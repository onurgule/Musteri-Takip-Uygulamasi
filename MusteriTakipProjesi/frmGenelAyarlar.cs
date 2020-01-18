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
    public partial class frmGenelAyarlar : Form
    {
        public frmGenelAyarlar()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        
        private void frmGenelAyarlar_Load(object sender, EventArgs e)
        {
            VergiDaireGetir();
            AyarDoldur();
        }
        void AyarDoldur()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ayarlar", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtUnvan.Text = Convert.ToString(dr["FirmaUnvan"]);
                txtYetkili.Text = Convert.ToString(dr["Yetkili"]);
                txtTelefon.Text = Convert.ToString(dr["Telefon"]);
                txtFax.Text = Convert.ToString(dr["Fax"]);
                txtAdres.Text = Convert.ToString(dr["Adres"]);
                txtOdemeYeri.Text = Convert.ToString(dr["OdemeYeri"]);
                cbVergiDairesi.Text = Convert.ToString(dr["VergiDairesi"]);
                txtVergiNo.Text = Convert.ToString(dr["VergiNo"]);
                txtYedekYolu.Text = Convert.ToString(dr["YedekYolu"]);
                if (Convert.ToInt16(dr["OtoYedek"]) == 1) cbOtoYedek.Checked = true;
                else if (Convert.ToInt16(dr["OtoYedek"]) == 0) cbOtoYedek.Checked = false;
            }
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        void VergiDaireGetir()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT VergiDaireID, REPLACE(STR(VergiDaireID), ' ', '') +' ' + Sehir + ' ' + VergiDairesi AS Ad FROM VergiDaireleri WHERE VergiDaireID<>null", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbVergiDairesi.DataSource = dt;
            cbVergiDairesi.ValueMember = "VergiDaireID";
            cbVergiDairesi.DisplayMember = "Ad";
        }
        private void btnGozat_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if(fbd.SelectedPath != "")
            {
                txtYedekYolu.Text = fbd.SelectedPath;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE Ayarlar SET FirmaUnvan=@firmaunvan, Yetkili=@yetkili, Telefon=@telefon, Fax=@fax, Adres=@adres, OdemeYeri=@odemeyeri, VergiDairesi=@vergidairesi, VergiNo=@vergino, YedekYolu=@yedekyolu, OtoYedek=@otoyedek",conn);
            cmd.Parameters.Add("@firmaunvan", OleDbType.VarChar).Value = txtUnvan.Text;
            cmd.Parameters.Add("@yetkili", OleDbType.VarChar).Value = txtYetkili.Text;
            cmd.Parameters.Add("@telefon", OleDbType.VarChar).Value = txtTelefon.Text;
            cmd.Parameters.Add("@fax", OleDbType.VarChar).Value = txtFax.Text;
            cmd.Parameters.Add("@adres", OleDbType.VarChar).Value = txtAdres.Text;
            cmd.Parameters.Add("@odemeyeri", OleDbType.VarChar).Value = txtOdemeYeri.Text;
            cmd.Parameters.Add("@vergidairesi", OleDbType.VarChar).Value = cbVergiDairesi.Text;
            cmd.Parameters.Add("@vergino", OleDbType.VarChar).Value = txtVergiNo.Text;
            cmd.Parameters.Add("@yedekyolu", OleDbType.VarChar).Value = txtYedekYolu.Text;
            if(cbOtoYedek.Checked == true)
            cmd.Parameters.Add("@otoyedek", OleDbType.VarChar).Value = 1;
            else if(cbOtoYedek.Checked == false)
            cmd.Parameters.Add("@otoyedek", OleDbType.VarChar).Value = 0;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            MessageBox.Show("Bilgiler Kaydedildi!");
            this.Close();
        }

        private void cbOtoYedek_CheckedChanged(object sender, EventArgs e)
        {
            if(txtYedekYolu.Text != "")
            {

            }
            else
            {
                if (cbOtoYedek.Checked == true)
                {
                    MessageBox.Show("Yedek yolu boş olamaz!", "Yedek Yolu Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbOtoYedek.Checked = false;
                }
            }
        }
    }
}
