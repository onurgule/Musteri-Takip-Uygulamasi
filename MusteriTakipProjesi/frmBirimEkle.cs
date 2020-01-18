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
    public partial class frmBirimEkle : Form
    {
        public Form gelinenform;
        public frmBirimEkle()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        void Yenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Birimler",conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lbIslemler.DataSource = dt;
            lbIslemler.ValueMember = "BirimID";
            lbIslemler.DisplayMember = "Birim";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (txtEkle.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Birimler(Birim) VALUES(@birim)", conn);
                cmd.Parameters.Add("@birim", OleDbType.VarChar).Value = txtEkle.Text;
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
                Yenile();
            }
            else
            {
                MessageBox.Show("Birim boş olduğundan ekleme başarısız!");
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
            OleDbCommand cmd = new OleDbCommand("DELETE * FROM Birimler WHERE BirimID =@id",conn);
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
                satis.BirimYenile();
            }
            else if (gelinenform.Name == "frmAlis")
            {
                frmAlis alis = (frmAlis)Application.OpenForms["frmAlis"];
                alis.BirimYenile();
            }
            else if (gelinenform.Name == "frmAlisIade")
            {
                frmAlisIade alisIade = (frmAlisIade)Application.OpenForms["frmAlisIade"];
                alisIade.BirimYenile();
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
                satisiade.BirimYenile();
            }
           
        }
    }
}
