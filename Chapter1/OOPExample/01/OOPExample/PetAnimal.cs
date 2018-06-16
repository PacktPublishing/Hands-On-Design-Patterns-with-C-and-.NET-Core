namespace OOPExample
{
    public class PetAnimal
    {
        private readonly string PetName;
        private readonly PetColor PetColor;

        public PetAnimal(string petName, PetColor petColor)
        {
            PetName = petName;
            PetColor = petColor;
        }

        public string MyPet() => $"My pet is {PetName} and its color is {PetColor}.";
    }
}