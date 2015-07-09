﻿using System;
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
            get { return _amount; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception (Resource.InvalidAmountInput);
                }
                if (double.IsPositiveInfinity(value))
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
                if (string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new Exception(Resource.InvalidCurrency);
                }
                _currency = value;
            }
        }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money(string inputAmount)
        {

            if (string.IsNullOrWhiteSpace(inputAmount)||string.IsNullOrEmpty(inputAmount))
            {
                throw new Exception (Resource.InvalidInput);
            }

            var amountArr = inputAmount.Split(' ');
            double amount;

            if (amountArr.Length != 2)
            {
               throw new Exception (Resource.InvalidAmountInput);
            }

            if (double.TryParse(amountArr[0], out amount))
            {
                Amount = amount;
            }
            else
            {
                throw new Exception(Resource.InvalidAmountInput);
            }

            Currency = amountArr[1];
        }

        public static Money operator +(Money obj1, Money obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new Exception (Resource.ObjectNull);
            }
            if (obj1.Currency.Equals(obj2.Currency, StringComparison.CurrentCultureIgnoreCase))
            {
                double totalAmount = obj1.Amount + obj2.Amount;
                return new Money(totalAmount, obj1.Currency);
            }
            else
            {
                throw new Exception (Resource.CurrencyMismatch);
            }
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}













