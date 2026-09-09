using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_AbstractFactoryPattern
{
    internal class Program
    {
        public interface IAbstractProductA { string UsefulFunctionA(); }
        public interface IAbstractProductB { string UsefulFunctionB(); }

        public class ConcreteProductA1 : IAbstractProductA { public string UsefulFunctionA() => "Product A1"; }
        public class ConcreteProductA2 : IAbstractProductA { public string UsefulFunctionA() => "Product A2"; }

        public class ConcreteProductB1 : IAbstractProductB { public string UsefulFunctionB() => "Product B1"; }
        public class ConcreteProductB2 : IAbstractProductB { public string UsefulFunctionB() => "Product B2"; }

        public interface IAbstractFactory
        {
            IAbstractProductA CreateProductA();
            IAbstractProductB CreateProductB();
        }

        public class ConcreteFactory1 : IAbstractFactory
        {
            public IAbstractProductA CreateProductA() => new ConcreteProductA1();
            public IAbstractProductB CreateProductB() => new ConcreteProductB1();
        }

        public class ConcreteFactory2 : IAbstractFactory
        {
            public IAbstractProductA CreateProductA() => new ConcreteProductA2();
            public IAbstractProductB CreateProductB() => new ConcreteProductB2();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== ABSTRACT FACTORY PATTERN (LY THUYET) ===");

            IAbstractFactory factory1 = new ConcreteFactory1();
            Console.WriteLine(factory1.CreateProductA().UsefulFunctionA());
            Console.WriteLine(factory1.CreateProductB().UsefulFunctionB());

            Console.ReadLine();
        }
    }
}
