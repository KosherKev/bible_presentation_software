using System.Text.Json;

namespace BibleShow.Core.FileSystem;

/// <summary>
/// Provides a cross-platform abstraction for file system operations.
/// </summary>
public interface IFileSystem
{
    /// <summary>
    /// Checks if a file exists at the specified path.
    /// </summary>
    bool FileExists(string path);

    /// <summary>
    /// Checks if a directory exists at the specified path.
    /// </summary>
    bool DirectoryExists(string path);

    /// <summary>
    /// Creates a directory at the specified path if it doesn't exist.
    /// </summary>
    void CreateDirectory(string path);

    /// <summary>
    /// Reads all text from a file at the specified path.
    /// </summary>
    Task<string> ReadAllTextAsync(string path);

    /// <summary>
    /// Writes text to a file at the specified path.
    /// </summary>
    Task WriteAllTextAsync(string path, string content);

    /// <summary>
    /// Reads and deserializes JSON from a file at the specified path.
    /// </summary>
    async Task<T?> ReadJsonAsync<T>(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        var json = await ReadAllTextAsync(path).ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(json);
    }

    /// <summary>
    /// Serializes and writes an object as JSON to a file at the specified path.
    /// </summary>
    async Task WriteJsonAsync<T>(string path, T obj, JsonSerializerOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(obj);
        var json = JsonSerializer.Serialize(obj, options);
        await WriteAllTextAsync(path, json).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets all files in a directory that match the specified search pattern.
    /// </summary>
    IEnumerable<string> GetFiles(string path, string searchPattern = "*.*");

    /// <summary>
    /// Gets all directories in a directory.
    /// </summary>
    IEnumerable<string> GetDirectories(string path);

    /// <summary>
    /// Deletes a file at the specified path if it exists.
    /// </summary>
    void DeleteFile(string path);

    /// <summary>
    /// Deletes a directory and its contents at the specified path if it exists.
    /// </summary>
    void DeleteDirectory(string path, bool recursive = true);

    /// <summary>
    /// Copies a file from the source path to the destination path.
    /// </summary>
    void CopyFile(string sourcePath, string destinationPath, bool overwrite = false);

    /// <summary>
    /// Moves a file from the source path to the destination path.
    /// </summary>
    void MoveFile(string sourcePath, string destinationPath);

    /// <summary>
    /// Gets the full path by combining multiple path parts in a cross-platform way.
    /// </summary>
    string GetFullPath(params string[] paths);
}