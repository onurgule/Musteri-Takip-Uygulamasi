namespace MusteriTakipProjesi
{
    partial class frmKritikSifre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKritikSifre));
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(221, 68);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(64, 30);
            this.btnKapat.TabIndex = 7;
            this.btnKapat.Text = "Kapat";
            // 
            // btnTamam
            // 
            this.btnTamam.Image = ((System.Drawing.Image)(resources.GetObject("btnTamam.Image")));
            this.btnTamam.Location = new System.Drawing.Point(77, 68);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(138, 30);
            this.btnTamam.TabIndex = 6;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(77, 25);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(208, 22);
            this.txtSifre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Şifre:";
            // 
            // frmKritikSifre
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 116);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKritikSifre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kritik Şifre";
            this.Load += new System.EventHandler(this.frmKritikSifre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private System.Windows.Forms.Label label1;
    }
}