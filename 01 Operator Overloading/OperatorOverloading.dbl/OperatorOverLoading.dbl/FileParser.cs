using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    public class FileParser
    {
        /// <summary>
        /// Parsing data function fetches Json string and returns json string after spliiting it into Dictionary<CurrencyName , Rate >
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, double> JsonDataParser()
        {
            Dictionary<string, double> finalData = new Dictionary<string, double>();
            string line;
            string completeData = "";
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"D:\Training\01 Operator Overloading\OperatorOverloading.dbl\Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                completeData += line;

            }
            file.Close();
            string[] blocks = completeData.Split('{', '}');
            string[] sourceFinder = blocks[1].Split(',');
            string[] keyValue;

            string[] currencyRate = blocks[2].Split(',');        // Split Currency inyo array after each ","
            foreach (string individualRates in currencyRate)
            {

                keyValue = individualRates.Split(':');    //This split removes currency name and exchange rates in two parts
                keyValue[0] = keyValue[0].Trim();          // Trims the splitted parts
                keyValue[0] = keyValue[0].Remove(0, 4);        //Removes Source name USD from the Json string
                keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1);
                finalData.Add(keyValue[0], double.Parse(keyValue[1]));     //Unhandled exception will occur if Json parser string is distorted due to extra space in double part or redundant currency name
            }
            return finalData;
        }
    }
}