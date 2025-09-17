using System.Linq;
using BibleShow.Core.Models;
using BibleShow.Core.Utils;
using Xunit;

namespace BibleShow.Core.Tests.Utils;

public class TextProcessingUtilityTests
{
    [Theory]
[InlineData("", "")]
[InlineData(" ", "")]
[InlineData("Hello World", "HELLO WORLD")]
[InlineData("HELLO WORLD", "HELLO WORLD")]
[InlineData("HeLLo WoRLD", "HELLO WORLD")]
public void NormalizeTextShouldNormalizeTextCorrectly(string input, string expected)
{
    var result = TextProcessingUtility.NormalizeText(input);
    Assert.Equal(expected, result);
}

    [Fact]
    public void NormalizeTextShouldHandleNullInput()
    {
        string input = null!;
        var result = TextProcessingUtility.NormalizeText(input);
        Assert.Equal("", result);
    }

    [Theory]
    [InlineData("Hello World", "HELLO WORLD", false)]
        [InlineData("Hello World", "Hello World", true)]
    [InlineData("héllo wörld", "HELLO WORLD", false)]
        [InlineData("héllo wörld", "héllo wörld", true)]
        public void NormalizeTextShouldRespectCasePreservation(string input, string expected, bool preserveCase)
        {
            var result = TextProcessingUtility.NormalizeText(input, preserveCase);
            Assert.Equal(expected, result);
        }

    [Fact]
    public void FindMatchesShouldReturnEmptyListWhenInputIsEmpty()
    {
        var result = TextProcessingUtility.FindMatches("", "test");
        Assert.Empty(result);
    }

    [Fact]
    public void FindMatchesShouldReturnEmptyListWhenSearchTextIsEmpty()
    {
        var result = TextProcessingUtility.FindMatches("test", "");
        Assert.Empty(result);
    }

    private static readonly int[] SingleStartIndex = new[] { 0 };
    private static readonly int[] SingleLength = new[] { 5 };
    private static readonly int[] SecondStartIndex = new[] { 6 };
    private static readonly int[] SecondLength = new[] { 5 };
    private static readonly int[] BothStartIndices = new[] { 0, 6 };
    private static readonly int[] BothLengths = new[] { 5, 5 };
    private static readonly int[] WorldStartIndices = new[] { 6 };
    private static readonly int[] WorldLengths = new[] { 5 };
    private static readonly int[] MultipleWorldStartIndices = new[] { 6, 12 };
    private static readonly int[] MultipleWorldLengths = new[] { 5, 5 };

    public static TheoryData<string, string, int[], int[]> FindMatchesTestData => new()
    {
        { "Hello World", "world", WorldStartIndices, WorldLengths },
        { "Hello World World", "world", MultipleWorldStartIndices, MultipleWorldLengths }
    };

    [Theory]
    [MemberData(nameof(FindMatchesTestData))]
    public void FindMatchesShouldFindAllMatches(string input, string searchText, int[] expectedStarts, int[] expectedLengths)
    {
        ArgumentNullException.ThrowIfNull(expectedStarts);
        ArgumentNullException.ThrowIfNull(expectedLengths);

        var result = TextProcessingUtility.FindMatches(input, searchText);
        
        Assert.Equal(expectedStarts.Length, result.Count);
        for (var i = 0; i < expectedStarts.Length; i++)
        {
            Assert.Equal(expectedStarts[i], result[i].StartIndex);
            Assert.Equal(expectedLengths[i], result[i].Length);
        }
    }

    [Theory]
    [InlineData("Hello World", "WORLD", false, 1)]
    [InlineData("Hello World", "WORLD", true, 0)]
    [InlineData("Hello WORLD", "world", false, 1)]
    [InlineData("Hello WORLD", "world", true, 0)]
    public void FindMatchesShouldRespectCaseSensitivity(string input, string searchText, bool caseSensitive, int expectedMatchCount)
    {
        var result = TextProcessingUtility.FindMatches(input, searchText, caseSensitive);
        Assert.Equal(expectedMatchCount, result.Count);
    }

    [Theory]
    [MemberData(nameof(HighlightTestData))]
    public void GetHighlightedTextShouldHighlightCorrectly(string input, int[] starts, int[] lengths, string expected)
    {
        var highlights = starts.Select((start, i) => new TextHighlight
        {
            StartIndex = start,
            Length = lengths[i],
            MatchedText = input.Substring(start, lengths[i])
        }).ToList();

        var result = TextProcessingUtility.GetHighlightedText(input, highlights);
        Assert.Equal(expected, result);
    }

    public static TheoryData<string, int[], int[], string> HighlightTestData => new()
    {
        {
            "Hello World",
            BothStartIndices,
            BothLengths,
            "<mark>Hello</mark> <mark>World</mark>"
        },
        {
            "Hello World",
            SecondStartIndex,
            SecondLength,
            "Hello <mark>World</mark>"
        },
        {
            "Hello World",
            SingleStartIndex,
            SingleLength,
            "<mark>Hello</mark> World"
        }
    };

    [Fact]
    public void GetHighlightedTextShouldReturnOriginalTextWhenNoHighlights()
    {
        var input = "Hello World";
        var result = TextProcessingUtility.GetHighlightedText(input, new List<TextHighlight>());
        Assert.Equal(input, result);
    }
}