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
using System.Diagnostics;
using System.Windows.Forms;

namespace Snappy
{
    public partial class AboutDialog : Form
    {
        public string v = "";

        public AboutDialog(string x)
        {
            InitializeComponent();
            v = x;
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            LabelAbout.Text = "Version " + v + ", 64-bit\r\nCopyright © 2021 Danske";
        }

        private void LinkGitHub_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/danskee");
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs a = new KeyEventArgs(keyData);
            if (a.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
