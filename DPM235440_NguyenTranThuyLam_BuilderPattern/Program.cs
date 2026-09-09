using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_BuilderPattern
{
    internal class Program
    {
        public class Product
        {
            private List<object> _parts = new List<object>();
            public void Add(string part) => _parts.Add(part);
            public void ListParts() => Console.WriteLine("Product parts: " + string.Join(", ", _parts));
        }

        public interface IBuilder
        {
            void BuildPartA();
            void BuildPartB();
        }

        public class ConcreteBuilder : IBuilder
        {
            private Product _product = new Product();
            public ConcreteBuilder() { Reset(); }
            public void Reset() { _product = new Product(); }
            public void BuildPartA() => _product.Add("PartA1");
            public void BuildPartB() => _product.Add("PartB1");
            public Product GetProduct() { Product result = _product; Reset(); return result; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== BUILDER PATTERN (LY THUYET) ===");
            var builder = new ConcreteBuilder();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.GetProduct().ListParts();

            Console.ReadLine();
        }
    }
}
