using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AB.Utilities;

namespace AB.Utilities.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzOnce = DoActionOnceWhen.Do(() => Console.WriteLine("Fizz"));
            var buzzOnce = DoActionOnceWhen.Do(() => Console.WriteLine("Buzz"));
            var fizzbuzzOnce = DoActionOnceWhen.Do(() => Console.WriteLine("FizzBuzz"));
            var resetOnce = DoActionOnceWhen.Do(() => fizzOnce.Reset());

            for (int i = 1; i <= 30; ++i) {
                bool mod3 = i % 3 == 0;
                bool mod5 = i % 5 == 0;
                if (!fizzOnce.When(() => mod3) 
                    && !buzzOnce.When(() => mod5)
                    && !fizzbuzzOnce.When(() => mod3 && mod5)) {
                        Console.WriteLine(i);
                }

                resetOnce.When(() => i > 25);
            }

            Console.ReadKey();
        }
    }
}
