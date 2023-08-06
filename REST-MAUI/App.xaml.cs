using REST_MAUI.Views;

namespace REST_MAUI;

public partial class App : Application
{
	public App(MainView MainView)
	{
		InitializeComponent();

		//MainPage = MainView; TestLoadingView
		MainPage = new TestLoadingView(); 
	}
}
