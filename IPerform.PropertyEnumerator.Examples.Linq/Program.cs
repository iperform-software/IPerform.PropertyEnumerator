using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPerform.PropertyEnumerator.Examples.Basic;
using IPerform.PropertyEnumerator;
using System.ComponentModel.DataAnnotations;

namespace IPerform.PropertyEnumerator.Examples.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeDTO dto = new SomeDTO();

            var propEnum = dto.GivePropertyEnumerator<bool>("^Arrange");

            propEnum.GetClassAttributes<TableHeaderAttribute>().Any(a =>
            {
                Console.WriteLine("entity has header: " + a.HeaderText);

                return true;
            });


            var countFalse = (from pvo in propEnum
                              where pvo.Value == false
                              select pvo);

            countFalse.Any(x =>
            {
                if (x.GetAttribute<DisplayAttribute>().Any(a =>
                {
                    Console.WriteLine("Attribute text " + a.Name);

                    return true;
                }))
                {
                    Console.WriteLine("Found attribute");
                }
                else
                {
                    Console.WriteLine("Didn't find attribute");
                }

                Console.WriteLine(string.Format("{0}: {1}", x.PropertyInfo.Name, x.Value));

                return false;
            });

            Console.WriteLine("Non authorized count: " + countFalse.Count());

            Console.ReadKey();
        }
    }
}
