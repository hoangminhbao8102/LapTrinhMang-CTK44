namespace Bai3
{
    partial class MainForm
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
            label1 = new Label();
            label2 = new Label();
            txtDomain = new TextBox();
            btnResolve = new Button();
            lbResults = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên miền";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 1;
            label2.Text = "Phân giải sau khi nhập tên miền";
            // 
            // txtDomain
            // 
            txtDomain.Location = new Point(74, 12);
            txtDomain.Name = "txtDomain";
            txtDomain.Size = new Size(244, 23);
            txtDomain.TabIndex = 2;
            // 
            // btnResolve
            // 
            btnResolve.Location = new Point(324, 12);
            btnResolve.Name = "btnResolve";
            btnResolve.Size = new Size(75, 23);
            btnResolve.TabIndex = 3;
            btnResolve.Text = "Phân giải";
            btnResolve.UseVisualStyleBackColor = true;
            btnResolve.Click += btnResolve_Click;
            // 
            // lbResults
            // 
            lbResults.FormattingEnabled = true;
            lbResults.ItemHeight = 15;
            lbResults.Location = new Point(12, 56);
            lbResults.Name = "lbResults";
            lbResults.Size = new Size(389, 94);
            lbResults.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 167);
            Controls.Add(lbResults);
            Controls.Add(btnResolve);
            Controls.Add(txtDomain);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Phân giải tên miền";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDomain;
        private Button btnResolve;
        private ListBox lbResults;
    }
}
