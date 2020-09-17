namespace WindowsFormsApp3
{
    partial class frmFact
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
            this.dgGiuongBenh = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgGiuongBenh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgGiuongBenh
            // 
            this.dgGiuongBenh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGiuongBenh.Location = new System.Drawing.Point(24, 70);
            this.dgGiuongBenh.Name = "dgGiuongBenh";
            this.dgGiuongBenh.RowTemplate.Height = 28;
            this.dgGiuongBenh.Size = new System.Drawing.Size(923, 572);
            this.dgGiuongBenh.TabIndex = 1;
            // 
            // fromFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 790);
            this.Controls.Add(this.dgGiuongBenh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fromFact";
            this.Text = "frmQLGiuongBenh";
            this.Load += new System.EventHandler(this.frmQLGiuongBenh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGiuongBenh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgGiuongBenh;
    }
}