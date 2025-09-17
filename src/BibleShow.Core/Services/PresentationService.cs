using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using Microsoft.Extensions.Options;

namespace BibleShow.Core.Services;

public class PresentationService : IPresentationService
{
    private readonly BibleShowConfiguration _configuration;
    private readonly IBibleShowConfigurationValidator _validator;
    private readonly IBibleService _bibleService;

    public PresentationService(
        IOptions<BibleShowConfiguration> configuration,
        IBibleShowConfigurationValidator validator,
        IBibleService bibleService)
    {
        _configuration = configuration.Value;
        _validator = validator;
        _bibleService = bibleService;
        _validator.ValidateStorageConfiguration(_configuration);
    }

    public Task<IEnumerable<Presentation>> GetAllPresentationsAsync()
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<Presentation?> GetPresentationByIdAsync(string id)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<Presentation> CreatePresentationAsync(string title, PresentationTheme theme)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<Presentation> UpdatePresentationAsync(Presentation presentation)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task DeletePresentationAsync(string id)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationItem> AddItemAsync(string presentationId, string bibleId, string bookId, string chapterId, IEnumerable<string> verseIds)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task<PresentationItem> UpdateItemAsync(string presentationId, PresentationItem item)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task RemoveItemAsync(string presentationId, string itemId)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }

    public Task ReorderItemsAsync(string presentationId, IEnumerable<(string ItemId, int NewOrder)> newOrders)
    {
        throw new NotImplementedException("Implementation will be added in task 2.3");
    }
}