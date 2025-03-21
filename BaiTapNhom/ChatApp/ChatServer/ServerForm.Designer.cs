namespace ChatServer
{
    partial class ServerForm
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
            btnStart = new Button();
            lstClients = new ListBox();
            gbListClients = new GroupBox();
            gbListClients.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(123, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(130, 45);
            btnStart.TabIndex = 0;
            btnStart.Text = "Khởi động máy chủ";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lstClients
            // 
            lstClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstClients.FormattingEnabled = true;
            lstClients.ItemHeight = 15;
            lstClients.Location = new Point(6, 22);
            lstClients.Name = "lstClients";
            lstClients.Size = new Size(360, 124);
            lstClients.TabIndex = 1;
            // 
            // gbListClients
            // 
            gbListClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbListClients.Controls.Add(lstClients);
            gbListClients.Location = new Point(12, 63);
            gbListClients.Name = "gbListClients";
            gbListClients.Size = new Size(381, 162);
            gbListClients.TabIndex = 2;
            gbListClients.TabStop = false;
            gbListClients.Text = "Danh sách các Client";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 237);
            Controls.Add(gbListClients);
            Controls.Add(btnStart);
            Name = "ServerForm";
            Text = "ServerForm";
            gbListClients.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private ListBox lstClients;
        private GroupBox gbListClients;
    }
}