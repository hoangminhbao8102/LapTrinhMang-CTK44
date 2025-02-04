﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai2
{
    class EchoProtocol : IProtocol
    {
        public const int BUFSIZE = 32; // Byte size of IO buffer
        private Socket clntSocket;
        private ILogger logger;

        public EchoProtocol(Socket clntSocket, ILogger logger) 
        {
            this.clntSocket = clntSocket;
            this.logger = logger;
        }

        public void HandleClient()
        {
            ArrayList entry = new ArrayList();
            entry.Add("Client address and port = " + clntSocket.RemoteEndPoint);
            entry.Add("Thread = " + Thread.CurrentThread.GetHashCode());
            try
            {
                int recvMsgSize; // Size of received message
                int totalBytesEchoed = 0; // Bytes received from client
                byte[] rcvBuffer = new byte[BUFSIZE];
                try
                {
                    while ((recvMsgSize = clntSocket.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None)) > 0) 
                    {
                        clntSocket.Send(rcvBuffer, 0, recvMsgSize, SocketFlags.None);
                        totalBytesEchoed += recvMsgSize;
                    }
                }
                catch (SocketException se)
                {
                    entry.Add(se.ErrorCode + ": " + se.Message);
                }
                entry.Add("Client finished; echoed " + totalBytesEchoed + " bytes.");
            }
            catch (SocketException se)
            {
                entry.Add(se.ErrorCode + ": " + se.Message);
            }
            clntSocket.Close();
            logger.WriteEntry(entry);
        }
    }
}
