
namespace PMQLTHU_CHI
{
    partial class MENU
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
            this.dgvPhieuTC = new System.Windows.Forms.DataGridView();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Print = new Guna.UI2.WinForms.Guna2Button();
            this.mahoadon = new System.Windows.Forms.TextBox();
            this.Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTC)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhieuTC
            // 
            this.dgvPhieuTC.AllowUserToAddRows = false;
            this.dgvPhieuTC.AllowUserToDeleteRows = false;
            this.dgvPhieuTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuTC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuTC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuTC.Location = new System.Drawing.Point(35, 68);
            this.dgvPhieuTC.MultiSelect = false;
            this.dgvPhieuTC.Name = "dgvPhieuTC";
            this.dgvPhieuTC.ReadOnly = true;
            this.dgvPhieuTC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuTC.Size = new System.Drawing.Size(769, 502);
            this.dgvPhieuTC.TabIndex = 11;
            this.dgvPhieuTC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuTC_CellContentClick);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraCuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuu.Location = new System.Drawing.Point(729, 27);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(75, 23);
            this.btnTraCuu.TabIndex = 10;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuKhoa.Location = new System.Drawing.Point(477, 29);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(223, 20);
            this.txtTuKhoa.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm kiếm";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMớiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMớiToolStripMenuItem1,
            this.đăngXuấtToolStripMenuItem,
            this.exportExcelToolStripMenuItem});
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.thêmMớiToolStripMenuItem.Text = "Menu";
            // 
            // thêmMớiToolStripMenuItem1
            // 
            this.thêmMớiToolStripMenuItem1.Name = "thêmMớiToolStripMenuItem1";
            this.thêmMớiToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.thêmMớiToolStripMenuItem1.Text = "Thêm mới";
            this.thêmMớiToolStripMenuItem1.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem1_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exportExcelToolStripMenuItem.Text = "Export excel";
            this.exportExcelToolStripMenuItem.Click += new System.EventHandler(this.exportExcelToolStripMenuItem_Click);
            // 
            // Print
            // 
            this.Print.Animated = true;
            this.Print.BackColor = System.Drawing.Color.Transparent;
            this.Print.BorderRadius = 10;
            this.Print.FillColor = System.Drawing.Color.CornflowerBlue;
            this.Print.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Print.ForeColor = System.Drawing.Color.White;
            this.Print.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Print.Location = new System.Drawing.Point(35, 587);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(131, 33);
            this.Print.TabIndex = 22;
            this.Print.Text = "Print";
            this.Print.UseTransparentBackground = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // mahoadon
            // 
            this.mahoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mahoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mahoadon.Location = new System.Drawing.Point(373, 595);
            this.mahoadon.Name = "mahoadon";
            this.mahoadon.Size = new System.Drawing.Size(104, 20);
            this.mahoadon.TabIndex = 23;
            // 
            // Xoa
            // 
            this.Xoa.Animated = true;
            this.Xoa.BackColor = System.Drawing.Color.Transparent;
            this.Xoa.BorderRadius = 10;
            this.Xoa.FillColor = System.Drawing.Color.Blue;
            this.Xoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Xoa.ForeColor = System.Drawing.Color.White;
            this.Xoa.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Xoa.Location = new System.Drawing.Point(673, 587);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(131, 33);
            this.Xoa.TabIndex = 24;
            this.Xoa.Text = "Xóa";
            this.Xoa.UseTransparentBackground = true;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 579);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mã hóa đơn";
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 632);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.mahoadon);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvPhieuTC);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MENU";
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.MENU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTC)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhieuTC;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportExcelToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button Print;
        private System.Windows.Forms.TextBox mahoadon;
        private Guna.UI2.WinForms.Guna2Button Xoa;
        private System.Windows.Forms.Label label2;
    }
}