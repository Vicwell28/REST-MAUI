using REST_MAUI.ViewModels;

namespace REST_MAUI.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}
}