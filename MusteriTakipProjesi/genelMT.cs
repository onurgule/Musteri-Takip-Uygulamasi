using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraGrid;
namespace MusteriTakipProjesi
{
    class genelMT
    {
        public double BakiyeCek(int sabitid, OleDbConnection conn)
        {
            double bakiye = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT DevirBakiye FROM Musteriler WHERE SabitID=@sabitid", conn);
            cmd.Parameters.Add("@sabitid", OleDbType.Integer).Value = sabitid;
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                bakiye = Convert.ToDouble(dr["DevirBakiye"]);
            }
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            return bakiye;
        }

        public int MIDCek(int sabitid, OleDbConnection conn)
        {
            int mid = -1;
            OleDbCommand cmd = new OleDbCommand("SELECT MID FROM Musteriler WHERE SabitID=@sabitid", conn);
            cmd.Parameters.Add("@sabitid", OleDbType.Integer).Value = sabitid;
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mid = Convert.ToInt16(dr["MID"]);
            }
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            return mid;

        }

        public string GrupCek(int sabitid, OleDbConnection conn)
        {
            string grup = "";
            OleDbCommand cmd = new OleDbCommand("SELECT Gruplar.GrupAdi AS GrupAdi FROM Musteriler INNER JOIN Gruplar ON Gruplar.GrupID=Musteriler.GrupNo WHERE SabitID=@sabitid", conn);
            cmd.Parameters.Add("@sabitid", OleDbType.Integer).Value = sabitid;
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                grup = Convert.ToString(dr["GrupAdi"]);
            }
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            return grup;

        }
        public bool OtoYedekVarMi(OleDbConnection conn)
        {
            bool otoyedek = false;
            OleDbCommand cmd = new OleDbCommand("SELECT OtoYedek FROM Ayarlar", conn);
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["OtoYedek"].ToString() == "0") otoyedek = false;
                else if (dr["OtoYedek"].ToString() == "1") otoyedek = true;
            }
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            return otoyedek;
        }

        public void Yedekle(OleDbConnection conn)
        {
            try
            {
                string yedekyolu = "";
                SaveFileDialog sfd = new SaveFileDialog();
                OleDbCommand cmd = new OleDbCommand("SELECT YedekYolu FROM Ayarlar", conn);
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    yedekyolu = dr["YedekYolu"].ToString();
                }
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                sfd.FileName = yedekyolu + @"\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "--" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".mtx";
                if (sfd.FileName != "")
                {
                    string src = Application.StartupPath + "\\MT.accdb";
                    string dst = sfd.FileName;
                    System.IO.File.Copy(src, dst, true);
                }
            }
            catch(Exception a)
            {
                MessageBox.Show("Yedek yolunun bulunamamasından kaynaklanan bir sorun ile oto-yedekleme yapılamadı.\nDaha sonra lütfen yedek yolunu değiştiriniz!","Yedek Yapılamadı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void ExcelKaydet(GridControl grid)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "MTX - Excel'e Aktarma";
            sfd.DefaultExt = "xls";
            sfd.Filter = "XLS Dosyası | *.xls";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                grid.ExportToXls(sfd.FileName);
            }
        }

        public bool MIDCheck(int mid,OleDbConnection conn)
        {
            bool midvar = false;
            OleDbCommand cmd = new OleDbCommand("SELECT SabitID FROM Musteriler WHERE MID=@mid",conn);
            cmd.Parameters.Add("@mid", OleDbType.Integer).Value = mid;
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                midvar = true;
            }
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            return midvar;
        }
    }
}
