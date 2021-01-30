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

        Graphics g;
        public string outputpath;
        public bool CaptureMouseCursor;
        public SoundPlayer camerasound;
        public bool ReadyToDrag = false;
        public ClickAction CurrentAction;
        public bool LeftButtonDown = false;
        public bool RectangleDrawn = false;
        Pen MyPen = new Pen(Color.Black, 1);
        public bool startedminimized = false;
        public Point ClickPoint = new Point();
        public int RectangleWidth = new int();
        public bool CopyScreenshotsToClipboard;
        public int RectangleHeight = new int();
        private const Int32 DI_NORMAL = 0x0003;
        public Point CurrentTopLeft = new Point();
        private const Int32 CURSOR_SHOWING = 0x0001;
        public Point DragClickRelative = new Point();
        public Point CurrentBottomRight = new Point();

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

        public enum ClickAction : int
        {
            Dragging,
            Outside,
            TopSizing,
            BottomSizing,
            LeftSizing,
            TopLeftSizing,
            BottomLeftSizing,
            RightSizing,
            TopRightSizing,
            BottomRightSizing
        }

        public CropForm()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void CropForm_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Snappy");
            SetForegroundWindow(processes[0].MainWindowHandle);
            camerasound = new SoundPlayer(@"camera-shutter-click-03.wav");
        }

        private void CropForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (LeftButtonDown && !RectangleDrawn)
            {
                if (Cursor.Position.X < ClickPoint.X)
                {
                    CurrentTopLeft.X = Cursor.Position.X;
                    CurrentBottomRight.X = ClickPoint.X;
                }
                else
                {
                    CurrentTopLeft.X = ClickPoint.X;
                    CurrentBottomRight.X = Cursor.Position.X;
                }

                if (Cursor.Position.Y < ClickPoint.Y)
                {
                    CurrentTopLeft.Y = Cursor.Position.Y;
                    CurrentBottomRight.Y = ClickPoint.Y;
                }
                else
                {
                    CurrentTopLeft.Y = ClickPoint.Y;
                    CurrentBottomRight.Y = Cursor.Position.Y;
                }

                g.DrawRectangle(MyPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (RectangleDrawn == true)
            {
                Size cs = new Size();
                cs.Height = Cursor.Current.Size.Height;
                cs.Width = Cursor.Current.Size.Width;
                Point StartPoint = new Point(CurrentTopLeft.X, CurrentTopLeft.Y);
                Rectangle bounds = new Rectangle(CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);
                Bitmap ss = new Bitmap(bounds.Width, bounds.Height);

                try
                {
                    Graphics g = Graphics.FromImage(ss);
                    System.Threading.Thread.Sleep(250);
                    g.CopyFromScreen(StartPoint, Point.Empty, bounds.Size);

                    if (CaptureMouseCursor == true)
                    {
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
                    }
                }
                catch
                {
                    MessageBox.Show("An error occured in the capturing of the screenshot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ss = null;
                }

                if (CopyScreenshotsToClipboard == true)
                {
                    Clipboard.SetImage(ss);
                    camerasound.Play();
                }
                else if (CopyScreenshotsToClipboard == false)
                {
                    try
                    {
                        ss.Save(outputpath + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                        camerasound.Play();
                    }
                    catch
                    {
                        MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
                Timer.Enabled = false;

                if (startedminimized == false)
                {
                    MainForm MainForm = (MainForm)Application.OpenForms["MainForm"];
                    MainForm.Maximize();
                }
            }
        }

        private void CropForm_MouseUp(object sender, MouseEventArgs e)
        {
            RectangleDrawn = true;
            LeftButtonDown = false;
        }

        private void CropForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LeftButtonDown = true;
                ClickPoint = new Point(Control.MousePosition.X, Control.MousePosition.Y);

                if (RectangleDrawn)
                {
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    DragClickRelative.X = Cursor.Position.X - CurrentTopLeft.X;
                    DragClickRelative.Y = Cursor.Position.Y - CurrentTopLeft.Y;
                }
            }
        }
    }
}
