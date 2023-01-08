using Microsoft.Maui.LifecycleEvents;

namespace MauiAppLifecycle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
                events.AddWindows(windows => windows
                       .OnActivated((window, args) => LogEvent(nameof(WindowsLifecycle.OnActivated)))
                       .OnClosed((window, args) => LogEvent(nameof(WindowsLifecycle.OnClosed)))
                       .OnLaunched((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunched)))
                       .OnLaunching((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunching)))
                       .OnVisibilityChanged((window, args) => LogEvent(nameof(WindowsLifecycle.OnVisibilityChanged))));
#elif ANDROID
                events.AddAndroid(android => android
                    .OnActivityResult((activity, requestCode, resultCode, data) => LogEvent(nameof(AndroidLifecycle.OnActivityResult)))
                    .OnStart((activity) => LogEvent(nameof(AndroidLifecycle.OnStart)))
                    .OnCreate((activity, bundle) => LogEvent(nameof(AndroidLifecycle.OnCreate)))
                    .OnBackPressed((activity) => LogEvent(nameof(AndroidLifecycle.OnBackPressed)) && false)
                    .OnStop((activity) => LogEvent(nameof(AndroidLifecycle.OnStop))));
#elif IOS
                events.AddiOS(ios => ios
                    .OnActivated((app) => LogEvent(nameof(iOSLifecycle.OnActivated)))
                    .OnResignActivation((app) => LogEvent(nameof(iOSLifecycle.OnResignActivation)))
                    .DidEnterBackground((app) => LogEvent(nameof(iOSLifecycle.DidEnterBackground)))
                    .WillTerminate((app) => LogEvent(nameof(iOSLifecycle.WillTerminate))));
#endif

                static bool LogEvent(string eventName)
                {
                    System.Diagnostics.Debug.WriteLine(eventName);
                    return true;
                }
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
