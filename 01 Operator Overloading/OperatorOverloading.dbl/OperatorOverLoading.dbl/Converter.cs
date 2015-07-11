using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperatorOverloading.dbl
{
    public class Converter : IParser
    {
        static Dictionary<string, double> finalData;
        /// <summary>
        /// This fuction expects input as (USD , INR) and returns exchange rate of input currencies.
        /// </summary>
        /// <param name="sourceCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        public double GetConversion(string sourceCurrency, string targetCurrency)
        {
             
            finalData = FileParser.ParsingData();
            double multiplier1 = GetMultiplier(sourceCurrency);
            double multiplier2 = GetMultiplier(targetCurrency);
            if (multiplier1 == 0)
            {
                throw new System.DivideByZeroException();
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
            FileParser fs = new FileParser();
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
