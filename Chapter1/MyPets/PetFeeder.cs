using System;
using System.Collections.Generic;
using System.Text;

namespace MyPets
{
    public static class PetFeeder
    {
        public static void FeedPet<TP, TF>(TP pet, TF food) where TP : PetAnimal
                                                        where TF : IPetFood            
        {
            pet.Feed(food);         
        }
    }
}
