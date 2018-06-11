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
    public partial class Form1 : Form
    {
        private static string conninfo = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrator\Desktop\WebBase.mdb";
        private static OleDbConnection oledb = new OleDbConnection(conninfo);//创建连接实例对象
        #region Connstuctor 
        public Form1()
        {
            InitializeComponent();
            
            
        }
        #endregion

        private void ConDb_Click(object sender, EventArgs e)
        {
            this.TableSelect.SelectedIndex = 1;
            try
            {
                oledb.Open();
                MessageBox.Show("链接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现异常，无法连接");
            }
        }

        private void closeConn_Click(object sender, EventArgs e)
        {
            oledb.Close();
            MessageBox.Show("数据库连接关闭");
        }

        private void selectTable_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                    switch (TableSelect.SelectedItem.ToString())
                {
                    case "学生表":
                        sql = "select * from Student";
                        break;
                    case "课程表":
                        sql = "Select * from Course";
                        break;
                    default:
                        MessageBox.Show("出现错误，无法获取用户需要的表");
                        break;
                }

                OleDbDataAdapter apt = new OleDbDataAdapter(sql, conninfo);
                DataTable table = new DataTable();
                apt.Fill(table);
                bindingSource1.DataSource = table;
                //dataGridView1.DataSource = table;
            }
            catch(Exception ecp)
            {
                MessageBox.Show("请先连接数据库");
            }

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 newForm = new Form2(oledb, TableSelect.SelectedItem.ToString());
                string sql = " ";

                switch (TableSelect.SelectedItem.ToString())
                {
                    case "学生表":
                        sql = "Select * from Student where StudentSex='1'";//使用两个不可能出结果的语句会直接返回表头
                        break;
                    case "课程表":
                        sql = "Select * from Course where CoursePoint>100";//
                        break;
                    default:
                        MessageBox.Show("出现错误，无法获取用户需要的表");
                        break;
                }
                OleDbDataAdapter apt = new OleDbDataAdapter(sql, oledb);
                DataTable table = new DataTable();
                apt.Fill(table);
                newForm.Show();
                newForm.dataGridView1.DataSource = table;
                selectTable_Click(sender, e);
            }
            catch(Exception cep)
            {
                MessageBox.Show("请先连接数据库");
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            string sql = "";
            string key = "";
            try
            {
                if (TableSelect.SelectedItem.ToString() == "学生表")
                {
                    sql = "Delete from Student where StudentNo=";
                    key = "StudentNo";
                }
                else
                {
                    sql = "Delete from Course where CourseNo=";
                    key = "CourseNo";
                }
                
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    string result = Convert.ToString(dataGridView1.SelectedRows[i].Cells[key].Value);
                    sql += result;
                   

                }
                //object key=dataGridView1.SelectedRows[0].Cells["CourseNo"].Value;
                OleDbCommand cmd = new OleDbCommand(sql, oledb);
                int num = cmd.ExecuteNonQuery();
                MessageBox.Show(string.Format("{0}行被删除",num));
                selectTable_Click(sender, e);

            }
            catch(Exception cep)
            {
                MessageBox.Show("请确认先连接数据库，然后选中表中行才能进行删除");
            }
        }

        private void changebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (oledb.State == ConnectionState.Closed || dataGridView1.SelectedRows.Count==0)
                {
                    MessageBox.Show("连接未开启或者未在选中要更改的单行");
                }
                else
                {
                    Form2 newform = new Form2(oledb, TableSelect.SelectedItem.ToString(),true);
                    DataTable dt = new DataTable();
                    int num = dataGridView1.SelectedRows.Count;//被选中的行数
                    for (int i = 0; i < num; i++)
                    {
                        DataGridViewRow gridrow = dataGridView1.SelectedRows[i];
                        DataRowView newrow = (DataRowView)gridrow.DataBoundItem;
                        dt = newrow.DataView.Table.Clone();
                        dt.ImportRow(newrow.Row);
                        //dt.Rows.Add(newrow.Row);
                    }
                    newform.dataGridView1.DataSource = dt;
                    newform.Show();
                }
            }catch(Exception cep)
            {
                MessageBox.Show("首先请确保数据库处于连接状态，然后更改只允许单行操作");
            }
        }

       

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //object test = dataGridView1.DataSource;
            //DataTable table = (DataTable)test;
            //object[] a = table.Rows[1].ItemArray;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    MessageBox.Show(Convert.ToString(a[i]));
            //}

            //MessageBox.Show(Convert.ToString(dataGridView1.CurrentCell.Value));

            string keytable = "";
            string keyval = "";
            if (TableSelect.SelectedItem.ToString() == "学生表")
            {
                keytable = "Student";
                keyval = "StudentNo";
            }
            else
            {
                keytable = "Course";
                keyval = "CourseNo";
            }
            int keycol = dataGridView1.CurrentCell.ColumnIndex;
            int keyrow = dataGridView1.CurrentCell.RowIndex;
            string sql = string.Format("update {0} set {1} = {2} where {3}={4}", keytable,Convert.ToString(dataGridView1.Columns[keycol].HeaderText),dataGridView1.CurrentCell.Value,keyval, dataGridView1.Rows[keyrow].Cells[keyval].Value);
            OleDbCommand cmd = new OleDbCommand(sql,oledb);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show(string.Format("{0}\n成功更新{1}行",sql,i));
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                //
                if (dlg.ShowDialog() != DialogResult.OK) return;


                //
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                }

            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
