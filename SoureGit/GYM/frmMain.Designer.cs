namespace GYM
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barManager = new DevExpress.XtraBars.Bar();
            this.barSubItem_System = new DevExpress.XtraBars.BarSubItem();
            this.barBttItem_ChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.barBttParameter = new DevExpress.XtraBars.BarButtonItem();
            this.barBttItem_Backup = new DevExpress.XtraBars.BarButtonItem();
            this.barBttItem_Restore = new DevExpress.XtraBars.BarButtonItem();
            this.barBttItem_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Manage = new DevExpress.XtraBars.BarSubItem();
            this.barBttItem_User = new DevExpress.XtraBars.BarButtonItem();
            this.barbttItem_Employee = new DevExpress.XtraBars.BarButtonItem();
            this.barBttItem_Report = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.barItem_ImageUser = new DevExpress.XtraBars.BarButtonItem();
            this.barItem_UserLogin = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgLstMain = new System.Windows.Forms.ImageList(this.components);
            this.barSubItem_ChangPass = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem_User = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem_Employee = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem_Customer = new DevExpress.XtraBars.BarSubItem();
            this.barSub_Users = new DevExpress.XtraBars.BarStaticItem();
            this.barbttItem_Customer = new DevExpress.XtraBars.BarButtonItem();
            this.barbttItem_Product = new DevExpress.XtraBars.BarButtonItem();
            this.barbttItem_Contract = new DevExpress.XtraBars.BarButtonItem();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGrp_User = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_GroupUser = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_User = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Authorise = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_SetPass = new DevExpress.XtraNavBar.NavBarItem();
            this.nvBarItem_LoginLog = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Management = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_Employee = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Place = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_TeamTruck = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupJourney = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemRegJourney = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemAll = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemTeam = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Stock = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_MIC = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_Search = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Report = new DevExpress.XtraNavBar.NavBarItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barManager,
            this.barStatus});
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Images = this.imgLstMain;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem_System,
            this.barSubItem_Manage,
            this.barSubItem_ChangPass,
            this.barSubItem_User,
            this.barSubItem_Employee,
            this.barSubItem_Customer,
            this.barItem_ImageUser,
            this.barItem_UserLogin,
            this.barBttItem_ChangePass,
            this.barBttItem_Backup,
            this.barBttItem_Restore,
            this.barBttItem_Exit,
            this.barSub_Users,
            this.barBttItem_User,
            this.barbttItem_Employee,
            this.barbttItem_Customer,
            this.barBttItem_Report,
            this.barbttItem_Product,
            this.barbttItem_Contract,
            this.barBttParameter});
            this.barManagerMain.LargeImages = this.imgLstMain;
            this.barManagerMain.MainMenu = this.barManager;
            this.barManagerMain.MaxItemId = 23;
            this.barManagerMain.StatusBar = this.barStatus;
            // 
            // barManager
            // 
            this.barManager.BarName = "Main menu";
            this.barManager.DockCol = 0;
            this.barManager.DockRow = 0;
            this.barManager.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barManager.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_System),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Manage)});
            this.barManager.OptionsBar.MultiLine = true;
            this.barManager.OptionsBar.UseWholeRow = true;
            this.barManager.Text = "Main menu";
            // 
            // barSubItem_System
            // 
            this.barSubItem_System.Caption = "Hệ Thống";
            this.barSubItem_System.Id = 0;
            this.barSubItem_System.ImageIndex = 18;
            this.barSubItem_System.LargeImageIndex = 0;
            this.barSubItem_System.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttItem_ChangePass),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttParameter),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttItem_Backup),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.barBttItem_Restore, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttItem_Exit)});
            this.barSubItem_System.Name = "barSubItem_System";
            this.barSubItem_System.Tag = "MN0100";
            // 
            // barBttItem_ChangePass
            // 
            this.barBttItem_ChangePass.Caption = "Đổi mật khẩu";
            this.barBttItem_ChangePass.Id = 11;
            this.barBttItem_ChangePass.ImageIndex = 5;
            this.barBttItem_ChangePass.Name = "barBttItem_ChangePass";
            this.barBttItem_ChangePass.Tag = "MN0101";
            this.barBttItem_ChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_ChangePass_ItemClick);
            // 
            // barBttParameter
            // 
            this.barBttParameter.Caption = "Tham số hệ thống";
            this.barBttParameter.Id = 22;
            this.barBttParameter.ImageIndex = 9;
            this.barBttParameter.Name = "barBttParameter";
            // 
            // barBttItem_Backup
            // 
            this.barBttItem_Backup.Caption = "Sao lưu dữ liệu";
            this.barBttItem_Backup.Id = 12;
            this.barBttItem_Backup.ImageIndex = 17;
            this.barBttItem_Backup.Name = "barBttItem_Backup";
            this.barBttItem_Backup.Tag = "MN0102";
            this.barBttItem_Backup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_Backup_ItemClick);
            // 
            // barBttItem_Restore
            // 
            this.barBttItem_Restore.Caption = "Khôi phục dữ liệu";
            this.barBttItem_Restore.Id = 13;
            this.barBttItem_Restore.ImageIndex = 0;
            this.barBttItem_Restore.Name = "barBttItem_Restore";
            this.barBttItem_Restore.Tag = "MN0103";
            this.barBttItem_Restore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_Restore_ItemClick);
            // 
            // barBttItem_Exit
            // 
            this.barBttItem_Exit.Caption = "Thoát";
            this.barBttItem_Exit.Id = 14;
            this.barBttItem_Exit.ImageIndex = 19;
            this.barBttItem_Exit.Name = "barBttItem_Exit";
            this.barBttItem_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_Exit_ItemClick);
            // 
            // barSubItem_Manage
            // 
            this.barSubItem_Manage.Caption = "Quản lý";
            this.barSubItem_Manage.Id = 1;
            this.barSubItem_Manage.ImageIndex = 20;
            this.barSubItem_Manage.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttItem_User),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbttItem_Employee),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBttItem_Report)});
            this.barSubItem_Manage.Name = "barSubItem_Manage";
            this.barSubItem_Manage.Tag = "MN0000";
            // 
            // barBttItem_User
            // 
            this.barBttItem_User.Caption = "Người dùng";
            this.barBttItem_User.Id = 16;
            this.barBttItem_User.ImageIndex = 8;
            this.barBttItem_User.Name = "barBttItem_User";
            this.barBttItem_User.Tag = "TL0002";
            this.barBttItem_User.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_User_ItemClick);
            // 
            // barbttItem_Employee
            // 
            this.barbttItem_Employee.Caption = "Nhân viên";
            this.barbttItem_Employee.Id = 17;
            this.barbttItem_Employee.ImageIndex = 14;
            this.barbttItem_Employee.Name = "barbttItem_Employee";
            this.barbttItem_Employee.Tag = "TL0101";
            this.barbttItem_Employee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbttItem_Employee_ItemClick);
            // 
            // barBttItem_Report
            // 
            this.barBttItem_Report.Caption = "Báo cáo";
            this.barBttItem_Report.Id = 19;
            this.barBttItem_Report.ImageIndex = 10;
            this.barBttItem_Report.Name = "barBttItem_Report";
            this.barBttItem_Report.Tag = "MN0006";
            this.barBttItem_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBttItem_Report_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_ImageUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItem_UserLogin)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // barItem_ImageUser
            // 
            this.barItem_ImageUser.Caption = "Người dùng";
            this.barItem_ImageUser.Id = 9;
            this.barItem_ImageUser.ImageIndex = 24;
            this.barItem_ImageUser.Name = "barItem_ImageUser";
            // 
            // barItem_UserLogin
            // 
            this.barItem_UserLogin.Caption = "UserLogin";
            this.barItem_UserLogin.Id = 10;
            this.barItem_UserLogin.Name = "barItem_UserLogin";
            this.barItem_UserLogin.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(801, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 387);
            this.barDockControlBottom.Size = new System.Drawing.Size(801, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 365);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(801, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 365);
            // 
            // imgLstMain
            // 
            this.imgLstMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstMain.ImageStream")));
            this.imgLstMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstMain.Images.SetKeyName(0, "48px-Crystal_Clear_app_artscontrol.png");
            this.imgLstMain.Images.SetKeyName(1, "Cancel.ico");
            this.imgLstMain.Images.SetKeyName(2, "DeleteXP.ico");
            this.imgLstMain.Images.SetKeyName(3, "HelpXP.ico");
            this.imgLstMain.Images.SetKeyName(4, "info.ico");
            this.imgLstMain.Images.SetKeyName(5, "Key manager.ico");
            this.imgLstMain.Images.SetKeyName(6, "key.ico");
            this.imgLstMain.Images.SetKeyName(7, "lock.ico");
            this.imgLstMain.Images.SetKeyName(8, "LogOff - Copy.ico");
            this.imgLstMain.Images.SetKeyName(9, "red star.ico");
            this.imgLstMain.Images.SetKeyName(10, "report.ico");
            this.imgLstMain.Images.SetKeyName(11, "task list.ico");
            this.imgLstMain.Images.SetKeyName(12, "unlock.ico");
            this.imgLstMain.Images.SetKeyName(13, "user group.ico");
            this.imgLstMain.Images.SetKeyName(14, "user.ico");
            this.imgLstMain.Images.SetKeyName(15, "users.ico");
            this.imgLstMain.Images.SetKeyName(16, "UserXP.ico");
            this.imgLstMain.Images.SetKeyName(17, "database.ico");
            this.imgLstMain.Images.SetKeyName(18, "gear.ico");
            this.imgLstMain.Images.SetKeyName(19, "exit.ico");
            this.imgLstMain.Images.SetKeyName(20, "application form.ico");
            this.imgLstMain.Images.SetKeyName(21, "computer.ico");
            this.imgLstMain.Images.SetKeyName(22, "coins.ico");
            this.imgLstMain.Images.SetKeyName(23, "conference.ico");
            this.imgLstMain.Images.SetKeyName(24, "Profile.ico");
            this.imgLstMain.Images.SetKeyName(25, "service.ico");
            this.imgLstMain.Images.SetKeyName(26, "red star.ico");
            this.imgLstMain.Images.SetKeyName(27, "add.ico");
            this.imgLstMain.Images.SetKeyName(28, "add to basket.ico");
            this.imgLstMain.Images.SetKeyName(29, "handshake.ico");
            this.imgLstMain.Images.SetKeyName(30, "fingerprint_reader_icon.jpg");
            this.imgLstMain.Images.SetKeyName(31, "FingerPrint2.jpg");
            this.imgLstMain.Images.SetKeyName(32, "Run.ico");
            this.imgLstMain.Images.SetKeyName(33, "task list.ico");
            this.imgLstMain.Images.SetKeyName(34, "tank_truck.png");
            this.imgLstMain.Images.SetKeyName(35, "peace.ico");
            this.imgLstMain.Images.SetKeyName(36, "monitor.ico");
            this.imgLstMain.Images.SetKeyName(37, "Find-Xp.ico");
            // 
            // barSubItem_ChangPass
            // 
            this.barSubItem_ChangPass.Caption = "Đổi mật khẩu";
            this.barSubItem_ChangPass.Id = 2;
            this.barSubItem_ChangPass.ImageIndex = 5;
            this.barSubItem_ChangPass.Name = "barSubItem_ChangPass";
            // 
            // barSubItem_User
            // 
            this.barSubItem_User.Caption = "Người dùng";
            this.barSubItem_User.Id = 6;
            this.barSubItem_User.ImageIndex = 14;
            this.barSubItem_User.Name = "barSubItem_User";
            // 
            // barSubItem_Employee
            // 
            this.barSubItem_Employee.Caption = "Nhân viên";
            this.barSubItem_Employee.Id = 7;
            this.barSubItem_Employee.ImageIndex = 15;
            this.barSubItem_Employee.Name = "barSubItem_Employee";
            // 
            // barSubItem_Customer
            // 
            this.barSubItem_Customer.Caption = "Khách hàng";
            this.barSubItem_Customer.Id = 8;
            this.barSubItem_Customer.ImageIndex = 13;
            this.barSubItem_Customer.Name = "barSubItem_Customer";
            // 
            // barSub_Users
            // 
            this.barSub_Users.Caption = "Khách hàng";
            this.barSub_Users.Id = 15;
            this.barSub_Users.ImageIndexDisabled = 14;
            this.barSub_Users.Name = "barSub_Users";
            this.barSub_Users.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barbttItem_Customer
            // 
            this.barbttItem_Customer.Caption = "Khách hàng";
            this.barbttItem_Customer.Id = 18;
            this.barbttItem_Customer.ImageIndex = 23;
            this.barbttItem_Customer.Name = "barbttItem_Customer";
            this.barbttItem_Customer.Tag = "TL0303";
            this.barbttItem_Customer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbttItem_Customer_ItemClick);
            // 
            // barbttItem_Product
            // 
            this.barbttItem_Product.Caption = "Sản phẩm";
            this.barbttItem_Product.Id = 20;
            this.barbttItem_Product.ImageIndex = 28;
            this.barbttItem_Product.Name = "barbttItem_Product";
            this.barbttItem_Product.Tag = "TL0402";
            this.barbttItem_Product.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbttItem_Product_ItemClick);
            // 
            // barbttItem_Contract
            // 
            this.barbttItem_Contract.Caption = "Hợp đồng";
            this.barbttItem_Contract.Id = 21;
            this.barbttItem_Contract.ImageIndex = 29;
            this.barbttItem_Contract.Name = "barbttItem_Contract";
            this.barbttItem_Contract.Tag = "TL0502";
            this.barbttItem_Contract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbttItem_Contract_ItemClick);
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navBarGrp_User;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGrp_User,
            this.navBarGroup_Management,
            this.navBarGroupJourney,
            this.navBarGroup_MIC});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_GroupUser,
            this.navBarItem_User,
            this.navBarItem_Authorise,
            this.navBarItem_Employee,
            this.navBarItem_Place,
            this.navBarItem_SetPass,
            this.nvBarItem_LoginLog,
            this.navBarItemRegJourney,
            this.navBarItemAll,
            this.navBarItemTeam,
            this.navBarItem_Stock,
            this.navBarItem_TeamTruck,
            this.navBarItem_Search,
            this.navBarItem_Report});
            this.navBarControl.Location = new System.Drawing.Point(0, 22);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 198;
            this.navBarControl.Size = new System.Drawing.Size(198, 365);
            this.navBarControl.SmallImages = this.imgLstMain;
            this.navBarControl.TabIndex = 4;
            // 
            // navBarGrp_User
            // 
            this.navBarGrp_User.Caption = "Người dùng";
            this.navBarGrp_User.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_GroupUser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_User),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Authorise),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_SetPass),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvBarItem_LoginLog)});
            this.navBarGrp_User.Name = "navBarGrp_User";
            this.navBarGrp_User.SmallImageIndex = 8;
            this.navBarGrp_User.Tag = "TL0000";
            // 
            // navBarItem_GroupUser
            // 
            this.navBarItem_GroupUser.Caption = "Nhóm người dùng";
            this.navBarItem_GroupUser.Name = "navBarItem_GroupUser";
            this.navBarItem_GroupUser.SmallImageIndex = 16;
            this.navBarItem_GroupUser.Tag = "TL0001";
            this.navBarItem_GroupUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_GroupUser_LinkClicked);
            // 
            // navBarItem_User
            // 
            this.navBarItem_User.Caption = "Người dùng";
            this.navBarItem_User.Name = "navBarItem_User";
            this.navBarItem_User.SmallImageIndex = 14;
            this.navBarItem_User.Tag = "TL0002";
            this.navBarItem_User.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_User_LinkClicked);
            // 
            // navBarItem_Authorise
            // 
            this.navBarItem_Authorise.Caption = "Phân quyền";
            this.navBarItem_Authorise.Name = "navBarItem_Authorise";
            this.navBarItem_Authorise.SmallImageIndex = 21;
            this.navBarItem_Authorise.Tag = "TL0003";
            this.navBarItem_Authorise.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Authorise_LinkClicked);
            // 
            // navBarItem_SetPass
            // 
            this.navBarItem_SetPass.Caption = "Thiết lập mật khẩu";
            this.navBarItem_SetPass.Name = "navBarItem_SetPass";
            this.navBarItem_SetPass.SmallImageIndex = 5;
            this.navBarItem_SetPass.Tag = "TL0004";
            this.navBarItem_SetPass.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_SetPass_LinkClicked);
            // 
            // nvBarItem_LoginLog
            // 
            this.nvBarItem_LoginLog.Caption = "Đang làm việc";
            this.nvBarItem_LoginLog.Name = "nvBarItem_LoginLog";
            this.nvBarItem_LoginLog.SmallImageIndex = 32;
            this.nvBarItem_LoginLog.Tag = "TL0005";
            this.nvBarItem_LoginLog.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvBarItem_LoginLog_LinkClicked);
            // 
            // navBarGroup_Management
            // 
            this.navBarGroup_Management.Caption = "Quản lý";
            this.navBarGroup_Management.Expanded = true;
            this.navBarGroup_Management.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Employee),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Place),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_TeamTruck)});
            this.navBarGroup_Management.Name = "navBarGroup_Management";
            this.navBarGroup_Management.SmallImageIndex = 14;
            this.navBarGroup_Management.Tag = "TL0100";
            // 
            // navBarItem_Employee
            // 
            this.navBarItem_Employee.Caption = "Nhân viên";
            this.navBarItem_Employee.Name = "navBarItem_Employee";
            this.navBarItem_Employee.SmallImageIndex = 14;
            this.navBarItem_Employee.Tag = "TL0101";
            this.navBarItem_Employee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Employee_LinkClicked);
            // 
            // navBarItem_Place
            // 
            this.navBarItem_Place.Caption = "Địa điểm";
            this.navBarItem_Place.Name = "navBarItem_Place";
            this.navBarItem_Place.SmallImageIndex = 22;
            this.navBarItem_Place.Tag = "TL0102";
            this.navBarItem_Place.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Place_LinkClicked);
            // 
            // navBarItem_TeamTruck
            // 
            this.navBarItem_TeamTruck.Caption = "Danh sách xe";
            this.navBarItem_TeamTruck.Name = "navBarItem_TeamTruck";
            this.navBarItem_TeamTruck.SmallImageIndex = 0;
            this.navBarItem_TeamTruck.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_TeamTruck_LinkClicked);
            // 
            // navBarGroupJourney
            // 
            this.navBarGroupJourney.Caption = "Thông tin hành trình Xe";
            this.navBarGroupJourney.Expanded = true;
            this.navBarGroupJourney.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemRegJourney),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAll),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemTeam),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Stock)});
            this.navBarGroupJourney.Name = "navBarGroupJourney";
            this.navBarGroupJourney.SmallImageIndex = 34;
            // 
            // navBarItemRegJourney
            // 
            this.navBarItemRegJourney.Caption = "Điều độ xe";
            this.navBarItemRegJourney.Name = "navBarItemRegJourney";
            this.navBarItemRegJourney.SmallImageIndex = 27;
            this.navBarItemRegJourney.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemRegJourney_LinkClicked);
            // 
            // navBarItemAll
            // 
            this.navBarItemAll.Caption = "Màn hình tổng hợp";
            this.navBarItemAll.Name = "navBarItemAll";
            this.navBarItemAll.SmallImageIndex = 4;
            this.navBarItemAll.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAll_LinkClicked);
            // 
            // navBarItemTeam
            // 
            this.navBarItemTeam.Caption = "Màn hình đội xe";
            this.navBarItemTeam.Name = "navBarItemTeam";
            this.navBarItemTeam.SmallImageIndex = 30;
            this.navBarItemTeam.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemTeam_LinkClicked);
            // 
            // navBarItem_Stock
            // 
            this.navBarItem_Stock.Caption = "Màn hình kho";
            this.navBarItem_Stock.Name = "navBarItem_Stock";
            this.navBarItem_Stock.SmallImageIndex = 28;
            this.navBarItem_Stock.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Stock_LinkClicked);
            // 
            // navBarGroup_MIC
            // 
            this.navBarGroup_MIC.Caption = "Quản trị";
            this.navBarGroup_MIC.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Search),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Report)});
            this.navBarGroup_MIC.Name = "navBarGroup_MIC";
            this.navBarGroup_MIC.SmallImageIndex = 36;
            // 
            // navBarItem_Search
            // 
            this.navBarItem_Search.Caption = "Tra cứu";
            this.navBarItem_Search.Name = "navBarItem_Search";
            this.navBarItem_Search.SmallImageIndex = 37;
            // 
            // navBarItem_Report
            // 
            this.navBarItem_Report.Caption = "Báo cáo";
            this.navBarItem_Report.Name = "navBarItem_Report";
            this.navBarItem_Report.SmallImageIndex = 10;
            // 
            // splitterControl1
            // 
            this.splitterControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitterControl1.Location = new System.Drawing.Point(198, 22);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 365);
            this.splitterControl1.TabIndex = 9;
            this.splitterControl1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 414);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đội xe Duy Tân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar barManager;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup navBarGrp_User;
        private DevExpress.XtraBars.BarSubItem barSubItem_System;
        private DevExpress.XtraBars.BarSubItem barSubItem_ChangPass;
        private DevExpress.XtraBars.BarSubItem barSubItem_Manage;
        private System.Windows.Forms.ImageList imgLstMain;
        private DevExpress.XtraBars.BarSubItem barSubItem_User;
        private DevExpress.XtraBars.BarSubItem barSubItem_Employee;
        private DevExpress.XtraBars.BarSubItem barSubItem_Customer;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_GroupUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_User;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Authorise;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Management;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Employee;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Place;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.BarButtonItem barItem_ImageUser;
        private DevExpress.XtraBars.BarStaticItem barItem_UserLogin;
        private DevExpress.XtraBars.BarButtonItem barBttItem_ChangePass;
        private DevExpress.XtraBars.BarButtonItem barBttItem_Backup;
        private DevExpress.XtraBars.BarButtonItem barBttItem_Restore;
        private DevExpress.XtraBars.BarButtonItem barBttItem_Exit;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_SetPass;
        private DevExpress.XtraBars.BarButtonItem barbttItem_Employee;
        private DevExpress.XtraBars.BarButtonItem barbttItem_Customer;
        private DevExpress.XtraBars.BarStaticItem barSub_Users;
        private DevExpress.XtraBars.BarButtonItem barBttItem_Report;
        private DevExpress.XtraBars.BarButtonItem barbttItem_Product;
        private DevExpress.XtraBars.BarButtonItem barbttItem_Contract;
        private DevExpress.XtraNavBar.NavBarItem nvBarItem_LoginLog;
        private DevExpress.XtraBars.BarButtonItem barBttItem_User;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupJourney;
        private DevExpress.XtraNavBar.NavBarItem navBarItemRegJourney;
        private DevExpress.XtraBars.BarButtonItem barBttParameter;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_MIC;
        private DevExpress.XtraNavBar.NavBarItem navBarItemAll;
        private DevExpress.XtraNavBar.NavBarItem navBarItemTeam;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Stock;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_TeamTruck;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Search;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Report;
    }
}