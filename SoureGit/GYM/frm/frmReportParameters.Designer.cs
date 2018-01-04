namespace GYM.frm
{
    partial class frmReportParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportParameters));
            this.grpAction = new DevExpress.XtraEditors.GroupControl();
            this.bttView = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.grbInfor = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpAction)).BeginInit();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbInfor)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.bttView);
            this.grpAction.Controls.Add(this.bttExit);
            this.grpAction.Location = new System.Drawing.Point(12, 94);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(397, 61);
            this.grpAction.TabIndex = 5;
            this.grpAction.Text = "Chức năng";
            // 
            // bttView
            // 
            this.bttView.ImageIndex = 2;
            this.bttView.ImageList = this.imgLst;
            this.bttView.Location = new System.Drawing.Point(236, 27);
            this.bttView.Name = "bttView";
            this.bttView.Size = new System.Drawing.Size(75, 23);
            this.bttView.TabIndex = 4;
            this.bttView.Text = "Xem";
            this.bttView.Click += new System.EventHandler(this.bttView_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "report.ico");
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(317, 27);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 3;
            this.bttExit.Text = "Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // grbInfor
            // 
            this.grbInfor.Location = new System.Drawing.Point(12, 12);
            this.grbInfor.Name = "grbInfor";
            this.grbInfor.Size = new System.Drawing.Size(397, 76);
            this.grbInfor.TabIndex = 4;
            this.grbInfor.Text = "Thông tin";
            // 
            // frmReportParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 169);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grbInfor);
            this.Name = "frmReportParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmReportParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpAction)).EndInit();
            this.grpAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbInfor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpAction;
        private DevExpress.XtraEditors.GroupControl grbInfor;
        private DevExpress.XtraEditors.SimpleButton bttView;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bttExit;
    }
}