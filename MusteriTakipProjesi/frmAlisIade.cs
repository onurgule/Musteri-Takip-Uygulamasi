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
    public partial class frmAlisIade : Form
    {
        public frmAlisIade()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        public string ad; public int sabitid; public string islem;
        public int id = -1;
        double ilkfiyat = 0;
        private void frmSatis_Load(object sender, EventArgs e)
        {
            dateTarih.DateTime = DateTime.Now.Date;
            dateVade.DateTime = DateTime.Now.Date;
            if (id == -1)
            {
                AciklamaYenile();
                BirimYenile();
                lblAd.Text = ad;
            }
            else
            {
                AciklamaYenile();
                BirimYenile();
                lblAd.Text = ad;
                IdliYenile();
            }
            

        }
        void IdliYenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Alislar WHERE AlisID=@id", conn);
            cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sabitid = Convert.ToInt16(dr["MusteriID"]);
                dateTarih.EditValue = Convert.ToDateTime(dr["Tarih"]);
                dateVade.EditValue = Convert.ToDateTime(dr["Vade"]);
                txtEvrakNo.Text = Convert.ToString(dr["EvrakNo"]);
                cbAciklama.SelectedValue = Convert.ToInt16(dr["AciklamaID"]);
                txtFiyat.Text = Convert.ToDouble(dr["Fiyat"]).ToString();
                txtMiktar.Text = Convert.ToDouble(dr["Miktar"]).ToString();
            }
            if (conn.State == ConnectionState.Open) conn.Close();
            ilkfiyat = Convert.ToDouble(txtTutar.Text);
        }

        public void AciklamaYenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Aciklamalar", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbAciklama.DataSource = dt;
            cbAciklama.ValueMember = "AciklamaID";
            cbAciklama.DisplayMember = "Aciklama";
        }

        public void BirimYenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Birimler", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbBirim.DataSource = dt;
            cbBirim.ValueMember = "BirimID";
            cbBirim.DisplayMember = "Birim";
        }

        private void btnAciklamaEkle_Click(object sender, EventArgs e)
        {
            frmAciklamaEkle aciklama = new frmAciklamaEkle();
            aciklama.gelinenform = this;
            aciklama.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmSatis_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna ana = (frmAna)Application.OpenForms["frmAna"];
            ana.Yenile();
            if (Application.OpenForms["frmMusteriHareket"] != null)
            {
                frmMusteriHareket mh = (frmMusteriHareket)Application.OpenForms["frmMusteriHareket"];
                mh.BakiyeYenile();
            }
        }

        private void btnBirimEkle_Click(object sender, EventArgs e)
        {
            frmBirimEkle birim = new frmBirimEkle();
            birim.gelinenform = this;
            birim.ShowDialog();
        }

        private void txtMiktar_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMiktar.Text != "" && txtFiyat.Text != "")
            {
                double miktar = Convert.ToDouble(txtMiktar.Text);
                double fiyat = Convert.ToDouble(txtFiyat.Text);
                double tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
            }
        }

        private void txtFiyat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMiktar.Text != "" && txtFiyat.Text != "")
            {
                double miktar = Convert.ToDouble(txtMiktar.Text);
                double fiyat = Convert.ToDouble(txtFiyat.Text);
                double tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        genelMT gmt = new genelMT();
        void Kaydet()
        {
            if (txtEvrakNo.Text != "" && txtTutar.Text != "" && id == -1)
            {
                double ilkbakiye = gmt.BakiyeCek(sabitid, conn);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Alislar(MusteriID,EvrakNo,Tarih,Vade,AciklamaID,Miktar,BirimID,Fiyat,Tutar,Tur,SonBakiye) VALUES(@MusteriID,@EvrakNo,@Tarih,@Vade,@AciklamaID,@Miktar,@BirimID,@Fiyat,@Tutar,1,@SonBakiye)", conn);
            cmd.Parameters.Add("@MusteriID", OleDbType.Integer).Value = sabitid;
            cmd.Parameters.Add("@EvrakNo", OleDbType.VarChar).Value = txtEvrakNo.Text; 
                cmd.Parameters.Add("@Tarih", OleDbType.Date).Value = Convert.ToDateTime(dateTarih.DateTime.ToShortDateString());
            cmd.Parameters.Add("@Vade", OleDbType.Date).Value = Convert.ToDateTime(dateVade.DateTime.ToShortDateString());
            cmd.Parameters.Add("@AciklamaID", OleDbType.Integer).Value = Convert.ToInt16(cbAciklama.SelectedValue);
            cmd.Parameters.Add("@Miktar", OleDbType.Double).Value = Convert.ToDouble(txtMiktar.Text);
            cmd.Parameters.Add("@BirimID", OleDbType.Integer).Value = Convert.ToInt16(cbBirim.SelectedValue);
            cmd.Parameters.Add("@Fiyat", OleDbType.Double).Value = Convert.ToDouble(txtFiyat.Text);
            cmd.Parameters.Add("@Tutar", OleDbType.Double).Value = Convert.ToDouble(txtMiktar.Text) * Convert.ToDouble(txtFiyat.Text);
            cmd.Parameters.Add("@SonBakiye", OleDbType.Double).Value = Convert.ToDouble(txtMiktar.Text) * Convert.ToDouble(txtFiyat.Text) + ilkbakiye;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE Musteriler SET DevirBakiye=DevirBakiye+@yenibakiye WHERE SabitID=@sabit";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@yenibakiye", OleDbType.Double).Value = Convert.ToDouble(txtMiktar.Text) * Convert.ToDouble(txtFiyat.Text);
            cmd.Parameters.Add("@sabit", OleDbType.Integer).Value = sabitid;
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            MessageBox.Show("Alış iade edildi!");
            this.Close();
            }
            else if (txtEvrakNo.Text != "" && txtTutar.Text != "" && id != -1)
            {
                double ilkbakiye = gmt.BakiyeCek(sabitid, conn);
                OleDbCommand cmd = new OleDbCommand("UPDATE Alislar SET EvrakNo=@EvrakNo,Tarih=@Tarih,Vade=@Vade,AciklamaID=@AciklamaID,Tutar=@Tutar,Miktar=@Miktar,Fiyat=@Fiyat,SonBakiye=@SonBakiye WHERE AlisID=@alisid", conn);
                cmd.Parameters.Add("@EvrakNo", OleDbType.VarChar).Value = txtEvrakNo.Text;
                cmd.Parameters.Add("@Tarih", OleDbType.Date).Value = Convert.ToDateTime(dateTarih.DateTime.ToShortDateString());
                cmd.Parameters.Add("@Vade", OleDbType.Date).Value = Convert.ToDateTime(dateVade.DateTime.ToShortDateString());
                cmd.Parameters.Add("@AciklamaID", OleDbType.Integer).Value = Convert.ToInt16(cbAciklama.SelectedValue);
                cmd.Parameters.Add("@Tutar", OleDbType.Double).Value = Convert.ToDouble(txtTutar.Text);
                cmd.Parameters.Add("@Miktar", OleDbType.Double).Value = Convert.ToDouble(txtMiktar.Text);
                cmd.Parameters.Add("@Fiyat", OleDbType.Double).Value = Convert.ToDouble(txtFiyat.Text);
                cmd.Parameters.Add("@SonBakiye", OleDbType.Double).Value = (Convert.ToDouble(txtTutar.Text) - ilkfiyat) + ilkbakiye;
                cmd.Parameters.Add("@alisid", OleDbType.Integer).Value = id;
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE Musteriler SET DevirBakiye=DevirBakiye+ @yenibakiye WHERE SabitID=@sabit";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@yenibakiye", OleDbType.Double).Value = (Convert.ToDouble(txtTutar.Text) - ilkfiyat);
                cmd.Parameters.Add("@sabit", OleDbType.Integer).Value = sabitid;
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gerekli boş alanları doldurunuz!");
            }
        }
    }
}
