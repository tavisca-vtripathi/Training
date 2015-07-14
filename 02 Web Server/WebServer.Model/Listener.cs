using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;



namespace WebServer.Model
{
    public class Listener
    {

        private TcpListener _listener;
        private bool _running = false;


        public Listener(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            Thread listenerThread = new Thread(new ThreadStart(Run));
            listenerThread.Start();
        }

        public void Run()
        {
            _running = true;
            _listener.Start();
            while (_running)
            {
                if (_listener.Pending())
                {

                    Socket clientSocket = _listener.AcceptSocket();
                    Dispatcher _dispatcher = new Dispatcher(clientSocket);
                    Thread dispatcherThread = new Thread(new ThreadStart(_dispatcher.HandleClient));
                    dispatcherThread.Start();
                }
            }
            _running = false;
            _listener.Stop();
        }

    }
}