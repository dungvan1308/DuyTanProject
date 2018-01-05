using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using GYM.Common;

namespace GYM.frm
{
    public partial class frmBackupRestore : DevExpress.XtraEditors.XtraForm
    {
        Server srv;
        ServerConnection conn;
        public frmBackupRestore()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackupRestore_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   10/06/2016
             * Purpose  :
             */
 
            txtFileName.Text = getDefaultBackupFileName();

            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            String[] instances = (String[])rk.GetValue("InstalledInstances");
            if (instances != null)
            {
                if (instances.Length > 0)
                {
                    foreach (String element in instances)
                    {
                        if (element == "MSSQLSERVER")
                            lstLocalInstances.Items.Add(System.Environment.MachineName);
                        else
                            lstLocalInstances.Items.Add(System.Environment.MachineName + @"\" + element);
                    }
                }
            }
            else
            {
                RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");

                foreach (string s in key.GetValueNames())
                {
                    if (s == "MSSQLSERVER")
                        lstLocalInstances.Items.Add(System.Environment.MachineName);
                    else
                        lstLocalInstances.Items.Add(System.Environment.MachineName + @"\" + s);
                }

                key.Close();
                baseKey.Close();
            }


            Thread threadGetNetworkInstances = new Thread(GetNetworkInstances);
            threadGetNetworkInstances.Start();
        }
        private static string getDefaultBackupFileName()
        {
            /*
             * Dungnv   :   10/06/2016
             * Purpose  :   Get Filename
             */
 
            return ClsParameter.SQL_BACKUP_PATH + "GYM_" + DateTime.Now.ToString("ddMMyyyy") + ".bak";
        }

        // Dung de uy quyen Set Messagel Call back
        delegate void SetMessageCallback(string text);

        private void AddNetworkInstance(string text)
        {
            /*
             * Dungnv   :   10/06/2016
             * Purpose
             */
 
            if (this.lstNetworkInstances.InvokeRequired)
            {
                SetMessageCallback d = new SetMessageCallback(AddNetworkInstance);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.lstNetworkInstances.Items.Add(text);
            }
        }

        private void GetNetworkInstances()
        {
            /*
             * Dungnv   :   10/06/2016
             * Purpose  :   
             */
 
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AddNetworkInstance(dr["Name"].ToString());
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                cmdDatabase.Properties.Items.Clear();

                string sqlSErverInstance;

                if (this.tabMain.SelectedTabPageIndex == 0)
                {
                    sqlSErverInstance = lstLocalInstances.SelectedItem.ToString();
                }
                else
                {
                    sqlSErverInstance = lstNetworkInstances.SelectedItem.ToString();
                }

                if (chkWindowsAuthentication.Checked == true)
                {
                    conn = new ServerConnection();
                    conn.ServerInstance = sqlSErverInstance;
                }
                else
                {
                    conn = new ServerConnection(sqlSErverInstance, txtLogin.Text, txtPassword.Text);
                }
                srv = new Server(conn);

                foreach (Database db in srv.Databases)
                {
                    cmdDatabase.Properties.Items.Add(db.Name);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            Backup bkp = new Backup();

            this.Cursor = Cursors.WaitCursor;
            this.gridControl_Main.DataSource = string.Empty;
            try
            {
                string fileName = this.txtFileName.Text;
                string databaseName = this.cmdDatabase.SelectedItem.ToString();

                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                bkp.Devices.AddDevice(fileName, DeviceType.File);
                //bkp.Incremental = chkIncremental.Checked;

                progressBarControl.Properties.Step = 1;
                progressBarControl.Properties.PercentView = true;
                this.progressBarControl.EditValue = 0;
                this.progressBarControl.Properties.Maximum = 100;
                this.progressBarControl.EditValue = 10;

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);

                bkp.SqlBackup(srv);
                MessageBox.Show("Database Backed Up To: " + fileName, "SMO Demos");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.progressBarControl.EditValue = 0;
            }
        }
        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.progressBarControl.EditValue = e.Percent;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :
             */
            Backup bkp = new Backup();

            Cursor = Cursors.WaitCursor;
            gridControl_Main.DataSource = "";

            try
            {
                string strFileName = txtFileName.Text.ToString();
                string strDatabaseName = cmdDatabase.SelectedItem.ToString();

                bkp.Action = BackupActionType.Log;
                bkp.Database = strDatabaseName;

                bkp.Devices.AddDevice(strFileName, DeviceType.File);
                progressBarControl.EditValue = 0;
                progressBarControl.Properties.Maximum = 100;
                progressBarControl.EditValue = 10;

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);

                bkp.SqlBackup(srv);
                MessageBox.Show("Log Backed Up To: " + strFileName, "SMO Demos");
            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                Cursor = Cursors.Default;
                progressBarControl.EditValue = 0;
            }
        }
    }
}