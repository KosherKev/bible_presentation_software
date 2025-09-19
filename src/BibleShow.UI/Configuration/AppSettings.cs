namespace BibleShow.UI.Configuration;

public class AppSettings
{
    public string DefaultBibleId { get; set; } = "kjv";
    public bool CaseSensitiveSearch { get; set; }
    public int MaxSearchResults { get; set; } = 100;
}