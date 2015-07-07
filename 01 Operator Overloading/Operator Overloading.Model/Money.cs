using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money                                                           
    {
        public int Amount;
        public string Currency;
        
        public Money()
        { }                                                           

        public Money(int amt, string curr)                                                                        //Takes input                                                         
        {
            if (amt < 0)
            {
                throw new ArgumentException();                                                                     ///throw exception for Integer out of range
            }
            else
            {
                this.Amount = amt;
                this.Currency = curr;
            }

        }

        public static Money operator +(Money money1, Money money2)                                                  //operator overloading function    
        { 
            Money money3 = new Money();

                if (money1.Currency == money2.Currency)
                {


                    money3.Amount = money1.Amount + money2.Amount;
                    money3.Currency = money1.Currency;
                }
                else
                {
                    throw new System.Exception();                                                                     //throw exception for currency mismatch
                }

            
            return money3;
        }
    }
}
