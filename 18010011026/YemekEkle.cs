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
    public partial class YemekEkle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        public static string _resimsakla;
        public YemekEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Resim dosyaları |*.jpg;*.jpeg;*.gif;*.bmp;" +
                "*.png;*ico|JPEG Files ( *.jpg;*.jpeg )|*.jpg;*.jpeg|GIF Files ( *.gif )|*.gif|BMP Files ( *.bmp )" +
                "|*.bmp|PNG Files ( *.png )|*.png|Icon Files ( *.ico )|*.ico";
            openDialog.Title = "Resim seçiniz.";
            openDialog.InitialDirectory = Application.StartupPath + @"\\DataPicture\";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _resimsakla = openDialog.FileName.ToString();
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.ImageLocation = _resimsakla;
                textBox3.Text = _resimsakla;
            }
            openDialog.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text))
                    MessageBox.Show("Bu alanlar boş geçilemez.");
                else
                {
                    //
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("INSERT INTO urunler(yemekAdi,fiyat,firmaID,yemekResim) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + Form1.idAnasayfa + "','" + textBox3.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Yemek Listenize Eklendi...");
                    this.Close();
                    //
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
