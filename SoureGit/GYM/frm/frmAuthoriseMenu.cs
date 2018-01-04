using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.ServiceReferenceDuyTan;
using GYM.Common;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System.Collections;


namespace GYM.frm
{
    public partial class frmAuthoriseMenu : DevExpress.XtraEditors.XtraForm
    {
        public string strMode = "";
        public string strCode = "";
        Dictionary<string, TreeListNode> map = new Dictionary<string, TreeListNode>();
        public frmAuthoriseMenu()
        {
            InitializeComponent();
        }

        private void frmAuthoriseMenu_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   12/11/2015
             * Purpose  :   Load phan quyen User
             */


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                initializeTreeMenu();
                //loadGroupUser 
                ClsCommonProcess.lookUpGroupUser(lookUpGrp);
            }
            catch (Exception ex)
            {
            }
        }


        private void initializeTreeMenu()
        {
            menuTreeList.ClearNodes();
            menuTreeList.BeginUpdate();

            menuTreeList.Columns.Add();
            menuTreeList.Columns[0].Caption = "Menu name";
            menuTreeList.Columns[0].VisibleIndex = 0;

            /*menuTreeList.Columns.Add();
            menuTreeList.Columns[1].Caption = "Parent Id";
            menuTreeList.Columns[1].VisibleIndex = 1;
            */
            menuTreeList.EndUpdate();

            loadTreeData();
        }

        private void loadTreeData()
        {
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            MenuObjectList menuObjectList = new MenuObjectList();

            try
            {
                menuObjectList = ws.selectAllMenuItem();

                menuTreeList.BeginUnboundLoad();
                if (menuObjectList != null && menuObjectList.list.Length > 0)
                {
                    map.Clear();
                    for (int i = 0; i < menuObjectList.list.Length; i++)
                    {
                        //Parent 
                        MenuObject menuObject = (MenuObject)menuObjectList.list[i];
                        if (menuObject.PARENTID == null || menuObject.PARENTID == "")
                        {
                            object[] obj = new object[] { menuObject.MENUNAME };
                            TreeListNode node = menuTreeList.AppendNode(obj, null);
                            node.Tag = menuObject.MENUID;
                            map[menuObject.MENUID] = node;
                        }
                    }

                    for (int i = 0; i < menuObjectList.list.Length; i++)
                    {
                        MenuObject menuObject = (MenuObject)menuObjectList.list[i];
                        if (menuObject.PARENTID != null && menuObject.PARENTID != "")
                        {
                            //Child 
                            TreeListNode parentNode = map[menuObject.PARENTID];
                            object[] obj = new object[] { menuObject.MENUNAME };
                            TreeListNode node = menuTreeList.AppendNode(obj, parentNode);
                            node.Tag = menuObject.MENUID;
                            map[menuObject.MENUID] = node;

                            if (menuObject.AU.Trim() == "1")
                            {

                                //Add Them,Xoa,Sua
                                TreeListNode AuNode = node;
                                object[] objAdd = new object[] { "Thêm mới" };
                                TreeListNode noteAdd = menuTreeList.AppendNode(objAdd, node);
                                noteAdd.Tag = menuObject.MENUID + "ADD";

                                map[menuObject.MENUID + "ADD"] = noteAdd;

                                object[] objDel = new object[] { "Xóa" };
                                TreeListNode noteDel = menuTreeList.AppendNode(objDel, node);
                                noteDel.Tag = menuObject.MENUID + "DEL";
                                map[menuObject.MENUID + "DEL"] = noteDel;

                                object[] objUp = new object[] { "Sửa" };
                                TreeListNode noteUp = menuTreeList.AppendNode(objUp, node);
                                noteUp.Tag = menuObject.MENUID + "UPD";
                                map[menuObject.MENUID + "UPD"] = noteUp;

                                object[] objView = new object[] { "Xem" };
                                TreeListNode noteView = menuTreeList.AppendNode(objView, node);
                                noteView.Tag = menuObject.MENUID + "VIE";
                                map[menuObject.MENUID + "VIE"] = noteView;
                            }


                        }
                    }

                    menuTreeList.ExpandAll();

                }
                menuTreeList.EndUnboundLoad();
            }
            catch (Exception ex)
            {
            }
            
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             * Purpose  :   Luu thong tin phan quyen 
             */

            bool bConfirm = false;

            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);

            if (bConfirm != true)
            {
                return;
            }

            String userGroupId = "";
            try
            {
                userGroupId = lookUpGrp.EditValue.ToString();
            }
            catch (Exception ex)
            {
                
            }
            if (userGroupId == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_GROUP_USER_EMPTY);
                lookUpGrp.Focus();
                return;
            }
            ArrayList selectedMenuItems = getSelectedMenuItems();
            AuthorizeMenuObjectList authorizeMenuObjectList = new AuthorizeMenuObjectList();
            authorizeMenuObjectList.USERGROUPID = userGroupId;
            authorizeMenuObjectList.menuIdList = selectedMenuItems.ToArray();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            bool result = ws.updateAuthorizeMenu(authorizeMenuObjectList);
            if (result)
            {
                ClsCommonProcess.msg(ClsParameter.MSG_UPDATE_SUCCESSFULL);
            }
            else
            {
                ClsCommonProcess.msg(ClsParameter.MSG_UPDATE_FAIL);
            }
        }

        private ArrayList getSelectedMenuItems()
        {
            /*
             * Dungnv : 12/11/2015
             */
 
            ArrayList selectedMenuItems = new ArrayList();
            GetCheckedNodesOperation op = new GetCheckedNodesOperation();
            menuTreeList.NodesIterator.DoOperation(op);
            for (int i = 0; i < op.CheckedNodes.Count; i++)
            {
                selectedMenuItems.Add(op.CheckedNodes[i].Tag);
            }

            return selectedMenuItems;
        }

        private void lookUpGrp_Click(object sender, EventArgs e)
        {
            /*
            * Dungnv   :   23/10/2014
            * Purpose  :   Change Text 
            */

            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void menuTreeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            /*
             * Dungnv   :   19/11/2015
             * Purpose  :   Xu ly Check
             */
 
            TreeListNode node = e.Node;
            if (node != null)
            {
                if (!node.HasChildren && node.Checked == true && node.ParentNode != null)
                {
                    node.ParentNode.Checked = true;
                }
            }         
        }

        public void deselectAllTree()
        {
            /*
             * Dungnv   :   19/11/2015
             * Purpose  :   Xu ly chon all
             */ 

            menuTreeList.BeginUpdate();
            foreach (KeyValuePair<string, TreeListNode> node in map)
            {
                node.Value.CheckState = CheckState.Unchecked;
            }
            menuTreeList.EndUpdate();
        }

        private void lookUpGrp_EditValueChanged(object sender, EventArgs e)
        {
            /*
             *  Dungnv  :   19/11/2015
             *  Purpose :   Xu ly khi chon Nhom phan quyen
             */
  
            try
            {
                deselectAllTree();
                string userGroupId = lookUpGrp.EditValue.ToString();
                if (!ClsCommonProcess.isEmpty(userGroupId))
                {
                    WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
                    AuthorizeMenuObjectList authorizedMenuList = ws.getAuthorizeMenus(userGroupId);
                    if (authorizedMenuList != null && authorizedMenuList.menuIdList.Length > 0)
                    {
                        menuTreeList.BeginUpdate();
                        for (int i = 0; i < authorizedMenuList.menuIdList.Length; i++)
                        {
                            string menuid = (string)authorizedMenuList.menuIdList[i];
                            TreeListNode node = map[menuid];
                            if (node != null)
                            {
                                node.CheckState = CheckState.Checked;
                            }
                        }
                        menuTreeList.EndUpdate();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             */
            this.Close();
        }
    }

    class GetCheckedNodesOperation : TreeListOperation
    {
        /*
         * Dungnv : 12/11/2015
         */

        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
        public GetCheckedNodesOperation() : base() { }
        public override void Execute(TreeListNode node)
        {
            if (node.CheckState != CheckState.Unchecked)
                CheckedNodes.Add(node);
        }
    }
}