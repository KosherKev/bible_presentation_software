using System;
using BibleShow.Core.FileSystem;
using BibleShow.Core.Exceptions;

namespace BibleShow.Core.Configuration
{
    public class BibleShowConfigurationValidator : IBibleShowConfigurationValidator
    {
        private readonly IFileSystem _fileSystem;

        public BibleShowConfigurationValidator(IFileSystem fileSystem)
        {
            ArgumentNullException.ThrowIfNull(fileSystem);
            _fileSystem = fileSystem;
        }

        public void ValidateConfiguration(BibleShowConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            ValidateBibleConfiguration(configuration);
            ValidateStorageConfiguration(configuration);
        }

        public void ValidateBibleConfiguration(BibleShowConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            var bibleConfig = configuration.BibleConfiguration 
                ?? throw new ConfigurationValidationException("BibleConfiguration section is missing");

            if (string.IsNullOrEmpty(bibleConfig.DefaultLanguage))
            {
                throw new ConfigurationValidationException("DefaultLanguage must be specified in BibleConfiguration");
            }

            if (bibleConfig.MaxSearchResults <= 0)
            {
                throw new ConfigurationValidationException("MaxSearchResults must be greater than 0 in BibleConfiguration");
            }
        }

        public void ValidateStorageConfiguration(BibleShowConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            var storageConfig = configuration.StorageConfiguration 
                ?? throw new ConfigurationValidationException("StorageConfiguration section is missing");

            if (string.IsNullOrEmpty(storageConfig.AppDataDirectory))
            {
                throw new ConfigurationValidationException("AppDataDirectory must be specified in StorageConfiguration");
            }

            if (storageConfig.MaxBackupCount <= 0)
            {
                throw new ConfigurationValidationException("MaxBackupCount must be greater than 0 in StorageConfiguration");
            }

            if (string.IsNullOrEmpty(storageConfig.BackupNameFormat))
            {
                throw new ConfigurationValidationException("BackupNameFormat must be specified in StorageConfiguration");
            }

            try
            {
                // Ensure the application data directory exists
                _fileSystem.CreateDirectory(storageConfig.AppDataDirectory);

                // Ensure required subdirectories exist
                var requiredDirs = new[]
                {
                    _fileSystem.GetFullPath(storageConfig.AppDataDirectory, "bibles"),
                    _fileSystem.GetFullPath(storageConfig.AppDataDirectory, "presentations"),
                    _fileSystem.GetFullPath(storageConfig.AppDataDirectory, "themes"),
                    _fileSystem.GetFullPath(storageConfig.AppDataDirectory, "backups")
                };

                foreach (var dir in requiredDirs)
                {
                    _fileSystem.CreateDirectory(dir);
                }

                // Validate backup directory permissions
                var testFile = _fileSystem.GetFullPath(
                    storageConfig.AppDataDirectory,
                    "backups",
                    ".test_write_permission");

                _fileSystem.WriteAllTextAsync(testFile, "test").GetAwaiter().GetResult();
                _fileSystem.DeleteFile(testFile);
            }
            catch (Exception ex)
            {
                throw new ConfigurationValidationException(
                    "Cannot access or write to required directories. Please check permissions.",
                    ex);
            }
        }
    }
}
