using DevExpress.Internal;
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
    public partial class frptDanhSachLTC : DevExpress.XtraEditors.XtraForm
    {
        public frptDanhSachLTC()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void LayNienKhoaVaoCmb()
        {
            int year = Program.layNamHienTai();
            for (int i = year - 5; i < year + 5; i++)
            {
                cmbNienKhoa.Items.Add($"{i}-{i + 1}");
            }
        }

        private void frptDanhSachLTC_Load(object sender, EventArgs e)
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
            }
            else
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            rprtDSLTC rpt = new rprtDSLTC(cmbNienKhoa.Text.Trim(), Convert.ToInt32(numHocKy.Text.Trim()));
            rpt.lbKhoa.Text = cmbKhoa.Text;
            rpt.lbHocKy.Text = numHocKy.Text;
            rpt.lbNienKhoa.Text = cmbNienKhoa.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
