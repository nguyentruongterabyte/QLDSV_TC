using DevExpress.XtraEditors;
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
    public partial class frmNhapDiem : DevExpress.XtraEditors.XtraForm
    {
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
            cmbNienKhoa.SelectedIndex = 5;

            Program.XoaItemPKT();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
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
                MessageBox.Show(cmbNienKhoa.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}