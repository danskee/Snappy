﻿/*
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
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Snappy
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO CI);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public Rectangle bounds;
        private bool allowVisible;
        public SoundPlayer camerasound;
        public bool CaptureMouseCursor = false;
        public bool CopyScreenshotsToClipboard;
        private const Int32 DI_NORMAL = 0x0003;
        private const Int32 CURSOR_SHOWING = 0x0001;
        AboutDialog AboutDialog = new AboutDialog();
        LicenseAgreementForm LicenseAgreementForm = new LicenseAgreementForm();
        public RegistryKey Settings = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Snappy", true);
        public RegistryKey Startup = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

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

        public MainForm()
        {
            InitializeComponent();

            // Copyright License
            if (Settings.GetValue("LicenseAccepted") != null)
            {
            }
            else
            {
                Settings.SetValue("LicenseAccepted", "False");
            }

            if (Settings.GetValue("LicenseAccepted").ToString() == "False")
            {
                LicenseAgreementForm.ShowDialog(this);
            }

            // Hotkey1
            if (Settings.GetValue("Hotkey1") != null)
            {
                Hotkey1.Text = Settings.GetValue("Hotkey1").ToString();
            }
            else
            {
                Settings.SetValue("Hotkey1", "Control + F5", RegistryValueKind.String);
            }

            // Hotkey2
            if (Settings.GetValue("Hotkey2") != null)
            {
                Hotkey2.Text = Settings.GetValue("Hotkey2").ToString();
            }
            else
            {
                Settings.SetValue("Hotkey2", "Control + F6", RegistryValueKind.String);
            }

            // Hotkey3
            if (Settings.GetValue("Hotkey3") != null)
            {
                Hotkey3.Text = Settings.GetValue("Hotkey3").ToString();
            }
            else
            {
                Settings.SetValue("Hotkey3", "Control + F7", RegistryValueKind.String);
            }

            // Hotkey1Enabled
            if (Settings.GetValue("Hotkey1Enabled") != null)
            {
                if (Settings.GetValue("Hotkey1Enabled").ToString() == "True")
                {
                    CheckBox1.Checked = true;
                    Hotkey1.Enabled = true;
                }
                else if (Settings.GetValue("Hotkey1Enabled").ToString() == "False")
                {
                    CheckBox1.Checked = false;
                    Hotkey1.Enabled = false;
                }
            }
            else
            {
                Settings.SetValue("Hotkey1Enabled", "True", RegistryValueKind.String);
            }

            // Hotkey2Enabled
            if (Settings.GetValue("Hotkey2Enabled") != null)
            {
                if (Settings.GetValue("Hotkey2Enabled").ToString() == "True")
                {
                    CheckBox2.Checked = true;
                    Hotkey2.Enabled = true;
                }
                else if (Settings.GetValue("Hotkey2Enabled").ToString() == "False")
                {
                    CheckBox2.Checked = false;
                    Hotkey2.Enabled = false;
                }
            }
            else
            {
                Settings.SetValue("Hotkey2Enabled", "True", RegistryValueKind.String);
            }

            // Hotkey3Enabled
            if (Settings.GetValue("Hotkey3Enabled") != null)
            {
                if (Settings.GetValue("Hotkey3Enabled").ToString() == "True")
                {
                    CheckBox3.Checked = true;
                    Hotkey3.Enabled = true;
                }
                else if (Settings.GetValue("Hotkey3Enabled").ToString() == "False")
                {
                    CheckBox3.Checked = false;
                    Hotkey3.Enabled = false;
                }
            }
            else
            {
                Settings.SetValue("Hotkey3Enabled", "True", RegistryValueKind.String);
            }

            // Capture mouse cursor
            if (Settings.GetValue("CaptureMouseCursor") != null)
            {
                if (Settings.GetValue("CaptureMouseCursor").ToString() == "True")
                {
                    CaptureMouseCursor = true;
                    CheckBoxCaptureMouseCursor.Checked = true;
                }
                else if (Settings.GetValue("CaptureMouseCursor").ToString() == "False")
                {
                    CaptureMouseCursor = false;
                    CheckBoxCaptureMouseCursor.Checked = false;
                }
            }
            else
            {
                CaptureMouseCursor = false;
                Settings.SetValue("CaptureMouseCursor", "False", RegistryValueKind.String);
            }

            // Copy screenshots to clipboard
            if (Settings.GetValue("CopyScreenshotsToClipboard") != null)
            {
                if (Settings.GetValue("CopyScreenshotsToClipboard").ToString() == "True")
                {
                    CopyScreenshotsToClipboard = true;
                    CheckBoxCopyScreenshotsToClipboard.Checked = true;
                    TextBoxOutputPath.Enabled = false;
                    ButtonBrowse.Enabled = false;
                }
                else if (Settings.GetValue("CopyScreenshotsToClipboard").ToString() == "False")
                {
                    CopyScreenshotsToClipboard = false;
                    CheckBoxCopyScreenshotsToClipboard.Checked = false;
                    TextBoxOutputPath.Enabled = true;
                    ButtonBrowse.Enabled = true;
                }
            }
            else
            {
                CopyScreenshotsToClipboard = false;
                Settings.SetValue("CopyScreenshotsToClipboard", "True", RegistryValueKind.String);
            }

            // Output path
            if (Settings.GetValue("OutputPath") != null)
            {
                TextBoxOutputPath.Text = Settings.GetValue("OutputPath").ToString().Replace("\"", "");
            }
            else
            {
                Settings.SetValue("OutputPath", "C:\\", RegistryValueKind.String);
            }

            // Start minimized
            if (Settings.GetValue("StartMinimized") != null)
            {
                if (Settings.GetValue("StartMinimized").ToString() == "True")
                {
                    Minimize();
                    CheckBoxStartMinimized.Checked = true;
                }
                else if (Settings.GetValue("StartMinimized").ToString() == "False")
                {
                    Maximize();
                    CheckBoxStartMinimized.Checked = false;
                }
            }
            else
            {
                Maximize();
                Settings.SetValue("StartMinimized", "False", RegistryValueKind.String);
            }

            // Start Snappy on system startup
            if (Settings.GetValue("StartSnappyOnSystemStartup") != null)
            {
                if (Settings.GetValue("StartSnappyOnSystemStartup").ToString() == "True")
                {
                    CheckBoxStartSnappyOnSystemStartup.Checked = true;
                }
                else if (Settings.GetValue("StartSnappyOnSystemStartup").ToString() == "False")
                {
                    CheckBoxStartSnappyOnSystemStartup.Checked = false;
                }
            }
            else
            {
                Settings.SetValue("StartSnappyOnSystemStartup", "False", RegistryValueKind.String);
            }

            RegisterHotkey();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            camerasound = new SoundPlayer(@"camera-shutter-click-03.wav");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Maximized == this.WindowState)
            {
                Maximize();
            }
        }

        private void SystemTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Maximize();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
        }

        private void MainMenuExit_Click(object sender, EventArgs e)
        {
            KillApp();
        }

        private void MainMenuAbout_Click(object sender, EventArgs e)
        {
            AboutDialog.ShowDialog(this);
        }

        private void ContextMenuStripExit_Click(object sender, EventArgs e)
        {
            KillApp();
        }

        private void Hotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode.ToString() == "ShiftKey")
                {
                }
                else
                {
                    Hotkey1.Text = "Shift + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode.ToString() == "ControlKey")
                {
                }
                else
                {
                    Hotkey1.Text = "Control + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Alt)
            {
                if (e.KeyCode.ToString() == "Menu")
                {
                }
                else
                {
                    Hotkey1.Text = "Alt + " + e.KeyCode.ToString();
                }
            }
            else
            {
                Hotkey1.Text = e.KeyCode.ToString();
            }

            Settings.SetValue("Hotkey1", Hotkey1.Text, RegistryValueKind.String);
            RegisterHotkey();
        }

        private void Hotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode.ToString() == "ShiftKey")
                {
                }
                else
                {
                    Hotkey2.Text = "Shift + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode.ToString() == "ControlKey")
                {
                }
                else
                {
                    Hotkey2.Text = "Control + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Alt)
            {
                if (e.KeyCode.ToString() == "Menu")
                {
                }
                else
                {
                    Hotkey2.Text = "Alt + " + e.KeyCode.ToString();
                }
            }
            else
            {
                Hotkey2.Text = e.KeyCode.ToString();
            }

            Settings.SetValue("Hotkey2", Hotkey2.Text, RegistryValueKind.String);
            RegisterHotkey();
        }

        private void Hotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode.ToString() == "ShiftKey")
                {
                }
                else
                {
                    Hotkey3.Text = "Shift + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode.ToString() == "ControlKey")
                {
                }
                else
                {
                    Hotkey3.Text = "Control + " + e.KeyCode.ToString();
                }
            }
            else if (Control.ModifierKeys == Keys.Alt)
            {
                if (e.KeyCode.ToString() == "Menu")
                {
                }
                else
                {
                    Hotkey3.Text = "Alt + " + e.KeyCode.ToString();
                }
            }
            else
            {
                Hotkey3.Text = e.KeyCode.ToString();
            }

            Settings.SetValue("Hotkey3", Hotkey3.Text, RegistryValueKind.String);
            RegisterHotkey();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                Settings.SetValue("Hotkey1Enabled", "True", RegistryValueKind.String);
                Hotkey1.Enabled = true;
                RegisterHotkey();
            }
            else if (CheckBox1.Checked == false)
            {
                Settings.SetValue("Hotkey1Enabled", "False", RegistryValueKind.String);
                Hotkey1.Enabled = false;
                UnregisterHotKey(this.Handle, 1);
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                Settings.SetValue("Hotkey2Enabled", "True", RegistryValueKind.String);
                Hotkey2.Enabled = true;
                RegisterHotkey();
            }
            else if (CheckBox2.Checked == false)
            {
                Settings.SetValue("Hotkey2Enabled", "False", RegistryValueKind.String);
                Hotkey2.Enabled = false;
                UnregisterHotKey(this.Handle, 2);
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == true)
            {
                Settings.SetValue("Hotkey3Enabled", "True", RegistryValueKind.String);
                Hotkey3.Enabled = true;
                RegisterHotkey();
            }
            else if (CheckBox3.Checked == false)
            {
                Settings.SetValue("Hotkey3Enabled", "False", RegistryValueKind.String);
                Hotkey3.Enabled = false;
                UnregisterHotKey(this.Handle, 3);
            }
        }

        private void CheckBoxCaptureMouseCursor_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxCaptureMouseCursor.Checked == true)
            {
                Settings.SetValue("CaptureMouseCursor", "True", RegistryValueKind.String);
                CaptureMouseCursor = true;
            }
            else if (CheckBoxCaptureMouseCursor.Checked == false)
            {
                Settings.SetValue("CaptureMouseCursor", "False", RegistryValueKind.String);
                CaptureMouseCursor = false;
            }
        }

        private void CheckBoxCopyScreenshotsToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxCopyScreenshotsToClipboard.Checked == true)
            {
                Settings.SetValue("CopyScreenshotsToClipboard", "True", RegistryValueKind.String);
                CopyScreenshotsToClipboard = true;
                TextBoxOutputPath.Enabled = false;
                ButtonBrowse.Enabled = false;
            }
            else if (CheckBoxCopyScreenshotsToClipboard.Checked == false)
            {
                Settings.SetValue("CopyScreenshotsToClipboard", "False", RegistryValueKind.String);
                CopyScreenshotsToClipboard = false;
                TextBoxOutputPath.Enabled = true;
                ButtonBrowse.Enabled = true;
            }
        }

        private void CheckBoxStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxStartMinimized.Checked == true)
            {
                Settings.SetValue("StartMinimized", "True", RegistryValueKind.String);
            }
            else if (CheckBoxStartMinimized.Checked == false)
            {
                Settings.SetValue("StartMinimized", "False", RegistryValueKind.String);
            }
        }

        private void CheckBoxStartSnappyOnSystemStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxStartSnappyOnSystemStartup.Checked == true)
            {
                Startup.SetValue("Snappy", "\"" + Application.ExecutablePath + "\"", RegistryValueKind.String);
                Settings.SetValue("StartSnappyOnSystemStartup", "True", RegistryValueKind.String);
            }
            else if (CheckBoxStartSnappyOnSystemStartup.Checked == false)
            {
                if (Startup.GetValue("Snappy") != null)
                {
                    Startup.DeleteValue("Snappy");
                }
                Settings.SetValue("StartSnappyOnSystemStartup", "False", RegistryValueKind.String);
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TextBoxOutputPath.Text = fbd.SelectedPath;
                Settings.SetValue("OutputPath", "\"" + fbd.SelectedPath + "\"");
            }
        }

        private void ButtonMinimizeSnappyToSystemTray_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        public void Minimize()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        public void Maximize()
        {
            this.allowVisible = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        void RegisterHotkey()
        {
            Keys a;

            // Hotkey1
            {
                Enum.TryParse(Hotkey1.Text.Replace("Shift + ", "").Replace("Control + ", "").Replace("Alt + ", ""), out a);

                if (Hotkey1.Text.Contains("Shift"))
                {
                    UnregisterHotKey(this.Handle, 1);
                    RegisterHotKey(this.Handle, 1, (int)4, a.GetHashCode());
                }
                else if (Hotkey1.Text.Contains("Control"))
                {
                    UnregisterHotKey(this.Handle, 1);
                    RegisterHotKey(this.Handle, 1, (int)2, a.GetHashCode());
                }
                else if (Hotkey1.Text.Contains("Alt"))
                {
                    UnregisterHotKey(this.Handle, 1);
                    RegisterHotKey(this.Handle, 1, (int)1, a.GetHashCode());
                }
                else
                {
                    UnregisterHotKey(this.Handle, 1);
                    RegisterHotKey(this.Handle, 1, (int)0, a.GetHashCode());
                }
            }

            // Hotkey 2
            {
                Enum.TryParse(Hotkey2.Text.Replace("Shift + ", "").Replace("Control + ", "").Replace("Alt + ", ""), out a);

                if (Hotkey2.Text.Contains("Shift"))
                {
                    UnregisterHotKey(this.Handle, 2);
                    RegisterHotKey(this.Handle, 2, (int)4, a.GetHashCode());
                }
                else if (Hotkey2.Text.Contains("Control"))
                {
                    UnregisterHotKey(this.Handle, 2);
                    RegisterHotKey(this.Handle, 2, (int)2, a.GetHashCode());
                }
                else if (Hotkey2.Text.Contains("Alt"))
                {
                    UnregisterHotKey(this.Handle, 2);
                    RegisterHotKey(this.Handle, 2, (int)1, a.GetHashCode());
                }
                else
                {
                    UnregisterHotKey(this.Handle, 2);
                    RegisterHotKey(this.Handle, 2, (int)0, a.GetHashCode());
                }
            }

            // Hotkey 3
            {
                Enum.TryParse(Hotkey3.Text.Replace("Shift + ", "").Replace("Control + ", "").Replace("Alt + ", ""), out a);

                if (Hotkey3.Text.Contains("Shift"))
                {
                    UnregisterHotKey(this.Handle, 3);
                    RegisterHotKey(this.Handle, 3, (int)4, a.GetHashCode());
                }
                else if (Hotkey3.Text.Contains("Control"))
                {
                    UnregisterHotKey(this.Handle, 3);
                    RegisterHotKey(this.Handle, 3, (int)2, a.GetHashCode());
                }
                else if (Hotkey3.Text.Contains("Alt"))
                {
                    UnregisterHotKey(this.Handle, 3);
                    RegisterHotKey(this.Handle, 3, (int)1, a.GetHashCode());
                }
                else
                {
                    UnregisterHotKey(this.Handle, 3);
                    RegisterHotKey(this.Handle, 3, (int)0, a.GetHashCode());
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 1)
                {
                    Minimize();
                    CropForm CropForm = new CropForm();
                    CropForm.RectangleDrawn = false;
                    CropForm.Timer.Enabled = true;
                    CropForm.Show();

                    if (CaptureMouseCursor == true)
                    {
                        CropForm.CaptureMouseCursor = true;
                    }
                    else if (CaptureMouseCursor == false)
                    {
                        CropForm.CaptureMouseCursor = false;
                    }

                    if (CopyScreenshotsToClipboard == true)
                    {
                        CropForm.CopyScreenshotsToClipboard = true;
                    }
                    else if (CopyScreenshotsToClipboard == false)
                    {
                        CropForm.CopyScreenshotsToClipboard = false;
                    }

                    CropForm.outputpath = TextBoxOutputPath.Text;
                }
                else if (m.WParam.ToInt32() == 2)
                {
                    Bitmap ss = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

                    try
                    {
                        Graphics g = Graphics.FromImage(ss);
                        System.Threading.Thread.Sleep(250);
                        g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

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
                            ss.Save(TextBoxOutputPath.Text + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                            camerasound.Play();
                        }
                        catch
                        {
                            MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (m.WParam.ToInt32() == 3)
                {
                    var rect = new RECT();
                    GetWindowRect(GetForegroundWindow(), out rect);
                    Rectangle bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

                    Bitmap ss = new Bitmap(bounds.Width, bounds.Height);

                    try
                    {
                        Graphics g = Graphics.FromImage(ss);
                        System.Threading.Thread.Sleep(250);
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

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
                    else if(CopyScreenshotsToClipboard == false)
                    {
                        try
                        {
                            ss.Save(TextBoxOutputPath.Text + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                            camerasound.Play();
                        }
                        catch
                        {
                            MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        void KillApp()
        {
            Application.Exit();
            this.Close();
        }
    }
}
