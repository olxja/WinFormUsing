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
       
        
        public AlertInfo(ParentForm parent)
        {
            InitializeComponent();
            
            this.MdiParent = parent;
            this.Parent = parent.DBPanel;//设置子窗体的容器为父窗体的panel；
            int width = (parent.DBPanel.Size.Width - 300) / 2;//动态居中，alertForm的大小为300，300
            int heigth = (parent.DBPanel.Height - 300) / 2;
            this.Anchor = AnchorStyles.None;
            this.Location = new Point(width, heigth);
            this.BringToFront();//把警告页面放到最上面展示
            this.Activate();

        }
        #endregion
       
       

        private void Finish_Click(object sender, EventArgs e)
        {
            try
            {
                //关闭的if语句来解决异常不会写，先放着
                this.Close();//两个异常，1.违法操作异常：不能在创建句柄的时候调用此方法，2.对象释放异常:你不能调用这个方法在被激活的事件中，当windowStates设为最大时
            }catch(Exception ex)
            {
                Console.WriteLine(Convert.ToString(ex));
            }
        }

        
    }
}
