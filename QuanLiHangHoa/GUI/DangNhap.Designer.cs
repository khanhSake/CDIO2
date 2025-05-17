namespace QuanLiHangHoa.GUI
{
    partial class frm_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DangNhap));
            this.pb_DangNhap = new System.Windows.Forms.PictureBox();
            this.lbl_DangNhap = new System.Windows.Forms.Label();
            this.lbl_MatKhau = new System.Windows.Forms.Label();
            this.txt_TenDN = new System.Windows.Forms.TextBox();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.btn_DN = new System.Windows.Forms.Button();
            this.btn_DangKy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_DangNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_DangNhap
            // 
            this.pb_DangNhap.Image = ((System.Drawing.Image)(resources.GetObject("pb_DangNhap.Image")));
            this.pb_DangNhap.Location = new System.Drawing.Point(1, -1);
            this.pb_DangNhap.Name = "pb_DangNhap";
            this.pb_DangNhap.Size = new System.Drawing.Size(461, 575);
            this.pb_DangNhap.TabIndex = 0;
            this.pb_DangNhap.TabStop = false;
            // 
            // lbl_DangNhap
            // 
            this.lbl_DangNhap.AutoSize = true;
            this.lbl_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DangNhap.Location = new System.Drawing.Point(491, 78);
            this.lbl_DangNhap.Name = "lbl_DangNhap";
            this.lbl_DangNhap.Size = new System.Drawing.Size(226, 32);
            this.lbl_DangNhap.TabIndex = 1;
            this.lbl_DangNhap.Text = "Tên Đăng Nhập";
            // 
            // lbl_MatKhau
            // 
            this.lbl_MatKhau.AutoSize = true;
            this.lbl_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MatKhau.Location = new System.Drawing.Point(491, 177);
            this.lbl_MatKhau.Name = "lbl_MatKhau";
            this.lbl_MatKhau.Size = new System.Drawing.Size(143, 32);
            this.lbl_MatKhau.TabIndex = 2;
            this.lbl_MatKhau.Text = "Mật Khẩu";
            // 
            // txt_TenDN
            // 
            this.txt_TenDN.Location = new System.Drawing.Point(753, 88);
            this.txt_TenDN.Name = "txt_TenDN";
            this.txt_TenDN.Size = new System.Drawing.Size(189, 22);
            this.txt_TenDN.TabIndex = 3;
            // 
            // txt_MK
            // 
            this.txt_MK.Location = new System.Drawing.Point(753, 177);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.Size = new System.Drawing.Size(189, 22);
            this.txt_MK.TabIndex = 4;
            // 
            // btn_DN
            // 
            this.btn_DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DN.Location = new System.Drawing.Point(541, 276);
            this.btn_DN.Name = "btn_DN";
            this.btn_DN.Size = new System.Drawing.Size(201, 51);
            this.btn_DN.TabIndex = 5;
            this.btn_DN.Text = "Đăng Nhập";
            this.btn_DN.UseVisualStyleBackColor = true;
            this.btn_DN.Click += new System.EventHandler(this.btn_DN_Click);
            // 
            // btn_DangKy
            // 
            this.btn_DangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangKy.Location = new System.Drawing.Point(765, 276);
            this.btn_DangKy.Name = "btn_DangKy";
            this.btn_DangKy.Size = new System.Drawing.Size(201, 51);
            this.btn_DangKy.TabIndex = 6;
            this.btn_DangKy.Text = "Đăng Ký";
            this.btn_DangKy.UseVisualStyleBackColor = true;
            this.btn_DangKy.Click += new System.EventHandler(this.btn_DangKy_Click);
            // 
            // frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 571);
            this.Controls.Add(this.btn_DangKy);
            this.Controls.Add(this.btn_DN);
            this.Controls.Add(this.txt_MK);
            this.Controls.Add(this.txt_TenDN);
            this.Controls.Add(this.lbl_MatKhau);
            this.Controls.Add(this.lbl_DangNhap);
            this.Controls.Add(this.pb_DangNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_DangNhap";
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pb_DangNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_DangNhap;
        private System.Windows.Forms.Label lbl_DangNhap;
        private System.Windows.Forms.Label lbl_MatKhau;
        public  System.Windows.Forms.TextBox txt_TenDN;
        public  System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.Button btn_DN;
        private System.Windows.Forms.Button btn_DangKy;
    }
}