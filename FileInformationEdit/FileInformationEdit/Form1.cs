using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        private void GetChangeLog()
        {
            HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create("http://sumjest.ru/index/file_info_editor/0-5");
            proxy_request.Method = "GET";
            proxy_request.Timeout = 20000;
            HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
            string html = "";
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                html = sr.ReadToEnd();
            string a = Regex.Match(html, @"<!--Dangerous--><p>Change log:([\s\S]*)\<!--Dangerous-->").ToString();
            a = a.Replace("<!--Dangerous-->", "");
            a = a.Replace("<p>", "");
            a = a.Replace("</p>", "");
            a = a.Replace("<br />", "");
            a = a.Replace("&nbsp;", " ");
            MessageBox.Show(a);

        }
        private void CheckForUpdates()
        {
            try
            {
                HttpWebResponse res = (HttpWebResponse)HttpWebRequest.Create("http://sumjest.ru/programsinfo/programs.txt").GetResponse();
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new StreamReader(res.GetResponseStream(), encoding))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] linea = line.Split(';');

                        if (line.Split(';')[0].Contains("FileInfoEditor"))
                        {
                            Version v;
                            if (Version.TryParse(line.Split(';')[1], out v)) { if (v.CompareTo(Version.Parse(Application.ProductVersion)) > 0) { menuStrip1.Items.Add("Вышла новая версия программы!", null, onNewClick); } }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void onNewClick(object sender, EventArgs e)
        {
            GetChangeLog();
        }
    }
}
