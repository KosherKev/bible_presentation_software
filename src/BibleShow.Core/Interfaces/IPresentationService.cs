using BibleShow.Core.Models;

namespace BibleShow.Core.Interfaces;

public interface IPresentationService
{
    Task<IEnumerable<Presentation>> GetAllPresentationsAsync();
    Task<Presentation?> GetPresentationByIdAsync(string id);
    Task<Presentation> CreatePresentationAsync(string title, PresentationTheme theme);
    Task<Presentation> UpdatePresentationAsync(Presentation presentation);
    Task DeletePresentationAsync(string id);
    Task<PresentationItem> AddItemAsync(string presentationId, string bibleId, string bookId, string chapterId, IEnumerable<string> verseIds);
    Task<PresentationItem> UpdateItemAsync(string presentationId, PresentationItem item);
    Task RemoveItemAsync(string presentationId, string itemId);
    Task ReorderItemsAsync(string presentationId, IEnumerable<(string ItemId, int NewOrder)> newOrders);
}