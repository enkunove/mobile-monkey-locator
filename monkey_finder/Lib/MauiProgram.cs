using Microsoft.Extensions.Logging;
using monkey_finder.Services;
using monkey_finder.ViewModel;


namespace monkey_finder;

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
        builder.Services.AddSingleton<MainPage>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
