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
using System.Data;
namespace WindowsForms
{
    public partial class ParentForm : Form
    {
        
        #region constructor
        public ParentForm()
        {
            InitializeComponent();

           
        }
        #endregion
        
       
        private void tsmiConnectDB_Click(object sender, EventArgs e)
        {
            tsmiConnectDb();//连接数据库
        }
        private void tsmiCloseDB_Click(object sender, EventArgs e)
        {
            closeConn_Click();//关闭数据库
        }
        #region connDB
        private static string conninfo = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrator\Desktop\WebBase.mdb";
        private static OleDbConnection oledb = new OleDbConnection(conninfo);//创建连接实例对象

        //public bool isAlertFormOpen = false;

        AlertInfo output = null; //警报窗口
        public void AlertForm_input(string info)//显示警报信息
        {
            
            if (output==null || output.IsDisposed==true)//如果子窗口为空或者被窗口释放了
            {
                output = new AlertInfo(this);//警告信息提示窗口
                output.ShowInfo.Text = info;//把警告信息传递到AlertInfo中去

                output.Show();//显示警告窗口
            }            
            else
            {
                output.ShowInfo.Text = info;

            }
        }
        private void tsmiConnectDb()//数据库连接按钮
        {
            if (oledb != null && oledb.State == ConnectionState.Closed)//如果已经创建了oleDbconnevtion对象并且连接状态为断开
            {
                oledb.Open();//数据库连接开启
                if ( oledb.State == ConnectionState.Open)//连接已开启
                {
                    AlertForm_input("连接成功");
                    this.tsslShowConn.Text = "已连接";   
                }
                else
                {
                    AlertForm_input("连接失败");
                    this.tsslShowConn.Text = "数据库未连接";
                }
            }
            else
            {
                AlertForm_input("数据库已经连接");

            }



        }

        private void closeConn_Click()//关闭数据库连接按钮
        {
            oledb.Close();
            this.tsslShowConn.Text = "数据库未连接";
            AlertForm_input("数据库连接关闭");
        }


        #endregion


        private void btnSelsectTable_Click(object sender, EventArgs e)//查询数据库按钮
        {
            SelectTable_Click();
        }
        #region showDBTable
        private void SelectTable_Click()
        {
            
            this.DBPanel.Controls.Clear();//清除所有panel中的控件
            DBTableInfo tables = new DBTableInfo(this,oledb);
            tables.MdiParent = this;
            tables.Parent = DBPanel;
            tables.Dock = DockStyle.Fill;
            tables.FormBorderStyle = FormBorderStyle.None;
            tables.Show();

        }

        #endregion

        private void ParentForm_Load(object sender, EventArgs e)
        {
            this.tsslShowTime.Text = "登陆时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        
    }
}
