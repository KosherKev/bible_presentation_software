namespace BibleShow.Core.Configuration;

public interface IBibleShowConfigurationValidator
{
    void ValidateConfiguration(BibleShowConfiguration configuration);
    void ValidateBibleConfiguration(BibleShowConfiguration configuration);
    void ValidateStorageConfiguration(BibleShowConfiguration configuration);
}

public class BibleShowConfiguration
{
    public StorageConfiguration StorageConfiguration { get; set; } = new();
    public BibleConfiguration BibleConfiguration { get; set; } = new();
}

public class StorageConfiguration
{
    public string AppDataDirectory { get; set; } = FileSystem.FileSystemUtilities.GetDefaultAppDataDirectory();
    public bool EnableAutoBackup { get; set; } = true;
    public int MaxBackupCount { get; set; } = 5;
    public string BackupNameFormat { get; set; } = "backup_{0}";
}

public class BibleConfiguration
{
    public string DefaultBibleId { get; set; } = string.Empty;
    public string DefaultLanguage { get; set; } = "en";
    public bool EnableSearchHighlighting { get; set; } = true;
    public int MaxSearchResults { get; set; } = 100;
}