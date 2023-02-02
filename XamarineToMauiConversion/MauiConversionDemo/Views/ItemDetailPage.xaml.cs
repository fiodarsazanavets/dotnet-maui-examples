using System.ComponentModel;
using Microsoft.Maui;
using MauiConversionDemo.ViewModels;

namespace MauiConversionDemo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}