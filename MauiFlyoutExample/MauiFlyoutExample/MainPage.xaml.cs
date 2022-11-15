namespace MauiFlyoutExample;

public partial class MainPage : FlyoutPage
{
	public MainPage()
	{
		InitializeComponent();
        flyoutPage.collectionView.SelectionChanged += OnItemChanged;
    }

	private void OnItemChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutItemModel;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }
    }
}

