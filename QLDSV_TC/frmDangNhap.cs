using DevExpress.Drawing.Internal.Fonts;
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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conn_publisher = new SqlConnection();



        private void LayDSPM(string cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed)
            {
                conn_publisher.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);

            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
            {
                conn_publisher.Close();
            }

            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu gốc.\nBạn xem lại tên SERVER của Publisher, và tên CSDL trong chuỗi kết nối.\n" + e.Message);
                return 0;
            }
        }


        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbKhoa.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

            if (KetNoi_CSDLGOC() == 0)
                { return; }
            LayDSPM("SELECT * FROM V_Get_Subscribers");
            cmbKhoa.SelectedIndex = 1;
            cmbKhoa.SelectedIndex = 0;

            txtPass.PasswordChar = '*';
            btnDangNhap.Enabled = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (radGiangVien.Checked == false && radSinhVien.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn vai trò đăng nhập!", "Thông báo", MessageBoxButtons.OK);
                return;
            }



            Program.servername = cmbKhoa.SelectedValue.ToString();
            Program.mlogin = txtLogin.Text;
            Program.password = txtPass.Text;


            if (Program.KetNoi() == 0)
            {
                return;
            };

            Program.mKhoa = cmbKhoa.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

           

            string strLenh = "";
            if (radGiangVien.Checked)
            {
                strLenh = "EXEC SP_LAY_THONG_TIN_GV_TU_LOGIN '" + Program.mlogin + "'";
               
            }

            if (radSinhVien.Checked)
            {
                strLenh = "EXEC SP_LAY_THONG_TIN_SV_TU_LOGIN '" + Program.mlogin + "'";
               
           }
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null)
            {
                MessageBox.Show("Lỗi chạy lệnh lấy thông tin đăng nhập.\n" + strLenh);
                return;
            }

            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
          
            if (Convert.IsDBNull(Program.username))
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
        }


        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtPass.PasswordChar = default;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            Program.frmChinh.Close();
        }
    }
}