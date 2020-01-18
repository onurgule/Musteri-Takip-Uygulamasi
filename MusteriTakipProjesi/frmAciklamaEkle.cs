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
    public partial class frmAciklamaEkle : Form
    {
        public Form gelinenform;
        public frmAciklamaEkle()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        void Yenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Aciklamalar",conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lbIslemler.DataSource = dt;
            lbIslemler.ValueMember = "AciklamaID";
            lbIslemler.DisplayMember = "Aciklama";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkle.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Aciklamalar(Aciklama) VALUES(@aciklama)", conn);
                cmd.Parameters.Add("@aciklama", OleDbType.VarChar).Value = txtEkle.Text;
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
                Yenile();
            }
            else
            {
                MessageBox.Show("Açıklama girilmedi!");
            }
            
        }

        private void frmAciklamaEkle_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE * FROM Aciklamalar WHERE AciklamaID =@id",conn);
            cmd.Parameters.Add("@id", OleDbType.Integer).Value = lbIslemler.SelectedValue;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            Yenile();
        }

        private void frmAciklamaEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gelinenform.Name == "frmSatis")
            {
                frmSatis satis = (frmSatis)Application.OpenForms["frmSatis"];
                satis.AciklamaYenile();
            }
            else if(gelinenform.Name == "frmAlis")
            {
                frmAlis alis = (frmAlis)Application.OpenForms["frmAlis"];
                alis.AciklamaYenile();
            }
            else if (gelinenform.Name == "frmAlisIade")
            {
                frmAlisIade alisIade = (frmAlisIade)Application.OpenForms["frmAlisIade"];
                alisIade.AciklamaYenile();
            }
            else if (gelinenform.Name == "frmOdeme")
            {
                frmOdeme odeme = (frmOdeme)Application.OpenForms["frmOdeme"];
                odeme.Yenile();
            }
           
            else if (gelinenform.Name == "frmTahsilat")
            {
                frmTahsilat tahsilat = (frmTahsilat)Application.OpenForms["frmTahsilat"];
                tahsilat.Yenile();
            }
            else if (gelinenform.Name == "frmSatisIade")
            {
                frmSatisIade satisiade = (frmSatisIade)Application.OpenForms["frmSatisIade"];
                satisiade.AciklamaYenile();
            }
           
            //BURAYI GELENE GORE DUZENLE:
        }
    }
}
