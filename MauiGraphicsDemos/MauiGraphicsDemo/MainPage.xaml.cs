using Microsoft.Maui.Controls;

namespace MauiGraphicsDemo;

public partial class MainPage : ContentPage
{
	private int imageScale = 1;
    private int translationCoordinates = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void ChangeImageScale(object sender, EventArgs e)
	{
        imageScale = imageScale == 1 ? 2 : 1;

        await PageImage.ScaleTo(imageScale);
    }

    private async void RotateImage(object sender, EventArgs e)
    {
        await PageImage.RelRotateTo(180);
    }

    private async void TranslateImage(object sender, EventArgs e)
    {
        translationCoordinates = translationCoordinates == 0 ? -100 : 0;

        await PageImage.TranslateTo(translationCoordinates, translationCoordinates);
    }

    private async void FadeImage(object sender, EventArgs e)
    {
        PageImage.Opacity = 0;
        await PageImage.FadeTo(1, 2000);
    }

    private async void RotateAndScaleImage(object sender, EventArgs e)
    {
        imageScale = imageScale == 1 ? 2 : 1;
        PageImage.RelRotateTo(180);
        await PageImage.ScaleTo(imageScale);
    }
}

