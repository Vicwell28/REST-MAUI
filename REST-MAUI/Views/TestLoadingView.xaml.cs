using System.Diagnostics;

namespace REST_MAUI.Views;

public partial class TestLoadingView : ContentPage
{
	public TestLoadingView()
	{
		InitializeComponent();
	}

	public async Task LoadDataAsync()
	{
		// Mostrar página modal de carga
		var loadingPage = new LoadingView();
		await Application.Current.MainPage.Navigation.PushModalAsync(loadingPage);

		try
		{
			// Realizar la petición al servidor
			// ...

			// Simular un retardo para demostración
			//await Task.Delay(5000);

			// Cerrar página modal de carga
			//await Application.Current.MainPage.Navigation.PopModalAsync();
		}
		catch (Exception ex)
		{
			// Manejar errores si es necesario
			Debug.WriteLine(ex);

		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await this.LoadDataAsync(); 
	}
}
