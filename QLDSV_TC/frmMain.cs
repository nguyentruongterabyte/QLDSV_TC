using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {

            InitializeComponent();
        }

        public void HienThiMenu()
        {
            if (Program.mGroup == "SV")
            {
                MAGV.Text = $"Mã SV: {Program.username} -";
                HOTEN.Text = $"Họ tên sinh viên: {Program.mHoTen} -";

                // Chỉ có nhóm sinh viên mới không được tạo tài khoản 
                Program.frmChinh.btnTaoTK.Enabled = false;


            } else
            {
                HOTEN.Text = $"Họ tên giảng viên: {Program.mHoTen} -";
                MAGV.Text = $"Mã GV: {Program.username} -";

                // Các nhóm khác "SV" có thể tạo tài khoản theo quyền của mỗi nhóm
                Program.frmChinh.btnTaoTK.Enabled = true;
            }
            NHOM.Text = $"Nhóm: {Program.mGroup}";

            // Phân quyền
            ribBaoCao.Visible = ribDanhMuc.Visible = true;
            if (Program.mGroup == "PGV") { }
            
           
        }

        private Form CheckExists(Type fType)
        {
            foreach(Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f; 
                }
            }
            return null;
        }

        private void closeAllFormInFormMain()
        {
            foreach(Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoLogin));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmTaoLogin f = new frmTaoLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((MessageBox.Show("Bạn có chắc muốn đăng xuất tài khoản khỏi thiết bị này?",
                    "Xác nhận", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1))
                == System.Windows.Forms.DialogResult.Yes) {
                // Set các ribbon về trạng thái Visible = false
                Program.frmChinh.ribDanhMuc.Visible = Program.frmChinh.ribBaoCao.Visible = false;

                // Xóa các login, password, ... của người dùng trước và trả về giá trị ban đầu 
                Program.servername = Program.username = Program.mlogin = Program.password 
                = Program.mloginDN = Program.passwordDN = Program.mGroup = Program.mHoTen = "";
               
                Program.mKhoa = 0;

                // Set button đăng nhập ở trạng thái enable = true
                btnDangNhap.Enabled = true;

                // Set button đăng xuất ở trạng thái enable = false vì tài khoản đã bị
                // đăng xuất không thể bị đăng xuất lần nữa
                btnDangXuat.Enabled = false;

                // Enable nút tạo tài khoản
                btnTaoTK.Enabled = false;

                // Đóng tất cả các form trong form chính (Mdi)
                closeAllFormInFormMain();

                // Set các label của statusStrip về trạng thái default
                Program.frmChinh.MAGV.Text = Program.frmChinh.HOTEN.Text
                = Program.frmChinh.NHOM.Text = "";
 
            }
            

        }
    }
}
