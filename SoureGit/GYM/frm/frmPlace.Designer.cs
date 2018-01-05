namespace GYM.frm
{
    partial class frmPlace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlace));
            this.grpctrl = new DevExpress.XtraEditors.GroupControl();
            this.checkEditOfDuyTan = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtTimeDuyTan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDistanceDuyTan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpDistrict = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtGpsY = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGpsX = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlaceName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bttNext = new DevExpress.XtraEditors.SimpleButton();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.bttSave = new DevExpress.XtraEditors.SimpleButton();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpctrl)).BeginInit();
            this.grpctrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditOfDuyTan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDuyTan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistanceDuyTan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGpsY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGpsX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpctrl
            // 
            this.grpctrl.Controls.Add(this.checkEditOfDuyTan);
            this.grpctrl.Controls.Add(this.labelControl10);
            this.grpctrl.Controls.Add(this.txtTimeDuyTan);
            this.grpctrl.Controls.Add(this.labelControl9);
            this.grpctrl.Controls.Add(this.labelControl8);
            this.grpctrl.Controls.Add(this.txtDistanceDuyTan);
            this.grpctrl.Controls.Add(this.labelControl7);
            this.grpctrl.Controls.Add(this.labelControl6);
            this.grpctrl.Controls.Add(this.txtAddress);
            this.grpctrl.Controls.Add(this.labelControl5);
            this.grpctrl.Controls.Add(this.lookUpDistrict);
            this.grpctrl.Controls.Add(this.labelControl4);
            this.grpctrl.Controls.Add(this.lookUpCity);
            this.grpctrl.Controls.Add(this.txtGpsY);
            this.grpctrl.Controls.Add(this.labelControl3);
            this.grpctrl.Controls.Add(this.txtGpsX);
            this.grpctrl.Controls.Add(this.labelControl2);
            this.grpctrl.Controls.Add(this.txtPlaceName);
            this.grpctrl.Controls.Add(this.labelControl1);
            this.grpctrl.Location = new System.Drawing.Point(12, 12);
            this.grpctrl.Name = "grpctrl";
            this.grpctrl.Size = new System.Drawing.Size(390, 238);
            this.grpctrl.TabIndex = 0;
            this.grpctrl.Text = "Thông tin địa điểm";
            // 
            // checkEditOfDuyTan
            // 
            this.checkEditOfDuyTan.Location = new System.Drawing.Point(137, 213);
            this.checkEditOfDuyTan.Name = "checkEditOfDuyTan";
            this.checkEditOfDuyTan.Properties.Caption = " Thuộc Duy Tân";
            this.checkEditOfDuyTan.Size = new System.Drawing.Size(75, 19);
            this.checkEditOfDuyTan.TabIndex = 20;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(190, 190);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(22, 13);
            this.labelControl10.TabIndex = 19;
            this.labelControl10.Text = "Phút";
            // 
            // txtTimeDuyTan
            // 
            this.txtTimeDuyTan.EditValue = "";
            this.txtTimeDuyTan.Location = new System.Drawing.Point(137, 187);
            this.txtTimeDuyTan.Name = "txtTimeDuyTan";
            this.txtTimeDuyTan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTimeDuyTan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTimeDuyTan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTimeDuyTan.Properties.NullText = "Chon Tinh / TP";
            this.txtTimeDuyTan.Size = new System.Drawing.Size(47, 20);
            this.txtTimeDuyTan.TabIndex = 7;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(16, 190);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(107, 13);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "Thời gian đến Duy Tân";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(190, 164);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(14, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Km";
            // 
            // txtDistanceDuyTan
            // 
            this.txtDistanceDuyTan.Location = new System.Drawing.Point(137, 161);
            this.txtDistanceDuyTan.Name = "txtDistanceDuyTan";
            this.txtDistanceDuyTan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDistanceDuyTan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDistanceDuyTan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDistanceDuyTan.Size = new System.Drawing.Size(47, 20);
            this.txtDistanceDuyTan.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 164);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(115, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Khoản cách với Duy Tân";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 138);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Đia chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(137, 135);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(240, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Quận, huyện";
            // 
            // lookUpDistrict
            // 
            this.lookUpDistrict.Location = new System.Drawing.Point(137, 109);
            this.lookUpDistrict.Name = "lookUpDistrict";
            this.lookUpDistrict.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDistrict.Properties.NullText = "Chọn Quận, huyện";
            this.lookUpDistrict.Properties.View = this.gridView2;
            this.lookUpDistrict.Size = new System.Drawing.Size(240, 20);
            this.lookUpDistrict.TabIndex = 4;
            this.lookUpDistrict.Click += new System.EventHandler(this.lookUpDistrict_Click);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Tỉnh / TP";
            // 
            // lookUpCity
            // 
            this.lookUpCity.Location = new System.Drawing.Point(137, 83);
            this.lookUpCity.Name = "lookUpCity";
            this.lookUpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCity.Properties.NullText = "Chọn Tỉnh / TP";
            this.lookUpCity.Properties.View = this.gridView1;
            this.lookUpCity.Size = new System.Drawing.Size(240, 20);
            this.lookUpCity.TabIndex = 3;
            this.lookUpCity.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.lookUpCity_Closed);
            this.lookUpCity.Click += new System.EventHandler(this.lookUpCity_Click);
            this.lookUpCity.Leave += new System.EventHandler(this.lookUpCity_Leave);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtGpsY
            // 
            this.txtGpsY.Location = new System.Drawing.Point(277, 57);
            this.txtGpsY.Name = "txtGpsY";
            this.txtGpsY.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGpsY.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGpsY.Size = new System.Drawing.Size(100, 20);
            this.txtGpsY.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(243, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "GPS Y";
            // 
            // txtGpsX
            // 
            this.txtGpsX.Location = new System.Drawing.Point(137, 57);
            this.txtGpsX.Name = "txtGpsX";
            this.txtGpsX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGpsX.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGpsX.Size = new System.Drawing.Size(100, 20);
            this.txtGpsX.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "GPS X";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Location = new System.Drawing.Point(137, 31);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(240, 20);
            this.txtPlaceName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên địa điểm";
            // 
            // bttNext
            // 
            this.bttNext.ImageIndex = 4;
            this.bttNext.ImageList = this.imgLst;
            this.bttNext.Location = new System.Drawing.Point(198, 255);
            this.bttNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttNext.Name = "bttNext";
            this.bttNext.Size = new System.Drawing.Size(64, 19);
            this.bttNext.TabIndex = 34;
            this.bttNext.Text = "Tiếp";
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Cancel.ico");
            this.imgLst.Images.SetKeyName(1, "Find-Xp.ico");
            this.imgLst.Images.SetKeyName(2, "save.ico");
            this.imgLst.Images.SetKeyName(3, "add.ico");
            this.imgLst.Images.SetKeyName(4, "Next.ico");
            // 
            // bttSave
            // 
            this.bttSave.ImageIndex = 2;
            this.bttSave.ImageList = this.imgLst;
            this.bttSave.Location = new System.Drawing.Point(268, 255);
            this.bttSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(64, 19);
            this.bttSave.TabIndex = 33;
            this.bttSave.Text = "Lưu";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttExit
            // 
            this.bttExit.ImageIndex = 0;
            this.bttExit.ImageList = this.imgLst;
            this.bttExit.Location = new System.Drawing.Point(338, 255);
            this.bttExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(64, 19);
            this.bttExit.TabIndex = 35;
            this.bttExit.Text = "Thoát";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // frmPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 284);
            this.Controls.Add(this.bttNext);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.grpctrl);
            this.MaximizeBox = false;
            this.Name = "frmPlace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý địa điểm";
            this.Load += new System.EventHandler(this.frmPlace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpctrl)).EndInit();
            this.grpctrl.ResumeLayout(false);
            this.grpctrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditOfDuyTan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDuyTan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistanceDuyTan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGpsY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGpsX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpctrl;
        private DevExpress.XtraEditors.TextEdit txtGpsY;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtGpsX;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPlaceName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpCity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtDistanceDuyTan;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpDistrict;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton bttNext;
        private DevExpress.XtraEditors.SimpleButton bttSave;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private System.Windows.Forms.ImageList imgLst;
        private DevExpress.XtraEditors.CheckEdit checkEditOfDuyTan;
        private DevExpress.XtraEditors.TextEdit txtTimeDuyTan;
    }
}