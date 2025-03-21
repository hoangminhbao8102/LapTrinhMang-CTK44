using ChatApp.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, HASHBYTES('SHA2_256', @password))";
            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
            MessageBox.Show("Đăng ký thành công!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Truy vấn lấy UserID từ database
            string query = "SELECT UserID FROM Users WHERE Username=@username AND PasswordHash=HASHBYTES('SHA2_256', @password)";
            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                // Gán giá trị UserID từ database
                int currentUserId = Convert.ToInt32(result.Rows[0]["UserID"]);

                MessageBox.Show("Đăng nhập thành công!");

                // Truyền currentUserId vào ClientForm
                ClientForm clientForm = new ClientForm(currentUserId);
                clientForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
