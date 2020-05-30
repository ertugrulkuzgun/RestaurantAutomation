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
    public partial class FirmaUrunListeleme : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        OleDbDataReader dr;
        string id;
        public static string _resimsakla;
        public FirmaUrunListeleme()
        {
            InitializeComponent();
        }

        private void dataGridViewGuncelle()
        {
            try
            {
                baglanti.Open();
                //datagridview sıfırlama
                dataGridView1.DataSource = null;
                //veri girişi
                OleDbDataAdapter urun_listele = new OleDbDataAdapter("SELECT yemekAdi AS[Yemek Adı],fiyat AS[Fiyat],id FROM urunler WHERE firmaID = " + Form1.idAnasayfa + "", baglanti);
                DataSet dshafiza = new DataSet();
                urun_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //ürün güncelleme
                OleDbCommand komut = new OleDbCommand("UPDATE urunler SET yemekAdi=@p1,fiyat=@p2,yemekResim=@p3 WHERE id=" + id + "", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                dataGridViewGuncelle();
                MessageBox.Show("Ürün güncellenmiştir.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FirmaUrunListeleme_Load(object sender, EventArgs e)
        {
            dataGridViewGuncelle();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                //seçili satırın verilerinin textboxlara ve pictureboxa yerleştirilmesi
                textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Yemek Adı"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Fiyat"].Value);
                id = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT yemekResim FROM urunler WHERE id = " + id + "", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    textBox3.Text = dr["yemekResim"].ToString();
                }
                baglanti.Close();
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.ImageLocation = textBox3.Text;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("DELETE FROM urunler WHERE id=" + id + "", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                dataGridViewGuncelle();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                pictureBox4.ImageLocation = null;
                MessageBox.Show("Ürün listenizden silinmiştir.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
