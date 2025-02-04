namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnSend = new Button();
            label1 = new Label();
            txtSendMessage = new TextBox();
            lstReceivedData = new ListBox();
            label2 = new Label();
            txtConnectionStatus = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtServerIP = new TextBox();
            txtPort = new TextBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(44, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(85, 34);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(188, 12);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(85, 34);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(216, 126);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 107);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "Enter text:";
            // 
            // txtSendMessage
            // 
            txtSendMessage.Location = new Point(22, 125);
            txtSendMessage.Name = "txtSendMessage";
            txtSendMessage.Size = new Size(171, 23);
            txtSendMessage.TabIndex = 4;
            // 
            // lstReceivedData
            // 
            lstReceivedData.FormattingEnabled = true;
            lstReceivedData.ItemHeight = 15;
            lstReceivedData.Location = new Point(9, 155);
            lstReceivedData.Name = "lstReceivedData";
            lstReceivedData.Size = new Size(301, 124);
            lstReceivedData.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 293);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 6;
            label2.Text = "Connection Status:";
            // 
            // txtConnectionStatus
            // 
            txtConnectionStatus.Location = new Point(135, 290);
            txtConnectionStatus.Name = "txtConnectionStatus";
            txtConnectionStatus.Size = new Size(156, 23);
            txtConnectionStatus.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 55);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "Server IP:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 84);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 9;
            label4.Text = "Port:";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(147, 52);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(100, 23);
            txtServerIP.TabIndex = 10;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(147, 81);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 23);
            txtPort.TabIndex = 11;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 325);
            Controls.Add(txtPort);
            Controls.Add(txtServerIP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtConnectionStatus);
            Controls.Add(label2);
            Controls.Add(lstReceivedData);
            Controls.Add(txtSendMessage);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Name = "ClientForm";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Button btnDisconnect;
        private Button btnSend;
        private Label label1;
        private TextBox txtSendMessage;
        private ListBox lstReceivedData;
        private Label label2;
        private TextBox txtConnectionStatus;
        private Label label3;
        private Label label4;
        private TextBox txtServerIP;
        private TextBox txtPort;
    }
}
