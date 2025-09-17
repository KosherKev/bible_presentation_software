using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BibleShow.Core.Models;

namespace BibleShow.Core.Utils;

public static class TextProcessingUtility
{
    public static string NormalizeText(string text, bool preserveCase = false)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        text = text.Trim();

        if (string.IsNullOrEmpty(text))
            return string.Empty;

        if (preserveCase)
            return text;

        var normalizedText = text.Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray();

        return new string(normalizedText).ToUpperInvariant();
    }

    public static IReadOnlyList<TextHighlight> FindMatches(string text, string searchText, bool caseSensitive = false)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(searchText))
            return Array.Empty<TextHighlight>();

        var matches = new List<TextHighlight>();
        var index = 0;

        while ((index = text.IndexOf(searchText, index, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase)) != -1)
        {
            matches.Add(new TextHighlight
            {
                StartIndex = index,
                Length = searchText.Length,
                MatchedText = text.Substring(index, searchText.Length)
            });
            index += searchText.Length;
        }

        return matches;
    }

    public static string GetHighlightedText(string text, IReadOnlyList<TextHighlight> highlights)
    {
        if (string.IsNullOrWhiteSpace(text) || !highlights.Any())
            return text;

        var sortedHighlights = highlights.OrderBy(h => h.StartIndex).ToList();
        var result = new StringBuilder();
        var currentIndex = 0;

        foreach (var highlight in sortedHighlights)
        {
            // Add text before highlight
            if (highlight.StartIndex > currentIndex)
            {
                result.Append(text.AsSpan(currentIndex, highlight.StartIndex - currentIndex));
            }

            // Add highlighted text
            result.Append("<mark>")
                 .Append(text.AsSpan(highlight.StartIndex, highlight.Length))
                 .Append("</mark>");

            currentIndex = highlight.StartIndex + highlight.Length;
        }

        // Add remaining text after last highlight
            if (currentIndex < text.Length)
            {
                result.Append(text.AsSpan(currentIndex));
            }

        return result.ToString();
    }
}