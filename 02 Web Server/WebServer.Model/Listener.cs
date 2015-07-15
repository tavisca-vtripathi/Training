<<<<<<< HEAD
﻿ using System;
=======
﻿using System;
>>>>>>> ceb05b56c55fa4efc1ceb10271de68a060243c84
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
<<<<<<< HEAD
=======



>>>>>>> ceb05b56c55fa4efc1ceb10271de68a060243c84
namespace WebServer.Model
{
    public class Listener
    {

<<<<<<< HEAD
        private TcpListener _tcpListener;

        public Listener(string host, int port)
        {
            this._tcpListener = new TcpListener(IPAddress.Parse(host), port);
        }

        public void Listen()
        {
            this._tcpListener.Start();
            while (true)
            {
                var socket = this._tcpListener.AcceptSocket();
                if (socket.Connected == false) continue;

                Application.RequestQueue.Enqueue(socket);
            }
        }

        public void Stop()
        {
            this._tcpListener.Stop();
        }
    }
 }
=======
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
                    Dispatcher dispatcher = new Dispatcher(clientSocket);
                    Thread dispatcherThread = new Thread(new ThreadStart(dispatcher.HandleClient));
                    dispatcherThread.Start();
                }
            }
            _running = false;
            _listener.Stop();
        }

    }
}
>>>>>>> ceb05b56c55fa4efc1ceb10271de68a060243c84
