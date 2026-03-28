namespace Tcp.Demo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var screen = Screen.PrimaryScreen!.WorkingArea;
            int halfWidth = screen.Width / 2;

            var server = new Server();
            server.StartPosition = FormStartPosition.Manual;
            server.Bounds = new Rectangle(screen.Left, screen.Top, halfWidth, screen.Height);

            var client = new Client();
            client.StartPosition = FormStartPosition.Manual;
            client.Bounds = new Rectangle(screen.Left + halfWidth, screen.Top, halfWidth, screen.Height);

            Application.Run(new MultiFormContext(server, client));
        }
    }


    internal class MultiFormContext : ApplicationContext
    {
        public MultiFormContext(params Form[] forms)
        {
            foreach (var form in forms)
            {
                form.FormClosed += OnFormClosed;
                form.Show();
            }
        }

        private void OnFormClosed(object? sender, FormClosedEventArgs e)
        {
            ExitThread();
        }
    }
}