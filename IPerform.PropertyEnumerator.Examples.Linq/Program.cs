using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPerform.PropertyEnumerator.Examples.Basic;
using IPerform.PropertyEnumerator;

namespace IPerform.PropertyEnumerator.Examples.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeDTO dto = new SomeDTO();

            var countFalse = (from pvo in new PropertyEnumerator<bool>(dto, "^Arrange")
                              where pvo.Value == false
                              select pvo);

            countFalse.Any(x =>
            {
                Console.WriteLine(string.Format("{0}: {1}", x.PropertyInfo.Name, x.Value));

                return false;
            });

            Console.WriteLine("Non authorized count: " + countFalse.Count());

            Console.ReadKey();
        }
    }
}
