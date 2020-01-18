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
    public partial class frmTumIslemlerRaporListele : Form
    {
        public frmTumIslemlerRaporListele()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        public DateTime baslangic;
        public DateTime bitis;
        private void frmTumIslemlerRaporListele_Load(object sender, EventArgs e)
        {
            Ekle();
        }
        public DataTable dtRapor;
        void DataTableDoldur()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT Satislar.SatisID AS IslemID,Musteriler.AdSoyad,Satislar.Tarih, Satislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Satislar.Tutar, switch(Satislar.Tur = 0, 'Satış İade',Satislar.Tur = 1, 'Satış') AS Tur, Satislar.Tur AS Durum, Satislar.IslemTarihi FROM (Satislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Satislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Satislar.MusteriID WHERE Satislar.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Alislar.AlisID AS IslemID,Musteriler.AdSoyad,Alislar.Tarih, Alislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Alislar.Tutar, switch(Alislar.Tur = 0, 'Alış',Alislar.Tur = 1, 'Alış İade') AS Tur, Alislar.Tur AS Durum, Alislar.IslemTarihi FROM (Alislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Alislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Alislar.MusteriID WHERE Alislar.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Odemeler.OdemeID AS IslemID,Musteriler.AdSoyad,Odemeler.Tarih, Odemeler.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Odemeler.Tutar, 'Odeme' AS Tur, 1 AS Durum, Odemeler.IslemTarihi FROM (Odemeler INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Odemeler.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Odemeler.MusteriID WHERE Odemeler.Tarih BETWEEN @tarih1 AND @tarih2 UNION SELECT Tahsilatlar.TahsilatID AS IslemID,Musteriler.AdSoyad,Tahsilatlar.Tarih, Tahsilatlar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Tahsilatlar.Tutar, 'Tahsilat' AS Tur, 0 AS Durum, Tahsilatlar.IslemTarihi FROM (Tahsilatlar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Tahsilatlar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Tahsilatlar.MusteriID WHERE Tahsilatlar.Tarih BETWEEN @tarih1 AND @tarih2", conn);
            cmd.Parameters.Add("@tarih1", OleDbType.Date).Value = baslangic;
            cmd.Parameters.Add("@tarih2", OleDbType.Date).Value = bitis;
            dtRapor = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dtRapor.Clear();
            da.Fill(dtRapor);
            dtRapor.DefaultView.Sort = "Tarih ASC";
            dtRapor = dtRapor.DefaultView.ToTable();
        }
        
        void Ekle()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Tarih");
            dt.Columns.Add("Tur");
            dt.Columns.Add("EvrakNo");
            dt.Columns.Add("AdSoyad");
            dt.Columns.Add("Aciklama");
            dt.Columns.Add("Verilen");
            dt.Columns.Add("Alinan");
            dt.Columns.Add("IslemTarihi");
            dt.Columns.Add("IslemID");
            int index = -1;
            foreach (DataRow row in dtRapor.Rows)
            {
                DataRow drow;
                drow = dt.NewRow();
                drow[0] = Convert.ToDateTime(row["Tarih"]).ToShortDateString();
                drow[1] = row["Tur"];
                drow[2] = row["EvrakNo"];
                drow[3] = row["AdSoyad"];
                drow[4] = row["Aciklama"];
                if (row["Durum"].ToString() == "1")
                {
                    drow[5] = row["Tutar"];
                    drow[6] = 0;
                }
                else if (row["Durum"].ToString() == "0")
                {
                    drow[5] = 0;
                    drow[6] = row["Tutar"];
                }
                drow[7] = row["IslemTarihi"];
                drow[8] = row["IslemID"];
                dt.Rows.Add(drow);
            }
            gridRapor.DataSource = dt;
        }


        private void gridViewRapor_DoubleClick(object sender, EventArgs e)
        {
            if (kilitacik == true)
            {
                int secilen = -1;
                string islemtur = "";
                string ad = "";
                foreach (int i in gridViewRapor.GetSelectedRows())
                {
                    DataRow row = gridViewRapor.GetDataRow(i);
                    secilen = Convert.ToInt16(row["IslemID"]);
                    islemtur = row["Tur"].ToString();
                    ad = row["AdSoyad"].ToString();
                }
                if (secilen != -1 && islemtur != "")
                {
                    if (islemtur == "Satış")
                    {
                        frmSatis satis = new frmSatis();
                        satis.id = secilen;
                        satis.ad = ad;
                        satis.ShowDialog();
                    }
                    else if (islemtur == "Satış İade")
                    {
                        frmSatisIade satisiade = new frmSatisIade();
                        satisiade.id = secilen;
                        satisiade.ad = ad;
                        satisiade.ShowDialog();
                    }
                    else if (islemtur == "Alış")
                    {
                        frmAlis alis = new frmAlis();
                        alis.id = secilen;
                        alis.ad = ad;
                        alis.ShowDialog();
                    }
                    else if (islemtur == "Alış İade")
                    {
                        frmAlisIade alisiade = new frmAlisIade();
                        alisiade.id = secilen;
                        alisiade.ad = ad;
                        alisiade.ShowDialog();
                    }
                    else if (islemtur == "Odeme")
                    {
                        frmOdeme odeme = new frmOdeme();
                        odeme.id = secilen;
                        odeme.ad = ad;
                        odeme.ShowDialog();
                    }
                    else if (islemtur == "Tahsilat")
                    {
                        frmTahsilat tahsilat = new frmTahsilat();
                        tahsilat.id = secilen;
                        tahsilat.ad = ad;
                        tahsilat.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Detaylara erişmek ve onları değiştirmek için lütfen kilidi sağ alttaki butondan açınız.","Kilitli!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public bool kilitacik = false;

        private void btnKilit_Click(object sender, EventArgs e)
        {
            if(kilitacik == true)
            {
                kilitacik = false;
                gridRapor.Focus();
                return;
            }
            else if (kilitacik == false)
            {
                frmKritikSifre sifre = new frmKritikSifre();
                sifre.formu = this;
                sifre.ShowDialog();
                if (kilitacik == false) btnKilit.Checked = true;
                else if (kilitacik == true) btnKilit.Checked = false;
                gridRapor.Focus();
            }

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            gridRapor.DataSource = null;
            DataTableDoldur();
            Ekle();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnYenile.PerformClick();
        }
        genelMT gmt = new genelMT();
        private void excelOlarakÇıkartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmt.ExcelKaydet(gridRapor);
        }

        private void gridViewRapor_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = Control.MousePosition;
                this.cmsGrid.Show(p2);
            }
        }
    }
}
