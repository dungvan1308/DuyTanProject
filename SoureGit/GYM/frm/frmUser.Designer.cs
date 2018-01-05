namespace GYM.frm
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEmployee = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpGroupUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkLock = new DevExpress.XtraEditors.CheckEdit();
            this.labLock = new DevExpress.XtraEditors.LabelControl();
            this.labGroupId = new DevExpress.XtraEditors.LabelControl();
            this.labFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labUserName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserId = new DevExpress.XtraEditors.TextEdit();
            this.labUserId = new DevExpress.XtraEditors.LabelControl();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttNext = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroupUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookUpEmployee);
            this.panelControl1.Controls.Add(this.lookUpGroupUser);
            this.panelControl1.Controls.Add(this.checkLock);
            this.panelControl1.Controls.Add(this.labLock);
            this.panelControl1.Controls.Add(this.labGroupId);
            this.panelControl1.Controls.Add(this.labFullName);
            this.panelControl1.Controls.Add(this.txtFullName);
            this.panelControl1.Controls.Add(this.txtUserName);
            this.panelControl1.Controls.Add(this.labUserName);
            this.panelControl1.Controls.Add(this.txtUserId);
            this.panelControl1.Controls.Add(this.labUserId);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(359, 176);
            this.panelControl1.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // lookUpEmployee
            // 
            this.lookUpEmployee.EditValue = "";
            this.lookUpEmployee.Location = new System.Drawing.Point(112, 143);
            this.lookUpEmployee.Name = "lookUpEmployee";
            this.lookUpEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEmployee.Properties.NullText = "[Chọn mã nhân viên tương ứng]";
            this.lookUpEmployee.Properties.View = this.gridView2;
            this.lookUpEmployee.Size = new System.Drawing.Size(234, 20);
            this.lookUpEmployee.TabIndex = 5;
            this.lookUpEmployee.Click += new System.EventHandler(this.lookUpEmployee_Click);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // lookUpGroupUser
            // 
            this.lookUpGroupUser.Location = new System.Drawing.Point(112, 92);
            this.lookUpGroupUser.Name = "lookUpGroupUser";
            this.lookUpGroupUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGroupUser.Properties.View = this.searchLookUpEdit1View;
            this.lookUpGroupUser.Size = new System.Drawing.Size(234, 20);
            this.lookUpGroupUser.TabIndex = 3;
            this.lookUpGroupUser.Click += new System.EventHandler(this.lookUpGroupUser_Click);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // checkLock
            // 
            this.checkLock.Location = new System.Drawing.Point(110, 118);
            this.checkLock.Name = "checkLock";
            this.checkLock.Properties.Caption = "";
            this.checkLock.Size = new System.Drawing.Size(75, 19);
            this.checkLock.TabIndex = 4;
            // 
            // labLock
            // 
            this.labLock.Location = new System.Drawing.Point(5, 120);
            this.labLock.Name = "labLock";
            this.labLock.Size = new System.Drawing.Size(24, 13);
            this.labLock.TabIndex = 8;
            this.labLock.Text = "Khóa";
            // 
            // labGroupId
            // 
            this.labGroupId.Location = new System.Drawing.Point(5, 95);
            this.labGroupId.Name = "labGroupId";
            this.labGroupId.Size = new System.Drawing.Size(84, 13);
            this.labGroupId.TabIndex = 7;
            this.labGroupId.Text = "Nhóm người dùng";
            // 
            // labFullName
            // 
            this.labFullName.Location = new System.Drawing.Point(5, 69);
            this.labFullName.Name = "labFullName";
            this.labFullName.Size = new System.Drawing.Size(32, 13);
            this.labFullName.TabIndex = 5;
            this.labFullName.Text = "Họ tên";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(112, 66);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(234, 20);
            this.txtFullName.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(112, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(5, 43);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(72, 13);
            this.labUserName.TabIndex = 2;
            this.labUserName.Text = "Tên đăng nhập";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(112, 14);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(105, 20);
            this.txtUserId.TabIndex = 0;
            // 
            // labUserId
            // 
            this.labUserId.Location = new System.Drawing.Point(5, 17);
            this.labUserId.Name = "labUserId";
            this.labUserId.Size = new System.Drawing.Size(71, 13);
            this.labUserId.TabIndex = 0;
            this.labUserId.Text = "Mã người dùng";
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "Next.ico");
            this.imgLst.Images.SetKeyName(3, "save.ico");
            // 
            // bttNext
            // 
            this.bttNext.ImageIndex = 1;
            this.bttNext.ImageList = this.imageList1;
            this.bttNext.Location = new System.Drawing.Point(134, 194);
            this.bttNext.Name = "bttNext";
            this.bttNext.Size = new System.Drawing.Size(75, 23);
            this.bttNext.TabIndex = 7;
            this.bttNext.Text = "Tiếp";
            this.bttNext.Click += new System.EventHandler(this.bttNext_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Cancel.ico");
            this.imageList1.Images.SetKeyName(1, "Find-Xp.ico");
            this.imageList1.Images.SetKeyName(2, "Next.ico");
            this.imageList1.Images.SetKeyName(3, "save.ico");
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 3;
            this.bttSave.ImageList = this.imageList1;
            this.bttSave.Location = new System.Drawing.Point(215, 194);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(75, 23);
            this.bttSave.TabIndex = 6;
            this.bttSave.Text = "&Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imageList1;
            this.bttExit.Location = new System.Drawing.Point(296, 194);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 8;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 227);
            this.Controls.Add(this.bttNext);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người dùng";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGroupUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpGroupUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.CheckEdit checkLock;
        private DevExpress.XtraEditors.LabelControl labLock;
        private DevExpress.XtraEditors.LabelControl labGroupId;
        private DevExpress.XtraEditors.LabelControl labFullName;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labUserName;
        private DevExpress.XtraEditors.TextEdit txtUserId;
        private DevExpress.XtraEditors.LabelControl labUserId;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttNext;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton bttSave;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}