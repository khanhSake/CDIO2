namespace QuanLiHangHoa.GUI
{
    partial class frm_DangKy
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
            this.lbl_TenDangNhap = new System.Windows.Forms.Label();
            this.lbl_MatKhau = new System.Windows.Forms.Label();
            this.lbl_NhapLaiMatKhau = new System.Windows.Forms.Label();
            this.txt_TenDangNhap = new System.Windows.Forms.TextBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.txt_NhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.btn_DangKy = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_TenDangNhap
            // 
            this.lbl_TenDangNhap.AutoSize = true;
            this.lbl_TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenDangNhap.Location = new System.Drawing.Point(95, 41);
            this.lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            this.lbl_TenDangNhap.Size = new System.Drawing.Size(213, 32);
            this.lbl_TenDangNhap.TabIndex = 0;
            this.lbl_TenDangNhap.Text = "Tên Đăng Nhập";
            // 
            // lbl_MatKhau
            // 
            this.lbl_MatKhau.AutoSize = true;
            this.lbl_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MatKhau.Location = new System.Drawing.Point(95, 125);
            this.lbl_MatKhau.Name = "lbl_MatKhau";
            this.lbl_MatKhau.Size = new System.Drawing.Size(135, 32);
            this.lbl_MatKhau.TabIndex = 1;
            this.lbl_MatKhau.Text = "Mật Khẩu";
            // 
            // lbl_NhapLaiMatKhau
            // 
            this.lbl_NhapLaiMatKhau.AutoSize = true;
            this.lbl_NhapLaiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NhapLaiMatKhau.Location = new System.Drawing.Point(95, 201);
            this.lbl_NhapLaiMatKhau.Name = "lbl_NhapLaiMatKhau";
            this.lbl_NhapLaiMatKhau.Size = new System.Drawing.Size(256, 32);
            this.lbl_NhapLaiMatKhau.TabIndex = 2;
            this.lbl_NhapLaiMatKhau.Text = "Nhập Lại Mật Khẩu";
            // 
            // txt_TenDangNhap
            // 
            this.txt_TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDangNhap.Location = new System.Drawing.Point(365, 50);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(199, 30);
            this.txt_TenDangNhap.TabIndex = 3;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau.Location = new System.Drawing.Point(365, 128);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(199, 30);
            this.txt_MatKhau.TabIndex = 4;
            // 
            // txt_NhapLaiMatKhau
            // 
            this.txt_NhapLaiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhapLaiMatKhau.Location = new System.Drawing.Point(365, 201);
            this.txt_NhapLaiMatKhau.Name = "txt_NhapLaiMatKhau";
            this.txt_NhapLaiMatKhau.Size = new System.Drawing.Size(199, 30);
            this.txt_NhapLaiMatKhau.TabIndex = 5;
            // 
            // btn_DangKy
            // 
            this.btn_DangKy.Location = new System.Drawing.Point(125, 267);
            this.btn_DangKy.Name = "btn_DangKy";
            this.btn_DangKy.Size = new System.Drawing.Size(150, 47);
            this.btn_DangKy.TabIndex = 6;
            this.btn_DangKy.Text = "Đăng Ký";
            this.btn_DangKy.UseVisualStyleBackColor = true;
            this.btn_DangKy.Click += new System.EventHandler(this.btn_DangKy_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(400, 267);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(150, 47);
            this.btn_Thoat.TabIndex = 7;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frm_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangKy);
            this.Controls.Add(this.txt_NhapLaiMatKhau);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.txt_TenDangNhap);
            this.Controls.Add(this.lbl_NhapLaiMatKhau);
            this.Controls.Add(this.lbl_MatKhau);
            this.Controls.Add(this.lbl_TenDangNhap);
            this.Name = "frm_DangKy";
            this.Text = "Đăng Ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TenDangNhap;
        private System.Windows.Forms.Label lbl_MatKhau;
        private System.Windows.Forms.Label lbl_NhapLaiMatKhau;
        public System.Windows.Forms.TextBox txt_TenDangNhap;
        public System.Windows.Forms.TextBox txt_MatKhau;
        public System.Windows.Forms.TextBox txt_NhapLaiMatKhau;
        private System.Windows.Forms.Button btn_DangKy;
        private System.Windows.Forms.Button btn_Thoat;
    }
}