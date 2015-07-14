using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Listener listener = new Listener(8080);
                listener.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
