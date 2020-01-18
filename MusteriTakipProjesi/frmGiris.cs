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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+"\\MT.accdb");
        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program ilk kurulduğunda şifre\n89 'dur","Şifre Bilgilendirmesi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {

            Giris();
        }

        void Giris()
        {
            if (txtSifre.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Sifre FROM Ayarlar WHERE Sifre=@sifre", conn);
                cmd.Parameters.Add("@sifre", OleDbType.VarChar).Value = txtSifre.Text;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    frmAna ana = new frmAna();
                    ana.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre girişi!\nLütfen tekrar deneyiniz.", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Şifre giriniz.", "Uyarı");
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
          /*  if(e.KeyCode == Keys.Enter)
            {
                Giris();
            }
           * */
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
