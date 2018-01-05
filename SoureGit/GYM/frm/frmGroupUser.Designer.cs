namespace GYM.frm
{
    partial class frmGroupUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupUser));
            this.bttNext = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.labNote = new System.Windows.Forms.Label();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labGroupID = new System.Windows.Forms.Label();
            this.labGroupName = new System.Windows.Forms.Label();
            this.txtGroupId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            this.panelControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bttNext
            // 
            this.bttNext.ImageIndex = 1;
            this.bttNext.ImageList = this.imgLst;
            this.bttNext.Location = new System.Drawing.Point(280, 117);
            this.bttNext.Name = "bttNext";
            this.bttNext.Size = new System.Drawing.Size(89, 23);
            this.bttNext.TabIndex = 8;
            this.bttNext.Text = "&Tiếp";
            this.bttNext.Click += new System.EventHandler(this.bttNext_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Next - Copy.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 2;
            this.bttSave.ImageList = this.imgLst;
            this.bttSave.Location = new System.Drawing.Point(375, 117);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(89, 23);
            this.bttSave.TabIndex = 6;
            this.bttSave.Text = "&Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(470, 117);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(89, 23);
            this.bttExit.TabIndex = 9;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // panelControlMain
            // 
            this.panelControlMain.Controls.Add(this.labNote);
            this.panelControlMain.Controls.Add(this.txtNote);
            this.panelControlMain.Controls.Add(this.txtGroupName);
            this.panelControlMain.Controls.Add(this.labGroupID);
            this.panelControlMain.Controls.Add(this.labGroupName);
            this.panelControlMain.Controls.Add(this.txtGroupId);
            this.panelControlMain.Location = new System.Drawing.Point(12, 12);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(547, 99);
            this.panelControlMain.TabIndex = 7;
            // 
            // labNote
            // 
            this.labNote.AutoSize = true;
            this.labNote.Location = new System.Drawing.Point(5, 66);
            this.labNote.Name = "labNote";
            this.labNote.Size = new System.Drawing.Size(42, 13);
            this.labNote.TabIndex = 3;
            this.labNote.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(121, 63);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(421, 20);
            this.txtNote.TabIndex = 2;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(122, 37);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(420, 20);
            this.txtGroupName.TabIndex = 1;
            // 
            // labGroupID
            // 
            this.labGroupID.AutoSize = true;
            this.labGroupID.Location = new System.Drawing.Point(5, 14);
            this.labGroupID.Name = "labGroupID";
            this.labGroupID.Size = new System.Drawing.Size(107, 13);
            this.labGroupID.TabIndex = 0;
            this.labGroupID.Text = "Mã nhóm người dùng";
            // 
            // labGroupName
            // 
            this.labGroupName.AutoSize = true;
            this.labGroupName.Location = new System.Drawing.Point(5, 40);
            this.labGroupName.Name = "labGroupName";
            this.labGroupName.Size = new System.Drawing.Size(111, 13);
            this.labGroupName.TabIndex = 2;
            this.labGroupName.Text = "Tên nhóm người dùng";
            // 
            // txtGroupId
            // 
            this.txtGroupId.Enabled = false;
            this.txtGroupId.Location = new System.Drawing.Point(121, 11);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(157, 20);
            this.txtGroupId.TabIndex = 0;
            // 
            // frmGroupUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 151);
            this.Controls.Add(this.bttNext);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.panelControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGroupUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm người dùng";
            this.Load += new System.EventHandler(this.frmGroupUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            this.panelControlMain.ResumeLayout(false);
            this.panelControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bttNext;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttSave;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.PanelControl panelControlMain;
        private System.Windows.Forms.Label labNote;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private System.Windows.Forms.Label labGroupID;
        private System.Windows.Forms.Label labGroupName;
        private DevExpress.XtraEditors.TextEdit txtGroupId;

    }
}