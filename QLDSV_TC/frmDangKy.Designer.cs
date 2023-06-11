namespace QLDSV_TC
{
    partial class frmDangKy
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
            System.Windows.Forms.Label mASVLabel;
            System.Windows.Forms.Label mALTCLabel1;
            this.LtcDaMogridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsLopTCDaMo = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_TC.DS();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNIENKHOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSVDADANGKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bdsLopTC = new System.Windows.Forms.BindingSource(this.components);
            this.dANGKYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LtcDangKygridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbxNienKhoa = new System.Windows.Forms.ComboBox();
            this.cbxHocKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lOPTINCHITableAdapter = new QLDSV_TC.DSTableAdapters.LOPTINCHITableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DSTableAdapters.TableAdapterManager();
            this.dANGKYTableAdapter = new QLDSV_TC.DSTableAdapters.DANGKYTableAdapter();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lOPTINCHIGridControl = new DevExpress.XtraGrid.GridControl();
            this.txtMaSV = new DevExpress.XtraEditors.TextEdit();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtMaLTC = new DevExpress.XtraEditors.TextEdit();
            this.btnHuyDK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sP_LTC_DAMOTableAdapter = new QLDSV_TC.DSTableAdapters.SP_LTC_DAMOTableAdapter();
            mASVLabel = new System.Windows.Forms.Label();
            mALTCLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LtcDaMogridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLopTCDaMo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLopTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dANGKYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LtcDangKygridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLTC.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mASVLabel
            // 
            mASVLabel.AutoSize = true;
            mASVLabel.Location = new System.Drawing.Point(52, 120);
            mASVLabel.Name = "mASVLabel";
            mASVLabel.Size = new System.Drawing.Size(38, 13);
            mASVLabel.TabIndex = 3;
            mASVLabel.Text = "MASV:";
            // 
            // mALTCLabel1
            // 
            mALTCLabel1.AutoSize = true;
            mALTCLabel1.Location = new System.Drawing.Point(47, 79);
            mALTCLabel1.Name = "mALTCLabel1";
            mALTCLabel1.Size = new System.Drawing.Size(44, 13);
            mALTCLabel1.TabIndex = 5;
            mALTCLabel1.Text = "MALTC:";
            // 
            // LtcDaMogridControl
            // 
            this.LtcDaMogridControl.DataSource = this.bdsLopTCDaMo;
            this.LtcDaMogridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LtcDaMogridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDaMogridControl.Location = new System.Drawing.Point(3, 16);
            this.LtcDaMogridControl.MainView = this.gridView3;
            this.LtcDaMogridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDaMogridControl.Name = "LtcDaMogridControl";
            this.LtcDaMogridControl.Size = new System.Drawing.Size(1378, 253);
            this.LtcDaMogridControl.TabIndex = 1;
            this.LtcDaMogridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // bdsLopTCDaMo
            // 
            this.bdsLopTCDaMo.DataMember = "SP_LTC_DAMO";
            this.bdsLopTCDaMo.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colNIENKHOA,
            this.colHOCKY,
            this.colNHOM,
            this.colTENMH,
            this.colTENGV,
            this.colSOSVDADANGKY});
            this.gridView3.DetailHeight = 284;
            this.gridView3.GridControl = this.LtcDaMogridControl;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView3_MouseDown);
            // 
            // colMALTC
            // 
            this.colMALTC.Caption = "Mã LTC";
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            // 
            // colNIENKHOA
            // 
            this.colNIENKHOA.Caption = "Niên khóa";
            this.colNIENKHOA.FieldName = "NIENKHOA";
            this.colNIENKHOA.Name = "colNIENKHOA";
            this.colNIENKHOA.Visible = true;
            this.colNIENKHOA.VisibleIndex = 1;
            // 
            // colHOCKY
            // 
            this.colHOCKY.Caption = "Học kỳ";
            this.colHOCKY.FieldName = "HOCKY";
            this.colHOCKY.Name = "colHOCKY";
            this.colHOCKY.Visible = true;
            this.colHOCKY.VisibleIndex = 2;
            // 
            // colNHOM
            // 
            this.colNHOM.Caption = "Nhóm";
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 3;
            // 
            // colTENMH
            // 
            this.colTENMH.Caption = "Tên môn học";
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 4;
            // 
            // colTENGV
            // 
            this.colTENGV.Caption = "Tên giảng viên";
            this.colTENGV.FieldName = "TENGV";
            this.colTENGV.Name = "colTENGV";
            this.colTENGV.Visible = true;
            this.colTENGV.VisibleIndex = 5;
            // 
            // colSOSVDADANGKY
            // 
            this.colSOSVDADANGKY.Caption = "Số sinh viên đã ĐK";
            this.colSOSVDADANGKY.FieldName = "SOSVDADANGKY";
            this.colSOSVDADANGKY.Name = "colSOSVDADANGKY";
            this.colSOSVDADANGKY.Visible = true;
            this.colSOSVDADANGKY.VisibleIndex = 6;
            // 
            // bdsLopTC
            // 
            this.bdsLopTC.DataMember = "LOPTINCHI";
            this.bdsLopTC.DataSource = this.dS;
            // 
            // dANGKYBindingSource
            // 
            this.dANGKYBindingSource.DataMember = "DANGKY";
            this.dANGKYBindingSource.DataSource = this.dS;
            // 
            // LtcDangKygridControl
            // 
            this.LtcDangKygridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LtcDangKygridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDangKygridControl.Location = new System.Drawing.Point(3, 16);
            this.LtcDangKygridControl.MainView = this.gridView2;
            this.LtcDangKygridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDangKygridControl.Name = "LtcDangKygridControl";
            this.LtcDangKygridControl.Size = new System.Drawing.Size(1041, 411);
            this.LtcDangKygridControl.TabIndex = 0;
            this.LtcDangKygridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.LtcDangKygridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            // 
            // cbxNienKhoa
            // 
            this.cbxNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNienKhoa.FormattingEnabled = true;
            this.cbxNienKhoa.Location = new System.Drawing.Point(289, 15);
            this.cbxNienKhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxNienKhoa.Name = "cbxNienKhoa";
            this.cbxNienKhoa.Size = new System.Drawing.Size(146, 21);
            this.cbxNienKhoa.TabIndex = 7;
            // 
            // cbxHocKy
            // 
            this.cbxHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHocKy.FormattingEnabled = true;
            this.cbxHocKy.Location = new System.Drawing.Point(581, 15);
            this.cbxHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxHocKy.Name = "cbxHocKy";
            this.cbxHocKy.Size = new System.Drawing.Size(75, 21);
            this.cbxHocKy.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Niên khóa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Học kỳ :";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(717, 11);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(84, 39);
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lOPTINCHITableAdapter
            // 
            this.lOPTINCHITableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DANGKYTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.LOPTINCHITableAdapter = this.lOPTINCHITableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dANGKYTableAdapter
            // 
            this.dANGKYTableAdapter.ClearBeforeFill = true;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.lOPTINCHIGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // lOPTINCHIGridControl
            // 
            this.lOPTINCHIGridControl.DataSource = this.bdsLopTC;
            this.lOPTINCHIGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOPTINCHIGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lOPTINCHIGridControl.Location = new System.Drawing.Point(3, 16);
            this.lOPTINCHIGridControl.MainView = this.gridView1;
            this.lOPTINCHIGridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lOPTINCHIGridControl.Name = "lOPTINCHIGridControl";
            this.lOPTINCHIGridControl.Size = new System.Drawing.Size(1378, 253);
            this.lOPTINCHIGridControl.TabIndex = 0;
            this.lOPTINCHIGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.lOPTINCHIGridControl.Visible = false;
            // 
            // txtMaSV
            // 
            this.txtMaSV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dANGKYBindingSource, "MASV", true));
            this.txtMaSV.Location = new System.Drawing.Point(97, 118);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Properties.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(166, 28);
            this.txtMaSV.TabIndex = 4;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Enabled = false;
            this.btnDangKy.Location = new System.Drawing.Point(55, 159);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(64, 39);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtMaLTC
            // 
            this.txtMaLTC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dANGKYBindingSource, "MALTC", true));
            this.txtMaLTC.Location = new System.Drawing.Point(97, 76);
            this.txtMaLTC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLTC.Name = "txtMaLTC";
            this.txtMaLTC.Properties.ReadOnly = true;
            this.txtMaLTC.Size = new System.Drawing.Size(107, 28);
            this.txtMaLTC.TabIndex = 6;
            // 
            // btnHuyDK
            // 
            this.btnHuyDK.Enabled = false;
            this.btnHuyDK.Location = new System.Drawing.Point(176, 159);
            this.btnHuyDK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyDK.Name = "btnHuyDK";
            this.btnHuyDK.Size = new System.Drawing.Size(87, 39);
            this.btnHuyDK.TabIndex = 7;
            this.btnHuyDK.Text = "Hủy đăng ký";
            this.btnHuyDK.UseVisualStyleBackColor = true;
            this.btnHuyDK.Click += new System.EventHandler(this.btnHuyDK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHuyDK);
            this.groupBox2.Controls.Add(mALTCLabel1);
            this.groupBox2.Controls.Add(this.txtMaLTC);
            this.groupBox2.Controls.Add(this.btnDangKy);
            this.groupBox2.Controls.Add(mASVLabel);
            this.groupBox2.Controls.Add(this.txtMaSV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 325);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(337, 429);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LtcDangKygridControl);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(337, 325);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1047, 429);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LtcDaMogridControl);
            this.groupBox1.Controls.Add(this.lOPTINCHIGridControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1384, 271);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnTimKiem);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cbxHocKy);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.cbxNienKhoa);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1384, 54);
            this.panelControl1.TabIndex = 16;
            // 
            // sP_LTC_DAMOTableAdapter
            // 
            this.sP_LTC_DAMOTableAdapter.ClearBeforeFill = true;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 754);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmDangKy";
            this.Text = "Đăng ký lớp tín chỉ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LtcDaMogridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLopTCDaMo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLopTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dANGKYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LtcDangKygridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLTC.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHocKy;
        private System.Windows.Forms.ComboBox cbxNienKhoa;
        private System.Windows.Forms.BindingSource bdsLopTC;
        private DS dS;
        private DSTableAdapters.LOPTINCHITableAdapter lOPTINCHITableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl LtcDangKygridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl LtcDaMogridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.BindingSource dANGKYBindingSource;
        private DSTableAdapters.DANGKYTableAdapter dANGKYTableAdapter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHuyDK;
        private DevExpress.XtraEditors.TextEdit txtMaLTC;
        private System.Windows.Forms.Button btnDangKy;
        private DevExpress.XtraEditors.TextEdit txtMaSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl lOPTINCHIGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource bdsLopTCDaMo;
        private DSTableAdapters.SP_LTC_DAMOTableAdapter sP_LTC_DAMOTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colNIENKHOA;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCKY;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENGV;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSVDADANGKY;
    }
}