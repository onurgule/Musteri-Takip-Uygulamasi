namespace MusteriTakipProjesi
{
    partial class frmCamera
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
            this.cbKameralar = new System.Windows.Forms.ComboBox();
            this.btnKameraSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnResimCek = new DevExpress.XtraEditors.SimpleButton();
            this.pbGoruntu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoruntu)).BeginInit();
            this.SuspendLayout();
            // 
            // cbKameralar
            // 
            this.cbKameralar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbKameralar.FormattingEnabled = true;
            this.cbKameralar.Location = new System.Drawing.Point(32, 300);
            this.cbKameralar.Name = "cbKameralar";
            this.cbKameralar.Size = new System.Drawing.Size(292, 24);
            this.cbKameralar.TabIndex = 0;
            this.cbKameralar.SelectedIndexChanged += new System.EventHandler(this.cbKameralar_SelectedIndexChanged);
            // 
            // btnKameraSec
            // 
            this.btnKameraSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKameraSec.Location = new System.Drawing.Point(343, 300);
            this.btnKameraSec.Name = "btnKameraSec";
            this.btnKameraSec.Size = new System.Drawing.Size(142, 23);
            this.btnKameraSec.TabIndex = 2;
            this.btnKameraSec.Text = "Kamera Seç";
            this.btnKameraSec.Click += new System.EventHandler(this.btnKameraSec_Click);
            // 
            // btnResimCek
            // 
            this.btnResimCek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResimCek.Location = new System.Drawing.Point(32, 338);
            this.btnResimCek.Name = "btnResimCek";
            this.btnResimCek.Size = new System.Drawing.Size(166, 42);
            this.btnResimCek.TabIndex = 3;
            this.btnResimCek.Text = "Resim Çek";
            this.btnResimCek.Click += new System.EventHandler(this.btnResimCek_Click);
            // 
            // pbGoruntu
            // 
            this.pbGoruntu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbGoruntu.Location = new System.Drawing.Point(12, 12);
            this.pbGoruntu.Name = "pbGoruntu";
            this.pbGoruntu.Size = new System.Drawing.Size(526, 271);
            this.pbGoruntu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGoruntu.TabIndex = 1;
            this.pbGoruntu.TabStop = false;
            // 
            // frmCamera
            // 
            this.AcceptButton = this.btnResimCek;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 392);
            this.Controls.Add(this.btnResimCek);
            this.Controls.Add(this.btnKameraSec);
            this.Controls.Add(this.pbGoruntu);
            this.Controls.Add(this.cbKameralar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTX - Kamera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCamera_FormClosing);
            this.Load += new System.EventHandler(this.frmCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGoruntu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKameralar;
        private System.Windows.Forms.PictureBox pbGoruntu;
        private DevExpress.XtraEditors.SimpleButton btnKameraSec;
        private DevExpress.XtraEditors.SimpleButton btnResimCek;
    }
}