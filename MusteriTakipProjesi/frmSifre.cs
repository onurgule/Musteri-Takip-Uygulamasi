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

namespace MusteriTakipProjesi
{
    public partial class frmSifre : Form
    {
        public frmSifre()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        void SifreKontrol()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT FirmaUnvan FROM Ayarlar WHERE Sifre=@sifre",conn);
            cmd.Parameters.Add("@sifre", OleDbType.VarChar).Value = txtEskiSifre.Text;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                SifreDegistir();
            }
            else
            {
                MessageBox.Show("Eski şifre hatalı!");
            }
            if (conn.State == ConnectionState.Open) conn.Close();
            
        }
        void SifreDegistir()
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE Ayarlar SET Sifre=@sifre",conn);
            cmd.Parameters.Add("@sifre", OleDbType.VarChar).Value = txtYeniSifre.Text;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            MessageBox.Show("Şifre başarıyla değiştirildi!");
            this.Close();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtEskiSifre.Text == "")
            {
                MessageBox.Show("Eski şifreyi giriniz.");
            }
            else
            {
                if(txtYeniSifre.Text != "" && txtYeniSifreD.Text == txtYeniSifre.Text)
                {
                    SifreKontrol();
                }
                else
                {
                    MessageBox.Show("Yeni şifre boş veya birbiriyle uyuşmuyor.");
                }
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
