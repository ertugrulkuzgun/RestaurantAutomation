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
    public partial class KullanıcıProfil : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        OleDbDataReader dr;
        public KullanıcıProfil()
        {
            InitializeComponent();
        }

        private void KullanıcıProfil_Load(object sender, EventArgs e)
        {
            //musterilerinin bilgilerinin textboxta gösterilmesi
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM musteri WHERE id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", Form1.idAnasayfa);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr.GetValue(0).ToString();
                    textBox2.Text = dr.GetValue(1).ToString();
                    textBox3.Text = dr.GetValue(2).ToString();
                    textBox4.Text = dr.GetValue(3).ToString();
                    textBox5.Text = dr.GetValue(4).ToString();
                }
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //musterilerin bilgilerinin veritabanında güncellenmesi
            try
            {
                OleDbCommand komut = new OleDbCommand("UPDATE musteri SET adSoyad=@p1,telNo=@p2,adres=@p3,username=@p4,passwd=@p5 WHERE id=" + Form1.idAnasayfa + "",baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", textBox4.Text);
                komut.Parameters.AddWithValue("@p5", textBox5.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bilgileriniz güncellenmiştir.");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
