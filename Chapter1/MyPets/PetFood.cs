using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyPets
{
    public interface IPetFood
    {        
       int Energy { get; }
    }

    public class Kibble : IPetFood
    {
        public int Energy => 7;
    }

    public class Fish : IPetFood
    {
        int IPetFood.Energy => 8;
    }
}
