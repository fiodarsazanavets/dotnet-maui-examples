namespace SecureStorageDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
        InitializeComponent();
        CounterBtn.Text = SecureStorage.Default.GetAsync("button_label").Result ?? CounterBtn.Text;

		var storedCounter = SecureStorage.Default.GetAsync("counter").Result;

		if (storedCounter != null)
			count = int.Parse(storedCounter);
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		var btnMessage = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";

        await SecureStorage.Default.SetAsync("counter", count.ToString());
        await SecureStorage.Default.SetAsync("button_label", btnMessage);

        CounterBtn.Text = await SecureStorage.Default.GetAsync("button_label");

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

