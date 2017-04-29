using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace FileInformationEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {

                textBox1.Text = ofd.FileName;
                MessageBox.Show(Path.GetFileNameWithoutExtension(textBox1.Text));
                label8.Text = File.GetCreationTime(ofd.FileName).ToString();
                label9.Text = File.GetLastWriteTime(ofd.FileName).ToString();
                label10.Text = File.GetLastAccessTime(ofd.FileName).ToString();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt;
            try
            {
                if (checkBox1.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox1.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if(i == -1){
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.SetCreationTime(textBox1.Text, dt);
                label8.Text = File.GetCreationTime(textBox1.Text).ToString();
                label9.Text = File.GetLastWriteTime(textBox1.Text).ToString();
                label10.Text = File.GetLastAccessTime(textBox1.Text).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt;
            try
            {
                if (checkBox2.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox2.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if (i == -1)
            {
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.SetLastWriteTime(textBox1.Text, dt);
                label8.Text = File.GetCreationTime(textBox1.Text).ToString();
                label9.Text = File.GetLastWriteTime(textBox1.Text).ToString();
                label10.Text = File.GetLastAccessTime(textBox1.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dt;
            
            try
            {
                if (checkBox3.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox3.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if (i == -1)
            {
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.SetLastAccessTime(textBox1.Text, dt);
                label8.Text = File.GetCreationTime(textBox1.Text).ToString();
                label9.Text = File.GetLastWriteTime(textBox1.Text).ToString();
                label10.Text = File.GetLastAccessTime(textBox1.Text).ToString();
            }catch(Exception ex){
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                maskedTextBox1.Enabled = false;
            }
            else
            {
                maskedTextBox1.Enabled = true;
            }
            
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                maskedTextBox2.Enabled = false;
            }
            else
            {
                maskedTextBox2.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                maskedTextBox3.Enabled = false;
            }
            else
            {
                maskedTextBox3.Enabled = true;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomBox.Show();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpWebRequest req;
            HttpWebResponse res;
            req = (HttpWebRequest)HttpWebRequest.Create("http://sumjest.ru/programsinfo/fileinfoedit.txt");
            try
            {
                res = (HttpWebResponse)req.GetResponse();
            }catch(Exception){
                MessageBox.Show("Unable to establish a connection with the host", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WebHeaderCollection header = res.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(res.GetResponseStream(), encoding))
            {
                string version = "";
                string page = "";
                string[] firstline = reader.ReadLine().Split(':');
                if (firstline.Length != 2)
                {
                    for (int i = 1; i < firstline.Length; i++)
                    {
                        version += firstline[i];

                    }
                }
                else
                {
                    version = firstline[1];
                }
                string[] secondline = reader.ReadLine().Split(':');
                if (secondline.Length != 2)
                {
                    for (int i = 1; i < secondline.Length; i++)
                    {
                        if (page == "")
                        {
                            page = secondline[i];
                        }
                        else
                        {
                            page += ":" + secondline[i];
                        }
                    }
                }
                else
                {
                    page = secondline[1];
                }

                Version v = Version.Parse(version);
                int ia = v.CompareTo(Version.Parse(Application.ProductVersion));
                if (ia != 1)
                {
                    MessageBox.Show("No updates available!", infoToolStripMenuItem.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    CustomBox.ShowNV(page, v);

                }
            }

        }

        private void tabPage1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                MessageBox.Show("Please choose only one file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(files[0]))
            {
                MessageBox.Show("Please drop file, not file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox1.Text = files[0];
            label8.Text = File.GetCreationTime(files[0]).ToString();
            label9.Text = File.GetLastWriteTime(files[0]).ToString();
            label10.Text = File.GetLastAccessTime(files[0]).ToString();
        }

        private void tabPage1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            

            DialogResult result = ofd.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                textBox2.Text = ofd.SelectedPath;
                label16.Text = Directory.GetCreationTime(ofd.SelectedPath).ToString();
                label14.Text = Directory.GetLastWriteTime(ofd.SelectedPath).ToString();
                label12.Text = Directory.GetLastAccessTime(ofd.SelectedPath).ToString();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime dt;

            try
            {
                if (checkBox4.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox4.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if (i == -1)
            {
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Directory.SetCreationTime(textBox2.Text, dt);
                label16.Text = Directory.GetCreationTime(textBox2.Text).ToString();
                label14.Text = Directory.GetLastWriteTime(textBox2.Text).ToString();
                label12.Text = Directory.GetLastAccessTime(textBox2.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime dt;

            try
            {
                if (checkBox5.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox5.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if (i == -1)
            {
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Directory.SetLastWriteTime(textBox2.Text, dt);
                label16.Text = Directory.GetCreationTime(textBox2.Text).ToString();
                label14.Text = Directory.GetLastWriteTime(textBox2.Text).ToString();
                label12.Text = Directory.GetLastAccessTime(textBox2.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime dt;

            try
            {
                if (checkBox6.Checked)
                {
                    dt = DateTime.Now;
                }
                else
                {
                    dt = DateTime.Parse(maskedTextBox6.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime min = DateTime.Parse("02.01.1601 00:00:00");
            int i = DateTime.Compare(dt, min);
            if (i == -1)
            {
                MessageBox.Show("Min date is \"02.01.1601 00:00:00\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Directory.SetLastAccessTime(textBox2.Text, dt);
                label16.Text = Directory.GetCreationTime(textBox2.Text).ToString();
                label14.Text = Directory.GetLastWriteTime(textBox2.Text).ToString();
                label12.Text = Directory.GetLastAccessTime(textBox2.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked){
                maskedTextBox4.Enabled = false;
                return;
            }
            maskedTextBox4.Enabled = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                maskedTextBox5.Enabled = false;
                return;
            }
            maskedTextBox5.Enabled = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                maskedTextBox6.Enabled = false;
                return;
            }
            maskedTextBox6.Enabled = true;
        }

        private void tabPage2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                MessageBox.Show("Please choose only one folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!Directory.Exists(files[0]))
            {
                MessageBox.Show("Please drop folder, not file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox2.Text = files[0];
            label16.Text = File.GetCreationTime(files[0]).ToString();
            label14.Text = File.GetLastWriteTime(files[0]).ToString();
            label12.Text = File.GetLastAccessTime(files[0]).ToString();
        }

        private void tabPage2_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false)){
                e.Effect = DragDropEffects.All;
            }
        }

        
    }
}
