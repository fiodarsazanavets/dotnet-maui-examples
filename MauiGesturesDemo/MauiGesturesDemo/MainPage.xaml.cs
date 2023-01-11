using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiGesturesDemo;

public partial class MainPage : ContentPage
{
    public MainPage()
	{   
        InitializeComponent();
        refreshView.Command = RefreshCommand;
    }

    public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

    async Task RefreshItemsAsync()
    {
        refreshView.IsRefreshing = true;
        await Task.Delay(TimeSpan.FromSeconds(2));
        refreshView.IsRefreshing = false;
    }

    async void OnIncorrectAnswerInvoked(object sender, EventArgs e)
    {
        await DisplayAlert("Wrong!", "Plese try again.", "OK");
    }

    async void OnCorrectAnswerInvoked(object sender, EventArgs e)
    {
        await DisplayAlert("Correct!", "The answer is 4.", "OK");
    }

    async void OnSwipedLeft(object sender, EventArgs e)
    {
        await DisplayAlert("Swipe Action", "BoxView swiped left", "OK");
    }
}

