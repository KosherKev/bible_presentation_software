using System.Collections.Generic;

namespace BibleShow.Core.Models;

public record SearchResult
{
    public required string BibleId { get; init; }
    public required string BookId { get; init; }
    public required string ChapterId { get; init; }
    public required Verse Verse { get; init; }
    public required IReadOnlyList<TextHighlight> Highlights { get; init; } = new List<TextHighlight>();
}

public record TextHighlight
{
    public required int StartIndex { get; init; }
    public required int Length { get; init; }
    public required string MatchedText { get; init; }
}