namespace GYM.frm
{
    partial class frmBackupRestore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBackupRestore = new DevExpress.XtraEditors.GroupControl();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.gridControl_Main = new DevExpress.XtraGrid.GridControl();
            this.grvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackupLog = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackupDB = new DevExpress.XtraEditors.SimpleButton();
            this.chkIncremental = new DevExpress.XtraEditors.CheckEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmdDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkWindowsAuthentication = new DevExpress.XtraEditors.CheckEdit();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLogin = new DevExpress.XtraEditors.TextEdit();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage_LocalInstances = new DevExpress.XtraTab.XtraTabPage();
            this.lstLocalInstances = new DevExpress.XtraEditors.ListBoxControl();
            this.tabPage_NetworkInstances = new DevExpress.XtraTab.XtraTabPage();
            this.lstNetworkInstances = new DevExpress.XtraEditors.ListBoxControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpBackupRestore)).BeginInit();
            this.grpBackupRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncremental.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowsAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage_LocalInstances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstLocalInstances)).BeginInit();
            this.tabPage_NetworkInstances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstNetworkInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBackupRestore
            // 
            this.grpBackupRestore.Controls.Add(this.progressBarControl);
            this.grpBackupRestore.Controls.Add(this.gridControl_Main);
            this.grpBackupRestore.Controls.Add(this.btnVerify);
            this.grpBackupRestore.Controls.Add(this.btnRestore);
            this.grpBackupRestore.Controls.Add(this.btnBackupLog);
            this.grpBackupRestore.Controls.Add(this.btnBackupDB);
            this.grpBackupRestore.Controls.Add(this.chkIncremental);
            this.grpBackupRestore.Controls.Add(this.btnBrowse);
            this.grpBackupRestore.Controls.Add(this.txtFileName);
            this.grpBackupRestore.Controls.Add(this.labelControl4);
            this.grpBackupRestore.Controls.Add(this.cmdDatabase);
            this.grpBackupRestore.Controls.Add(this.labelControl3);
            this.grpBackupRestore.Controls.Add(this.chkWindowsAuthentication);
            this.grpBackupRestore.Controls.Add(this.btnConnect);
            this.grpBackupRestore.Controls.Add(this.labelControl2);
            this.grpBackupRestore.Controls.Add(this.txtPassword);
            this.grpBackupRestore.Controls.Add(this.labelControl1);
            this.grpBackupRestore.Controls.Add(this.txtLogin);
            this.grpBackupRestore.Controls.Add(this.tabMain);
            this.grpBackupRestore.Location = new System.Drawing.Point(12, 12);
            this.grpBackupRestore.Name = "grpBackupRestore";
            this.grpBackupRestore.Size = new System.Drawing.Size(794, 465);
            this.grpBackupRestore.TabIndex = 0;
            this.grpBackupRestore.Text = "Thông tin";
            // 
            // progressBarControl
            // 
            this.progressBarControl.Location = new System.Drawing.Point(5, 442);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Size = new System.Drawing.Size(780, 18);
            this.progressBarControl.TabIndex = 18;
            // 
            // gridControl_Main
            // 
            this.gridControl_Main.Location = new System.Drawing.Point(5, 239);
            this.gridControl_Main.MainView = this.grvResult;
            this.gridControl_Main.Name = "gridControl_Main";
            this.gridControl_Main.Size = new System.Drawing.Size(780, 197);
            this.gridControl_Main.TabIndex = 17;
            this.gridControl_Main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResult});
            // 
            // grvResult
            // 
            this.grvResult.GridControl = this.gridControl_Main;
            this.grvResult.Name = "grvResult";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(710, 202);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 16;
            this.btnVerify.Text = "Verified";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(622, 202);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(541, 202);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(75, 23);
            this.btnBackupLog.TabIndex = 14;
            this.btnBackupLog.Text = "Backup Log";
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(460, 202);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(75, 23);
            this.btnBackupDB.TabIndex = 13;
            this.btnBackupDB.Text = "Backup";
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // chkIncremental
            // 
            this.chkIncremental.Location = new System.Drawing.Point(460, 177);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Properties.Caption = "Incremental";
            this.chkIncremental.Size = new System.Drawing.Size(159, 19);
            this.chkIncremental.TabIndex = 12;
            this.chkIncremental.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(710, 149);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(545, 151);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(159, 20);
            this.txtFileName.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(460, 158);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Backup File";
            // 
            // cmdDatabase
            // 
            this.cmdDatabase.Location = new System.Drawing.Point(545, 125);
            this.cmdDatabase.Name = "cmdDatabase";
            this.cmdDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdDatabase.Size = new System.Drawing.Size(159, 20);
            this.cmdDatabase.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(460, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "DataBase";
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(460, 100);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Properties.Caption = "Use Windows Authentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(159, 19);
            this.chkWindowsAuthentication.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(710, 72);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(460, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(545, 74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(159, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(460, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(545, 48);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(159, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(5, 23);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tabPage_LocalInstances;
            this.tabMain.Size = new System.Drawing.Size(449, 210);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage_LocalInstances,
            this.tabPage_NetworkInstances});
            // 
            // tabPage_LocalInstances
            // 
            this.tabPage_LocalInstances.Controls.Add(this.lstLocalInstances);
            this.tabPage_LocalInstances.Name = "tabPage_LocalInstances";
            this.tabPage_LocalInstances.Size = new System.Drawing.Size(443, 182);
            this.tabPage_LocalInstances.Text = "Local Instances";
            // 
            // lstLocalInstances
            // 
            this.lstLocalInstances.Location = new System.Drawing.Point(3, 3);
            this.lstLocalInstances.Name = "lstLocalInstances";
            this.lstLocalInstances.Size = new System.Drawing.Size(437, 176);
            this.lstLocalInstances.TabIndex = 0;
            // 
            // tabPage_NetworkInstances
            // 
            this.tabPage_NetworkInstances.Controls.Add(this.lstNetworkInstances);
            this.tabPage_NetworkInstances.Name = "tabPage_NetworkInstances";
            this.tabPage_NetworkInstances.Size = new System.Drawing.Size(443, 182);
            this.tabPage_NetworkInstances.Text = "Network Instances";
            // 
            // lstNetworkInstances
            // 
            this.lstNetworkInstances.Location = new System.Drawing.Point(6, 3);
            this.lstNetworkInstances.Name = "lstNetworkInstances";
            this.lstNetworkInstances.Size = new System.Drawing.Size(434, 176);
            this.lstNetworkInstances.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(731, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 521);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpBackupRestore);
            this.MaximizeBox = false;
            this.Name = "frmBackupRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu và phục hồi dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpBackupRestore)).EndInit();
            this.grpBackupRestore.ResumeLayout(false);
            this.grpBackupRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncremental.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowsAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage_LocalInstances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstLocalInstances)).EndInit();
            this.tabPage_NetworkInstances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstNetworkInstances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpBackupRestore;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tabPage_LocalInstances;
        private DevExpress.XtraEditors.ListBoxControl lstLocalInstances;
        private DevExpress.XtraTab.XtraTabPage tabPage_NetworkInstances;
        private DevExpress.XtraEditors.ListBoxControl lstNetworkInstances;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmdDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkWindowsAuthentication;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraGrid.GridControl gridControl_Main;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResult;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.SimpleButton btnBackupLog;
        private DevExpress.XtraEditors.SimpleButton btnBackupDB;
        private DevExpress.XtraEditors.CheckEdit chkIncremental;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;
    }
}