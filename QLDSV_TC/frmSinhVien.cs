using DevExpress.XtraBars;
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
    public partial class frmSinhVien : DevExpress.XtraEditors.XtraForm
    {
        private bool check_select = false;
        private String mLop = "";
        private String hanhDong = "";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            // TODO: This line of code loads data into the 'dS.DANGKY' table. You can move, or remove it, as needed.
            this.dANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dANGKYTableAdapter.Fill(this.dS.DANGKY);

            Program.XoaItemPKT();

            cbxCN.DataSource = Program.bds_dspm; // sao chép ở frmDangNhap
            cbxCN.DisplayMember = "TENKHOA";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = Program.mKhoa;
           

            if (Program.mGroup == "PGV")
            {
                cbxCN.Enabled = true;
            } else
            {
                cbxCN.Enabled = false;
            }
        }

        private void cbxCN_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxCN.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cbxCN.SelectedValue.ToString();

            if (cbxCN.SelectedIndex != Program.mKhoa)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }



            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr; // Tạo kết nối để sau này thay đổi mật khẩu dữ liệu k bị lỗi
                this.lOPTableAdapter.Fill(this.dS.LOP);

                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            }


           
        }

        private void EnableButton(bool b)
        {
            // phần 1
            gbThem.Enabled = b;
            btnGhi.Enabled = btnHuy.Enabled = b;

            //phần 2
            lOPGridControl.Enabled = sINHVIENGridControl.Enabled = !b;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnLamMoi.Enabled = !b;
            cbxCN.Enabled = !b;
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            mLop = ((DataRowView)lOPBindingSource[lOPBindingSource.Position])["MALOP"].ToString();
            EnableButton(true);
            this.sINHVIENBindingSource.AddNew();
            txtMaLop.Text = mLop;
            hanhDong = "ADD";
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            mLop = ((DataRowView)lOPBindingSource[lOPBindingSource.Position])["MALOP"].ToString();
            EnableButton(true);
            txtMaLop.Text = mLop;
            hanhDong = "UPDATE";
        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Thiếu kiểm tra các txt.Text
            if (hanhDong == "ADD" && CheckIDSinhVien() == false) // dữ liệu chưa phù hợp
            {
                return;
            }
            try
            {
                this.sINHVIENBindingSource.EndEdit();
                this.sINHVIENBindingSource.ResetCurrentItem();
                this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                btnLamMoi.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên!!\n" + ex.Message, "", MessageBoxButtons.OK);
            }

            this.EnableButton(false);
        }

        private bool CheckIDSinhVien()
        {
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "", MessageBoxButtons.OK);
                return false;
            }
            // Kiểm tra trùng mã lớp
            string query1 = "DECLARE  @return_value int \n"
                            + "EXEC  @return_value = SP_KIEM_TRA_TON_TAI_MASV \n"
                            + "@MASV = N'" + txtMaSV.Text + "' \n"
                            + "SELECT  'Return Value' = @return_value ";
            int resultMa = Program.CheckDataHelper(query1);
            if (resultMa == -1)
            {
                MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                return false;
            }
            if (resultMa == 1)
            {
                return false;
            }
            

            return true;
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dANGKYBindingSource.Count > 0)
            {
                MessageBox.Show("Không thể xóa sinh viên này vì đã đăng kí Lớp tín chỉ ",
                    "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa sinh viên này ?",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    sINHVIENBindingSource.RemoveCurrent(); // Xóa ở máy hiện tại trước
                    this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên của hệ thống. Hãy xóa lại\n" + ex.Message,
                    "", MessageBoxButtons.OK);

                    // Load lại danh sách nhân viên, vì có thể xóa trên giao diện nhưng chưa xóa trên db
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    return;
                }
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.sINHVIENBindingSource.CancelEdit();
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            EnableButton(false);
        }

        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);

                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btnGhi.Enabled) // nếu thông tin chưa được ghi
            {
                if (MessageBox.Show("Thông tin chưa được lưu. \n" +
                    "Bạn có thực sự muốn thoát ?",
                    "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
                return;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}