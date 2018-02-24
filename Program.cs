using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = "./Resources/small.in";
            var pizzas = Builder.build(path);
            
            foreach (var pizza in pizzas)
            {

                Console.WriteLine(DateTime.Now);
                var chrone = new Stopwatch();
                chrone.Start();

                var slices = pizza.cut();
                
                Console.WriteLine(slices.Length);
                
                /*
                foreach (Slice slice in slices)
                {
                    Console.WriteLine(slice.r1 + " " + slice.c1 + " " + slice.r2 + " " + slice.c2);
                }*/

                /*
                if (pizza.finalSolution != null)
                {
                    foreach (Slice slice in pizza.finalSolution)
                    {
                        Console.WriteLine(slice.r1 + " " + slice.c1 + " " + slice.r2 + " " + slice.c2);
                    }
                }
                else
                {
                    Console.WriteLine("No posible solution have been founded.");
                }*/

                chrone.Stop();
                Console.WriteLine("Elapse ML:" + chrone.ElapsedMilliseconds);
                Console.WriteLine(DateTime.Now);
            }



        }

    }

}
