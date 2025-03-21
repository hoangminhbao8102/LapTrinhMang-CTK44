using ChatApp.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        private TcpClient? client;
        private NetworkStream? stream;
        private int currentUserId; // Lưu UserID của người dùng hiện tại

        public ClientForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId; // Gán UserID khi khởi chạy form
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient("127.0.0.1", 12345);
            stream = client.GetStream();
            lblStatus.Text = "Đã kết nối tới máy chủ!";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có người nhận được chọn
            if (lstOnlineUsers.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên người nhận
            string? selectedUsername = lstOnlineUsers.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUsername))
            {
                MessageBox.Show("Tên người nhận không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int receiverId = GetUserIdByUsername(selectedUsername);
            string message = txtMessage.Text;

            if (!string.IsNullOrEmpty(message))
            {
                // Gửi tin nhắn đến Server qua TCP/IP
                SendMessageToServer(receiverId, message);

                // Lưu vào SQL Server
                SendMessageToUser(receiverId, message);

                // Hiển thị tin nhắn trên danh sách tin nhắn của Client
                lstMessages.Items.Add("Bạn: " + message);
                txtMessage.Clear(); // Xóa nội dung nhập sau khi gửi
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!");
            }
        }

        private void SendMessageToServer(int receiverId, string message)
        {
            if (stream != null && stream.CanWrite)
            {
                string formattedMessage = $"{receiverId}:{message}"; // Định dạng tin nhắn "receiverId:message"
                byte[] buffer = Encoding.UTF8.GetBytes(formattedMessage);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        private void SendMessageToUser(int receiverId, string message)
        {
            // Kiểm tra nếu người nhận đang online
            string checkOnlineQuery = "SELECT COUNT(*) FROM Clients WHERE UserID = @receiverId AND Status = 'Online'";
            SqlParameter[] checkParams = { new SqlParameter("@receiverId", receiverId) };
            int isOnline = (int)DatabaseHelper.ExecuteQuery(checkOnlineQuery, checkParams).Rows[0][0];

            if (isOnline > 0)
            {
                // Người nhận đang online -> Lưu tin nhắn vào bảng Messages
                string query = "INSERT INTO Messages (SenderID, ReceiverID, MessageText) VALUES (@senderId, @receiverId, @message)";
                SqlParameter[] parameters = {
                    new SqlParameter("@senderId", currentUserId), // ID của người gửi
                    new SqlParameter("@receiverId", receiverId),
                    new SqlParameter("@message", message)
                };
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            else
            {
                // Người nhận offline -> Lưu tin nhắn vào bảng OfflineMessages
                string query = "INSERT INTO OfflineMessages (SenderID, ReceiverID, MessageText) VALUES (@senderId, @receiverId, @message)";
                SqlParameter[] parameters = {
                    new SqlParameter("@senderId", currentUserId),
                    new SqlParameter("@receiverId", receiverId),
                    new SqlParameter("@message", message)
                };
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
        }

        private int GetUserIdByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return -1; // Trả về -1 nếu tên không hợp lệ
            }

            string query = "SELECT UserID FROM Users WHERE Username = @username";
            SqlParameter[] parameters = { new SqlParameter("@username", username) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["UserID"]);
            }
            return -1; // Trả về -1 nếu không tìm thấy UserID
        }

        private void LoadOnlineUsers()
        {
            string query = "SELECT Username FROM Users U JOIN Clients C ON U.UserID = C.UserID WHERE C.Status = 'Online'";
            DataTable users = DatabaseHelper.ExecuteQuery(query);

            lstOnlineUsers.Items.Clear();
            foreach (DataRow row in users.Rows)
            {
                string username = row["Username"]?.ToString() ?? "Unknown"; // Nếu null thì gán "Unknown"
                lstOnlineUsers.Items.Add(username);
            }
        }

        private void CreateGroup(string groupName, int createdBy)
        {
            string query = "INSERT INTO Groups (GroupName, CreatedBy) VALUES (@groupName, @createdBy)";
            SqlParameter[] parameters = {
                new SqlParameter("@groupName", groupName),
                new SqlParameter("@createdBy", createdBy)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void SendMessageToGroup(int groupId, string message)
        {
            string query = "INSERT INTO GroupMessages (GroupID, SenderID, MessageText) VALUES (@groupId, @senderId, @message)";
            SqlParameter[] parameters = {
                new SqlParameter("@groupId", groupId),
                new SqlParameter("@senderId", currentUserId),
                new SqlParameter("@message", message)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void btnRefreshOnlineUsers_Click(object sender, EventArgs e)
        {
            LoadOnlineUsers();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            int userId = currentUserId; // Biến lưu UserID của người đang đăng nhập

            if (!string.IsNullOrEmpty(groupName))
            {
                CreateGroup(groupName, userId);
                MessageBox.Show("Nhóm đã được tạo thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhóm!");
            }
        }

        private void btnSendGroupMessage_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm trước khi gửi tin nhắn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lstGroups.SelectedValue.ToString(), out int selectedGroupId))
            {
                MessageBox.Show("Lỗi khi lấy GroupID. Hãy kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = txtGroupMessage.Text;
            if (!string.IsNullOrEmpty(message))
            {
                SendMessageToGroup(selectedGroupId, message);
                lstGroupMessages.Items.Add("Bạn: " + message);
                txtGroupMessage.Clear(); // Xóa nội dung sau khi gửi
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!");
            }
        }
    }
}
