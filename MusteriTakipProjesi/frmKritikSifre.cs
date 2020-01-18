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
    public partial class frmKritikSifre : Form
    {
        public frmKritikSifre()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        public Form formu=null;
        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (formu != null)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT FirmaUnvan FROM Ayarlar WHERE Sifre=@sifre", conn);
                cmd.Parameters.Add("@sifre", OleDbType.VarChar).Value = txtSifre.Text;
                if (conn.State == ConnectionState.Closed) conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (formu.Name == "frmTumIslemlerRaporListele")
                    {
                        frmTumIslemlerRaporListele _listele = (frmTumIslemlerRaporListele)Application.OpenForms["frmTumIslemlerRaporListele"];
                        _listele.kilitacik = true;
                    }
                    else if (formu.Name == "frmMusteriHareket")
                    {
                        frmMusteriHareket _hareket = (frmMusteriHareket)Application.OpenForms["frmMusteriHareket"];
                        _hareket.kilitacik = true;
                    }
                }
                else
                {
                    MessageBox.Show("Şifre yanlış girildi!");
                    if (formu.Name == "frmTumIslemlerRaporListele")
                    {
                        frmTumIslemlerRaporListele _listele = (frmTumIslemlerRaporListele)Application.OpenForms["frmTumIslemlerRaporListele"];
                        _listele.kilitacik = false;
                    }
                    else if (formu.Name == "frmMusteriHareket")
                    {
                        frmMusteriHareket _hareket = (frmMusteriHareket)Application.OpenForms["frmMusteriHareket"];
                        _hareket.kilitacik = false;
                    }
                }
                if (conn.State == ConnectionState.Open) conn.Close();
                this.Close();
            }
        }

        private void frmKritikSifre_Load(object sender, EventArgs e)
        {

        }
    }
}
