using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.dbl;
using OperatorOverloading.Model;
namespace OperatorOverloading.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
          try
            {
                Converter con = new Converter();
                string sourceCurrency;
                string targetCurrency;

                Console.WriteLine("Enter Source Currency");
                sourceCurrency = Console.ReadLine().ToUpper();
                if (sourceCurrency.Length != 3 || string.IsNullOrWhiteSpace(sourceCurrency))
                {
                 throw new System.Exception("Invalid Currency Name");
                }

                Console.WriteLine("Enter Target Currency");
                targetCurrency = Console.ReadLine().ToUpper();
                if (targetCurrency.Length != 3 || string.IsNullOrWhiteSpace(targetCurrency))
                {
                  throw new System.Exception("Invalid Currency Name");
                }

                double ans = con.GetConversion(sourceCurrency, targetCurrency);
                Console.WriteLine(ans);
                Console.ReadKey();
            }
           catch (Exception e)
            {
               Console.WriteLine(e.Message);
                Console.ReadKey();

            }
        }
    }
}