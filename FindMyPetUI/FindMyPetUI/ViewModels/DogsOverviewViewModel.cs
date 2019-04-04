using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FindMyPetUI.Services;
using FindMyPetUI.Models;
using FindMyPetUI.Views;

namespace FindMyPetUI.ViewModels
{
    public class DogsOverviewViewModel : BaseViewModel
    {
        public ObservableCollection<Dog> Dogs { get; set; }
        public Command LoadDogsCommand { get; set; }

        public DogsOverviewViewModel()
        {
            Title = "Lost Dogs";
            Dogs = new ObservableCollection<Dog>();
            LoadDogsCommand = new Command(async () => await ExecuteLoadDogsCommand());

            MessagingCenter.Subscribe<NewDogPage, Dog>(this, "Add New Record", async (obj, dog) =>
            {
                var newDog = dog as Dog;
                Dogs.Add(newDog);
                await DataStore.AddItemAsync(newDog);
            });
        }

        async Task ExecuteLoadDogsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dogs.Clear();
                var dogs = await DataStore.GetItemsAsync(true);
                foreach (var dog in dogs)
                {
                    Dogs.Add(dog);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}