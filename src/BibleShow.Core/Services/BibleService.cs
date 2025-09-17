using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.FileSystem;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using BibleShow.Core.Utils;
using Microsoft.Extensions.Options;

namespace BibleShow.Core.Services;

public class BibleService : IBibleService
{
    private readonly BibleShowConfiguration _configuration;
    private readonly IBibleShowConfigurationValidator _validator;
    private readonly IFileSystem _fileSystem;
    private readonly Dictionary<string, Bible> _bibleCache = new();

    public BibleService(
            IOptions<BibleShowConfiguration> configuration,
            IBibleShowConfigurationValidator validator,
            IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(validator);
        ArgumentNullException.ThrowIfNull(fileSystem);

        _configuration = configuration.Value;
        _validator = validator;
        _fileSystem = fileSystem;
        _validator.ValidateBibleConfiguration(_configuration);
    }

    public async Task<IEnumerable<Bible>> GetAllBiblesAsync()
    {
        await LoadBiblesAsync().ConfigureAwait(false);
        return _bibleCache.Values;
    }

    public async Task<Bible?> GetBibleByIdAsync(string id)
    {
        ArgumentNullException.ThrowIfNull(id);

        if (_bibleCache.Count == 0)
        {
            await LoadBiblesAsync().ConfigureAwait(false);
        }

        if (!_bibleCache.TryGetValue(id, out var bible))
        {
            throw new BibleNotFoundException($"Bible with ID {id} not found.");
        }

        return bible;
    }

    public async Task<Book?> GetBookAsync(string bibleId, string bookId)
    {
        var bible = await GetBibleByIdAsync(bibleId).ConfigureAwait(false);
        if (bible == null)
            throw new BibleNotFoundException(bibleId);

        return bible.Books.FirstOrDefault(b => b.Id == bookId);
    }

    public async Task<Chapter?> GetChapterAsync(string bibleId, string bookId, string chapterId)
    {
        var book = await GetBookAsync(bibleId, bookId).ConfigureAwait(false);
        if (book == null)
            throw new BibleShowException($"Book '{bookId}' not found in Bible '{bibleId}'.");

        return book.Chapters.FirstOrDefault(c => c.Id == chapterId);
    }

    public async Task<IEnumerable<Verse>> GetVersesAsync(string bibleId, string bookId, string chapterId, IEnumerable<string> verseIds)
    {
        var chapter = await GetChapterAsync(bibleId, bookId, chapterId).ConfigureAwait(false);
        if (chapter == null)
            throw new BibleShowException($"Chapter '{chapterId}' not found in Book '{bookId}' of Bible '{bibleId}'.");

        var verseIdSet = new HashSet<string>(verseIds);
        return chapter.Verses.Where(v => verseIdSet.Contains(v.Id));
    }

    public async Task<IEnumerable<SearchResult>> SearchAsync(string bibleId, string searchText, SearchOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(searchText))
            throw new ArgumentException("Search text cannot be empty.", nameof(searchText));

        if (_bibleCache.Count == 0)
        {
            await LoadBiblesAsync().ConfigureAwait(false);
        }

        if (!_bibleCache.TryGetValue(bibleId, out var bible))
        {
            throw new BibleNotFoundException($"Bible with ID {bibleId} not found.");
        }

        var results = new List<SearchResult>();
        var normalizedSearchText = TextProcessingUtility.NormalizeText(searchText, options?.CaseSensitive ?? false);

        foreach (var verse in bible.GetAllVerses())
        {
            if (options?.BookFilter != null && (verse.Id == null || !verse.Id.StartsWith($"{options.BookFilter}.", StringComparison.Ordinal)))
                continue;

            if (options?.ChapterFilter != null)
            {
                var parts = verse.Id?.Split('.') ?? Array.Empty<string>();
                if (parts.Length < 2 || parts[1] != options.ChapterFilter)
                    continue;
            }

            var matches = TextProcessingUtility.FindMatches(verse.Text, searchText, options?.CaseSensitive ?? false);

            if (matches.Any())
            {
                var parts = verse.Id?.Split('.') ?? Array.Empty<string>();
                if (parts.Length >= 2)
                {
                    results.Add(new SearchResult
                    {
                        BibleId = bible.Id,
                        BookId = parts[0],
                        ChapterId = parts[1],
                        Verse = verse,
                        Highlights = matches.Select(m => new TextHighlight 
                        { 
                            StartIndex = m.StartIndex,
                            Length = m.Length,
                            MatchedText = verse.Text.Substring(m.StartIndex, m.Length)
                        }).ToList()
                    });

                    if (options?.MaxResults > 0 && results.Count >= options.MaxResults)
                        break;
                }
            }
        }

        return results;
    }

    private async Task LoadBiblesAsync()
    {
        try
        {
            var bibleFiles = _fileSystem.GetFiles(_configuration.StorageConfiguration.AppDataDirectory, "*.json");
            foreach (var file in bibleFiles)
            {
                var content = await _fileSystem.ReadAllTextAsync(file).ConfigureAwait(false);
                var bible = System.Text.Json.JsonSerializer.Deserialize<Bible>(content);
                if (bible != null)
                {
                    _bibleCache[bible.Id] = bible;
                }
            }
        }
        catch (JsonException ex)
        {
            _bibleCache.Clear();
            throw new BibleLoadException("Failed to deserialize Bible JSON file.", ex);
        }
        catch (IOException ex)
         {
             _bibleCache.Clear();
             throw new BibleLoadException("Failed to read Bible files from storage.", ex);
         }
    }
}