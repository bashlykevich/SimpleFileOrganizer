using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleFileOrganizer
{
    public partial class FilterEdit : Form
    {
        public Filter filter = null;
        public FilterEdit()
        {
            InitializeComponent();

            Filter f = new Filter();
            edtExt.Text = f.Extensions;
            //edtDirectory.Text = f.TargetDir;
            edtFilename.Text = f.FileNameMask;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filter = new Filter();
            filter.Extensions = edtExt.Text;
            filter.FileNameMask = edtFilename.Text;
            filter.TargetDir = edtDirectory.Text;
            if (rbCopy.Checked)
                filter.Action = RuleAction.Copy;
            else
                filter.Action = RuleAction.Move;
            Close();
        }

        private void FilterEdit_Load(object sender, EventArgs e)
        {

        }

        private void edtExt_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("List extensions to filter using semicolon, for example: ico;png;jpg", edtExt);
        }

        private void edtExt_TextChanged(object sender, EventArgs e)
        {
            if(edtDirectory.Text == "" 
                   || edtExt.Text.StartsWith(edtDirectory.Text))
                edtDirectory.Text = edtExt.Text;
        }
    }
}
