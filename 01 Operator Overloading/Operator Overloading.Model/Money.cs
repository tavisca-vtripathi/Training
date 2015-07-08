using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public double Amount 
        { 
            get
            {
            return _amount;
            }
            set
            {
                if (value<0 || double.IsPositiveInfinity(value))
                {
                    throw new System.Exception(Resource.InvalidAmountInput);
                }
                this._amount = value;
            }

       }
        public string Currency { 
            get
            {
                return _currency;
            
            }
            set
            { 
            if(string.IsNullOrEmpty(value))
            {
            throw new System.Exception(Resource.InvalidCurrency);
            }
            this._currency=value;
            }
        }


        
       
       
        public Money(double amount, string currency)
        {
             

               Amount  = amount;
               Currency = currency;


            
           
        }
             
    
          

        

        public static Money operator +(Money money1, Money money2)                                 //operator overloading function    
        { 
               Money money3 = new Money(0.0,"");
                if (money1.Currency.Equals(money2.Currency , StringComparison.CurrentCultureIgnoreCase))
                {
                       
                        money3.Amount = money1.Amount + money2.Amount;
                        if(money3.Amount>double.MaxValue)
                        {
                            throw new System.Exception(Resource.InvalidSum);
                        }
                        else
                        {
                        money3.Currency = money1.Currency;
                        return money3;}
                    
                   
                }
                else
                {
                    throw new System.Exception(Resource.CurrencyMismatch);                                                                     //throw exception for currency mismatch
                }

            
            
        }
    }
}
