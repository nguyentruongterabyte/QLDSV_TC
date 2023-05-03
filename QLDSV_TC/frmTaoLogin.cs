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
    public partial class frmTaoLogin : DevExpress.XtraEditors.XtraForm
    {


        private void LayUsernameLogin(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) 
            { 
                Program.conn.Open(); 
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd, Program.conn);
            da.Fill(dt);
            Program.conn.Close();

            cmbUsername.DataSource = dt;
            cmbUsername.DisplayMember = "HOTEN";
            cmbUsername.ValueMember = "MAGV";
        }
        

        public frmTaoLogin()
        {
            InitializeComponent();
        }


        private void frmTaoLogin_Load(object sender, EventArgs e)
        {

            if (Program.KetNoi() == 0)
                { return; }
            // Lấy dữ liệu về đổ vào combo box username là MAGV
            // và display member là HOTEN của giảng viên
            LayUsernameLogin("SELECT * FROM V_Lay_MAGV_HOTEN");
            cmbUsername.SelectedIndex = 1;
            cmbUsername.SelectedIndex = 0;
        
            switch (Program.mGroup) {
                
                case "PGV":
                    cmbRole.DataSource = new Dictionary<String, String>()
                    {
                    // Login nhóm này được tạo tài khoản cho nhóm PGV, Khoa.  
                        {"PGV", "Phòng giáo vụ"},
                        {"KHOA", "Khoa"},
                    }.ToList();
                    break;
                
                case "KHOA":
                // Login này được tạo tài khoản cho nhóm Khoa. 
                    cmbRole.DataSource = new Dictionary<String, String>()
                    {
                        {"KHOA", "Khoa"}
                    }.ToList();
                    break;
                
                case "PKT":
                // Phòng kết toán chỉ được tạo tài khoản mới thuộc cùng nhóm. 
                    cmbRole.DataSource = new Dictionary<String, String>()
                    {
                        {"PKT", "Phòng kế toán"}
                    }.ToList();
                    break;
                default:
                    return;
            }

            cmbRole.ValueMember = "Key";
            cmbRole.DisplayMember = "Value";

            cmbRole.SelectedIndex = 1;
            cmbRole.SelectedIndex = 0;

            txtPass.PasswordChar = '*';
            txtRetype.PasswordChar = '*';
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtPass.PasswordChar = default;
            } else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void chkRetypeHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetypeHienThi.Checked)
            {
                txtRetype.PasswordChar = default;
            } else
            {
                txtRetype.PasswordChar = '*';
            } 
                
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "" || txtRetype.Text)
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtRetype.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtPass.Text != txtRetype.Text) { 
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
