using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using Microsoft.Extensions.Options;

namespace BibleShow.Core.Services;

public class BibleService : IBibleService
{
    private readonly BibleShowConfiguration _configuration;
    private readonly IBibleShowConfigurationValidator _validator;

    public BibleService(
        IOptions<BibleShowConfiguration> configuration,
        IBibleShowConfigurationValidator validator)
    {
        _configuration = configuration.Value;
        _validator = validator;
        _validator.ValidateBibleConfiguration(_configuration);
    }

    public Task<IEnumerable<Bible>> GetAllBiblesAsync()
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }

    public Task<Bible?> GetBibleByIdAsync(string id)
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }

    public Task<Book?> GetBookAsync(string bibleId, string bookId)
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }

    public Task<Chapter?> GetChapterAsync(string bibleId, string bookId, string chapterId)
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }

    public Task<IEnumerable<Verse>> GetVersesAsync(string bibleId, string bookId, string chapterId, IEnumerable<string> verseIds)
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }

    public Task<IEnumerable<Verse>> SearchAsync(string bibleId, string searchText, int maxResults = 100)
    {
        throw new NotImplementedException("Implementation will be added in task 2.4");
    }
}