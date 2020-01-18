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
    public partial class frmOdeme : Form
    {
        public frmOdeme()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        public string ad; public int sabitid; public string islem;
        public int id = -1;
        double ilkfiyat = 0;
        genelMT gmt = new genelMT();
        private void frmOdeme_Load(object sender, EventArgs e)
        {
            dateTarih.DateTime = DateTime.Now.Date;
            dateVade.DateTime = DateTime.Now.Date;
            if (id == -1)
            {
                Yenile();
                lblAd.Text = ad;
            }
            else
            {
                Yenile();
                lblAd.Text = ad;
                IdliYenile();
            }
        }
        void IdliYenile()
        {
            if (id != -1)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Odemeler WHERE OdemeID=@id", conn);
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
                    txtTutar.Text = Convert.ToDouble(dr["Tutar"]).ToString();
                }
                if (conn.State == ConnectionState.Open) conn.Close();
                ilkfiyat = Convert.ToDouble(txtTutar.Text);
            }
        }
        public void Yenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Aciklamalar", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbAciklama.DataSource = dt;
            cbAciklama.ValueMember = "AciklamaID";
            cbAciklama.DisplayMember = "Aciklama";
        }

        private void btnAciklamaEkle_Click(object sender, EventArgs e)
        {
            frmAciklamaEkle aciklama = new frmAciklamaEkle();
            aciklama.gelinenform = this;
            aciklama.ShowDialog();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        void Kaydet()
        {
            if (txtEvrakNo.Text != "" && txtTutar.Text != "" && id == -1)
            {
                double ilkbakiye = gmt.BakiyeCek(sabitid, conn);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Odemeler(MusteriID,EvrakNo,Tarih,Vade,AciklamaID,Tutar,SonBakiye) VALUES(@MusteriID,@EvrakNo,@Tarih,@Vade,@AciklamaID,@Tutar,@SonBakiye)", conn);
            cmd.Parameters.Add("@MusteriID", OleDbType.Integer).Value = sabitid;
            cmd.Parameters.Add("@EvrakNo", OleDbType.VarChar).Value = txtEvrakNo.Text; 
            cmd.Parameters.Add("@Tarih", OleDbType.Date).Value = Convert.ToDateTime(dateTarih.DateTime.ToShortDateString());
            cmd.Parameters.Add("@Vade", OleDbType.Date).Value = Convert.ToDateTime(dateVade.DateTime.ToShortDateString());
            cmd.Parameters.Add("@AciklamaID", OleDbType.Integer).Value = Convert.ToInt16(cbAciklama.SelectedValue);
            cmd.Parameters.Add("@Tutar", OleDbType.Double).Value = Convert.ToDouble(txtTutar.Text);
            cmd.Parameters.Add("@SonBakiye", OleDbType.Double).Value = Convert.ToDouble(txtTutar.Text) + ilkbakiye;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE Musteriler SET DevirBakiye=DevirBakiye+@yenibakiye WHERE SabitID=@sabit";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@yenibakiye", OleDbType.Double).Value = Convert.ToDouble(txtTutar.Text);
            cmd.Parameters.Add("@sabit", OleDbType.Integer).Value = sabitid;
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            MessageBox.Show("Ödeme Eklendi!");
            this.Close();
            }
            else if (txtEvrakNo.Text != "" && txtTutar.Text != "" && id != -1)
            {
                double ilkbakiye = gmt.BakiyeCek(sabitid, conn);
                OleDbCommand cmd = new OleDbCommand("UPDATE Odemeler SET EvrakNo=@EvrakNo,Tarih=@Tarih,Vade=@Vade,AciklamaID=@AciklamaID,Tutar=@Tutar,SonBakiye=@SonBakiye WHERE OdemeID=@odemeid", conn);
                cmd.Parameters.Add("@EvrakNo", OleDbType.VarChar).Value = txtEvrakNo.Text;
                cmd.Parameters.Add("@Tarih", OleDbType.Date).Value = Convert.ToDateTime(dateTarih.DateTime.ToShortDateString());
                cmd.Parameters.Add("@Vade", OleDbType.Date).Value = Convert.ToDateTime(dateVade.DateTime.ToShortDateString());
                cmd.Parameters.Add("@AciklamaID", OleDbType.Integer).Value = Convert.ToInt16(cbAciklama.SelectedValue);
                cmd.Parameters.Add("@Tutar", OleDbType.Double).Value = Convert.ToDouble(txtTutar.Text);
                cmd.Parameters.Add("@SonBakiye", OleDbType.Double).Value = (Convert.ToDouble(txtTutar.Text) - ilkfiyat) + ilkbakiye;
                cmd.Parameters.Add("@odemeid", OleDbType.Integer).Value = id;
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

        private void frmOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna ana = (frmAna)Application.OpenForms["frmAna"];
            ana.Yenile();

            if(Application.OpenForms["frmMusteriHareket"] != null)
            {
                frmMusteriHareket mh = (frmMusteriHareket)Application.OpenForms["frmMusteriHareket"];
                mh.BakiyeYenile();
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
