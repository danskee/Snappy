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

namespace Snappy
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.Hotkey3 = new System.Windows.Forms.TextBox();
            this.Hotkey1 = new System.Windows.Forms.TextBox();
            this.Hotkey2 = new System.Windows.Forms.TextBox();
            this.GroupBoxHotkeySettings = new System.Windows.Forms.GroupBox();
            this.GroupBoxMiscSettings = new System.Windows.Forms.GroupBox();
            this.CheckBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.CheckBoxStartSnappyOnSystemStartup = new System.Windows.Forms.CheckBox();
            this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxScreenshotSettings = new System.Windows.Forms.GroupBox();
            this.LabelOutputPath = new System.Windows.Forms.Label();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxOutputPath = new System.Windows.Forms.TextBox();
            this.CheckBoxCopyScreenshotsToClipboard = new System.Windows.Forms.CheckBox();
            this.CheckBoxCaptureMouseCursor = new System.Windows.Forms.CheckBox();
            this.ButtonMinimizeSnappyToSystemTray = new System.Windows.Forms.Button();
            this.MainMenuExit = new System.Windows.Forms.MenuItem();
            this.MainMenuFile = new System.Windows.Forms.MenuItem();
            this.MainMenuAbout = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.MainMenuHelp = new System.Windows.Forms.MenuItem();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.GroupBoxHotkeySettings.SuspendLayout();
            this.GroupBoxMiscSettings.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.GroupBoxScreenshotSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Checked = true;
            this.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBox1.Location = new System.Drawing.Point(13, 19);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(190, 18);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Hotkey for a cropped screenshot:";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Checked = true;
            this.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBox2.Location = new System.Drawing.Point(13, 43);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(196, 18);
            this.CheckBox2.TabIndex = 1;
            this.CheckBox2.Text = "Hotkey for a fullscreen screenshot:";
            this.CheckBox2.UseVisualStyleBackColor = true;
            this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.Checked = true;
            this.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBox3.Location = new System.Drawing.Point(13, 67);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(249, 18);
            this.CheckBox3.TabIndex = 2;
            this.CheckBox3.Text = "Hotkey for a screenshot of the active window:";
            this.CheckBox3.UseVisualStyleBackColor = true;
            this.CheckBox3.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
            // 
            // Hotkey3
            // 
            this.Hotkey3.Location = new System.Drawing.Point(373, 66);
            this.Hotkey3.Name = "Hotkey3";
            this.Hotkey3.ReadOnly = true;
            this.Hotkey3.Size = new System.Drawing.Size(100, 20);
            this.Hotkey3.TabIndex = 3;
            this.Hotkey3.Text = "Control + F7";
            this.Hotkey3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey3_KeyDown);
            // 
            // Hotkey1
            // 
            this.Hotkey1.Location = new System.Drawing.Point(373, 18);
            this.Hotkey1.Name = "Hotkey1";
            this.Hotkey1.ReadOnly = true;
            this.Hotkey1.Size = new System.Drawing.Size(100, 20);
            this.Hotkey1.TabIndex = 4;
            this.Hotkey1.Text = "Control + F5";
            this.Hotkey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey1_KeyDown);
            // 
            // Hotkey2
            // 
            this.Hotkey2.Location = new System.Drawing.Point(373, 42);
            this.Hotkey2.Name = "Hotkey2";
            this.Hotkey2.ReadOnly = true;
            this.Hotkey2.Size = new System.Drawing.Size(100, 20);
            this.Hotkey2.TabIndex = 5;
            this.Hotkey2.Text = "Control + F6";
            this.Hotkey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey2_KeyDown);
            // 
            // GroupBoxHotkeySettings
            // 
            this.GroupBoxHotkeySettings.Controls.Add(this.Hotkey1);
            this.GroupBoxHotkeySettings.Controls.Add(this.Hotkey2);
            this.GroupBoxHotkeySettings.Controls.Add(this.CheckBox1);
            this.GroupBoxHotkeySettings.Controls.Add(this.CheckBox2);
            this.GroupBoxHotkeySettings.Controls.Add(this.Hotkey3);
            this.GroupBoxHotkeySettings.Controls.Add(this.CheckBox3);
            this.GroupBoxHotkeySettings.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxHotkeySettings.Name = "GroupBoxHotkeySettings";
            this.GroupBoxHotkeySettings.Size = new System.Drawing.Size(486, 100);
            this.GroupBoxHotkeySettings.TabIndex = 6;
            this.GroupBoxHotkeySettings.TabStop = false;
            this.GroupBoxHotkeySettings.Text = "Hotkey settings";
            // 
            // GroupBoxMiscSettings
            // 
            this.GroupBoxMiscSettings.Controls.Add(this.CheckBoxStartMinimized);
            this.GroupBoxMiscSettings.Controls.Add(this.CheckBoxStartSnappyOnSystemStartup);
            this.GroupBoxMiscSettings.Location = new System.Drawing.Point(13, 202);
            this.GroupBoxMiscSettings.Name = "GroupBoxMiscSettings";
            this.GroupBoxMiscSettings.Size = new System.Drawing.Size(485, 73);
            this.GroupBoxMiscSettings.TabIndex = 7;
            this.GroupBoxMiscSettings.TabStop = false;
            this.GroupBoxMiscSettings.Text = "Misc settings";
            // 
            // CheckBoxStartMinimized
            // 
            this.CheckBoxStartMinimized.AutoSize = true;
            this.CheckBoxStartMinimized.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxStartMinimized.Location = new System.Drawing.Point(13, 19);
            this.CheckBoxStartMinimized.Name = "CheckBoxStartMinimized";
            this.CheckBoxStartMinimized.Size = new System.Drawing.Size(102, 18);
            this.CheckBoxStartMinimized.TabIndex = 7;
            this.CheckBoxStartMinimized.Text = "Start minimized";
            this.CheckBoxStartMinimized.UseVisualStyleBackColor = true;
            this.CheckBoxStartMinimized.CheckedChanged += new System.EventHandler(this.CheckBoxStartMinimized_CheckedChanged);
            // 
            // CheckBoxStartSnappyOnSystemStartup
            // 
            this.CheckBoxStartSnappyOnSystemStartup.AutoSize = true;
            this.CheckBoxStartSnappyOnSystemStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxStartSnappyOnSystemStartup.Location = new System.Drawing.Point(13, 43);
            this.CheckBoxStartSnappyOnSystemStartup.Name = "CheckBoxStartSnappyOnSystemStartup";
            this.CheckBoxStartSnappyOnSystemStartup.Size = new System.Drawing.Size(178, 18);
            this.CheckBoxStartSnappyOnSystemStartup.TabIndex = 6;
            this.CheckBoxStartSnappyOnSystemStartup.Text = "Start Snappy on system startup";
            this.CheckBoxStartSnappyOnSystemStartup.UseVisualStyleBackColor = true;
            this.CheckBoxStartSnappyOnSystemStartup.CheckedChanged += new System.EventHandler(this.CheckBoxStartSnappyOnSystemStartup_CheckedChanged);
            // 
            // SystemTrayIcon
            // 
            this.SystemTrayIcon.ContextMenuStrip = this.ContextMenuStrip;
            this.SystemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemTrayIcon.Icon")));
            this.SystemTrayIcon.Text = "Snappy";
            this.SystemTrayIcon.Visible = true;
            this.SystemTrayIcon.DoubleClick += new System.EventHandler(this.SystemTrayIcon_DoubleClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuStripExit});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStrip.Size = new System.Drawing.Size(93, 26);
            // 
            // ContextMenuStripExit
            // 
            this.ContextMenuStripExit.Name = "ContextMenuStripExit";
            this.ContextMenuStripExit.Size = new System.Drawing.Size(92, 22);
            this.ContextMenuStripExit.Text = "Exit";
            this.ContextMenuStripExit.Click += new System.EventHandler(this.ContextMenuStripExit_Click);
            // 
            // GroupBoxScreenshotSettings
            // 
            this.GroupBoxScreenshotSettings.Controls.Add(this.LabelOutputPath);
            this.GroupBoxScreenshotSettings.Controls.Add(this.ButtonBrowse);
            this.GroupBoxScreenshotSettings.Controls.Add(this.TextBoxOutputPath);
            this.GroupBoxScreenshotSettings.Controls.Add(this.CheckBoxCopyScreenshotsToClipboard);
            this.GroupBoxScreenshotSettings.Controls.Add(this.CheckBoxCaptureMouseCursor);
            this.GroupBoxScreenshotSettings.Location = new System.Drawing.Point(13, 119);
            this.GroupBoxScreenshotSettings.Name = "GroupBoxScreenshotSettings";
            this.GroupBoxScreenshotSettings.Size = new System.Drawing.Size(485, 77);
            this.GroupBoxScreenshotSettings.TabIndex = 8;
            this.GroupBoxScreenshotSettings.TabStop = false;
            this.GroupBoxScreenshotSettings.Text = "Screenshot settings";
            // 
            // LabelOutputPath
            // 
            this.LabelOutputPath.AutoSize = true;
            this.LabelOutputPath.Location = new System.Drawing.Point(189, 27);
            this.LabelOutputPath.Name = "LabelOutputPath";
            this.LabelOutputPath.Size = new System.Drawing.Size(66, 13);
            this.LabelOutputPath.TabIndex = 11;
            this.LabelOutputPath.Text = "Output path:";
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Enabled = false;
            this.ButtonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonBrowse.Location = new System.Drawing.Point(397, 42);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 20);
            this.ButtonBrowse.TabIndex = 10;
            this.ButtonBrowse.Text = "Browse..";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // TextBoxOutputPath
            // 
            this.TextBoxOutputPath.Enabled = false;
            this.TextBoxOutputPath.Location = new System.Drawing.Point(192, 42);
            this.TextBoxOutputPath.Name = "TextBoxOutputPath";
            this.TextBoxOutputPath.ReadOnly = true;
            this.TextBoxOutputPath.Size = new System.Drawing.Size(199, 20);
            this.TextBoxOutputPath.TabIndex = 6;
            this.TextBoxOutputPath.Text = "C:\\";
            // 
            // CheckBoxCopyScreenshotsToClipboard
            // 
            this.CheckBoxCopyScreenshotsToClipboard.AutoSize = true;
            this.CheckBoxCopyScreenshotsToClipboard.Checked = true;
            this.CheckBoxCopyScreenshotsToClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCopyScreenshotsToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxCopyScreenshotsToClipboard.Location = new System.Drawing.Point(12, 43);
            this.CheckBoxCopyScreenshotsToClipboard.Name = "CheckBoxCopyScreenshotsToClipboard";
            this.CheckBoxCopyScreenshotsToClipboard.Size = new System.Drawing.Size(174, 18);
            this.CheckBoxCopyScreenshotsToClipboard.TabIndex = 9;
            this.CheckBoxCopyScreenshotsToClipboard.Text = "Copy screenshots to clipboard";
            this.CheckBoxCopyScreenshotsToClipboard.UseVisualStyleBackColor = true;
            this.CheckBoxCopyScreenshotsToClipboard.CheckedChanged += new System.EventHandler(this.CheckBoxCopyScreenshotsToClipboard_CheckedChanged);
            // 
            // CheckBoxCaptureMouseCursor
            // 
            this.CheckBoxCaptureMouseCursor.AutoSize = true;
            this.CheckBoxCaptureMouseCursor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxCaptureMouseCursor.Location = new System.Drawing.Point(12, 19);
            this.CheckBoxCaptureMouseCursor.Name = "CheckBoxCaptureMouseCursor";
            this.CheckBoxCaptureMouseCursor.Size = new System.Drawing.Size(135, 18);
            this.CheckBoxCaptureMouseCursor.TabIndex = 8;
            this.CheckBoxCaptureMouseCursor.Text = "Capture mouse cursor";
            this.CheckBoxCaptureMouseCursor.UseVisualStyleBackColor = true;
            this.CheckBoxCaptureMouseCursor.CheckedChanged += new System.EventHandler(this.CheckBoxCaptureMouseCursor_CheckedChanged);
            // 
            // ButtonMinimizeSnappyToSystemTray
            // 
            this.ButtonMinimizeSnappyToSystemTray.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonMinimizeSnappyToSystemTray.Location = new System.Drawing.Point(12, 282);
            this.ButtonMinimizeSnappyToSystemTray.Name = "ButtonMinimizeSnappyToSystemTray";
            this.ButtonMinimizeSnappyToSystemTray.Size = new System.Drawing.Size(486, 23);
            this.ButtonMinimizeSnappyToSystemTray.TabIndex = 9;
            this.ButtonMinimizeSnappyToSystemTray.Text = "Minimize Snappy to system tray";
            this.ButtonMinimizeSnappyToSystemTray.UseVisualStyleBackColor = true;
            this.ButtonMinimizeSnappyToSystemTray.Click += new System.EventHandler(this.ButtonMinimizeSnappyToSystemTray_Click);
            // 
            // MainMenuExit
            // 
            this.MainMenuExit.Index = 0;
            this.MainMenuExit.Text = "Exit";
            this.MainMenuExit.Click += new System.EventHandler(this.MainMenuExit_Click);
            // 
            // MainMenuFile
            // 
            this.MainMenuFile.Index = 0;
            this.MainMenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MainMenuExit});
            this.MainMenuFile.Text = "File";
            // 
            // MainMenuAbout
            // 
            this.MainMenuAbout.Index = 0;
            this.MainMenuAbout.Text = "About";
            this.MainMenuAbout.Click += new System.EventHandler(this.MainMenuAbout_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "";
            // 
            // MainMenuHelp
            // 
            this.MainMenuHelp.Index = 1;
            this.MainMenuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MainMenuAbout,
            this.menuItem2});
            this.MainMenuHelp.Text = "Help";
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MainMenuFile,
            this.MainMenuHelp});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 317);
            this.Controls.Add(this.ButtonMinimizeSnappyToSystemTray);
            this.Controls.Add(this.GroupBoxScreenshotSettings);
            this.Controls.Add(this.GroupBoxMiscSettings);
            this.Controls.Add(this.GroupBoxHotkeySettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Snappy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.GroupBoxHotkeySettings.ResumeLayout(false);
            this.GroupBoxHotkeySettings.PerformLayout();
            this.GroupBoxMiscSettings.ResumeLayout(false);
            this.GroupBoxMiscSettings.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.GroupBoxScreenshotSettings.ResumeLayout(false);
            this.GroupBoxScreenshotSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox CheckBox1;
        private System.Windows.Forms.CheckBox CheckBox2;
        private System.Windows.Forms.CheckBox CheckBox3;
        private System.Windows.Forms.TextBox Hotkey3;
        private System.Windows.Forms.TextBox Hotkey1;
        private System.Windows.Forms.TextBox Hotkey2;
        private System.Windows.Forms.GroupBox GroupBoxHotkeySettings;
        private System.Windows.Forms.GroupBox GroupBoxMiscSettings;
        private System.Windows.Forms.CheckBox CheckBoxStartMinimized;
        private System.Windows.Forms.CheckBox CheckBoxStartSnappyOnSystemStartup;
        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
        private System.Windows.Forms.GroupBox GroupBoxScreenshotSettings;
        private System.Windows.Forms.CheckBox CheckBoxCaptureMouseCursor;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.CheckBox CheckBoxCopyScreenshotsToClipboard;
        private System.Windows.Forms.Label LabelOutputPath;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuStripExit;
        public System.Windows.Forms.TextBox TextBoxOutputPath;
        private System.Windows.Forms.Button ButtonMinimizeSnappyToSystemTray;
        private System.Windows.Forms.MenuItem MainMenuExit;
        private System.Windows.Forms.MenuItem MainMenuFile;
        private System.Windows.Forms.MenuItem MainMenuAbout;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem MainMenuHelp;
        private System.Windows.Forms.MainMenu MainMenu;
    }
}

