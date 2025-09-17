namespace BibleShow.Core.Configuration;

public interface IBibleShowConfigurationValidator
{
    void ValidateBibleConfiguration(BibleShowConfiguration configuration);
    void ValidateStorageConfiguration(BibleShowConfiguration configuration);
}

public class BibleShowConfiguration
{
    public required string BiblesDirectory { get; init; }
    public required string PresentationsDirectory { get; init; }
    public required string ThemesDirectory { get; init; }
    public required string BackupDirectory { get; init; }
    public required string DefaultLanguage { get; init; } = "en";
    public required bool EnableCloudSync { get; init; }
    public required bool EnableAutoBackup { get; init; }
    public int AutoBackupIntervalHours { get; init; } = 24;
    public int MaxBackupCount { get; init; } = 10;
}