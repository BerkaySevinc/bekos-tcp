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
            this.lvSent = new ListView();
            lvReceived = new ListView();
            SuspendLayout();
            // 
            // lblReceived
            // 
            lblReceived.AutoSize = true;
            lblReceived.Font = new Font("Segoe UI", 15F);
            lblReceived.ForeColor = SystemColors.Control;
            lblReceived.Location = new Point(63, 66);
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
            lblSent.Location = new Point(63, 474);
            lblSent.Name = "lblSent";
            lblSent.Size = new Size(129, 28);
            lblSent.TabIndex = 7;
            lblSent.Text = "Sent Count: 0";
            // 
            // lvSent
            // 
            this.lvSent.Location = new Point(63, 505);
            this.lvSent.Name = "lvSent";
            this.lvSent.Size = new Size(647, 312);
            this.lvSent.TabIndex = 6;
            this.lvSent.UseCompatibleStateImageBehavior = false;
            this.lvSent.View = View.List;
            // 
            // lvReceived
            // 
            lvReceived.Location = new Point(63, 97);
            lvReceived.Name = "lvReceived";
            lvReceived.Size = new Size(647, 312);
            lvReceived.TabIndex = 5;
            lvReceived.UseCompatibleStateImageBehavior = false;
            lvReceived.View = View.List;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 21, 23);
            ClientSize = new Size(800, 897);
            Controls.Add(lblReceived);
            Controls.Add(lblSent);
            Controls.Add(this.lvSent);
            Controls.Add(lvReceived);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReceived;
        private Label lblSent;
        private ListView lvSent;
        private ListView lvReceived;
    }
}