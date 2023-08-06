using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using REST_MAUI.Models;
using REST_MAUI.Services.Configuration;
using REST_MAUI.ViewModels;

namespace REST_MAUI.Views;

public partial class MainView : ContentPage
{
	private readonly MainViewModel _mainViewModel;
	public MainView(MainViewModel MainViewModel)
	{
		InitializeComponent();
		this._mainViewModel = MainViewModel;
		this._mainViewModel.GetAllUsersCommand.Execute(this);
		this.BindingContext = this._mainViewModel;
	}
}
