namespace Tcp.Demo
{
    internal static class Theme
    {
        public static readonly Color Background  = Color.FromArgb(13,  15,  20);
        public static readonly Color Surface     = Color.FromArgb(22,  26,  36);
        public static readonly Color Accent      = Color.FromArgb(88,  101, 242);
        public static readonly Color AccentHover = Color.FromArgb(108, 122, 255);
        public static readonly Color Danger      = Color.FromArgb(210, 65,  65);
        public static readonly Color DangerHover = Color.FromArgb(230, 85,  85);
        public static readonly Color TextPrimary = Color.FromArgb(215, 220, 235);

        private static readonly Color RowAlt = Color.FromArgb(28, 33, 46);

        public static void StyleListView(ListView lv)
        {
            lv.SmallImageList = new ImageList { ImageSize = new Size(1, 28) };

            lv.Columns.Add(new ColumnHeader());
            lv.Resize += (s, _) => { if (lv.Columns.Count > 0) lv.Columns[0].Width = lv.ClientSize.Width; };

            lv.DrawColumnHeader += (s, e) => e.DrawDefault = true;
            lv.DrawItem += (s, e) => { };
            lv.DrawSubItem += (s, e) =>
            {
                Color bg = e.ItemIndex % 2 == 0 ? Surface : RowAlt;

                using var bgBrush = new SolidBrush(bg);
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

                var textRect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y, e.Bounds.Width - 10, e.Bounds.Height);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv.Font, textRect, TextPrimary,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            };
        }

        public static void StyleButton(Button btn, Color backColor, Color hoverColor)
        {
            btn.MouseEnter += (_, _) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, _) => btn.BackColor = backColor;
        }

        public static void FitListViewColumns(params ListView[] listViews)
        {
            foreach (var lv in listViews)
                if (lv.Columns.Count > 0)
                    lv.Columns[0].Width = lv.ClientSize.Width;
        }
    }
}
