namespace DVLD_PROJECT.Users
{
    partial class frmListUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterOptions = new System.Windows.Forms.ComboBox();
            this.lbFilterText = new System.Windows.Forms.TextBox();
            this.cbIsActiveFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(475, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 411);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1093, 354);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.VirtualMode = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = global::DVLD_PROJECT.Properties.Resources.Add_New_User_72;
            this.btnAddUser.Location = new System.Drawing.Point(1009, 305);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(108, 83);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_PROJECT.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(464, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(977, 774);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterOptions
            // 
            this.cbFilterOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterOptions.FormattingEnabled = true;
            this.cbFilterOptions.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "FullName",
            "UserName",
            "isActive"});
            this.cbFilterOptions.Location = new System.Drawing.Point(118, 364);
            this.cbFilterOptions.Name = "cbFilterOptions";
            this.cbFilterOptions.Size = new System.Drawing.Size(220, 28);
            this.cbFilterOptions.TabIndex = 10;
            this.cbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cbFilterOptions_SelectedIndexChanged);
            // 
            // lbFilterText
            // 
            this.lbFilterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilterText.Location = new System.Drawing.Point(344, 366);
            this.lbFilterText.Name = "lbFilterText";
            this.lbFilterText.Size = new System.Drawing.Size(185, 26);
            this.lbFilterText.TabIndex = 11;
            this.lbFilterText.TextChanged += new System.EventHandler(this.lbFilterText_TextChanged);
            // 
            // cbIsActiveFilter
            // 
            this.cbIsActiveFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActiveFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActiveFilter.FormattingEnabled = true;
            this.cbIsActiveFilter.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActiveFilter.Location = new System.Drawing.Point(344, 364);
            this.cbIsActiveFilter.Name = "cbIsActiveFilter";
            this.cbIsActiveFilter.Size = new System.Drawing.Size(121, 28);
            this.cbIsActiveFilter.TabIndex = 12;
            this.cbIsActiveFilter.Visible = false;
            this.cbIsActiveFilter.SelectedIndexChanged += new System.EventHandler(this.cbIsActiveFilter_SelectedIndexChanged);
            // 
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 826);
            this.Controls.Add(this.cbIsActiveFilter);
            this.Controls.Add(this.lbFilterText);
            this.Controls.Add(this.cbFilterOptions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterOptions;
        private System.Windows.Forms.TextBox lbFilterText;
        private System.Windows.Forms.ComboBox cbIsActiveFilter;
    }
}