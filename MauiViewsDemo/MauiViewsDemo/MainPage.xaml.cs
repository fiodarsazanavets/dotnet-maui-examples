namespace MauiViewsDemo;

public partial class MainPage : ContentPage
{
	private int count = 0;
	private int imageClickCount = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void OnImageButtonClicked(object sender, EventArgs e)
    {
		imageClickCount++;
        if (count == 1)
            ImageLabel.Text = $"Clicked {imageClickCount} time";
        else
            ImageLabel.Text = $"Clicked {imageClickCount} times";

        SemanticScreenReader.Announce(ImageLabel.Text);

    }
}

