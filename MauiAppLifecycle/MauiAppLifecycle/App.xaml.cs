using System.Diagnostics;

namespace MauiAppLifecycle;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            Debug.WriteLine("Window created.");
        };

        window.Activated += (s, e) =>
        {
            Debug.WriteLine("Window activated.");
        };

        window.Deactivated += (s, e) =>
        {
            Debug.WriteLine("Window deactivated.");
        };

        window.Stopped += (s, e) =>
        {
            Debug.WriteLine("Window stopped.");
        };

        window.Resumed += (s, e) =>
        {
            Debug.WriteLine("Window resumed.");
        };

        window.Destroying += (s, e) =>
        {
            Debug.WriteLine("Window destroying.");
        };

        return window;
    }
}
