using CommunityToolkit.Maui;
using Grind.Controls;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
                }
            });

            builder.Services.AddSingleton<TrackersPage>();
            builder.Services.AddSingleton<TodosPage>();
            builder.Services.AddSingleton<CompletedTodosPage>();
            builder.Services.AddSingleton<ToolsPage>();
            builder.Services.AddSingleton<RoutinesPage>();
            builder.Services.AddSingleton<AboutPage>();
            builder.Services.AddSingleton<AddTrackerPage>();
            builder.Services.AddSingleton<AddTodoPage>();
            builder.Services.AddSingleton<AddRoutinePage>();

            builder.Services.AddTransient<TrackerDetailsPage>();
            builder.Services.AddTransient<TodoDetailsPage>();

            builder.Services.AddSingleton<TrackersViewModel>();
            builder.Services.AddSingleton<UnfinishedTodosViewModel>();
            builder.Services.AddSingleton<FinishedTodosViewModel>();
            builder.Services.AddSingleton<ToolsViewModel>();
            builder.Services.AddSingleton<RoutinesViewModel>();
            builder.Services.AddSingleton<AddTrackerViewModel>();
            builder.Services.AddSingleton<AddTodoViewModel>();
            builder.Services.AddSingleton<AddRoutineViewModel>();

            builder.Services.AddTransient<TrackerDetailsViewModel>();
            builder.Services.AddTransient<TodoDetailsViewModel>();

            return builder.Build();
        }
    }
}