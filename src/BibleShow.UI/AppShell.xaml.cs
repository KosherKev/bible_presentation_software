using Microsoft.Extensions.DependencyInjection;

namespace BibleShow.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		// Register route for MainPage with dependency injection
		Routing.RegisterRoute("MainPage", typeof(MainPage));
	}
}
