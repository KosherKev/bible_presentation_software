namespace BibleShow.Core.Models;

public record Presentation
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required DateTimeOffset UpdatedAt { get; init; }
    public required PresentationTheme Theme { get; init; }
    public IReadOnlyList<PresentationItem> Items { get; init; } = new List<PresentationItem>();
}

public record PresentationTheme
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string BackgroundColor { get; init; }
    public required string TextColor { get; init; }
    public required string FontFamily { get; init; }
    public required int FontSize { get; init; }
    public required TextAlignment TextAlignment { get; init; }
    public string? BackgroundImage { get; init; }
    public double BackgroundOpacity { get; init; } = 1.0;
}

public record PresentationItem
{
    public required string Id { get; init; }
    public required string BibleId { get; init; }
    public required string BookId { get; init; }
    public required string ChapterId { get; init; }
    public required IReadOnlyList<string> VerseIds { get; init; }
    public required int Order { get; init; }
    public PresentationTheme? CustomTheme { get; init; }
}

public enum TextAlignment
{
    Left,
    Center,
    Right,
    Justify
}