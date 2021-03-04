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
            this.GroupBoxScreenshotSettings = new System.Windows.Forms.GroupBox();
            this.CheckBoxPlayACameraShutterSound = new System.Windows.Forms.CheckBox();
            this.LabelOutputPath = new System.Windows.Forms.Label();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxOutputPath = new System.Windows.Forms.TextBox();
            this.CheckBoxCopyScreenshotsToClipboard = new System.Windows.Forms.CheckBox();
            this.CheckBoxCaptureMouseCursor = new System.Windows.Forms.CheckBox();
            this.ButtonMinimizeSnappyToSystemTray = new System.Windows.Forms.Button();
            this.ButtonResetSettings = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxHotkeySettings.SuspendLayout();
            this.GroupBoxMiscSettings.SuspendLayout();
            this.GroupBoxScreenshotSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
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
            this.GroupBoxHotkeySettings.Location = new System.Drawing.Point(13, 35);
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
            this.GroupBoxMiscSettings.Location = new System.Drawing.Point(14, 245);
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
            // GroupBoxScreenshotSettings
            // 
            this.GroupBoxScreenshotSettings.Controls.Add(this.CheckBoxPlayACameraShutterSound);
            this.GroupBoxScreenshotSettings.Controls.Add(this.LabelOutputPath);
            this.GroupBoxScreenshotSettings.Controls.Add(this.ButtonBrowse);
            this.GroupBoxScreenshotSettings.Controls.Add(this.TextBoxOutputPath);
            this.GroupBoxScreenshotSettings.Controls.Add(this.CheckBoxCopyScreenshotsToClipboard);
            this.GroupBoxScreenshotSettings.Controls.Add(this.CheckBoxCaptureMouseCursor);
            this.GroupBoxScreenshotSettings.Location = new System.Drawing.Point(14, 142);
            this.GroupBoxScreenshotSettings.Name = "GroupBoxScreenshotSettings";
            this.GroupBoxScreenshotSettings.Size = new System.Drawing.Size(485, 97);
            this.GroupBoxScreenshotSettings.TabIndex = 8;
            this.GroupBoxScreenshotSettings.TabStop = false;
            this.GroupBoxScreenshotSettings.Text = "Screenshot settings";
            // 
            // CheckBoxPlayACameraShutterSound
            // 
            this.CheckBoxPlayACameraShutterSound.AutoSize = true;
            this.CheckBoxPlayACameraShutterSound.Checked = true;
            this.CheckBoxPlayACameraShutterSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPlayACameraShutterSound.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBoxPlayACameraShutterSound.Location = new System.Drawing.Point(12, 67);
            this.CheckBoxPlayACameraShutterSound.Name = "CheckBoxPlayACameraShutterSound";
            this.CheckBoxPlayACameraShutterSound.Size = new System.Drawing.Size(166, 18);
            this.CheckBoxPlayACameraShutterSound.TabIndex = 12;
            this.CheckBoxPlayACameraShutterSound.Text = "Play a camera shutter sound";
            this.CheckBoxPlayACameraShutterSound.UseVisualStyleBackColor = true;
            this.CheckBoxPlayACameraShutterSound.CheckedChanged += new System.EventHandler(this.CheckBoxPlayACameraShutterSound_CheckedChanged);
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
            this.ButtonMinimizeSnappyToSystemTray.Location = new System.Drawing.Point(15, 324);
            this.ButtonMinimizeSnappyToSystemTray.Name = "ButtonMinimizeSnappyToSystemTray";
            this.ButtonMinimizeSnappyToSystemTray.Size = new System.Drawing.Size(389, 23);
            this.ButtonMinimizeSnappyToSystemTray.TabIndex = 9;
            this.ButtonMinimizeSnappyToSystemTray.Text = "Minimize Snappy to system tray";
            this.ButtonMinimizeSnappyToSystemTray.UseVisualStyleBackColor = true;
            this.ButtonMinimizeSnappyToSystemTray.Click += new System.EventHandler(this.ButtonMinimizeSnappyToSystemTray_Click);
            // 
            // ButtonResetSettings
            // 
            this.ButtonResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonResetSettings.Location = new System.Drawing.Point(410, 324);
            this.ButtonResetSettings.Name = "ButtonResetSettings";
            this.ButtonResetSettings.Size = new System.Drawing.Size(90, 23);
            this.ButtonResetSettings.TabIndex = 10;
            this.ButtonResetSettings.Text = "Reset settings";
            this.ButtonResetSettings.UseVisualStyleBackColor = true;
            this.ButtonResetSettings.Click += new System.EventHandler(this.ButtonResetSettings_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(511, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExit});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuItemFile.Text = "File";
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(92, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuItemHelp.Text = "Help";
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuItemAbout.Text = "About";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdatesToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(171, 48);
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            this.CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CheckForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdates);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ExitToolStripMenuItem.Text = "Exit Snappy";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 359);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ButtonResetSettings);
            this.Controls.Add(this.ButtonMinimizeSnappyToSystemTray);
            this.Controls.Add(this.GroupBoxScreenshotSettings);
            this.Controls.Add(this.GroupBoxMiscSettings);
            this.Controls.Add(this.GroupBoxHotkeySettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Snappy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.GroupBoxHotkeySettings.ResumeLayout(false);
            this.GroupBoxHotkeySettings.PerformLayout();
            this.GroupBoxMiscSettings.ResumeLayout(false);
            this.GroupBoxMiscSettings.PerformLayout();
            this.GroupBoxScreenshotSettings.ResumeLayout(false);
            this.GroupBoxScreenshotSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public System.Windows.Forms.TextBox TextBoxOutputPath;
        private System.Windows.Forms.Button ButtonMinimizeSnappyToSystemTray;
        private System.Windows.Forms.Button ButtonResetSettings;
        private System.Windows.Forms.CheckBox CheckBoxPlayACameraShutterSound;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

