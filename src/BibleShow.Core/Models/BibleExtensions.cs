using System.Collections.Generic;
using System.Linq;

namespace BibleShow.Core.Models;

public static class BibleExtensions
{
    public static IEnumerable<Verse> GetAllVerses(this Bible bible)
    {
        ArgumentNullException.ThrowIfNull(bible);

        return bible.Books
            .SelectMany(b => b.Chapters)
            .SelectMany(c => c.Verses);
    }
}