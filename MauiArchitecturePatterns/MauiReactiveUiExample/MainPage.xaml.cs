using CommunityToolkit.Maui.Markup;
using MauiReactiveUiExample.Models;
using MauiReactiveUiExample.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace MauiReactiveUiExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AppViewModel viewModel)
        {
            InitializeComponent();
            Shell.SetTitleView(this, new SearchBar
            {
                Placeholder = "Search Animals"
            }.Bind(SearchBar.TextProperty, nameof(viewModel.Query)));

            var collection = new CollectionView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var swipeView = new SwipeView();
                    var deleteSwipeItem = new SwipeItem()
                    {
                        Text = "Delete",
                        BackgroundColor = Colors.Red,
                    };
                    deleteSwipeItem.Bind(MenuItem.CommandProperty, nameof(viewModel.DeleteAnimalCommand), source: viewModel);
                    deleteSwipeItem.Bind(MenuItem.CommandParameterProperty, ".");

                    var layout = new Grid
                    {
                        Padding = 10,
                        BackgroundColor = Colors.AliceBlue,
                        Children =
                        {
                            new Label
                            {
                                FontSize = 15,
                                TextColor = Colors.Black
                            }.Bind(Label.TextProperty, nameof(Animal.Name)),
                        }

                    }.Margins(0, 0, 0, 5);

                    swipeView.RightItems.Add(deleteSwipeItem);
                    swipeView.Content = layout;

                    return swipeView;
                }),

                SelectionMode = SelectionMode.None,
                ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem,
                ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
                {
                    ItemSpacing = 5,
                }
            };
            collection.Bind(ItemsView.ItemsSourceProperty, nameof(viewModel.AnimalNames));
            collection.EmptyView = new Label
            {
                Text = "No animals in available."
            };

            Content = new VerticalStackLayout
            {

                Children =
                {
                    collection,
                    new Border
                    {
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Colors.Black),
                        BackgroundColor = Colors.Transparent,
                        Padding = new Thickness(8, 4),
                        HorizontalOptions = LayoutOptions.Fill,
                        StrokeShape = new RoundRectangle { CornerRadius=new CornerRadius(10)},
                        Content = new Entry
                        {
                            Placeholder = "New Animal",
                        }.Bind(Entry.TextProperty, nameof(viewModel.NewAnimal))
                    }.Margins(0, 20, 0, 0),
                    new Button
                    {
                        Text = "Add New Animal",
                        WidthRequest = 100,
                        HorizontalOptions = LayoutOptions.Center
                    }.BindCommand(nameof(viewModel.AddAnimalCommand))
                }
            }.Margins(15, 10, 15, 15);

            BindingContext = viewModel;
        }
    }
}