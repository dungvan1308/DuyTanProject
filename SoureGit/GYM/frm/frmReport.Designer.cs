namespace GYM.frm
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.grpList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.respo_image_Detete = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.respo_btt_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grpModule = new DevExpress.XtraEditors.GroupControl();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttView = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpList)).BeginInit();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.respo_image_Detete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.respo_btt_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpModule)).BeginInit();
            this.grpModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.gridControlMain);
            this.grpList.Location = new System.Drawing.Point(12, 79);
            this.grpList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(838, 371);
            this.grpList.TabIndex = 5;
            this.grpList.Text = "Danh sách báo cáo";
            // 
            // gridControlMain
            // 
            this.gridControlMain.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMain.Location = new System.Drawing.Point(4, 21);
            this.gridControlMain.MainView = this.gridViewMain;
            this.gridControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.respo_image_Detete,
            this.respo_btt_Delete});
            this.gridControlMain.Size = new System.Drawing.Size(830, 347);
            this.gridControlMain.TabIndex = 3;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMain});
            this.gridControlMain.Click += new System.EventHandler(this.gridControlMain_Click);
            // 
            // gridViewMain
            // 
            this.gridViewMain.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridViewMain.Appearance.GroupPanel.Options.UseFont = true;
            this.gridViewMain.GridControl = this.gridControlMain;
            this.gridViewMain.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewMain.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewMain.OptionsBehavior.Editable = false;
            this.gridViewMain.OptionsView.AllowHtmlDrawGroups = false;
            this.gridViewMain.OptionsView.ColumnAutoWidth = false;
            this.gridViewMain.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // respo_image_Detete
            // 
            this.respo_image_Detete.Appearance.Options.UseImage = true;
            this.respo_image_Detete.AutoHeight = false;
            this.respo_image_Detete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.respo_image_Detete.Name = "respo_image_Detete";
            // 
            // respo_btt_Delete
            // 
            this.respo_btt_Delete.AutoHeight = false;
            this.respo_btt_Delete.Name = "respo_btt_Delete";
            // 
            // grpModule
            // 
            this.grpModule.Controls.Add(this.cmbModule);
            this.grpModule.Location = new System.Drawing.Point(12, 11);
            this.grpModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpModule.Name = "grpModule";
            this.grpModule.Size = new System.Drawing.Size(838, 63);
            this.grpModule.TabIndex = 4;
            this.grpModule.Text = "Phân hệ báo cáo";
            // 
            // cmbModule
            // 
            this.cmbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Location = new System.Drawing.Point(4, 30);
            this.cmbModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(245, 21);
            this.cmbModule.TabIndex = 0;
            this.cmbModule.SelectedIndexChanged += new System.EventHandler(this.cmbModule_SelectedIndexChanged);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(788, 454);
            this.bttExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(64, 19);
            this.bttExit.TabIndex = 7;
            this.bttExit.Text = "Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "report.ico");
            // 
            // bttView
            // 
            this.bttView.ImageIndex = 1;
            this.bttView.ImageList = this.imgLst;
            this.bttView.Location = new System.Drawing.Point(718, 454);
            this.bttView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttView.Name = "bttView";
            this.bttView.Size = new System.Drawing.Size(64, 19);
            this.bttView.TabIndex = 6;
            this.bttView.Text = "Xem";
            this.bttView.Click += new System.EventHandler(this.bttView_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 484);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.bttView);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpModule);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpList)).EndInit();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.respo_image_Detete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.respo_btt_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpModule)).EndInit();
            this.grpModule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpList;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit respo_image_Detete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit respo_btt_Delete;
        private DevExpress.XtraEditors.GroupControl grpModule;
        private System.Windows.Forms.ComboBox cmbModule;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttView;
    }
}