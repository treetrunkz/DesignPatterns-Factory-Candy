namespace Factory
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface ICandyFactory
    {
        void Eat(int candyCount);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class SourSkittles : ICandyFactory
    {
        public void Eat(int candyCount)
        {
            Console.WriteLine("Eat the candy! : " + candyCount.ToString() + " Sour Gummy Skittles eaten.");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class HardCandy : ICandyFactory
    {
        public void Eat(int candyCount)
        {
            Console.WriteLine("Eat the candy! : " + candyCount.ToString() + " Hard Candies eaten.");
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class CandyFactory
    {
        public abstract ICandyFactory GetCandy(string Candy);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCandyFactory : CandyFactory
    {
        public override ICandyFactory GetCandy(string Candy)
        {
            switch (Candy)
            {
                case "SourSkittles":
                    return new SourSkittles();
                case "HardCandy":
                    return new HardCandy();
                default:
                    throw new ApplicationException(string.Format("Candy '{0}' cannot be created", Candy));
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CandyFactory factory = new ConcreteCandyFactory();

            ICandyFactory SourSkittles = factory.GetCandy("SourSkittles");
            SourSkittles.Eat(10);

            ICandyFactory HardCandy = factory.GetCandy("HardCandy");
            HardCandy.Eat(200);

            Console.ReadKey();

        }
    }
}