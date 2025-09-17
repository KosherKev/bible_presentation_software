namespace BibleShow.Core.Exceptions;

public class BibleShowException : Exception
{
    public BibleShowException(string message) : base(message)
    {
    }

    public BibleShowException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class BibleNotFoundException : BibleShowException
{
    public BibleNotFoundException(string bibleId) 
        : base($"Bible with ID '{bibleId}' was not found.")
    {
        BibleId = bibleId;
    }

    public string BibleId { get; }
}

public class PresentationNotFoundException : BibleShowException
{
    public PresentationNotFoundException(string presentationId) 
        : base($"Presentation with ID '{presentationId}' was not found.")
    {
        PresentationId = presentationId;
    }

    public string PresentationId { get; }
}

public class ThemeNotFoundException : BibleShowException
{
    public ThemeNotFoundException(string themeId) 
        : base($"Theme with ID '{themeId}' was not found.")
    {
        ThemeId = themeId;
    }

    public string ThemeId { get; }
}