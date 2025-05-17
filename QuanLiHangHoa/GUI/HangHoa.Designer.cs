namespace QuanLiHangHoa.GUI
{
    partial class frm_HangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HangHoa));
            this.lbl_MaHH = new System.Windows.Forms.Label();
            this.lbl_TenHH = new System.Windows.Forms.Label();
            this.lbl_NgaySX = new System.Windows.Forms.Label();
            this.lbl_HanSX = new System.Windows.Forms.Label();
            this.lbl_GiaBan = new System.Windows.Forms.Label();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.lbl_NhaCC = new System.Windows.Forms.Label();
            this.lbl_NgayNhap = new System.Windows.Forms.Label();
            this.txt_MaHH = new System.Windows.Forms.TextBox();
            this.txt_TenHH = new System.Windows.Forms.TextBox();
            this.txt_GiaBan = new System.Windows.Forms.TextBox();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.dateTimePicker_NgaySX = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_HanSD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cb_NhaCungCap = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_Dem = new System.Windows.Forms.Button();
            this.txt_Dem = new System.Windows.Forms.TextBox();
            this.txt_Tim = new System.Windows.Forms.TextBox();
            this.txt_HinhHH = new System.Windows.Forms.TextBox();
            this.pb_HinhHH = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_HinhHH)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MaHH
            // 
            this.lbl_MaHH.AutoSize = true;
            this.lbl_MaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHH.Location = new System.Drawing.Point(44, 45);
            this.lbl_MaHH.Name = "lbl_MaHH";
            this.lbl_MaHH.Size = new System.Drawing.Size(86, 29);
            this.lbl_MaHH.TabIndex = 0;
            this.lbl_MaHH.Text = "Mã HH";
            // 
            // lbl_TenHH
            // 
            this.lbl_TenHH.AutoSize = true;
            this.lbl_TenHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenHH.Location = new System.Drawing.Point(44, 108);
            this.lbl_TenHH.Name = "lbl_TenHH";
            this.lbl_TenHH.Size = new System.Drawing.Size(96, 29);
            this.lbl_TenHH.TabIndex = 1;
            this.lbl_TenHH.Text = "Tên HH";
            // 
            // lbl_NgaySX
            // 
            this.lbl_NgaySX.AutoSize = true;
            this.lbl_NgaySX.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgaySX.Location = new System.Drawing.Point(44, 176);
            this.lbl_NgaySX.Name = "lbl_NgaySX";
            this.lbl_NgaySX.Size = new System.Drawing.Size(108, 29);
            this.lbl_NgaySX.TabIndex = 2;
            this.lbl_NgaySX.Text = "Ngày SX";
            // 
            // lbl_HanSX
            // 
            this.lbl_HanSX.AutoSize = true;
            this.lbl_HanSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HanSX.Location = new System.Drawing.Point(44, 244);
            this.lbl_HanSX.Name = "lbl_HanSX";
            this.lbl_HanSX.Size = new System.Drawing.Size(95, 29);
            this.lbl_HanSX.TabIndex = 3;
            this.lbl_HanSX.Text = "Hạn SD";
            // 
            // lbl_GiaBan
            // 
            this.lbl_GiaBan.AutoSize = true;
            this.lbl_GiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GiaBan.Location = new System.Drawing.Point(369, 45);
            this.lbl_GiaBan.Name = "lbl_GiaBan";
            this.lbl_GiaBan.Size = new System.Drawing.Size(98, 29);
            this.lbl_GiaBan.TabIndex = 4;
            this.lbl_GiaBan.Text = "Giá Bán";
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.AutoSize = true;
            this.lbl_SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoLuong.Location = new System.Drawing.Point(369, 108);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(116, 29);
            this.lbl_SoLuong.TabIndex = 5;
            this.lbl_SoLuong.Text = "Số Lượng";
            // 
            // lbl_NhaCC
            // 
            this.lbl_NhaCC.AutoSize = true;
            this.lbl_NhaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NhaCC.Location = new System.Drawing.Point(369, 176);
            this.lbl_NhaCC.Name = "lbl_NhaCC";
            this.lbl_NhaCC.Size = new System.Drawing.Size(170, 29);
            this.lbl_NhaCC.TabIndex = 6;
            this.lbl_NhaCC.Text = "Nhà Cung Cấp";
            // 
            // lbl_NgayNhap
            // 
            this.lbl_NgayNhap.AutoSize = true;
            this.lbl_NgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayNhap.Location = new System.Drawing.Point(369, 244);
            this.lbl_NgayNhap.Name = "lbl_NgayNhap";
            this.lbl_NgayNhap.Size = new System.Drawing.Size(133, 29);
            this.lbl_NgayNhap.TabIndex = 7;
            this.lbl_NgayNhap.Text = "Ngày Nhập";
            // 
            // txt_MaHH
            // 
            this.txt_MaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaHH.Location = new System.Drawing.Point(163, 42);
            this.txt_MaHH.Name = "txt_MaHH";
            this.txt_MaHH.Size = new System.Drawing.Size(135, 34);
            this.txt_MaHH.TabIndex = 8;
            // 
            // txt_TenHH
            // 
            this.txt_TenHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenHH.Location = new System.Drawing.Point(163, 108);
            this.txt_TenHH.Name = "txt_TenHH";
            this.txt_TenHH.Size = new System.Drawing.Size(200, 34);
            this.txt_TenHH.TabIndex = 9;
            // 
            // txt_GiaBan
            // 
            this.txt_GiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GiaBan.Location = new System.Drawing.Point(490, 45);
            this.txt_GiaBan.Name = "txt_GiaBan";
            this.txt_GiaBan.Size = new System.Drawing.Size(135, 34);
            this.txt_GiaBan.TabIndex = 10;
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLuong.Location = new System.Drawing.Point(491, 108);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(135, 34);
            this.txt_SoLuong.TabIndex = 11;
            // 
            // dateTimePicker_NgaySX
            // 
            this.dateTimePicker_NgaySX.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgaySX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_NgaySX.Location = new System.Drawing.Point(164, 177);
            this.dateTimePicker_NgaySX.Name = "dateTimePicker_NgaySX";
            this.dateTimePicker_NgaySX.Size = new System.Drawing.Size(160, 22);
            this.dateTimePicker_NgaySX.TabIndex = 12;
            this.dateTimePicker_NgaySX.Value = new System.DateTime(2025, 3, 7, 0, 0, 0, 0);
            // 
            // dateTimePicker_HanSD
            // 
            this.dateTimePicker_HanSD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_HanSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_HanSD.Location = new System.Drawing.Point(163, 251);
            this.dateTimePicker_HanSD.Name = "dateTimePicker_HanSD";
            this.dateTimePicker_HanSD.Size = new System.Drawing.Size(161, 22);
            this.dateTimePicker_HanSD.TabIndex = 13;
            this.dateTimePicker_HanSD.Value = new System.DateTime(2025, 3, 7, 0, 0, 0, 0);
            // 
            // dateTimePicker_NgayNhap
            // 
            this.dateTimePicker_NgayNhap.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_NgayNhap.Location = new System.Drawing.Point(528, 251);
            this.dateTimePicker_NgayNhap.Name = "dateTimePicker_NgayNhap";
            this.dateTimePicker_NgayNhap.Size = new System.Drawing.Size(161, 22);
            this.dateTimePicker_NgayNhap.TabIndex = 14;
            this.dateTimePicker_NgayNhap.Value = new System.DateTime(2025, 3, 7, 0, 0, 0, 0);
            // 
            // cb_NhaCungCap
            // 
            this.cb_NhaCungCap.FormattingEnabled = true;
            this.cb_NhaCungCap.Items.AddRange(new object[] {
            "Siêu Thị Go",
            "Siêu Thị Lotte",
            "Cửa Hàng Biên Long",
            "Công Ty Thực Phẩm",
            "Chợ Cồn"});
            this.cb_NhaCungCap.Location = new System.Drawing.Point(545, 179);
            this.cb_NhaCungCap.Name = "cb_NhaCungCap";
            this.cb_NhaCungCap.Size = new System.Drawing.Size(175, 24);
            this.cb_NhaCungCap.TabIndex = 15;
            this.cb_NhaCungCap.SelectedIndexChanged += new System.EventHandler(this.cb_NhaCungCap_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 318);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1321, 348);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(754, 117);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(114, 47);
            this.btn_Them.TabIndex = 17;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Location = new System.Drawing.Point(907, 117);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(117, 47);
            this.btn_Sua.TabIndex = 18;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(774, 194);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(94, 47);
            this.btn_Xoa.TabIndex = 19;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Location = new System.Drawing.Point(907, 194);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(104, 47);
            this.btn_Reset.TabIndex = 20;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(1491, 491);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(94, 47);
            this.btn_Tim.TabIndex = 21;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // btn_Dem
            // 
            this.btn_Dem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dem.Location = new System.Drawing.Point(694, 45);
            this.btn_Dem.Name = "btn_Dem";
            this.btn_Dem.Size = new System.Drawing.Size(94, 47);
            this.btn_Dem.TabIndex = 22;
            this.btn_Dem.Text = "Đếm";
            this.btn_Dem.UseVisualStyleBackColor = true;
            this.btn_Dem.Click += new System.EventHandler(this.btn_Dem_Click);
            // 
            // txt_Dem
            // 
            this.txt_Dem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Dem.Location = new System.Drawing.Point(824, 53);
            this.txt_Dem.Name = "txt_Dem";
            this.txt_Dem.Size = new System.Drawing.Size(104, 34);
            this.txt_Dem.TabIndex = 23;
            // 
            // txt_Tim
            // 
            this.txt_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tim.Location = new System.Drawing.Point(1481, 570);
            this.txt_Tim.Name = "txt_Tim";
            this.txt_Tim.Size = new System.Drawing.Size(104, 34);
            this.txt_Tim.TabIndex = 24;
            // 
            // txt_HinhHH
            // 
            this.txt_HinhHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HinhHH.Location = new System.Drawing.Point(1367, 318);
            this.txt_HinhHH.Name = "txt_HinhHH";
            this.txt_HinhHH.Size = new System.Drawing.Size(234, 34);
            this.txt_HinhHH.TabIndex = 26;
            this.txt_HinhHH.Text = "MyTom.jpg";
            // 
            // pb_HinhHH
            // 
            this.pb_HinhHH.Image = global::QuanLiHangHoa.Properties.Resources.MyTom;
            this.pb_HinhHH.Location = new System.Drawing.Point(1367, 40);
            this.pb_HinhHH.Name = "pb_HinhHH";
            this.pb_HinhHH.Size = new System.Drawing.Size(244, 233);
            this.pb_HinhHH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_HinhHH.TabIndex = 25;
            this.pb_HinhHH.TabStop = false;
            this.pb_HinhHH.Click += new System.EventHandler(this.pb_HinhHH_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Trang Quản Lý Hàng Hóa";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Location = new System.Drawing.Point(1346, 491);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(109, 47);
            this.btn_Thoat.TabIndex = 28;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frm_HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1643, 666);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_HinhHH);
            this.Controls.Add(this.pb_HinhHH);
            this.Controls.Add(this.txt_Tim);
            this.Controls.Add(this.txt_Dem);
            this.Controls.Add(this.btn_Dem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_NhaCungCap);
            this.Controls.Add(this.dateTimePicker_NgayNhap);
            this.Controls.Add(this.dateTimePicker_HanSD);
            this.Controls.Add(this.dateTimePicker_NgaySX);
            this.Controls.Add(this.txt_SoLuong);
            this.Controls.Add(this.txt_GiaBan);
            this.Controls.Add(this.txt_TenHH);
            this.Controls.Add(this.txt_MaHH);
            this.Controls.Add(this.lbl_NgayNhap);
            this.Controls.Add(this.lbl_NhaCC);
            this.Controls.Add(this.lbl_SoLuong);
            this.Controls.Add(this.lbl_GiaBan);
            this.Controls.Add(this.lbl_HanSX);
            this.Controls.Add(this.lbl_NgaySX);
            this.Controls.Add(this.lbl_TenHH);
            this.Controls.Add(this.lbl_MaHH);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_HangHoa";
            this.Text = "HangHoa";
            this.Load += new System.EventHandler(this.frm_HangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_HinhHH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MaHH;
        private System.Windows.Forms.Label lbl_TenHH;
        private System.Windows.Forms.Label lbl_NgaySX;
        private System.Windows.Forms.Label lbl_HanSX;
        private System.Windows.Forms.Label lbl_GiaBan;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.Label lbl_NhaCC;
        private System.Windows.Forms.Label lbl_NgayNhap;
        public System.Windows.Forms.TextBox txt_MaHH;
        public System.Windows.Forms.TextBox txt_TenHH;
        public System.Windows.Forms.TextBox txt_GiaBan;
        public System.Windows.Forms.TextBox txt_SoLuong;
        public System.Windows.Forms.DateTimePicker dateTimePicker_NgaySX;
        public System.Windows.Forms.DateTimePicker dateTimePicker_HanSD;
        public System.Windows.Forms.DateTimePicker dateTimePicker_NgayNhap;
        public System.Windows.Forms.ComboBox cb_NhaCungCap;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_Dem;
        public System.Windows.Forms.TextBox txt_Dem;
        public System.Windows.Forms.TextBox txt_Tim;
        private System.Windows.Forms.PictureBox pb_HinhHH;
        public System.Windows.Forms.TextBox txt_HinhHH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Thoat;
    }
}