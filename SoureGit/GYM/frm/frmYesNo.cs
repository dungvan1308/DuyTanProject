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
    public partial class frmYesNo : DevExpress.XtraEditors.XtraForm
    {
        public bool isYes = false;
        public frmYesNo()
        {
            InitializeComponent();
        }

        private void frmYesNo_Load(object sender, EventArgs e)
        {
           
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            /*
            * Dungnv : 11/11/2015
            */
            // Dong y 
            this.isYes = true;
            this.Close();
        }

        private void bbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}