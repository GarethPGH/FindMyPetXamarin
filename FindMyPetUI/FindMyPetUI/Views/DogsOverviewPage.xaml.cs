using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FindMyPetUI.Models;
using FindMyPetUI.Views;
using FindMyPetUI.ViewModels;

namespace FindMyPetUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogsOverviewPage : ContentPage
    {
        DogsOverviewViewModel viewModel;

        public DogsOverviewPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DogsOverviewViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var dog = args.SelectedItem as Dog;
            if (dog == null)
                return;

            await Navigation.PushAsync(new DogDetailPage(new DogDetailViewModel(dog)));

            // Manually deselect dog.
            DogsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewDogPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Dogs.Count == 0)
                viewModel.LoadDogsCommand.Execute(null);
        }
    }
}