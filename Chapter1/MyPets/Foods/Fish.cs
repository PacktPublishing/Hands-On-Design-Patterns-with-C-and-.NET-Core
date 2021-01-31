using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyPets
{
    public class Fish : IPetFood
    {
        int IPetFood.Energy => 8;
    }
}
