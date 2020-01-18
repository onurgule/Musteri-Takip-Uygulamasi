using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System.Windows.Forms;

namespace MusteriTakipProjesi
{
    public partial class frmExtre : Form
    {
        public int sabitid = -1;
        public string ad = "";
        public frmExtre()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        mtExtre mtExt = new mtExtre();
        //DataSet dsRapor = new DataSet();
        DataTable dtRapor;
        void DataTableDoldur()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT Satislar.SatisID AS IslemID,Satislar.Tarih, switch(Satislar.Tur = 0, 'Satış İade',Satislar.Tur = 1, 'Satış') AS Tur, Satislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Satislar.Miktar,Birimler.Birim,Satislar.Fiyat,Satislar.Tutar, Satislar.Tur AS Durum, Satislar.IslemTarihi, Satislar.SonBakiye FROM ((Satislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Satislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Satislar.MusteriID) INNER JOIN Birimler ON Birimler.BirimID=Satislar.BirimID WHERE Satislar.Tarih BETWEEN @tarih1 AND @tarih2 AND Satislar.MusteriID=@id UNION SELECT Alislar.AlisID AS IslemID,Alislar.Tarih,switch(Alislar.Tur = 0, 'Alış',Alislar.Tur = 1, 'Alış İade') AS Tur ,Alislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Alislar.Miktar,Birimler.Birim,Alislar.Fiyat, Alislar.Tutar, Alislar.Tur AS Durum, Alislar.IslemTarihi, Alislar.SonBakiye FROM ((Alislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Alislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Alislar.MusteriID) INNER JOIN Birimler ON Birimler.BirimID=Alislar.BirimID WHERE Alislar.Tarih BETWEEN @tarih1 AND @tarih2 AND Alislar.MusteriID=@id UNION SELECT Odemeler.OdemeID AS IslemID,Odemeler.Tarih, 'Odeme' AS Tur,Odemeler.EvrakNo, Aciklamalar.Aciklama AS Aciklama, '0','0','0', Odemeler.Tutar, 1 AS Durum, Odemeler.IslemTarihi, Odemeler.SonBakiye FROM (Odemeler INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Odemeler.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Odemeler.MusteriID WHERE Odemeler.Tarih BETWEEN @tarih1 AND @tarih2 AND Odemeler.MusteriID=@id UNION SELECT Tahsilatlar.TahsilatID AS IslemID,Tahsilatlar.Tarih, 'Tahsilat' AS Tur, Tahsilatlar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, '0','0','0', Tahsilatlar.Tutar, 0 AS Durum, Tahsilatlar.IslemTarihi, Tahsilatlar.SonBakiye FROM (Tahsilatlar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Tahsilatlar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Tahsilatlar.MusteriID WHERE Tahsilatlar.Tarih BETWEEN @tarih1 AND @tarih2 AND Tahsilatlar.MusteriID=@id", conn);
            cmd.Parameters.Add("@tarih1", OleDbType.Date).Value = dtpBaslangic.Value;
            cmd.Parameters.Add("@tarih2", OleDbType.Date).Value = dtpBitis.Value;
            cmd.Parameters.Add("@id", OleDbType.Integer).Value = sabitid;
            dtRapor = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtRapor);
            dtRapor.DefaultView.Sort = "Tarih ASC";
            dtRapor = dtRapor.DefaultView.ToTable();
        }
        private void btnOnizle_Click(object sender, EventArgs e)
        {
            Onizle();
        }
        genelMT gmt = new genelMT();
        void Onizle()
        {
            double verilenTop = 0;
            double alinanTop = 0;
            double araToplam = 0;
            double sonbakiye = gmt.BakiyeCek(sabitid, conn);
            DataTableDoldur();
            DataRow dRowHeader = mtExt.dsExtre.dtExtreHeader.NewdtExtreHeaderRow();//Fatura Başlık İçin Bir Satır Oluşturduk
            dRowHeader["Today"] = DateTime.Now.Date.ToShortDateString();//Müşteri Kodu
            dRowHeader["MID"] = gmt.MIDCek(sabitid, conn);
            dRowHeader["Unvan"] = ad;
            dRowHeader["Grup"] = gmt.GrupCek(sabitid,conn);
            mtExt.dsExtre.dtExtreHeader.Rows.Add(dRowHeader);//Fatura Başlık Bilgisine
            //yeni bir satır ekledik
            if (dtRapor.Rows.Count == 0) { MessageBox.Show("Kayıt Bulunamadı!"); return; }
            foreach (DataRow row in dtRapor.Rows)
            {
                DataRow dRowDetail = mtExt.dsExtre.dtExtreDetail.NewdtExtreDetailRow();//Fatura Detayı İçin Bir Satır Oluşturduk
                dRowDetail["IslemTuru"] = row["Tur"];//Stok Adı
                dRowDetail["Tarih"] = Convert.ToDateTime(row["Tarih"]).ToShortDateString();//Stok Birim
                dRowDetail["EvrakNo"] = row["EvrakNo"];//Birim Fiyat
                dRowDetail["Aciklama"] = row["Aciklama"];//Miktar
                if (row["Durum"].ToString() == "1")
                {
                    if (row["Tutar"] != "")
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
                dRowDetail["Bakiye"] = row["SonBakiye"];
                mtExt.dsExtre.dtExtreDetail.Rows.Add(dRowDetail);
            }
            //DataRow dRowFooter = mtExt.dsExtre.dtRaporOut.NewdtRaporOutRow();
            DataRow dRowFooter = mtExt.dsExtre.dtExtreFooter.NewdtExtreFooterRow();
            araToplam = verilenTop - alinanTop;
            dRowFooter["TopVerilen"] = verilenTop;
            dRowFooter["TopAlinan"] = alinanTop.ToString();
            dRowFooter["AraToplam"] = araToplam;
            dRowFooter["GenelBakiye"] = sonbakiye;
            mtExt.dsExtre.dtExtreFooter.Rows.Add(dRowFooter);
            mtExt.DataMember = "dtExtreDetail";
            mtExt.ShowPreview();
            this.Close();
        }
    }
}
