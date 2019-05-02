
namespace BestPractices
{
    public class Math
    {
        public int Add(int a, int b) => a + b;
        public float Add(float a, float b) => a + b;
        public decimal Add(decimal a, decimal b) => a + b;
    }
}

namespace Implement
{
    public class Consume
    {
        BestPractices.Math math = new BestPractices.Math();
    }

}