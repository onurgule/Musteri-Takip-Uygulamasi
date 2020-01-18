namespace MusteriTakipProjesi
{
    partial class frmSifre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSifre));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.txtEskiSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifreD = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(24, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Eski Şifre";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(62, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Şifre";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(24, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Yeni Şifre";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(62, 136);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Şifre";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(62, 169);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Doğrulama";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(62, 223);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(122, 37);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(190, 223);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(95, 37);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.Location = new System.Drawing.Point(144, 57);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Properties.PasswordChar = '*';
            this.txtEskiSifre.Size = new System.Drawing.Size(141, 22);
            this.txtEskiSifre.TabIndex = 7;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(144, 133);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.PasswordChar = '*';
            this.txtYeniSifre.Size = new System.Drawing.Size(141, 22);
            this.txtYeniSifre.TabIndex = 8;
            // 
            // txtYeniSifreD
            // 
            this.txtYeniSifreD.Location = new System.Drawing.Point(144, 166);
            this.txtYeniSifreD.Name = "txtYeniSifreD";
            this.txtYeniSifreD.Properties.PasswordChar = '*';
            this.txtYeniSifreD.Size = new System.Drawing.Size(141, 22);
            this.txtYeniSifreD.TabIndex = 9;
            // 
            // frmSifre
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 280);
            this.Controls.Add(this.txtYeniSifreD);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSifre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştir";
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.TextEdit txtEskiSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifreD;
    }
}