namespace LessonSchedulesApp.DAL.Schedules
{
    partial class frmSchedules
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblSubjectId = new System.Windows.Forms.Label();
            this.lblDayId = new System.Windows.Forms.Label();
            this.lbGroupId = new System.Windows.Forms.Label();
            this.dgwSchedules = new System.Windows.Forms.DataGridView();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txtOrder);
            this.pnlLeft.Controls.Add(this.lblOrder);
            this.pnlLeft.Controls.Add(this.cmbUser);
            this.pnlLeft.Controls.Add(this.cmbSubject);
            this.pnlLeft.Controls.Add(this.cmbDay);
            this.pnlLeft.Controls.Add(this.cmbGroup);
            this.pnlLeft.Controls.Add(this.btnDelete);
            this.pnlLeft.Controls.Add(this.btnUpdate);
            this.pnlLeft.Controls.Add(this.btnView);
            this.pnlLeft.Controls.Add(this.btnSave);
            this.pnlLeft.Controls.Add(this.lblUserId);
            this.pnlLeft.Controls.Add(this.lblSubjectId);
            this.pnlLeft.Controls.Add(this.lblDayId);
            this.pnlLeft.Controls.Add(this.lbGroupId);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(368, 450);
            this.pnlLeft.TabIndex = 0;
            // 
            // cmbUser
            // 
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(117, 190);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(160, 21);
            this.cmbUser.TabIndex = 15;
            this.cmbUser.ValueMember = "Id";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DisplayMember = "Name";
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(117, 139);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(160, 21);
            this.cmbSubject.TabIndex = 14;
            this.cmbSubject.ValueMember = "Id";
            // 
            // cmbDay
            // 
            this.cmbDay.DisplayMember = "Name";
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(117, 95);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(160, 21);
            this.cmbDay.TabIndex = 13;
            this.cmbDay.ValueMember = "Id";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(117, 51);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(160, 21);
            this.cmbGroup.TabIndex = 12;
            this.cmbGroup.ValueMember = "Id";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(259, 340);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(179, 340);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(99, 340);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(13, 193);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(52, 13);
            this.lblUserId.TabIndex = 6;
            this.lblUserId.Text = "Istifadəçi ";
            // 
            // lblSubjectId
            // 
            this.lblSubjectId.AutoSize = true;
            this.lblSubjectId.Location = new System.Drawing.Point(13, 142);
            this.lblSubjectId.Name = "lblSubjectId";
            this.lblSubjectId.Size = new System.Drawing.Size(31, 13);
            this.lblSubjectId.TabIndex = 4;
            this.lblSubjectId.Text = "Fənn";
            // 
            // lblDayId
            // 
            this.lblDayId.AutoSize = true;
            this.lblDayId.Location = new System.Drawing.Point(12, 98);
            this.lblDayId.Name = "lblDayId";
            this.lblDayId.Size = new System.Drawing.Size(27, 13);
            this.lblDayId.TabIndex = 2;
            this.lblDayId.Text = "Gün";
            // 
            // lbGroupId
            // 
            this.lbGroupId.AutoSize = true;
            this.lbGroupId.Location = new System.Drawing.Point(13, 51);
            this.lbGroupId.Name = "lbGroupId";
            this.lbGroupId.Size = new System.Drawing.Size(36, 13);
            this.lbGroupId.TabIndex = 0;
            this.lbGroupId.Text = "Qurup";
            // 
            // dgwSchedules
            // 
            this.dgwSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwSchedules.Location = new System.Drawing.Point(368, 0);
            this.dgwSchedules.Name = "dgwSchedules";
            this.dgwSchedules.Size = new System.Drawing.Size(432, 450);
            this.dgwSchedules.TabIndex = 1;
            this.dgwSchedules.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwSchedules_RowHeaderMouseClick);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(14, 258);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(25, 13);
            this.lblOrder.TabIndex = 16;
            this.lblOrder.Text = "Sıra";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(117, 251);
            this.txtOrder.Multiline = true;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(41, 20);
            this.txtOrder.TabIndex = 17;
            // 
            // frmSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgwSchedules);
            this.Controls.Add(this.pnlLeft);
            this.Name = "frmSchedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedules";
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSchedules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lbGroupId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblSubjectId;
        private System.Windows.Forms.Label lblDayId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgwSchedules;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtOrder;
    }
}