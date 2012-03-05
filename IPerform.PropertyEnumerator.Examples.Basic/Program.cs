using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPerform.PropertyEnumerator;

namespace IPerform.PropertyEnumerator.Examples.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeDTO dto = new SomeDTO();
            int countFalse = 0;

            PropertyIterator.ForEach<bool>(dto, "^Arrange", (p, v, o) =>
            {
                Console.WriteLine(string.Format("{0}: {1}", p.Name, v));

                if (v == false)
                {
                    countFalse++;
                }
            });

            Console.WriteLine("Non authorized count: " + countFalse);

            Console.ReadKey();
        }
    }
}
