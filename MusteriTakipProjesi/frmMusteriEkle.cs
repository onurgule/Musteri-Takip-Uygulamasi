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
    public partial class frmMusteriEkle : Form
    {
        public frmMusteriEkle()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");

        private void frmMusteriEkle_Load(object sender, EventArgs e)
        {
            GrupGetir();
            VergiDairesiGetir();
            IlCek();
            SinifCek();
            TarihleriDefaultla();
        }
        void TarihleriDefaultla()
        {
            dateDogumGunu.DateTime = DateTime.Now.Date;
            dateEvlilik.DateTime = DateTime.Now.Date;
        }
        void SinifCek()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Siniflar WHERE SinifID <> 0", conn);
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
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Gruplar WHERE GrupID<>0", conn);
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

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKod.Text != "")
            {
                if (txtAdSoyad.Text != "")
                {
                    if (!gmt.MIDCheck(Convert.ToInt16(txtKod.Text), conn))
                    {
                        Kaydet();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu müşteri numarasına sahip bir müşteri zaten var!","Müşteri Numarası Hatalı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Adınızı giriniz!", "Müşteri Adı Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Kodunuzu alın!", "Müşteri Kodu Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        genelMT gmt = new genelMT();
        void Kaydet()
        {
            
            OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Musteriler WHERE AdSoyad=@adsoyad", conn);
            cmd2.Parameters.Add("@adsoyad", OleDbType.VarChar).Value = txtAdSoyad.Text;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                DialogResult dialog = MessageBox.Show(txtAdSoyad.Text + " adlı bir müşteri zaten var, devam etmek istiyor musunuz?", "Müşteri Mevcut", MessageBoxButtons.YesNo);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                { }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            OleDbCommand cmd = new OleDbCommand("INSERT INTO Musteriler(MID,AdSoyad,GrupNo,VergiDaireNo,VergiNo,Telefon1,Telefon2,Fax,CepTel,Adres,SemtID,IlceID,IlID,Email,Aciklama,DurumBit,DevirBakiye,BorcluOrAlacakli,Cinsiyet,SinifID,DogumGunu,EvlilikYildonum,Resim) VALUES(@MID,@AdSoyad,@GrupNo,@VergiDaireNo,@VergiNo,@Telefon1,@Telefon2,@Fax,@CepTel,@Adres,@SemtID,@IlceID,@IlID,@Email,@Aciklama,@DurumBit,@DevirBakiye,@BorcluOrAlacakli,@Cinsiyet,@SinifID,@DogumGunu,@EvlilikYildonum,@Resim)", conn);
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

            cmd.Parameters.Add("@DevirBakiye", OleDbType.Double).Value = Convert.ToDouble(txtDevirBakiye.Text.Replace('.',','));
            if (rbBorclu.Checked) cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "Borçlu";
            else if (rbAlacakli.Checked) cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "Alacaklı";
            else cmd.Parameters.Add("@BorcluOrAlacakli", OleDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Cinsiyet", OleDbType.VarChar).Value = cbCinsiyet.Text;
            cmd.Parameters.Add("@SinifID", OleDbType.Integer).Value = Convert.ToInt16(cbSiniflandirma.SelectedValue);
            cmd.Parameters.Add("@DogumGunu", OleDbType.Date).Value = Convert.ToDateTime(dateDogumGunu.EditValue);
            cmd.Parameters.Add("@EvlilikYildonum", OleDbType.Date).Value = Convert.ToDateTime(dateEvlilik.EditValue);
            cmd.Parameters.Add("@Resim", OleDbType.LongVarBinary).Value = ResmimiziAt(); // EDİT
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();

        }
        Bitmap bmp = null;
        byte[] ResmimiziAt()
        {
            if (pbResim.Image != null)
            {
                Bitmap bmpKucuk = new Bitmap(pbResim.Image, 300, 200);
                pbResim.Image = bmpKucuk;
            }
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(pbResim.Image, typeof(byte[]));
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
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ilceler WHERE il_id=@ilid AND ilce_id<>0 ORDER BY ilce_ad ASC", conn);
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
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public void Resmet(Bitmap resim)
        {
            pbResim.Image = resim;
        }
        private void btnCamera_Click(object sender, EventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.gelenform = this;
            cam.ShowDialog();
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            DosyadanResim();
        }

        private void btnResimSil_Click(object sender, EventArgs e)
        {
            pbResim.Image = null;
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

        private void frmMusteriEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAna ana = (frmAna)Application.OpenForms["frmAna"];
            ana.Yenile();
        }

        private void cbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            KodGetir();
            txtAdSoyad.Focus();
        }
    }
}
