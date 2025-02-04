using System.Net;

namespace Client
{
    public partial class ClientForm : Form
    {
        private ClientProgram? clientProgram;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtServerIP.Text;
            int port = int.Parse(txtPort.Text);
            clientProgram = new ClientProgram();
            clientProgram.SetDataFunction = SetData;
            clientProgram.Connect(IPAddress.Parse(ip), port);
            txtConnectionStatus.Text = "Connecting...";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (clientProgram != null && clientProgram.Disconnect())
            {
                txtConnectionStatus.Text = "Disconnected.";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtSendMessage.Text;
            clientProgram?.SendData(message);
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
    }
}
