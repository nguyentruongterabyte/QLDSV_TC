using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Diagnostics;
using System.Data;

namespace QLDSV_TC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static SqlConnection conn = new SqlConnection();
        public static string connstr;
        public static string connstr_publisher = "Data Source=DELLLATITUDEE65; Initial Catalog=QLDSV_TC; Integrated Security=True";

        public static SqlDataReader myReader;
        public static string servername = "";
        public static string username = "";
        public static string mlogin = "";
        public static string password = "";

        public static string database = "QLDSV_TC";
        public static string remotelogin = "HTKN";
        public static string remotepassword = "123456";
        public static string mloginDN = "";
        public static string passwordDN = "";
        public static string mGroup = "";
        public static string mHoTen = "";
        public static int mKhoa = 0;

        public static BindingSource bds_dspm = new BindingSource();
        public static frmMain frmChinh;


        public static void DangXuat()
        {
            // Set các ribbon về trạng thái Visible = false
            frmChinh.ribDanhMuc.Visible = frmChinh.ribBaoCao.Visible = false;

            // Xóa các login, password, ... của người dùng trước và trả về giá trị ban đầu 
            //Program.servername = Program.username = Program.mlogin = Program.password 
            //= Program.mloginDN = Program.passwordDN = Program.mGroup = Program.mHoTen = "";

            mKhoa = 0;

            // Set button đăng nhập ở trạng thái enable = true
            frmChinh.btnDangNhap.Enabled = true;

            // Set button đăng xuất ở trạng thái enable = false vì tài khoản đã bị
            // đăng xuất không thể bị đăng xuất lần nữa
            frmChinh.btnDangXuat.Enabled = false;

            // Disable nút tạo tài khoản
            frmChinh.btnTaoTK.Enabled = false;

            // Disable nut đổi mật
            frmChinh.btnDoiMK.Enabled = false;

            // Đóng tất cả các form trong form chính (Mdi)
            frmChinh.closeAllFormInFormMain();

            // Set các label của statusStrip về trạng thái default
            frmChinh.lbHoTen.Text = "Họ tên: ";
            frmChinh.lbNhom.Text = "Nhóm: ";
            frmChinh.lbMa.Text = "Mã: ";

            // Set tất cả các button của frmMain về Enable = false
            frmChinh.SetEnableOfButtons(false);


            frmDangNhap f = new frmDangNhap();
            f.MdiParent = frmChinh;
            f.Show();


        }

        public static int layNamHienTai()
        {
            return DateTime.Now.Year;
        }
        public static int KetNoi()
        {
            
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                connstr = "Data Source=" + servername + "; Initial Catalog=" +
                    database + "; User ID=" +
                    mlogin + "; password=" + password;
                // Test connstr
                //MessageBox.Show(connstr);
                conn.ConnectionString = connstr;
                conn.Open();
                return 1;
            } catch(Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại username và password.\n" + e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

        }


        public static List<string> LayTenServerTuCmbKhoa(ComboBox cmbKhoa)
        {
            List<string> servernames = new List<string>();

            foreach (DataRowView item in cmbKhoa.Items)
            {
                servernames.Add(item.Row["TENSERVER"].ToString());
            }

            return servernames;

        }

        public static void XoaItemPKT()
        {
            // Tìm kiếm index của item cần xóa trong bds_dspm
            int index = Program.bds_dspm.Find("TENKHOA", "Phòng kế toán");

            // Nếu item tồn tại trong bds_dspm
            if (index >= 0)
            {
                // Xóa item khỏi bds_dspm
                Program.bds_dspm.RemoveAt(index);
            }
        }

        // Cho phép xem, xóa, sửa, thêm.
        // Nhược điểm: tải dữ liệu chậm hơn so với datareader
        public static DataTable ExecSqlDataTable(string cmd)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        // Tải dữ liệu chỉ cho phép đọc, không cho hiệu chỉnh.
        // Ưu điểm tải dữ về rất nhanh
        public  static SqlDataReader ExecSqlDataReader(string cmd)
        {
            SqlDataReader myReader;
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            SqlCommand sqlcmd = sqlCommand;
            sqlcmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            } catch(Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        // Thực thi câu lệnh cập nhật trên sp đó không trả về Số liệu
        public static int ExecSqlNonQuery(String cmd)
        {
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            SqlCommand sqlcmd = sqlCommand;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                sqlcmd.ExecuteNonQuery(); 
                conn.Close();
                //
                return 0;
            } catch(SqlException e)
            {
                if (e.Message.Contains("Error converting data type varchar to int"))
                {
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày\" qua kiểu Number hoặc mở file Excel.");
                    
                } else
                {
                    MessageBox.Show(e.Message);
                }
                return e.State; // Trạng thái lỗi gửi từ RAISERROR trong SQL Server qua
            }
        }
        [STAThread] //Thêm thuộc tính STAThreadAttribute vào phương thức Main
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new frmMain();
            frmChinh.SetEnableOfButtons(false);
            Application.Run(frmChinh);
           
            //Application.Run(new frmDangNhap());

        }
    }
}
