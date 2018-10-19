using System;

namespace MyPets
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new PetOwner("Diego Jones");
            owner.AddPet(new PetDog("Ruffy", new PetColor("Brown with white spots and pink nose.")));
            owner.AddPet(new PetCat("Precious", new PetColor("Calico with a large white patch on the right side of her face.")));

            Console.Write(owner.MyPets());

            Console.Read();
        }
    }
}
