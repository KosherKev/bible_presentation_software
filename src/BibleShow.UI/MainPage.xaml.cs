using BibleShow.Core.Interfaces;
using BibleShow.Core.Models;
using BibleShow.Core.Exceptions;
using System.Collections.ObjectModel;

namespace BibleShow.UI
{
	public partial class MainPage : ContentPage
	{
		private IBibleService? _bibleService;
		private ObservableCollection<Verse> _verses;
		private Verse? _selectedVerse;

		public ObservableCollection<Verse> Verses => _verses;
		public Verse? SelectedVerse
		{
			get => _selectedVerse;
			set
			{
				_selectedVerse = value;
				OnPropertyChanged(nameof(SelectedVerse));
				OnPropertyChanged(nameof(PreviewText));
			}
		}

		public string PreviewText => SelectedVerse != null
			? $"{SelectedVerse.Reference}\n\n{SelectedVerse.Text}"
			: "Select a verse to preview";

		public MainPage()
		{
			InitializeComponent();
			_verses = new ObservableCollection<Verse>();
			BindingContext = this;
		}

		public MainPage(IBibleService bibleService) : this()
		{
			_bibleService = bibleService;
		}

		protected override async void OnAppearing()
	{
		base.OnAppearing();
		
		// Get the bible service from DI if not already set
		if (_bibleService == null)
		{
			_bibleService = Handler?.MauiContext?.Services?.GetService<IBibleService>();
		}
		
		await LoadBibleVerses().ConfigureAwait(true);
	}

	private async Task LoadBibleVerses()
	{
		if (_bibleService == null)
		{
			// Show a message that services are not available
			_verses.Clear();
			_verses.Add(new Verse { Id = "error", Number = 0, Reference = "Error", Text = "Bible service not available. Please restart the application." });
			return;
		}
		
		try
		{
			var searchResults = await _bibleService.SearchAsync("kjv", "Genesis 1", new SearchOptions { CaseSensitive = false }).ConfigureAwait(true);
				_verses.Clear();
				foreach (var result in searchResults)
				{
					_verses.Add(result.Verse);
				}
			}
			catch (BibleShowException ex)
			{
				await DisplayAlert("Error", "Failed to load Bible verses: " + ex.Message, "OK").ConfigureAwait(true);
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", "Bible service operation failed: " + ex.Message, "OK").ConfigureAwait(true);
			}
		}

		private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(e.NewTextValue))
				return;

			try
		{
			if (_bibleService == null)
			{
				_verses.Clear();
				_verses.Add(new Verse { Id = "error", Number = 0, Reference = "Error", Text = "Bible service not available for search." });
				return;
			}
			
			var searchResults = await _bibleService.SearchAsync("kjv", e.NewTextValue, new SearchOptions { CaseSensitive = false }).ConfigureAwait(true);
				_verses.Clear();
				foreach (var result in searchResults)
				{
					_verses.Add(result.Verse);
				}
			}
			catch (BibleShowException ex)
			{
				await DisplayAlert("Error", "Search failed: " + ex.Message, "OK").ConfigureAwait(true);
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", "Search operation failed: " + ex.Message, "OK").ConfigureAwait(true);
			}
		}

		private async void OnVerseSelected(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Verse verse)
				{
					SelectedVerse = verse;
					if (_presentationPage != null)
					{
						_presentationPage.CurrentVerse = $"{verse.Reference}\n{verse.Text}";
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", $"Failed to select verse: {ex.Message}", "OK").ConfigureAwait(true);
			}
			catch (ArgumentException ex)
			{
				await DisplayAlert("Error", $"Invalid verse data: {ex.Message}", "OK").ConfigureAwait(true);
			}
		}

		private Window? _presentationWindow;
		private PresentationWindow? _presentationPage;

		private async void OnPresentClicked(object sender, EventArgs e)
		{
			if (SelectedVerse == null)
			{
				await DisplayAlert("No Verse Selected", "Please select a verse to present.", "OK").ConfigureAwait(true);
				return;
			}

			try
			{
				if (_presentationWindow == null)
				{
					_presentationPage = new PresentationWindow();
					_presentationWindow = new Window
					{
						Page = _presentationPage,
						Title = "BibleShow Presentation",
						Width = 800,
						Height = 600
					};
					_presentationWindow.Destroying += (s, e) =>
					{
						_presentationWindow = null;
						_presentationPage = null;
					};
				}

				if (Application.Current == null)
				{
					await DisplayAlert("Error", "Application context is not available.", "OK").ConfigureAwait(true);
					return;
				}

				Application.Current.OpenWindow(_presentationWindow);
				if (_presentationPage != null)
				{
					_presentationPage.CurrentVerse = $"{SelectedVerse.Reference}\n{SelectedVerse.Text}";
				}
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", $"Failed to open presentation window: {ex.Message}", "OK").ConfigureAwait(true);
				_presentationWindow = null;
				_presentationPage = null;
			}
			catch (ArgumentException ex)
			{
				await DisplayAlert("Error", $"Invalid window configuration: {ex.Message}", "OK").ConfigureAwait(true);
				_presentationWindow = null;
				_presentationPage = null;
			}
		}

		private async void OnClearClicked(object sender, EventArgs e)
		{
			try
			{
				if (_presentationPage != null)
				{
					_presentationPage.CurrentVerse = string.Empty;
				}
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", $"Failed to clear presentation: {ex.Message}", "OK").ConfigureAwait(true);
			}
		}

		private async void OnPreviousClicked(object sender, EventArgs e)
		{
			try
			{
				if (SelectedVerse == null)
					return;

				var currentIndex = _verses.IndexOf(SelectedVerse);
				if (currentIndex > 0)
				{
					SelectedVerse = _verses[currentIndex - 1];
					VersesCollection.ScrollTo(SelectedVerse);
					if (_presentationPage != null)
					{
						_presentationPage.CurrentVerse = $"{SelectedVerse.Reference}\n{SelectedVerse.Text}";
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", $"Failed to show previous verse: {ex.Message}", "OK").ConfigureAwait(true);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				await DisplayAlert("Error", $"Invalid verse index: {ex.Message}", "OK").ConfigureAwait(true);
			}
		}

		private async void OnNextClicked(object sender, EventArgs e)
		{
			try
			{
				if (SelectedVerse == null)
					return;

				var currentIndex = _verses.IndexOf(SelectedVerse);
				if (currentIndex < _verses.Count - 1)
				{
					SelectedVerse = _verses[currentIndex + 1];
					VersesCollection.ScrollTo(SelectedVerse);
					if (_presentationPage != null)
					{
						_presentationPage.CurrentVerse = $"{SelectedVerse.Reference}\n{SelectedVerse.Text}";
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", $"Failed to show next verse: {ex.Message}", "OK").ConfigureAwait(true);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				await DisplayAlert("Error", $"Invalid verse index: {ex.Message}", "OK").ConfigureAwait(true);
			}
			
		}
	}
}

