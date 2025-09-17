using BibleShow.Core.Exceptions;

namespace BibleShow.Core.Configuration;

public class BibleShowConfigurationValidator : IBibleShowConfigurationValidator
{
    public void ValidateBibleConfiguration(BibleShowConfiguration configuration)
    {
        if (string.IsNullOrWhiteSpace(configuration.BiblesDirectory))
        {
            throw new BibleShowException("Bibles directory must be specified.");
        }

        if (!Directory.Exists(configuration.BiblesDirectory))
        {
            Directory.CreateDirectory(configuration.BiblesDirectory);
        }

        if (string.IsNullOrWhiteSpace(configuration.DefaultLanguage))
        {
            throw new BibleShowException("Default language must be specified.");
        }
    }

    public void ValidateStorageConfiguration(BibleShowConfiguration configuration)
    {
        var requiredDirectories = new[]
        {
            configuration.PresentationsDirectory,
            configuration.ThemesDirectory,
            configuration.BackupDirectory
        };

        foreach (var directory in requiredDirectories)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new BibleShowException($"Required directory path is not specified.");
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        if (configuration.EnableAutoBackup)
        {
            if (configuration.AutoBackupIntervalHours <= 0)
            {
                throw new BibleShowException("Auto backup interval must be greater than 0 hours.");
            }

            if (configuration.MaxBackupCount <= 0)
            {
                throw new BibleShowException("Maximum backup count must be greater than 0.");
            }
        }
    }
}