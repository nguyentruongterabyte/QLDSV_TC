using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        GridView gridView = new GridView();
        GridView gridViewDK = new GridView();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void lOPTINCHIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPTINCHIBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.DANGKY' table. You can move, or remove it, as needed.
            this.dANGKYTableAdapter.Fill(this.dS.DANGKY);

            this.lOPTINCHITableAdapter.Fill(this.dS.LOPTINCHI);

            load_CBX();
            LoadLtcDaMo();
            LoadLtcDaDangKy();

            // Lấy GridView hiện tại của ltcDAMO
            gridView = LtcDaMogridControl.MainView as GridView;

            // Đăng ký sự kiện FocusedRowChanged cua LtcDaMo
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;

            dANGKYBindingSource.AddNew();

            // Lấy GridView hiện tại của GridControl LtcDangKy
            gridViewDK = LtcDangKygridControl.MainView as GridView;

            // Đăng ký sự kiện FocusedRowChanged
            gridViewDK.FocusedRowChanged += GridView_FocusedRowChanged_DK;
        }

        public void LoadLtcDaDangKy()
        {
            String sql = "EXEC SP_LTC_DADANGKY '"+Program.username+"'";
            DataTable dt = Program.ExecSqlDataTable(sql);
            this.LtcDangKygridControl.DataSource = dt;
        }

        public void LoadLtcDaMo()
        {
            String sql = "EXEC SP_LTC_DAMO";
            DataTable dt = Program.ExecSqlDataTable(sql);
            this.LtcDaMogridControl.DataSource = dt;
        }

        private  void load_CBX()
        {
            var items = new BindingList<KeyValuePair<string, string>>();

            //items.Add(new KeyValuePair<string, string>("TATCA", "Tất cả"));
            items.Add(new KeyValuePair<string, string>("2015-2016", "2015-2016"));
            items.Add(new KeyValuePair<string, string>("2021-2022", "2021-2022"));
            items.Add(new KeyValuePair<string, string>("2022-2023", "2022-2023"));
            items.Add(new KeyValuePair<string, string>("2023-2024", "2023-2024"));

            cbxNienKhoa.DataSource = items;
            cbxNienKhoa.ValueMember = "Key";
            cbxNienKhoa.DisplayMember = "Value";

            var items1 = new BindingList<KeyValuePair<string, string>>();

            //items1.Add(new KeyValuePair<string, string>("TATCA", "Tất cả"));
            items1.Add(new KeyValuePair<string, string>("1", "1"));
            items1.Add(new KeyValuePair<string, string>("2", "2"));
            items1.Add(new KeyValuePair<string, string>("3", "3"));
            items1.Add(new KeyValuePair<string, string>("4", "4"));

            cbxHocKy.DataSource = items1;
            cbxHocKy.ValueMember = "Key";
            cbxHocKy.DisplayMember = "Value";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "EXEC SP_TIM_LTC_NIENKHOA_HOCKY @NIENKHOA = '"+cbxNienKhoa.SelectedValue.ToString() + "', @HOCKY = "+cbxHocKy.SelectedValue.ToString()+"";
            DataTable dt = Program.ExecSqlDataTable(sql);
            this.LtcDaMogridControl.DataSource = dt;
        }

        // Phương thức xử lý sự kiện FocusedRowChanged
        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowIndex = gridView.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                //object rowData = gridView.GetRow(e.FocusedRowHandle);

                // Xử lý dữ liệu
                rowIndex = gridView.FocusedRowHandle;

                // Lấy giá trị của cột "MaSV" tại dòng đang được chọn
                string maLtc = gridView.GetRowCellValue(rowIndex, "MALTC").ToString();

                txtMaLTC.Text = maLtc;
                txtMaSV.Text = Program.username;
            }
            btnDangKy.Enabled = true;
            btnHuyDK.Enabled = false;
        }

        private void GridView_FocusedRowChanged_DK(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowIndex = gridViewDK.FocusedRowHandle;
            if (rowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                //object rowData = gridView.GetRow(e.FocusedRowHandle);

                // Xử lý dữ liệu
                rowIndex = gridViewDK.FocusedRowHandle;

                // Lấy giá trị của cột "MaSV" tại dòng đang được chọn
                string maLtc = gridViewDK.GetRowCellValue(rowIndex, "MALTC").ToString();

                txtMaLTC.Text = maLtc;
                txtMaSV.Text = Program.username;
            }
            btnHuyDK.Enabled = true;
            btnDangKy.Enabled = false;
        }
        public void SuaDuLieu(String strLenh)
        {

            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Program.conn.Close();
                MessageBox.Show("Lỗi cập nhật dữ liệu \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(txtMaLTC.Text == "" || txtMaSV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Lớp tín chỉ !", "", MessageBoxButtons.OK);
                return;
            }
            if(CheckLTC_DADANGKY() == -1 || CheckLTC_DADANGKY() == 1)
            {
                return;
            }
            if (MessageBox.Show("Bạn có muốn đăng ký LTC này ?",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (CheckLTC_DADANGKY() == 2) // đã đăng ký nhưng đã hủy trước đó
                {
                    String query = "UPDATE DANGKY SET HUYDANGKY = 0 \n"
                    + "WHERE MALTC = " + txtMaLTC.Text + " AND MASV = '" + Program.username + "'";
                    SuaDuLieu(query);

                    // load lại dữ liệu
                    LoadLtcDaDangKy();
                    LoadLtcNienKhoaHocKy(); //load LTC theo niên khóa học kì đang hiển thị trên cbx

                    MessageBox.Show("Lớp tín chỉ được đăng ký lại thành công!!", "", MessageBoxButtons.OK);
                    return;
                }
                try
                {
                    this.dANGKYBindingSource.EndEdit();
                    this.dANGKYBindingSource.ResetCurrentItem();
                    this.dANGKYTableAdapter.Update(this.dS.DANGKY);

                    //Cho phép Null nên phải set lại thành False
                    String query = "UPDATE DANGKY SET HUYDANGKY = 0 \n"
                   + "WHERE MALTC = " + txtMaLTC.Text + " AND MASV = '" + Program.username + "'";
                    SuaDuLieu(query);

                    MessageBox.Show("Bạn đã đăng ký lớp tín chỉ thành công!!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi lớp học!!\n" + ex.Message, "", MessageBoxButtons.OK);
                }
                LoadLtcDaDangKy();
                //load lai LTC de cap nhat so sinh vien da dang ky
                LoadLtcNienKhoaHocKy();
            }
        }

        private void LoadLtcNienKhoaHocKy()
        {
            String sql = "EXEC SP_TIM_LTC_NIENKHOA_HOCKY @NIENKHOA = '" + cbxNienKhoa.SelectedValue.ToString() + "', @HOCKY = " + cbxHocKy.SelectedValue.ToString() + "";
            DataTable dt = Program.ExecSqlDataTable(sql);
            this.LtcDaMogridControl.DataSource = dt;
        }

        private int CheckLTC_DADANGKY()
        {
            // Kiểm tra trùng mã lớp
            string query1 = "DECLARE  @return_value int \n"
                            + "EXEC @return_value = SP_CHECK_LTC_DADANGKY \n"
                            + "@MASV = '"+Program.username+"', @MALTC = "+txtMaLTC.Text+" \n"
                            + "SELECT  'Return Value' = @return_value";
            int resultMa = Program.CheckDataHelper(query1);
            if (resultMa == -1)
            {
                MessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                return -1;
            }
            if (resultMa == 1) // Đang đăng kí LTC 
            {
                MessageBox.Show("Sinh viên đang đăng ký lớp tín chỉ này !", "", MessageBoxButtons.OK);
                return 1;
            }
            if (resultMa == 2) // Đăng ký LTC trước đó nhưng đã hủy
            {
                return 2;
            }

            return 0; // Chưa bao giờ đăng ký
        }

        private void btnHuyDK_Click(object sender, EventArgs e)
        {
            if (txtMaLTC.Text == "" || txtMaSV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Lớp tín chỉ !", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có muốn hủy đăng ký LTC này ?",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    String query = "UPDATE DANGKY SET HUYDANGKY = 1 \n"
                    + "WHERE MALTC = " + txtMaLTC.Text + " AND MASV = '" + Program.username + "'";
                    SuaDuLieu(query);

                    // load lại dữ liệu
                    LoadLtcDaDangKy();
                    LoadLtcNienKhoaHocKy();

                    MessageBox.Show("Hủy lớp tín chỉ thành công!!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hủy đăng lớp tín chỉ của hệ thống.\n" + ex.Message,
                    "", MessageBoxButtons.OK);
                    // Load lại danh sách LTC, vì có thể xóa trên giao diện nhưng chưa xóa trên db
                    LoadLtcDaDangKy();
                    LoadLtcNienKhoaHocKy();
                    return;
                }
            }
        }
    }
}