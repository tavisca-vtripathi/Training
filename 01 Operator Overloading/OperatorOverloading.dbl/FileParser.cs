using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.dbl
{
    class FileParser
    {
        
        static string[] finalData;
        /// <summary>
        /// Parsing data function fetches Json string and returns json string after spliiting it into string []
        /// </summary>
        /// <returns></returns>
        public static string[] ParsingData()
        {
            string line;
            string completeData = "";
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"D:\Training\01 Operator Overloading\OperatorOverloading.dbl\Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                completeData += line;
                
            }
            file.Close();
            finalData = completeData.Split('{', ',', '}');
            return finalData;
        }
    }
}