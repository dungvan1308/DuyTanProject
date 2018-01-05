namespace GenLienceKey
{
    partial class frmGenLienceKey
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtOutPut = new DevExpress.XtraEditors.TextEdit();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bttExit = new DevExpress.XtraEditors.SimpleButton();
            this.bttEnscrypt = new DevExpress.XtraEditors.SimpleButton();
            this.bttDeCrypt = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutPut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(604, 69);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "LienceKey";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(5, 32);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(594, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtOutPut);
            this.groupControl2.Controls.Add(this.txtInput);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 87);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(604, 181);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Enscrypt";
            // 
            // txtOutPut
            // 
            this.txtOutPut.Location = new System.Drawing.Point(81, 100);
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.Properties.AutoHeight = false;
            this.txtOutPut.Size = new System.Drawing.Size(518, 71);
            this.txtOutPut.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(81, 23);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.AutoHeight = false;
            this.txtInput.Size = new System.Drawing.Size(518, 71);
            this.txtInput.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 128);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "OutPut";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "InPut";
            // 
            // bttExit
            // 
            this.bttExit.Location = new System.Drawing.Point(541, 274);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(75, 23);
            this.bttExit.TabIndex = 2;
            this.bttExit.Text = "Exit";
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // bttEnscrypt
            // 
            this.bttEnscrypt.Location = new System.Drawing.Point(460, 274);
            this.bttEnscrypt.Name = "bttEnscrypt";
            this.bttEnscrypt.Size = new System.Drawing.Size(75, 23);
            this.bttEnscrypt.TabIndex = 3;
            this.bttEnscrypt.Text = "Enscrypt";
            this.bttEnscrypt.Click += new System.EventHandler(this.bttEnscrypt_Click);
            // 
            // bttDeCrypt
            // 
            this.bttDeCrypt.Location = new System.Drawing.Point(379, 274);
            this.bttDeCrypt.Name = "bttDeCrypt";
            this.bttDeCrypt.Size = new System.Drawing.Size(75, 23);
            this.bttDeCrypt.TabIndex = 4;
            this.bttDeCrypt.Text = "DeCrypt";
            this.bttDeCrypt.Click += new System.EventHandler(this.bttDeCrypt_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(298, 274);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 5;
            this.simpleButton4.Text = "Clean";
            // 
            // frmGenLienceKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 306);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.bttDeCrypt);
            this.Controls.Add(this.bttEnscrypt);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "frmGenLienceKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGenLienceKey";
            this.Load += new System.EventHandler(this.frmGenLienceKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutPut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtOutPut;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton bttExit;
        private DevExpress.XtraEditors.SimpleButton bttEnscrypt;
        private DevExpress.XtraEditors.SimpleButton bttDeCrypt;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}