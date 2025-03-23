using Microsoft.Extensions.Logging;
using monkey_finder.Lib.Services;
using monkey_finder.ViewModel;
using monkey_finder.View;


namespace monkey_finder.Lib;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MonkeyService>();
        builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddTransient<MonkeyDetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddSingleton<MainPage>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
