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
        public double GetConversionRate(string sourceCurrency, string targetCurrency)
        {
            double multiplier1 = GetMultiplier(sourceCurrency);
            double multiplier2 = GetMultiplier(targetCurrency);
            if (multiplier1 == 0)
            {
                throw new System.Exception("Currency one exchange rate is zero");
            }
            return (multiplier2 / multiplier1);
        }
        /// <summary>
        /// It expects input as (AFN) and It returns currency's exchange rate as comparison to USD
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static double GetMultiplier(string currency)
        {
            var finalData = FileParser.JsonDataParser();
            var fs = new FileParser();
            if (currency.Equals("USD"))
            {
                return 1;
            }
            double multiplier;
           
            if(finalData.TryGetValue(currency, out multiplier)==false)
            {
                throw new System.Exception("Currency not found..!!");
            }
            
            return multiplier;
        }


    }

}
