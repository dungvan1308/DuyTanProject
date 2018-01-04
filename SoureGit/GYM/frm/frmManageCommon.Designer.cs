namespace GYM.frm
{
    partial class frmManageCommon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageCommon));
            this.grbCtrlResult = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.dtgResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grbCtrl_Search = new DevExpress.XtraEditors.GroupControl();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtContent = new DevExpress.XtraEditors.TextEdit();
            this.bttSearch = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.bttAdd = new System.Windows.Forms.ToolStripButton();
            this.bttUpdate = new System.Windows.Forms.ToolStripButton();
            this.bttView = new System.Windows.Forms.ToolStripButton();
            this.bttDelete = new System.Windows.Forms.ToolStripButton();
            this.bttLock = new System.Windows.Forms.ToolStripButton();
            this.bttUnlock = new System.Windows.Forms.ToolStripButton();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrlResult)).BeginInit();
            this.grbCtrlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrl_Search)).BeginInit();
            this.grbCtrl_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCtrlResult
            // 
            this.grbCtrlResult.Controls.Add(this.gridControlMain);
            this.grbCtrlResult.Location = new System.Drawing.Point(5, 105);
            this.grbCtrlResult.Name = "grbCtrlResult";
            this.grbCtrlResult.Size = new System.Drawing.Size(887, 370);
            this.grbCtrlResult.TabIndex = 5;
            this.grbCtrlResult.Text = "Kết quả";
            // 
            // gridControlMain
            // 
            this.gridControlMain.Location = new System.Drawing.Point(5, 24);
            this.gridControlMain.MainView = this.dtgResult;
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.Size = new System.Drawing.Size(877, 341);
            this.gridControlMain.TabIndex = 2;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgResult});
            this.gridControlMain.DoubleClick += new System.EventHandler(this.gridControlMain_DoubleClick);
            // 
            // dtgResult
            // 
            this.dtgResult.GridControl = this.gridControlMain;
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgResult.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgResult.OptionsBehavior.Editable = false;
            this.dtgResult.OptionsBehavior.ReadOnly = true;
            this.dtgResult.OptionsView.ColumnAutoWidth = false;
            this.dtgResult.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dtgResult_CustomColumnDisplayText);
            this.dtgResult.Click += new System.EventHandler(this.dtgResult_Click);
            // 
            // grbCtrl_Search
            // 
            this.grbCtrl_Search.Controls.Add(this.cmbStatus);
            this.grbCtrl_Search.Controls.Add(this.txtContent);
            this.grbCtrl_Search.Controls.Add(this.bttSearch);
            this.grbCtrl_Search.Location = new System.Drawing.Point(5, 28);
            this.grbCtrl_Search.Name = "grbCtrl_Search";
            this.grbCtrl_Search.Size = new System.Drawing.Size(887, 71);
            this.grbCtrl_Search.TabIndex = 4;
            this.grbCtrl_Search.Text = "Thông tin tra cứu";
            // 
            // cmbStatus
            // 
            this.cmbStatus.EditValue = "";
            this.cmbStatus.Location = new System.Drawing.Point(5, 36);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Size = new System.Drawing.Size(97, 20);
            this.cmbStatus.TabIndex = 0;
            this.cmbStatus.Tag = "TERM";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(108, 37);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(693, 20);
            this.txtContent.TabIndex = 1;
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
            // 
            // bttSearch
            // 
            this.bttSearch.ImageIndex = 0;
            this.bttSearch.ImageList = this.imgLst;
            this.bttSearch.Location = new System.Drawing.Point(807, 34);
            this.bttSearch.Name = "bttSearch";
            this.bttSearch.Size = new System.Drawing.Size(75, 23);
            this.bttSearch.TabIndex = 1;
            this.bttSearch.Text = "Tìm";
            this.bttSearch.Click += new System.EventHandler(this.bttSearch_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(1, "Cancel.ico");
            this.imgLst.Images.SetKeyName(2, "add.ico");
            this.imgLst.Images.SetKeyName(3, "accept.ico");
            this.imgLst.Images.SetKeyName(4, "unlock.ico");
            this.imgLst.Images.SetKeyName(5, "open lock.ico");
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttAdd,
            this.bttUpdate,
            this.bttView,
            this.bttDelete,
            this.bttLock,
            this.bttUnlock});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(903, 25);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // bttAdd
            // 
            this.bttAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttAdd.Image = global::GYM.CompanyInfo.add;
            this.bttAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttAdd.Name = "bttAdd";
            this.bttAdd.Size = new System.Drawing.Size(23, 22);
            this.bttAdd.Text = "Thêm mới";
            this.bttAdd.Click += new System.EventHandler(this.bttAdd_Click);
            // 
            // bttUpdate
            // 
            this.bttUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttUpdate.Image = global::GYM.CompanyInfo.FPEDITAX_DLL_3;
            this.bttUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttUpdate.Name = "bttUpdate";
            this.bttUpdate.Size = new System.Drawing.Size(23, 22);
            this.bttUpdate.Text = "Sửa";
            this.bttUpdate.Click += new System.EventHandler(this.bttUpdate_Click);
            // 
            // bttView
            // 
            this.bttView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttView.Image = global::GYM.CompanyInfo.list___Copy;
            this.bttView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttView.Name = "bttView";
            this.bttView.Size = new System.Drawing.Size(23, 22);
            this.bttView.Text = "Xem";
            this.bttView.Click += new System.EventHandler(this.bttView_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttDelete.Image = global::GYM.CompanyInfo.Cancel;
            this.bttDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(23, 22);
            this.bttDelete.Text = "Xóa";
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttLock
            // 
            this.bttLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttLock.Image = global::GYM.CompanyInfo._lock;
            this.bttLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttLock.Name = "bttLock";
            this.bttLock.Size = new System.Drawing.Size(23, 22);
            this.bttLock.Text = "Khóa";
            this.bttLock.Click += new System.EventHandler(this.bttLock_Click);
            // 
            // bttUnlock
            // 
            this.bttUnlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttUnlock.Image = global::GYM.CompanyInfo.open_lock;
            this.bttUnlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttUnlock.Name = "bttUnlock";
            this.bttUnlock.Size = new System.Drawing.Size(23, 22);
            this.bttUnlock.Text = "Mở khóa";
            this.bttUnlock.Click += new System.EventHandler(this.bttUnlock_Click);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 1;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(817, 481);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 3;
            this.bttExit.Text = "Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // frmManageCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 511);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.grbCtrlResult);
            this.Controls.Add(this.grbCtrl_Search);
            this.Controls.Add(this.toolStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmManageCommon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin ";
            this.Load += new System.EventHandler(this.frmManageCommon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrlResult)).EndInit();
            this.grbCtrlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrl_Search)).EndInit();
            this.grbCtrl_Search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbCtrlResult;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgResult;
        private DevExpress.XtraEditors.GroupControl grbCtrl_Search;
        private DevExpress.XtraEditors.SimpleButton bttSearch;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.TextEdit txtContent;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton bttAdd;
        private System.Windows.Forms.ToolStripButton bttUpdate;
        private System.Windows.Forms.ToolStripButton bttView;
        private System.Windows.Forms.ToolStripButton bttDelete;
        private System.Windows.Forms.ToolStripButton bttLock;
        private System.Windows.Forms.ToolStripButton bttUnlock;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
    }
}