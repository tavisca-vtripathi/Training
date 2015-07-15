﻿ using System;
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
