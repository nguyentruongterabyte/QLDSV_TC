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
    public partial class frptDSDongHocPhi : DevExpress.XtraEditors.XtraForm
    {
        public frptDSDongHocPhi()
        {
            InitializeComponent();
        }

        

        private void LayNienKhoaVaoCmb()
        {
            int year = Program.layNamHienTai();
            for (int i = year - 5; i < year + 5; i++)
            {
                cmbNienKhoa.Items.Add($"{i}-{i + 1}");
            }
        }
        private void frptDSDongHocPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qLDSV_TCDataSet.LOP);
            LayNienKhoaVaoCmb();
            cmbLop.DataSource = bdsLopHoc;
            cmbLop.DisplayMember = "TENLOP";
            cmbLop.ValueMember = "MALOP";

            
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLopHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSV_TCDataSet);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            rprtDSDongHocPhi rpt = new rprtDSDongHocPhi(cmbLop.SelectedValue.ToString().Trim(), cmbNienKhoa.Text.Trim(), Convert.ToInt32(numHocKy.Text.Trim()));

            if (txtMaKhoa.Text.Trim() == "CNTT")
                rpt.lbKhoa.Text = "Công nghệ thông tin";
            else if (txtMaKhoa.Text.Trim() == "VT")
                rpt.lbKhoa.Text = "Viễn thông";
            rpt.lbMaLop.Text = cmbLop.SelectedValue.ToString();
            
            Program.KetNoi();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
