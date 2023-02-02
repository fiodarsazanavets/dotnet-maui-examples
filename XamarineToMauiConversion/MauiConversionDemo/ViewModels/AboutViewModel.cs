using System;
using System.Windows.Input;
using Microsoft.Maui;

namespace MauiConversionDemo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() => { });
        }

        public ICommand OpenWebCommand { get; }
    }
}