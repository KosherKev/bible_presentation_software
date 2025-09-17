using System;

namespace BibleShow.Core.Exceptions;

public class BibleShowException : Exception
{
    public BibleShowException()
        : base("An error occurred in BibleShow.")
    {
    }

    public BibleShowException(string message) : base(message)
    {
    }

    public BibleShowException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class ConfigurationValidationException : BibleShowException
{
    public ConfigurationValidationException()
        : base("Configuration validation failed.")
    {
    }

    public ConfigurationValidationException(string message) : base(message)
    {
    }

    public ConfigurationValidationException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}

public class BibleNotFoundException : BibleShowException
{
    public BibleNotFoundException()
        : base("Bible was not found.")
    {
    }

    public BibleNotFoundException(string bibleId) 
        : base($"Bible with ID '{bibleId}' was not found.")
    {
        BibleId = bibleId;
    }

    public BibleNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public string? BibleId { get; }
}

public class PresentationNotFoundException : BibleShowException
{
    public PresentationNotFoundException()
        : base("Presentation was not found.")
    {
    }

    public PresentationNotFoundException(string presentationId) 
        : base($"Presentation with ID '{presentationId}' was not found.")
    {
        PresentationId = presentationId;
    }

    public PresentationNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public string? PresentationId { get; }
}

public class ThemeNotFoundException : BibleShowException
{
    public ThemeNotFoundException()
        : base("Theme was not found.")
    {
    }

    public ThemeNotFoundException(string themeId) 
        : base($"Theme with ID '{themeId}' was not found.")
    {
        ThemeId = themeId;
    }

    public ThemeNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public string? ThemeId { get; }
}