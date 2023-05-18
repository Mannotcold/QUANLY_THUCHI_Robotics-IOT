
namespace PMQLTHU_CHI
{
    partial class KhoaHoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.CAPNHAT = new Guna.UI2.WinForms.Guna2Button();
            this.Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvkh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Quay_lai = new Guna.UI2.WinForms.Guna2Button();
            this.txtKhoaHoc = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Animated = true;
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.FillColor = System.Drawing.Color.Blue;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(12, 446);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(131, 33);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseTransparentBackground = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // CAPNHAT
            // 
            this.CAPNHAT.Animated = true;
            this.CAPNHAT.BackColor = System.Drawing.Color.Transparent;
            this.CAPNHAT.BorderRadius = 10;
            this.CAPNHAT.FillColor = System.Drawing.Color.Blue;
            this.CAPNHAT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CAPNHAT.ForeColor = System.Drawing.Color.White;
            this.CAPNHAT.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.CAPNHAT.Location = new System.Drawing.Point(185, 446);
            this.CAPNHAT.Name = "CAPNHAT";
            this.CAPNHAT.Size = new System.Drawing.Size(131, 33);
            this.CAPNHAT.TabIndex = 14;
            this.CAPNHAT.Text = "Cập nhật";
            this.CAPNHAT.UseTransparentBackground = true;
            this.CAPNHAT.Click += new System.EventHandler(this.CAPNHAT_Click);
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
            this.Xoa.Location = new System.Drawing.Point(358, 446);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(131, 33);
            this.Xoa.TabIndex = 15;
            this.Xoa.Text = "Xóa";
            this.Xoa.UseTransparentBackground = true;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "DANH SÁCH KHÓA HỌC";
            // 
            // dgvkh
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvkh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvkh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvkh.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvkh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvkh.Location = new System.Drawing.Point(24, 86);
            this.dgvkh.Name = "dgvkh";
            this.dgvkh.RowHeadersVisible = false;
            this.dgvkh.Size = new System.Drawing.Size(454, 294);
            this.dgvkh.TabIndex = 17;
            this.dgvkh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvkh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvkh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvkh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvkh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvkh.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvkh.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvkh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvkh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvkh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvkh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvkh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkh.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvkh.ThemeStyle.ReadOnly = false;
            this.dgvkh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvkh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvkh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvkh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvkh.ThemeStyle.RowsStyle.Height = 22;
            this.dgvkh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvkh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvkh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkh_CellContentClick);
            // 
            // Quay_lai
            // 
            this.Quay_lai.Animated = true;
            this.Quay_lai.BackColor = System.Drawing.Color.Transparent;
            this.Quay_lai.BorderRadius = 10;
            this.Quay_lai.FillColor = System.Drawing.Color.SlateGray;
            this.Quay_lai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Quay_lai.ForeColor = System.Drawing.Color.White;
            this.Quay_lai.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Quay_lai.Location = new System.Drawing.Point(185, 512);
            this.Quay_lai.Name = "Quay_lai";
            this.Quay_lai.Size = new System.Drawing.Size(131, 33);
            this.Quay_lai.TabIndex = 18;
            this.Quay_lai.Text = "Quay lại";
            this.Quay_lai.UseTransparentBackground = true;
            this.Quay_lai.Click += new System.EventHandler(this.Quay_lai_Click);
            // 
            // txtKhoaHoc
            // 
            this.txtKhoaHoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKhoaHoc.DefaultText = "";
            this.txtKhoaHoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKhoaHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKhoaHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKhoaHoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKhoaHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKhoaHoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKhoaHoc.Location = new System.Drawing.Point(155, 395);
            this.txtKhoaHoc.Name = "txtKhoaHoc";
            this.txtKhoaHoc.PasswordChar = '\0';
            this.txtKhoaHoc.PlaceholderText = "";
            this.txtKhoaHoc.SelectedText = "";
            this.txtKhoaHoc.Size = new System.Drawing.Size(200, 36);
            this.txtKhoaHoc.TabIndex = 19;
            // 
            // KhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 557);
            this.Controls.Add(this.txtKhoaHoc);
            this.Controls.Add(this.Quay_lai);
            this.Controls.Add(this.dgvkh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.CAPNHAT);
            this.Controls.Add(this.btnLuu);
            this.Name = "KhoaHoc";
            this.Text = "KhoaHoc";
            this.Load += new System.EventHandler(this.KhoaHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvkh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button CAPNHAT;
        private Guna.UI2.WinForms.Guna2Button Xoa;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvkh;
        private Guna.UI2.WinForms.Guna2Button Quay_lai;
        private Guna.UI2.WinForms.Guna2TextBox txtKhoaHoc;
    }
}