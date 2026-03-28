namespace Tcp.Demo
{
    partial class Server
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
            lblReceived = new Label();
            lvReceived = new NoHScrollListView();
            lblSent = new Label();
            lvSent = new NoHScrollListView();
            btnStop = new Button();
            btnStart = new Button();
            lvClients = new NoHScrollListView();
            lblConnectedCount = new Label();
            lvConnectedClients = new NoHScrollListView();
            SuspendLayout();
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.Font = new Font("Segoe UI", 15F);
            lblReceived.ForeColor = SystemColors.Control;
            lblReceived.Location = new Point(66, 342);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(167, 28);
            lblReceived.TabIndex = 8;
            lblReceived.Text = "Received Count: 0";
            // 
            // lvReceived
            // 
            lvReceived.Location = new Point(66, 373);
            lvReceived.Name = "lvReceived";
            lvReceived.Size = new Size(659, 312);
            lvReceived.TabIndex = 7;
            lvReceived.UseCompatibleStateImageBehavior = false;
            lvReceived.View = View.List;
            // 
            // lblSent
            // 
            lblSent.AutoSize = true;
            lblSent.Font = new Font("Segoe UI", 15F);
            lblSent.ForeColor = SystemColors.Control;
            lblSent.Location = new Point(66, 688);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 10;
            lblSent.Text = "Sent Count: 0";
            // 
            // lvSent
            // 
            lvSent.Location = new Point(66, 719);
            lvSent.Name = "lvSent";
            lvSent.Size = new Size(659, 312);
            lvSent.TabIndex = 9;
            lvSent.UseCompatibleStateImageBehavior = false;
            lvSent.View = View.List;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(66, 226);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(183, 56);
            btnStop.TabIndex = 13;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(66, 90);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(183, 56);
            btnStart.TabIndex = 12;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lvClients
            // 
            lvClients.Location = new Point(602, 31);
            lvClients.Name = "lvClients";
            lvClients.Size = new Size(493, 312);
            lvClients.TabIndex = 11;
            lvClients.UseCompatibleStateImageBehavior = false;
            lvClients.View = View.List;
            // 
            // lblConnectedCount
            // 
            lblConnectedCount.Location = new Point(0, 0);
            lblConnectedCount.Name = "lblConnectedCount";
            lblConnectedCount.Size = new Size(100, 23);
            lblConnectedCount.TabIndex = 14;
            // 
            // lvConnectedClients
            // 
            lvConnectedClients.Location = new Point(217, 65);
            lvConnectedClients.Name = "lvConnectedClients";
            lvConnectedClients.Size = new Size(404, 232);
            lvConnectedClients.TabIndex = 15;
            lvConnectedClients.UseCompatibleStateImageBehavior = false;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 21, 23);
            ClientSize = new Size(1107, 1061);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lvClients);
            Controls.Add(lblConnectedCount);
            Controls.Add(lvConnectedClients);
            Controls.Add(lblSent);
            Controls.Add(lvSent);
            Controls.Add(lblReceived);
            Controls.Add(lvReceived);
            Name = "Server";
            Text = " Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReceived;
        private NoHScrollListView lvReceived;
        private Label lblSent;
        private NoHScrollListView lvSent;
        private Button btnStop;
        private Button btnStart;
        private NoHScrollListView lvClients;
        private Label lblConnectedCount;
        private NoHScrollListView lvConnectedClients;
    }
}
