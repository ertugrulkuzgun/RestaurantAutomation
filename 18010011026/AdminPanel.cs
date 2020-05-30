using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _18010011026
{
    public partial class AdminPanel : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        OleDbDataReader dr;
        string filedelimiter = ",";
        string line = "";
        Int32 counter = 0;
        public AdminPanel()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void comboBoxlarıGuncelle()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM firma", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["firmaTamAd"]);
                }
                baglanti.Close();
                dr.Close();
                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("SELECT * FROM musteri", baglanti);
                dr = komut2.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["adSoyad"]);
                }
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            comboBoxlarıGuncelle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            openChildForm(new FirmaProfil());
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //id gönderme
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM firma WHERE firmaTamAd = '" + comboBox1.SelectedItem + "'", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Form1.idAnasayfa = dr["id"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            openChildForm(new UyeOl());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //firma silme
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("DELETE FROM firma WHERE firmaTamAd = '" + comboBox1.SelectedItem + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                comboBoxlarıGuncelle();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //id gönderme
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM musteri WHERE adSoyad = '" + comboBox2.SelectedItem + "'", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Form1.idAnasayfa = dr["id"].ToString();
                }
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            openChildForm(new KullanıcıProfil());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //firma silme
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("DELETE FROM musteri WHERE adSoyad = '" + comboBox2.SelectedItem + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                comboBoxlarıGuncelle();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //seçilen dosyayı textboxa yazdırma
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.Title = "Bir txt dosyası seçiniz.";
            openDialog.InitialDirectory = Application.StartupPath;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openDialog.FileName.ToString();
            }
            openDialog.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //verilen konumdaki txt deki verileri veritabanına ekleme
            try
            {
                System.IO.StreamReader KaynakDosya = new System.IO.StreamReader(textBox1.Text.ToString());
                baglanti.Open();
                while ((line = KaynakDosya.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        OleDbCommand komut = new OleDbCommand("INSERT INTO firma(firmaTamAd,telNo,adres,username,passwd,kurulusTarih) VALUES('" + line.Replace(filedelimiter, "','") + "')", baglanti);
                        komut.ExecuteNonQuery();
                    }
                    counter++;
                }

                KaynakDosya.Close();
                baglanti.Close();
                comboBoxlarıGuncelle();
                MessageBox.Show("Toplu eklemeler başarıyla tamamlandı.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //seçilen dosyayı textboxa yazdırma
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.Title = "Bir txt dosyası seçiniz.";
            openDialog.InitialDirectory = Application.StartupPath;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openDialog.FileName.ToString();
            }
            openDialog.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //verilen konumdaki txt deki verileri veritabanına ekleme
            try
            {
                System.IO.StreamReader KaynakDosya = new System.IO.StreamReader(textBox2.Text.ToString());
                baglanti.Open();
                while ((line = KaynakDosya.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        OleDbCommand komut = new OleDbCommand("INSERT INTO musteri(adSoyad,telNo,adres,username,passwd,dgTarih) VALUES('" + line.Replace(filedelimiter, "','") + "')", baglanti);
                        komut.ExecuteNonQuery();
                    }
                    counter++;
                }

                KaynakDosya.Close();
                baglanti.Close();
                comboBoxlarıGuncelle();
                MessageBox.Show("Toplu eklemeler başarıyla tamamlandı.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
