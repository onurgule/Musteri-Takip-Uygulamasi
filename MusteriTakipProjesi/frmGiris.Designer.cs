namespace MusteriTakipProjesi
{
    partial class frmGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.pbGiris = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGiris)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Giriş";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(38, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(118, 119);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(183, 22);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.UseSystemPasswordChar = true;
            this.txtSifre.TextChanged += new System.EventHandler(this.txtSifre_TextChanged);
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(307, 119);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(34, 22);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "\r\n";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnIptal.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIptal.Location = new System.Drawing.Point(263, 211);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(111, 38);
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Image = ((System.Drawing.Image)(resources.GetObject("btnTamam.Image")));
            this.btnTamam.Location = new System.Drawing.Point(118, 211);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(111, 38);
            this.btnTamam.TabIndex = 5;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // pbGiris
            // 
            this.pbGiris.Image = global::MusteriTakipProjesi.Properties.Resources.user;
            this.pbGiris.Location = new System.Drawing.Point(304, 9);
            this.pbGiris.Name = "pbGiris";
            this.pbGiris.Size = new System.Drawing.Size(70, 63);
            this.pbGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGiris.TabIndex = 1;
            this.pbGiris.TabStop = false;
            // 
            // frmGiris
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(413, 261);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbGiris);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            ((System.ComponentModel.ISupportInitialize)(this.pbGiris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbGiris;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifre;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
    }
}

