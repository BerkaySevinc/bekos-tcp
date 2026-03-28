namespace Tcp.Demo
{
    partial class Client
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
            lblReceived = new Label();
            lblSent = new Label();
            lvSent = new NoHScrollListView();
            lvReceived = new NoHScrollListView();
            btnConnect = new Button();
            btnDisconnect = new Button();
            lblPing = new Label();
            lvConnections = new NoHScrollListView();
            SuspendLayout();
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.Font = new Font("Segoe UI", 15F);
            lblReceived.ForeColor = SystemColors.Control;
            lblReceived.Location = new Point(76, 372);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(167, 28);
            lblReceived.TabIndex = 8;
            lblReceived.Text = "Received Count: 0";
            // 
            // lblSent
            // 
            lblSent.AutoSize = true;
            lblSent.Font = new Font("Segoe UI", 15F);
            lblSent.ForeColor = SystemColors.Control;
            lblSent.Location = new Point(76, 737);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 7;
            lblSent.Text = "Sent Count: 0";
            // 
            // lvSent
            // 
            lvSent.Location = new Point(76, 768);
            lvSent.Name = "lvSent";
            lvSent.Size = new Size(647, 312);
            lvSent.TabIndex = 6;
            lvSent.UseCompatibleStateImageBehavior = false;
            lvSent.View = View.List;
            // 
            // lvReceived
            // 
            lvReceived.Location = new Point(76, 403);
            lvReceived.Name = "lvReceived";
            lvReceived.Size = new Size(647, 312);
            lvReceived.TabIndex = 5;
            lvReceived.UseCompatibleStateImageBehavior = false;
            lvReceived.View = View.List;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(99, 114);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(183, 56);
            btnConnect.TabIndex = 13;
            btnConnect.Text = "Start Connecting";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(99, 209);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(183, 56);
            btnDisconnect.TabIndex = 12;
            btnDisconnect.Text = "Stop Connection";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // lblPing
            // 
            lblPing.AutoSize = true;
            lblPing.Font = new Font("Segoe UI", 15F);
            lblPing.ForeColor = SystemColors.Control;
            lblPing.Location = new Point(325, 22);
            lblPing.Name = "lblPing";
            lblPing.Size = new Size(60, 28);
            lblPing.TabIndex = 11;
            lblPing.Text = "Ping: ";
            // 
            // lvConnections
            // 
            lvConnections.Location = new Point(325, 53);
            lvConnections.Name = "lvConnections";
            lvConnections.Size = new Size(435, 312);
            lvConnections.TabIndex = 10;
            lvConnections.UseCompatibleStateImageBehavior = false;
            lvConnections.View = View.List;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 21, 23);
            ClientSize = new Size(1097, 1061);
            Controls.Add(btnConnect);
            Controls.Add(btnDisconnect);
            Controls.Add(lblPing);
            Controls.Add(lvConnections);
            Controls.Add(lblReceived);
            Controls.Add(lblSent);
            Controls.Add(lvSent);
            Controls.Add(lvReceived);
            Name = "Client";
            Text = "Client";
            Load += Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReceived;
        private Label lblSent;
        private NoHScrollListView lvSent;
        private NoHScrollListView lvReceived;
        private Button btnConnect;
        private Button btnDisconnect;
        private Label lblPing;
        private NoHScrollListView lvConnections;
    }
}