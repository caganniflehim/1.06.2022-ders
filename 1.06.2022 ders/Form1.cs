using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._06._2022_ders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mesax box", "selam", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("merhaba", "selam", MessageBoxButtons.OKCancel);

            // ikinci kısım
           DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("programdan çıkılsın mı","çıkış",MessageBoxButtons.YesNo);
            if (dialog==DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("çıkış yapılmadı");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("merhaba", "selam", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("merhaba", "selam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("merhaba", "selam", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "metin dosyası | *.txt";
            file.RestoreDirectory = true;//son açılan dizinin açık kalması için
            if (file.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(file.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            //2.yol
            richTextBox1.LoadFile(file.FileName, RichTextBoxStreamType.PlainText);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.DefaultExt = "*.txt";
            file.Filter = "metin dosyası | *.txt";

            if (file.ShowDialog()==DialogResult.OK && file.FileName.Length>0)
            {
                richTextBox1.SaveFile(file.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("dosya kaydedildi", "kayıt yeri: "
                    + file.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "resim dosyası|*.jpg;*.png| video dosyası|*avi;|tüm dosyalar |*.*";
            file.Title = "resim seç";
            file.ShowDialog();
            string filePath = file.FileName;
            pictureBox1.ImageLocation = filePath;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string isim = Interaction.InputBox("isim giriş", "yeni isim", "örn:ali uzun");
            listBox1.Items.Add(isim);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string isim = Interaction.InputBox("isim girişi", "yeni isim", listBox1.SelectedItem.ToString());
            listBox1.Items[index] = isim;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog()==DialogResult.OK)
            {
                string dosyayolu = folder.SelectedPath;
                label2.Text = dosyayolu;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string dosyauolu = label2.Text;
            if (dosyauolu!="")
            {
                foreach (string d in Directory.GetDirectories(dosyauolu))
                {
                    listBox2.Items.Add(Path.GetFileName(d));
                }
                foreach (string f in Directory.GetFiles(dosyauolu))
                {
                    listBox2.Items.Add(Path.GetFileName(f));
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                button14.BackColor = color.Color;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog()==DialogResult.OK)
            {
                button14.BackColor = color.Color;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowColor = true;
            font.ShowDialog();
            button15.Font = font.Font;
            button15.ForeColor = font.Color;
        }
    }
}
