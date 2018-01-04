using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.ServiceReferenceDuyTan;
using System.Collections;
using GYM.Common;

using System.Threading;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


namespace GYM.frm
{
    public partial class frmBackupAndRestore : DevExpress.XtraEditors.XtraForm
    {
        public frmBackupAndRestore()
        {
            InitializeComponent();
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackupAndRestore_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   load list of file in backup folder
             */
            InitGridControl();
            loadlistFile();
           
        }

        private void gridControlFile_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   Select File
             */
 

        }

        private void loadlistFile()
        {
            /*
            * Dungnv  : 11/06/2016
            * Purpose : load list file in folder
            */


            DataTable dt = gridControlFile.DataSource as DataTable;
            DataRow dr;
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            ArrayList arr = new ArrayList();
            arr = new ArrayList(ws.getListFileInfo());

            if(arr!=null)
            {
                int iCount = 0;
                iCount = arr.Count;
                try
                {
                    for (int i = 0; i < iCount; i++)
                    {
                        dr = dt.NewRow();
                        dr.BeginEdit();

                        FileObject obj = new FileObject();
                        obj = (FileObject)arr[i];
                        dr["FILENAME"] = obj.strFileName;
                        dr["CREATEDATE"] = obj.dtCreated;
                        dr["FILESIZE"] = obj.dbSize;

                        dr.EndEdit();
                        dt.Rows.Add(dr);

                    }

                    gridControlFile.DataSource = dt;
                }
                catch (Exception ex)
                {
                    gridControlFile.DataSource = null;
                }
            }

           
        }

        private void InitGridControl()
        {
            /*
             *  Dungnv  :   11/06/2016
             *  Purpose :   Khoi tao luoi GridControl 
             */

            try
            {
                DataTable dt = new DataTable();

               
                dt.Columns.Add(new DataColumn("FILENAME", Type.GetType("System.String")));
                //dt.Columns.Add(new DataColumn("CREATEDATE", Type.GetType("System.DateTime")));
                dt.Columns.Add(new DataColumn("CREATEDATE", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("FILESIZE", Type.GetType("System.String")));


                dt.Columns["FILENAME"].Caption = "Tên file";
                dt.Columns["CREATEDATE"].Caption = "Ngày tạo";
                dt.Columns["FILESIZE"].Caption = "Kích thước";
                gridControlFile.DataSource = dt;


                gridViewFile.PopulateColumns();
                gridViewFile.Columns["FILENAME"].Width = 200;
                gridViewFile.Columns["FILENAME"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewFile.Columns["FILENAME"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                gridViewFile.Columns["CREATEDATE"].Width = 100;
                gridViewFile.Columns["CREATEDATE"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewFile.Columns["CREATEDATE"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


                gridViewFile.Columns["FILESIZE"].Width = 100;
                gridViewFile.Columns["FILESIZE"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            }
            catch (Exception ex)
            {
            }

        }

        private void bttBackup_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   Bakup du lieu
             */
            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_BACKUP);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            if(ws.backupData()==true)
            {
                ClsCommonProcess.msg(ClsParameter.MSG_BACKUP_SUCCESS);
                loadlistFile();
            }
            else
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_BACKUP_FAIL);
            }
        }

        private void gridViewFile_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            /*
             * Dungnv   :   12/06/2016
             * Purpose  :   Format Number
             */

            try
            {
                if (e.Column.FieldName == "FILESIZE")
                {
                    string strNum = "";
                    strNum = e.DisplayText;
                    e.DisplayText = ClsCommonProcess.formartNumber(strNum);
                }
            }
            catch (Exception ex)
            {
            }
 
        }

        private void bttRestore_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   12/06/2016
             * Purpose  :   Restore Database
             */

            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_RESTORE);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            if(txtFileName.Text.Trim()=="")
            {
                ClsCommonProcess.msg(ClsParameter.MSG_FILENAME_EMTY);
                return;

            }
            string strFileName = txtFileName.Text.Trim();

            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            if(ws.restoreData(strFileName)==true)
            {
                ClsCommonProcess.msg(ClsParameter.MSG_RESTORE_SUCCESS);
            }
            else
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_RESTORE_FAIL);
            }
          
        }

        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.progressBar.Value = e.Percent;
        }

        private void gridViewFile_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   select file
             */

            if (gridViewFile != null)
            {
                if (gridViewFile.RowCount > 0)
                {
                    try
                    {
                        txtFileName.Text = gridViewFile.GetRowCellValue(gridViewFile.FocusedRowHandle, "FILENAME").ToString();
                    }
                    catch(Exception ex)
                    {
                        txtFileName.Text = "";
                    }
                    
                }
            }
        }

    }
}