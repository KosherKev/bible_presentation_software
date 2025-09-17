using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibleShow.Core.FileSystem;

public class FileSystemProvider : IFileSystem
{
        private static readonly JsonSerializerOptions DefaultJsonOptions = new()
        {
            WriteIndented = true
        };

        public bool FileExists(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            Directory.CreateDirectory(path);
        }

        public async Task<string> ReadAllTextAsync(string path)
        {
            ArgumentNullException.ThrowIfNull(path);
            return await File.ReadAllTextAsync(path).ConfigureAwait(false);
        }

        public async Task WriteAllTextAsync(string path, string content)
        {
            ArgumentNullException.ThrowIfNull(path);
            ArgumentNullException.ThrowIfNull(content);

            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
            {
                CreateDirectory(directory);
            }
            await File.WriteAllTextAsync(path, content).ConfigureAwait(false);
        }

        public async Task<T?> ReadJsonAsync<T>(string path)
        {
            ArgumentNullException.ThrowIfNull(path);

            var content = await ReadAllTextAsync(path).ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(content, DefaultJsonOptions);
        }

        public async Task WriteJsonAsync<T>(string path, T value)
        {
            ArgumentNullException.ThrowIfNull(path);
            ArgumentNullException.ThrowIfNull(value);

            var content = JsonSerializer.Serialize(value, DefaultJsonOptions);
            await WriteAllTextAsync(path, content).ConfigureAwait(false);
        }

        public IEnumerable<string> GetFiles(string path, string searchPattern = "*.*")
        {
            ArgumentNullException.ThrowIfNull(path);
            ArgumentNullException.ThrowIfNull(searchPattern);

            return Directory.Exists(path) 
                ? Directory.GetFiles(path, searchPattern)
                : Array.Empty<string>();
        }

        public IEnumerable<string> GetDirectories(string path)
        {
            ArgumentNullException.ThrowIfNull(path);

            return Directory.Exists(path)
                ? Directory.GetDirectories(path)
                : Array.Empty<string>();
        }

        public void DeleteFile(string path)
        {
            ArgumentNullException.ThrowIfNull(path);

            if (FileExists(path))
            {
                File.Delete(path);
            }
        }

        public void DeleteDirectory(string path, bool recursive = true)
        {
            ArgumentNullException.ThrowIfNull(path);

            if (DirectoryExists(path))
            {
                Directory.Delete(path, recursive);
            }
        }

        public void CopyFile(string sourcePath, string destinationPath, bool overwrite = false)
        {
            ArgumentNullException.ThrowIfNull(sourcePath);
            ArgumentNullException.ThrowIfNull(destinationPath);

            var destinationDirectory = Path.GetDirectoryName(destinationPath);
            if (!string.IsNullOrEmpty(destinationDirectory))
            {
                CreateDirectory(destinationDirectory);
            }
            File.Copy(sourcePath, destinationPath, overwrite);
        }

        public void MoveFile(string sourcePath, string destinationPath)
        {
            ArgumentNullException.ThrowIfNull(sourcePath);
            ArgumentNullException.ThrowIfNull(destinationPath);

            var destinationDirectory = Path.GetDirectoryName(destinationPath);
            if (!string.IsNullOrEmpty(destinationDirectory))
            {
                CreateDirectory(destinationDirectory);
            }
            File.Move(sourcePath, destinationPath, true);
        }

        public string GetFullPath(params string[] paths)
        {
            ArgumentNullException.ThrowIfNull(paths);
            if (paths.Length == 0)
            {
                throw new ArgumentException("At least one path must be provided.", nameof(paths));
            }

            return Path.GetFullPath(Path.Combine(paths));
        }
    }