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
            lvReceived = new ListView();
            lblSent = new Label();
            lvSent = new ListView();
            SuspendLayout();
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.Font = new Font("Segoe UI", 15F);
            lblReceived.ForeColor = SystemColors.Control;
            lblReceived.Location = new Point(66, 58);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(167, 28);
            lblReceived.TabIndex = 8;
            lblReceived.Text = "Received Count: 0";
            // 
            // lvReceived
            // 
            lvReceived.Location = new Point(66, 89);
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
            lblSent.Location = new Point(66, 460);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 10;
            lblSent.Text = "Sent Count: 0";
            // 
            // lvSent
            // 
            lvSent.Location = new Point(66, 491);
            lvSent.Name = "lvSent";
            lvSent.Size = new Size(659, 312);
            lvSent.TabIndex = 9;
            lvSent.UseCompatibleStateImageBehavior = false;
            lvSent.View = View.List;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 21, 23);
            ClientSize = new Size(800, 954);
            Controls.Add(lblSent);
            Controls.Add(lvSent);
            Controls.Add(lblReceived);
            Controls.Add(lvReceived);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReceived;
        private ListView lvReceived;
        private Label lblSent;
        private ListView lvSent;
    }
}
