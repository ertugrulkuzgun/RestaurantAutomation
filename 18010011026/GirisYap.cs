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
    public partial class GirisYap : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        public static string id;
        public static bool kontrolMusteri = false;
        public static bool kontrolFirma = false;
        public static bool kontrolAdmin = false;
        public static bool girisGenelKontrol = false;
        public GirisYap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            girisGenelKontrol = false;
            kontrolMusteri = false;
            kontrolAdmin = false;
            kontrolFirma = false;
            if (radioButton1.Checked == true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from musteri", baglanti);
                OleDbDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if(dr["username"].ToString() == textBox1.Text && dr["passwd"].ToString() == textBox2.Text)
                    {
                        kontrol = true;
                        kontrolMusteri = true;
                        kontrolAdmin = false;
                        kontrolFirma = false;
                        girisGenelKontrol = true;
                        id = dr.GetValue(6).ToString();
                        Form1.idAnasayfa = id;
                        MessageBox.Show("Giriş Başarılı!");
                        this.Close();
                        break;
                    }
                }
                if(kontrol == false)
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış", "Müşteri Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            if(radioButton2.Checked == true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from firma", baglanti);
                OleDbDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if(dr["username"].ToString()==textBox1.Text && dr["passwd"].ToString() == textBox2.Text)
                    {
                        kontrol = true;
                        kontrolFirma = true;
                        kontrolAdmin = false;
                        kontrolMusteri = false;
                        girisGenelKontrol = true;
                        id = dr.GetValue(6).ToString();
                        Form1.idAnasayfa = id;
                        MessageBox.Show("Giriş Başarılı!");
                        this.Close();
                        break;
                    }
                }
                if(kontrol == false)
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış", "Firma Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            if(radioButton3.Checked == true)
            {
                if(textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    kontrol = true;
                    kontrolAdmin = true;
                    kontrolFirma = false;
                    kontrolMusteri = false;
                    girisGenelKontrol = true;
                    MessageBox.Show("Giriş Başarılı!");
                    this.Close();
                }
                if(kontrol == false)
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış", "Admin Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
