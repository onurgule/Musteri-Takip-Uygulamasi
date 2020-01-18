using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriTakipProjesi
{
    public partial class frmMusteriKarti : Form
    {
        public int sabitid = -1;
        public int mid = -1;
        public frmMusteriKarti()
        {
            InitializeComponent();
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            DosyadanResim();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.gelenform = this;
            cam.ShowDialog();
        }
        public void Resmet(Bitmap resim)
        {
            pbResim.Image = resim;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
       
        private void frmMusteriKarti_Load(object sender, EventArgs e)
        {
            GrupGetir();
            VergiDairesiGetir();
            IlCek();
            SinifCek();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Musteriler WHERE SabitID=@sabitid",conn);
            cmd.Parameters.Add("@sabitid", OleDbType.Integer).Value = sabitid;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    byte[] blob = (dr["Resim"] as byte[]);
                    mStream.Write(blob, 0, blob.Length);
                    mStream.Seek(0, SeekOrigin.Begin);
                    if (mStream.Length != 0)
                    {
                        try
                        {
                            Bitmap bm = new Bitmap(mStream);
                            pbResim.Image = bm; //Resmi Çekmiyor - Eğer geri yüklendi ise.
                        }
                        catch (Exception a) { }
                    }
                }

                txtKod.Text = Convert.ToString(dr["MID"]);
                txtAdSoyad.Text = Convert.ToString(dr["AdSoyad"]);
                txtVergiNo.Text = Convert.ToString(dr["VergiNo"]);
                txtTelefon1.Text = Convert.ToString(dr["Telefon1"]);
                txtTelefon2.Text = Convert.ToString(dr["Telefon2"]);
                txtFax.Text = Convert.ToString(dr["Fax"]);
                txtCepTel.Text = Convert.ToString(dr["CepTel"]);
                txtAdres.Text = Convert.ToString(dr["Adres"]);
                txtEmail.Text = Convert.ToString(dr["Email"]);
                txtAciklama.Text = Convert.ToString(dr["Aciklama"]);
                cbGrup.SelectedValue = Convert.ToInt16(dr["GrupNo"]);
                cbVergiDairesi.SelectedValue = Convert.ToInt64(dr["VergiDaireNo"]);
                cbSehir.SelectedValue = Convert.ToInt16(dr["IlID"]);
                IlceCek();
                int ilceid = Convert.ToInt16(dr["IlceID"]);
                cbIlce.SelectedValue = ilceid;
                SemtCek();
                int semtid = Convert.ToInt16(dr["SemtID"]);
                cbSemt.SelectedValue = semtid;
                if (dr["DurumBit"].ToString() == "0") cbDurumu.SelectedIndex = 1;
                else if (dr["DurumBit"].ToString() == "1") cbDurumu.SelectedIndex = 0;
                txtDevirBakiye.Text = dr["DevirBakiye"].ToString();
                if (dr["BorcluOrAlacakli"].ToString() == "Alacaklı") { rbAlacakli.Checked = true; rbBorclu.Checked = false; }
                else if (dr["BorcluOrAlacakli"].ToString() == "Borçlu") { rbBorclu.Checked = true; rbAlacakli.Checked = false; }
                string cins = dr["Cinsiyet"].ToString();
                cbCinsiyet.Text = cins;
                cbSiniflandirma.SelectedValue = Convert.ToInt16(dr["SinifID"]);
                dateDogumGunu.DateTime = Convert.ToDateTime(dr["DogumGunu"]);
                dateEvlilik.DateTime = Convert.ToDateTime(dr["EvlilikYildonum"]);

            }
            conn.Close();
        }
        void SinifCek()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Siniflar WHERE SinifID <>0", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbSiniflandirma.DataSource = dt;
            cbSiniflandirma.ValueMember = "SinifID";
            cbSiniflandirma.DisplayMember = "Sinif";
            cbSiniflandirma.SelectedIndex = -1;
        }
        void VergiDairesiGetir()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT VergiDaireID, REPLACE(STR(VergiDaireID), ' ', '') +' ' + Sehir + ' ' + VergiDairesi AS Ad FROM VergiDaireleri WHERE VergiDaireID<>0", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbVergiDairesi.DataSource = dt;
            cbVergiDairesi.ValueMember = "VergiDaireID";
            cbVergiDairesi.DisplayMember = "Ad";
            cbVergiDairesi.SelectedIndex = -1;
        }
        void GrupGetir()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Gruplar WHERE GrupID <>0", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbGrup.DataSource = dt;
            cbGrup.ValueMember = "GrupID";
            cbGrup.DisplayMember = "GrupAdi";
            cbGrup.SelectedIndex = -1;
        }
        void KodGetir()
        {
            int son = 1;
            OleDbCommand cmd = new OleDbCommand("SELECT MAX(MID) FROM Musteriler", conn);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    son = Convert.ToInt16(dr[0].ToString()) + 1;
                }
                catch (Exception a) { son = 1; }
            }
            conn.Close();
            txtKod.Text = son.ToString();
        }
        void IlCek()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Iller WHERE il_id <> 0 ORDER BY il_ad ASC", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbSehir.DataSource = dt;
            cbSehir.DisplayMember = "il_ad";
            cbSehir.ValueMember = "il_id";
            cbSehir.SelectedIndex = -1;
        }
        void IlceCek()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ilceler WHERE il_id=@ilid AND ilce_id <> 0 ORDER BY ilce_ad ASC", conn);
            cmd.Parameters.Add("@ilid", OleDbType.Integer).Value = Convert.ToInt16(cbSehir.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbIlce.DataSource = dt;
            cbIlce.DisplayMember = "ilce_ad";
            cbIlce.ValueMember = "ilce_id";
            cbIlce.SelectedIndex = -1;
        }
        void SemtCek()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Semtler WHERE ilce_id=@ilceid AND semt_id <> 0 ORDER BY semt_ad ASC", conn);
            cmd.Parameters.Add("@ilceid", OleDbType.Integer).Value = Convert.ToInt16(cbIlce.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbSemt.DataSource = dt;
            cbSemt.DisplayMember = "semt_ad";
            cbSemt.ValueMember = "semt_id";
            cbSemt.SelectedIndex = -1;
        }
        private void barbtnKes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clipboard.SetImage(pbResim.Image);
            pbResim.Image = null;
        }

        private void barbtnKopyala_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clipboard.SetImage(pbResim.Image);
        }

        private void barbtnYapıştır_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pbResim.Image = Clipboard.GetImage();
        }

        private void barbtnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pbResim.Image = null;
        }

        private void barbtnYukle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DosyadanResim();
        }
        void DosyadanResim()
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (od.FileName != "")
            {
                pbResim.ImageLocation = od.FileName;
            }
        }

        private void barbtnKameradanYukle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.gelenform = this;
            cam.ShowDialog();
        }

        private void barbtnFarkliKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Resim Dosyası|*.png";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pbResim.Image.Save(sfd.FileName);
        }

        private void cbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbSehir.Focused)
            {
                return;
            }
            cbSemt.DataSource = null;
            IlceCek();
        }

        private void cbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbIlce.Focused)
            {
                return;
            }
            SemtCek();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE Musteriler SET MID=@MID,AdSoyad=@AdSoyad,GrupNo=@GrupNo,VergiDaireNo=@VergiDaireNo,VergiNo=@VergiNo,Telefon1=@Telefon1,Telefon2=@Telefon2,Fax=@Fax,CepTel=@CepTel,Adres=@Adres,SemtID=@SemtID,IlceID=@IlceID,IlID=@IlID,Email=@Email,Aciklama=@Aciklama,DurumBit=@DurumBit,DevirBakiye=@DevirBakiye,BorcluOrAlacakli=@BorcluOrAlacakli,Cinsiyet=@Cinsiyet,SinifID=@SinifID,DogumGunu=@DogumGunu,EvlilikYildonum=@EvlilikYildonum,Resim=@Resim WHERE SabitID=@sabitid", conn);
            cmd.Parameters.Add("@MID", OleDbType.Integer).Value = Convert.ToInt16(txtKod.Text);
            cmd.Parameters.Add("@AdSoyad", OleDbType.VarChar).Value = txtAdSoyad.Text;
            cmd.Parameters.Add("@GrupNo", OleDbType.Integer).Value = Convert.ToInt16(cbGrup.SelectedValue);
            cmd.Parameters.Add("@VergiDaireNo", OleDbType.Integer).Value = Convert.ToInt32(cbVergiDairesi.SelectedValue);
            cmd.Parameters.Add("@VergiNo", OleDbType.VarChar).Value = txtVergiNo.Text;
            cmd.Parameters.Add("@Telefon1", OleDbType.VarChar).Value = txtTelefon1.Text;
            cmd.Parameters.Add("@Telefon2", OleDbType.VarChar).Value = txtTelefon2.Text;
            cmd.Parameters.Add("@Fax", OleDbType.VarChar).Value = txtFax.Text;
            cmd.Parameters.Add("@CepTel", OleDbType.VarChar).Value = txtCepTel.Text;
            cmd.Parameters.Add("@Adres", OleDbType.VarChar).Value = txtAdres.Text;
            cmd.Parameters.Add("@Semt", OleDbType.Integer).Value = Convert.ToInt16(cbSemt.SelectedValue);
            cmd.Parameters.Add("@Ilce", OleDbType.Integer).Value = Convert.ToInt16(cbIlce.SelectedValue);
            cmd.Parameters.Add("@IlID", OleDbType.Integer).Value = Convert.ToInt16(cbSehir.SelectedValue);
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@Aciklama", OleDbType.VarChar).Value = txtAciklama.Text;
            if (cbDurumu.Text == "Aktif") cmd.Parameters.Add("@DurumBit", OleDbType.Integer).Value = 1;
            else if (cbDurumu.Text == "Pasif") cmd.Parameters.Add("@DurumBit", OleDbType.Integer).Value = 0;
            else cmd.Parameters.Add("@DurumBit", OleDbType.VarChar).Value = -1;
            cmd.Parameters.Add("@DevirBakiye", OleDbType.Currency).Value = txtDevirBakiye.Text;
            if (rbBorclu.Checked) cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "Borçlu";
            else if (rbAlacakli.Checked) cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "Alacaklı";
            else cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Cinsiyet", OleDbType.VarChar).Value = cbCinsiyet.Text;
            cmd.Parameters.Add("@SinifID", OleDbType.Integer).Value = Convert.ToInt16(cbSiniflandirma.SelectedValue);
            cmd.Parameters.Add("@DogumGunu", OleDbType.Date).Value = Convert.ToDateTime(dateDogumGunu.EditValue);
            cmd.Parameters.Add("@EvlilikYildonum", OleDbType.Date).Value = Convert.ToDateTime(dateEvlilik.EditValue);
            cmd.Parameters.Add("@Resim", OleDbType.LongVarBinary).Value = ResmimiziAt(); // EDİT
            cmd.Parameters.Add("@musteri", OleDbType.Integer).Value = sabitid;
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();
            this.Close();
        }
        byte[] ResmimiziAt()
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(pbResim.Image, typeof(byte[]));
        }

        private void frmMusteriKarti_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna ana = (frmAna)Application.OpenForms["frmAna"];
            ana.Yenile();
            frmMusteriHareket hareket = (frmMusteriHareket)Application.OpenForms["frmMusteriHareket"];
            if (hareket != null) hareket.Yenile(gmusterino: Convert.ToInt16(txtKod.Text),gvergino:Convert.ToString(cbVergiDairesi.SelectedValue+"/"+txtVergiNo.Text),gunvan: txtAdSoyad.Text,ggrupadi: cbGrup.Text, gaciklama:txtAciklama.Text );
        }


        private void txtKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            KodGetir();
            txtAdSoyad.Focus();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
