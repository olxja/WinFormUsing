namespace WindowsForms
{
    partial class ParentForm
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
            this.DBoperation = new System.Windows.Forms.MenuStrip();
            this.tsmiOperatorDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseDB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelsectTable = new System.Windows.Forms.ToolStripMenuItem();
            this.DBPanel = new System.Windows.Forms.Panel();
            this.ConnState = new System.Windows.Forms.StatusStrip();
            this.tsslShowConn = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEmpty = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslShowTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.DBoperation.SuspendLayout();
            this.ConnState.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBoperation
            // 
            this.DBoperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOperatorDB,
            this.btnSelsectTable});
            this.DBoperation.Location = new System.Drawing.Point(0, 0);
            this.DBoperation.Name = "DBoperation";
            this.DBoperation.Size = new System.Drawing.Size(719, 25);
            this.DBoperation.TabIndex = 2;
            this.DBoperation.Text = "menuStrip1";
            // 
            // tsmiOperatorDB
            // 
            this.tsmiOperatorDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnectDB,
            this.tsmiCloseDB});
            this.tsmiOperatorDB.Name = "tsmiOperatorDB";
            this.tsmiOperatorDB.Size = new System.Drawing.Size(80, 21);
            this.tsmiOperatorDB.Text = "数据库操作";
            // 
            // tsmiConnectDB
            // 
            this.tsmiConnectDB.Name = "tsmiConnectDB";
            this.tsmiConnectDB.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiConnectDB.Size = new System.Drawing.Size(183, 22);
            this.tsmiConnectDB.Text = "连接数据库";
            this.tsmiConnectDB.Click += new System.EventHandler(this.tsmiConnectDB_Click);
            // 
            // tsmiCloseDB
            // 
            this.tsmiCloseDB.Name = "tsmiCloseDB";
            this.tsmiCloseDB.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCloseDB.Size = new System.Drawing.Size(183, 22);
            this.tsmiCloseDB.Text = "关闭数据库";
            this.tsmiCloseDB.Click += new System.EventHandler(this.tsmiCloseDB_Click);
            // 
            // btnSelsectTable
            // 
            this.btnSelsectTable.Name = "btnSelsectTable";
            this.btnSelsectTable.Size = new System.Drawing.Size(80, 21);
            this.btnSelsectTable.Text = "查询数据库";
            this.btnSelsectTable.Click += new System.EventHandler(this.btnSelsectTable_Click);
            // 
            // DBPanel
            // 
            this.DBPanel.AutoScroll = true;
            this.DBPanel.AutoSize = true;
            this.DBPanel.BackColor = System.Drawing.Color.Black;
            this.DBPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DBPanel.Location = new System.Drawing.Point(0, 25);
            this.DBPanel.Name = "DBPanel";
            this.DBPanel.Size = new System.Drawing.Size(719, 412);
            this.DBPanel.TabIndex = 6;
            // 
            // ConnState
            // 
            this.ConnState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslShowConn,
            this.tsslEmpty,
            this.tsslShowTime});
            this.ConnState.Location = new System.Drawing.Point(0, 415);
            this.ConnState.Name = "ConnState";
            this.ConnState.Size = new System.Drawing.Size(719, 22);
            this.ConnState.TabIndex = 0;
            this.ConnState.Text = "statusStrip1";
            // 
            // tsslShowConn
            // 
            this.tsslShowConn.BackColor = System.Drawing.Color.Transparent;
            this.tsslShowConn.Name = "tsslShowConn";
            this.tsslShowConn.Size = new System.Drawing.Size(80, 17);
            this.tsslShowConn.Text = "数据库未连接";
            // 
            // tsslEmpty
            // 
            this.tsslEmpty.BackColor = System.Drawing.Color.Transparent;
            this.tsslEmpty.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslEmpty.Name = "tsslEmpty";
            this.tsslEmpty.Size = new System.Drawing.Size(493, 17);
            this.tsslEmpty.Spring = true;
            // 
            // tsslShowTime
            // 
            this.tsslShowTime.BackColor = System.Drawing.Color.Transparent;
            this.tsslShowTime.Name = "tsslShowTime";
            this.tsslShowTime.Size = new System.Drawing.Size(131, 17);
            this.tsslShowTime.Text = "toolStripStatusLabel2";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(719, 437);
            this.Controls.Add(this.ConnState);
            this.Controls.Add(this.DBPanel);
            this.Controls.Add(this.DBoperation);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.DBoperation;
            this.Name = "ParentForm";
            this.Text = "父窗口";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.DBoperation.ResumeLayout(false);
            this.DBoperation.PerformLayout();
            this.ConnState.ResumeLayout(false);
            this.ConnState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip DBoperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiOperatorDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnectDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseDB;
        private System.Windows.Forms.ToolStripMenuItem btnSelsectTable;
        private System.Windows.Forms.StatusStrip ConnState;
        private System.Windows.Forms.ToolStripStatusLabel tsslEmpty;
        private System.Windows.Forms.ToolStripStatusLabel tsslShowTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslShowConn;
        public System.Windows.Forms.Panel DBPanel;
    }
}