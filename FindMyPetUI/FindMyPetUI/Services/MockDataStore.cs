using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyPetUI.Models;

namespace FindMyPetUI.Services
{
    public class MockDataStore : IDataStore<Dog>
    {
        List<Dog> lostDogs;

        public MockDataStore()
        {
            lostDogs = new List<Dog>();
            var mockItems = new List<Dog>
            {
                new Dog { Id = 1, GuidId = Guid.NewGuid(), Name = "Bark", OwnerName = "Sandra", Description = "Small and Obnoxious." },
                new Dog { Id = 2, GuidId = Guid.NewGuid(), Name = "Fido", OwnerName = "Bob", Description = "Cute and Fluffy" },
                new Dog { Id = 3, GuidId = Guid.NewGuid(), Name = "Woof", OwnerName="Jeff", Description = "Small and Funny." },
                new Dog { Id = 4, GuidId = Guid.NewGuid(), Name = "Digger", OwnerName = "Desi", Description = "Licks his butt all the time" },
                new Dog { Id = 5, GuidId = Guid.NewGuid(), Name = "Max", OwnerName = "Brat", Description = "Eats shoes" },
                new Dog { Id = 6, GuidId = Guid.NewGuid(), Name = "Derp", OwnerName = "Scott", Description = "Big and Obnoxious." },
            };

            foreach (var doggo in mockItems)
            {
                lostDogs.Add(doggo);
            }
        }

        public async Task<bool> AddItemAsync(Dog doggo)
        {
            lostDogs.Add(doggo);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Dog doggo)
        {
            var no_Doggo = lostDogs.Where((Dog arg) => arg.Id == doggo.Id).FirstOrDefault();
            lostDogs.Remove(no_Doggo);
            lostDogs.Add(doggo);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var no_doggo = lostDogs.Where((Dog arg) => arg.Id.ToString() == id).FirstOrDefault();
            lostDogs.Remove(no_doggo);

            return await Task.FromResult(true);
        }

        public async Task<Dog> GetItemAsync(string id)
        {
            return await Task.FromResult(lostDogs.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<Dog>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(lostDogs);
        }
    }
}