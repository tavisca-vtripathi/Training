using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;

namespace OperatorOverloading.dbl
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
            var finalData = FileParser.JsonDataParser();
            if(sourceCurrency!="USD" && targetCurrency != "USD")
            {
                throw new System.Exception("Invalid Currency");
            }
            else if (finalData.TryGetValue(targetCurrency, out rate)==false)
            { 
            throw new System.Exception("Please check your currency input");
            
            }
            else if (sourceCurrency.Equals("USD"))
            {
                return rate = finalData[targetCurrency];
            }
            else
            {
                return rate = (1 / finalData[targetCurrency]);
            }
            
        }
    }
}
