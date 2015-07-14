using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;

namespace WebServer.Model
{
    class Dispatcher
    {
        private Socket _clientSocket = null; // use a queue later on

        public Dispatcher(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }
        public void HandleClient()
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(_clientSocket);
            requestParser.Parser(requestString);

            Console.WriteLine(requestParser.HttpUrl);

            if (requestParser.HttpMethod != null && requestParser.HttpMethod.Equals("GET"))
            {
                //TO DO: Select appropriate class for serving the received GET request.....
                var createResponse = new CreateResponse(_clientSocket, ConfigurationManager.AppSettings["Path"]);
                createResponse.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Thread.Yield();

            }
            StopClientSocket(_clientSocket);  //closes the connection
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            Encoding _charEncoder = Encoding.UTF8;
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {

                Thread.Yield();

            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }



    }
}
