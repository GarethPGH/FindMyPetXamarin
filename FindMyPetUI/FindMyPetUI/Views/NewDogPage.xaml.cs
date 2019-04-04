using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FindMyPetUI.Models;

namespace FindMyPetUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDogPage : ContentPage
    {
        public Dog Item { get; set; }

        public NewDogPage()
        {
            InitializeComponent();

            Item = new Dog
            {
                Name = "Derpina",
                Description = "A Potbellied Pig, not a Dog"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}