using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money                                                           
    {
        public double Amount{get; set;}
        public string Currency { get; set; }
       
        public Money(double amount, string currency)
        {
            if (amount < 0.0 || amount >double.MaxValue)
            {
                throw new System.Exception("Check Amount Input..!!!! ");
            }
            else
            {

                Amount = amount;
                Currency = currency;

            }


        }
             
    
          

        

        public static Money operator +(Money money1, Money money2)                                 //operator overloading function    
        { 
               Money money3 = new Money(0.0,"");
                if ( money1.Currency.ToUpper()==money2.Currency.ToUpper())
                {
                       
                        money3.Amount = money1.Amount + money2.Amount;
                        if(money3.Amount>double.MaxValue)
                        {
                            throw new System.Exception("Sum is beyond storage capacity");
                        }
                        else
                        {
                        money3.Currency = money1.Currency;
                        return money3;}
                    
                   
                }
                else
                {
                    throw new System.Exception("The currency was different");                                                                     //throw exception for currency mismatch
                }

            
            
        }
    }
}
