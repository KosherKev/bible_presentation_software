using Microsoft.Maui.Controls;
using BibleShow.Core.Services;
using BibleShow.Core.Interfaces;
using BibleShow.UI.Components;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BibleShow.UI.Pages;

public partial class ExamplePage : ContentPage
{
    private readonly ICrashReportingService _crashReportingService;
    private readonly ILoggingService _loggingService;
    private readonly IServiceProvider _serviceProvider;

    public ObservableCollection<string> Items { get; } = new();

    public ExamplePage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        try
        {
            _crashReportingService = _serviceProvider.GetRequiredService<ICrashReportingService>();
            _loggingService = _serviceProvider.GetRequiredService<ILoggingService>();

            InitializeComponent();
            BindingContext = this;

            MainContent.WithErrorBoundary(_serviceProvider);
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to initialize ExamplePage - service not found", ex);
            _crashReportingService?.ReportError("ExamplePage initialization failed", ex, new Dictionary<string, string>
            {
                { "error_type", "service_not_found" }
            });
            throw;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _loggingService?.LogError("Failed to initialize ExamplePage", ex);
            _crashReportingService?.ReportError("ExamplePage initialization failed", ex, new Dictionary<string, string>
            {
                { "error_type", "unexpected" }
            });
            throw;
        }
    }

    private async void OnLoadItemsClicked(object sender, EventArgs e)
    {
        try
        {
            await LoadItemsAsync().ConfigureAwait(true);
        }
        catch (InvalidOperationException ex)
        {
            _loggingService.LogError("Failed to load items - invalid operation", ex);
            _crashReportingService.ReportError("Item loading failed", ex, new Dictionary<string, string>
            {
                { "error_type", "invalid_operation" }
            });
            MainContent.PropagateError(ex);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _loggingService.LogError("Failed to load items", ex);
            _crashReportingService.ReportError("Item loading failed", ex, new Dictionary<string, string>
            {
                { "error_type", "unexpected" }
            });
            MainContent.PropagateError(ex);
        }
    }

    private void OnErrorButtonClicked(object sender, EventArgs e)
    {
        try
        {
            throw new InvalidOperationException("This is a test error");
        }
        catch (InvalidOperationException ex)
        {
            _loggingService.LogError("Test error triggered", ex);
            _crashReportingService.ReportError("Test error", ex, new Dictionary<string, string>
            {
                { "error_type", "test_error" }
            });
            MainContent.PropagateError(ex);
        }
    }

    private async Task LoadItemsAsync()
    {
        // Simulate loading delay
        await Task.Delay(1000).ConfigureAwait(true);

        // Add some test items
        Items.Clear();
        Items.Add("Item 1");
        Items.Add("Item 2");
        Items.Add("Item 3");
    }
}