using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System.Data.OleDb;

namespace MusteriTakipProjesi
{
    public partial class frmTumIslemlerRapor : Form
    {
        public frmTumIslemlerRapor()
        {
            InitializeComponent();
        }

        private void btnOnizle_Click(object sender, EventArgs e)
        {
            Onizle();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        mtRapotTum mtRaporT = new mtRapotTum();
        //DataSet dsRapor = new DataSet();
        DataTable dtRapor;
        void DataTableDoldur()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT Satislar.SatisID AS IslemID,Musteriler.AdSoyad,Satislar.Tarih, Satislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Satislar.Tutar, switch(Satislar.Tur = 0, 'Satış İade',Satislar.Tur = 1, 'Satış') AS Tur, Satislar.Tur AS Durum, Satislar.IslemTarihi FROM (Satislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Satislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Satislar.MusteriID WHERE Satislar.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Alislar.AlisID AS IslemID,Musteriler.AdSoyad,Alislar.Tarih, Alislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Alislar.Tutar, switch(Alislar.Tur = 0, 'Alış',Alislar.Tur = 1, 'Alış İade') AS Tur, Alislar.Tur AS Durum, Alislar.IslemTarihi FROM (Alislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Alislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Alislar.MusteriID WHERE Alislar.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Odemeler.OdemeID AS IslemID,Musteriler.AdSoyad,Odemeler.Tarih, Odemeler.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Odemeler.Tutar, 'Odeme' AS Tur, 1 AS Durum, Odemeler.IslemTarihi FROM (Odemeler INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Odemeler.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Odemeler.MusteriID WHERE Odemeler.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Tahsilatlar.TahsilatID AS IslemID,Musteriler.AdSoyad,Tahsilatlar.Tarih, Tahsilatlar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Tahsilatlar.Tutar, 'Tahsilat' AS Tur, 0 AS Durum, Tahsilatlar.IslemTarihi FROM (Tahsilatlar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Tahsilatlar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Tahsilatlar.MusteriID WHERE Tahsilatlar.Tarih BETWEEN @tarih1 AND @tarih2", conn);
            cmd.Parameters.Add("@tarih1", OleDbType.Date).Value = dtpBaslangic.Value;
            cmd.Parameters.Add("@tarih2", OleDbType.Date).Value = dtpBitis.Value;
            dtRapor = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtRapor);
            dtRapor.DefaultView.Sort = "Tarih ASC";
            dtRapor = dtRapor.DefaultView.ToTable();
        }
        void Onizle()
        {
            double verilenTop = 0;
            double alinanTop = 0;
            double araToplam = 0;
            DataTableDoldur();
            DataRow dRowHeader = mtRaporT.dsRapor.dtRaporHead.NewdtRaporHeadRow();//Fatura Başlık İçin Bir Satır Oluşturduk
            dRowHeader["Today"] = DateTime.Now.Date.ToShortDateString();//Müşteri Kodu
            mtRaporT.dsRapor.dtRaporHead.Rows.Add(dRowHeader);//Fatura Başlık Bilgisine
            //yeni bir satır ekledik
            if (dtRapor.Rows.Count == 0) { MessageBox.Show("Kayıt Bulunamadı!"); return; }
            foreach (DataRow row in dtRapor.Rows) { 
            DataRow dRowDetail = mtRaporT.dsRapor.dtRaporIn.NewdtRaporInRow();//Fatura Detayı İçin Bir Satır Oluşturduk
            dRowDetail["IslemTuru"] = row["Tur"];//Stok Adı
            dRowDetail["Tarih"] = Convert.ToDateTime(row["Tarih"]).ToShortDateString();//Stok Birim
            dRowDetail["EvrakNo"] = row["EvrakNo"];//Birim Fiyat
            dRowDetail["Aciklama"] = row["Aciklama"];//Miktar
            if (row["Durum"].ToString() == "1")
            {
                if(row["Tutar"]!="")
                verilenTop += Convert.ToDouble(row["Tutar"]);
                dRowDetail["Verilen"] = row["Tutar"];
                dRowDetail["Alinan"] = 0;//İskonto Oranı
            }
            else if (row["Durum"].ToString() == "0")
            {
                if (row["Tutar"] != "")
                    alinanTop += Convert.ToDouble(row["Tutar"]);
                dRowDetail["Verilen"] = 0;
                dRowDetail["Alinan"] = row["Tutar"];//KDV Oranı
            }
            mtRaporT.dsRapor.dtRaporIn.Rows.Add(dRowDetail);
            }
            //DataRow dRowFooter = mtRaporT.dsRapor.dtRaporOut.NewdtRaporOutRow();
            DataRow dRowFooter = mtRaporT.dsRapor.dtRaporFoot.NewdtRaporFootRow();
            araToplam = verilenTop - alinanTop;
            dRowFooter["TopVerilen"] = verilenTop;
            dRowFooter["TopAlinan"] = alinanTop.ToString();
            dRowFooter["AraToplam"] = araToplam;
            mtRaporT.dsRapor.dtRaporFoot.Rows.Add(dRowFooter);
            mtRaporT.ShowPreview();
            this.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            DataTableDoldur();
            if(dtRapor.Rows.Count == 0)
            {
                MessageBox.Show("Kayıt bulunamadı!");
                return;
            }
            frmTumIslemlerRaporListele listele = new frmTumIslemlerRaporListele();
            listele.baslangic = dtpBaslangic.Value;
            listele.bitis = dtpBitis.Value;
            listele.dtRapor = dtRapor;
            listele.Show();
        }

        private void frmTumIslemlerRapor_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
