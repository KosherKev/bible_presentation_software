using System;

namespace BibleShow.Core.Exceptions;

/// <summary>
/// Exception thrown when a platform-specific error occurs.
/// </summary>
public class PlatformException : BibleShowException
{
    /// <summary>
    /// Gets the platform where the exception occurred.
    /// </summary>
    public string Platform { get; }

    public PlatformException() 
        : base("A platform-specific error occurred.")
    {
        Platform = "Unknown";
    }
    
    public PlatformException(string message)
        : base(message)
    {
        Platform = "Unknown";
    }

    public PlatformException(string message, Exception innerException)
        : base(message, innerException)
    {
        Platform = "Unknown";
    }
    
    public PlatformException(string message, string platform) 
        : base(message)
    {
        Platform = platform ?? "Unknown";
    }

    public PlatformException(string message, string platform, Exception innerException) 
        : base(message, innerException)
    {
        Platform = platform ?? "Unknown";
    }
}