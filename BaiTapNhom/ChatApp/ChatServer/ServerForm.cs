using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        private TcpListener? server;
        private Thread? serverThread;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            serverThread = new Thread(ListenForClients);
            serverThread.Start();
            Invoke(new Action(() => lstClients.Items.Add("Máy chủ đã khởi động...")));
        }

        private void ListenForClients()
        {
            while (true)
            {
                TcpClient client = server!.AcceptTcpClient();
                Thread clientThread = new Thread(HandleClient!);
                clientThread.Start(client);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Invoke(new Action(() => lstClients.Items.Add(message)));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }
    }
}
