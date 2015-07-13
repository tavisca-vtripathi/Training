using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class Dispatcher
    {
        private Socket _serverSocket;
        private int _timeout;
        private string _contentPath;
        public Dispatcher(Socket serverSocket, String contentPath)
        {
            _serverSocket = serverSocket;
            _timeout = 5;
            _contentPath = contentPath;
        }

        public void AcceptRequest()
        {
            Socket clientSocket = null;
            try
            {
                // Create new thread to handle the request and continue to listen the socket.
                clientSocket = _serverSocket.Accept();

                var requestHandler = new Thread(() =>
                {
                    clientSocket.ReceiveTimeout = _timeout;
                    clientSocket.SendTimeout = _timeout;
                    HandleTheRequest(clientSocket);
                });
                requestHandler.Start();
            }
            catch
            {
                if (clientSocket != null)
                    clientSocket.Close();
                throw new System.Exception(Resource.ClientAcceptingError);

            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            var requestParser = new RequestParser();

            string requestString = DecodeRequest(clientSocket);
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var createResponse = new CreateResponse(clientSocket, _contentPath);
                createResponse.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                throw new System.Exception(Resource.UnImplementedMethod);
            }
            StopClientSocket(clientSocket);
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;
            var buffer = new byte[1024000];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                Console.ReadLine();
            }
            return Encoding.UTF8.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
