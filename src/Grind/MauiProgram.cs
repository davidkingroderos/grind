using Grind.View;
using Grind.ViewModel;
using Microsoft.Extensions.Logging;

namespace Grind
{
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<TrackersPage>();
            builder.Services.AddSingleton<TasksPage>();
            builder.Services.AddSingleton<AboutPage>();

            builder.Services.AddSingleton<TrackersViewModel>();

            return builder.Build();
        }
    }
}