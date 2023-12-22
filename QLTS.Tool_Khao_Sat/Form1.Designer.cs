namespace QLTS.Tool_Khao_Sat
{
    partial class fForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLoadTeant = new System.Windows.Forms.Button();
            this.btnSaveCookie = new System.Windows.Forms.Button();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelFail = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTenantProcess = new System.Windows.Forms.Label();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.btnEditScript = new System.Windows.Forms.Button();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(4, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 718);
            this.panel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCheck,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(760, 705);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cCheck
            // 
            this.cCheck.Text = "";
            this.cCheck.Width = 23;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 38;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 495;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 170;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.PeachPuff;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStop.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(789, 307);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(254, 36);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLoadTeant
            // 
            this.btnLoadTeant.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnLoadTeant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadTeant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadTeant.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTeant.Location = new System.Drawing.Point(789, 223);
            this.btnLoadTeant.Name = "btnLoadTeant";
            this.btnLoadTeant.Size = new System.Drawing.Size(254, 36);
            this.btnLoadTeant.TabIndex = 3;
            this.btnLoadTeant.Text = "Load các tỉnh";
            this.btnLoadTeant.UseVisualStyleBackColor = false;
            this.btnLoadTeant.Click += new System.EventHandler(this.btnLoadTeant_Click);
            // 
            // btnSaveCookie
            // 
            this.btnSaveCookie.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSaveCookie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveCookie.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveCookie.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCookie.Location = new System.Drawing.Point(789, 112);
            this.btnSaveCookie.Name = "btnSaveCookie";
            this.btnSaveCookie.Size = new System.Drawing.Size(254, 36);
            this.btnSaveCookie.TabIndex = 2;
            this.btnSaveCookie.Text = "Lưu Cookie";
            this.btnSaveCookie.UseVisualStyleBackColor = false;
            this.btnSaveCookie.Click += new System.EventHandler(this.btnSaveCookie_Click);
            // 
            // txtCookie
            // 
            this.txtCookie.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCookie.Font = new System.Drawing.Font("Roboto Slab", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCookie.Location = new System.Drawing.Point(789, 79);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(254, 27);
            this.txtCookie.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(786, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cookie:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBoxAll);
            this.panel4.Controls.Add(this.labelFail);
            this.panel4.Controls.Add(this.labelSuccess);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.labelTenantProcess);
            this.panel4.Location = new System.Drawing.Point(4, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 48);
            this.panel4.TabIndex = 3;
            // 
            // labelFail
            // 
            this.labelFail.AutoSize = true;
            this.labelFail.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFail.Location = new System.Drawing.Point(869, 28);
            this.labelFail.Name = "labelFail";
            this.labelFail.Size = new System.Drawing.Size(31, 18);
            this.labelFail.TabIndex = 10;
            this.labelFail.Text = "Fail";
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.Location = new System.Drawing.Point(868, 2);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(59, 18);
            this.labelSuccess.TabIndex = 9;
            this.labelSuccess.Text = "Success";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng thái";
            // 
            // labelTenantProcess
            // 
            this.labelTenantProcess.AutoSize = true;
            this.labelTenantProcess.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenantProcess.Location = new System.Drawing.Point(778, 17);
            this.labelTenantProcess.Name = "labelTenantProcess";
            this.labelTenantProcess.Size = new System.Drawing.Size(74, 18);
            this.labelTenantProcess.TabIndex = 3;
            this.labelTenantProcess.Text = "Tenant/All";
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.BackColor = System.Drawing.Color.Turquoise;
            this.btnUpgrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpgrade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpgrade.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpgrade.Location = new System.Drawing.Point(789, 265);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(254, 36);
            this.btnUpgrade.TabIndex = 8;
            this.btnUpgrade.Text = "Nâng cấp";
            this.btnUpgrade.UseVisualStyleBackColor = false;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // btnEditScript
            // 
            this.btnEditScript.BackColor = System.Drawing.Color.Pink;
            this.btnEditScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditScript.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEditScript.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditScript.Location = new System.Drawing.Point(789, 154);
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(254, 36);
            this.btnEditScript.TabIndex = 9;
            this.btnEditScript.Text = "Sửa script";
            this.btnEditScript.UseVisualStyleBackColor = false;
            this.btnEditScript.Click += new System.EventHandler(this.btnEditScript_Click);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(19, 27);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(81, 17);
            this.checkBoxAll.TabIndex = 11;
            this.checkBoxAll.Text = "Chọn tất cả";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // fForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 775);
            this.Controls.Add(this.btnEditScript);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.btnSaveCookie);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLoadTeant);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool nâng cấp dữ liệu";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cCheck;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSaveCookie;
        private System.Windows.Forms.Button btnLoadTeant;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTenantProcess;
        private System.Windows.Forms.Label labelFail;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Button btnEditScript;
        private System.Windows.Forms.CheckBox checkBoxAll;
    }
}

