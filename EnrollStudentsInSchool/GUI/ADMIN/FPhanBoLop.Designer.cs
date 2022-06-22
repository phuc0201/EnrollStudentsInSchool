
namespace EnrollStudentsInSchool_
{
    partial class FPhanBoLop
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbBDiem = new System.Windows.Forms.ComboBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.btnTimSV = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTimLop = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPhanBoLop = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanBoLop)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnLoad);
            this.pnlMain.Controls.Add(this.cbBDiem);
            this.pnlMain.Controls.Add(this.txtMaSV);
            this.pnlMain.Controls.Add(this.txtMaLop);
            this.pnlMain.Controls.Add(this.btnTimSV);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.btnDelete);
            this.pnlMain.Controls.Add(this.btnTimLop);
            this.pnlMain.Controls.Add(this.btnNhapDiem);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.dgvPhanBoLop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1400, 850);
            this.pnlMain.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.BackgroundImage = global::EnrollStudentsInSchool_.Properties.Resources.btnReload;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(1056, 323);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(40, 40);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbBDiem
            // 
            this.cbBDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBDiem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBDiem.FormattingEnabled = true;
            this.cbBDiem.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbBDiem.Location = new System.Drawing.Point(1126, 323);
            this.cbBDiem.Name = "cbBDiem";
            this.cbBDiem.Size = new System.Drawing.Size(121, 38);
            this.cbBDiem.TabIndex = 4;
            this.cbBDiem.Text = "1";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaSV.Location = new System.Drawing.Point(163, 330);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(147, 35);
            this.txtMaSV.TabIndex = 3;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaLop.Location = new System.Drawing.Point(163, 265);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(147, 35);
            this.txtMaLop.TabIndex = 3;
            // 
            // btnTimSV
            // 
            this.btnTimSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimSV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimSV.Location = new System.Drawing.Point(23, 330);
            this.btnTimSV.Name = "btnTimSV";
            this.btnTimSV.Size = new System.Drawing.Size(122, 35);
            this.btnTimSV.TabIndex = 2;
            this.btnTimSV.Text = "Tìm Sinh Viên";
            this.btnTimSV.UseVisualStyleBackColor = true;
            this.btnTimSV.Click += new System.EventHandler(this.btnTimSV_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(338, 265);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 35);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm Sinh Viên";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(338, 330);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa Sinh Viên Khỏi Lớp";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTimLop
            // 
            this.btnTimLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimLop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimLop.Location = new System.Drawing.Point(23, 265);
            this.btnTimLop.Name = "btnTimLop";
            this.btnTimLop.Size = new System.Drawing.Size(122, 35);
            this.btnTimLop.TabIndex = 2;
            this.btnTimLop.Text = "Tìm Lớp";
            this.btnTimLop.UseVisualStyleBackColor = true;
            this.btnTimLop.Click += new System.EventHandler(this.btnTimLop_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapDiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNhapDiem.Location = new System.Drawing.Point(1264, 324);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(122, 35);
            this.btnNhapDiem.TabIndex = 2;
            this.btnNhapDiem.Text = "NHẬP ĐIỂM";
            this.btnNhapDiem.UseVisualStyleBackColor = true;
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(591, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ LỚP";
            // 
            // dgvPhanBoLop
            // 
            this.dgvPhanBoLop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhanBoLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanBoLop.Location = new System.Drawing.Point(0, 382);
            this.dgvPhanBoLop.Name = "dgvPhanBoLop";
            this.dgvPhanBoLop.RowTemplate.Height = 25;
            this.dgvPhanBoLop.Size = new System.Drawing.Size(1400, 468);
            this.dgvPhanBoLop.TabIndex = 0;
            this.dgvPhanBoLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellClick);
            // 
            // FPhanBoLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "FPhanBoLop";
            this.Size = new System.Drawing.Size(1400, 850);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanBoLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.DataGridView dgvPhanBoLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhapDiem;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Button btnTimLop;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnTimSV;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbBDiem;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
    }
}
