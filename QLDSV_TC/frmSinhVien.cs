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
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSinhVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void sINHVIENBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSinhVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {

            // Liên quan đến khóa ngoại: bắt buộc khóa ngoại bằng false, không kiểm tra ràng buộc khóa ngoại
            DS.EnforceConstraints = false;
            // Gán chuỗi kết nối ở thời điểm đăng nhập 
            // Nếu không có thì khi chạy chương trình ở thời điểm hiện tại thì chạy
            // nhưng trong tương lai nó sẽ không chạy
            // vì nếu sau này có thể tài khoản bị đổi mật khẩu
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.dANGKYTableAdapter.Fill(this.DS.DANGKY);

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
