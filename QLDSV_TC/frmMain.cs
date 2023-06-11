using DevExpress.XtraPrinting.Native.Lines;
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
                = btnDangKy.Enabled = btnChuyenLop.Enabled = Active;
        }

        public void autoDangNhap(string tk, string password, string vaiTro, string servername, int mKhoa)
        {
            Program.servername = servername;
            Program.mlogin = tk;
            Program.password = password;


            if (Program.KetNoi() == 0)
            {
                return;
            };

            Program.mKhoa = mKhoa;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;


            
            string strLenh = $"EXEC SP_LAY_THONG_TIN_{vaiTro}_TU_LOGIN '{Program.mlogin}'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null)
            {
                MessageBox.Show("Không thể lấy thông tin từ đăng nhập!", "", MessageBoxButtons.OK);
                return;
            }

            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);

            if (Program.myReader.IsDBNull(1))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\nBạn xem lại username, password",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Program.mHoTen = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();

            Program.frmChinh.btnDangNhap.Enabled = false;
            Program.frmChinh.btnDangXuat.Enabled = true;

            MessageBox.Show($"Đăng nhập thành công vào tài khoản {Program.mloginDN}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Program.frmChinh.HienThiMenu();

            btnDangNhap.Enabled = false;
            Program.frmChinh.btnDoiMK.Enabled = true;
            
        }

        public void HienThiMenu()
        {
            if (Program.mGroup == "SV")
            {
                lbMa.Text = $"Mã SV: {Program.username} -";
                lbHoTen.Text = $"Họ tên sinh viên: {Program.mHoTen} -";
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
                            = btnDiem.Enabled = btnChuyenLop.Enabled = true;
                        rprtPhieuDiemSV.Visible = rprtPGVKhoa.Visible = true;
                        break;
                    }
                case "PKT":
                    {
                    
                        btnHocPhi.Enabled = true; 
                        rprtHocPhiRibbon.Visible = true;
                        break;
                    }
                case "KHOA":
                    {
                        btnSinhVien.Enabled = btnLopHoc.Enabled
                            = btnMonHoc.Enabled = btnLopTinChi.Enabled
                            = btnDiem.Enabled = btnChuyenLop.Enabled = true;
                        btnHocPhi.Enabled = btnDangKy.Enabled = false;
                        rprtPhieuDiemSV.Visible = rprtPGVKhoa.Visible = true;
                        break;
                    }
                case "SV":
                    {
                        
                        btnDangKy.Enabled = true;
                        rprtPhieuDiemSV.Visible = true;
                        break;
                    }
            }
           
        }

        private Form isFormOpen(Type fType)
        {
            // Lấy tất cả các Form hiện tại trong ứng dụng
            var openForms = Application.OpenForms.Cast<Form>();

            // Tìm kiếm Form của Type đã chỉ định
            return openForms.FirstOrDefault(form => form.GetType() == fType);
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

            //autoDangNhap("ml", "123456", "GV", "DELLLATITUDEE65\\MSSQLSERVER03", 2);
            // DELLLATITUDEE65\MSSQLSERVER01 - Công nghệ thông tin
            // PGV: KT - 123456
            // KHOA: HTT - 123456
            // SV: n20dccn083 - 123456
            // DELLLATITUDEE65\MSSQLSERVER02 - Viễn thông
            // DELLLATITUDEE65\MSSQLSERVER03 - Học phí
            // KT: ML - 123456
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

        private void btnDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhapDiem));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmNhapDiem f = new frmNhapDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLopTinChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLtc));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmLtc f = new frmLtc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChuyenLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuyenLop));
            if (frm != null)
            {
                frm.Activate();

            } else
            {
                frmChuyenLop f = new frmChuyenLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangKy));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmDangKy f = new frmDangKy();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmMonHoc));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHocPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmHocPhi));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frmHocPhi f = new frmHocPhi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = isFormOpen(typeof(frptDanhSachLTC));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frptDanhSachLTC f = new frptDanhSachLTC();
                f.Show();
            }
        }

        private void btnDSSVDangKyLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = isFormOpen(typeof(frptDSSVDangKyLTC));
            if (frm != null)
            {
                frm.Activate();

            } else
            {
                frptDSSVDangKyLTC f = new frptDSSVDangKyLTC();
                f.Show();
            }
        }

        private void btnInPhieuDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = isFormOpen(typeof(frptPhieuDiem));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frptPhieuDiem f = new frptPhieuDiem();
                f.Show();
            }
        }

        private void btnDSBangDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = isFormOpen(typeof(frptBangDiemMH));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frptBangDiemMH f = new frptBangDiemMH();
                f.Show();
            }
        }

        private void btnDSDongHocPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = isFormOpen(typeof(frptDSDongHocPhi));
            if (frm != null)
            {
                frm.Activate();
            } else
            {
                frptDSDongHocPhi f = new frptDSDongHocPhi();
                f.Show();
            }
        }
    }
}
