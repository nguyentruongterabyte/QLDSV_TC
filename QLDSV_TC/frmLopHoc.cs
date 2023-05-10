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
        string maKhoa = "";
        string maLop = "";
        
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void themKhoaHocVaoCmb()
        {
            int year = Program.layNamHienTai();
            for (int i = year - 2; i < year + 3; i++)
            {
                cmbKhoaHoc.Items.Add($"{i}-{i + 4}");
            }
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
            cmbKhoa.SelectedIndex = Program.mKhoa;
            themKhoaHocVaoCmb();
            // Thêm thuộc tính này vào người dùng có thể nhập khoa học khác
            cmbKhoaHoc.DropDownStyle = ComboBoxStyle.DropDown;

            maKhoa = ((DataRowView)bdsLopHoc[0])["MAKHOA"].ToString();

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

            txtMaKhoa.Text = maKhoa;

            maLop = txtMaLop.Text;

            panelControl2.Enabled = true;
            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled
                = cmbKhoa.Enabled = false;

            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcLopHoc.Enabled = false;
           
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLopHoc.Position;
            panelControl2.Enabled = true;
            bdsLopHoc.AddNew();

            txtMaKhoa.Text = maKhoa;


            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled
                = cmbKhoa.Enabled = false;


            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcLopHoc.Enabled = false;

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLopHoc.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsSinhVien.Position = vitri;
            }
            gcLopHoc.Enabled = true;


            panelControl2.Enabled = false;

            maLop = "";

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
                    bdsLopHoc.RemoveCurrent();

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
            if (Validator.isEmptyText(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống!", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (Validator.isEmptyText(txtTenLop.Text))
            {
                MessageBox.Show("Tên lớp không được để trống!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
            if (!Validator.isValidClassId(txtMaLop.Text.Trim()))
            {
                MessageBox.Show("Mã lớp không hợp lệ!\n Ví dụ: D16CQMT01, D15CQMT01, D15CQIS01 là những input hợp lệ", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
            if (!Validator.isValidYearRange(cmbKhoaHoc.Text.Trim()))
            {
                MessageBox.Show("Khóa học không hợp lệ!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }

            // begin check malop exist
            if (maLop != txtMaLop.Text)
            {
                Program.KetNoi();
                // Chạy sp kiểm tra lớp đã tồn tại ở 1 trong những phân mảnh hay chưa
                int state = Program.ExecSqlNonQuery($"EXEC SP_KIEM_TRA_TON_TAI_MALOP '{txtMaLop.Text}'");
                if (state != 0)
                {
                    // Nếu state = 1 thì có nghĩa là
                    // database đã có sinh viên có mã được nhập 
                    MessageBox.Show("Mã lớp đã tồn tại", "", MessageBoxButtons.OK);
                    return;
                }
            }
            // end check maLop exist
           
            try
            {
                bdsLopHoc.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPHOCTableAdapter.Update(this.DS.LOP);
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp học!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;

            }
            gcLopHoc.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = true;

            btnGhi.Enabled = btnPhucHoi.Enabled = false;

            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            } else
            {
                cmbKhoa.Enabled = false;
            }

            panelControl2.Enabled = false;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            
              // Lấy dữ liệu servername để kết nối
            Program.servername = cmbKhoa.SelectedValue.ToString();

            // Nếu servername chưa trùng với vai trò đăng nhập
            // thì lấy tài khoản hỗ trợ kết nối để kết nối 
            // sang phân mảnh mới
            if (cmbKhoa.SelectedIndex != Program.mKhoa)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            } 
            else
            {
                // Còn nếu vai trò đăng nhập hiện tại đã khớp
                // thì lấy tài khoản đang đăng nhập
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {

                this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPHOCTableAdapter.Fill(this.DS.LOP);

                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                maKhoa = ((DataRowView)bdsLopHoc[0])["MAKHOA"].ToString();
            }
        }
    }
}
