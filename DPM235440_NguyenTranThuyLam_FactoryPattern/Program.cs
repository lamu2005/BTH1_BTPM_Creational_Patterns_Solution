using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_FactoryPattern
{
    public interface IProduct
    {
        string Operation();
    }

    public class ConcreteProduct1 : IProduct
    {
        public string Operation() => "{Result of ConcreteProduct1}";
    }

    public class ConcreteProduct2 : IProduct
    {
        public string Operation() => "{Result of ConcreteProduct2}";
    }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            return "Creator: " + product.Operation();
        }
    }

    public class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProduct1();
    }

    public class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProduct2();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== FACTORY METHOD PATTERN (LY THUYET) ===");

            Creator creator1 = new ConcreteCreator1();
            Console.WriteLine(creator1.SomeOperation());

            Creator creator2 = new ConcreteCreator2();
            Console.WriteLine(creator2.SomeOperation());

            Console.ReadLine();
        }
    }
}
