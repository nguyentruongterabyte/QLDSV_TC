using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class rprtDSDongHocPhi : DevExpress.XtraReports.UI.XtraReport
    {
        public rprtDSDongHocPhi()
        {
            InitializeComponent();
        }

        private string ConvertNumberToWords(long number)
        {
            if (number == 0)
                return "Không đồng";

            string[] ones =
            {
            "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười",
            "mười một", "mười hai", "mười ba", "mười bốn", "mười năm", "mười sáu",
            "mười bảy", "mười tám", "mười chín"
        };

            string[] units =
            {
            "", "nghìn", "triệu", "tỷ"
        };

            string result = "";
            int unitIndex = 0;

            while (number > 0)
            {
                int group = (int)(number % 1000);
                number /= 1000;

                int hundreds = group / 100;
                int tens = group % 100 / 10;
                int onesDigit = group % 10;

                string groupResult = "";

                if (hundreds > 0)
                    groupResult += ones[hundreds] + " trăm ";

                if (tens > 1)
                    groupResult += ones[tens] + " mươi ";
                else if (tens == 1)
                    groupResult += "mười ";

                if (tens != 1 && onesDigit > 0)
                    groupResult += ones[onesDigit] + " ";

                if (group > 0)
                    groupResult += units[unitIndex] + " ";

                result = groupResult + result;
                unitIndex++;
            }

            return result.Trim();
        }
        public rprtDSDongHocPhi(string maLop, string nienKhoa, int hocKy)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = hocKy;

            //lbTienBangChu.Text = ConvertNumberToWords(Convert.ToInt32(lbTienBangSo.Text.Replace('.', ' ')));
        
            this.sqlDataSource1.Fill();

        }

    }
}
