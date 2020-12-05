using System;
using System.Threading;

namespace GarbageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------Hello Garbage Collector Tests!");
            Test();
            Console.WriteLine("---------press [Enter] to exit!");
            Console.ReadLine();
        }

        static void Test()
        {
            
            var smiec1 = new Smiec();
            using (var smiec = new Smiec())
            {
                Console.WriteLine($" smiec {smiec.GetHashCode()} generacja {GC.GetGeneration(smiec)}");

                Thread.Sleep(2000);

                Console.WriteLine($" smiec {smiec.GetHashCode()} generacja {GC.GetGeneration(smiec)}");
            }
            Console.WriteLine($" smiec1 {smiec1.GetHashCode()} generacja {GC.GetGeneration(smiec1)}");


            smiec1.Dispose();
            smiec1 = null;

            Thread.Sleep(2000);

            Console.ReadLine();

            GC.Collect(0, GCCollectionMode.Forced);
            GC.Collect();
        }
    }
}
