using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{

    public partial class frmSinhVien : DevExpress.XtraEditors.XtraForm
    {

        
        int vitri = 0;
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void LayThongTinLop(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd, Program.conn);
            da.Fill(dt);
            Program.conn.Close();

            cmbLop.DataSource = dt;
            cmbLop.DisplayMember = "TENLOP";
            cmbLop.ValueMember = "MALOP";
            

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            // Sau này có trường hợp tài khoản được kết nối với dataset có thể đổi
            // lại mật khẩu thì sẽ báo lỗi 
            // nên phải dùng tài khoản đang login để tableAdapter kết nối
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

            this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.DANGKYTableAdapter.Fill(this.DS.DANGKY);

            Program.XoaItemPKT();
            cmbKhoa.DataSource = Program.bds_dspm; // sao chép bds_dspm đã load ở form đăng nhập           
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";

            if (Program.KetNoi() == 0) {
                MessageBox.Show("Lỗi lấy thông tin lớp!");
                
            }
            LayThongTinLop("SELECT * FROM V_Lay_MALOP_TENLOP");
            cmbLop.SelectedIndex = 1;
            cmbLop.SelectedIndex = 0;
            // Chỉ có PGV mới được chuyển khoa để thao tác
            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            } 
            else
            {
                cmbKhoa.Enabled = false;
            }
        }



        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Phải giữ lại vị trí để khi thêm mới 
            // ta nhấn nút undo thì nó sẽ trở lại mẫu 
            // tin thứ i
            vitri = bdsSinhVien.Position;
            panelControl2.Enabled = true;
            bdsSinhVien.AddNew();

            dtpNgaySinh.EditValue = "";

            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = false;

            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcSinhVien.Enabled = false;
            gcSinhVien.Visible = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsSinhVien.Position = vitri;
            }
            gcSinhVien.Enabled = true;
            gcSinhVien.Visible = true;
            
            panelControl2.Enabled = false;

            btnThem.Enabled = btnHieuChinh.Enabled 
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = true;
            
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSinhVien.Position;
            panelControl2.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = false;

            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            gcSinhVien.Enabled = false;
            gcSinhVien.Visible = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Dữ liệu phân tán được dùng ở nhiều nơi nên
            // đôi khi ta phải nhấn reload để tải dữ liệu 
            // mà được người khác sử dụng về
            try
            {
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maSV = "";
            if (bdsDangKy.Count > 0)
            {
                MessageBox.Show("Không thể xóa sinh viên này vì sinh viên đã đăng ký lớp tín chỉ", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?",
                   "Xác nhận",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes) {
                try
                {
                    maSV = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString();
                    MessageBox.Show(maSV.ToString());
                    // Xóa trên giao diện trước
                    bdsSinhVien.RemoveCurrent();
                    
                    // Cập nhật trên database sau
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);

                    // Thực hiện reload
                    btnReload.PerformClick();
                } catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                    // Khi mình xóa nhân viên ở giao diện
                    // mà gặp lỗi nào đó không xóa được 
                    // ở trên database thì phải fill lại 
                    // sinh viên ở giao diện để tránh mâu thuẫn
                    this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                    bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);
                    return;
                }
            }
            if (bdsSinhVien.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bdsSinhVien.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcSinhVien.Enabled = true;
            gcSinhVien.Visible = true;
            btnThem.Enabled = btnHieuChinh.Enabled
                = btnXoa.Enabled = btnReload.Enabled
                = btnInDS.Enabled = btnThoat.Enabled = true;

            btnGhi.Enabled = btnPhucHoi.Enabled = false;

            panelControl2.Enabled = false;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        { 
            // Nếu cmbKhoa không có dữ liệu thì không làm gì hết
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
            }
            else
            {
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.DANGKYTableAdapter.Fill(this.DS.DANGKY);
            }
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                txtMaLop.Text = cmbLop.SelectedValue.ToString();
            }
        }
    }
}
