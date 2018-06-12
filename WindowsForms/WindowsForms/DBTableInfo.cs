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
                this.OleConn = conn;
                leftpanelShowTable(conn);
            }
            else
            {
                AlertInfo alert = new AlertInfo(parent);
                alert.ShowInfo.Text = "查询出错,请先连接数据库";
                alert.Show();
            }
        }
        #endregion

        [DefaultValue("Hello world")]
        public string Str = "Hello world";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden )]
        public string Str2 = "Hello world";

        #region selectDB
        private void leftpanelShowTable(OleDbConnection conn)
        {
            DataTable dt = new DataTable();
            if (conn != null && conn.State == ConnectionState.Open)
            { //还有个ArgumentException,但是直接写入了参数应该不会出现异常
                dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });//重点注意
            }
            DataGridView view = new DataGridView();//存放查询出的表的DataGridView
            view.DataSource = dt; //设置view的数据源
            int n = dt.Rows.Count;//行数
            int m = dt.Columns.IndexOf("TABLE_NAME");//每一行的table名称
            string[] tables = new string[n]; //存放table表的数组
            for (int i = 0; i < n; i++)
            {
                DataRow row = dt.Rows[i];
                tables[i] = Convert.ToString(row.ItemArray.GetValue(m));
                Label tmp = new Label();
                tmp.BorderStyle = BorderStyle.Fixed3D;//定义label边框样式
                tmp.TextAlign = ContentAlignment.MiddleCenter;//字体居中对齐
                tmp.Text = tables[i];
                tmp.Location = new Point(0, i * 30);//动态设定label的位置为距容器左上角横坐标为0，纵坐标为i*30。因为每个label高度为30
                tmp.Size = new Size(this.ShowTableDetail.Panel1.Width, 30);//填充满左pancel
                tmp.BackColor = Color.Azure;//设置背景色，方便区分
                tmp.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;//设置Anchor属性
                tmp.ContextMenuStrip = getDBTablesContextMenu(tables[i]); //绑定右键菜单
                this.ShowTableDetail.Panel1.Controls.Add(tmp);//添加控件
                tmp.Click += new EventHandler(tmp_click);//绑定点击事件
            }
        }

        private ContextMenuStrip getDBTablesContextMenu(string tablename)
        {
            ContextMenuStrip tmpCMS = new ContextMenuStrip();
            tmpCMS.Name = tablename; //把右键菜单的name属性设为表的名字，供动态生成函数调用

            //插入按钮
            ToolStripMenuItem insert = new ToolStripMenuItem("在表中插入数据");
            insert.Name = "Insert";
            insert.Click += new EventHandler(InsertData);
            tmpCMS.Items.Add(insert);
             
            
            tmpCMS.Items.Add("删除选中数据").Name="delect";
            tmpCMS.Items.Add("更改选定行中数据").Name = "update";
            //绑定完增删改3个右键功能,下面绑定事件

           
            return tmpCMS;
        }

        private void InsertData(object sender, EventArgs e)//右键插入功能
        {

            ToolStripMenuItem tmptable = (ToolStripMenuItem)sender;
            string tablename = tmptable.Owner.Name; //获取表的名字
            if (this.dbtableview != null)
            {
                this.dbtableview.ReadOnly = false;
            }
            else
            {
                //parentForm.AlertForm_input("无法插入，请先选择您想要插入的表");//显示不出来

               
                AlertForm_input("无法插入，请先选择您想要插入的表");


            }
           
        }
        AlertInfo output = null; //警报窗口
        public void AlertForm_input(string info)//显示警报信息
        {

            if (output == null || output.IsDisposed == true)//如果子窗口为空或者被窗口释放了
            {
                output = new AlertInfo((ParentForm)this.Parent.Parent);//警告信息提示窗口
                output.ShowInfo.Text = info;//把警告信息传递到AlertInfo中去

                output.Show();//显示警告窗口
            }
            else
            {
                output.ShowInfo.Text = info;

            }
        }

        private void tmp_click(object sender, EventArgs e)
        {
            Label tmptable = (Label)sender;//获取控件信息

            string tablename = tmptable.Text;//获取表名

            selectTables(tablename);
           
        }
        DataGridView dbtableview = null;//供pancel2使用的数据库表图形化容器
        private void selectTables(string tablename)
        {
            string sql = string.Format("select * from {0}", tablename);
            OleDbDataAdapter dataapt = new OleDbDataAdapter(sql, OleConn);
            DataTable dt = new DataTable();
            dataapt.Fill(dt); //把查询结果放进dt中
            dbtableview = new DataGridView();
            dbtableview.ReadOnly = true;
            dbtableview.DataSource = dt;
            this.ShowTableDetail.Panel2.Controls.Clear();//先清除所有pancel2上的控件
            this.ShowTableDetail.Panel2.Controls.Add(dbtableview);//重新添加到pancel2上
            dbtableview.Dock = DockStyle.Fill;
            dbtableview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//平铺填满在pancel2上
        }


        #endregion
    }
}
