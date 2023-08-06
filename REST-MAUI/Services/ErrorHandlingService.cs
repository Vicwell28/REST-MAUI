using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Services
{
	public static class ErrorHandlingService
	{
		public static async Task HandleErrorAsync(Exception ex)
		{
			await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
		}
	}
}
