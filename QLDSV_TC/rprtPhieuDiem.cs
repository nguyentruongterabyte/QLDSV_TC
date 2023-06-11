﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class rprtPhieuDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public rprtPhieuDiem()
        {
        }
        public rprtPhieuDiem(string maSV)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maSV;
            this.sqlDataSource1.Fill();
        }
    }
}
