using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;
using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.Models;
using Microsoft.Extensions.Options;

namespace BibleShow.Core.FileSystem;

/// <summary>
/// Default implementation of IStorageService using the file system.
/// </summary>
public class StorageService : IStorageService
{
    private readonly IFileSystem _fileSystem;
    private readonly BibleShowConfiguration _configuration;
    private readonly JsonSerializerOptions _jsonOptions;

    public StorageService(
        IFileSystem fileSystem,
        IOptions<BibleShowConfiguration> configuration)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _configuration = configuration?.Value ?? throw new ArgumentNullException(nameof(configuration));
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
    }

    public string GetAppDataDirectory()
        => _configuration.StorageConfiguration.AppDataDirectory;

    public string GetBiblesDirectory()
        => _fileSystem.GetFullPath(GetAppDataDirectory(), "bibles");

    public string GetPresentationsDirectory()
        => _fileSystem.GetFullPath(GetAppDataDirectory(), "presentations");

    public string GetThemesDirectory()
        => _fileSystem.GetFullPath(GetAppDataDirectory(), "themes");

    public string GetBackupsDirectory()
        => _fileSystem.GetFullPath(GetAppDataDirectory(), "backups");

    public async Task SaveBibleAsync(Bible bible)
    {
        ArgumentNullException.ThrowIfNull(bible);
        var path = _fileSystem.GetFullPath(GetBiblesDirectory(), $"{bible.Id}.json");
        await _fileSystem.WriteJsonAsync(path, bible, _jsonOptions).ConfigureAwait(false);
    }

    public async Task<Bible?> LoadBibleAsync(string bibleId)
    {
        ArgumentNullException.ThrowIfNull(bibleId);
        var path = _fileSystem.GetFullPath(GetBiblesDirectory(), $"{bibleId}.json");
        if (!_fileSystem.FileExists(path))
        {
            return null;
        }
        return await _fileSystem.ReadJsonAsync<Bible>(path).ConfigureAwait(false);
    }

    public async Task SavePresentationAsync(Presentation presentation)
        {
            ArgumentNullException.ThrowIfNull(presentation);
            var path = _fileSystem.GetFullPath(GetPresentationsDirectory(), $"{presentation.Id}.json");
            await _fileSystem.WriteJsonAsync(path, presentation, _jsonOptions).ConfigureAwait(false);
        }

    public async Task<Presentation?> LoadPresentationAsync(string presentationId)
    {
        var path = _fileSystem.GetFullPath(GetPresentationsDirectory(), $"{presentationId}.json");
        if (!_fileSystem.FileExists(path))
        {
            return null;
        }
        return await _fileSystem.ReadJsonAsync<Presentation>(path).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Presentation>> GetAllPresentationsAsync()
    {
        var presentations = new List<Presentation>();
        var files = _fileSystem.GetFiles(GetPresentationsDirectory(), "*.json");

        foreach (var file in files)
        {
            var presentation = await _fileSystem.ReadJsonAsync<Presentation>(file).ConfigureAwait(false);
            if (presentation != null)
            {
                presentations.Add(presentation);
            }
        }

        return presentations;
    }

    public async Task SaveThemeAsync(PresentationTheme theme)
    {
        ArgumentNullException.ThrowIfNull(theme);
        var path = _fileSystem.GetFullPath(GetThemesDirectory(), $"{theme.Id}.json");
        await _fileSystem.WriteJsonAsync(path, theme, _jsonOptions).ConfigureAwait(false);
    }

    public async Task<PresentationTheme?> LoadThemeAsync(string themeId)
    {
        var path = _fileSystem.GetFullPath(GetThemesDirectory(), $"{themeId}.json");
        if (!_fileSystem.FileExists(path))
        {
            return null;
        }
        return await _fileSystem.ReadJsonAsync<PresentationTheme>(path).ConfigureAwait(false);
    }

    public async Task<IEnumerable<PresentationTheme>> GetAllThemesAsync()
    {
        var themes = new List<PresentationTheme>();
        var files = _fileSystem.GetFiles(GetThemesDirectory(), "*.json");

        foreach (var file in files)
        {
            var theme = await _fileSystem.ReadJsonAsync<PresentationTheme>(file).ConfigureAwait(false);
            if (theme != null)
            {
                themes.Add(theme);
            }
        }

        return themes;
    }

    public async Task CreateBackupAsync(string backupName)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        var backupDir = _fileSystem.GetFullPath(GetBackupsDirectory(), $"{backupName}_{timestamp}");
        
        await Task.Run(() => _fileSystem.CreateDirectory(backupDir)).ConfigureAwait(false);

        // Backup Bibles
        var biblesBackupDir = _fileSystem.GetFullPath(backupDir, "bibles");
        foreach (var file in _fileSystem.GetFiles(GetBiblesDirectory()))
        {
            await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(biblesBackupDir, Path.GetFileName(file)))).ConfigureAwait(false);
        }

        // Backup Presentations
        var presentationsBackupDir = _fileSystem.GetFullPath(backupDir, "presentations");
        foreach (var file in _fileSystem.GetFiles(GetPresentationsDirectory()))
        {
            await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(presentationsBackupDir, Path.GetFileName(file)))).ConfigureAwait(false);
        }

        // Backup Themes
        var themesBackupDir = _fileSystem.GetFullPath(backupDir, "themes");
        foreach (var file in _fileSystem.GetFiles(GetThemesDirectory()))
        {
            await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(themesBackupDir, Path.GetFileName(file)))).ConfigureAwait(false);
        }
    }

    public async Task RestoreFromBackupAsync(string backupName)
    {
        var backupDir = _fileSystem.GetFullPath(GetBackupsDirectory(), backupName);
        if (!_fileSystem.DirectoryExists(backupDir))
        {
            throw new BibleShowException($"Backup '{backupName}' not found.");
        }

        // Restore Bibles
        var biblesBackupDir = _fileSystem.GetFullPath(backupDir, "bibles");
        if (_fileSystem.DirectoryExists(biblesBackupDir))
        {
            foreach (var file in _fileSystem.GetFiles(biblesBackupDir))
            {
                await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(GetBiblesDirectory(), Path.GetFileName(file)), true)).ConfigureAwait(false);
            }
        }

        // Restore Presentations
        var presentationsBackupDir = _fileSystem.GetFullPath(backupDir, "presentations");
        if (_fileSystem.DirectoryExists(presentationsBackupDir))
        {
            foreach (var file in _fileSystem.GetFiles(presentationsBackupDir))
            {
                await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(GetPresentationsDirectory(), Path.GetFileName(file)), true)).ConfigureAwait(false);
            }
        }

        // Restore Themes
        var themesBackupDir = _fileSystem.GetFullPath(backupDir, "themes");
        if (_fileSystem.DirectoryExists(themesBackupDir))
        {
            foreach (var file in _fileSystem.GetFiles(themesBackupDir))
            {
                await Task.Run(() => _fileSystem.CopyFile(file, _fileSystem.GetFullPath(GetThemesDirectory(), Path.GetFileName(file)), true)).ConfigureAwait(false);
            }
        }
    }

    public Task<IEnumerable<string>> GetAvailableBackupsAsync()
    {
        return Task.FromResult(_fileSystem.GetDirectories(GetBackupsDirectory())
            .Select(dir => Path.GetFileName(dir) ?? string.Empty)
            .Where(name => !string.IsNullOrEmpty(name)));
    }

    public void EnsureDirectoriesExist()
    {
        _fileSystem.CreateDirectory(GetAppDataDirectory());
        _fileSystem.CreateDirectory(GetBiblesDirectory());
        _fileSystem.CreateDirectory(GetPresentationsDirectory());
        _fileSystem.CreateDirectory(GetThemesDirectory());
        _fileSystem.CreateDirectory(GetBackupsDirectory());
    }
}