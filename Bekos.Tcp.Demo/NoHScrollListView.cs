using System.Runtime.InteropServices;

namespace Tcp.Demo
{
    internal class NoHScrollListView : ListView
    {
        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_NCCALCSIZE   = 0x0083;
            const int WM_SIZE         = 0x0005;
            const int LVM_INSERTITEMW = 0x104D;

            // Hide horizontal scrollbar whenever layout is recalculated
            if ((m.Msg == WM_NCCALCSIZE || m.Msg == WM_SIZE) && IsHandleCreated)
                ShowScrollBar(Handle, 0 /* SB_HORZ */, false);

            // Scroll to last item on insert
            if (m.Msg == LVM_INSERTITEMW && Items.Count > 0)
                Items[^1].EnsureVisible();
        }
    }
}
