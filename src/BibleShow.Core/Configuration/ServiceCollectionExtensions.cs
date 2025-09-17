using System;
using Microsoft.Extensions.DependencyInjection;
using BibleShow.Core.FileSystem;
using BibleShow.Core.Services;
using BibleShow.Core.Interfaces;

namespace BibleShow.Core.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBibleShowCore(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // File System Services
            services.AddSingleton<IFileSystem, FileSystemProvider>();
        services.AddSingleton<IStorageService, StorageService>();

        // Configuration Validation
        services.AddSingleton<IBibleShowConfigurationValidator, BibleShowConfigurationValidator>();

        // Core Services
        services.AddScoped<IBibleService, BibleService>();
        services.AddScoped<IPresentationService, PresentationService>();
        services.AddScoped<IThemeService, ThemeService>();

        return services;
    }
}