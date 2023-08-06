using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using REST_MAUI.HException;
using REST_MAUI.Models;
using REST_MAUI.Repository.UserRepository;
using REST_MAUI.Services;
using REST_MAUI.Services.ApiService;
using REST_MAUI.Services.Configuration;
using REST_MAUI.ViewModels;
using REST_MAUI.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;

namespace REST_MAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.AddServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder AddServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.Build());

		mauiAppBuilder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
		mauiAppBuilder.Services.AddSingleton<IApiService, ApiService>();
		mauiAppBuilder.Services.AddSingleton<IUserRepository, UserRepository>();
		mauiAppBuilder.Services.AddSingleton<ApiEndpoint>();
		mauiAppBuilder.Services.AddSingleton<User>();
		mauiAppBuilder.Services.AddSingleton<ApiException>();
		mauiAppBuilder.Services.AddSingleton<UserRepositoryException>();
		mauiAppBuilder.Services.AddSingleton<MainView>();
		mauiAppBuilder.Services.AddSingleton<MainViewModel>();


		return mauiAppBuilder;
	}

	
}
