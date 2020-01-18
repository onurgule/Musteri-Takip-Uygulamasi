namespace MusteriTakipProjesi
{
    partial class frmTumIslemlerRapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTumIslemlerRapor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.label1.Location = new System.Drawing.Point(134, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tüm İşlemler Detay Raporu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(67, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tarih";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(140, 135);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(173, 24);
            this.dtpBitis.TabIndex = 12;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(140, 92);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(173, 24);
            this.dtpBaslangic.TabIndex = 11;
            // 
            // btnKapat
            // 
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(441, 239);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(149, 41);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnOnizle
            // 
            this.btnOnizle.Image = ((System.Drawing.Image)(resources.GetObject("btnOnizle.Image")));
            this.btnOnizle.Location = new System.Drawing.Point(235, 239);
            this.btnOnizle.Name = "btnOnizle";
            this.btnOnizle.Size = new System.Drawing.Size(149, 41);
            this.btnOnizle.TabIndex = 5;
            this.btnOnizle.Text = "Önizle";
            this.btnOnizle.Click += new System.EventHandler(this.btnOnizle_Click);
            // 
            // btnListele
            // 
            this.btnListele.Image = ((System.Drawing.Image)(resources.GetObject("btnListele.Image")));
            this.btnListele.Location = new System.Drawing.Point(45, 239);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(149, 41);
            this.btnListele.TabIndex = 4;
            this.btnListele.Text = "Listele";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // frmTumIslemlerRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 297);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.dtpBaslangic);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnOnizle);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTumIslemlerRapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTumIslemlerRapor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraEditors.SimpleButton btnOnizle;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
    }
}