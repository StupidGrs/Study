﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps_MDDS.Internal_Step2Classes
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
    public partial class Internal_Step2
    {
        
        #region Properties
        public wInternal_Step2 wInternal_Step2
        {
            get
            {
                if ((this.mwInternal_Step2 == null))
                {
                    this.mwInternal_Step2 = new wInternal_Step2();
                }
                return this.mwInternal_Step2;
            }
        }
        #endregion
        
        #region Fields
        private wInternal_Step2 mwInternal_Step2;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wInternal_Step2 : BrowserWindow
    {
        
        public wInternal_Step2()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Internal";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Internal");
            #endregion
        }
        
        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }
        
        #region Properties
        public pInternal_Step2 pInternal_Step2
        {
            get
            {
                if ((this.mpInternal_Step2 == null))
                {
                    this.mpInternal_Step2 = new pInternal_Step2(this);
                }
                return this.mpInternal_Step2;
            }
        }
        #endregion
        
        #region Fields
        private pInternal_Step2 mpInternal_Step2;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class pInternal_Step2 : HtmlDocument
    {
        
        public pInternal_Step2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = "Body";
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Internal";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/DDSUS10LB/DDS/Administration/UserInformation/Internal/tabid/280/ctl/AddUser/mid/" +
                "733/LoginName/michelle-haskins/Default.aspx";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Administration/UserInformation/Internal/ta" +
                "bid/280/ctl/AddUser/mid/733/LoginName/michelle-haskins/Default.aspx";
            this.WindowTitles.Add("Internal");
            #endregion
        }
        
        #region Properties
        public UIDnn_ctr733_AddUser_cTable UIDnn_ctr733_AddUser_cTable
        {
            get
            {
                if ((this.mUIDnn_ctr733_AddUser_cTable == null))
                {
                    this.mUIDnn_ctr733_AddUser_cTable = new UIDnn_ctr733_AddUser_cTable(this);
                }
                return this.mUIDnn_ctr733_AddUser_cTable;
            }
        }
        
        public HtmlCheckBox UIClientSolutionsCheckBox
        {
            get
            {
                if ((this.mUIClientSolutionsCheckBox == null))
                {
                    this.mUIClientSolutionsCheckBox = new HtmlCheckBox(this);
                    #region Search Criteria
                    this.mUIClientSolutionsCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "dnn_ctr733_AddUser_cblTeams_2";
                    this.mUIClientSolutionsCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Name] = "dnn$ctr733$AddUser$cblTeams$2";
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Value] = "on";
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.LabeledBy] = "Client Solutions";
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Title] = null;
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Class] = null;
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.ControlDefinition] = "id=dnn_ctr733_AddUser_cblTeams_2 type=ch";
                    this.mUIClientSolutionsCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.TagInstance] = "9";
                    this.mUIClientSolutionsCheckBox.WindowTitles.Add("Internal");
                    #endregion
                }
                return this.mUIClientSolutionsCheckBox;
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
                    this.mbtnSubmit.SearchProperties[HtmlButton.PropertyNames.Id] = "dnn_ctr733_AddUser_imgbtnSubmit";
                    this.mbtnSubmit.SearchProperties[HtmlButton.PropertyNames.Name] = "dnn$ctr733$AddUser$imgbtnSubmit";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.DisplayText] = null;
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Type] = "image";
                    this.mbtnSubmit.FilterProperties["Src"] = "http://mddsqa.mercer.com/DDSUS10LB/DDS/Images_DDS/submit.gif";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Title] = "Submit changes";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.Class] = "icon_rectangle_130_25";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-T";
                    this.mbtnSubmit.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "5";
                    this.mbtnSubmit.WindowTitles.Add("Internal");
                    #endregion
                }
                return this.mbtnSubmit;
            }
        }
        #endregion
        
        #region Fields
        private UIDnn_ctr733_AddUser_cTable mUIDnn_ctr733_AddUser_cTable;
        
        private HtmlCheckBox mUIClientSolutionsCheckBox;
        
        private HtmlInputButton mbtnSubmit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDnn_ctr733_AddUser_cTable : HtmlTable
    {
        
        public UIDnn_ctr733_AddUser_cTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlTable.PropertyNames.Id] = "dnn_ctr733_AddUser_cblTeams";
            this.SearchProperties[HtmlTable.PropertyNames.Name] = null;
            this.FilterProperties[HtmlTable.PropertyNames.InnerText] = "Admin Approver\r\nAll Plans Setup Approver";
            this.FilterProperties[HtmlTable.PropertyNames.ControlDefinition] = "id=dnn_ctr733_AddUser_cblTeams border=0";
            this.FilterProperties[HtmlTable.PropertyNames.RowCount] = "15";
            this.FilterProperties[HtmlTable.PropertyNames.ColumnCount] = "1";
            this.FilterProperties[HtmlTable.PropertyNames.Class] = null;
            this.FilterProperties[HtmlTable.PropertyNames.TagInstance] = "4";
            this.WindowTitles.Add("Internal");
            #endregion
        }
        
        #region Properties
        public HtmlLabel UIAllPlansSetupApproveLabel
        {
            get
            {
                if ((this.mUIAllPlansSetupApproveLabel == null))
                {
                    this.mUIAllPlansSetupApproveLabel = new HtmlLabel(this);
                    #region Search Criteria
                    this.mUIAllPlansSetupApproveLabel.SearchProperties[HtmlLabel.PropertyNames.Id] = null;
                    this.mUIAllPlansSetupApproveLabel.SearchProperties[HtmlLabel.PropertyNames.Name] = null;
                    this.mUIAllPlansSetupApproveLabel.SearchProperties[HtmlLabel.PropertyNames.LabelFor] = "dnn_ctr733_AddUser_cblTeams_1";
                    this.mUIAllPlansSetupApproveLabel.FilterProperties[HtmlLabel.PropertyNames.InnerText] = "All Plans Setup Approver";
                    this.mUIAllPlansSetupApproveLabel.FilterProperties[HtmlLabel.PropertyNames.Class] = null;
                    this.mUIAllPlansSetupApproveLabel.FilterProperties[HtmlLabel.PropertyNames.ControlDefinition] = "for=dnn_ctr733_AddUser_cblTeams_1";
                    this.mUIAllPlansSetupApproveLabel.FilterProperties[HtmlLabel.PropertyNames.TagInstance] = "2";
                    this.mUIAllPlansSetupApproveLabel.WindowTitles.Add("Internal");
                    #endregion
                }
                return this.mUIAllPlansSetupApproveLabel;
            }
        }
        #endregion
        
        #region Fields
        private HtmlLabel mUIAllPlansSetupApproveLabel;
        #endregion
    }
}
