using Foundation;
using Microsoft.Maui.Hosting;

namespace MauiMvuExample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
}

