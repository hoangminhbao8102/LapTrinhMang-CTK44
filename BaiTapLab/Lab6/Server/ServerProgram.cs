using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerProgram
    {
        private IPAddress? serverIP;
        public IPAddress? ServerIP
        {
            get
            {
                return serverIP;
            }
            set
            {
                this.serverIP = value;
            }
        }
        private int port;
        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }
        //delegate để set dữ liệu cho các Control
        //Tại thời điểm này ta chưa biết dữ liệu sẽ được hiển thị vào đâu nên phải dùng delegate
        public delegate void SetDataControl(string Data);
        public SetDataControl? SetDataFunction = null;
        public delegate void SetStatusControl(string Data);
        public SetStatusControl? SetStatusFunction = null;
        public delegate void ClientConnectedControl(string ClientInfo);
        public ClientConnectedControl? ClientConnectedFunction = null;
        Socket? serverSocket = null;
        List<Socket> clientSockets = new List<Socket>();
        IPEndPoint? serverEP = null;
        Socket? clientSocket = null;
        //buffer để nhận và gởi dữ liệu
        byte[] buff = new byte[1024];
        //Số byte thực sự nhận được
        int byteReceive = 0;
        string stringReceive = "";
        public ServerProgram(IPAddress? ServerIP, int Port)
        {
            this.ServerIP = ServerIP ?? throw new ArgumentNullException(nameof(ServerIP));
            this.Port = Port;
        }
        //Lắng nghe kết nối
        public void Listen()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverEP = new IPEndPoint(ServerIP ?? throw new ArgumentNullException(nameof(ServerIP)), Port);
            //Kết hợp Server Socket với Local Endpoint
            serverSocket.Bind(serverEP);
            //Lắng nghe kết nối trên Server Socket
            //-1: không giới hạn số lượng client kết nối đến
            serverSocket.Listen(-1);
            SetStatusFunction?.Invoke("Đang chờ kết nối"); //Bắt đầu chấp nhận Client kết nối đến
            serverSocket.BeginAccept(new AsyncCallback(AcceptScoket), serverSocket);
        }
        //Hàm callback chấp nhận Client kết nối
        private void AcceptScoket(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState!;
            //Hàm Accept sẽ block server lại và chờ Client kết nối đến
            //Sau khi Client kết nối đến sẽ trả về socket chứa thông tin của Client
            clientSocket = s.EndAccept(ia);
            clientSockets.Add(clientSocket);
            string clientInfo = clientSocket.RemoteEndPoint?.ToString() ?? "Unknown Client";
            ClientConnectedFunction?.Invoke(clientInfo);
            string hello = "Hello Client";
            buff = Encoding.UTF8.GetBytes(hello);
            SetStatusFunction?.Invoke("Client " + clientSocket.RemoteEndPoint?.ToString() + " đã kết nối đến");
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), clientSocket);
        }
        private void SendData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState!;
            s.EndSend(ia);
            //khởi tạo lại buffer để nhận dữ liệu
            buff = new byte[1024];
            //Bắt đầu nhận dữ liệu
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
        public void Close()
        {
            foreach (var socket in clientSockets)
            {
                socket.Close();
            }
            clientSockets.Clear();
            serverSocket?.Close();
        }
        private void ReceiveData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState!;
            try
            {
                //Hàm EndReceive sẽ bị block cho đến khi có dữ liệu trong TCP buffer
                byteReceive = s.EndReceive(ia);
            }
            catch
            {
                //Trường hợp lỗi xảy ra khi Client ngắt kết nối
                CloseClient(s);
                SetStatusFunction?.Invoke("Client ngắt kết nối");
                return;
            }
            //Nếu Client shutdown thì hàm EndReceive sẽ trả về 0
            if (byteReceive == 0)
            {
                CloseClient(s);
                SetStatusFunction?.Invoke("Client đóng kết nối");
            }
            else
            {
                stringReceive = Encoding.UTF8.GetString(buff, 0, byteReceive);
                SetDataFunction?.Invoke($"Received from {s.RemoteEndPoint}: {stringReceive}");
                //Sau khi Server nhận dữ liệu xong thì bắt đầu gởi dữ liệu xuống cho Client
                s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), s);
            }
        }
        private void CloseClient(Socket client)
        {
            clientSockets.Remove(client);
            client.Close();
        }
        private void SendDataToClient(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState!;
            s.EndSend(ia);
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
    }
}
