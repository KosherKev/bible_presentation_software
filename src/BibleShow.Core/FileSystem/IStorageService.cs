using BibleShow.Core.Models;

namespace BibleShow.Core.FileSystem;

/// <summary>
/// Provides storage operations for managing Bible files and presentation data.
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Gets the root directory for all application data.
    /// </summary>
    string GetAppDataDirectory();

    /// <summary>
    /// Gets the directory where Bible files are stored.
    /// </summary>
    string GetBiblesDirectory();

    /// <summary>
    /// Gets the directory where presentation files are stored.
    /// </summary>
    string GetPresentationsDirectory();

    /// <summary>
    /// Gets the directory where theme files are stored.
    /// </summary>
    string GetThemesDirectory();

    /// <summary>
    /// Gets the directory for application backups.
    /// </summary>
    string GetBackupsDirectory();

    /// <summary>
    /// Saves a Bible to storage.
    /// </summary>
    Task SaveBibleAsync(Bible bible);

    /// <summary>
    /// Loads a Bible from storage by its ID.
    /// </summary>
    Task<Bible?> LoadBibleAsync(string bibleId);

    /// <summary>
    /// Saves a presentation to storage.
    /// </summary>
    Task SavePresentationAsync(Presentation presentation);

    /// <summary>
    /// Loads a presentation from storage by its ID.
    /// </summary>
    Task<Presentation?> LoadPresentationAsync(string presentationId);

    /// <summary>
    /// Gets all presentations from storage.
    /// </summary>
    Task<IEnumerable<Presentation>> GetAllPresentationsAsync();

    /// <summary>
    /// Saves a theme to storage.
    /// </summary>
    Task SaveThemeAsync(PresentationTheme theme);

    /// <summary>
    /// Loads a theme from storage by its ID.
    /// </summary>
    Task<PresentationTheme?> LoadThemeAsync(string themeId);

    /// <summary>
    /// Gets all themes from storage.
    /// </summary>
    Task<IEnumerable<PresentationTheme>> GetAllThemesAsync();

    /// <summary>
    /// Creates a backup of all application data.
    /// </summary>
    Task CreateBackupAsync(string backupName);

    /// <summary>
    /// Restores application data from a backup.
    /// </summary>
    Task RestoreFromBackupAsync(string backupName);

    /// <summary>
    /// Gets a list of available backups.
    /// </summary>
    Task<IEnumerable<string>> GetAvailableBackupsAsync();

    /// <summary>
    /// Ensures all required application directories exist.
    /// </summary>
    void EnsureDirectoriesExist();
}