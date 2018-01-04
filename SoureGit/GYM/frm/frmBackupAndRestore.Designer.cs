namespace GYM.frm
{
    partial class frmBackupAndRestore
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupAndRestore));
            this.grpInfor = new DevExpress.XtraEditors.GroupControl();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gridControlFile = new DevExpress.XtraGrid.GridControl();
            this.gridViewFile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FILENAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CREATEDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FILESIZE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.bttRestore = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttBackup = new DevExpress.XtraEditors.SimpleButton();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfor)).BeginInit();
            this.grpInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfor
            // 
            this.grpInfor.Controls.Add(this.txtFileName);
            this.grpInfor.Controls.Add(this.progressBar);
            this.grpInfor.Controls.Add(this.gridControlFile);
            this.grpInfor.Location = new System.Drawing.Point(12, 12);
            this.grpInfor.Name = "grpInfor";
            this.grpInfor.Size = new System.Drawing.Size(577, 364);
            this.grpInfor.TabIndex = 0;
            this.grpInfor.Text = "Thông tin";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(7, 23);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtFileName.Properties.Appearance.Options.UseForeColor = true;
            this.txtFileName.Properties.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(565, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 334);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(567, 23);
            this.progressBar.TabIndex = 8;
            // 
            // gridControlFile
            // 
            this.gridControlFile.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlFile.Location = new System.Drawing.Point(7, 48);
            this.gridControlFile.MainView = this.gridViewFile;
            this.gridControlFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlFile.Name = "gridControlFile";
            this.gridControlFile.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonDelete});
            this.gridControlFile.Size = new System.Drawing.Size(567, 278);
            this.gridControlFile.TabIndex = 7;
            this.gridControlFile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFile});
            // 
            // gridViewFile
            // 
            this.gridViewFile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FILENAME,
            this.CREATEDATE,
            this.FILESIZE});
            this.gridViewFile.GridControl = this.gridControlFile;
            this.gridViewFile.Name = "gridViewFile";
            this.gridViewFile.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFile.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFile.OptionsBehavior.Editable = false;
            this.gridViewFile.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewFile_CustomColumnDisplayText);
            this.gridViewFile.Click += new System.EventHandler(this.gridViewFile_Click);
            // 
            // FILENAME
            // 
            this.FILENAME.Caption = "Tên File";
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.Visible = true;
            this.FILENAME.VisibleIndex = 0;
            this.FILENAME.Width = 340;
            // 
            // CREATEDATE
            // 
            this.CREATEDATE.Caption = "Ngày tạo";
            this.CREATEDATE.Name = "CREATEDATE";
            this.CREATEDATE.Visible = true;
            this.CREATEDATE.VisibleIndex = 1;
            this.CREATEDATE.Width = 299;
            // 
            // FILESIZE
            // 
            this.FILESIZE.Caption = "Kích thước";
            this.FILESIZE.Name = "FILESIZE";
            this.FILESIZE.Visible = true;
            this.FILESIZE.VisibleIndex = 2;
            this.FILESIZE.Width = 112;
            // 
            // repositoryItemButtonDelete
            // 
            this.repositoryItemButtonDelete.AppearanceDisabled.Options.UseImage = true;
            this.repositoryItemButtonDelete.AutoHeight = false;
            this.repositoryItemButtonDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonDelete.Name = "repositoryItemButtonDelete";
            // 
            // bttRestore
            // 
            this.bttRestore.ImageIndex = 5;
            this.bttRestore.ImageList = this.imgLst;
            this.bttRestore.Location = new System.Drawing.Point(433, 382);
            this.bttRestore.Name = "bttRestore";
            this.bttRestore.Size = new System.Drawing.Size(75, 23);
            this.bttRestore.TabIndex = 1;
            this.bttRestore.Text = "Khôi phục";
            this.bttRestore.Click += new System.EventHandler(this.bttRestore_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            this.imgLst.Images.SetKeyName(3, "Next.ico");
            this.imgLst.Images.SetKeyName(4, "add.ico");
            this.imgLst.Images.SetKeyName(5, "database.ico");
            // 
            // bttBackup
            // 
            this.bttBackup.ImageIndex = 2;
            this.bttBackup.ImageList = this.imgLst;
            this.bttBackup.Location = new System.Drawing.Point(352, 382);
            this.bttBackup.Name = "bttBackup";
            this.bttBackup.Size = new System.Drawing.Size(75, 23);
            this.bttBackup.TabIndex = 0;
            this.bttBackup.Text = "Sao lưu";
            this.bttBackup.Click += new System.EventHandler(this.bttBackup_Click);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(514, 382);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 2;
            this.bttExit.Text = "Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // frmBackupAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 413);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.grpInfor);
            this.Controls.Add(this.bttBackup);
            this.Controls.Add(this.bttRestore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBackupAndRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu và khôi phục dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupAndRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpInfor)).EndInit();
            this.grpInfor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpInfor;
        private DevExpress.XtraEditors.SimpleButton bttRestore;
        private DevExpress.XtraEditors.SimpleButton bttBackup;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraGrid.GridControl gridControlFile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFile;
        private DevExpress.XtraGrid.Columns.GridColumn FILENAME;
        private DevExpress.XtraGrid.Columns.GridColumn CREATEDATE;
        private DevExpress.XtraGrid.Columns.GridColumn FILESIZE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonDelete;
        private System.Windows.Forms.ProgressBar progressBar;
        private DevExpress.XtraEditors.TextEdit txtFileName;
    }
}