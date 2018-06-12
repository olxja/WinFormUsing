namespace WindowsForms
{
    partial class DBTableInfo
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
            this.ShowTableDetail = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ShowTableDetail)).BeginInit();
            this.ShowTableDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowTableDetail
            // 
            this.ShowTableDetail.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ShowTableDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShowTableDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowTableDetail.Location = new System.Drawing.Point(0, 0);
            this.ShowTableDetail.Name = "ShowTableDetail";
            // 
            // ShowTableDetail.Panel1
            // 
            this.ShowTableDetail.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ShowTableDetail.Size = new System.Drawing.Size(671, 455);
            this.ShowTableDetail.SplitterDistance = 191;
            this.ShowTableDetail.TabIndex = 0;
            // 
            // DBTableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 455);
            this.Controls.Add(this.ShowTableDetail);
            this.Name = "DBTableInfo";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.ShowTableDetail)).EndInit();
            this.ShowTableDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ShowTableDetail;
    }
}