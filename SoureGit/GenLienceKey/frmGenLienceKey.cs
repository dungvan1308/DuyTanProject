using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClassLibraryCommon;


namespace GenLienceKey
{
    public partial class frmGenLienceKey : DevExpress.XtraEditors.XtraForm
    {
        public frmGenLienceKey()
        {
            InitializeComponent();
        }

        private void memoExEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmGenLienceKey_Load(object sender, EventArgs e)
        {
            txtInput.Text  = CommonObject.getCpuId_Serial();
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttDeCrypt_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   03/06/2016
             * Purpose  :   Giai nen
             */
            string strInput = "";
            strInput = txtInput.Text.Trim();
        }
        

        private void bttEnscrypt_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = CommonObject.EncryptData(txtInput.Text);
        }
    }
}