using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18010011026
{
    public partial class Form1 : Form
    {
        public static string idAnasayfa;
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        public Form childForm = new Form();

        private void disableButtons()
        {
            button9.Enabled = false;
            button7.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button8.Enabled = false;
            button10.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button15.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disableButtons();
            button7.Enabled = false;
        }

        private void customizeDesign()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
            if (panel2.Visible == true)
                panel2.Visible = false;
            if (panel3.Visible == true)
                panel3.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnUye_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            childForm = new GirisYap();
            openChildForm();
            //kodlar buraya
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            childForm = new UyeOl();
            openChildForm();
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            childForm = new RestoranListele();
            openChildForm();
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            childForm = new YemekListele();
            openChildForm();
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }
        private Form activeForm = null;
        private void openChildForm()
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text ="Saat: " + DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;

            if(GirisYap.girisGenelKontrol == true)
            {
                
                button2.Enabled = false;
                button3.Enabled = false;
                button7.Enabled = true;
                if (GirisYap.kontrolMusteri == true)
                {
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button12.Enabled = true;
                    button13.Enabled = true;                
                }

                if (GirisYap.kontrolFirma == true)
                {
                    button8.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                    button15.Enabled = true;
                }

                if (GirisYap.kontrolAdmin == true)
                {
                    button9.Enabled = true;
                }
            }
            
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GirisYap.girisGenelKontrol = false;
            GirisYap.kontrolAdmin = false;
            GirisYap.kontrolFirma = false;
            GirisYap.kontrolMusteri = false;
            idAnasayfa = null;
            disableButtons();
            hideSubMenu();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            childForm = new KullanıcıProfil();
            openChildForm();
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            childForm = new MusteriGecmisSiparis();
            openChildForm();
            hideSubMenu();
        }

        

        private void btnFirma_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            childForm = new FirmaProfil();
            openChildForm();
            hideSubMenu();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            childForm = new FirmaUrunListeleme();
            openChildForm();
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            childForm = new FirmaGelenSiparisler();
            openChildForm();
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            childForm = new IletisimeGecin();
            openChildForm();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            childForm = new AdminPanel();
            openChildForm();
        }

        private void btnAnaMenu_Click_1(object sender, EventArgs e)
        {
            childForm.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            childForm = new YemekEkle();
            openChildForm();
            hideSubMenu();
        }
    }
}
