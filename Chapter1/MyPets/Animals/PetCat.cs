namespace MyPets
{
    public class PetCat : PetAnimal
    {
        public PetCat(string petName, PetColor petColor) : base(petName, petColor)
        {

        }

        public string Meow()
        {
            return "Meow!";
        }

        public override void Feed(IPetFood food)
        {
            if (food is Fish)
            {
                Eat(food);
            }
            else
            {
                Meow();
            }
        }
    }
}
