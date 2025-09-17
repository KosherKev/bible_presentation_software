using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using Microsoft.Extensions.Options;

namespace BibleShow.Core.Services;

public class ThemeService : IThemeService
{
    private readonly BibleShowConfiguration _configuration;
    private readonly IBibleShowConfigurationValidator _validator;

    public ThemeService(
        IOptions<BibleShowConfiguration> configuration,
        IBibleShowConfigurationValidator validator)
    {
        _configuration = configuration.Value;
        _validator = validator;
        _validator.ValidateStorageConfiguration(_configuration);
    }

    public Task<IEnumerable<PresentationTheme>> GetAllThemesAsync()
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationTheme?> GetThemeByIdAsync(string id)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationTheme> CreateThemeAsync(PresentationTheme theme)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationTheme> UpdateThemeAsync(PresentationTheme theme)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task DeleteThemeAsync(string id)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationTheme> DuplicateThemeAsync(string id, string newName)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }
}