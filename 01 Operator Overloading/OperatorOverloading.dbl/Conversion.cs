using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    public class Converter : IParser
    {
        static string[] initialseperatedString;
        static string[] currencySeperatedString;

        public double GetConversion(string sourceCurrency, string targetCurrency)
        {
            int counter = 0;
            string line;
            string completeData = "";
            System.IO.StreamReader file =
                           new System.IO.StreamReader(@"D:\Training\01 Operator Overloading\OperatorOverloading.dbl\Data.txt");

            while ((line = file.ReadLine()) != null)
            {
                completeData += line;
                counter++;
            }
            
            file.Close();
            initialseperatedString = completeData.Split('{');
            currencySeperatedString = initialseperatedString[2].Split(',');


            double multiplier1 = getMultiplier(sourceCurrency);
            double multiplier2 = getMultiplier(targetCurrency);
            return (multiplier2 / multiplier1);

        }

        public static double getMultiplier(string currency)
        {
            bool check = false;
            if (currency.Equals("USD"))
                return 1;
            int j;
            for (j = 0; j < currencySeperatedString.Length; j++)
            {
                if (currencySeperatedString[j].Contains(currency) == true)
                {
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                throw new System.Exception("Currency not found..!!");
            }
            string[] finalSplit = currencySeperatedString[j].Split(':');
            double multiplier = Convert.ToDouble(finalSplit[1]);

            return multiplier;
        }
    }

}
