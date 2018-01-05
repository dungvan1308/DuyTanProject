namespace GYM.frm
{
    partial class frmUserResetPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserResetPass));
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelCtrlMain = new DevExpress.XtraEditors.PanelControl();
            this.lookupUserName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labPass = new DevExpress.XtraEditors.LabelControl();
            this.labRetypePass = new DevExpress.XtraEditors.LabelControl();
            this.txtRetypePass = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labUserName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrlMain)).BeginInit();
            this.panelCtrlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 2;
            this.bttSave.ImageList = this.imgLst;
            this.bttSave.Location = new System.Drawing.Point(160, 118);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(75, 23);
            this.bttSave.TabIndex = 9;
            this.bttSave.Text = "&Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            this.imgLst.Images.SetKeyName(3, "Profile.ico");
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(241, 118);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 10;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // panelCtrlMain
            // 
            this.panelCtrlMain.Controls.Add(this.lookupUserName);
            this.panelCtrlMain.Controls.Add(this.labPass);
            this.panelCtrlMain.Controls.Add(this.labRetypePass);
            this.panelCtrlMain.Controls.Add(this.txtRetypePass);
            this.panelCtrlMain.Controls.Add(this.txtPass);
            this.panelCtrlMain.Controls.Add(this.labUserName);
            this.panelCtrlMain.Location = new System.Drawing.Point(12, 12);
            this.panelCtrlMain.Name = "panelCtrlMain";
            this.panelCtrlMain.Size = new System.Drawing.Size(304, 100);
            this.panelCtrlMain.TabIndex = 11;
            // 
            // lookupUserName
            // 
            this.lookupUserName.EditValue = "dd";
            this.lookupUserName.Location = new System.Drawing.Point(112, 14);
            this.lookupUserName.Name = "lookupUserName";
            this.lookupUserName.Properties.Appearance.Options.UseImage = true;
            this.lookupUserName.Properties.NullText = "[Chọn nhóm người dùng]";
            this.lookupUserName.Properties.View = this.searchView;
            this.lookupUserName.Size = new System.Drawing.Size(178, 20);
            this.lookupUserName.TabIndex = 0;
            this.lookupUserName.Click += new System.EventHandler(this.lookupUserName_Click);
            // 
            // searchView
            // 
            this.searchView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchView.Name = "searchView";
            this.searchView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchView.OptionsView.ShowGroupPanel = false;
            // 
            // labPass
            // 
            this.labPass.Location = new System.Drawing.Point(5, 43);
            this.labPass.Name = "labPass";
            this.labPass.Size = new System.Drawing.Size(44, 13);
            this.labPass.TabIndex = 9;
            this.labPass.Text = "Mật khẩu";
            // 
            // labRetypePass
            // 
            this.labRetypePass.Location = new System.Drawing.Point(5, 69);
            this.labRetypePass.Name = "labRetypePass";
            this.labRetypePass.Size = new System.Drawing.Size(85, 13);
            this.labRetypePass.TabIndex = 5;
            this.labRetypePass.Text = "Nhập lại mật khẩu";
            // 
            // txtRetypePass
            // 
            this.txtRetypePass.Location = new System.Drawing.Point(112, 66);
            this.txtRetypePass.Name = "txtRetypePass";
            this.txtRetypePass.Properties.PasswordChar = '*';
            this.txtRetypePass.Size = new System.Drawing.Size(178, 20);
            this.txtRetypePass.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(112, 40);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(178, 20);
            this.txtPass.TabIndex = 1;
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(5, 17);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(72, 13);
            this.labUserName.TabIndex = 2;
            this.labUserName.Text = "Tên đăng nhập";
            // 
            // frmUserResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 153);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.panelCtrlMain);
            this.MaximizeBox = false;
            this.Name = "frmUserResetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập mật khẩu";
            this.Load += new System.EventHandler(this.frmUserResetPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrlMain)).EndInit();
            this.panelCtrlMain.ResumeLayout(false);
            this.panelCtrlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bttSave;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.PanelControl panelCtrlMain;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupUserName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchView;
        private DevExpress.XtraEditors.LabelControl labPass;
        private DevExpress.XtraEditors.LabelControl labRetypePass;
        private DevExpress.XtraEditors.TextEdit txtRetypePass;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.LabelControl labUserName;
    }
}