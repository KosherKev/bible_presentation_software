using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BibleShow.Core.Services;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Configuration;
using BibleShow.Core.FileSystem;
using BibleShow.UI.Configuration;
using BibleShow.UI.Components;
using BibleShow.UI.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace BibleShow.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Initialize fallback logger early in case main logging fails
            BibleShow.Core.Services.FallbackLogger.Initialize();
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

// Removed problematic MacCatalyst window configuration that was causing HIServices faults

            // Register services
            builder.Services.AddSingleton<ILoggingService, LoggingService>();
            builder.Services.AddSingleton<ICrashReportingService, CrashReportingService>();
            builder.Services.AddSingleton<BibleShow.Core.FileSystem.IFileSystem, FileSystemProvider>();
            builder.Services.AddSingleton<IStorageService, StorageService>();

            // Register UI components
            builder.Services.AddTransient<ErrorBoundary>();
            builder.Services.AddTransient<ExamplePage>();
            builder.Services.AddScoped<MainPage>();

            // Configure logging
            builder.Logging.AddDebug();

            // Load configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Microsoft.Maui.Storage.FileSystem.AppDataDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            builder.Configuration.AddConfiguration(config);

            // Configure services
            builder.Services.Configure<AppSettings>(config.GetSection("AppSettings"));
            builder.Services.Configure<BibleShowConfiguration>(config.GetSection("BibleShow"));

            // Add core services
            builder.Services.AddBibleShowCore();

            var app = builder.Build();

            // Initialize services
            try
            {
                var crashReportingService = app.Services.GetRequiredService<ICrashReportingService>();
                crashReportingService.Initialize();

                // Initialize storage service
                var storageService = app.Services.GetRequiredService<IStorageService>();
                storageService.EnsureDirectoriesExist();

                // Initialize App services
                if (Application.Current is App appInstance)
                {
                    appInstance.InitializeServices(app.Services);
                }
            }
            catch (Exception ex)
            {
                var loggingService = app.Services.GetRequiredService<ILoggingService>();
                loggingService.LogCritical("Failed to initialize services", ex);
                throw;
            }

            return app;
        }
    }
}

