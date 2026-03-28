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
            lblReceived.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblReceived.ForeColor = Color.FromArgb(110, 120, 150);
            lblReceived.Location = new Point(66, 342);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(167, 28);
            lblReceived.TabIndex = 8;
            lblReceived.Text = "Received Count: 0";
            //
            // lvReceived
            //
            lvReceived.BackColor = Color.FromArgb(22, 26, 36);
            lvReceived.BorderStyle = BorderStyle.None;
            lvReceived.Font = new Font("Segoe UI", 12F);
            lvReceived.ForeColor = Color.FromArgb(215, 220, 235);
            lvReceived.FullRowSelect = true;
            lvReceived.HeaderStyle = ColumnHeaderStyle.None;
            lvReceived.Location = new Point(66, 373);
            lvReceived.Name = "lvReceived";
            lvReceived.OwnerDraw = true;
            lvReceived.Size = new Size(659, 312);
            lvReceived.TabIndex = 7;
            lvReceived.UseCompatibleStateImageBehavior = false;
            lvReceived.View = View.Details;
            //
            // lblSent
            //
            lblSent.AutoSize = true;
            lblSent.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSent.ForeColor = Color.FromArgb(110, 120, 150);
            lblSent.Location = new Point(66, 688);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 10;
            lblSent.Text = "Sent Count: 0";
            //
            // lvSent
            //
            lvSent.BackColor = Color.FromArgb(22, 26, 36);
            lvSent.BorderStyle = BorderStyle.None;
            lvSent.Font = new Font("Segoe UI", 12F);
            lvSent.ForeColor = Color.FromArgb(215, 220, 235);
            lvSent.FullRowSelect = true;
            lvSent.HeaderStyle = ColumnHeaderStyle.None;
            lvSent.Location = new Point(66, 719);
            lvSent.Name = "lvSent";
            lvSent.OwnerDraw = true;
            lvSent.Size = new Size(659, 312);
            lvSent.TabIndex = 9;
            lvSent.UseCompatibleStateImageBehavior = false;
            lvSent.View = View.Details;
            //
            // btnStop
            //
            btnStop.BackColor = Color.FromArgb(210, 65, 65);
            btnStop.Cursor = Cursors.Hand;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(66, 226);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(183, 56);
            btnStop.TabIndex = 13;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            //
            // btnStart
            //
            btnStart.BackColor = Color.FromArgb(88, 101, 242);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(66, 90);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(183, 56);
            btnStart.TabIndex = 12;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            //
            // lvClients
            //
            lvClients.BackColor = Color.FromArgb(22, 26, 36);
            lvClients.BorderStyle = BorderStyle.None;
            lvClients.Font = new Font("Segoe UI", 12F);
            lvClients.ForeColor = Color.FromArgb(215, 220, 235);
            lvClients.FullRowSelect = true;
            lvClients.HeaderStyle = ColumnHeaderStyle.None;
            lvClients.Location = new Point(602, 31);
            lvClients.Name = "lvClients";
            lvClients.OwnerDraw = true;
            lvClients.Size = new Size(493, 312);
            lvClients.TabIndex = 11;
            lvClients.UseCompatibleStateImageBehavior = false;
            lvClients.View = View.Details;
            //
            // lblConnectedCount
            //
            lblConnectedCount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblConnectedCount.ForeColor = Color.FromArgb(110, 120, 150);
            lblConnectedCount.Location = new Point(0, 0);
            lblConnectedCount.Name = "lblConnectedCount";
            lblConnectedCount.Size = new Size(100, 23);
            lblConnectedCount.TabIndex = 14;
            //
            // lvConnectedClients
            //
            lvConnectedClients.BackColor = Color.FromArgb(22, 26, 36);
            lvConnectedClients.BorderStyle = BorderStyle.None;
            lvConnectedClients.Font = new Font("Segoe UI", 12F);
            lvConnectedClients.ForeColor = Color.FromArgb(215, 220, 235);
            lvConnectedClients.FullRowSelect = true;
            lvConnectedClients.HeaderStyle = ColumnHeaderStyle.None;
            lvConnectedClients.Location = new Point(217, 65);
            lvConnectedClients.Name = "lvConnectedClients";
            lvConnectedClients.OwnerDraw = true;
            lvConnectedClients.Size = new Size(404, 232);
            lvConnectedClients.TabIndex = 15;
            lvConnectedClients.UseCompatibleStateImageBehavior = false;
            lvConnectedClients.View = View.Details;
            //
            // Server
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 15, 20);
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
