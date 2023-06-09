using DevExpress.XtraEditors;
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
    public partial class frmChuyenLop : DevExpress.XtraEditors.XtraForm
    {
        private String mkhoaSV = "";
        private bool check_select = false;
        private String mkhoaLop = "";
        public frmChuyenLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            Program.XoaItemPKT();
            cbxCN.DataSource = Program.bds_dspm; // sao chép ở frmDangNhap
            cbxCN.DisplayMember = "TENKHOA";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = 1;
            cbxCN.SelectedIndex = Program.mKhoa;
            if (Program.mGroup == "KHOA")
            {
                cbxCN.Enabled = false;
            } else
            {
                cbxCN.Enabled = true;
            }
        }

        private void btnChonLop_Click(object sender, EventArgs e)
        {
            String maLopMoi = ((DataRowView)lOPBindingSource[lOPBindingSource.Position])["MALOP"].ToString();
            txtMaLopMoi.Text = maLopMoi;
            
            // Lấy mã khoa của lớp muốn chuyển SV đến
            mkhoaLop = ((DataRowView)lOPBindingSource[lOPBindingSource.Position])["MAKHOA"].ToString();

            // Nếu khác khoa thì phải nhập mã sinh viên mới
            if ((txtMaSV.Text != "" && txtMaLopMoi.Text != "") && mkhoaLop != mkhoaSV)
            {
                txtMaSVMoi.Enabled = true;
            }
            else { txtMaSVMoi.Enabled = false; }
        }

        private void btnChonSV_Click(object sender, EventArgs e)
        {
            String maSVCu = ((DataRowView)sINHVIENBindingSource[sINHVIENBindingSource.Position])["MASV"].ToString();
            txtMaSV.Text = maSVCu;

            //Lấy mã khoa của SV là khoa của lớp cũ chứa SV
            mkhoaSV = ((DataRowView)lOPBindingSource[lOPBindingSource.Position])["MAKHOA"].ToString();
            
            // Nếu khác khoa thì phải nhập mã sinh viên mới
            if ((txtMaSV.Text != "" && txtMaLopMoi.Text != "") && mkhoaLop != mkhoaSV)
            {
                txtMaSVMoi.Enabled = true;
            }
            else { txtMaSVMoi.Enabled = false; }
        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
  
            if(txtMaSV.Text.Trim() == "" || txtMaLopMoi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn đầy đủ dữ liệu", "", MessageBoxButtons.OK);
                return;
            }

            if(txtMaSVMoi.Enabled == true && txtMaSVMoi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên mới", "", MessageBoxButtons.OK);
                return;
            }

            if(txtMaSVMoi.Text.Length > 10)
            {
                MessageBox.Show("Mã sinh viên bạn nhập quá dài.\n Vui lòng nhập lại!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn chuyển sinh viên "+txtMaSV.Text.Trim()+" tới lớp "+txtMaLopMoi.Text.Trim()+" ?",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    if (mkhoaLop == mkhoaSV) // chuyển sinh viên vào lớp cùng khoa
                    {
                        String query = "EXEC SP_CHUYENLOP_CUNGKHOA '" + txtMaLopMoi.Text.Trim() + "', '" + txtMaSV.Text.Trim() + "'";
                        SuaDuLieu(query);
                        this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    }
                    else //Chuyển sinh viên vào lớp khác khoa
                    {
                        if (txtMaSVMoi.Text.Trim() == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã sinh viên mới", "", MessageBoxButtons.OK);
                            return;
                        }
                        if (CheckIDSinhVien() == false) // kiểm tra mã sinh viên mới có tồn tại
                        {
                            return;
                        }
                        String query = "EXEC SP_CHUYENLOP @MaSVMoi = '" + txtMaSVMoi.Text.Trim() + "', @MaLopMoi = '" + txtMaLopMoi.Text + "', @MaSVCu = '" + txtMaSV.Text + "'";
                        int state = SuaDuLieu(query);
                        if (state == 0)
                        {
                            MessageBox.Show("Chuyển lớp thành công !!!", "", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Chuyển lớp thất bại");
                   
                        }
                        this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    }
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.dS.LOP);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển lớp của hệ thống. Hãy thử lại\n" + ex.Message,
                    "", MessageBoxButtons.OK);
                    return;
                }
            }
            
        }

        public int SuaDuLieu(String strLenh)
        {
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                Program.conn.Close();
                MessageBox.Show("Lỗi cập nhật dữ liệu \n" + ex.Message, "", MessageBoxButtons.OK);
                return 1;
            }
        }

        private void cbxCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            // xử lí để không cbx không tự động chọn
            if (cbxCN.SelectedIndex != 0)
            {
                check_select = true;
            }
            //lấy tài khoản login để đăng nhập qua site khác
            if (check_select == true)
            {
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

                Program.servername = cbxCN.SelectedValue.ToString();

                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                }
                else
                {
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr; // Tạo kết nối để sau này thay đổi mật khẩu dữ liệu k bị lỗi
                    this.lOPTableAdapter.Fill(this.dS.LOP);

                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                }
            }
        }

        private bool CheckIDSinhVien()
        {
            // Kiểm tra trùng mã sv
            string query1 = $"EXEC SP_KIEM_TRA_TON_TAI_MASV '{txtMaSVMoi.Text}'";
            //if (resultMa == -1)
            //{
            //    MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
            //    return false;
            //}
            //if (resultMa == 1)
            //{
            //    MessageBox.Show("Mã sinh viên đã tồn tại ở khoa hiện tại !", "", MessageBoxButtons.OK);
            //    return false;
            //}
            //if (resultMa == 2)
            //{
            //    MessageBox.Show("Mã sinh viên đã tồn tại ở khoa khác !", "", MessageBoxButtons.OK);
            //    return false;
            //}

            if (Program.ExecSqlNonQuery(query1) == 1) {
                return false;
            }

            return true;
        }
    }
}