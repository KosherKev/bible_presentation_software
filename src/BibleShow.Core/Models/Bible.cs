namespace BibleShow.Core.Models;

public record Bible
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Language { get; init; }
    public required string Version { get; init; }
    public required string Copyright { get; init; }
    public required bool IsRightToLeft { get; init; }
    public IReadOnlyList<Book> Books { get; init; } = new List<Book>();
}

public record Book
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Abbreviation { get; init; }
    public required int Number { get; init; }
    public IReadOnlyList<Chapter> Chapters { get; init; } = new List<Chapter>();
}

public record Chapter
{
    public required string Id { get; init; }
    public required int Number { get; init; }
    public IReadOnlyList<Verse> Verses { get; init; } = new List<Verse>();
}

public record Verse
{
    public required string Id { get; init; }
    public required int Number { get; init; }
    public required string Text { get; init; }
    public string Reference { get; init; } = string.Empty;
}