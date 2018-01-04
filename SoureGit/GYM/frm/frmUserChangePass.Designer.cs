namespace GYM.frm
{
    partial class frmUserChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserChangePass));
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labRetypePass = new DevExpress.XtraEditors.LabelControl();
            this.txtRetypePass = new DevExpress.XtraEditors.TextEdit();
            this.labOldPass = new DevExpress.XtraEditors.LabelControl();
            this.labPass = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPass = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPass = new DevExpress.XtraEditors.TextEdit();
            this.labUserName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 0;
            this.bttSave.ImageList = this.imgLst;
            this.bttSave.Location = new System.Drawing.Point(160, 140);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(75, 23);
            this.bttSave.TabIndex = 12;
            this.bttSave.Text = "&Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "save.ico");
            this.imgLst.Images.SetKeyName(1, "Cancel.ico");
            this.imgLst.Images.SetKeyName(2, "Profile.ico");
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 1;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(241, 140);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 13;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtUserName);
            this.panelControl1.Controls.Add(this.labRetypePass);
            this.panelControl1.Controls.Add(this.txtRetypePass);
            this.panelControl1.Controls.Add(this.labOldPass);
            this.panelControl1.Controls.Add(this.labPass);
            this.panelControl1.Controls.Add(this.txtNewPass);
            this.panelControl1.Controls.Add(this.txtOldPass);
            this.panelControl1.Controls.Add(this.labUserName);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(304, 122);
            this.panelControl1.TabIndex = 14;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(112, 14);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(178, 20);
            this.txtUserName.TabIndex = 12;
            // 
            // labRetypePass
            // 
            this.labRetypePass.Location = new System.Drawing.Point(5, 95);
            this.labRetypePass.Name = "labRetypePass";
            this.labRetypePass.Size = new System.Drawing.Size(85, 13);
            this.labRetypePass.TabIndex = 11;
            this.labRetypePass.Text = "Nhập lại mật khẩu";
            // 
            // txtRetypePass
            // 
            this.txtRetypePass.Location = new System.Drawing.Point(112, 92);
            this.txtRetypePass.Name = "txtRetypePass";
            this.txtRetypePass.Properties.PasswordChar = '*';
            this.txtRetypePass.Size = new System.Drawing.Size(178, 20);
            this.txtRetypePass.TabIndex = 4;
            // 
            // labOldPass
            // 
            this.labOldPass.Location = new System.Drawing.Point(5, 43);
            this.labOldPass.Name = "labOldPass";
            this.labOldPass.Size = new System.Drawing.Size(44, 13);
            this.labOldPass.TabIndex = 9;
            this.labOldPass.Text = "Mật khẩu";
            // 
            // labPass
            // 
            this.labPass.Location = new System.Drawing.Point(5, 69);
            this.labPass.Name = "labPass";
            this.labPass.Size = new System.Drawing.Size(63, 13);
            this.labPass.TabIndex = 5;
            this.labPass.Text = "Mật khẩu mới";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(112, 66);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Properties.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(178, 20);
            this.txtNewPass.TabIndex = 3;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(112, 40);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Properties.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(178, 20);
            this.txtOldPass.TabIndex = 2;
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(5, 17);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(72, 13);
            this.labUserName.TabIndex = 2;
            this.labUserName.Text = "Tên đăng nhập";
            // 
            // frmUserChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 175);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmUserChangePass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bttSave;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labRetypePass;
        private DevExpress.XtraEditors.TextEdit txtRetypePass;
        private DevExpress.XtraEditors.LabelControl labOldPass;
        private DevExpress.XtraEditors.LabelControl labPass;
        private DevExpress.XtraEditors.TextEdit txtNewPass;
        private DevExpress.XtraEditors.TextEdit txtOldPass;
        private DevExpress.XtraEditors.LabelControl labUserName;
    }
}