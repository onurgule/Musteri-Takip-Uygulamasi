namespace MusteriTakipProjesi
{
    partial class frmExtre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtre));
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnizle = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpBitis
            // 
            this.dtpBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(215, 114);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(173, 24);
            this.dtpBitis.TabIndex = 10;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(215, 71);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(173, 24);
            this.dtpBaslangic.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(66, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Genel Extre";
            // 
            // btnKapat
            // 
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(239, 196);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(149, 41);
            this.btnKapat.TabIndex = 13;
            this.btnKapat.Text = "Kapat";
            // 
            // btnOnizle
            // 
            this.btnOnizle.Image = ((System.Drawing.Image)(resources.GetObject("btnOnizle.Image")));
            this.btnOnizle.Location = new System.Drawing.Point(33, 196);
            this.btnOnizle.Name = "btnOnizle";
            this.btnOnizle.Size = new System.Drawing.Size(149, 41);
            this.btnOnizle.TabIndex = 12;
            this.btnOnizle.Text = "Önizle";
            this.btnOnizle.Click += new System.EventHandler(this.btnOnizle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(66, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // frmExtre
            // 
            this.AcceptButton = this.btnOnizle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 252);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnOnizle);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.dtpBaslangic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExtre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnOnizle;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}