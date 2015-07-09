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
        public double Amount               //Property for amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0 || double.IsPositiveInfinity(value))
                {
                    throw new System.Exception(Resource.InvalidAmountInput);
                }
                this._amount = value;
            }
        }
        public string Currency           //Property for Currency
        {
            get
            {
                return _currency;

            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception(Resource.InvalidCurrency);
                }
                this._currency = value;
            }
        }
        public Money(double amount, string currency)                       //Constructor for receiving inputs
        {
            Amount = amount;
            Currency = currency;
        }
        public static Money operator +(Money money1, Money money2)                          //operator overloading function    
        {
            if (money1 == null || money2 == null)
            {

                throw new ArgumentException(Resource.ObjectNull);
            }

            if (money1.Currency.Equals(money2.Currency, StringComparison.CurrentCultureIgnoreCase))
            {

                double MoneySum;

                MoneySum = money1.Amount + money2.Amount;
                if (MoneySum > double.MaxValue)
                {
                    throw new System.Exception(Resource.InvalidSum);
                }
                else
                {
                    return new Money(MoneySum, money1.Currency);
                }
            }
            else
            {
                throw new System.Exception(Resource.CurrencyMismatch);                                                                     //throw exception for currency mismatch
            }


        }
    }
}













