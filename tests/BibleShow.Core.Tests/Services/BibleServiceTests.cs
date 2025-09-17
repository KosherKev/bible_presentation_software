using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using BibleShow.Core.Configuration;
using BibleShow.Core.Exceptions;
using BibleShow.Core.FileSystem;
using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using BibleShow.Core.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace BibleShow.Core.Tests.Services;

public class BibleServiceTests
{
    private readonly Mock<IFileSystem> _fileSystemMock;
    private readonly Mock<IBibleShowConfigurationValidator> _validatorMock;
    private readonly BibleShowConfiguration _configuration;
    private readonly BibleService _service;

    public BibleServiceTests()
    {
        _fileSystemMock = new Mock<IFileSystem>();
        _validatorMock = new Mock<IBibleShowConfigurationValidator>();
        _configuration = new BibleShowConfiguration
        {
            StorageConfiguration = new StorageConfiguration
            {
                AppDataDirectory = "/test/data"
            },
            BibleConfiguration = new BibleConfiguration()
        };

        var options = Options.Create(_configuration);
        _service = new BibleService(options, _validatorMock.Object, _fileSystemMock.Object);

        SetupTestBible();
    }

    [Fact]
    public async Task SearchAsyncShouldThrowArgumentExceptionWhenSearchTextIsEmpty()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => 
            _service.SearchAsync("test-bible", "", new SearchOptions()));
    }

    [Fact]
    public async Task SearchAsyncShouldThrowBibleNotFoundExceptionWhenBibleNotFound()
    {
        await Assert.ThrowsAsync<BibleNotFoundException>(() => 
            _service.SearchAsync("non-existent", "test", new SearchOptions()));
    }

    [Fact]
    public async Task SearchAsyncShouldReturnMatchingVerses()
    {
        var results = await _service.SearchAsync("test-bible", "love", new SearchOptions());
        
        Assert.NotEmpty(results);
        Assert.All(results, r => 
        {
            Assert.Contains("LOVE", r.Verse.Text.ToUpperInvariant(), StringComparison.Ordinal);
            Assert.NotEmpty(r.Highlights);
        });
    }

    [Fact]
    public async Task SearchAsyncShouldRespectMaxResults()
    {
        var options = new SearchOptions { MaxResults = 1 };
        var results = await _service.SearchAsync("test-bible", "the", options);
        
        Assert.Single(results);
    }

    [Fact]
    public async Task SearchAsyncShouldRespectBookFilter()
    {
        var options = new SearchOptions { BookFilter = "GEN" };
        var results = await _service.SearchAsync("test-bible", "beginning", options);
        
        Assert.All(results, r => Assert.Equal("GEN", r.BookId));
    }

    [Fact]
    public async Task SearchAsyncShouldRespectChapterFilter()
    {
        var options = new SearchOptions { BookFilter = "GEN", ChapterFilter = "1" };
        var results = await _service.SearchAsync("test-bible", "beginning", options);
        
        Assert.All(results, r => 
        {
            Assert.Equal("GEN", r.BookId);
            Assert.Equal("1", r.ChapterId);
        });
    }

    [Theory]
    [InlineData("LOVE", false, 2)] // Case-insensitive should find both "love" and "LOVE"
    [InlineData("LOVE", true, 1)]  // Case-sensitive should only find "LOVE"
    public async Task SearchAsyncShouldRespectCaseSensitivity(string searchText, bool caseSensitive, int expectedCount)
    {
        var options = new SearchOptions { CaseSensitive = caseSensitive };
        var results = await _service.SearchAsync("test-bible", searchText, options);
        
        Assert.Equal(expectedCount, results.Count());
    }

    private void SetupTestBible()
    {
        var bible = new Bible
        {
            Id = "test-bible",
            Name = "Test Bible",
            Language = "en",
            Version = "TEST",
            Copyright = "Test Copyright",
            IsRightToLeft = false,
            Books = new List<Book>
            {
                new Book
                {
                    Id = "GEN",
                    Name = "Genesis",
                    Abbreviation = "Gen",
                    Number = 1,
                    Chapters = new List<Chapter>
                    {
                        new Chapter
                        {
                            Id = "1",
                            Number = 1,
                            Verses = new List<Verse>
                            {
                                new Verse
                                {
                                    Id = "GEN.1.1",
                                    Number = 1,
                                    Text = "In the beginning God created the heaven and the earth."
                                },
                                new Verse
                                {
                                    Id = "GEN.1.2",
                                    Number = 2,
                                    Text = "For God so loved the world."
                                },
                                new Verse
                                {
                                    Id = "GEN.1.3",
                                    Number = 3,
                                    Text = "The LOVE of God is eternal."
                                }
                            }
                        }
                    }
                }
            }
        };

        var bibleJson = JsonSerializer.Serialize(bible);
        var biblePath = "/test/data/bibles/test-bible.json";

        _fileSystemMock.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(true);
        _fileSystemMock.Setup(f => f.GetFiles(It.IsAny<string>(), "*.json"))
            .Returns(new[] { biblePath });
        _fileSystemMock.Setup(f => f.ReadAllTextAsync(biblePath))
            .ReturnsAsync(bibleJson);
    }
}