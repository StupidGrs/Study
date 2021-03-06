﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps_MDDS.ExternalClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public partial class External
    {
        
        #region Properties
        public wExternal wExternal
        {
            get
            {
                if ((this.mwExternal == null))
                {
                    this.mwExternal = new wExternal();
                }
                return this.mwExternal;
            }
        }
        #endregion
        
        #region Fields
        private wExternal mwExternal;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wExternal : BrowserWindow
    {
        
        public wExternal()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Admin - Users - External";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }
        
        #region Properties
        public pExternal pExternal
        {
            get
            {
                if ((this.mpExternal == null))
                {
                    this.mpExternal = new pExternal(this);
                }
                return this.mpExternal;
            }
        }
        
        public pExternalStep2 pExternalStep2
        {
            get
            {
                if ((this.mpExternalStep2 == null))
                {
                    this.mpExternalStep2 = new pExternalStep2(this);
                }
                return this.mpExternalStep2;
            }
        }
        
        public pExternalModify pExternalModify
        {
            get
            {
                if ((this.mpExternalModify == null))
                {
                    this.mpExternalModify = new pExternalModify(this);
                }
                return this.mpExternalModify;
            }
        }
        #endregion
        
        #region Fields
        private pExternal mpExternal;
        
        private pExternalStep2 mpExternalStep2;
        
        private pExternalModify mpExternalModify;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class pExternal : HtmlDocument
    {
        
        public pExternal(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = "Body";
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Admin - Users - External";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/DDSUS10LB/DDS/Administration/UserInformation/External/tabid/281/Default.aspx";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Administration/UserInformation/External/ta" +
                "bid/281/Default.aspx";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        #region Properties
        public HtmlInputButton btnAddUser
        {
            get
            {
                if ((this.mbtnAddUser == null))
                {
                    this.mbtnAddUser = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnAddUser.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_ExternalUser_imgbtnAdd";
                    this.mbtnAddUser.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$ExternalUser$imgbtnAdd";
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnAddUser.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/DesktopModules/DDS_Users/Images/useradd.GI" +
                        "F";
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.Title] = "Add new user";
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_square";
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"TEXT-ALIGN: center; BORDER-RIGHT-";
                    this.mbtnAddUser.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "42";
                    this.mbtnAddUser.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnAddUser;
            }
        }
        
        public HtmlInputButton btnRemoveUser
        {
            get
            {
                if ((this.mbtnRemoveUser == null))
                {
                    this.mbtnRemoveUser = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnRemoveUser.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_ExternalUser_imgbtnRemove";
                    this.mbtnRemoveUser.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$ExternalUser$imgbtnRemove";
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnRemoveUser.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/DesktopModules/DDS_Users/Images/userremove" +
                        ".GIF";
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.Title] = "Remove selected user";
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_square";
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnRemoveUser.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "43";
                    this.mbtnRemoveUser.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnRemoveUser;
            }
        }
        
        public HtmlInputButton btnModifyUser
        {
            get
            {
                if ((this.mbtnModifyUser == null))
                {
                    this.mbtnModifyUser = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnModifyUser.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_ExternalUser_imgbtnModify";
                    this.mbtnModifyUser.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$ExternalUser$imgbtnModify";
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnModifyUser.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/DesktopModules/DDS_Users/Images/useredit.G" +
                        "IF";
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.Title] = "Modify selected user";
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_square";
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnModifyUser.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "44";
                    this.mbtnModifyUser.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnModifyUser;
            }
        }
        
        public pnPane pnPane
        {
            get
            {
                if ((this.mpnPane == null))
                {
                    this.mpnPane = new pnPane(this);
                }
                return this.mpnPane;
            }
        }
        
        public HtmlInputButton btnConfirmUserRemove_OK
        {
            get
            {
                if ((this.mbtnConfirmUserRemove_OK == null))
                {
                    this.mbtnConfirmUserRemove_OK = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnConfirmUserRemove_OK.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_ExternalUser_cfDelete_imgbtnOK";
                    this.mbtnConfirmUserRemove_OK.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$ExternalUser$cfDelete$imgbtnOK";
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnConfirmUserRemove_OK.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/OK.gif";
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnConfirmUserRemove_OK.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "47";
                    this.mbtnConfirmUserRemove_OK.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnConfirmUserRemove_OK;
            }
        }
        
        public HtmlInputButton btnConfirmUserRemove_Cancel
        {
            get
            {
                if ((this.mbtnConfirmUserRemove_Cancel == null))
                {
                    this.mbtnConfirmUserRemove_Cancel = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnConfirmUserRemove_Cancel.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_ExternalUser_cfDelete_imgbtnCancel";
                    this.mbtnConfirmUserRemove_Cancel.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$ExternalUser$cfDelete$imgbtnCancel";
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/Cancel.gif";
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnConfirmUserRemove_Cancel.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "46";
                    this.mbtnConfirmUserRemove_Cancel.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnConfirmUserRemove_Cancel;
            }
        }
        #endregion
        
        #region Fields
        private HtmlInputButton mbtnAddUser;
        
        private HtmlInputButton mbtnRemoveUser;
        
        private HtmlInputButton mbtnModifyUser;
        
        private pnPane mpnPane;
        
        private HtmlInputButton mbtnConfirmUserRemove_OK;
        
        private HtmlInputButton mbtnConfirmUserRemove_Cancel;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class pnPane : HtmlDiv
    {
        
        public pnPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "dnn_ctr734_ModuleContent";
            this.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "     \r\n\r\nExternal Web User Details\r\nDisp";
            this.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.Class] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=dnn_ctr734_ModuleContent";
            this.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "20";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        #region Properties
        public tblUsers tblUsers
        {
            get
            {
                if ((this.mtblUsers == null))
                {
                    this.mtblUsers = new tblUsers(this);
                }
                return this.mtblUsers;
            }
        }
        #endregion
        
        #region Fields
        private tblUsers mtblUsers;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class tblUsers : HtmlTable
    {
        
        public tblUsers(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlTable.PropertyNames.Id] = null;
            this.SearchProperties[HtmlTable.PropertyNames.Name] = null;
            this.FilterProperties[HtmlTable.PropertyNames.InnerText] = "Augustus (IM) Yeo augustusyeo@gmail.com ";
            this.FilterProperties[HtmlTable.PropertyNames.ControlDefinition] = "width=\"100%\"";
            this.FilterProperties[HtmlTable.PropertyNames.RowCount] = "9";
            this.FilterProperties[HtmlTable.PropertyNames.ColumnCount] = "4";
            this.FilterProperties[HtmlTable.PropertyNames.Class] = null;
            this.FilterProperties[HtmlTable.PropertyNames.TagInstance] = "17";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        #region Properties
        public HtmlCell UIHaskinsMichelleCell
        {
            get
            {
                if ((this.mUIHaskinsMichelleCell == null))
                {
                    this.mUIHaskinsMichelleCell = new HtmlCell(this);
                    #region Search Criteria
                    this.mUIHaskinsMichelleCell.SearchProperties[HtmlCell.PropertyNames.Id] = null;
                    this.mUIHaskinsMichelleCell.SearchProperties[HtmlCell.PropertyNames.Name] = null;
                    this.mUIHaskinsMichelleCell.SearchProperties[HtmlCell.PropertyNames.MaxDepth] = "3";
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.InnerText] = "Haskins Michelle ";
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.ControlDefinition] = "style=\"WIDTH: 122px\"";
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.RowIndex] = "2";
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.ColumnIndex] = "0";
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.Class] = null;
                    this.mUIHaskinsMichelleCell.FilterProperties[HtmlCell.PropertyNames.TagInstance] = "9";
                    this.mUIHaskinsMichelleCell.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mUIHaskinsMichelleCell;
            }
        }
        #endregion
        
        #region Fields
        private HtmlCell mUIHaskinsMichelleCell;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class pExternalStep2 : HtmlDocument
    {
        
        public pExternalStep2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = "Body";
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Admin - Users - External";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/DDSUS10LB/DDS/Administration/UserInformation/External/tabid/281/ctl/AddExternalU" +
                "ser/mid/734/Default.aspx";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Administration/UserInformation/External/ta" +
                "bid/281/ctl/AddExternalUser/mid/734/Default.aspx";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        #region Properties
        public HtmlEdit txtFirstName
        {
            get
            {
                if ((this.mtxtFirstName == null))
                {
                    this.mtxtFirstName = new HtmlEdit(this);
                    #region Search Criteria
                    this.mtxtFirstName.SearchProperties[HtmlEdit.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_tbxFirstName";
                    this.mtxtFirstName.SearchProperties[HtmlEdit.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$tbxFirstName";
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "style=\"POSITION: relative; WIDTH: 96%\" i";
                    this.mtxtFirstName.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "12";
                    this.mtxtFirstName.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mtxtFirstName;
            }
        }
        
        public HtmlEdit txtLastName
        {
            get
            {
                if ((this.mtxtLastName == null))
                {
                    this.mtxtLastName = new HtmlEdit(this);
                    #region Search Criteria
                    this.mtxtLastName.SearchProperties[HtmlEdit.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_tbxLastName";
                    this.mtxtLastName.SearchProperties[HtmlEdit.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$tbxLastName";
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "style=\"POSITION: relative; WIDTH: 94%; T";
                    this.mtxtLastName.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "13";
                    this.mtxtLastName.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mtxtLastName;
            }
        }
        
        public HtmlEdit txtEmailAddress
        {
            get
            {
                if ((this.mtxtEmailAddress == null))
                {
                    this.mtxtEmailAddress = new HtmlEdit(this);
                    #region Search Criteria
                    this.mtxtEmailAddress.SearchProperties[HtmlEdit.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_tbxEmail";
                    this.mtxtEmailAddress.SearchProperties[HtmlEdit.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$tbxEmail";
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "style=\"POSITION: relative; WIDTH: 96%\" i";
                    this.mtxtEmailAddress.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "14";
                    this.mtxtEmailAddress.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mtxtEmailAddress;
            }
        }
        
        public HtmlEdit txtCompanyName
        {
            get
            {
                if ((this.mtxtCompanyName == null))
                {
                    this.mtxtCompanyName = new HtmlEdit(this);
                    #region Search Criteria
                    this.mtxtCompanyName.SearchProperties[HtmlEdit.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_tbxCompany";
                    this.mtxtCompanyName.SearchProperties[HtmlEdit.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$tbxCompany";
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "style=\"POSITION: relative; WIDTH: 96%\" i";
                    this.mtxtCompanyName.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "15";
                    this.mtxtCompanyName.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mtxtCompanyName;
            }
        }
        
        public HtmlCheckBox UIIsuzuNorthAmericaCorCheckBox
        {
            get
            {
                if ((this.mUIIsuzuNorthAmericaCorCheckBox == null))
                {
                    this.mUIIsuzuNorthAmericaCorCheckBox = new HtmlCheckBox(this);
                    #region Search Criteria
                    this.mUIIsuzuNorthAmericaCorCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_cblClientSchemes_0";
                    this.mUIIsuzuNorthAmericaCorCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$cblClientSchemes$0";
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Value] = "on";
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.LabeledBy] = "Isuzu North America Corporation > Retirement Trust";
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Title] = null;
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Class] = null;
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.ControlDefinition] = "id=dnn_ctr734_AddExternalUser_cblClientS";
                    this.mUIIsuzuNorthAmericaCorCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.TagInstance] = "16";
                    this.mUIIsuzuNorthAmericaCorCheckBox.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mUIIsuzuNorthAmericaCorCheckBox;
            }
        }
        
        public HtmlInputButton btnSubmit
        {
            get
            {
                if ((this.mbtnSubmit == null))
                {
                    this.mbtnSubmit = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnSubmit.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_imgbtnSubmit";
                    this.mbtnSubmit.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$imgbtnSubmit";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnSubmit.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/Submit.gif";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Title] = "Submit";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "11";
                    this.mbtnSubmit.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnSubmit;
            }
        }
        #endregion
        
        #region Fields
        private HtmlEdit mtxtFirstName;
        
        private HtmlEdit mtxtLastName;
        
        private HtmlEdit mtxtEmailAddress;
        
        private HtmlEdit mtxtCompanyName;
        
        private HtmlCheckBox mUIIsuzuNorthAmericaCorCheckBox;
        
        private HtmlInputButton mbtnSubmit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class pExternalModify : HtmlDocument
    {
        
        public pExternalModify(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = "Body";
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Admin - Users - External";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/DDSUS10LB/DDS/Administration/UserInformation/External/tabid/281/ctl/AddExternalU" +
                "ser/mid/734/UserStagingGUID/5f7bfe6a-b47b-4917-beb9-e2c1d8f2632b/ModifyExternalU" +
                "ser/1/Default.aspx";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Administration/UserInformation/External/ta" +
                "bid/281/ctl/AddExternalUser/mid/734/UserStagingGUID/5f7bfe6a-b47b-4917-beb9-e2c1" +
                "d8f2632b/ModifyExternalUser/1/Default.aspx";
            this.WindowTitles.Add("Admin - Users - External");
            #endregion
        }
        
        #region Properties
        public HtmlInputButton btnApproveReject
        {
            get
            {
                if ((this.mbtnApproveReject == null))
                {
                    this.mbtnApproveReject = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnApproveReject.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_imgbtnApprove";
                    this.mbtnApproveReject.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$imgbtnApprove";
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnApproveReject.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/Approve.gif";
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.Title] = "Open Approval Popup";
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnApproveReject.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "10";
                    this.mbtnApproveReject.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnApproveReject;
            }
        }
        
        public HtmlInputButton btnApproveWin_Approve
        {
            get
            {
                if ((this.mbtnApproveWin_Approve == null))
                {
                    this.mbtnApproveWin_Approve = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnApproveWin_Approve.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_ExternalUserApproval_btnApprove";
                    this.mbtnApproveWin_Approve.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$ExternalUserApproval$btnApprove";
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnApproveWin_Approve.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/DesktopModules/DDS_Approval/Images/Approve" +
                        ".gif";
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.Title] = "Approve pending items";
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnApproveWin_Approve.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "116";
                    this.mbtnApproveWin_Approve.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnApproveWin_Approve;
            }
        }
        
        public HtmlInputButton btnApproveWin_Reject
        {
            get
            {
                if ((this.mbtnApproveWin_Reject == null))
                {
                    this.mbtnApproveWin_Reject = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnApproveWin_Reject.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_ExternalUserApproval_btnReject";
                    this.mbtnApproveWin_Reject.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$ExternalUserApproval$btnReject";
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnApproveWin_Reject.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/Reject.gif";
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.Title] = "Reject pending items";
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnApproveWin_Reject.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "117";
                    this.mbtnApproveWin_Reject.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnApproveWin_Reject;
            }
        }
        
        public HtmlInputButton btnApprovePendingItem_OK
        {
            get
            {
                if ((this.mbtnApprovePendingItem_OK == null))
                {
                    this.mbtnApprovePendingItem_OK = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mbtnApprovePendingItem_OK.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr734_AddExternalUser_ExternalUserApproval_confirmationApprove_imgbtnOK";
                    this.mbtnApprovePendingItem_OK.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr734$AddExternalUser$ExternalUserApproval$confirmationApprove$imgbtnOK";
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnApprovePendingItem_OK.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/OK.gif";
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnApprovePendingItem_OK.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "121";
                    this.mbtnApprovePendingItem_OK.WindowTitles.Add("Admin - Users - External");
                    #endregion
                }
                return this.mbtnApprovePendingItem_OK;
            }
        }
        #endregion
        
        #region Fields
        private HtmlInputButton mbtnApproveReject;
        
        private HtmlInputButton mbtnApproveWin_Approve;
        
        private HtmlInputButton mbtnApproveWin_Reject;
        
        private HtmlInputButton mbtnApprovePendingItem_OK;
        #endregion
    }
}
