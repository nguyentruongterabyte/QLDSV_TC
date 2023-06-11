using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Security.Policy;

namespace QLDSV_TC
{
    public partial class rprtBangDiemMH : DevExpress.XtraReports.UI.XtraReport
    {
        public rprtBangDiemMH()
        {
            InitializeComponent();
        }

        public rprtBangDiemMH(string nienKhoa, int hocKy, string maMH, int nhom)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocKy;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = nhom;
            this.sqlDataSource1.Fill();
        }
       
    }
}
