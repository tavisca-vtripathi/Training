using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.dbl;
using System.Text.RegularExpressions;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;

        public double Amount
        {
            get { return _amount; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception(Resource.InvalidAmountInput);
                }
                if (double.IsPositiveInfinity(value) || value > double.MaxValue)
                {
                    throw new Exception(Resource.InvalidAmountInput);
                }
                _amount = value;
            }
        }

        public string Currency
        {
            get { return _currency; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(Resource.InvalidCurrency);
                }
                _currency = value.ToUpper();
            }
        }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money(string inputAmount)   // input expexcted as 100 USD   
        {

            if (string.IsNullOrWhiteSpace(inputAmount))
            {
                throw new Exception(Resource.InvalidInput);
            }

            var amountArr = inputAmount.Split(' ');
            double amount;

            if (amountArr.Length != 2)
            {
                throw new Exception(Resource.InvalidAmountInput);
            }

            if (double.TryParse(amountArr[0], out amount) == false)
            {
                throw new Exception(Resource.InvalidAmountInput);

            }
            else
            {
                Amount = amount;
            }

            Currency = amountArr[1];
        }
        /// <summary>
        /// It expects input as (INR) i.e the currency to whic user wants to convert
        /// </summary>
        /// <param name="toCurrency"></param>
        /// <returns></returns>
        public Money ConvertCurrency(string toCurrency)
        {

            if (string.IsNullOrWhiteSpace(toCurrency) || toCurrency.Length != 3 || Regex.IsMatch(toCurrency, @"^[a-zA-Z]+$") == false)
            {
                throw new System.Exception(Resource.InvalidCurrency);
            }
            var convert = new ConvertCurrency();
            var exchangerate = convert.GetConversionRate(this.Currency, toCurrency);
            var totalAmount = exchangerate * this.Amount;
            if (double.IsPositiveInfinity(totalAmount) || totalAmount > double.MaxValue)
            {
                throw new System.Exception(Resource.OutOfRange);

            }
            return new Money(totalAmount, toCurrency);


        }
        public static Money operator +(Money obj1, Money obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new Exception(Resource.ObjectNull);
            }
            if (!obj1.Currency.Equals(obj2.Currency, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception(Resource.CurrencyMismatch);
            }
            else
            {
                double totalAmount = obj1.Amount + obj2.Amount;
                return new Money(totalAmount, obj1.Currency);
                throw new Exception(Resource.CurrencyMismatch);
            }
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}