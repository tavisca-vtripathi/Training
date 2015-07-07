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
        
        static void Main(string[] args)
        {
            try                                                          // try block to check validation on input string and currency match
            {
                
                Console.WriteLine("Enter the Amount :");
                double amountOne = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Currency :");                 
                string currency = Console.ReadLine();
                Money firstMoneyObject = new Money(amountOne, currency);
                Console.WriteLine("Enter the Amount :");
                double amountTwo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Currency :");
                string currency2 = Console.ReadLine();
                Money secondMoneyObject = new Money(amountTwo, currency2);

                Money sumMoneyObject = firstMoneyObject + secondMoneyObject;                 //Operator Overloading
                Console.WriteLine("Sum is : "+sumMoneyObject.Amount+" " + sumMoneyObject.Currency);
            }
            
            
            catch (Exception ex)                                                            // Catching exception 
            {
                Console.WriteLine(ex.Message);


            }


            Console.ReadLine();





        }
    }
}
