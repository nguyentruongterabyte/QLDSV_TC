using DevExpress.XtraEditors.Mask.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmLopHoc : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPHOCTableAdapter.Fill(this.DS.LOP);
            // TODO: This line of code loads data into the 'DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            Program.XoaItemPKT();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";

            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            } else
            {
                cmbKhoa.Enabled = false;
            }

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLopHoc.Position;

            panelControl2.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled
                = cmbKhoa.Enabled = false;

            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcLopHoc.Enabled = false;
            gcLopHoc.Visible = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLopHoc.Position;
            panelControl2.Enabled = true;
            bdsLopHoc.AddNew();

            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled
                = cmbKhoa.Enabled = false;


            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcLopHoc.Enabled = false;
            gcLopHoc.Visible = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLopHoc.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsSinhVien.Position = vitri;
            }
            gcLopHoc.Enabled = true;
            gcLopHoc.Visible = true;

            panelControl2.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = true;

            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            }
            else
            {
                cmbKhoa.Enabled = false;
            }

            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPHOCTableAdapter.Fill(this.DS.LOP);
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maLop = "";
            if (bdsSinhVien.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp học này vì đã có sinh viên!", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp học này?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    maLop = ((DataRowView)bdsLopHoc[bdsLopHoc.Position])["MALOP"].ToString();
                    bdsSinhVien.RemoveCurrent();

                    this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPHOCTableAdapter.Update(this.DS.LOP);
                    btnReload.PerformClick();
                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp học!\n" + ex.Message, "", MessageBoxButtons.OK);

                    this.LOPHOCTableAdapter.Fill(this.DS.LOP);
                    bdsLopHoc.Position = bdsLopHoc.Find("MALOP", maLop);
                    return;
                }
                
            }
            if (bdsLopHoc.Count == 0) {
                btnXoa.Enabled = false;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
