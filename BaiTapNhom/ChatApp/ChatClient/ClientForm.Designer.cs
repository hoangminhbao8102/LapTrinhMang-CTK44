namespace ChatClient
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            label1 = new Label();
            label2 = new Label();
            lblStatus = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            lstMessages = new ListBox();
            groupBox1 = new GroupBox();
            gbOnlineUsers = new GroupBox();
            lstOnlineUsers = new ListBox();
            btnRefreshOnlineUsers = new Button();
            groupBox2 = new GroupBox();
            lstGroupMessages = new ListBox();
            label3 = new Label();
            btnCreateGroup = new Button();
            txtGroupName = new TextBox();
            btnSendGroupMessage = new Button();
            txtGroupMessage = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            lstGroups = new ListBox();
            groupBox1.SuspendLayout();
            gbOnlineUsers.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(46, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(101, 39);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Mở kết nối";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(373, 494);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Trạng thái:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Nhập tin nhắn";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(442, 494);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(16, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "...";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(101, 57);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(173, 23);
            txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(280, 57);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 5;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lstMessages
            // 
            lstMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstMessages.FormattingEnabled = true;
            lstMessages.ItemHeight = 15;
            lstMessages.Location = new Point(6, 22);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(336, 109);
            lstMessages.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstMessages);
            groupBox1.Location = new Point(12, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 145);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đoạn chat sau khi gửi";
            // 
            // gbOnlineUsers
            // 
            gbOnlineUsers.Controls.Add(lstOnlineUsers);
            gbOnlineUsers.Location = new Point(367, 12);
            gbOnlineUsers.Name = "gbOnlineUsers";
            gbOnlineUsers.Size = new Size(198, 290);
            gbOnlineUsers.TabIndex = 8;
            gbOnlineUsers.TabStop = false;
            gbOnlineUsers.Text = "Xem người dùng hoạt động";
            // 
            // lstOnlineUsers
            // 
            lstOnlineUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstOnlineUsers.FormattingEnabled = true;
            lstOnlineUsers.ItemHeight = 15;
            lstOnlineUsers.Location = new Point(6, 22);
            lstOnlineUsers.Name = "lstOnlineUsers";
            lstOnlineUsers.Size = new Size(186, 244);
            lstOnlineUsers.TabIndex = 0;
            // 
            // btnRefreshOnlineUsers
            // 
            btnRefreshOnlineUsers.Location = new Point(233, 13);
            btnRefreshOnlineUsers.Name = "btnRefreshOnlineUsers";
            btnRefreshOnlineUsers.Size = new Size(90, 38);
            btnRefreshOnlineUsers.TabIndex = 9;
            btnRefreshOnlineUsers.Text = "Làm mới";
            btnRefreshOnlineUsers.UseVisualStyleBackColor = true;
            btnRefreshOnlineUsers.Click += btnRefreshOnlineUsers_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstGroupMessages);
            groupBox2.Location = new Point(12, 299);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(349, 210);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Đoạn chat sau khi gửi cho nhóm";
            // 
            // lstGroupMessages
            // 
            lstGroupMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstGroupMessages.FormattingEnabled = true;
            lstGroupMessages.ItemHeight = 15;
            lstGroupMessages.Location = new Point(7, 22);
            lstGroupMessages.Name = "lstGroupMessages";
            lstGroupMessages.Size = new Size(336, 169);
            lstGroupMessages.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 241);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 11;
            label3.Text = "Nhập tên nhóm";
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.Location = new Point(286, 237);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(75, 23);
            btnCreateGroup.TabIndex = 12;
            btnCreateGroup.Text = "Tạo nhóm";
            btnCreateGroup.UseVisualStyleBackColor = true;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(109, 237);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(171, 23);
            txtGroupName.TabIndex = 13;
            // 
            // btnSendGroupMessage
            // 
            btnSendGroupMessage.Location = new Point(269, 266);
            btnSendGroupMessage.Name = "btnSendGroupMessage";
            btnSendGroupMessage.Size = new Size(92, 23);
            btnSendGroupMessage.TabIndex = 16;
            btnSendGroupMessage.Text = "Gửi cho nhóm";
            btnSendGroupMessage.UseVisualStyleBackColor = true;
            btnSendGroupMessage.Click += btnSendGroupMessage_Click;
            // 
            // txtGroupMessage
            // 
            txtGroupMessage.Location = new Point(136, 266);
            txtGroupMessage.Name = "txtGroupMessage";
            txtGroupMessage.Size = new Size(127, 23);
            txtGroupMessage.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 270);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 14;
            label4.Text = "Nhập tin nhắn nhóm";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lstGroups);
            groupBox3.Location = new Point(367, 308);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(198, 183);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách nhóm";
            // 
            // lstGroups
            // 
            lstGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstGroups.FormattingEnabled = true;
            lstGroups.ItemHeight = 15;
            lstGroups.Location = new Point(6, 22);
            lstGroups.Name = "lstGroups";
            lstGroups.Size = new Size(186, 154);
            lstGroups.TabIndex = 0;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 521);
            Controls.Add(groupBox3);
            Controls.Add(btnSendGroupMessage);
            Controls.Add(txtGroupMessage);
            Controls.Add(label4);
            Controls.Add(txtGroupName);
            Controls.Add(btnCreateGroup);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(btnRefreshOnlineUsers);
            Controls.Add(gbOnlineUsers);
            Controls.Add(groupBox1);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(lblStatus);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Name = "ClientForm";
            Text = "Client";
            groupBox1.ResumeLayout(false);
            gbOnlineUsers.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Label label1;
        private Label label2;
        private Label lblStatus;
        private TextBox txtMessage;
        private Button btnSend;
        private ListBox lstMessages;
        private GroupBox groupBox1;
        private GroupBox gbOnlineUsers;
        private ListBox lstOnlineUsers;
        private Button btnRefreshOnlineUsers;
        private GroupBox groupBox2;
        private Label label3;
        private Button btnCreateGroup;
        private TextBox txtGroupName;
        private ListBox lstGroupMessages;
        private Button btnSendGroupMessage;
        private TextBox txtGroupMessage;
        private Label label4;
        private GroupBox groupBox3;
        private ListBox lstGroups;
    }
}