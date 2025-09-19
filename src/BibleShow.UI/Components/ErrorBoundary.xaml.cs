using Microsoft.Maui.Controls;
using BibleShow.Core.Interfaces;
using System.Windows.Input;
using BibleShow.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace BibleShow.UI.Components;

public partial class ErrorBoundary : ContentView
{
    private ICrashReportingService? _crashReportingService;
    private ILoggingService? _loggingService;
    private Exception? _lastError;
    private bool _hasError;
    private bool _servicesInitialized;

    public new View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public static readonly new BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(View), typeof(ErrorBoundary), null,
            propertyChanged: OnContentChanged);

    public ErrorBoundary()
    {
        InitializeComponent();
        _servicesInitialized = false;
        RegisterGlobalExceptionHandlers();
    }

    public ErrorBoundary(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        InitializeComponent();
        InitializeServices(services);
        RegisterGlobalExceptionHandlers();
    }

    private void RegisterGlobalExceptionHandlers()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            var exception = args.ExceptionObject as Exception;
            if (exception != null)
            {
                HandleError(new InvalidOperationException("An unhandled exception occurred in the application", exception));
            }
        };

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            if (!args.Observed)
            {
                HandleError(new InvalidOperationException("An unobserved task exception occurred", args.Exception));
                args.SetObserved();
            }
        };

        // Register platform-agnostic exception handler
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            if (args.ExceptionObject is Exception ex)
            {
                HandleError(new InvalidOperationException("An unhandled platform exception occurred", ex));
            }
        };
    }

    private void InitializeServices(IServiceProvider services)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(services);

            _crashReportingService = services.GetRequiredService<ICrashReportingService>() 
                ?? throw new InvalidOperationException($"{nameof(ICrashReportingService)} is not registered.");
            _loggingService = services.GetRequiredService<ILoggingService>()
                ?? throw new InvalidOperationException($"{nameof(ILoggingService)} is not registered.");
            
            _servicesInitialized = true;
        }
        catch (InvalidOperationException ex)
        {
            _servicesInitialized = false;
            ShowError(new InvalidOperationException("Failed to initialize error boundary services. Please ensure all required services are registered.", ex));
        }
    }

    public void EnsureServicesInitialized()
    {
        if (!_servicesInitialized)
        {
            var services = Application.Current?.Handler?.MauiContext?.Services
                ?? throw new InvalidOperationException(
                    "Services are not initialized. Use the WithErrorBoundary extension method to wrap views with error handling.");
            InitializeServices(services);
        }

        if (!_servicesInitialized || _crashReportingService == null || _loggingService == null)
        {
            _servicesInitialized = false;
        }
    }

    private static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ErrorBoundary errorBoundary)
        {
            errorBoundary.UpdateContent();
        }
    }

    private void UpdateContent()
    {
        try
        {
            EnsureServicesInitialized();
            
            var contentContainerControl = ContentContainer;
            var errorContainerControl = ErrorContainer;
            
            if (contentContainerControl == null || errorContainerControl == null)
            {
                var message = _hasError && _lastError != null
                    ? GetUserFriendlyErrorMessage(_lastError)
                    : "An error occurred while loading the application. Please try again later.";
                Content = CreateErrorLabel(message);
                return;
            }
            
            if (_hasError)
            {
                contentContainerControl.Content = CreateErrorDisplay();
                errorContainerControl.IsVisible = true;
            }
            else
            {
                contentContainerControl.Content = Content;
                errorContainerControl.IsVisible = false;
            }
        }
        catch (InvalidOperationException ex)
        {
            if (_servicesInitialized && _loggingService != null && _crashReportingService != null)
            {
                _loggingService.LogError("Failed to update error boundary content - invalid operation", ex);
                _crashReportingService.ReportError("Error boundary content update failed", ex, new Dictionary<string, string>
                {
                    { "error_type", "content_update" }
                });
            }
            ShowError(ex);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            if (_servicesInitialized && _loggingService != null && _crashReportingService != null)
            {
                _loggingService.LogError("Failed to update error boundary content - unexpected error", ex);
                _crashReportingService.ReportError("Error boundary content update failed", ex, new Dictionary<string, string>
                {
                    { "error_type", "unexpected" }
                });
            }
            ShowError(ex);
        }
    }

    private VerticalStackLayout CreateErrorDisplay()
    {
        return new VerticalStackLayout
        {
            Spacing = 20,
            Children =
            {
                new Label
                {
                    Text = _lastError != null ? GetUserFriendlyErrorMessage(_lastError) : "An error occurred",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 16
                },
                new Button
                {
                    Text = "Retry",
                    Command = new Command((object? _) => OnRetryClicked(null, EventArgs.Empty)),
                    HorizontalOptions = LayoutOptions.Center
                }
            }
        };
    }

    public static string GetUserFriendlyErrorMessage(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);

        return exception switch
        {
            InvalidOperationException => "The application encountered an error while performing an operation. Please try again.",
            ArgumentException => "Invalid input was provided. Please check your input and try again.",
            TimeoutException => "The operation timed out. Please check your connection and try again.",
            TaskCanceledException => "The operation was cancelled. Please try again.",
            _ => "An unexpected error occurred. Please try again or contact support if the problem persists."
        };
    }

    public void HandleError(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);

        try
        {
            EnsureServicesInitialized();

            // Store services in local variables to prevent multiple property accesses
            var loggingService = _loggingService;
            var crashReportingService = _crashReportingService;

            // Create error context for logging and reporting
            var errorContext = new Dictionary<string, string>
            {
                { "component", "error_boundary" },
                { "error_type", exception.GetType().Name },
                { "error_message", exception.Message },
                { "stack_trace", exception.StackTrace ?? "No stack trace available" },
                { "source", exception.Source ?? "Unknown source" },
                { "has_inner_exception", (exception.InnerException != null).ToString() }
            };

            if (exception.InnerException != null)
            {
                errorContext.Add("inner_exception_type", exception.InnerException.GetType().Name);
                errorContext.Add("inner_exception_message", exception.InnerException.Message);
            }

            // Log the error with full context
            if (_servicesInitialized && loggingService != null)
            {
                loggingService.LogError($"Error boundary caught exception: {exception.Message}", exception);
                
                if (exception.InnerException != null)
                {
                    loggingService.LogError("Inner exception details:", exception.InnerException);
                }
            }

            // Report the error with full context
            if (_servicesInitialized && crashReportingService != null)
            {
                crashReportingService.ReportError("Error boundary exception", exception, errorContext);
            }

            // Update UI state
            _lastError = exception;
            _hasError = true;

            // Ensure UI updates happen on the main thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    UpdateContent();
                }
                catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
                {
                    if (_servicesInitialized && loggingService != null)
                    {
                        loggingService.LogError("Failed to update UI after error", ex);
                    }
                    ShowError(new InvalidOperationException("Failed to update UI after error", ex));
                }
            });
        }
        catch (InvalidOperationException ex)
        {
            var loggingService = _loggingService;
            if (_servicesInitialized && loggingService != null)
            {
                loggingService.LogError("Failed to handle error in error boundary - invalid operation", ex);
                loggingService.LogError("Original error that triggered the failure", exception);
            }
            ShowError(new AggregateException("Multiple errors occurred in error boundary", new[] { exception, ex }));
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            var loggingService = _loggingService;
            if (_servicesInitialized && loggingService != null)
            {
                loggingService.LogError("Failed to handle error in error boundary - unexpected error", ex);
                loggingService.LogError("Original error that triggered the failure", exception);
            }
            ShowError(new AggregateException("Multiple errors occurred in error boundary", new[] { exception, ex }));
        }
    }

    private void OnRetryClicked(object? sender, EventArgs e)
    {
        try
        {
            _hasError = false;
            _lastError = null;
            UpdateContent();
        }
        catch (InvalidOperationException ex)
        {
            var loggingService = _loggingService;
            var crashReportingService = _crashReportingService;

            if (_servicesInitialized && loggingService != null && crashReportingService != null)
            {
                loggingService.LogError("Failed to retry in error boundary - invalid operation", ex);
                crashReportingService.ReportError("Error boundary retry failed", ex, new Dictionary<string, string>
                {
                    { "error_type", "retry_operation" }
                });
            }
            ShowError(ex);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            var loggingService = _loggingService;
            var crashReportingService = _crashReportingService;

            if (_servicesInitialized && loggingService != null && crashReportingService != null)
            {
                loggingService.LogError("Failed to retry in error boundary - unexpected error", ex);
                crashReportingService.ReportError("Error boundary retry failed", ex, new Dictionary<string, string>
                {
                    { "error_type", "unexpected" }
                });
            }
            ShowError(ex);
        }
    }

    private void ShowError(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);

        try
        {
            if (_servicesInitialized && _loggingService != null && _crashReportingService != null)
            {
                try
                {
                    _loggingService.LogError("Error boundary showing error", exception);
                    _crashReportingService.ReportError("Error boundary showing error", exception, new Dictionary<string, string>
                    {
                        { "component", "error_boundary" },
                        { "error_type", exception.GetType().Name }
                    });
                }
                catch (InvalidOperationException)
                {
                    _servicesInitialized = false;
                }
            }

            ShowErrorMessage(exception, GetUserFriendlyErrorMessage(exception));
        }
        catch (ObjectDisposedException)
        {
            ShowErrorMessage(exception, "A critical error occurred");
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            ShowErrorMessage(exception, GetUserFriendlyErrorMessage(exception));
        }
    }

    private void ShowErrorMessage(Exception exception, string message)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(message);

        _lastError = exception;
        _hasError = true;

        // Store UI controls in local variables to prevent multiple property accesses
        var errorMessageControl = ErrorMessage;
        var errorContainerControl = ErrorContainer;
        var contentContainerControl = ContentContainer;

        // Track if we need to fall back to a simpler error display
        bool needsFallback = false;
        Exception? fallbackException = null;

        try
        {
            if (errorMessageControl?.Handler != null && errorContainerControl?.Handler != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        errorMessageControl.Text = message;
                        errorContainerControl.IsVisible = true;

                        // Ensure content container is hidden when showing error
                        if (contentContainerControl?.Handler != null)
                        {
                            contentContainerControl.IsVisible = false;
                        }

                        UpdateContent();
                    }
                    catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
                    {
                        needsFallback = true;
                        fallbackException = ex;
                    }
                });
            }
            else
            {
                needsFallback = true;
            }
        }
        catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
        {
            needsFallback = true;
            fallbackException = ex;
        }

        // If primary error display failed, try fallback approaches
        if (needsFallback)
        {
            try
            {
                var fallbackLabel = new Label
                {
                    Text = message,
                    TextColor = Colors.Red,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(20)
                };

                var fallbackContainer = new ScrollView
                {
                    Content = new VerticalStackLayout
                    {
                        Children =
                        {
                            fallbackLabel,
                            new Button
                            {
                                Text = "Retry",
                                Command = new Command((object? _) => OnRetryClicked(null, EventArgs.Empty)),
                                HorizontalOptions = LayoutOptions.Center,
                                Margin = new Thickness(0, 10, 0, 0)
                            }
                        }
                    }
                };

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Content = fallbackContainer;
                    }
                    catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
                    {
                        // Log the failure to create even the fallback UI
                        if (_servicesInitialized && _loggingService != null)
                        {
                            _loggingService.LogError("Failed to create fallback error UI", ex);
                            if (fallbackException != null)
                            {
                                _loggingService.LogError("Original error that triggered fallback", fallbackException);
                            }
                        }
                    }
                });
            }
            catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
            {
                // Last resort: log the complete failure to show any error UI
                if (_servicesInitialized && _loggingService != null)
                {
                    _loggingService.LogError("Failed to show any error UI", ex);
                    if (fallbackException != null)
                    {
                        _loggingService.LogError("Original error that triggered fallback", fallbackException);
                    }
                }
            }
        }
    }

    private static Label CreateErrorLabel(string text)
    {
        return new Label
        {
            Text = text,
            TextColor = Colors.Red,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }
}