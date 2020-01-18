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
    public partial class frmMusteriHareket : Form
    {
        public frmMusteriHareket()
        {
            InitializeComponent();
        }
        public double bakiye;
        public int musterino,sabitid;
        public string unvan,grupadi,aciklama,vergino;
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MT.accdb");
        private void frmMusteriHareket_Load(object sender, EventArgs e)
        {
            lblMusteriKodu.Text = musterino.ToString();
            lblUnvan.Text = unvan;
            lblGrup.Text = grupadi;
            lblVergi.Text = vergino.ToString();
            lblAciklama.Text = aciklama;
            lblBakiye.Text = bakiye.ToString("C");
            dateIlkTarih.EditValue = new DateTime(DateTime.Now.Year, 01, 01);
            dateSonTarih.EditValue = new DateTime(DateTime.Now.Year, 12, 31);
            Bul();
        }
        public void BakiyeYenile()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT DevirBakiye FROM Musteriler WHERE MID=@mid",conn);
            cmd.Parameters.Add("@mid", OleDbType.Integer).Value = musterino;
            if (conn.State == ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                bakiye = Convert.ToDouble(dr["DevirBakiye"]);
                lblBakiye.Text = bakiye.ToString("C");
            }
            if (conn.State == ConnectionState.Open) conn.Close();
        }
       public void Yenile(int gmusterino, string gvergino, string gunvan, string ggrupadi,string gaciklama)
        {
            lblMusteriKodu.Text = gmusterino.ToString();
            lblUnvan.Text = gunvan;
            lblGrup.Text = ggrupadi;
            lblVergi.Text = gvergino.ToString();
            lblAciklama.Text = gaciklama;
        }
        private void btnMusteriKarti_Click(object sender, EventArgs e)
        {
            frmMusteriKarti kart = new frmMusteriKarti();
                kart.sabitid = Convert.ToInt16(sabitid);
            kart.ShowDialog();
            BakiyeYenile();
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

        private void barbtnSatis2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            frmSatis satis = new frmSatis();
            satis.sabitid = sabitid;
            satis.ad = unvan;
            satis.islem = "Satış";
            satis.ShowDialog();
        }

        private void barbtnOdeme2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            frmOdeme odeme = new frmOdeme();
            odeme.sabitid = sabitid;
            odeme.ad = unvan;
            odeme.islem = "Ödeme";
            odeme.ShowDialog();
        }

        private void barbtnAlisIade2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAlisIade alisiade = new frmAlisIade();
            alisiade.sabitid = sabitid;
            alisiade.ad = unvan;
            alisiade.islem = "Alış İadesi";
            alisiade.ShowDialog();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Bul();
        }
        DataTable dtRapor = new DataTable();
        void Bul()
        {
            gridIslemler.DataSource = null;
            OleDbCommand cmd = new OleDbCommand("SELECT Satislar.SatisID AS IslemID,Satislar.Tarih, switch(Satislar.Tur = 0, 'Satış İade',Satislar.Tur = 1, 'Satış') AS Tur, Satislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Satislar.Miktar,Birimler.Birim,Satislar.Fiyat,Satislar.Tutar, 1 AS Durum, Satislar.IslemTarihi, Satislar.SonBakiye FROM ((Satislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Satislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Satislar.MusteriID) INNER JOIN Birimler ON Birimler.BirimID=Satislar.BirimID WHERE Satislar.Tarih BETWEEN @tarih1 AND @tarih2 AND Satislar.MusteriID=@id UNION SELECT Alislar.AlisID AS IslemID,Alislar.Tarih,switch(Alislar.Tur = 0, 'Alış İade',Alislar.Tur = 1, 'Alış') AS Tur ,Alislar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, Alislar.Miktar,Birimler.Birim,Alislar.Fiyat, Alislar.Tutar, 0 AS Durum, Alislar.IslemTarihi, Alislar.SonBakiye FROM ((Alislar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Alislar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Alislar.MusteriID) INNER JOIN Birimler ON Birimler.BirimID=Alislar.BirimID WHERE Alislar.Tarih BETWEEN @tarih1 AND @tarih2 AND Alislar.MusteriID=@id UNION SELECT Odemeler.OdemeID AS IslemID,Odemeler.Tarih, 'Odeme' AS Tur,Odemeler.EvrakNo, Aciklamalar.Aciklama AS Aciklama, '','','', Odemeler.Tutar, 1 AS Durum, Odemeler.IslemTarihi, Odemeler.SonBakiye FROM (Odemeler INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Odemeler.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Odemeler.MusteriID WHERE Odemeler.Tarih BETWEEN @tarih1 AND @tarih2 AND Odemeler.MusteriID=@id UNION SELECT Tahsilatlar.TahsilatID AS IslemID,Tahsilatlar.Tarih, 'Tahsilat' AS Tur, Tahsilatlar.EvrakNo, Aciklamalar.Aciklama AS Aciklama, '','','', Tahsilatlar.Tutar, 0 AS Durum, Tahsilatlar.IslemTarihi, Tahsilatlar.SonBakiye FROM (Tahsilatlar INNER JOIN Aciklamalar ON Aciklamalar.AciklamaID=Tahsilatlar.AciklamaID) INNER JOIN Musteriler ON Musteriler.SabitID=Tahsilatlar.MusteriID WHERE Tahsilatlar.Tarih BETWEEN @tarih1 AND @tarih2 AND Tahsilatlar.MusteriID=@id", conn);
            cmd.Parameters.Add("@tarih1", OleDbType.Date).Value = dateIlkTarih.EditValue;
            cmd.Parameters.Add("@tarih2", OleDbType.Date).Value = dateSonTarih.EditValue;
            cmd.Parameters.Add("@id", OleDbType.Integer).Value = sabitid;
            dtRapor = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtRapor);
            dtRapor.DefaultView.Sort = "Tarih ASC";
            dtRapor = dtRapor.DefaultView.ToTable();
            gridIslemler.DataSource = dtRapor;
            gridView.Columns["IslemID"].Visible = false;
            gridView.Columns["IslemTarihi"].Visible = false;
            gridView.Columns["Durum"].Visible = false;
            gridView.Columns["Tarih"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void barbtnAlis2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAlis alis = new frmAlis();
            alis.sabitid = sabitid;
            alis.ad = unvan;
            alis.islem = "Alış";
            alis.ShowDialog();
        }

        private void barbtnTahsilat2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTahsilat tahsilat = new frmTahsilat();
            tahsilat.sabitid = sabitid;
            tahsilat.ad = unvan;
            tahsilat.islem = "Tahsilat";
            tahsilat.ShowDialog();
        }

        private void barbtnSatisIade2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSatisIade satisiade = new frmSatisIade();
            satisiade.sabitid = sabitid;
            satisiade.ad = unvan;
            satisiade.islem = "Satış İade";
            satisiade.ShowDialog();
        }
        public bool kilitacik = false;
        private void gridIslemler_DoubleClick(object sender, EventArgs e)
        {
            if (kilitacik == true)
            {
                int secilen = -1;
                string islemtur = "";
                string ad = "";
                foreach (int i in gridView.GetSelectedRows())
                {
                    DataRow row = gridView.GetDataRow(i);
                    secilen = Convert.ToInt16(row["IslemID"]);
                    islemtur = row["Tur"].ToString();
                    ad = unvan;
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
                MessageBox.Show("Detaylara erişmek ve onları değiştirmek için lütfen kilidi sağ üstteki butondan açınız.", "Kilitli!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            if (kilitacik == true)
            {
                kilitacik = false;
                gridIslemler.Focus();
                return;
            }
            else if (kilitacik == false)
            {
                frmKritikSifre sifre = new frmKritikSifre();
                sifre.formu = this;
                sifre.ShowDialog();
                if (kilitacik == false) btnKilit.Checked = true;
                else if (kilitacik == true) btnKilit.Checked = false;
                gridIslemler.Focus();
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bul();
        }
        genelMT gmt = new genelMT();
        private void excelOlarakÇıkartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmt.ExcelKaydet(gridIslemler);
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = Control.MousePosition;
                this.cmsGrid.Show(p2);
            }
        }

        private void btnExtre_Click(object sender, EventArgs e)
        {
            int secilen = sabitid;
            string ad = unvan;
            frmExtre extre = new frmExtre();
            extre.sabitid = secilen;
            extre.ad = ad;
            extre.ShowDialog();
        }


    }
}
