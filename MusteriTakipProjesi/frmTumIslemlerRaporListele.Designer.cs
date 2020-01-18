namespace MusteriTakipProjesi
{
    partial class frmTumIslemlerRaporListele
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTumIslemlerRaporListele));
            this.gridRapor = new DevExpress.XtraGrid.GridControl();
            this.gridViewRapor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IslemTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvrakNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ünvanı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Açıklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Verilen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Alınan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IslemTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Durum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IslemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnKilit = new DevExpress.XtraEditors.CheckButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.cmsGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelOlarakÇıkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRapor)).BeginInit();
            this.cmsGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridRapor
            // 
            this.gridRapor.Location = new System.Drawing.Point(13, 27);
            this.gridRapor.MainView = this.gridViewRapor;
            this.gridRapor.Name = "gridRapor";
            this.gridRapor.Size = new System.Drawing.Size(835, 471);
            this.gridRapor.TabIndex = 0;
            this.gridRapor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRapor});
            // 
            // gridViewRapor
            // 
            this.gridViewRapor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Tarih,
            this.IslemTuru,
            this.EvrakNo,
            this.Ünvanı,
            this.Açıklama,
            this.Verilen,
            this.Alınan,
            this.IslemTarihi,
            this.Durum,
            this.IslemID});
            this.gridViewRapor.GridControl = this.gridRapor;
            this.gridViewRapor.Name = "gridViewRapor";
            this.gridViewRapor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewRapor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewRapor.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewRapor.OptionsBehavior.Editable = false;
            this.gridViewRapor.OptionsView.ShowFooter = true;
            this.gridViewRapor.OptionsView.ShowGroupPanel = false;
            this.gridViewRapor.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Tarih, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewRapor.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewRapor_PopupMenuShowing);
            this.gridViewRapor.DoubleClick += new System.EventHandler(this.gridViewRapor_DoubleClick);
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.FieldName = "Tarih";
            this.Tarih.Name = "Tarih";
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 0;
            // 
            // IslemTuru
            // 
            this.IslemTuru.Caption = "İşlem Türü";
            this.IslemTuru.FieldName = "Tur";
            this.IslemTuru.Name = "IslemTuru";
            this.IslemTuru.Visible = true;
            this.IslemTuru.VisibleIndex = 1;
            // 
            // EvrakNo
            // 
            this.EvrakNo.Caption = "EvrakNo";
            this.EvrakNo.FieldName = "EvrakNo";
            this.EvrakNo.Name = "EvrakNo";
            this.EvrakNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EvrakNo", "{0}")});
            this.EvrakNo.Visible = true;
            this.EvrakNo.VisibleIndex = 2;
            // 
            // Ünvanı
            // 
            this.Ünvanı.Caption = "Ünvanı";
            this.Ünvanı.FieldName = "AdSoyad";
            this.Ünvanı.Name = "Ünvanı";
            this.Ünvanı.Visible = true;
            this.Ünvanı.VisibleIndex = 3;
            // 
            // Açıklama
            // 
            this.Açıklama.Caption = "Açıklama";
            this.Açıklama.FieldName = "Aciklama";
            this.Açıklama.Name = "Açıklama";
            this.Açıklama.Visible = true;
            this.Açıklama.VisibleIndex = 4;
            // 
            // Verilen
            // 
            this.Verilen.Caption = "Verilen";
            this.Verilen.FieldName = "Verilen";
            this.Verilen.Name = "Verilen";
            this.Verilen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Verilen", "TOP={0:0.##}")});
            this.Verilen.Visible = true;
            this.Verilen.VisibleIndex = 5;
            // 
            // Alınan
            // 
            this.Alınan.Caption = "Alınan";
            this.Alınan.FieldName = "Alinan";
            this.Alınan.Name = "Alınan";
            this.Alınan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Alinan", "TOP={0:0.##}")});
            this.Alınan.Visible = true;
            this.Alınan.VisibleIndex = 6;
            // 
            // IslemTarihi
            // 
            this.IslemTarihi.Caption = "İşlem Tarihi";
            this.IslemTarihi.FieldName = "IslemTarihi";
            this.IslemTarihi.Name = "IslemTarihi";
            this.IslemTarihi.Visible = true;
            this.IslemTarihi.VisibleIndex = 7;
            // 
            // Durum
            // 
            this.Durum.Caption = "Durum";
            this.Durum.FieldName = "Durum";
            this.Durum.Name = "Durum";
            // 
            // IslemID
            // 
            this.IslemID.Caption = "İşlem ID";
            this.IslemID.FieldName = "IslemID";
            this.IslemID.Name = "IslemID";
            // 
            // btnKilit
            // 
            this.btnKilit.Image = ((System.Drawing.Image)(resources.GetObject("btnKilit.Image")));
            this.btnKilit.Location = new System.Drawing.Point(797, 505);
            this.btnKilit.Name = "btnKilit";
            this.btnKilit.Size = new System.Drawing.Size(51, 44);
            this.btnKilit.TabIndex = 1;
            this.btnKilit.Click += new System.EventHandler(this.btnKilit_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Image = ((System.Drawing.Image)(resources.GetObject("btnYenile.Image")));
            this.btnYenile.Location = new System.Drawing.Point(13, 505);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(48, 44);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // cmsGrid
            // 
            this.cmsGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yenileToolStripMenuItem,
            this.excelOlarakÇıkartToolStripMenuItem});
            this.cmsGrid.Name = "cmsGrid";
            this.cmsGrid.Size = new System.Drawing.Size(208, 56);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // excelOlarakÇıkartToolStripMenuItem
            // 
            this.excelOlarakÇıkartToolStripMenuItem.Name = "excelOlarakÇıkartToolStripMenuItem";
            this.excelOlarakÇıkartToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.excelOlarakÇıkartToolStripMenuItem.Text = "Excel Olarak Çıkart";
            this.excelOlarakÇıkartToolStripMenuItem.Click += new System.EventHandler(this.excelOlarakÇıkartToolStripMenuItem_Click);
            // 
            // frmTumIslemlerRaporListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 561);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnKilit);
            this.Controls.Add(this.gridRapor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTumIslemlerRaporListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTumIslemlerRaporListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRapor)).EndInit();
            this.cmsGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridRapor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRapor;
        private DevExpress.XtraGrid.Columns.GridColumn Durum;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraGrid.Columns.GridColumn IslemTuru;
        private DevExpress.XtraGrid.Columns.GridColumn EvrakNo;
        private DevExpress.XtraGrid.Columns.GridColumn Ünvanı;
        private DevExpress.XtraGrid.Columns.GridColumn Açıklama;
        private DevExpress.XtraGrid.Columns.GridColumn Verilen;
        private DevExpress.XtraGrid.Columns.GridColumn Alınan;
        private DevExpress.XtraGrid.Columns.GridColumn IslemTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn IslemID;
        private DevExpress.XtraEditors.CheckButton btnKilit;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelOlarakÇıkartToolStripMenuItem;
    }
}