using BibleShow.Core.Interfaces;
using BibleShow.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BibleShow.Core.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBibleShowCore(this IServiceCollection services)
    {
        // Register core services
        services.AddScoped<IBibleService, BibleService>();
        services.AddScoped<IPresentationService, PresentationService>();
        services.AddScoped<IThemeService, ThemeService>();

        // Register configuration validators
        services.AddSingleton<IBibleShowConfigurationValidator, BibleShowConfigurationValidator>();

        return services;
    }
}