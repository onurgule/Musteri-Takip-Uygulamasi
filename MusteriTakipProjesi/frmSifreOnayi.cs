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
    public partial class frmSifreOnayi : Form
    {
        public frmSifreOnayi()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        public string islem = "";
        private void btnTamam_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT FirmaUnvan FROM Ayarlar WHERE Sifre=@sifre",conn);
            cmd.Parameters.Add("@sifre", OleDbType.VarChar).Value = txtSifre.Text;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                frmAna ana = (frmAna)Application.OpenForms["frmAna"]; //Olumlu
                this.Close();
                if(islem == "GeriYukle")
                ana.GeriYukle();
                if (islem == "AyarlarXML")
                    ana.AyarlarXMLOlustur();
                if (islem == "MusterilerXML")
                    ana.MusterilerXMLOlustur();
            }
            else
            {
                MessageBox.Show("Şifre yanlış girildi!");
            }
            if (conn.State == ConnectionState.Open) conn.Close();
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
