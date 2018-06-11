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
        

        private void tsmOpenChildForm_Click(object sender, EventArgs e)
        {
            CreateNewForm();
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            CloseOpenedForm(childForm);
        }

        #region functions
        static ChildForm childForm;
        private ChildForm CreateNewForm()
        {
            childForm = new ChildForm(this);
            childForm.MdiParent = this;
            //childForm.startposition = formstartposition.centerscreen;
            childForm.Show();
            return childForm;
        }

        private void CloseOpenedForm(Form openedForm)
        {
            try
            {
                openedForm.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
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

        public bool isAlertFormOpen = false;
        AlertInfo output = null;//警告信息提示窗口

        private void AlertForm_input(string info)
        {
            if (isAlertFormOpen == false)
            {
                output = new AlertInfo(this, isAlertFormOpen);
                //output.MdiParent = this;
                //output.Parent = this.DBPanel;//设置子窗体的容器为父窗体的panel；
                output.ShowInfo.Text = info;
                ////output.Dock = DockStyle.Fill;//设置停靠位置，填满父容器；
                ////output.FormBorderStyle = FormBorderStyle.None;//把子窗口的边框去掉
                //int width = (this.Size.Width-300) / 2;//动态居中，alertForm的大小为300，300
                //int heigth = (this.Height-300) / 2;
                //output.Anchor = AnchorStyles.None;
                //output.Location = new Point(width,heigth);
                output.Show();
                isAlertFormOpen = true;
            }
            else
            {
                output.ShowInfo.Text = info;

            }
        }
        private void tsmiConnectDb()//数据库连接按钮
        {  
            try
            {
                oledb.Open();
                if (oledb.State == ConnectionState.Open && isAlertFormOpen == false)
                {
                    AlertForm_input("连接成功");
                    this.tsslShowConn.Text = "已连接";
                }
                else
                    AlertForm_input("连接失败");
            }
            catch (Exception ex)
            {
                AlertForm_input(string.Format("已经连接，无需再次连接"));
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
