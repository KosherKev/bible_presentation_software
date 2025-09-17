using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace BibleShow.Core.FileSystem;

/// <summary>
/// Provides utility methods for cross-platform file system operations.
/// </summary>
public static class FileSystemUtilities
{
    /// <summary>
    /// Gets the default application data directory based on the current operating system.
    /// </summary>
    public static string GetDefaultAppDataDirectory()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BibleShow");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Library",
                "Application Support",
                "BibleShow");
        }
        else // Linux and others
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                ".bibleshow");
        }
    }

    /// <summary>
    /// Normalizes a file path to use the correct directory separators for the current platform.
    /// </summary>
    public static string NormalizePath(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        return path.Replace("\\", Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal)
                  .Replace("/", Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
    }

    /// <summary>
    /// Gets a relative path from a base directory to a full path.
    /// </summary>
    public static string GetRelativePath(string basePath, string fullPath)
    {
        var normalizedBase = NormalizePath(Path.GetFullPath(basePath));
        var normalizedFull = NormalizePath(Path.GetFullPath(fullPath));

        if (!normalizedFull.StartsWith(normalizedBase, StringComparison.Ordinal))
        {
            throw new ArgumentException($"Path '{fullPath}' is not under base path '{basePath}'");
        }

        var relativePath = normalizedFull.Substring(normalizedBase.Length);
        if (relativePath.StartsWith(Path.DirectorySeparatorChar))
        {
            relativePath = relativePath.Substring(1);
        }

        return relativePath;
    }

    /// <summary>
    /// Ensures a path uses forward slashes for cross-platform compatibility.
    /// </summary>
    public static string ToForwardSlashes(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        return path.Replace("\\", "/", StringComparison.Ordinal);
    }

    /// <summary>
    /// Gets the appropriate temporary directory for the current platform.
    /// </summary>
    public static string GetTempDirectory()
    {
        var tempPath = Path.GetTempPath();
        var tempDir = Path.Combine(tempPath, "BibleShow", Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        return tempDir;
    }

    /// <summary>
    /// Safely deletes a directory and its contents, handling common issues.
    /// </summary>
    public static void SafeDeleteDirectory(string path, int retryCount = 3, int retryDelayMs = 100)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (retryCount <= 0) throw new ArgumentOutOfRangeException(nameof(retryCount), "Retry count must be greater than 0");
        if (retryDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(retryDelayMs), "Retry delay must be non-negative");

        if (!Directory.Exists(path))
        {
            return;
        }

        for (int i = 0; i < retryCount; i++)
        {
            try
            {
                Directory.Delete(path, true);
                return;
            }
            catch (IOException) when (i < retryCount - 1)
            {
                Thread.Sleep(retryDelayMs);
            }
            catch (UnauthorizedAccessException) when (i < retryCount - 1)
            {
                Thread.Sleep(retryDelayMs);
            }
        }
    }

    /// <summary>
    /// Safely copies a directory and its contents, handling common issues.
    /// </summary>
    public static void SafeCopyDirectory(string sourcePath, string destinationPath, bool overwrite = true)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        if (!Directory.Exists(sourcePath))
        {
            throw new DirectoryNotFoundException($"Source directory '{sourcePath}' does not exist");
        }

        Directory.CreateDirectory(destinationPath);

        foreach (var dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath, StringComparison.Ordinal));
        }

        foreach (var filePath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        {
            var destFilePath = filePath.Replace(sourcePath, destinationPath, StringComparison.Ordinal);
            File.Copy(filePath, destFilePath, overwrite);
        }
    }

    /// <summary>
    /// Gets the appropriate line ending for the current platform.
    /// </summary>
    public static string GetPlatformLineEnding()
        => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

    /// <summary>
    /// Normalizes line endings in text content for the current platform.
    /// </summary>
    public static string NormalizeLineEndings(string content)
    {
        ArgumentNullException.ThrowIfNull(content);

        content = content.Replace("\r\n", "\n", StringComparison.Ordinal);
        content = content.Replace("\r", "\n", StringComparison.Ordinal);
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            content = content.Replace("\n", "\r\n", StringComparison.Ordinal);
        }

        return content;
    }
}