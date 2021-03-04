/*
   Snappy

   Copyright (C) 2021 Danske

   This file is part of Snappy

   Snappy is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   Snappy is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with Snappy. If not, see <https://www.gnu.org/licenses/>.

   Credit: https://medium.com/@nishancw/c-screenshot-utility-to-capture-a-portion-of-the-screen-489ddceeee49
*/

using System;
using System.Media;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Snappy
{
    public partial class CropForm : Form
    {
        [DllImport("User32.dll", SetLastError = true)]
        static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO CI);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public string outputpath;
        public bool CaptureMouseCursor;
        public const int HTCAPTION = 0x2;
        public bool playacamerashuttersound;
        public bool startedminimized = false;
        public bool CopyScreenshotsToClipboard;
        private const Int32 DI_NORMAL = 0x0003;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        private const Int32 CURSOR_SHOWING = 0x0001;

        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        public CropForm()
        {
            InitializeComponent();
            Process[] processes = Process.GetProcessesByName("Snappy");
            SetForegroundWindow(processes[0].MainWindowHandle);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int
                    HTLEFT = 10,
                    HTRIGHT = 11,
                    HTTOP = 12,
                    HTTOPLEFT = 13,
                    HTTOPRIGHT = 14,
                    HTBOTTOM = 15,
                    HTBOTTOMLEFT = 16,
                    HTBOTTOMRIGHT = 17;

        const int _ = 10;

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }
        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }

        private void ButtonCapture_Click(object sender, EventArgs e)
        {
            Rectangle bounds = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Bitmap ss = new Bitmap(bounds.Width, bounds.Height);
            this.Hide();

            try
            {
                Graphics g = Graphics.FromImage(ss);
                System.Threading.Thread.Sleep(250);
                g.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, this.Size);

                switch (CaptureMouseCursor)
                {
                    case true:
                        CURSORINFO CI;
                        CI.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out CI))
                        {
                            if (CI.flags == CURSOR_SHOWING)
                            {
                                var hdc = g.GetHdc();
                                DrawIconEx(hdc, CI.ptScreenPos.x - bounds.X, CI.ptScreenPos.y - bounds.Y, CI.hCursor, 0, 0, 0, IntPtr.Zero, DI_NORMAL);
                                g.ReleaseHdc();
                            }
                        }
                        break;
                }
            }
            catch
            {
                MessageBox.Show("An error occured in the capturing of the screenshot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ss = null;
            }

            switch (playacamerashuttersound)
            {
                case true:
                    SoundPlayer camerasound = new SoundPlayer(@"camera-shutter-click-03.wav");
                    camerasound.Play();
                    break;
            }

            switch (CopyScreenshotsToClipboard)
            {
                case true:
                    Clipboard.SetImage(ss);
                    break;

                case false:
                    try
                    {
                        ss.Save(outputpath + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

            this.Close();

            switch (startedminimized)
            {
                case false:
                    MainForm MainForm = (MainForm)Application.OpenForms["MainForm"];
                    MainForm.resize(true);
                    break;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            switch (startedminimized)
            {
                case false:
                    MainForm MainForm = (MainForm)Application.OpenForms["MainForm"];
                    MainForm.resize(true);
                    break;
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                var cursor = this.PointToClient(Cursor.Position);
                if (TopLeft.Contains(cursor)) m.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) m.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (Top.Contains(cursor)) m.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) m.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) m.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) m.Result = (IntPtr)HTBOTTOM;
            }
        }
    }
}
