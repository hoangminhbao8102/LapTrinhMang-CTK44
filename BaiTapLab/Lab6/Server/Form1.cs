using System.Net;

namespace Server
{
    public partial class ServerForm : Form
    {
        private ServerProgram? serverProgram;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            serverProgram = new ServerProgram(IPAddress.Any, port);
            serverProgram.SetDataFunction = SetData;
            serverProgram.SetStatusFunction = SetStatus;
            serverProgram.ClientConnectedFunction = ClientConnected;
            serverProgram.Listen();
            txtConnectionStatus.Text = "Server started. Waiting for connections...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            serverProgram?.Close();
            txtConnectionStatus.Text = "Server stopped.";
            lstClients.Items.Clear();
        }

        private void SetData(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetData), data);
            }
            else
            {
                lstReceivedData.Items.Add(data);
            }
        }

        private void SetStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetStatus), status);
            }
            else
            {
                txtConnectionStatus.Text = status;
            }
        }

        private void ClientConnected(string clientInfo)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ClientConnected), clientInfo);
            }
            else
            {
                lstClients.Items.Add(clientInfo);
            }
        }
    }
}
