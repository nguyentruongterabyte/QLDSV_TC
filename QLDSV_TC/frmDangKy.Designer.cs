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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LtcDaMogridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lOPTINCHIGridControl = new DevExpress.XtraGrid.GridControl();
            this.lOPTINCHIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV_TC.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHuyDK = new System.Windows.Forms.Button();
            this.txtMaLTC = new DevExpress.XtraEditors.TextEdit();
            this.dANGKYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtMaSV = new DevExpress.XtraEditors.TextEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            mASVLabel = new System.Windows.Forms.Label();
            mALTCLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LtcDaMogridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dANGKYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LtcDangKygridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
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
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1070, 67);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 582);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1070, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 67);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 515);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1070, 67);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 515);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LtcDaMogridControl);
            this.groupBox1.Controls.Add(this.lOPTINCHIGridControl);
            this.groupBox1.Location = new System.Drawing.Point(10, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1049, 271);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // LtcDaMogridControl
            // 
            this.LtcDaMogridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LtcDaMogridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDaMogridControl.Location = new System.Drawing.Point(3, 16);
            this.LtcDaMogridControl.MainView = this.gridView3;
            this.LtcDaMogridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDaMogridControl.MenuManager = this.barManager1;
            this.LtcDaMogridControl.Name = "LtcDaMogridControl";
            this.LtcDaMogridControl.Size = new System.Drawing.Size(1043, 253);
            this.LtcDaMogridControl.TabIndex = 1;
            this.LtcDaMogridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 284;
            this.gridView3.GridControl = this.LtcDaMogridControl;
            this.gridView3.Name = "gridView3";
            // 
            // lOPTINCHIGridControl
            // 
            this.lOPTINCHIGridControl.DataSource = this.lOPTINCHIBindingSource;
            this.lOPTINCHIGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOPTINCHIGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lOPTINCHIGridControl.Location = new System.Drawing.Point(3, 16);
            this.lOPTINCHIGridControl.MainView = this.gridView1;
            this.lOPTINCHIGridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lOPTINCHIGridControl.MenuManager = this.barManager1;
            this.lOPTINCHIGridControl.Name = "lOPTINCHIGridControl";
            this.lOPTINCHIGridControl.Size = new System.Drawing.Size(1043, 253);
            this.lOPTINCHIGridControl.TabIndex = 0;
            this.lOPTINCHIGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.lOPTINCHIGridControl.Visible = false;
            // 
            // lOPTINCHIBindingSource
            // 
            this.lOPTINCHIBindingSource.DataMember = "LOPTINCHI";
            this.lOPTINCHIBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.lOPTINCHIGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHuyDK);
            this.groupBox2.Controls.Add(mALTCLabel1);
            this.groupBox2.Controls.Add(this.txtMaLTC);
            this.groupBox2.Controls.Add(this.btnDangKy);
            this.groupBox2.Controls.Add(mASVLabel);
            this.groupBox2.Controls.Add(this.txtMaSV);
            this.groupBox2.Location = new System.Drawing.Point(10, 370);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(337, 223);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnHuyDK
            // 
            this.btnHuyDK.Enabled = false;
            this.btnHuyDK.Location = new System.Drawing.Point(176, 159);
            this.btnHuyDK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyDK.Name = "btnHuyDK";
            this.btnHuyDK.Size = new System.Drawing.Size(87, 19);
            this.btnHuyDK.TabIndex = 7;
            this.btnHuyDK.Text = "Hủy đăng ký";
            this.btnHuyDK.UseVisualStyleBackColor = true;
            this.btnHuyDK.Click += new System.EventHandler(this.btnHuyDK_Click);
            // 
            // txtMaLTC
            // 
            this.txtMaLTC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dANGKYBindingSource, "MALTC", true));
            this.txtMaLTC.Location = new System.Drawing.Point(97, 76);
            this.txtMaLTC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLTC.MenuManager = this.barManager1;
            this.txtMaLTC.Name = "txtMaLTC";
            this.txtMaLTC.Size = new System.Drawing.Size(107, 28);
            this.txtMaLTC.TabIndex = 6;
            // 
            // dANGKYBindingSource
            // 
            this.dANGKYBindingSource.DataMember = "DANGKY";
            this.dANGKYBindingSource.DataSource = this.dS;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Enabled = false;
            this.btnDangKy.Location = new System.Drawing.Point(55, 159);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(64, 19);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtMaSV
            // 
            this.txtMaSV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dANGKYBindingSource, "MASV", true));
            this.txtMaSV.Location = new System.Drawing.Point(97, 118);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSV.MenuManager = this.barManager1;
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(107, 28);
            this.txtMaSV.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LtcDangKygridControl);
            this.groupBox3.Location = new System.Drawing.Point(384, 370);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(675, 223);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // LtcDangKygridControl
            // 
            this.LtcDangKygridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LtcDangKygridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDangKygridControl.Location = new System.Drawing.Point(3, 16);
            this.LtcDangKygridControl.MainView = this.gridView2;
            this.LtcDangKygridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LtcDangKygridControl.MenuManager = this.barManager1;
            this.LtcDangKygridControl.Name = "LtcDangKygridControl";
            this.LtcDangKygridControl.Size = new System.Drawing.Size(669, 205);
            this.LtcDangKygridControl.TabIndex = 0;
            this.LtcDangKygridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.LtcDangKygridControl;
            this.gridView2.Name = "gridView2";
            // 
            // cbxNienKhoa
            // 
            this.cbxNienKhoa.FormattingEnabled = true;
            this.cbxNienKhoa.Location = new System.Drawing.Point(289, 41);
            this.cbxNienKhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxNienKhoa.Name = "cbxNienKhoa";
            this.cbxNienKhoa.Size = new System.Drawing.Size(146, 21);
            this.cbxNienKhoa.TabIndex = 7;
            // 
            // cbxHocKy
            // 
            this.cbxHocKy.FormattingEnabled = true;
            this.cbxHocKy.Location = new System.Drawing.Point(581, 39);
            this.cbxHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxHocKy.Name = "cbxHocKy";
            this.cbxHocKy.Size = new System.Drawing.Size(75, 21);
            this.cbxHocKy.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Niên khóa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Học kỳ :";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(725, 40);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(64, 19);
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
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 609);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxHocKy);
            this.Controls.Add(this.cbxNienKhoa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDangKy";
            this.Text = "frmDangKy";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LtcDaMogridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPTINCHIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dANGKYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LtcDangKygridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHocKy;
        private System.Windows.Forms.ComboBox cbxNienKhoa;
        private System.Windows.Forms.BindingSource lOPTINCHIBindingSource;
        private DS dS;
        private DSTableAdapters.LOPTINCHITableAdapter lOPTINCHITableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl lOPTINCHIGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl LtcDangKygridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl LtcDaMogridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.BindingSource dANGKYBindingSource;
        private DSTableAdapters.DANGKYTableAdapter dANGKYTableAdapter;
        private System.Windows.Forms.Button btnDangKy;
        private DevExpress.XtraEditors.TextEdit txtMaSV;
        private DevExpress.XtraEditors.TextEdit txtMaLTC;
        private System.Windows.Forms.Button btnHuyDK;
    }
}