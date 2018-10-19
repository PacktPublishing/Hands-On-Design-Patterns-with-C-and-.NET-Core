
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chapter1_OOP
{
    public class PetColor
    {
        public readonly string Color;

        public PetColor(string color)
        {
            Color = color;
        }
    }

    public class PetAnimal
    {
        private readonly string PetName;
        private readonly PetColor PetColor;

        public PetAnimal(string petName, PetColor petColor)
        {
            PetName = petName;
            PetColor = petColor;
        }

        public string MyPet() => $"My pet is {PetName} and its color is {PetColor.Color}.";
    }

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

        public string MyPets() => $"{OwnerName} owns {string.Concat(Pets.Select(p => p.MyPet() + Environment.NewLine))}";
    }
}
