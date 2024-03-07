namespace QLTS.Tool_Khao_Sat
{
    partial class FormDetail
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
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.btnGetStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(29, 27);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(369, 25);
            this.txtStoreName.TabIndex = 0;
            // 
            // btnGetStore
            // 
            this.btnGetStore.BackColor = System.Drawing.Color.Thistle;
            this.btnGetStore.Location = new System.Drawing.Point(404, 25);
            this.btnGetStore.Name = "btnGetStore";
            this.btnGetStore.Size = new System.Drawing.Size(115, 29);
            this.btnGetStore.TabIndex = 1;
            this.btnGetStore.Text = "Lấy store";
            this.btnGetStore.UseVisualStyleBackColor = false;
            this.btnGetStore.Click += new System.EventHandler(this.btnGetStore_Click);
            // 
            // FormDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 114);
            this.Controls.Add(this.btnGetStore);
            this.Controls.Add(this.txtStoreName);
            this.Font = new System.Drawing.Font("Roboto Slab", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính năng khác";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Button btnGetStore;
    }
}