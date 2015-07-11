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
        public static Dictionary<string, double> ParsingData()
        {
           Dictionary<string, double> finalData=new Dictionary<string,double>();
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

            string[] currencyRate = blocks[2].Split(',');
            foreach (string individualRates in currencyRate)
            {

                keyValue = individualRates.Split(':');
                keyValue[0] = keyValue[0].Trim();
                keyValue[0] = keyValue[0].Remove(0, 4);
                keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1);
                finalData.Add(keyValue[0], double.Parse(keyValue[1]));
            }
            return finalData;
        }
    }
}