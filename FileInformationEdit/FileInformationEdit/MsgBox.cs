﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInformationEdit
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
            label3.Text = "Version: " + Application.ProductVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/id144268714");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
