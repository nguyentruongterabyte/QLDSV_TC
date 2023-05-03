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
            frmMain frmChinh = new frmMain();
            Application.Run(frmChinh);

            //Application.Run(new frmDangNhap());

        }
    }
}
