namespace Server
{
    partial class ServerForm
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
            btnStart = new Button();
            btnStop = new Button();
            label1 = new Label();
            lstReceivedData = new ListBox();
            label2 = new Label();
            txtConnectionStatus = new TextBox();
            label3 = new Label();
            txtPort = new TextBox();
            label4 = new Label();
            lstClients = new ListBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(44, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 31);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(202, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(86, 31);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 2;
            label1.Text = "Text receive form client:";
            // 
            // lstReceivedData
            // 
            lstReceivedData.FormattingEnabled = true;
            lstReceivedData.ItemHeight = 15;
            lstReceivedData.Location = new Point(12, 94);
            lstReceivedData.Name = "lstReceivedData";
            lstReceivedData.Size = new Size(161, 154);
            lstReceivedData.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 257);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 4;
            label2.Text = "Connection Status:";
            // 
            // txtConnectionStatus
            // 
            txtConnectionStatus.Location = new Point(136, 254);
            txtConnectionStatus.Name = "txtConnectionStatus";
            txtConnectionStatus.Size = new Size(189, 23);
            txtConnectionStatus.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 52);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 6;
            label3.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(136, 49);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 23);
            txtPort.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(179, 75);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 8;
            label4.Text = "Clients:";
            // 
            // lstClients
            // 
            lstClients.FormattingEnabled = true;
            lstClients.ItemHeight = 15;
            lstClients.Location = new Point(179, 94);
            lstClients.Name = "lstClients";
            lstClients.Size = new Size(163, 154);
            lstClients.TabIndex = 9;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 289);
            Controls.Add(lstClients);
            Controls.Add(label4);
            Controls.Add(txtPort);
            Controls.Add(label3);
            Controls.Add(txtConnectionStatus);
            Controls.Add(label2);
            Controls.Add(lstReceivedData);
            Controls.Add(label1);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "ServerForm";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label label1;
        private ListBox lstReceivedData;
        private Label label2;
        private TextBox txtConnectionStatus;
        private Label label3;
        private TextBox txtPort;
        private Label label4;
        private ListBox lstClients;
    }
}
