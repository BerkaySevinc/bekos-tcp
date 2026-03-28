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
            lblReceived.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblReceived.ForeColor = Color.FromArgb(110, 120, 150);
            lblReceived.Location = new Point(76, 372);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(167, 28);
            lblReceived.TabIndex = 8;
            lblReceived.Text = "Received Count: 0";
            //
            // lblSent
            //
            lblSent.AutoSize = true;
            lblSent.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSent.ForeColor = Color.FromArgb(110, 120, 150);
            lblSent.Location = new Point(76, 737);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 7;
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
            lvSent.Location = new Point(76, 768);
            lvSent.Name = "lvSent";
            lvSent.OwnerDraw = true;
            lvSent.Size = new Size(647, 312);
            lvSent.TabIndex = 6;
            lvSent.UseCompatibleStateImageBehavior = false;
            lvSent.View = View.Details;
            //
            // lvReceived
            //
            lvReceived.BackColor = Color.FromArgb(22, 26, 36);
            lvReceived.BorderStyle = BorderStyle.None;
            lvReceived.Font = new Font("Segoe UI", 12F);
            lvReceived.ForeColor = Color.FromArgb(215, 220, 235);
            lvReceived.FullRowSelect = true;
            lvReceived.HeaderStyle = ColumnHeaderStyle.None;
            lvReceived.Location = new Point(76, 403);
            lvReceived.Name = "lvReceived";
            lvReceived.OwnerDraw = true;
            lvReceived.Size = new Size(647, 312);
            lvReceived.TabIndex = 5;
            lvReceived.UseCompatibleStateImageBehavior = false;
            lvReceived.View = View.Details;
            //
            // btnConnect
            //
            btnConnect.BackColor = Color.FromArgb(88, 101, 242);
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(99, 114);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(183, 56);
            btnConnect.TabIndex = 13;
            btnConnect.Text = "Start Connecting";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            //
            // btnDisconnect
            //
            btnDisconnect.BackColor = Color.FromArgb(210, 65, 65);
            btnDisconnect.Cursor = Cursors.Hand;
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.FlatAppearance.BorderSize = 0;
            btnDisconnect.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDisconnect.ForeColor = Color.White;
            btnDisconnect.Location = new Point(99, 209);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(183, 56);
            btnDisconnect.TabIndex = 12;
            btnDisconnect.Text = "Stop Connection";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += btnDisconnect_Click;
            //
            // lblPing
            //
            lblPing.AutoSize = true;
            lblPing.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPing.ForeColor = Color.FromArgb(110, 120, 150);
            lblPing.Location = new Point(325, 22);
            lblPing.Name = "lblPing";
            lblPing.Size = new Size(60, 28);
            lblPing.TabIndex = 11;
            lblPing.Text = "Ping: ";
            //
            // lvConnections
            //
            lvConnections.BackColor = Color.FromArgb(22, 26, 36);
            lvConnections.BorderStyle = BorderStyle.None;
            lvConnections.Font = new Font("Segoe UI", 12F);
            lvConnections.ForeColor = Color.FromArgb(215, 220, 235);
            lvConnections.FullRowSelect = true;
            lvConnections.HeaderStyle = ColumnHeaderStyle.None;
            lvConnections.Location = new Point(325, 53);
            lvConnections.Name = "lvConnections";
            lvConnections.OwnerDraw = true;
            lvConnections.Size = new Size(435, 312);
            lvConnections.TabIndex = 10;
            lvConnections.UseCompatibleStateImageBehavior = false;
            lvConnections.View = View.Details;
            //
            // Client
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 15, 20);
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
