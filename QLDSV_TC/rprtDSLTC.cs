﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class rprtDSLTC : DevExpress.XtraReports.UI.XtraReport
    {
        public rprtDSLTC()
        {

        }
        public rprtDSLTC(string NienKhoa, int HocKy)
        {
            InitializeComponent();
            
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            Program.KetNoi();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = NienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = HocKy;
            this.sqlDataSource1.Fill();

        }
       

    }
}
