using System;
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
    public partial class NewVersion : Form
    {
        string download_page;
        Version v;
        public NewVersion(string url, Version v)
        {
            InitializeComponent();
            download_page = url;
            this.v = v;
            label3.Text = v.ToString();
        }

        private void button1_Click1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(download_page);
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}
