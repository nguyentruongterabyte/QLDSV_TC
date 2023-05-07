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
    public partial class frmLopHoc : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.LOPHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPHOCTableAdapter.Fill(this.DS.LOP);
            // TODO: This line of code loads data into the 'DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
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

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLopHoc.Position;
            
        }
    }
}
