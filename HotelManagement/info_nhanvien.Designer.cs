namespace HotelManagement
{
    partial class info_nhanvien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lb_id = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_pos = new System.Windows.Forms.Label();
            this.lb_sex = new System.Windows.Forms.Label();
            this.lb_bdate = new System.Windows.Forms.Label();
            this.lb_phone = new System.Windows.Forms.Label();
            this.lb_address = new System.Windows.Forms.Label();
            this.lb_email = new System.Windows.Forms.Label();
            this.guestTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.quanLyKhachSanDataSet20 = new HotelManagement.QuanLyKhachSanDataSet20();
            this.timekeepingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timekeepingTableAdapter = new HotelManagement.QuanLyKhachSanDataSet20TableAdapters.timekeepingTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkintimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkouttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guestTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timekeepingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_id.Location = new System.Drawing.Point(237, 288);
            this.lb_id.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(275, 55);
            this.lb_id.TabIndex = 118;
            this.lb_id.Text = "Employee ID";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_name.Location = new System.Drawing.Point(237, 371);
            this.lb_name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(136, 55);
            this.lb_name.TabIndex = 119;
            this.lb_name.Text = "Name";
            // 
            // lb_pos
            // 
            this.lb_pos.AutoSize = true;
            this.lb_pos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_pos.Location = new System.Drawing.Point(237, 453);
            this.lb_pos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_pos.Name = "lb_pos";
            this.lb_pos.Size = new System.Drawing.Size(91, 55);
            this.lb_pos.TabIndex = 120;
            this.lb_pos.Text = "pos";
            // 
            // lb_sex
            // 
            this.lb_sex.AutoSize = true;
            this.lb_sex.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_sex.Location = new System.Drawing.Point(1098, 273);
            this.lb_sex.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_sex.Name = "lb_sex";
            this.lb_sex.Size = new System.Drawing.Size(157, 55);
            this.lb_sex.TabIndex = 121;
            this.lb_sex.Text = "gender";
            // 
            // lb_bdate
            // 
            this.lb_bdate.AutoSize = true;
            this.lb_bdate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_bdate.Location = new System.Drawing.Point(1098, 356);
            this.lb_bdate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_bdate.Name = "lb_bdate";
            this.lb_bdate.Size = new System.Drawing.Size(130, 55);
            this.lb_bdate.TabIndex = 122;
            this.lb_bdate.Text = "bdate";
            // 
            // lb_phone
            // 
            this.lb_phone.AutoSize = true;
            this.lb_phone.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_phone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_phone.Location = new System.Drawing.Point(1098, 438);
            this.lb_phone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_phone.Name = "lb_phone";
            this.lb_phone.Size = new System.Drawing.Size(141, 55);
            this.lb_phone.TabIndex = 123;
            this.lb_phone.Text = "phone";
            // 
            // lb_address
            // 
            this.lb_address.AutoSize = true;
            this.lb_address.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_address.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_address.Location = new System.Drawing.Point(237, 549);
            this.lb_address.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_address.Name = "lb_address";
            this.lb_address.Size = new System.Drawing.Size(172, 55);
            this.lb_address.TabIndex = 124;
            this.lb_address.Text = "address";
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_email.Location = new System.Drawing.Point(1086, 534);
            this.lb_email.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(130, 55);
            this.lb_email.TabIndex = 125;
            this.lb_email.Text = "email";
            // 
            // guestTable
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guestTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guestTable.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guestTable.ColumnHeadersHeight = 40;
            this.guestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guestTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.checkintimeDataGridViewTextBoxColumn,
            this.checkouttimeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.salaryDataGridViewTextBoxColumn});
            this.guestTable.DataSource = this.timekeepingBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guestTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.guestTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.Location = new System.Drawing.Point(209, 641);
            this.guestTable.Margin = new System.Windows.Forms.Padding(6);
            this.guestTable.Name = "guestTable";
            this.guestTable.ReadOnly = true;
            this.guestTable.RowHeadersVisible = false;
            this.guestTable.RowHeadersWidth = 82;
            this.guestTable.RowTemplate.Height = 35;
            this.guestTable.Size = new System.Drawing.Size(1581, 716);
            this.guestTable.TabIndex = 146;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guestTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.guestTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guestTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guestTable.ThemeStyle.HeaderStyle.Height = 40;
            this.guestTable.ThemeStyle.ReadOnly = true;
            this.guestTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guestTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guestTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guestTable.ThemeStyle.RowsStyle.Height = 35;
            this.guestTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guestTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // quanLyKhachSanDataSet20
            // 
            this.quanLyKhachSanDataSet20.DataSetName = "QuanLyKhachSanDataSet20";
            this.quanLyKhachSanDataSet20.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timekeepingBindingSource
            // 
            this.timekeepingBindingSource.DataMember = "timekeeping";
            this.timekeepingBindingSource.DataSource = this.quanLyKhachSanDataSet20;
            // 
            // timekeepingTableAdapter
            // 
            this.timekeepingTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkintimeDataGridViewTextBoxColumn
            // 
            this.checkintimeDataGridViewTextBoxColumn.DataPropertyName = "checkintime";
            this.checkintimeDataGridViewTextBoxColumn.HeaderText = "Check In Time";
            this.checkintimeDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.checkintimeDataGridViewTextBoxColumn.Name = "checkintimeDataGridViewTextBoxColumn";
            this.checkintimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkouttimeDataGridViewTextBoxColumn
            // 
            this.checkouttimeDataGridViewTextBoxColumn.DataPropertyName = "checkouttime";
            this.checkouttimeDataGridViewTextBoxColumn.HeaderText = "Check Out Time";
            this.checkouttimeDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.checkouttimeDataGridViewTextBoxColumn.Name = "checkouttimeDataGridViewTextBoxColumn";
            this.checkouttimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            this.salaryDataGridViewTextBoxColumn.DataPropertyName = "salary";
            this.salaryDataGridViewTextBoxColumn.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            this.salaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(703, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 78);
            this.label1.TabIndex = 147;
            this.label1.Text = "Employee Infomation";
            // 
            // info_nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2040, 1430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guestTable);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.lb_address);
            this.Controls.Add(this.lb_phone);
            this.Controls.Add(this.lb_bdate);
            this.Controls.Add(this.lb_sex);
            this.Controls.Add(this.lb_pos);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_id);
            this.Name = "info_nhanvien";
            this.Text = "info_nhanvien";
            this.Load += new System.EventHandler(this.info_nhanvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guestTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timekeepingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_pos;
        private System.Windows.Forms.Label lb_sex;
        private System.Windows.Forms.Label lb_bdate;
        private System.Windows.Forms.Label lb_phone;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.Label lb_email;
        private Guna.UI2.WinForms.Guna2DataGridView guestTable;
        private QuanLyKhachSanDataSet20 quanLyKhachSanDataSet20;
        private System.Windows.Forms.BindingSource timekeepingBindingSource;
        private QuanLyKhachSanDataSet20TableAdapters.timekeepingTableAdapter timekeepingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkintimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkouttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}