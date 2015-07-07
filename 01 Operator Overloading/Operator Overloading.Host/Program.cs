using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    public class Program                                                                              //Main Program
    {
        static void Main(string[] args)
        {
            try                                                                                     // try block to check validation on input string and currency match
            {
                Console.WriteLine("Enter the amount");
                int amount = Convert.ToInt32(Console.ReadLine());                                  
                string currency = Console.ReadLine();
                Money firstMoneyObject = new Money(amount, currency);
                Console.WriteLine("Enter the amount :");
                int amount1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Currency");
                string currency2 = Console.ReadLine();
                Money secondMoneyObject = new Money(amount1, currency2);

                Money sumMoneyObject = firstMoneyObject + secondMoneyObject;                        //Operator Overloading
                Console.WriteLine("Sum is : "+sumMoneyObject.Amount+" " + sumMoneyObject.Currency);
            }
            
            catch (ArgumentException e)                                                         // Catching exception for integer value
            {
                Console.WriteLine("Amount entered is less than zero");
            
            }
            catch (Exception ex)                                                              // Catching exception for currency mismatch
            {
                Console.WriteLine("OOPS !! There is some error");


            }


            Console.ReadLine();





        }
    }
}
