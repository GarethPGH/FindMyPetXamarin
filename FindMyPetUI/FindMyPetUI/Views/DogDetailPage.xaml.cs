using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FindMyPetUI.Models;
using FindMyPetUI.ViewModels;

namespace FindMyPetUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogDetailPage : ContentPage
    {
        DogDetailViewModel viewModel;

        public DogDetailPage(DogDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DogDetailPage()
        {
            InitializeComponent();

            var item = new Dog
            {
                Name = "Derp",
                Description = "Small White Chuihuahua with Black Spots"
            };

            viewModel = new DogDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}