using System.ComponentModel;
using Xamarin.Forms;
using XamarineAppDemo.ViewModels;

namespace XamarineAppDemo.Views
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