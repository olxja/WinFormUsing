﻿using System;
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
    public partial class ChildForm : Form
    {
        #region constructor
        public ChildForm()
        {
            InitializeComponent();
        }
        public ChildForm(ParentForm parent)
        {
            InitializeComponent();
            
            this.MdiParent = parent;
        }
        #endregion
        private void ChildForm_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
