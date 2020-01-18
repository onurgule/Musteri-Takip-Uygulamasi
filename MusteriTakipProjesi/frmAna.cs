using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MusteriTakipProjesi
{
    public partial class frmAna : Form
    {

        // YEDEKLEME ve GERİ YÜKLEMEYİ ARAŞTIR. FAZLA BİR ŞEY KALMADI ZATEN.
        public frmAna()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        int suansabitid = -1; 
        private void frmAna_Load(object sender, EventArgs e)
        {
            //btnDropMenu.ContextMenuStrip = cmsMenu;
            Yenile();
        }
        public void TamYenileme()
        {
            Yenile();
            GrupGetir();
            SemtCek();
            Defaultla();
        }
        void Defaultla()
        {
            cbAraGrup.Text = "Tümü";
            cbAraSemt.Text = "Tümü";
            cbAraDurum.Text = "Tümü";
            cbAraBakiye.Text = "Tümü";
            txtAraAd.Text = "";
        }
        void GrupGetir()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Gruplar WHERE GrupID<>0", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Tümü";
            dt.Rows.InsertAt(dr, 0);
            cbAraGrup.DataSource = dt;
            cbAraGrup.ValueMember = "GrupID";
            cbAraGrup.DisplayMember = "GrupAdi";
            cbAraGrup.SelectedIndex = 0;
        }
        void SemtCek()
        {
            if(cbAraSemt.Items.IndexOf("Tümü") == -1)
            cbAraSemt.Items.Add("Tümü");
            int i = 0;
                while(i<gridView.RowCount)
            {
                DataRow row = gridView.GetDataRow(i);
                if (cbAraSemt.Items.IndexOf(row["m_semt"]) == -1)
                {
                    if(Convert.ToString(row["m_semt"]) != "")
                    cbAraSemt.Items.Add(row["m_semt"]);
                }
                if(i<gridView.RowCount)
                {
                    i++;
                    gridView.SelectRow(i);
                }
            }
            gridView.SelectRow(0);
        }
       public enum bakiyeDurum
        {
            Tum = 0,
            Bakiyeli = 1, // bakiyesi 0'dan farklı
            Bakiyesiz = 2, // bakiyesi 0
            AlacakBakiyeli = 3, // bakiyesi 0'dan küçük.
            BorcBakiyeli = 4, //bakiyesi 0'dan büyük.
        }
        public void Yenile(string adsoyad, int grupno, int semtno, bakiyeDurum bakiyedurum, int durum) // -1 ve null işlem yapmaz.
        {
            string bakiyeolayi = "";
            if(bakiyedurum == bakiyeDurum.AlacakBakiyeli) // Tümü - bakiyesi olanlar - alacak bakiyesi olanlar
            { bakiyeolayi = "< 0"; }
            else if(bakiyedurum == bakiyeDurum.BorcBakiyeli) // Tümü - bakiyesi olanlar - borç bakiyesi olanlar
            { bakiyeolayi = "> 0"; }
            else if(bakiyedurum == bakiyeDurum.Bakiyesiz) // Tümü - bakiyesi olmayanlar
            { bakiyeolayi = "= 0"; }
            else if(bakiyedurum == bakiyeDurum.Bakiyeli)
            {
                bakiyeolayi = "<> 0";
            }
            else if(bakiyedurum == bakiyeDurum.Tum)
            { bakiyeolayi = "Musteriler.DevirBakiye"; }
            OleDbCommand cmd = new OleDbCommand("SELECT *, Gruplar.GrupAdi AS m_grup ,Semtler.semt_ad AS m_semt,Ilceler.ilce_ad AS m_ilce,Iller.il_ad AS m_il, Siniflar.Sinif AS m_Sinif FROM ((((Musteriler INNER JOIN Gruplar ON Gruplar.GrupID = Musteriler.GrupNo) INNER JOIN Semtler ON Semtler.semt_id=Musteriler.SemtID) INNER JOIN Ilceler ON Ilceler.ilce_id = Musteriler.IlceID) INNER JOIN Iller ON Iller.il_id = Musteriler.IlID) INNER JOIN Siniflar ON Siniflar.SinifID = Musteriler.SinifID WHERE Musteriler.AdSoyad=@adsoyad AND Musteriler.GrupNo=@grupno AND Musteriler.SemtID=@semtno AND Musteriler.DurumBit=@durumbit AND Musteriler.DevirBakiye "+bakiyeolayi, conn);
            cmd.Parameters.Add("@adsoyad", OleDbType.VarChar).Value = adsoyad;
            cmd.Parameters.Add("@grupno", OleDbType.Integer).Value = grupno;
            cmd.Parameters.Add("@semtno", OleDbType.Integer).Value = semtno;
            cmd.Parameters.Add("@durumbit", OleDbType.Integer).Value = 1;

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gdMusteriler.DataSource = dt;
        }
        public void Yenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT *, Gruplar.GrupAdi AS m_grup ,Semtler.semt_ad AS m_semt,Ilceler.ilce_ad AS m_ilce,Iller.il_ad AS m_il, Siniflar.Sinif AS m_Sinif FROM ((((Musteriler INNER JOIN Gruplar ON Gruplar.GrupID = Musteriler.GrupNo) INNER JOIN Semtler ON Semtler.semt_id=Musteriler.SemtID) INNER JOIN Ilceler ON Ilceler.ilce_id = Musteriler.IlceID) INNER JOIN Iller ON Iller.il_id = Musteriler.IlID) INNER JOIN Siniflar ON Siniflar.SinifID = Musteriler.SinifID", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gdMusteriler.DataSource = dt;
            GrupGetir();//
            SemtCek();//
            Defaultla();
            //gridView.Columns["Bakiye"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Bakiye", "Sum={0}");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr");
            Localizer.Active = Localizer.CreateDefaultLocalizer();
            
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDropMenu_Click(object sender, EventArgs e)
        {
            Point p = new Point(0, btnDropMenu.Size.Height);
            var a = btnDropMenu.PointToScreen(p);
            popupMenu.ShowPopup(barManager,a);
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            frmMusteriEkle ekle = new frmMusteriEkle();
            ekle.Show();
        }

        private void txtAraAd_TextChanged(object sender, EventArgs e)
        {
                Ara();
        }

        private void btnMusteriKarti_Click(object sender, EventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                frmMusteriKarti kart = new frmMusteriKarti();
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    kart.sabitid = Convert.ToInt16(row["SabitID"]);
                }
                kart.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!","Müşteri Seçilmedi!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            if (gridView.GetSelectedRows().Count() >0)
            { 
          int secilen = -1;
          int mid = -1;
            foreach (int i in gridView.GetSelectedRows())
            {
                DataRow row = gridView.GetDataRow(i);
                secilen = Convert.ToInt16(row["SabitID"]);
                mid = Convert.ToInt16(row["MID"]);
            }
            if (secilen != -1)
            {
                DialogResult dialog = MessageBox.Show(mid + " nolu müşteriyi silmek istediğinizden emin misiniz?", "Müşteri Silme", MessageBoxButtons.YesNo);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE * FROM Musteriler WHERE SabitID=@sabitid", conn);
                    cmd.Parameters.Add("@sabitid", OleDbType.Integer).Value = secilen;
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open) conn.Close();
                    Yenile();
                }
            }
        }
                else
	            {
                    MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
	            }
        }
        private void btnMusteriHareketleri_Click(object sender, EventArgs e)
        {
            if(gridView.GetSelectedRows().Count() >0){
            int secilen = -1;
            int musterii = -1;
            frmMusteriHareket hareket = new frmMusteriHareket();
            foreach (int i in gridView.GetSelectedRows())
            {
                DataRow row = gridView.GetDataRow(i);
                musterii = Convert.ToInt16(row["MID"]);
                secilen = Convert.ToInt16(row["SabitID"]);
                hareket.musterino = musterii;
                hareket.bakiye = Convert.ToDouble(row["DevirBakiye"]);
                hareket.unvan = Convert.ToString(row["AdSoyad"]);
                hareket.vergino = Convert.ToString(row["VergiDaireNo"] + "/" + row["VergiNo"]);
                hareket.aciklama = Convert.ToString(row["Aciklama"]);
                hareket.sabitid = secilen;
            }
            OleDbCommand cmd = new OleDbCommand("SELECT Gruplar.GrupAdi FROM Musteriler INNER JOIN Gruplar ON Gruplar.GrupID=Musteriler.GrupNo WHERE SabitID=@sabitid", conn);
            cmd.Parameters.Add("@sabitid",OleDbType.Integer).Value = secilen;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                hareket.grupadi = dr[0].ToString();
            if (conn.State == ConnectionState.Open) conn.Close();
            hareket.ShowDialog();
            }
            else
	            {
                    MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
	            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAraBul_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void cbAraGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbAraGrup.Focused)
            {
                return;
            }
            Ara();
        }

        private void cbAraSemt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbAraSemt.Focused)
            {
                return;
            }
            Ara();
        }

        private void cbAraBakiye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbAraBakiye.Focused)
            {
                return;
            }
            Ara();
        }

        private void cbAraDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbAraDurum.Focused)
            {
                return;
            }
            Ara();
        }
        void Ara()
        {
            string aramakodu = "";
            if(txtAraAd.Text != "")
            {
                if (aramakodu == "")
                    aramakodu += "Musteriler.AdSoyad LIKE '%" + txtAraAd.Text + "%'";
                else
                { aramakodu += " AND AdSoyad LIKE '*" + txtAraAd.Text + "*"; }
            }
            
            if(cbAraGrup.Text != "Tümü")
            {
                if (aramakodu == "")
                    aramakodu += "GrupNo =" + cbAraGrup.SelectedValue;
                else
                { aramakodu += " AND GrupNo =" + cbAraGrup.SelectedValue; } //++
            }
            if(cbAraSemt.Text != "Tümü")
            {
                if (aramakodu == "")
                    aramakodu += "Semtler.semt_ad='" + cbAraSemt.Text+"'";
                else
                { aramakodu += " AND Semtler.semt_ad='" + cbAraSemt.Text+"'"; }
            }
            if(cbAraDurum.Text != "Tümü")
            {
                if (aramakodu == "")
                {
                    if (cbAraDurum.Text == "Aktif")
                        aramakodu += "DurumBit=1";
                    else if (cbAraDurum.Text == "Pasif")
                        aramakodu += "DurumBit=0";
                }
                else
                {
                    if (cbAraDurum.Text == "Aktif")
                        aramakodu += " AND DurumBit=1";
                    else if (cbAraDurum.Text == "Pasif")
                        aramakodu += " AND DurumBit=0";
                }
            }
            if(cbAraBakiye.Text != "Tümü") // Enumla filan olabilir.
            {
                if (aramakodu == "")
                {
                    if(cbAraBakiye.Text == "Bakiyesi Olanlar")
                    {
                        aramakodu += " (DevirBakiye > 0 OR DevirBakiye < 0)";
                    }
                    else if(cbAraBakiye.Text == "Bakiyesi Olmayanlar")
                    {
                        aramakodu += " DevirBakiye = 0";
                    }
                    else if(cbAraBakiye.Text == "Alacak Bakiyesi Olanlar")
                    {
                        aramakodu += "DevirBakiye < 0";
                    }
                    else if (cbAraBakiye.Text == "Borç Bakiyesi Olanlar")
                    {
                        aramakodu += "DevirBakiye > 0";
                    }
                }
                else
                {
                    if (cbAraBakiye.Text == "Bakiyesi Olanlar")
                    {
                        aramakodu += " AND (DevirBakiye > 0 OR DevirBakiye < 0)";
                    }
                    else if (cbAraBakiye.Text == "Bakiyesi Olmayanlar")
                    {
                        aramakodu += " AND DevirBakiye = 0";
                    }
                    else if (cbAraBakiye.Text == "Alacak Bakiyesi Olanlar")
                    {
                        aramakodu += " AND DevirBakiye < 0";
                    }
                    else if (cbAraBakiye.Text == "Borç Bakiyesi Olanlar")
                    {
                        aramakodu += " AND DevirBakiye > 0";
                    }
                }
            }
            OleDbCommand cmd;
            if(aramakodu != "")
             cmd = new OleDbCommand("SELECT *, Gruplar.GrupAdi AS m_grup ,Semtler.semt_ad AS m_semt,Ilceler.ilce_ad AS m_ilce,Iller.il_ad AS m_il, Siniflar.Sinif AS m_Sinif FROM ((((Musteriler INNER JOIN Gruplar ON Gruplar.GrupID = Musteriler.GrupNo) INNER JOIN Semtler ON Semtler.semt_id=Musteriler.SemtID) INNER JOIN Ilceler ON Ilceler.ilce_id = Musteriler.IlceID) INNER JOIN Iller ON Iller.il_id = Musteriler.IlID) INNER JOIN Siniflar ON Siniflar.SinifID = Musteriler.SinifID WHERE " +aramakodu,conn);
            else
                cmd = new OleDbCommand("SELECT *, Gruplar.GrupAdi AS m_grup ,Semtler.semt_ad AS m_semt,Ilceler.ilce_ad AS m_ilce,Iller.il_ad AS m_il, Siniflar.Sinif AS m_Sinif FROM ((((Musteriler INNER JOIN Gruplar ON Gruplar.GrupID = Musteriler.GrupNo) INNER JOIN Semtler ON Semtler.semt_id=Musteriler.SemtID) INNER JOIN Ilceler ON Ilceler.ilce_id = Musteriler.IlceID) INNER JOIN Iller ON Iller.il_id = Musteriler.IlID) INNER JOIN Siniflar ON Siniflar.SinifID = Musteriler.SinifID", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gdMusteriler.DataSource = dt;
        }

        private void btnBorclandir_Click(object sender, EventArgs e)
        {
            Point p = new Point(0, btnBorclandir.Size.Height);
            var a = btnBorclandir.PointToScreen(p);
            popupBorclandir.ShowPopup(barManager, a);
        }

        private void btnAlacaklandir_Click(object sender, EventArgs e)
        {
            Point p = new Point(0, btnAlacaklandir.Size.Height);
            var a = btnAlacaklandir.PointToScreen(p);
            popupAlacaklandir.ShowPopup(barManager, a);
        }

        private void barBtnSifreDegistir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSifre sifre = new frmSifre();
            sifre.ShowDialog();
        }
        bool derhalkapat = false;
        genelMT gmt = new genelMT();
        private void frmAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (derhalkapat == false)
            {
                DialogResult dialog = MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    if(gmt.OtoYedekVarMi(conn))
                    {
                        gmt.Yedekle(conn);
                    }
                    derhalkapat = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {

            }
        }

        private void barBtnGenelAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGenelAyarlar ayar = new frmGenelAyarlar();
            ayar.ShowDialog();
        }

        private void barBtnYedekle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VeritabaniYedekle();
        }

        void AyarlarXML(string path)
        {
            DataTableColumnAyarla();
            XmlTextWriter yaz = new XmlTextWriter(path, System.Text.UTF8Encoding.GetEncoding("windows-1254"));
            yaz.Formatting = System.Xml.Formatting.Indented;
            try
            {
                yaz.WriteStartDocument();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ayarlar", conn);
                yaz.WriteStartElement("Ayarlar");
                if (conn.State == ConnectionState.Closed) conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        yaz.WriteElementString(dtAyarlar.Columns[i].ColumnName, Convert.ToString(dr[i]));
                    }
                }
                dr.Close();
                if (conn.State == ConnectionState.Open) conn.Close();
                yaz.WriteEndElement();
                yaz.WriteEndDocument();
                yaz.Close();
                MessageBox.Show("Ayarlar XML çıktısı oluşturuldu!");
                }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar XML çıktısı oluşturulurken hata!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            
            
        }

        void MusterilerXML(string path)
        {
            try
            {
                DataTableColumnAyarla();
                XmlTextWriter yaz = new XmlTextWriter(path, System.Text.UTF8Encoding.GetEncoding("windows-1254"));
                yaz.Formatting = System.Xml.Formatting.Indented;
                yaz.WriteStartDocument();
                OleDbCommand cmd = new OleDbCommand("SELECT SabitID,MID,AdSoyad,Gruplar.GrupAdi AS m_grup, VergiDaireNo, VergiNo,Telefon1,Telefon2,Fax,CepTel,Adres,Semtler.semt_ad AS m_semt,Ilceler.ilce_ad AS m_ilce,Iller.il_ad AS m_il,Email,Aciklama,DurumBit,DevirBakiye,BorcluOrAlacakli,Cinsiyet, Siniflar.Sinif AS m_Sinif, DogumGunu, EvlilikYildonum, EvlilikYildonum  FROM ((((Musteriler INNER JOIN Gruplar ON Gruplar.GrupID = Musteriler.GrupNo) INNER JOIN Semtler ON Semtler.semt_id=Musteriler.SemtID) INNER JOIN Ilceler ON Ilceler.ilce_id = Musteriler.IlceID) INNER JOIN Iller ON Iller.il_id = Musteriler.IlID) INNER JOIN Siniflar ON Siniflar.SinifID = Musteriler.SinifID", conn);
                yaz.WriteStartElement("Musteriler");
                if (conn.State == ConnectionState.Closed) conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                int m = 0;
                while (dr.Read())
                {
                    yaz.WriteStartElement("Musteri");
                    m++;
                    yaz.WriteAttributeString("ID", m.ToString());
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (i != dr.FieldCount - 1)
                            yaz.WriteElementString(dtMusteriler.Columns[i].ColumnName, Convert.ToString(dr[i]));
                        else
                        {

                        }
                    }
                    yaz.WriteEndElement();

                }
                yaz.WriteEndElement();
                yaz.WriteEndDocument();
                yaz.Flush();
                yaz.Close();
                MessageBox.Show("Müşteriler XML çıktısı oluşturuldu!");
            }
            catch(Exception a)
            {
                MessageBox.Show("Müşteriler XML çıktısı oluşturulurken hata!","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        DataTable dtAyarlar;
        DataTable dtMusteriler;
        public void GeriYukle()
        {
            DialogResult dial = MessageBox.Show("Geri yükleme işlemi gerçekleştirildiğinde şimdiki veriler silinip, daha önceki yedekten çekilecektir.\nEğer yedekten sonra veri eklenmişse onlar silinecektir.\nDevam etmek istiyor musunuz?", "Geri Yükleme", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dial == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Title = "MTX - Geri Yükleme";
                    ofd.DefaultExt = "mtx";
                    ofd.Filter = "MTX Dosyası | *.mtx";
                    ofd.ShowDialog();
                    if (ofd.FileName != "")
                    {
                        string src = ofd.FileName;
                        string dst = Application.StartupPath + "\\MT.accdb";
                        System.IO.File.Copy(src, dst, true);
                        MessageBox.Show("Geri Yükleme Başarılı!");
                        Yenile();
                    }
                }
                catch(Exception a)
                { MessageBox.Show("Geri yüklemede hata!"); }
                
            }
        }
                       

        

        void DataTableColumnAyarla()
       {
           dtAyarlar = new DataTable();
           dtMusteriler = new DataTable();
           dtAyarlar.Columns.Add("Firmaunvan");
           dtAyarlar.Columns.Add("Yetkili");
           dtAyarlar.Columns.Add("Telefon");
           dtAyarlar.Columns.Add("Fax") ;
           dtAyarlar.Columns.Add("Adres") ;
           dtAyarlar.Columns.Add("Odemeyeri") ;
           dtAyarlar.Columns.Add("Vergidairesi");
           dtAyarlar.Columns.Add("Vergino");
           dtAyarlar.Columns.Add("Yedekyolu");
           dtAyarlar.Columns.Add("Otoyedek");
           dtAyarlar.Columns.Add("Sifre");
            //
           dtMusteriler.Columns.Add("SabitID");
           dtMusteriler.Columns.Add("MID");
           dtMusteriler.Columns.Add("AdSoyad");
           dtMusteriler.Columns.Add("Grup");
           dtMusteriler.Columns.Add("VergiDaireNo");
           dtMusteriler.Columns.Add("VergiNo");
           dtMusteriler.Columns.Add("Telefon1");
           dtMusteriler.Columns.Add("Telefon2");
           dtMusteriler.Columns.Add("Fax");
           dtMusteriler.Columns.Add("CepTel");
           dtMusteriler.Columns.Add("Adres");
           dtMusteriler.Columns.Add("Semt");
           dtMusteriler.Columns.Add("Ilce");
           dtMusteriler.Columns.Add("Il");
           dtMusteriler.Columns.Add("Email");
           dtMusteriler.Columns.Add("Aciklama");
           dtMusteriler.Columns.Add("Durum");
           dtMusteriler.Columns.Add("DevirBakiye");
           dtMusteriler.Columns.Add("BorcDurumu");
           dtMusteriler.Columns.Add("Cinsiyet");
           dtMusteriler.Columns.Add("Sinif");
           dtMusteriler.Columns.Add("DogumGunu");
           dtMusteriler.Columns.Add("EvlilikYildonumu");
           dtMusteriler.Columns.Add("Resim");

       }
        private void barBtnGeriYukle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSifreOnayi sifreonay = new frmSifreOnayi();
            sifreonay.islem = "GeriYukle";
            sifreonay.ShowDialog();
        }

        private void btnExtre_Click(object sender, EventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string ad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    ad = Convert.ToString(row["AdSoyad"]);
                }
                frmExtre extre = new frmExtre();
                extre.sabitid = secilen;
                extre.ad = ad;
                extre.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        void VeritabaniYedekle()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "MTX - Yedekleme";
            sfd.DefaultExt = "mtx";
            sfd.Filter = "MTX Dosyası | *.mtx";
            sfd.ShowDialog();
            if(sfd.FileName != ""){
            string src = Application.StartupPath + "\\MT.accdb";
            string dst = sfd.FileName;
            System.IO.File.Copy(src, dst, true);
            MessageBox.Show("Yedekleme Başarılı!");
            }
        }
        void VeritabaniGeriYukle()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "MTX - Geri Yükleme";
            ofd.DefaultExt = "mtx";
            ofd.Filter = "MTX Dosyası | *.mtx";
            ofd.ShowDialog();
            if(ofd.FileName != "")
            {
                    string src = ofd.FileName;
                    string dst = Application.StartupPath + "\\MT.accdb";
                    System.IO.File.Copy(src, dst, true);
                    MessageBox.Show("Geri Yükleme Başarılı!");
            }
        }
        private void barbtnSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmSatis satis = new frmSatis();
                satis.sabitid = secilen;
                satis.ad = adsoyad;
                satis.islem = "Satış";
                satis.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AyarlarXMLOlustur()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Dosyası | *.xml";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                AyarlarXML(sfd.FileName);
            }
        }
       private void barbtnAyarlarXML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bütün bilgileriniz XML dosyasına aktarılıp herkes tarafından okunabilir olacaktır!\nDevam etmek istiyor musunuz?","Dikkat",MessageBoxButtons.YesNoCancel);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                frmSifreOnayi sifreonay = new frmSifreOnayi();
                sifreonay.islem = "AyarlarXML";
                sifreonay.ShowDialog();
            }
        }
        public void MusterilerXMLOlustur()
       {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Dosyası | *.xml";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                MusterilerXML(sfd.FileName);
            }
       }
        private void barbtnMusterilerXML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bütün Müşterileriniz XML dosyasına aktarılıp herkes tarafından okunabilir olacaktır!\nDevam etmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNoCancel);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                frmSifreOnayi sifreonay = new frmSifreOnayi();
                sifreonay.islem = "MusterilerXML";
                sifreonay.ShowDialog();
            }
        }

        private void barbtnOdeme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmOdeme odeme = new frmOdeme();
                odeme.sabitid = secilen;
                odeme.ad = adsoyad;
                odeme.islem = "Ödeme";
                odeme.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnAlisIade_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmAlisIade alisiade = new frmAlisIade();
                alisiade.sabitid = secilen;
                alisiade.ad = adsoyad;
                alisiade.islem = "Alış İadesi";
                alisiade.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnAlis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmAlis alis = new frmAlis();
                alis.sabitid = secilen;
                alis.ad = adsoyad;
                alis.islem = "Alış";
                alis.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnTahsilat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmTahsilat tahsilat = new frmTahsilat();
                tahsilat.sabitid = secilen;
                tahsilat.ad = adsoyad;
                tahsilat.islem = "Tahsilat";
                tahsilat.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barbtnSatisIade_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView.GetSelectedRows().Count() > 0)
            {
                int secilen = -1;
                string adsoyad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["SabitID"]);
                    adsoyad = Convert.ToString(row["AdSoyad"]);
                }
                frmSatisIade satisiade = new frmSatisIade();
                satisiade.sabitid = secilen;
                satisiade.ad = adsoyad;
                satisiade.islem = "Satış İade";
                satisiade.ShowDialog();
            }
            else
            {
                MessageBox.Show("Müşteri yok veya seçilmedi!", "Müşteri Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barBtnTumIslemRaporu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTumIslemlerRapor tumislem = new frmTumIslemlerRapor();
            tumislem.ShowDialog();
        }

        private void gdMusteriler_DoubleClick(object sender, EventArgs e)
        {
            btnMusteriHareketleri.PerformClick();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        private void excelOlarakÇıkartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmt.ExcelKaydet(gdMusteriler);
            
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = Control.MousePosition;
                this.cmsGrid.Show(p2);
            }
        }


    }
}
