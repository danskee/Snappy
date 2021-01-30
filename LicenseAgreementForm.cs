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
using Microsoft.Win32;
using System.Windows.Forms;

namespace Snappy
{
    public partial class LicenseAgreementForm : Form
    {
        RegistryKey Settings = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Snappy", true);

        public LicenseAgreementForm()
        {
            InitializeComponent();
        }

        void ButtonAgree_Click(object sender, EventArgs e)
        {
            Settings.SetValue("LicenseAccepted", "True", RegistryValueKind.String);
            this.Close();
        }

        void ButtonDecline_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
