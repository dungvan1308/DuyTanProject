namespace GYM.frm
{
    partial class frmAuthoriseMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthoriseMenu));
            this.GrpAuthorise = new System.Windows.Forms.GroupBox();
            this.menuTreeList = new DevExpress.XtraTreeList.TreeList();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpGrp = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.GrpAuthorise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGrp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpAuthorise
            // 
            this.GrpAuthorise.Controls.Add(this.menuTreeList);
            this.GrpAuthorise.Controls.Add(this.labelControl1);
            this.GrpAuthorise.Controls.Add(this.lookUpGrp);
            this.GrpAuthorise.Location = new System.Drawing.Point(12, 11);
            this.GrpAuthorise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpAuthorise.Name = "GrpAuthorise";
            this.GrpAuthorise.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrpAuthorise.Size = new System.Drawing.Size(440, 420);
            this.GrpAuthorise.TabIndex = 17;
            this.GrpAuthorise.TabStop = false;
            this.GrpAuthorise.Text = "Thông tin phân quyền";
            // 
            // menuTreeList
            // 
            this.menuTreeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuTreeList.Location = new System.Drawing.Point(6, 52);
            this.menuTreeList.Name = "menuTreeList";
            this.menuTreeList.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.menuTreeList.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.menuTreeList.OptionsView.ShowCheckBoxes = true;
            this.menuTreeList.Size = new System.Drawing.Size(420, 363);
            this.menuTreeList.TabIndex = 2;
            this.menuTreeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.menuTreeList_AfterCheckNode);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 29);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nhóm người dùng";
            // 
            // lookUpGrp
            // 
            this.lookUpGrp.Location = new System.Drawing.Point(106, 27);
            this.lookUpGrp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lookUpGrp.Name = "lookUpGrp";
            this.lookUpGrp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGrp.Properties.View = this.searchLookUpEdit1View;
            this.lookUpGrp.Size = new System.Drawing.Size(320, 20);
            this.lookUpGrp.TabIndex = 0;
            this.lookUpGrp.EditValueChanged += new System.EventHandler(this.lookUpGrp_EditValueChanged);
            this.lookUpGrp.Click += new System.EventHandler(this.lookUpGrp_Click);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 2;
            this.bttSave.ImageList = this.imgLst;
            this.bttSave.Location = new System.Drawing.Point(297, 439);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(75, 23);
            this.bttSave.TabIndex = 15;
            this.bttSave.Text = "Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            this.imgLst.Images.SetKeyName(3, "Next.ico");
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(377, 439);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 16;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // frmAuthoriseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 475);
            this.Controls.Add(this.GrpAuthorise);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAuthoriseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phân quyền";
            this.Load += new System.EventHandler(this.frmAuthoriseMenu_Load);
            this.GrpAuthorise.ResumeLayout(false);
            this.GrpAuthorise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGrp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpAuthorise;
        private DevExpress.XtraTreeList.TreeList menuTreeList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpGrp;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton bttSave;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttExit;

    }
}