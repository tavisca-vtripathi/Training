using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Listener
    {
        // check for already running
        private bool _running = false;
        private int _timeout = 5;
        private Socket _serverSocket;
        TcpListener tcp = new TcpListener(IPAddress.Any, 8080);


        // Directory to host our contents
        private string _contentPath;
        private void InitializeSocket(int port, string contentPath) //create socket
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            _serverSocket.Listen(100);    //no of request in queue
            _serverSocket.ReceiveTimeout = _timeout;
            _serverSocket.SendTimeout = _timeout;
            _running = true; //socket created
            _contentPath = contentPath;
        }
        public void Start(int port, string contentPath)
        {
            try
            {
                InitializeSocket(port, contentPath);
            }
            catch
            {
                throw new System.Exception(Resource.SocketCreatingError);

            }
            while (_running)
            {
                //if (tcp.Pending())
                {
                    var dispatcher = new Dispatcher(_serverSocket, contentPath);
                    dispatcher.AcceptRequest();
                }
            }
        }
        public void Stop()
        {
            _running = false;
            try
            {
                _serverSocket.Close();
            }
            catch
            {
                throw new System.Exception(Resource.SocketClosingError);

            }
            _serverSocket = null;
        }

    }
}
