using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPets
{
    public class PetOwner
    {
        private readonly string OwnerName;
        private readonly List<PetAnimal> Pets;

        public PetOwner(string name)
        {
            OwnerName = name;
            Pets = new List<PetAnimal>();
        }

        public void AddPet(PetAnimal pet)
        {
            Pets.Add(pet);
        }

        public void Feed(PetDog dog)
        {
            PetFeeder.FeedPet(dog, new Kibble());
        }

        public void Feed(PetCat cat)
        {
            PetFeeder.FeedPet(cat, new Fish());
        }

        public string MyPets()
        {
            var pets = string.Concat(Pets.Select(p => $"{p.MyPet()} {Environment.NewLine}"));

            var ret = $"{OwnerName}: {Environment.NewLine} {pets}";
            
            return ret;
        }
    }
}
