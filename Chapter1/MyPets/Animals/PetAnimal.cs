
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MyPets
{
    public class PetAnimal
    {
        private readonly string PetName;
        private readonly PetColor PetColor;

        private int _hunger;

        protected PetAnimal(string petName, PetColor petColor)
        {
            PetName = petName;
            PetColor = petColor;
        }

        public virtual void Feed(IPetFood food)
        {
            Eat(food);
        }

        protected void Eat(IPetFood food)
        {
            _hunger -= food.Energy;
        }

        public string MyPet() => $"My pet is {PetName} and its color is {PetColor.Color}.";
    }
}
