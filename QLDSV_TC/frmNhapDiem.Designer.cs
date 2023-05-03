namespace QLDSV_TC
{
    partial class frmNhapDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadLTC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadLTC
            // 
            this.btnLoadLTC.Location = new System.Drawing.Point(574, 12);
            this.btnLoadLTC.Name = "btnLoadLTC";
            this.btnLoadLTC.Size = new System.Drawing.Size(97, 34);
            this.btnLoadLTC.TabIndex = 0;
            this.btnLoadLTC.Text = "Tải lớp tín chỉ";
            this.btnLoadLTC.UseVisualStyleBackColor = true;
            this.btnLoadLTC.Click += new System.EventHandler(this.btnLoadLTC_Click);
            // 
            // frmNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 461);
            this.Controls.Add(this.btnLoadLTC);
            this.Name = "frmNhapDiem";
            this.Text = "frmNhapDiem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadLTC;
    }
}