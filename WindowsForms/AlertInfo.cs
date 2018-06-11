using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AlertInfo : Form
    {
        
        #region constructor
        public AlertInfo()
        {
            InitializeComponent();
        }
       
        ParentForm thisParent;//其父类实例
        public AlertInfo(ParentForm parent, bool isAlertOpen)
        {
            InitializeComponent();
            thisParent = parent;
            this.MdiParent = parent;
            this.Parent = parent.DBPanel;//设置子窗体的容器为父窗体的panel；
            int width = (parent.Size.Width - 300) / 2;//动态居中，alertForm的大小为300，300
            int heigth = (parent.Height - 300) / 2;
            this.Anchor = AnchorStyles.None;
            this.Location = new Point(width, heigth);
        }
        #endregion
       
       

        private void Finish_Click(object sender, EventArgs e)
        {
            try
            {
                thisParent.isAlertFormOpen = false;
                this.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
            }
        }

        
    }
}
