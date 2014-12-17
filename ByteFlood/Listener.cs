﻿using System;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using Jayrock.JsonRpc;

namespace ByteFlood
{
    public enum LogMessageType
    {
        Error, Info, Warning
    }
    /// <summary>
    /// RPC listener
    /// </summary>
    public class Listener
    {
        public State State;
        public Thread Thread;
        public bool Running = true;
        public TcpListener TcpListener;
        public StateRpcHandler Handler;
        public Listener(State state)
        {
            Thread = new Thread(new ThreadStart(MainLoop));
            Thread.SetApartmentState(ApartmentState.STA);
            Thread.Start();
            State = state;
            Handler = new StateRpcHandler(State);
        }

        public void MainLoop()
        {
            TcpListener = new TcpListener(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 65432));
            TcpListener.Start();
            while (Running)
            {
                try
                {
                    HandleConnection(TcpListener.AcceptTcpClient());
                }
                catch (Exception ex)
                {
                    LogMessage("Exception occurred in listener thread!", LogMessageType.Error);
                    LogMessage(ex.Message, LogMessageType.Error);
                    LogMessage(ex.StackTrace, LogMessageType.Error);
                }
            }
        }

        public void HandleConnection(TcpClient tcp)
        {
            var ns = tcp.GetStream();
            using (var sw = new StreamWriter(ns) { AutoFlush = true })
            using (var sr = new StreamReader(ns))
            {
	            LogMessage(string.Format("Incoming connection from {0}", tcp.Client.RemoteEndPoint.ToString()));
	            JsonRpcDispatcherFactory.CreateDispatcher(Handler).Process(sr, sw);
	            LogMessage("Closed connection");
            }
        }

        public void LogMessage(string message, LogMessageType type = LogMessageType.Info)
        {
            Console.WriteLine("[{0}] {1}", type.ToString().ToUpper(), message);
        }

        public void Shutdown()
        {
            Running = false;
            TcpListener.Stop();
            Thread.Abort();
        }
    }
}
