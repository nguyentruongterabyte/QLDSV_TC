using DevExpress.XtraReports.UI;
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
    public partial class frptPhieuDiem : DevExpress.XtraEditors.XtraForm
    {
        public frptPhieuDiem()
        {
            InitializeComponent();
        }

       

        private void frptPhieuDiem_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.V_SINHVIEN);

            Program.XoaItemPKT();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";

            cmbKhoa.SelectedIndex = Program.mKhoa;

            cmbMaSV.DataSource = bdsSinhVien;
            cmbMaSV.DisplayMember = "HOTEN";
            cmbMaSV.ValueMember = "MASV";

            cmbMaSV.SelectedIndex = 0;
            txtMaSV.Text = "";

            cmbKhoa.SelectedIndex = Program.mKhoa;
            if (Program.mGroup == "PGV")
            {
                cmbKhoa.Enabled = true;
            }
            else
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cmbKhoa.SelectedValue.ToString();

            if (cmbKhoa.SelectedIndex != Program.mKhoa)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
        }

        private void cmbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSV.SelectedValue != null)
            {
                txtMaSV.Text = cmbMaSV.SelectedValue.ToString();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (Validator.isEmptyText(txtMaSV.Text)) {
                MessageBox.Show("Hãy nhập hoặc chọn mã sinh viên!");
                return; 
            }
            rprtPhieuDiem rpt = new rprtPhieuDiem(txtMaSV.Text.Trim());
            rpt.lbMSSV.Text = txtMaSV.Text.Trim().ToUpper();
            Program.KetNoi();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
