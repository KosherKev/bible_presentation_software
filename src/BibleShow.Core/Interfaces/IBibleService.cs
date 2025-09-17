using BibleShow.Core.Models;

namespace BibleShow.Core.Interfaces;

public interface IBibleService
{
    Task<IEnumerable<Bible>> GetAllBiblesAsync();
    Task<Bible?> GetBibleByIdAsync(string id);
    Task<Book?> GetBookAsync(string bibleId, string bookId);
    Task<Chapter?> GetChapterAsync(string bibleId, string bookId, string chapterId);
    Task<IEnumerable<Verse>> GetVersesAsync(string bibleId, string bookId, string chapterId, IEnumerable<string> verseIds);
    Task<IEnumerable<Verse>> SearchAsync(string bibleId, string searchText, int maxResults = 100);
}