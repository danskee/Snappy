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
using System.Net;
using System.IO;
using System.Media;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;

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
        public string Folder = "";
        public string newestver = "";
        public bool startedminimized;
        WebClient wc = new WebClient();
        public bool CaptureMouseCursor;
        public bool playacamerashuttersound;
        public bool CopyScreenshotsToClipboard;
        private const Int32 DI_NORMAL = 0x0003;
        private const Int32 CURSOR_SHOWING = 0x0001;
        AboutDialog AboutDialog = new AboutDialog("1.0.5");
        LicenseAgreementDialog LicenseAgreementDialog = new LicenseAgreementDialog();
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
                LicenseAgreementDialog.ShowDialog(this);
            }

            // Checked For Updates
            if (Settings.GetValue("CheckedForUpdates") != null)
            {
                if (Settings.GetValue("CheckedForUpdates").ToString() == "False")
                {
                    checkforupdates();
                }
            }
            else
            {
                checkforupdates();
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

            // Play a camera shutter sound
            if (Settings.GetValue("PlayACameraShutterSound") != null)
            {
                if (Settings.GetValue("PlayACameraShutterSound").ToString() == "True")
                {
                    CheckBoxPlayACameraShutterSound.Checked = true;
                    playacamerashuttersound = true;
                }
                else if (Settings.GetValue("PlayACameraShutterSound").ToString() == "False")
                {
                    CheckBoxPlayACameraShutterSound.Checked = false;
                    playacamerashuttersound = false;
                }
            }
            else
            {
                playacamerashuttersound = true;
                Settings.SetValue("PlayACameraShutterSound", "True", RegistryValueKind.String);
            }

            // Start minimized
            if (Settings.GetValue("StartMinimized") != null)
            {
                if (Settings.GetValue("StartMinimized").ToString() == "True")
                {
                    resize(false);
                    startedminimized = true;
                    CheckBoxStartMinimized.Checked = true;
                }
                else if (Settings.GetValue("StartMinimized").ToString() == "False")
                {
                    resize(true);
                    startedminimized = false;
                    CheckBoxStartMinimized.Checked = false;
                }
            }
            else
            {
                resize(true);
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

            for (int i = 1; i < 4; i++)
            {
                TextBox textboxhk = Controls.Find("Hotkey" + i, true).FirstOrDefault() as TextBox;
                CheckBox chkbox = Controls.Find("CheckBox" + i, true).FirstOrDefault() as CheckBox;

                if (Settings.GetValue("Hotkey" + i) != null)
                {
                    textboxhk.Text = Settings.GetValue("Hotkey" + i).ToString();
                }
                else
                {
                    Settings.SetValue("Hotkey" + i, "Control + F5", RegistryValueKind.String);
                }

                if (Settings.GetValue("Hotkey" + i + "Enabled") != null)
                {
                    if (Settings.GetValue("Hotkey" + i + "Enabled").ToString() == "True")
                    {
                        chkbox.Checked = true;
                        textboxhk.Enabled = true;
                    }
                    else if (Settings.GetValue("Hotkey" + i + "Enabled").ToString() == "False")
                    {
                        chkbox.Checked = false;
                        textboxhk.Enabled = false;
                    }
                }
                else
                {
                    Settings.SetValue("Hotkey" + i + "Enabled", "True", RegistryValueKind.String);
                }

                RegisterHotkeys(textboxhk, i);
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutDialog.ShowDialog(this);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Maximized == this.WindowState)
            {
                resize(true);
            }
        }

        private void SystemTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            resize(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
        }

        private void Hotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            RegisterHotkey(Hotkey1, 1, e);
        }

        private void Hotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            RegisterHotkey(Hotkey2, 2, e);
        }

        private void Hotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            RegisterHotkey(Hotkey3, 3, e);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            DisableEnableHotkey(CheckBox1.Checked, 1);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            DisableEnableHotkey(CheckBox2.Checked, 2);
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            DisableEnableHotkey(CheckBox3.Checked, 3);
        }

        private void CheckBoxCaptureMouseCursor_CheckedChanged(object sender, EventArgs e)
        {
            switch (CheckBoxCaptureMouseCursor.Checked)
            {
                case true:
                    Settings.SetValue("CaptureMouseCursor", "True", RegistryValueKind.String);
                    CaptureMouseCursor = true;
                    break;

                case false:
                    Settings.SetValue("CaptureMouseCursor", "False", RegistryValueKind.String);
                    CaptureMouseCursor = false;
                    break;
            }
        }

        private void CheckBoxCopyScreenshotsToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            switch (CheckBoxCopyScreenshotsToClipboard.Checked)
            {
                case true:
                    Settings.SetValue("CopyScreenshotsToClipboard", "True", RegistryValueKind.String);
                    CopyScreenshotsToClipboard = true;
                    TextBoxOutputPath.Enabled = false;
                    ButtonBrowse.Enabled = false;
                    break;

                case false:
                    Settings.SetValue("CopyScreenshotsToClipboard", "False", RegistryValueKind.String);
                    CopyScreenshotsToClipboard = false;
                    TextBoxOutputPath.Enabled = true;
                    ButtonBrowse.Enabled = true;
                    break;
            }
        }

        private void CheckBoxPlayACameraShutterSound_CheckedChanged(object sender, EventArgs e)
        {
            switch (CheckBoxPlayACameraShutterSound.Checked)
            {
                case true:
                    Settings.SetValue("PlayACameraShutterSound", "True", RegistryValueKind.String);
                    playacamerashuttersound = true;
                    break;

                case false:
                    Settings.SetValue("PlayACameraShutterSound", "False", RegistryValueKind.String);
                    playacamerashuttersound = false;
                    break;
            }
        }

        private void CheckBoxStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            switch (CheckBoxStartMinimized.Checked)
            {
                case true:
                    Settings.SetValue("StartMinimized", "True", RegistryValueKind.String);
                    break;

                case false:
                    Settings.SetValue("StartMinimized", "False", RegistryValueKind.String);
                    break;
            }
        }

        private void CheckBoxStartSnappyOnSystemStartup_CheckedChanged(object sender, EventArgs e)
        {
            switch (CheckBoxStartSnappyOnSystemStartup.Checked)
            {
                case true:
                    Startup.SetValue("Snappy", "\"" + Application.ExecutablePath + "\"", RegistryValueKind.String);
                    Settings.SetValue("StartSnappyOnSystemStartup", "True", RegistryValueKind.String);
                    break;

                case false:
                    if (Startup.GetValue("Snappy") != null)
                    {
                        Startup.DeleteValue("Snappy");
                    }
                    Settings.SetValue("StartSnappyOnSystemStartup", "False", RegistryValueKind.String);
                    break;
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            switch (fbd.ShowDialog())
            {
                case DialogResult.OK:
                    TextBoxOutputPath.Text = fbd.SelectedPath;
                    Settings.SetValue("OutputPath", "\"" + fbd.SelectedPath + "\"");
                    break;
            }
        }

        private void ButtonMinimizeSnappyToSystemTray_Click(object sender, EventArgs e)
        {
            resize(false);
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure you want to reset all of the settings?", "Snappy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    CheckBox1.Checked = true;
                    Hotkey1.Enabled = true;
                    Hotkey1.Text = "Control + F5";
                    Settings.SetValue("Hotkey1", "Control + F5", RegistryValueKind.String);
                    Settings.SetValue("Hotkey1Enabled", "True", RegistryValueKind.String);

                    CheckBox2.Checked = true;
                    Hotkey2.Enabled = true;
                    Hotkey2.Text = "Control + F6";
                    Settings.SetValue("Hotkey2", "Control + F6", RegistryValueKind.String);
                    Settings.SetValue("Hotkey2Enabled", "True", RegistryValueKind.String);

                    CheckBox3.Checked = true;
                    Hotkey3.Enabled = true;
                    Hotkey3.Text = "Control + F7";
                    Settings.SetValue("Hotkey3", "Control + F7", RegistryValueKind.String);
                    Settings.SetValue("Hotkey3Enabled", "True", RegistryValueKind.String);

                    CheckBoxCaptureMouseCursor.Checked = false;
                    CaptureMouseCursor = false;
                    Settings.SetValue("CaptureMouseCursor", "False", RegistryValueKind.String);

                    CheckBoxCopyScreenshotsToClipboard.Checked = true;
                    CopyScreenshotsToClipboard = true;
                    Settings.SetValue("CopyScreenshotsToClipboard", "True", RegistryValueKind.String);

                    CheckBoxPlayACameraShutterSound.Checked = true;
                    playacamerashuttersound = true;
                    Settings.SetValue("PlayACameraShutterSound", "True", RegistryValueKind.String);

                    TextBoxOutputPath.Enabled = false;
					TextBoxOutputPath.Text = "C:\\";
                    Settings.SetValue("OutputPath", "C:\\", RegistryValueKind.String);

                    ButtonBrowse.Enabled = false;

                    CheckBoxStartMinimized.Checked = false;
                    Settings.SetValue("StartMinimized", "False", RegistryValueKind.String);

                    CheckBoxStartSnappyOnSystemStartup.Checked = false;
                    Settings.SetValue("StartSnappyOnSystemStartup", "False", RegistryValueKind.String);

                    break;
            }
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

        public void resize(bool maximize)
        {
            switch (maximize)
            {
                case true:
                    this.allowVisible = true;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    break;

                case false:
                    this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        private void RegisterHotkey(TextBox textbox, int id, KeyEventArgs e)
        {
            switch (Control.ModifierKeys)
            {
                case Keys.Shift:
                    if (e.KeyCode.ToString() == "ShiftKey")
                    {
                    }
                    else
                    {
                        UnregisterHotKey(this.Handle, id);
                        RegisterHotKey(this.Handle, id, (int)4, e.KeyCode.GetHashCode());
                        textbox.Text = "Shift + " + e.KeyCode.ToString();
                    }
                    break;

                case Keys.Control:
                    if (e.KeyCode.ToString() == "ControlKey")
                    {
                    }
                    else
                    {
                        UnregisterHotKey(this.Handle, id);
                        RegisterHotKey(this.Handle, id, (int)2, e.KeyCode.GetHashCode());
                        textbox.Text = "Control + " + e.KeyCode.ToString();
                    }
                    break;

                case Keys.Alt:
                    if (e.KeyCode.ToString() == "Menu")
                    {
                    }
                    else
                    {
                        UnregisterHotKey(this.Handle, id);
                        RegisterHotKey(this.Handle, id, (int)1, e.KeyCode.GetHashCode());
                        textbox.Text = "Alt + " + e.KeyCode.ToString();
                    }
                    break;

                default:
                    UnregisterHotKey(this.Handle, id);
                    RegisterHotKey(this.Handle, id, (int)0, e.KeyCode.GetHashCode());
                    textbox.Text = e.KeyCode.ToString();
                    break;
            }

            Settings.SetValue("Hotkey" + id, textbox.Text, RegistryValueKind.String);
        }

        private void DisableEnableHotkey(bool enabled, int id)
        {
            TextBox textboxhk = Controls.Find("Hotkey" + id, true).FirstOrDefault() as TextBox;

            switch (enabled)
            {
                case true:
                    textboxhk.Enabled = true;
                    Settings.SetValue("Hotkey" + id + "Enabled", "True", RegistryValueKind.String);
                    RegisterHotkeys(textboxhk, id);
                    break;

                case false:
                    textboxhk.Enabled = false;
                    Settings.SetValue("Hotkey" + id + "Enabled", "False", RegistryValueKind.String);
                    UnregisterHotKey(this.Handle, id);
                    break;
            }
        }

        private void RegisterHotkeys(TextBox textbox, int id)
        {
            Keys a;

            Enum.TryParse(textbox.Text.Replace("Shift + ", "").Replace("Control + ", "").Replace("Alt + ", ""), out a);

            if (textbox.Text.Contains("Shift"))
            {
                UnregisterHotKey(this.Handle, id);
                RegisterHotKey(this.Handle, id, (int)4, a.GetHashCode());
            }
            else if (textbox.Text.Contains("Control"))
            {
                UnregisterHotKey(this.Handle, id);
                RegisterHotKey(this.Handle, id, (int)2, a.GetHashCode());
            }
            else if (textbox.Text.Contains("Alt"))
            {
                UnregisterHotKey(this.Handle, id);
                RegisterHotKey(this.Handle, id, (int)1, a.GetHashCode());
            }
            else
            {
                UnregisterHotKey(this.Handle, id);
                RegisterHotKey(this.Handle, id, (int)0, a.GetHashCode());
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case 0x0312:
                    switch (m.WParam.ToInt32())
                    {
                        case 1:
                            resize(false);
                            CropForm CropForm = new CropForm();
                            CropForm.Show();

                            CropForm.CaptureMouseCursor = CaptureMouseCursor;
                            CropForm.CopyScreenshotsToClipboard = CopyScreenshotsToClipboard;
                            CropForm.startedminimized = startedminimized;
                            CropForm.playacamerashuttersound = playacamerashuttersound;
                            CropForm.outputpath = TextBoxOutputPath.Text;

                            break;

                        case 2:
                            Bitmap ss = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

                            try
                            {
                                Graphics g = Graphics.FromImage(ss);
                                System.Threading.Thread.Sleep(250);
                                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

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
                                        ss.Save(TextBoxOutputPath.Text + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                            }

                            break;

                        case 3:
                            var rect = new RECT();
                            GetWindowRect(GetForegroundWindow(), out rect);
                            Rectangle bounds1 = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

                            Bitmap ss1 = new Bitmap(bounds1.Width, bounds1.Height);

                            try
                            {
                                Graphics g = Graphics.FromImage(ss1);
                                System.Threading.Thread.Sleep(250);
                                g.CopyFromScreen(new Point(bounds1.Left, bounds1.Top), Point.Empty, bounds1.Size);

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
                                                DrawIconEx(hdc, CI.ptScreenPos.x - bounds1.X, CI.ptScreenPos.y - bounds1.Y, CI.hCursor, 0, 0, 0, IntPtr.Zero, DI_NORMAL);
                                                g.ReleaseHdc();
                                            }
                                        }
                                        break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("An error occured in the capturing of the screenshot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ss1 = null;
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
                                    Clipboard.SetImage(ss1);
                                    break;

                                case false:
                                    try
                                    {
                                        ss1.Save(TextBoxOutputPath.Text + "\\" + "Screenshot-" + DateTime.Now.ToString("hh:mm:ss").Replace(":", "") + ".png", ImageFormat.Png);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("The specified path doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                            }

                            break;
                    }

                    break;
            }
        }

        private void exit()
        {
            Application.Exit();
            this.Close();
        }

        private void SelectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Folder = fbd.SelectedPath;
            }
            else if (fbd.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Please select a folder where to download the newest version in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectFolder();
            }
        }

        private void checkforupdates()
        {
            Settings.SetValue("CheckedForUpdates", "True", RegistryValueKind.String);

            int currentversion = Convert.ToInt32("1.0.5".Replace(".", ""));
            newestver = wc.DownloadString("https://raw.githubusercontent.com/danskee/Snappy/main/version").Replace("\n", "").Replace("\r", "");
            int newestversion = Convert.ToInt32(newestver.Replace(".", ""));

            if (currentversion < newestversion)
            {
                switch (MessageBox.Show("The version " + newestver + " is available. Download?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        DownloadNewestVersion();
                        break;
                }
            }
        }

        private void CheckForUpdates(object sender, EventArgs e)
        {
            checkforupdates();
        }

        private void DownloadNewestVersion()
        {
            SelectFolder();

            try
            {
                wc.DownloadFile("https://github.com/danskee/Snappy/releases/download/v" + newestver + "/" + "Snappy-v" + newestver + ".zip", Folder + @"\" + "Snappy-v" + newestver + ".zip");
                ZipFile.ExtractToDirectory(Folder + @"\" + "Snappy-v" + newestver + ".zip", Folder);
                File.Delete(Folder + @"\" + "Snappy-v" + newestver + ".zip");
                MessageBox.Show("Succesfully downloaded the newest version in " + Folder + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failed to download the newest version. Make sure you have a stable internet connection and that you're not trying to overwrite an already existing file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }
    }
}
