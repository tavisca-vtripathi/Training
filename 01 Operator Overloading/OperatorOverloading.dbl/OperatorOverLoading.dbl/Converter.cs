using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperatorOverloading.dbl
{
    public class Converter : IParser
    {
        
        static string[] finalData;
        /// <summary>
        /// this fuction expects input as (USD , INR) and returns exchange rate of input currencies
        /// </summary>
        /// <param name="sourceCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        public double GetConversion(string sourceCurrency, string targetCurrency)
        {    finalData = FileParser.ParsingData();
            double multiplier1 = getMultiplier(sourceCurrency);
            double multiplier2 = getMultiplier(targetCurrency);
            if(multiplier1 == 0)
            {   
            throw new System.DivideByZeroException();
            }
            return (multiplier2 / multiplier1);
        }
        /// <summary>
        /// It expexts input as (AFN) and It returns currency's exchange rate as comparison to USD
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static double getMultiplier(string currency)
        {
            bool check = false;
            if (currency.Equals("USD"))
            {
                return 1;
            }
            int j;
            for (j = 0; j < finalData.Length; j++)
            {
                if (finalData[j].Contains(currency))
                {
                    check = true;
                    break;
                }
                    
            }
            if (check == false)
            {
                throw new System.Exception("Currency not found..!!");
            }
            string[] finalSplit = finalData[j].Split(':');
            double multiplier = Convert.ToDouble(finalSplit[1]);
            return multiplier;
        }

       
    }

}
