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
    public partial class frmFail : DevExpress.XtraEditors.XtraForm
    {
        public frmFail()
        {
            InitializeComponent();
        }

        private void frmFail_Load(object sender, EventArgs e)
        {

        }

        private void bbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}