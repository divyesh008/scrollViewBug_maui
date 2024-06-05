using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using poc_maui.Models;

namespace poc_maui.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
        public ICommand AddCommand { private set; get; }

        public MainPageViewModel()
		{
            AddCommand = new Command(AddHandler);
        }

        private async void AddHandler()
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Add button clicked.", "Ok");
        }
    }
}

