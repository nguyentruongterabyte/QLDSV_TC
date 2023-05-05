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
        public frmSinhVien()
        {
            InitializeComponent();
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


            cmbKhoa.DataSource = Program.bds_dspm; // sao chép bds_dspm đã load ở form đăng nhập
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mKhoa;
            if (Program.mGroup == "PGV") 
                cmbKhoa.Enabled = true;
            else 
                cmbKhoa.Enabled = false;
        }

  
    }
}
