using System;

namespace BibleShow.Core.Exceptions;

/// <summary>
/// Exception thrown when there is an error loading Bible data from storage.
/// </summary>
public class BibleLoadException : Exception 
{
    public BibleLoadException() : base()
    {
    }
    
    public BibleLoadException(string message) : base(message)
    {
    }

    public BibleLoadException(string message, Exception innerException) : base(message, innerException)
    {
    }
}