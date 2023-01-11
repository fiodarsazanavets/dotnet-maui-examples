namespace MessageSubscriptionDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		MessagingCenter.Subscribe<MainPage>(this, "increment", (sender) =>
		{
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
        });

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		MessagingCenter.Send<MainPage>(this, "increment");
	}
}

