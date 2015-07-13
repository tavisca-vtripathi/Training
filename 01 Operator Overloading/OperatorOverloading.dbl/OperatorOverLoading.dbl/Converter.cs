using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using System.Configuration;

namespace OperatorOverloading.Dbl
{
    public class ConvertCurrency : ICurencyConverter
    {
        /// <summary>
        /// This fuction expects input as (USD , INR) and returns exchange rate of input currencies.
        /// </summary>
        /// <param name="sourceCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        public double Convert(string sourceCurrency, string targetCurrency)
        {
            double rate;
            string source = ConfigurationManager.AppSettings["source"];
            var exchangeRate = FileParser.JsonDataParser();
            if (sourceCurrency != source && targetCurrency != source)
            {
                throw new System.Exception("Invalid Currency");
            }
            else if (exchangeRate.TryGetValue(targetCurrency, out rate) == false)
            {
                throw new System.Exception("Please check your currency input");

            }
            else if (sourceCurrency.Equals(source))
            {
                return rate = exchangeRate[targetCurrency];
            }
            else
            {
                return rate = (1 / exchangeRate[targetCurrency]);
            }

        }
    }
}
