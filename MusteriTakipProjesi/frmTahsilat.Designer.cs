namespace MusteriTakipProjesi
{
    partial class frmTahsilat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTahsilat));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAciklamaEkle = new DevExpress.XtraEditors.SimpleButton();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.cbAciklama = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEvrakNo = new DevExpress.XtraEditors.TextEdit();
            this.dateVade = new DevExpress.XtraEditors.DateEdit();
            this.dateTarih = new DevExpress.XtraEditors.DateEdit();
            this.lblIslem = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblAd = new DevExpress.XtraEditors.LabelControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvrakNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVade.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTarih.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAciklamaEkle);
            this.groupBox2.Controls.Add(this.txtTutar);
            this.groupBox2.Controls.Add(this.cbAciklama);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.Controls.Add(this.labelControl8);
            this.groupBox2.Location = new System.Drawing.Point(35, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 120);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // btnAciklamaEkle
            // 
            this.btnAciklamaEkle.Location = new System.Drawing.Point(444, 30);
            this.btnAciklamaEkle.Name = "btnAciklamaEkle";
            this.btnAciklamaEkle.Size = new System.Drawing.Size(38, 24);
            this.btnAciklamaEkle.TabIndex = 12;
            this.btnAciklamaEkle.Text = "...";
            this.btnAciklamaEkle.Click += new System.EventHandler(this.btnAciklamaEkle_Click);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(114, 70);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Properties.Mask.EditMask = "n2";
            this.txtTutar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTutar.Size = new System.Drawing.Size(158, 22);
            this.txtTutar.TabIndex = 10;
            // 
            // cbAciklama
            // 
            this.cbAciklama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAciklama.FormattingEnabled = true;
            this.cbAciklama.Location = new System.Drawing.Point(115, 30);
            this.cbAciklama.Name = "cbAciklama";
            this.cbAciklama.Size = new System.Drawing.Size(329, 24);
            this.cbAciklama.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 73);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 16);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Tutar";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(27, 30);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 16);
            this.labelControl8.TabIndex = 1;
            this.labelControl8.Text = "Açıklama";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEvrakNo);
            this.groupBox1.Controls.Add(this.dateVade);
            this.groupBox1.Controls.Add(this.dateTarih);
            this.groupBox1.Controls.Add(this.lblIslem);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Location = new System.Drawing.Point(35, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 162);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtEvrakNo
            // 
            this.txtEvrakNo.Location = new System.Drawing.Point(115, 120);
            this.txtEvrakNo.Name = "txtEvrakNo";
            this.txtEvrakNo.Properties.Mask.EditMask = "f0";
            this.txtEvrakNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEvrakNo.Size = new System.Drawing.Size(181, 22);
            this.txtEvrakNo.TabIndex = 8;
            // 
            // dateVade
            // 
            this.dateVade.EditValue = null;
            this.dateVade.Location = new System.Drawing.Point(115, 90);
            this.dateVade.Name = "dateVade";
            this.dateVade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateVade.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateVade.Size = new System.Drawing.Size(181, 22);
            this.dateVade.TabIndex = 7;
            // 
            // dateTarih
            // 
            this.dateTarih.EditValue = null;
            this.dateTarih.Location = new System.Drawing.Point(115, 59);
            this.dateTarih.Name = "dateTarih";
            this.dateTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTarih.Size = new System.Drawing.Size(181, 22);
            this.dateTarih.TabIndex = 6;
            // 
            // lblIslem
            // 
            this.lblIslem.Appearance.Font = new System.Drawing.Font("Tahoma", 12.8F);
            this.lblIslem.Location = new System.Drawing.Point(115, 24);
            this.lblIslem.Name = "lblIslem";
            this.lblIslem.Size = new System.Drawing.Size(72, 25);
            this.lblIslem.TabIndex = 5;
            this.lblIslem.Text = "Tahsilat";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 123);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 16);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Evrak No";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "İşlem Türü";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tarih";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 16);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Vade";
            // 
            // lblAd
            // 
            this.lblAd.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblAd.Location = new System.Drawing.Point(65, 10);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(59, 28);
            this.lblAd.TabIndex = 17;
            this.lblAd.Text = "lblAd";
            // 
            // btnVazgec
            // 
            this.btnVazgec.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(412, 362);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(105, 37);
            this.btnVazgec.TabIndex = 21;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(61, 362);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(137, 37);
            this.btnKaydet.TabIndex = 20;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmTahsilat
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 408);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTahsilat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTX - Tahsilat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTahsilat_FormClosing);
            this.Load += new System.EventHandler(this.frmTahsilat_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvrakNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVade.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTarih.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnAciklamaEkle;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private System.Windows.Forms.ComboBox cbAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtEvrakNo;
        private DevExpress.XtraEditors.DateEdit dateVade;
        private DevExpress.XtraEditors.DateEdit dateTarih;
        private DevExpress.XtraEditors.LabelControl lblIslem;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblAd;
    }
}