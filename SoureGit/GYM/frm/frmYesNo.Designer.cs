namespace GYM.frm
{
    partial class frmYesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYesNo));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labMsg = new DevExpress.XtraEditors.LabelControl();
            this.bttOK = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bbExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.labMsg);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(305, 60);
            this.panelControl1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labMsg
            // 
            this.labMsg.Location = new System.Drawing.Point(51, 25);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(63, 13);
            this.labMsg.TabIndex = 0;
            this.labMsg.Text = "labelControl1";
            // 
            // bttOK
            // 
            this.bttOK.ImageIndex = 0;
            this.bttOK.ImageList = this.imgLst;
            this.bttOK.Location = new System.Drawing.Point(161, 78);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(75, 23);
            this.bttOK.TabIndex = 5;
            this.bttOK.Text = "&Đồng ý";
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Ok3.ico");
            this.imgLst.Images.SetKeyName(1, "Cancel.ico");
            // 
            // bbExit
            // 
            this.bbExit.ImageIndex = 1;
            this.bbExit.ImageList = this.imgLst;
            this.bbExit.Location = new System.Drawing.Point(242, 78);
            this.bbExit.Name = "bbExit";
            this.bbExit.Size = new System.Drawing.Size(75, 23);
            this.bbExit.TabIndex = 4;
            this.bbExit.Text = "&Thoát";
            this.bbExit.Click += new System.EventHandler(this.bbExit_Click);
            // 
            // frmYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 114);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.bbExit);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận";
            this.Load += new System.EventHandler(this.frmYesNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraEditors.LabelControl labMsg;
        private DevExpress.XtraEditors.SimpleButton bttOK;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.SimpleButton bbExit;
    }
}