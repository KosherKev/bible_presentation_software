using System.Threading;

namespace BibleShow.UI.New;

public partial class MainPage : ContentPage
{
	private int _count;
	private readonly object _countLock = new();
	private readonly SemaphoreSlim _uiUpdateSemaphore = new(1, 1);

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		int currentCount;
		lock (_countLock)
		{
			_count++;
			currentCount = _count;
		}

		try
		{
			await _uiUpdateSemaphore.WaitAsync();
			
			if (MainThread.IsMainThread)
			{
				UpdateUI(currentCount);
			}
			else
			{
				await MainThread.InvokeOnMainThreadAsync(() => UpdateUI(currentCount));
			}
		}
		finally
		{
			_uiUpdateSemaphore.Release();
		}
	}

	private void UpdateUI(int count)
	{
		CounterBtn.Text = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";
		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_uiUpdateSemaphore.Dispose();
		}
		base.Dispose(disposing);
	}
}

