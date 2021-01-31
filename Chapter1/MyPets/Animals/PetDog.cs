namespace MyPets
{
    public class PetDog : PetAnimal
    {
        public PetDog(string petName, PetColor petColor) : base(petName, petColor)
        {
            
        }

        public string Bark()
        {
            return "Woof!";
        }        

    }
}
