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

        public void SetEnableOfButtons(Boolean Active)
        {
            btnSinhVien.Enabled = btnLopHoc.Enabled = btnMonHoc.Enabled
                = btnLopTinChi.Enabled = btnDiem.Enabled = btnHocPhi.Enabled
                = btnDangKy.Enabled = Active;
        }

        

        public void HienThiMenu()
        {
            if (Program.mGroup == "SV")
            {
                lbHoTen.Text = $"Mã SV: {Program.username} -";
                lbMa.Text = $"Họ tên sinh viên: {Program.mHoTen} -";
                // Chỉ có nhóm sinh viên mới không được tạo tài khoản 
                Program.frmChinh.btnTaoTK.Enabled = false;


            } else
            {
                lbHoTen.Text = $"Họ tên giảng viên: {Program.mHoTen} -";
                lbMa.Text = $"Mã GV: {Program.username} -";
                // Các nhóm khác "SV" có thể tạo tài khoản theo quyền của mỗi nhóm
                Program.frmChinh.btnTaoTK.Enabled = true;
            }
            lbNhom.Text = $"Nhóm: {Program.mGroup}";

            ribBaoCao.Visible = ribDanhMuc.Visible = true;
            


            // Phân quyền
            switch (Program.mGroup)
            {
                case "PGV":
                    {
                        btnSinhVien.Enabled = btnLopHoc.Enabled
                            = btnMonHoc.Enabled = btnLopTinChi.Enabled
                            = btnDiem.Enabled = true;
          
                        break;
                    }
                case "PKT":
                    {
                    
                        btnHocPhi.Enabled = true; 
                        break;
                    }
                case "KHOA":
                    {
                        btnSinhVien.Enabled = btnLopHoc.Enabled
                            = btnMonHoc.Enabled = btnLopTinChi.Enabled
                            = btnDiem.Enabled = true;
                        btnHocPhi.Enabled = btnDangKy.Enabled = false;
                        break;
                    }
                case "SV":
                    {
                        
                        ribBaoCao.Visible = false;
                        btnDangKy.Enabled = true;  
                        break;
                    }
            }
           
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

        public void closeAllFormInFormMain()
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
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất tài khoản khỏi thiết bị này?",
                    "Xác nhận", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes) {
                Program.DangXuat();
            }
        }

        private void btnSinhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmSinhVien));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDoiMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDoiMK));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmDoiMK f = new frmDoiMK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void btnLopHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLopHoc));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmLopHoc f = new frmLopHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

    }
}
