namespace AssignmentSystem
{
    partial class frmPersonal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.P_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_using = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pcbDelete = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pcbEdit = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pcbAdd = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 361);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_id,
            this.P_name,
            this.P_user,
            this.P_pass,
            this.P_status,
            this.P_using});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 16);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(794, 342);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // P_id
            // 
            this.P_id.DataPropertyName = "P_id";
            this.P_id.HeaderText = "รหัส";
            this.P_id.Name = "P_id";
            this.P_id.ReadOnly = true;
            // 
            // P_name
            // 
            this.P_name.DataPropertyName = "P_name";
            this.P_name.FillWeight = 300F;
            this.P_name.HeaderText = "ชื่อ-นามสกุล";
            this.P_name.Name = "P_name";
            this.P_name.ReadOnly = true;
            this.P_name.Width = 200;
            // 
            // P_user
            // 
            this.P_user.DataPropertyName = "P_user";
            this.P_user.HeaderText = "User";
            this.P_user.Name = "P_user";
            this.P_user.ReadOnly = true;
            // 
            // P_pass
            // 
            this.P_pass.DataPropertyName = "P_pass";
            this.P_pass.HeaderText = "Password";
            this.P_pass.Name = "P_pass";
            this.P_pass.ReadOnly = true;
            // 
            // P_status
            // 
            this.P_status.DataPropertyName = "P_status";
            this.P_status.HeaderText = "Status";
            this.P_status.Name = "P_status";
            this.P_status.ReadOnly = true;
            // 
            // P_using
            // 
            this.P_using.DataPropertyName = "P_using";
            this.P_using.HeaderText = "Using";
            this.P_using.Name = "P_using";
            this.P_using.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pcbDelete);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.pcbEdit);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.pcbAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 89);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ลบ";
            // 
            // pcbDelete
            // 
            this.pcbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbDelete.Image = global::AssignmentSystem.Properties.Resources.Symbol___Delete;
            this.pcbDelete.Location = new System.Drawing.Point(115, 25);
            this.pcbDelete.Name = "pcbDelete";
            this.pcbDelete.Size = new System.Drawing.Size(34, 33);
            this.pcbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDelete.TabIndex = 6;
            this.pcbDelete.TabStop = false;
            this.pcbDelete.Click += new System.EventHandler(this.pcbDelete_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(65, 63);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "แก้ไข";
            // 
            // pcbEdit
            // 
            this.pcbEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbEdit.Image = global::AssignmentSystem.Properties.Resources.Edit;
            this.pcbEdit.Location = new System.Drawing.Point(66, 25);
            this.pcbEdit.Name = "pcbEdit";
            this.pcbEdit.Size = new System.Drawing.Size(34, 33);
            this.pcbEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbEdit.TabIndex = 2;
            this.pcbEdit.TabStop = false;
            this.pcbEdit.Click += new System.EventHandler(this.pcbEdit_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "สร้างใหม่";
            // 
            // pcbAdd
            // 
            this.pcbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbAdd.Image = global::AssignmentSystem.Properties.Resources.Symbol___Add;
            this.pcbAdd.Location = new System.Drawing.Point(15, 25);
            this.pcbAdd.Name = "pcbAdd";
            this.pcbAdd.Size = new System.Drawing.Size(34, 33);
            this.pcbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAdd.TabIndex = 0;
            this.pcbAdd.TabStop = false;
            this.pcbAdd.Click += new System.EventHandler(this.pcbAdd_Click);
            // 
            // frmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPersonal";
            this.Load += new System.EventHandler(this.frmPersonal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pcbDelete;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pcbEdit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pcbAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_using;
    }
}