using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> ceb05b56c55fa4efc1ceb10271de68a060243c84

namespace WebServer.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
<<<<<<< HEAD
                string host = ConfigurationManager.AppSettings["webserver-host"];
                if (string.IsNullOrEmpty(host))
                    throw new Exception("Host is invalid");

                int port = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["webserver-port"], out port) == false)
                    throw new Exception("Port is invalid");
                var server = new Server(host, port);
                server.Start();

                Console.WriteLine("Enter any key to exit");
                Console.ReadKey();

                server.Stop();
=======
                Listener listener = new Listener(8080);
                listener.Start();
>>>>>>> ceb05b56c55fa4efc1ceb10271de68a060243c84

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
