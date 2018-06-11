using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsForms
{
    public partial class DBTableInfo : Form
    {
        ParentForm thisParent;//父窗口
        OleDbConnection OleConn; //从父窗口传过来的数据库链接 
        #region constructor
        public DBTableInfo()
        {
            InitializeComponent();
        }
        public DBTableInfo(ParentForm parent,OleDbConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                InitializeComponent();
                this.thisParent = parent;
                this.OleConn = conn;
                leftpanelShowTable(conn);
            }
            else
            {
                AlertInfo alert = new AlertInfo(parent, false);
                alert.ShowInfo.Text = "查询出错,请先连接数据库";
                alert.Show();
            }
        }
        #endregion

        private void leftpanelShowTable(OleDbConnection conn)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[] { null, null, null, "Table" });
                DataGridView view = new DataGridView();
                view.DataSource = dt;
                int n = dt.Rows.Count;//行数
                int m = dt.Columns.IndexOf("TABLE_NAME");
                string[] tables = new string[n];
                for (int i = 0; i < n; i++)
                {
                    DataRow row = dt.Rows[i];
                    tables[i] = Convert.ToString(row.ItemArray.GetValue(m));
                    Label tmp = new Label();
                    tmp.BorderStyle = BorderStyle.Fixed3D;//定义label边框样式
                    tmp.TextAlign = ContentAlignment.MiddleCenter;//字体居中对齐
                    tmp.Text = tables[i];
                    tmp.Location = new Point(0, i * 40);
                    tmp.Size = new Size(this.ShowTableDetail.Panel1.Width, 30);
                    //tmp.Anchor = AnchorStyles.Right;
                    tmp.BackColor = Color.Azure;
                    tmp.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;//设置Anchor属性
                    this.ShowTableDetail.Panel1.Controls.Add(tmp);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
