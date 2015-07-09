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

            try                                                         // try block to check validation on input string and currency match
            {

                Console.WriteLine("Enter the Amount :");
                double amountOne;
                if (double.TryParse(Console.ReadLine(), out amountOne) == false)    //Checking validity of amount input
                {
                    throw new System.Exception(Resource.InvalidAmountInput);
                }
                Console.WriteLine("Enter Currency :");
                string currency = Console.ReadLine();
                Money firstMoneyObject = new Money(amountOne, currency);               //Constructor called for assigning values
                Console.WriteLine("Enter the Amount :");
                double amountTwo;
                if (double.TryParse(Console.ReadLine(), out amountTwo) == false)
                {
                    throw new System.Exception(Resource.InvalidAmountInput);
                }
                Console.WriteLine("Enter Currency :");
                string currencyTwo = Console.ReadLine();
                Money secondMoneyObject = new Money(amountTwo, currencyTwo);
                Money sumMoneyObject = firstMoneyObject + secondMoneyObject;                              //Operator Overloading
                Console.WriteLine("Sum is : " + sumMoneyObject.Amount + " " + sumMoneyObject.Currency);
            }
            catch (Exception ex)                                                                         // Catching exception 
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
