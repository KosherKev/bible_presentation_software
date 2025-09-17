using BibleShow.Core.Models;

namespace BibleShow.Core.Interfaces;

public interface IThemeService
{
    Task<IEnumerable<PresentationTheme>> GetAllThemesAsync();
    Task<PresentationTheme?> GetThemeByIdAsync(string id);
    Task<PresentationTheme> CreateThemeAsync(PresentationTheme theme);
    Task<PresentationTheme> UpdateThemeAsync(PresentationTheme theme);
    Task DeleteThemeAsync(string id);
    Task<PresentationTheme> DuplicateThemeAsync(string id, string newName);
}