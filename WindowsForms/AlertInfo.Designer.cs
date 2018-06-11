namespace WindowsForms
{
    partial class AlertInfo
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
            this.Finish = new System.Windows.Forms.Button();
            this.ShowInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Finish
            // 
            this.Finish.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Finish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Finish.Location = new System.Drawing.Point(98, 163);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(75, 23);
            this.Finish.TabIndex = 1;
            this.Finish.Text = "确定";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // ShowInfo
            // 
            this.ShowInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShowInfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowInfo.Location = new System.Drawing.Point(23, 62);
            this.ShowInfo.MaximumSize = new System.Drawing.Size(268, 80);
            this.ShowInfo.Name = "ShowInfo";
            this.ShowInfo.Size = new System.Drawing.Size(235, 80);
            this.ShowInfo.TabIndex = 2;
            this.ShowInfo.Text = "label1";
            this.ShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlertInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ShowInfo);
            this.Controls.Add(this.Finish);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.Name = "AlertInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Finish;
        public System.Windows.Forms.Label ShowInfo;
    }
}