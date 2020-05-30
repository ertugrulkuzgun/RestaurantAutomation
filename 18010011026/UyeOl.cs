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

namespace _18010011026
{
    public partial class UyeOl : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        OleDbCommand komut = new OleDbCommand();
        public UyeOl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UyeOl_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                dateTimePicker1.Enabled = true;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            if(radioButton2.Checked == true)
            {
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool varMıYokMU = false;
            if(radioButton1.Checked == true)           
            {
                try
                {
                    if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text)
                && string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text))
                        MessageBox.Show("Bu alanlar boş geçilemez...");
                    else
                    {
                        baglanti.Open();
                        OleDbCommand komut = new OleDbCommand("select * from musteri", baglanti);
                        OleDbDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["username"].ToString() == textBox4.Text)
                            {
                                varMıYokMU = true;
                            }
                        }
                        baglanti.Close();
                        if(varMıYokMU == false)
                        {
                            //bura
                            DateTime dt = dateTimePicker1.Value;
                            komut.Connection = baglanti;
                            komut.CommandText = "INSERT INTO musteri(adSoyad,telNo,adres,username,passwd,dgTarih) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dt.ToShortDateString() + "')";
                            baglanti.Open();
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglanti.Close();
                            MessageBox.Show("Kayıt Tamamlandı!");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            this.Close();
                            //bura if içerisine alınacak
                        }
                        else
                        {
                            MessageBox.Show("Bu kullanıcı isminde kayıt bulunmaktadır. Başka kullanıcı adı seçiniz.");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            if(radioButton2.Checked == true)
            {
                try
                {
                    if (string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrEmpty(textBox8.Text)
                && string.IsNullOrEmpty(textBox9.Text) && string.IsNullOrEmpty(textBox10.Text))
                        MessageBox.Show("Bu alanlar boş geçilemez...");
                    else
                    {
                        baglanti.Open();
                        OleDbCommand komut = new OleDbCommand("select * from firma", baglanti);
                        OleDbDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["username"].ToString() == textBox9.Text)
                            {
                                varMıYokMU = true;
                            }
                        }
                        baglanti.Close();
                        if (varMıYokMU == false)
                        {                           
                            DateTime dt = dateTimePicker1.Value;
                            komut.Connection = baglanti;
                            komut.CommandText = "INSERT INTO firma(firmaTamAd,telNo,adres,username,passwd,kurulusTarih) VALUES('" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + dt.ToShortDateString() + "')";
                            baglanti.Open();
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglanti.Close();
                            MessageBox.Show("Kayıt Tamamlandı!");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Bu kullanıcı isminde kayıt bulunmaktadır. Başka kullanıcı adı seçiniz.");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
