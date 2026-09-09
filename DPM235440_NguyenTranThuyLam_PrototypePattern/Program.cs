using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_PrototypePattern
{
    internal class Program
    {
        public class Person
        {
            public int Age;
            public string Name;

            public Person ShallowCopy() => (Person)this.MemberwiseClone();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROTOTYPE PATTERN (LY THUYET) ===");
            Person p1 = new Person { Age = 25, Name = "John" };
            Person p2 = p1.ShallowCopy();

            Console.WriteLine($"P1: {p1.Name}, {p1.Age}");
            Console.WriteLine($"P2 (Cloned): {p2.Name}, {p2.Age}");

            Console.ReadLine();
        }
    }
}
