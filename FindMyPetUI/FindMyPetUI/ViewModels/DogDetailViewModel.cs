using System;

using FindMyPetUI.Models;

namespace FindMyPetUI.ViewModels
{
    public class DogDetailViewModel : BaseViewModel
    {
        public Dog NewDog { get; set; }
        public DogDetailViewModel(Dog dog = null)
        {
            NewDog = dog; 

            Title = "Lost Dog";

            Name = dog?.Name;

            OwnerName = dog?.OwnerName;

            Description = dog?.Description;
        }

    }
}
