using System;
using System.Collections.Generic;

namespace LiskovPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<IAnimal> { new Cat(), new Dog() };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.MakeNoise());
            }

            Console.Read();
        }
    }

    interface IAnimal
    {
        string MakeNoise();
    }
    class Dog : IAnimal
    {
        public string MakeNoise()
        {
            return "Woof";
        }
    }
    class Cat : IAnimal
    {
        public string MakeNoise()
        {
            return "Meouw";
        }
    }
}
