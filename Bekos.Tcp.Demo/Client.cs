using Bekos.Tcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Tcp.Demo
{
    public partial class Client : Form
    {
        public Client()
        {
            BackColor = Theme.Background;
            DoubleBuffered = true;
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            ApplyTheme();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // WM_ERASEBKGND
            {
                using var g = Graphics.FromHdc(m.WParam);
                g.Clear(BackColor);
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ArrangeControls();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (IsHandleCreated) ArrangeControls();
        }

        private void ApplyTheme()
        {
            Theme.StyleListView(lvConnections);
            Theme.StyleListView(lvReceived);
            Theme.StyleListView(lvSent);

            Theme.StyleButton(btnConnect, Theme.Accent, Theme.AccentHover);
            Theme.StyleButton(btnDisconnect, Theme.Danger, Theme.DangerHover);
        }

        private void ArrangeControls()
        {
            const int pad = 32;
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            int innerW = w - pad * 2;
            int sectionH = (h - pad * 4) / 3;

            int s1Y = pad;
            int s2Y = s1Y + sectionH + pad;
            int s3Y = s2Y + sectionH + pad;

            int btnColW = innerW / 3;
            int listColW = innerW - btnColW - pad;
            int listX = pad + btnColW + pad;

            // Section 1 — ping + buttons left, listview right
            int labelH = lblPing.PreferredHeight;
            int btnsAreaH = sectionH - labelH - pad / 2;
            int btnH = (btnsAreaH - pad / 2) / 2;

            lblPing.SetBounds(pad, s1Y, btnColW, labelH);
            btnConnect.SetBounds(pad, s1Y + labelH + pad / 2, btnColW, btnH);
            btnDisconnect.SetBounds(pad, s1Y + labelH + pad / 2 + btnH + pad / 2, btnColW, btnH);
            lvConnections.SetBounds(listX, s1Y, listColW, sectionH);

            // Section 2 — received
            labelH = lblReceived.PreferredHeight;
            lblReceived.SetBounds(pad, s2Y, innerW, labelH);
            lvReceived.SetBounds(pad, s2Y + labelH + pad / 2, innerW, sectionH - labelH - pad / 2);

            // Section 3 — sent
            labelH = lblSent.PreferredHeight;
            lblSent.SetBounds(pad, s3Y, innerW, labelH);
            lvSent.SetBounds(pad, s3Y + labelH + pad / 2, innerW, sectionH - labelH - pad / 2);

            Theme.FitListViewColumns(lvConnections, lvReceived, lvSent);
        }


        TcpClient client = new(18002) { AutoReconnect = true };
        private void Client_Load(object sender, EventArgs e)
        {
            TcpEncryptionOptions options = new TcpEncryptionOptions
            {
                Password = "test",
                UseIV = true
            };
            client.ConfigureEncryption(options);
            client.EncryptMessageContent = true;

            client.Connected += Client_Connected;
            client.Disconnected += Client_Disconnected;

            client.MessageReceived += Client_MessageReceived;

            client.LatencyUpdated += (object? sender, LatencyUpdatedEventArgs e) => lblPing.Text = "Ping: " + e.Latency + " ms";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            lvConnections.Items.Add("Begin Try Connecting...");
            client.BeginTryUntilConnect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Stop();
        }

        private void Client_Connected(object? sender, EventArgs e)
        {
            lvConnections.Items.Add("Connected");
        }

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            lvConnections.Items.Add("Disconnected");
        }


        int receivedCount = 0;
        int sentCount = 0;
        private void Client_MessageReceived(object? sender, MessageReceivedEventArgs<TcpMessage> e)
        {
            var message = e.Message;

            receivedCount++;
            lblReceived.Text = "Received Count: " + receivedCount;

            lvReceived.Items.Add(message.Text + " - Received   ");

            client.SendMessage(message!);

            sentCount++;
            lblSent.Text = "Sent Count: " + sentCount;

            lvSent.Items.Add(message.Text + " - ReSended");
        }


    }
}
