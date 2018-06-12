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
    public partial class Form2 : Form
    {
        private  OleDbConnection beforeconn;
        private string beforeTable;
        public Form2()
        {
            InitializeComponent();
            

        }
        public Form2(OleDbConnection conn,string tablename)
        {
            InitializeComponent();
            this.beforeconn = conn;
            this.beforeTable = tablename;
        }
        public Form2(OleDbConnection conn, string tablename,bool change)
        {
            InitializeComponent();
            this.beforeconn = conn;
            
            if (change)
            {
                this.insert.Visible = false;
                this.finishbutton.Visible = false;
               
            }
        }

        private void finishbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            int num = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string sql = "";
                if (beforeTable == "学生表")
                    sql = "Insert into Student(id,StudentNo,StudentName,StudentSex,StudentAge) values (";
                else
                    sql = "Insert into Course(Id,CourseNo,CourseName,CoursePoint) values(";


;               
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    sql += string.Format(" '{0}',", dataGridView1.Rows[i].Cells[j].Value);
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql +=")";

                try
                {
                    OleDbCommand cmd = new OleDbCommand(sql, beforeconn);
                    num+=cmd.ExecuteNonQuery();
                    
                }
                catch (Exception cep)
                {
                    MessageBox.Show(string.Format("第{0}行插入出错",i));
                }

            }
            MessageBox.Show(string.Format("成功插入{0}行", num));
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void insert_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string keytable = "";
            string keyval = "";
            if (beforeTable == "学生表")
            {
                keytable = "Student";
                keyval = "StudentNo";
            }
            else
            {
                keytable = "Course";
                keyval = "CourseNo";
            }
            //string sql = string.Format("update {0} set {1} = {2} where {3}={4}", keytable,,, keyval, dataGridView1.Rows[0].Cells[keyval]);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
