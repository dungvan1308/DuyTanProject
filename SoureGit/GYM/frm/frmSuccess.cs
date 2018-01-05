using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GYM.frm
{
    public partial class frmSuccess : DevExpress.XtraEditors.XtraForm
    {
        public frmSuccess()
        {
            InitializeComponent();
        }

        private void bbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSuccess_Load(object sender, EventArgs e)
        {

        }
    }
}