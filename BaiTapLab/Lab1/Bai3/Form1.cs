using System.Net;

namespace Bai3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            string domain = txtDomain.Text;
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(domain);
                lbResults.Items.Add("Tên miền: " + hostInfo.HostName);
                lbResults.Items.Add("Địa chỉ IP:");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    lbResults.Items.Add(ipaddr.ToString());
                }
            }
            catch (Exception ex)
            {
                lbResults.Items.Add("Không phân giải được tên miền: " + domain);
                lbResults.Items.Add("Lỗi: " + ex.Message);
            }
        }
    }
}
