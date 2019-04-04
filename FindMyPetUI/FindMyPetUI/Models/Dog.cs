using System;
using System.IO;

namespace FindMyPetUI.Models
{
    public class Dog
    {
        public int Id {get; set;}
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
    }
}