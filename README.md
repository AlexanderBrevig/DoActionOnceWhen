DoActionOnceWhen
================

Do something only once when a predicate is met

Install with Package Manager Console
    
    PM> Install-Package DoActionOnceWhen

Example
-------

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AB.Utilities;
    
    namespace ConsoleApplication2
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

Print out:

    1
    2
    Fizz
    4
    Buzz
    6
    7
    8
    9
    10
    11
    12
    13
    14
    FizzBuzz
    16
    17
    18
    19
    20
    21
    22
    23
    24
    25
    26
    Fizz
    28
    29
    30
