using BibleShow.Core.Models;

namespace BibleShow.UI;

public partial class PresentationWindow : ContentPage
{
    private string _currentVerse = string.Empty;
    public string CurrentVerse
    {
        get => _currentVerse;
        set
        {
            _currentVerse = value;
            OnPropertyChanged(nameof(CurrentVerse));
        }
    }

    public PresentationWindow()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public void DisplayVerse(Verse verse)
    {
        try
        {
            if (verse == null)
                return;

            CurrentVerse = $"{verse.Reference}\n\n{verse.Text}";
        }
        catch (InvalidOperationException ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Error", $"Failed to display verse: {ex.Message}", "OK").ConfigureAwait(true);
            });
        }
        catch (ArgumentException ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Error", $"Invalid verse data: {ex.Message}", "OK").ConfigureAwait(true);
            });
        }
    }

    public void ClearDisplay()
    {
        try
        {
            CurrentVerse = string.Empty;
        }
        catch (InvalidOperationException ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Error", $"Failed to clear display: {ex.Message}", "OK").ConfigureAwait(true);
            });
        }
    }
}