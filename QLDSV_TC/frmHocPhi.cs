using DevExpress.Utils.Extensions;
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
    public partial class frmHocPhi : DevExpress.XtraEditors.XtraForm
    {

        string maSV = "";
        int hocPhi = 0;
        public frmHocPhi()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMaLop.Text = "";
            if (Validator.isEmptyText(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập gì vào ô mã sinh viên cả!");
                txtMaSV.Focus();
                return;
            }

            maSV = txtMaSV.Text;

            Program.KetNoi();
            Program.myReader = Program.ExecSqlDataReader($"EXEC SP_TIM_THONG_TIN_SV '{maSV}'");
            if (Program.myReader.HasRows)
            {
                Program.myReader.Read();
                txtMaSV.Text = maSV = Program.myReader.GetString(0);
                txtHoTen.Text = Program.myReader.GetString(1);
                txtMaLop.Text = Program.myReader.GetString(2);
                Program.myReader.Close();

                
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_THONG_TIN_HOC_PHI, txtMaSV.Text);

                
                btnTuyChon.Enabled = btnThemMoi.Enabled = btnReload.Enabled = true;
                 
                
                if (bdsHocPhi.Count > 0)
                {
                    btnHieuChinh.Enabled = btnXoa.Enabled = true;
                }
                if (bdsCTDongHocPhi.Count > 0)
                {
                    btnXoaCT.Enabled = true;
                } else
                {
                    btnXoaCT.Enabled = false;
                }
            } else
            {
                bdsHocPhi.Clear();
                bdsCTDongHocPhi.Clear();
                btnTuyChon.Enabled = btnThemMoi.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = false;
                MessageBox.Show("Không tìm thấy thông tin sinh viên!");
         
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "SOTIENCANDONG" && e.IsGetData)
            {
                // Get the underlying DataRow for the current grid row
                DataRowView rowView = (DataRowView)e.Row;
                DataRow row = rowView.Row;

                // Get the values of "HOCPHI" and "SOTIENDADONG" columns
                if (row["HOCPHI"] != DBNull.Value && row["SOTIENDADONG"] != DBNull.Value)
                {
                    int hocPhi = Convert.ToInt32(row["HOCPHI"]);
                    int soTienDaDong = Convert.ToInt32(row["SOTIENDADONG"]);
                    int soTienCanDong = hocPhi - soTienDaDong;
                    e.Value = soTienCanDong;

                }

                // Calculate the value for "SOTIENCANDONG" column

                // Set the calculated value for the "SOTIENCANDONG" column
            }
        }

        private void setEnableOfButtonsCT(bool Activate) 
        {
            btnThemCT.Enabled = btnXoaCT.Enabled = btnSuaCT.Enabled =
                gcHocPhi.Enabled = btnTim.Enabled =
                 btnThemMoi.Enabled = btnHieuChinh.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnReload.Enabled = btnPhucHoi.Enabled = Activate;
            gridView2.OptionsBehavior.Editable = btnHuyCT.Enabled = btnGhiCT.Enabled = !Activate;
        
               
        } 

        private void setEnableOfButtons(bool Activate)
        {
            btnTim.Enabled = btnTuyChon.Enabled = cT_DONGHOCPHIGridControl.Enabled = btnThemMoi.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = Activate;

            gridView1.OptionsBehavior.Editable = btnGhi.Enabled = btnPhucHoi.Enabled = !Activate;
            gridView1.Columns["NIENKHOA"].OptionsColumn.ReadOnly = !Activate;
            gridView1.Columns["HOCKY"].OptionsColumn.ReadOnly = !Activate;
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsHocPhi.AddNew();
            setEnableOfButtons(false);

            // Sửa thuộc tính "ReadOnly" của cột "NIENKHOA" và "HOCKY" thành false
            gridView1.Columns["NIENKHOA"].OptionsColumn.ReadOnly = false;
            gridView1.Columns["HOCKY"].OptionsColumn.ReadOnly = false;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataRow row = gv.GetDataRow(e.RowHandle);
            row["MASV"] = maSV;
            row["SOTIENDADONG"] = 0;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentRowView = (DataRowView)bdsHocPhi.Current;
            DataRow currentRow = currentRowView.Row;
            string nienKhoa = currentRow["NIENKHOA"].ToString();
            string hocKy = currentRow["HOCKY"].ToString();
            string hocPhi = currentRow["HOCPHI"].ToString();
            
            if (!Validator.isValidYearRange(nienKhoa))
            {
                MessageBox.Show("Niên khóa nhập không hợp lệ!");
                return;
            }

            if (Validator.isEmptyText(hocKy))
            {
                MessageBox.Show("Không được để trống học kỳ!");
                return;
            }

            if (Validator.isEmptyText(hocPhi))
            {
                MessageBox.Show("Không được để trống học phí!");
                return;
            }
            try
            {
                bdsHocPhi.EndEdit();
                bdsHocPhi.ResetCurrentItem();
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Update(this.qLDSV_TCDataSet.SP_LAY_THONG_TIN_HOC_PHI);


            } catch(Exception ex) {
                MessageBox.Show("Lỗi ghi học phí! \n" + ex.Message);
                return;
            }
            setEnableOfButtons(true);
        }


        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_THONG_TIN_HOC_PHI, maSV);

            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload\n" + ex.Message);
            }
        }

        private void frmHocPhi_Load(object sender, EventArgs e)
        {
            this.qLDSV_TCDataSet.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.CT_DONGHOCPHI' table. You can move, or remove it, as needed.
            this.cT_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.cT_DONGHOCPHITableAdapter.Fill(this.qLDSV_TCDataSet.CT_DONGHOCPHI);

        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            DataRowView currentRowView = (DataRowView)bdsHocPhi.Current;
            DataRow currentRow = currentRowView.Row;
            hocPhi = Convert.ToInt32(currentRow["HOCPHI"].ToString());
            setEnableOfButtonsCT(false);
            bdsCTDongHocPhi.AddNew();
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setEnableOfButtons(true);
            
            bdsCTDongHocPhi.CancelEdit();
            bdsHocPhi.CancelEdit();
            
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            setEnableOfButtonsCT(true);
            bdsCTDongHocPhi.CancelEdit();
        }

        private void btnGhiCT_Click(object sender, EventArgs e)
        {
            DataRowView currentRowView = (DataRowView)bdsCTDongHocPhi.Current;
            DataRow currentRow = currentRowView.Row;
            string ngayDong = currentRow["NGAYDONG"].ToString();
            string soTienDong = currentRow["SOTIENDONG"].ToString();
            if (Validator.isEmptyText(ngayDong))
            {
                MessageBox.Show("Vui lòng nhập ngày đóng!");
                return;
            }
            if (Validator.isEmptyText(soTienDong))
            {
                MessageBox.Show("Vui lòng nhập số tiền đóng!");
                return;
            }

            int tongSoTienCanDong = 0;
            foreach(DataRowView rowView in bdsCTDongHocPhi)
            {
                DataRow row = rowView.Row;
                if (row["SOTIENDONG"] != DBNull.Value)
                {
                    int soTienCanDong = Convert.ToInt32(row["SOTIENDONG"]);
                    tongSoTienCanDong += soTienCanDong;
                }
            }
            if (tongSoTienCanDong > hocPhi)
            {
                MessageBox.Show("Tổng số tiền đóng đã vượt quá học phí!");
                return;
            }
            try
            {
                bdsCTDongHocPhi.EndEdit();
                bdsCTDongHocPhi.ResetCurrentItem();
                cT_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                cT_DONGHOCPHITableAdapter.Update(this.qLDSV_TCDataSet.CT_DONGHOCPHI);
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi chi tiết đóng học phí\n" + ex.Message);
                return;
            }
            setEnableOfButtonsCT(true);
        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTim.PerformClick();
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            DataRowView currentRowView = (DataRowView)bdsHocPhi.Current;
            DataRow currentRow = currentRowView.Row;
            hocPhi = Convert.ToInt32(currentRow["HOCPHI"].ToString());
            setEnableOfButtonsCT(false);
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng cửa sổ học phí?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setEnableOfButtons(false);
            gridView1.Columns["NIENKHOA"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["HOCKY"].OptionsColumn.ReadOnly = true;
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (bdsCTDongHocPhi.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa lần đóng học phí này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
               
                try
                {
                    bdsCTDongHocPhi.RemoveCurrent();
                    this.cT_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cT_DONGHOCPHITableAdapter.Update(qLDSV_TCDataSet.CT_DONGHOCPHI);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa chi tiết đóng học phí\n" + ex.Message);
                    this.cT_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cT_DONGHOCPHITableAdapter.Fill(qLDSV_TCDataSet.CT_DONGHOCPHI);

                    return;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDongHocPhi.Count > 0)
            {
                MessageBox.Show("Không thể xóa học phí này vì sinh viên đã đóng học phí!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa học phí này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try {
                    bdsHocPhi.RemoveCurrent();
                    this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sP_LAY_THONG_TIN_HOC_PHITableAdapter.Update(qLDSV_TCDataSet.SP_LAY_THONG_TIN_HOC_PHI);
                } catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa học phí!\n" + ex.Message);
                    return;
                }
            }
        }

        private void btnRefreshCT_Click(object sender, EventArgs e)
        {
            try
            {
                this.cT_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.cT_DONGHOCPHITableAdapter.Fill(qLDSV_TCDataSet.CT_DONGHOCPHI);
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload\n" + ex.Message);
                return;
            }
        }
    }
}
