namespace MusteriTakipProjesi
{
    partial class frmBirimEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBirimEkle));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEkle = new DevExpress.XtraEditors.TextEdit();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.lbIslemler = new DevExpress.XtraEditors.ListBoxControl();
            this.btnSatirSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEkle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Açıklama";
            // 
            // txtEkle
            // 
            this.txtEkle.Location = new System.Drawing.Point(12, 35);
            this.txtEkle.Name = "txtEkle";
            this.txtEkle.Size = new System.Drawing.Size(246, 22);
            this.txtEkle.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.Image")));
            this.btnEkle.Location = new System.Drawing.Point(264, 27);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(33, 41);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // lbIslemler
            // 
            this.lbIslemler.Location = new System.Drawing.Point(13, 74);
            this.lbIslemler.Name = "lbIslemler";
            this.lbIslemler.Size = new System.Drawing.Size(284, 204);
            this.lbIslemler.TabIndex = 3;
            // 
            // btnSatirSil
            // 
            this.btnSatirSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSatirSil.Image")));
            this.btnSatirSil.Location = new System.Drawing.Point(12, 284);
            this.btnSatirSil.Name = "btnSatirSil";
            this.btnSatirSil.Size = new System.Drawing.Size(109, 37);
            this.btnSatirSil.TabIndex = 4;
            this.btnSatirSil.Text = "Satır Sil";
            this.btnSatirSil.Click += new System.EventHandler(this.btnSatirSil_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(177, 284);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(120, 37);
            this.btnKapat.TabIndex = 5;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // frmBirimEkle
            // 
            this.AcceptButton = this.btnEkle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 346);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnSatirSil);
            this.Controls.Add(this.lbIslemler);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtEkle);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBirimEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birimler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAciklamaEkle_FormClosing);
            this.Load += new System.EventHandler(this.frmAciklamaEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEkle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbIslemler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEkle;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.ListBoxControl lbIslemler;
        private DevExpress.XtraEditors.SimpleButton btnSatirSil;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
    }
}