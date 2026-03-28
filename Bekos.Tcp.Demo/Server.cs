
using Bekos.Tcp;



namespace Tcp.Demo
{
    public partial class Server : Form
    {
        public Server()
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
            Theme.StyleListView(lvClients);
            Theme.StyleListView(lvConnectedClients);
            Theme.StyleListView(lvReceived);
            Theme.StyleListView(lvSent);

            Theme.StyleButton(btnStart, Theme.Accent, Theme.AccentHover);
            Theme.StyleButton(btnStop, Theme.Danger, Theme.DangerHover);
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
            int listsW = innerW - btnColW - pad;
            int listX = pad + btnColW + pad;
            int logW     = (listsW - pad) * 6 / 10;
            int clientsW = listsW - pad - logW;

            // Section 1 — buttons left, two listviews right
            int btnH = (sectionH - pad / 2) / 2;
            btnStart.SetBounds(pad, s1Y, btnColW, btnH);
            btnStop.SetBounds(pad, s1Y + btnH + pad / 2, btnColW, btnH);

            int labelH = lblConnectedCount.PreferredHeight;
            lvClients.SetBounds(listX, s1Y, logW, sectionH);
            lblConnectedCount.SetBounds(listX + logW + pad, s1Y, clientsW, labelH);
            lvConnectedClients.SetBounds(listX + logW + pad, s1Y + labelH + pad / 2, clientsW, sectionH - labelH - pad / 2);

            // Section 2 — received
            labelH = lblReceived.PreferredHeight;
            lblReceived.SetBounds(pad, s2Y, innerW, labelH);
            lvReceived.SetBounds(pad, s2Y + labelH + pad / 2, innerW, sectionH - labelH - pad / 2);

            // Section 3 — sent
            labelH = lblSent.PreferredHeight;
            lblSent.SetBounds(pad, s3Y, innerW, labelH);
            lvSent.SetBounds(pad, s3Y + labelH + pad / 2, innerW, sectionH - labelH - pad / 2);

            Theme.FitListViewColumns(lvClients, lvConnectedClients, lvReceived, lvSent);
        }


        TcpServer server = new(18002);
        private void Server_Load(object sender, EventArgs e)
        {
            lblConnectedCount.Text = "Connected: 0";
            TcpEncryptionOptions options = new TcpEncryptionOptions
            {
                Password = "test",
                UseIV = true,
            };
            server.ConfigureEncryption(options);
            server.EncryptMessageContent = true;

            server.ClientConnected += Server_ClientConnected;
            server.ClientDisconnected += Server_ClientDisconnected;

            server.MessageReceived += Server_MessageReceived;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            lvClients.Items.Add("Server Started...");
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();
            lvClients.Items.Add("Server Stopped.");
        }

        private void Server_ClientConnected(object? sender, ClientConnectedEventArgs e)
        {
            lvClients.Items.Add("Client Connected - " + e.Client.Address + " : " + e.Client.Port);
            lvConnectedClients.Items.Add(e.Client.Address + " : " + e.Client.Port);
            lblConnectedCount.Text = "Connected: " + server.Clients.Count;

            if (server.Clients.Count is 1)
                Task.Run(SendData);
        }

        private void Server_ClientDisconnected(object? sender, ClientDisconnectedEventArgs e)
        {
            lvClients.Items.Add("Client Disconnected - " + e.Client.Address + " : " + e.Client.Port);

            foreach (ListViewItem item in lvConnectedClients.Items)
            {
                if (item.Text == e.Client.Address + " : " + e.Client.Port)
                {
                    lvConnectedClients.Items.Remove(item);
                    break;
                }
            }

            lblConnectedCount.Text = "Connected: " + server.Clients.Count;
        }


        int sentCount = 0;
        private void SendData()
        {
            var rnd = new Random();
            while (server.Clients.Count > 0)
            {
                int num = rnd.Next(10001, 99999);
                var message = new TcpMessage(num.ToString());

                server.SendMessageToAll(message);

                sentCount++;
                lblSent.Text = "Sent Count: " + sentCount;

                lvSent.Items.Add(message.Text + " - Sent            ");

                Thread.Sleep(1000);
            }
        }


        int receivedCount = 0;
        private void Server_MessageReceived(object? sender, MessageReceivedEventArgs<TcpMessage> e)
        {
            var message = e.Message;

            receivedCount++;
            lblReceived.Text = "Received Count: " + receivedCount;

            lvReceived.Items.Add(message.Text + " - ReReceived");
        }
    }
}
