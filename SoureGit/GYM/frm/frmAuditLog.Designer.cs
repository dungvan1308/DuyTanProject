namespace GYM.frm
{
    partial class frmAuditLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditLog));
            this.grbCtrl_Search = new DevExpress.XtraEditors.GroupControl();
            this.dtTodate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtFrdate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkNow = new DevExpress.XtraEditors.CheckEdit();
            this.bttSearch = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.grbCtrlResult = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.dtgResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bttClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrl_Search)).BeginInit();
            this.grbCtrl_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrlResult)).BeginInit();
            this.grbCtrlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCtrl_Search
            // 
            this.grbCtrl_Search.Controls.Add(this.dtTodate);
            this.grbCtrl_Search.Controls.Add(this.labelControl2);
            this.grbCtrl_Search.Controls.Add(this.dtFrdate);
            this.grbCtrl_Search.Controls.Add(this.labelControl1);
            this.grbCtrl_Search.Controls.Add(this.chkNow);
            this.grbCtrl_Search.Controls.Add(this.bttSearch);
            this.grbCtrl_Search.Location = new System.Drawing.Point(12, 12);
            this.grbCtrl_Search.Name = "grbCtrl_Search";
            this.grbCtrl_Search.Size = new System.Drawing.Size(514, 71);
            this.grbCtrl_Search.TabIndex = 5;
            this.grbCtrl_Search.Text = "Thông tin tra cứu";
            // 
            // dtTodate
            // 
            this.dtTodate.EditValue = null;
            this.dtTodate.Location = new System.Drawing.Point(279, 35);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTodate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTodate.Properties.EditFormat.FormatString = "DD/MM/YYYY";
            this.dtTodate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTodate.Size = new System.Drawing.Size(100, 20);
            this.dtTodate.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(226, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dtFrdate
            // 
            this.dtFrdate.EditValue = null;
            this.dtFrdate.Location = new System.Drawing.Point(120, 35);
            this.dtFrdate.Name = "dtFrdate";
            this.dtFrdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrdate.Properties.EditFormat.FormatString = "DD/MM/YYYY";
            this.dtFrdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrdate.Size = new System.Drawing.Size(100, 20);
            this.dtFrdate.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(74, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Từ ngày";
            // 
            // chkNow
            // 
            this.chkNow.Location = new System.Drawing.Point(5, 35);
            this.chkNow.Name = "chkNow";
            this.chkNow.Properties.Caption = "Hiện tại";
            this.chkNow.Size = new System.Drawing.Size(75, 19);
            this.chkNow.TabIndex = 2;
            this.chkNow.CheckedChanged += new System.EventHandler(this.chkNow_CheckedChanged);
            // 
            // bttSearch
            // 
            this.bttSearch.ImageIndex = 1;
            this.bttSearch.ImageList = this.imgLst;
            this.bttSearch.Location = new System.Drawing.Point(385, 33);
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
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            // 
            // grbCtrlResult
            // 
            this.grbCtrlResult.Controls.Add(this.gridControlMain);
            this.grbCtrlResult.Location = new System.Drawing.Point(12, 89);
            this.grbCtrlResult.Name = "grbCtrlResult";
            this.grbCtrlResult.Size = new System.Drawing.Size(514, 383);
            this.grbCtrlResult.TabIndex = 6;
            this.grbCtrlResult.Text = "Kết quả";
            // 
            // gridControlMain
            // 
            this.gridControlMain.Location = new System.Drawing.Point(5, 24);
            this.gridControlMain.MainView = this.dtgResult;
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.Size = new System.Drawing.Size(504, 354);
            this.gridControlMain.TabIndex = 0;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgResult});
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
            // 
            // bttClose
            // 
            this.bttClose.ImageIndex = 0;
            this.bttClose.ImageList = this.imgLst;
            this.bttClose.Location = new System.Drawing.Point(451, 478);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(75, 23);
            this.bttClose.TabIndex = 7;
            this.bttClose.Text = "Đóng";
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // frmAuditLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 509);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.grbCtrlResult);
            this.Controls.Add(this.grbCtrl_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAuditLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người dùng đăng nhập vào hệ thống";
            this.Load += new System.EventHandler(this.frmAuditLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrl_Search)).EndInit();
            this.grbCtrl_Search.ResumeLayout(false);
            this.grbCtrl_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtrlResult)).EndInit();
            this.grbCtrlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbCtrl_Search;
        private DevExpress.XtraEditors.SimpleButton bttSearch;
        private DevExpress.XtraEditors.CheckEdit chkNow;
        private DevExpress.XtraEditors.GroupControl grbCtrlResult;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgResult;
        private DevExpress.XtraEditors.DateEdit dtTodate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtFrdate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton bttClose;
        private System.Windows.Forms.ImageList imgLst;

    }
}