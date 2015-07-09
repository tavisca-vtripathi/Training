using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    public class Program                                                     //Main Program
    {


        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter First Amount and  Currency: ");

                var amount1 = new Money(Console.ReadLine());

                Console.Write("Enter Second Amount and  Currency: ");
                var amount2 = new Money(Console.ReadLine());
                var amount3 = amount1 + amount2;
                Console.Write("The Total Amount is: " + amount3);

            }

            catch (Exception e)
            {
                Console.WriteLine("OOPS!! There is some error..!");
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
