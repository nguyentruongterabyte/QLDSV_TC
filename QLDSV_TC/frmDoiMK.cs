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
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void frmDoiMK_Load(object sender, EventArgs e)
        {
            txtLogin.Text = Program.mloginDN;
            txtOldPass.PasswordChar = txtNewPass.PasswordChar = txtRetype.PasswordChar = '*';
        }

        private void chkOldPassHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOldPassHienThi.Checked)
            {
                txtOldPass.PasswordChar = default;
            } else
            {
                txtOldPass.PasswordChar = '*';
            }
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtNewPass.PasswordChar = default;
            } else
            {
                txtNewPass.PasswordChar = '*';
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Validator.isEmptyText(txtOldPass.Text))
            {
                MessageBox.Show("Mật khẩu cũ không được để trống!", "", MessageBoxButtons.OK);
                txtOldPass.Focus();
                return;
            }
            if (Validator.isEmptyText(txtNewPass.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "", MessageBoxButtons.OK);
                txtNewPass.Focus();
                return;
            }
            if (Validator.isEmptyText (txtRetype.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!", "", MessageBoxButtons.OK);
                txtRetype.Focus();
                return;
            }
            if (Validator.checkConfirmPassword(txtNewPass.Text, txtRetype.Text))
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp", "", MessageBoxButtons.OK);
                txtRetype.Focus();
                return;
            }

            if (Validator.checkConfirmPassword(txtOldPass.Text, Program.passwordDN))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "", MessageBoxButtons.OK);
                txtOldPass.Focus();
                return;
            }

            if (Validator.isContainSpaceCharacters(txtNewPass.Text))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng!", "", MessageBoxButtons.OK);
                txtNewPass.Focus();
                return;
            }

            if (Validator.minLengthPassword(txtNewPass.Text, 3))
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 3 ký tự");
                txtNewPass.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn lưu thay đổi?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.Yes)
            {
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu!", "", MessageBoxButtons.OK);
                    return;
                }

                int state = Program.ExecSqlNonQuery($"EXEC SP_DOI_MAT_KHAU '{txtLogin.Text}', '{txtOldPass.Text}', '{txtNewPass.Text}'");

                if (state == 0) {
                    MessageBox.Show("Đổi mật khẩu thành công!\nMời bạn đăng nhập lại", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Program.DangXuat();
                    
                }


            }
        }

 
    }
}