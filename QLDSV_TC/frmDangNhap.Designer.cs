using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Data;
using System;

namespace QLDSV_TC
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

    
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmDangNhap
            // 
            this.ClientSize = new System.Drawing.Size(614, 433);
            this.Name = "frmDangNhap";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbKhoa;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox txtLogin;
        private TextBox txtPass;
        private DS dS;
        private BindingSource dSBindingSource;
        private GroupBox groupBox1;
        private Button btnDangNhap;
        private Button btnThoat;
        private RadioButton radSinhVien;
        private RadioButton radGiangVien;
    }
}