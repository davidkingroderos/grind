using Microsoft.UI.Windowing;
using Microsoft.UI;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Grind.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }


//        public void SetWinNoResizable()
//        {
//            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),
//                                                                        (handler, view) =>
//                                                                        {
//#if WINDOWS
//                                                                            var nativeWindow = handler.PlatformView;
//                                                                            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
//                                                                            WindowId WindowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
//                                                                            AppWindow appWindow = AppWindow.GetFromWindowId(WindowId);
//                                                                            var presenter = appWindow.Presenter as OverlappedPresenter;
//                                                                            presenter.IsResizable = false;
//#endif
//                                                                        });
//        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}