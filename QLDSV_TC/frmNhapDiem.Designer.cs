namespace QLDSV_TC
{
    partial class frmNhapDiem
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGhiDiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhapDiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaiLTC = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numHocKy = new System.Windows.Forms.NumericUpDown();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bdsDSLTC = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new QLDSV_TC.DS();
            this.gv_DS_DangKy1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SP_LAY_DS_LTCTableAdapter = new QLDSV_TC.DSTableAdapters.SP_LAY_DS_LTCTableAdapter();
            this.gc_DS_DangKy = new DevExpress.XtraGrid.GridControl();
            this.gv_DS_DangKy2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_DS_DangKy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_DS_DangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_DS_DangKy2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGhiDiem);
            this.panelControl1.Controls.Add(this.btnNhapDiem);
            this.panelControl1.Controls.Add(this.btnTaiLTC);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.numHocKy);
            this.panelControl1.Controls.Add(this.cmbNienKhoa);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.cmbKhoa);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1384, 43);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGhiDiem
            // 
            this.btnGhiDiem.Appearance.BackColor = System.Drawing.Color.Cyan;
            this.btnGhiDiem.Appearance.Options.UseBackColor = true;
            this.btnGhiDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGhiDiem.Location = new System.Drawing.Point(1095, 9);
            this.btnGhiDiem.Name = "btnGhiDiem";
            this.btnGhiDiem.Size = new System.Drawing.Size(104, 31);
            this.btnGhiDiem.TabIndex = 6;
            this.btnGhiDiem.Text = "Ghi điểm";
            this.btnGhiDiem.Click += new System.EventHandler(this.btnGhiDiem_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.btnNhapDiem.Appearance.Options.UseBackColor = true;
            this.btnNhapDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapDiem.Location = new System.Drawing.Point(976, 9);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(104, 30);
            this.btnNhapDiem.TabIndex = 8;
            this.btnNhapDiem.Text = "Nhập điểm";
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // btnTaiLTC
            // 
            this.btnTaiLTC.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTaiLTC.Appearance.Options.UseBackColor = true;
            this.btnTaiLTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiLTC.Location = new System.Drawing.Point(855, 9);
            this.btnTaiLTC.Name = "btnTaiLTC";
            this.btnTaiLTC.Size = new System.Drawing.Size(104, 32);
            this.btnTaiLTC.TabIndex = 7;
            this.btnTaiLTC.Text = "Tải lớp tín chỉ";
            this.btnTaiLTC.Click += new System.EventHandler(this.btnTaiLTC_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Học kỳ";
            // 
            // numHocKy
            // 
            this.numHocKy.Location = new System.Drawing.Point(757, 11);
            this.numHocKy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHocKy.Name = "numHocKy";
            this.numHocKy.Size = new System.Drawing.Size(69, 21);
            this.numHocKy.TabIndex = 4;
            this.numHocKy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbNienKhoa
            // 
            this.cmbNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNienKhoa.FormattingEnabled = true;
            this.cmbNienKhoa.Location = new System.Drawing.Point(577, 11);
            this.cmbNienKhoa.Name = "cmbNienKhoa";
            this.cmbNienKhoa.Size = new System.Drawing.Size(100, 21);
            this.cmbNienKhoa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "niên khóa";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(312, 11);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(164, 21);
            this.cmbKhoa.TabIndex = 1;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bdsDSLTC;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 43);
            this.gridControl1.MainView = this.gv_DS_DangKy1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(518, 429);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_DS_DangKy1});
            // 
            // bdsDSLTC
            // 
            this.bdsDSLTC.DataMember = "SP_LAY_DS_LTC";
            this.bdsDSLTC.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gv_DS_DangKy1
            // 
            this.gv_DS_DangKy1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colTENMH,
            this.colNHOM,
            this.colHOTEN});
            this.gv_DS_DangKy1.GridControl = this.gridControl1;
            this.gv_DS_DangKy1.Name = "gv_DS_DangKy1";
            this.gv_DS_DangKy1.OptionsBehavior.Editable = false;
            // 
            // colMALTC
            // 
            this.colMALTC.Caption = "Mã LTC";
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            this.colMALTC.Width = 53;
            // 
            // colTENMH
            // 
            this.colTENMH.Caption = "Tên môn học";
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            this.colTENMH.Width = 157;
            // 
            // colNHOM
            // 
            this.colNHOM.Caption = "Nhóm";
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 2;
            this.colNHOM.Width = 48;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Caption = "Họ tên giảng viên";
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 3;
            this.colHOTEN.Width = 176;
            // 
            // SP_LAY_DS_LTCTableAdapter
            // 
            this.SP_LAY_DS_LTCTableAdapter.ClearBeforeFill = true;
            // 
            // gc_DS_DangKy
            // 
            this.gc_DS_DangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_DS_DangKy.Location = new System.Drawing.Point(518, 43);
            this.gc_DS_DangKy.MainView = this.gv_DS_DangKy2;
            this.gc_DS_DangKy.Name = "gc_DS_DangKy";
            this.gc_DS_DangKy.Size = new System.Drawing.Size(866, 429);
            this.gc_DS_DangKy.TabIndex = 2;
            this.gc_DS_DangKy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_DS_DangKy2});
            // 
            // gv_DS_DangKy2
            // 
            this.gv_DS_DangKy2.GridControl = this.gc_DS_DangKy;
            this.gv_DS_DangKy2.Name = "gv_DS_DangKy2";
            // 
            // frmNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 472);
            this.Controls.Add(this.gc_DS_DangKy);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmNhapDiem";
            this.Text = "Nhập điểm";
            this.Load += new System.EventHandler(this.frmNhapDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_DS_DangKy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_DS_DangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_DS_DangKy2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGhiDiem;
        private DevExpress.XtraEditors.SimpleButton btnNhapDiem;
        private DevExpress.XtraEditors.SimpleButton btnTaiLTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHocKy;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_DS_DangKy1;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private System.Windows.Forms.BindingSource bdsDSLTC;
        private DS DS;
        private DSTableAdapters.SP_LAY_DS_LTCTableAdapter SP_LAY_DS_LTCTableAdapter;
        private DevExpress.XtraGrid.GridControl gc_DS_DangKy;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_DS_DangKy2;
    }
}