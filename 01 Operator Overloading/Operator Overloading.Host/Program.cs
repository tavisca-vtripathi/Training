using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.dbl;
using OperatorOverloading.Model;
namespace OperatorOverloading.Host
{
   public  class Program
    { 
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the amount in the form of <100 USD>");
                var amount = new Money(Console.ReadLine());
                Console.WriteLine("Enter the currency in which you want to convert");
                string toCurrency = Console.ReadLine();
                var output = amount.ConvertCurrency(toCurrency.ToUpper());
                Console.WriteLine("your Converted amount is "+output+" "+toCurrency);
                Console.ReadKey();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS..!! There occur some error");
                Console.WriteLine(e.Message);
                Console.ReadKey();

            }
        }
    }
}