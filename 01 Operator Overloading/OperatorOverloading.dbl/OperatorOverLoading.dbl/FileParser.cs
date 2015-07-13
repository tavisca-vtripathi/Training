using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using OperatorOverLoading.Dbl;
namespace OperatorOverloading.Dbl
{
    public class FileParser
    {
        /// <summary>
        /// Parsing data function fetches Json string and returns json string after spliiting it into Dictionary<CurrencyName , Rate >
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, double> JsonDataParser()
        {
            string path = ConfigurationManager.AppSettings["path"];
            Dictionary<string, double> exchangeRate = new Dictionary<string, double>();
            string jsonString = "";
            if (!File.Exists(path))
            {
                throw new System.Exception(Resource.FileNotFound);
            }
            jsonString = File.ReadAllText(path);
            string[] blocks = jsonString.Split('{', '}');
            string[] sourceFinder = blocks[1].Split(',');
            string[] keyValue;

            string[] currencyRate = blocks[2].Split(',');        // Split Currency inyo array after each ","
            double rate;
            foreach (string individualRates in currencyRate)
            {

                keyValue = individualRates.Split(':');    //This split removes currency name and exchange rates in two parts
                keyValue[0] = keyValue[0].Trim();          // Trims the splitted parts
                keyValue[0] = keyValue[0].Remove(0, 4);        //Removes Source name USD from the Json string
                keyValue[0] = keyValue[0].Remove(keyValue[0].Length - 1, 1);
                if (double.TryParse(keyValue[1], out rate) == false)
                    throw new System.Exception(Resource.InvalidArgument);
                exchangeRate.Add(keyValue[0], rate);     //Unhandled exception will occur if Json parser string is distorted due to extra space in double part or redundant currency name
            }
            return exchangeRate;
        }
    }
}