namespace GYM.frm
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.bttLogin = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labUserName = new System.Windows.Forms.Label();
            this.labPass = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bttLogin
            // 
            this.bttLogin.ImageIndex = 0;
            this.bttLogin.ImageList = this.imgLst;
            this.bttLogin.Location = new System.Drawing.Point(119, 86);
            this.bttLogin.Name = "bttLogin";
            this.bttLogin.Size = new System.Drawing.Size(89, 23);
            this.bttLogin.TabIndex = 5;
            this.bttLogin.Text = "&Đăng nhập";
            this.bttLogin.Click += new System.EventHandler(this.bttLogin_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "login - Copy.ico");
            this.imgLst.Images.SetKeyName(1, "Cancel.ico");
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 1;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(214, 86);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(89, 23);
            this.bttExit.TabIndex = 6;
            this.bttExit.Text = "&Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPass);
            this.panelControl1.Controls.Add(this.labUserName);
            this.panelControl1.Controls.Add(this.labPass);
            this.panelControl1.Controls.Add(this.txtUserName);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(291, 68);
            this.panelControl1.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(121, 37);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(157, 20);
            this.txtPass.TabIndex = 1;
          
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(5, 14);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(79, 13);
            this.labUserName.TabIndex = 0;
            this.labUserName.Text = "Tên đăng nhập";
            // 
            // labPass
            // 
            this.labPass.AutoSize = true;
            this.labPass.Location = new System.Drawing.Point(5, 40);
            this.labPass.Name = "labPass";
            this.labPass.Size = new System.Drawing.Size(51, 13);
            this.labPass.TabIndex = 2;
            this.labPass.Text = "Mật khẩu";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(121, 11);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.bttLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 119);
            this.Controls.Add(this.bttLogin);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bttLogin;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labPass;
        private DevExpress.XtraEditors.TextEdit txtUserName;

    }
}