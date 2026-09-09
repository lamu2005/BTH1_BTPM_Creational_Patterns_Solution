using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235440_NguyenTranThuyLam_SingletonPattern
{
    internal class Program
    {
        public sealed class Singleton
        {
            private static Singleton _instance;
            private static readonly object _lock = new object();

            private Singleton() { }

            public static Singleton GetInstance()
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }

            public void SomeBusinessLogic() => Console.WriteLine("Singleton Instance is working!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== SINGLETON PATTERN (LY THUYET) ===");
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Duy nhất 1 Instance tồn tại!");
            }
            s1.SomeBusinessLogic();

            Console.ReadLine();
        }
    }
}
