using DevExpress.LookAndFeel.Helpers;
using DevExpress.Utils.Gesture;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Columns;
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
    public partial class frmNhapDiem : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt_DS_DangKy = new DataTable();
        string maLTC;
        public frmNhapDiem()
        {
            InitializeComponent();
        }

        private void LayNienKhoaVaoCmb()
        {
            int year = Program.layNamHienTai();
            for (int i = year - 5; i < year + 5; i++)
            {
                cmbNienKhoa.Items.Add($"{i}-{i+1}");
            } 
        }

  

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            LayNienKhoaVaoCmb();
            cmbNienKhoa.SelectedIndex = 4;

            Program.XoaItemPKT();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";

            cmbKhoa.SelectedIndex = Program.mKhoa;


            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            } else
            {
                cmbKhoa.Enabled = false;
            }

            try {

                SP_LAY_DS_LTCTableAdapter.Connection.ConnectionString = Program.connstr;
                SP_LAY_DS_LTCTableAdapter.Fill(DS.SP_LAY_DS_LTC, cmbNienKhoa.Text, int.Parse(numHocKy.Text));
            }
            catch(System.Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaiLTC_Click(object sender, EventArgs e)
        {
            try
            {
               
                SP_LAY_DS_LTCTableAdapter.Connection.ConnectionString = Program.connstr;
                SP_LAY_DS_LTCTableAdapter.Fill(DS.SP_LAY_DS_LTC, cmbNienKhoa.Text, int.Parse(numHocKy.Text));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            if (bdsDSLTC.Position == -1)
            {
                MessageBox.Show("Học kỳ thuộc niên khóa chưa có lớp tín chỉ!", "", MessageBoxButtons.OK);
                return;
            }

            maLTC = ((DataRowView)bdsDSLTC[bdsDSLTC.Position])["MALTC"].ToString();
            
            string strLenh = $"EXEC SP_LAY_DSSV_DANGKY '{maLTC}'";
            dt_DS_DangKy = Program.ExecSqlDataTable(strLenh);
            gc_DS_DangKy.DataSource = dt_DS_DangKy;



            // Lấy đối tượng gv_DS_DangKy từ GridControl
            GridView gv_DS_DangKy = gc_DS_DangKy.MainView as GridView;

            // Thêm cột "MASV" và "HOTENSV" vào danh sách ReadOnlyColumns
            gv_DS_DangKy.Columns["MASV"].OptionsColumn.ReadOnly = true; // Bỏ chế độ ReadOnly cho cột "MASV"
            gv_DS_DangKy.Columns["HOTENSV"].OptionsColumn.ReadOnly = true; // Bỏ chế độ ReadOnly cho cột "HOTENSV"

            gv_DS_DangKy.Columns["MASV"].Caption = "Mã SV";
            gv_DS_DangKy.Columns["HOTENSV"].Caption = "Họ tên SV";
            gv_DS_DangKy.Columns["DIEM_CC"].Caption = "Điểm chuyên cần";
            gv_DS_DangKy.Columns["DIEM_GK"].Caption = "Điểm giữa kỳ";
            gv_DS_DangKy.Columns["DIEM_CK"].Caption = "Điểm cuối kỳ";

            // Thiết lập range giá trị cho cột điểm CC
            GridColumn colDiemCC = gv_DS_DangKy.Columns["DIEM_CC"];
            RepositoryItemSpinEdit spnDiemCC = new RepositoryItemSpinEdit();
            spnDiemCC.MinValue = 0;
            spnDiemCC.MaxValue = 10;
            colDiemCC.ColumnEdit = spnDiemCC;

            // Thiết lập range giá trị cho cột điểm GK
            GridColumn colDiemGK = gv_DS_DangKy.Columns["DIEM_GK"];
            RepositoryItemSpinEdit spnDiemGK = new RepositoryItemSpinEdit();
            spnDiemGK.MinValue = 0;
            spnDiemGK.MaxValue = 10;
            colDiemGK.ColumnEdit = spnDiemGK;

            // Thiết lập range giá trị cho cột điểm CK
            GridColumn colDiemCK = gv_DS_DangKy.Columns["DIEM_CK"];
            RepositoryItemSpinEdit spnDiemCK = new RepositoryItemSpinEdit();
            spnDiemCK.MinValue = 0;
            spnDiemCK.MaxValue = 10;
            colDiemCK.ColumnEdit = spnDiemCK;

            bool diemHetMonExists = false;
            foreach(GridColumn column in gv_DS_DangKy.Columns)
            {
                if (column.FieldName == "DIEMHETMON")
                {
                    diemHetMonExists = true;
                    break;
                }
            }
            if (!diemHetMonExists)
            {
                
                GridColumn colDiemHMH = gv_DS_DangKy.Columns.AddVisible("DIEMHETMON", "Điểm hết môn");
            }

   

            gv_DS_DangKy.CellValueChanged += (sder, ev) =>
            {
                float diemHMH;
                if (ev.Column.FieldName == "DIEM_CC" || ev.Column.FieldName == "DIEM_GK" || ev.Column.FieldName == "DIEM_CK")
                {
                    float diemCC = 0;
                    float diemGK = 0;
                    float diemCK = 0;

                    // Lấy giá trị từ các ô trong cột DIEM_CC, DIEM_GK, DIEM_CK tương ứng với hàng được thay đổi
                    object diemCCObj = gv_DS_DangKy.GetRowCellValue(ev.RowHandle, "DIEM_CC");
                    if (diemCCObj != DBNull.Value)
                    {
                        diemCC = Convert.ToSingle(diemCCObj);
                    }

                    object diemGKObj = gv_DS_DangKy.GetRowCellValue(ev.RowHandle, "DIEM_GK");
                    if (diemGKObj != DBNull.Value)
                    {
                        diemGK = Convert.ToSingle(diemGKObj);
                    }

                    object diemCKObj = gv_DS_DangKy.GetRowCellValue(ev.RowHandle, "DIEM_CK");
                    if (diemCKObj != DBNull.Value)
                    {
                        diemCK = Convert.ToSingle(diemCKObj);
                    }

                    // Tính điểm hết môn và gán giá trị vào cột DIEMHETMON
                    
                    diemHMH = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
                    
                    gv_DS_DangKy.SetRowCellValue(ev.RowHandle, "DIEMHETMON", "0");
                   
                    
                }


            };

        }

        private void btnGhiDiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DIEM_CC", typeof(int));
            dt.Columns.Add("DIEM_GK", typeof(float));
            dt.Columns.Add("DIEM_CK", typeof(float));

            int maLTCint = int.Parse(maLTC);
            for (int i = 0; i < dt_DS_DangKy.Rows.Count; i++)
            {
                dt.Rows.Add(
                    maLTCint,
                    dt_DS_DangKy.Rows[i]["MASV"],
                    dt_DS_DangKy.Rows[i]["DIEM_CC"],
                    dt_DS_DangKy.Rows[i]["DIEM_GK"],
                    dt_DS_DangKy.Rows[i]["DIEM_CK"]
                    );
            }

            try
            {
                SqlParameter para = new SqlParameter();
                para.SqlDbType = SqlDbType.Structured;
                para.TypeName = "dbo.TYPE_DANGKY";
                para.ParameterName = "@DIEMTHI";
                para.Value = dt;
            
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối về csdl!", "", MessageBoxButtons.OK);
                    return;
                }

                SqlCommand sqlCommand = new SqlCommand("SP_CAP_NHAT_DIEM", Program.conn);
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(para);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception ex)
            {
                MessageBox.Show("Cập nhật điểm thất bại!\n" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}