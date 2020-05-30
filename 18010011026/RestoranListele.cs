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
    public partial class RestoranListele : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\proje.accdb");
        DataTable dt = new DataTable();
        OleDbDataReader dr;
        string dtgvSecili;
        string firmaID;
        string urunID;
        string urunAd;
        string resimSakla;
        public RestoranListele()
        {
            InitializeComponent();
        }

        private void RestoranListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter firmaListele = new OleDbDataAdapter("SELECT firmaTamAd AS[Restoran] FROM firma", baglanti); 
            firmaListele.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Restoran LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                dtgvSecili = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Restoran"].Value);
                OleDbCommand komut = new OleDbCommand("SELECT * FROM firma WHERE firmaTamAd = '" + dtgvSecili + "'", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    firmaID = dr["id"].ToString();
                }
                baglanti.Close();
                baglanti.Open();
                OleDbDataAdapter urun_listele = new OleDbDataAdapter("SELECT yemekAdi AS[Yemek Adı],fiyat AS[Fiyat] FROM urunler WHERE firmaID = " + firmaID + "", baglanti);
                DataTable dt = new DataTable();
                urun_listele.Fill(dt);
                dataGridView2.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                urunAd = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Yemek Adı"].Value);
                OleDbCommand komut = new OleDbCommand("SELECT * FROM urunler WHERE yemekAdi = '" + urunAd + "'", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    urunID = dr["id"].ToString();
                    resimSakla = dr["yemekResim"].ToString();
                }
                baglanti.Close();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = resimSakla;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
