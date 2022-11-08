using AgendaMAUI.ViewModels;
using AgendaMAUI.Views;

namespace AgendaMAUI;

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
                fonts.AddFont("fontello.ttf", "fontello");
                fonts.AddFont("Tangerine-Bold.ttf", "Tangerine-Bold");
                fonts.AddFont("Tangerine-Regular.ttf", "Tangerine-Regular");
                fonts.AddFont("Volkhov-Bold.ttf", "Volkhov-Bold");
                fonts.AddFont("Volkhov-Regular.ttf", "Volkhov-Regular");
                fonts.AddFont("Lusitana-Bold.ttf", "Lusitana-Bold");
                fonts.AddFont("Lusitana-Regular.ttf", "LusitanaRegular");
            });

        builder.Services.AddSingleton<ConferenceMAUIService>();
        builder.Services.AddSingleton<ConferenceXAMARINService>();
        builder.Services.AddTransient<MAUIDayViewModel>();
        builder.Services.AddTransient<MauiDayPage>();
        builder.Services.AddTransient<XamarinDayViewModel>();
        builder.Services.AddTransient<XamarinDayPage>();
        builder.Services.AddTransient<SpeakerViewModel>();
        builder.Services.AddTransient<SpeakerPage>();
        builder.Services.AddTransient<SpeakerDetailViewModel>();
        builder.Services.AddTransient<SpeakerDetailPage>();
        builder.Services.AddTransient<SpeakerService>();
        return builder.Build();
	}
}
