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

        
        int vitri = 0;
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
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsSinhVien.Position = vitri;
            }
            gcSinhVien.Enabled = true;
            
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
    }
}
