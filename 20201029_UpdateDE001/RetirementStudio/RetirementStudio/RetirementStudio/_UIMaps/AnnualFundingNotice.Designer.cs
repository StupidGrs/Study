﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.AnnualFundingNoticeClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public partial class AnnualFundingNotice
    {
        
        #region Properties
        public wRetirementStudio wRetirementStudio
        {
            get
            {
                if ((this.mwRetirementStudio == null))
                {
                    this.mwRetirementStudio = new wRetirementStudio();
                }
                return this.mwRetirementStudio;
            }
        }
        #endregion
        
        #region Fields
        private wRetirementStudio mwRetirementStudio;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wRetirementStudio : WinWindow
    {
        
        public wRetirementStudio()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Retirement Studio";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public tvNaviTree tvNaviTree
        {
            get
            {
                if ((this.mtvNaviTree == null))
                {
                    this.mtvNaviTree = new tvNaviTree(this);
                }
                return this.mtvNaviTree;
            }
        }
        
        public wEndofNoticeYr_Yearbeforefundingser wEndofNoticeYr_Yearbeforefundingser
        {
            get
            {
                if ((this.mwEndofNoticeYr_Yearbeforefundingser == null))
                {
                    this.mwEndofNoticeYr_Yearbeforefundingser = new wEndofNoticeYr_Yearbeforefundingser(this);
                }
                return this.mwEndofNoticeYr_Yearbeforefundingser;
            }
        }
        
        public wPolicies_FundingPolicy wPolicies_FundingPolicy
        {
            get
            {
                if ((this.mwPolicies_FundingPolicy == null))
                {
                    this.mwPolicies_FundingPolicy = new wPolicies_FundingPolicy(this);
                }
                return this.mwPolicies_FundingPolicy;
            }
        }
        
        public wPolicies_InvestmentPolicy wPolicies_InvestmentPolicy
        {
            get
            {
                if ((this.mwPolicies_InvestmentPolicy == null))
                {
                    this.mwPolicies_InvestmentPolicy = new wPolicies_InvestmentPolicy(this);
                }
                return this.mwPolicies_InvestmentPolicy;
            }
        }
        
        public wPolicies_AssetAllocationPct_Cash wPolicies_AssetAllocationPct_Cash
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_Cash == null))
                {
                    this.mwPolicies_AssetAllocationPct_Cash = new wPolicies_AssetAllocationPct_Cash(this);
                }
                return this.mwPolicies_AssetAllocationPct_Cash;
            }
        }
        
        public wPolicies_AssetAllocationPct_USGov wPolicies_AssetAllocationPct_USGov
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_USGov == null))
                {
                    this.mwPolicies_AssetAllocationPct_USGov = new wPolicies_AssetAllocationPct_USGov(this);
                }
                return this.mwPolicies_AssetAllocationPct_USGov;
            }
        }
        
        public wPolicies_AssetAllocationPct_PreferredCorpDebt wPolicies_AssetAllocationPct_PreferredCorpDebt
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_PreferredCorpDebt == null))
                {
                    this.mwPolicies_AssetAllocationPct_PreferredCorpDebt = new wPolicies_AssetAllocationPct_PreferredCorpDebt(this);
                }
                return this.mwPolicies_AssetAllocationPct_PreferredCorpDebt;
            }
        }
        
        public wPolicies_AssetAllocationPct_AllOtherCorp wPolicies_AssetAllocationPct_AllOtherCorp
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_AllOtherCorp == null))
                {
                    this.mwPolicies_AssetAllocationPct_AllOtherCorp = new wPolicies_AssetAllocationPct_AllOtherCorp(this);
                }
                return this.mwPolicies_AssetAllocationPct_AllOtherCorp;
            }
        }
        
        public wPolicies_AssetAllocationPct_PreferredCorpStocks wPolicies_AssetAllocationPct_PreferredCorpStocks
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_PreferredCorpStocks == null))
                {
                    this.mwPolicies_AssetAllocationPct_PreferredCorpStocks = new wPolicies_AssetAllocationPct_PreferredCorpStocks(this);
                }
                return this.mwPolicies_AssetAllocationPct_PreferredCorpStocks;
            }
        }
        
        public wPolicies_AssetAllocationPct_CommonCorpStocks wPolicies_AssetAllocationPct_CommonCorpStocks
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_CommonCorpStocks == null))
                {
                    this.mwPolicies_AssetAllocationPct_CommonCorpStocks = new wPolicies_AssetAllocationPct_CommonCorpStocks(this);
                }
                return this.mwPolicies_AssetAllocationPct_CommonCorpStocks;
            }
        }
        
        public wPolicies_AssetAllocationPct_PartnershipJoint wPolicies_AssetAllocationPct_PartnershipJoint
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_PartnershipJoint == null))
                {
                    this.mwPolicies_AssetAllocationPct_PartnershipJoint = new wPolicies_AssetAllocationPct_PartnershipJoint(this);
                }
                return this.mwPolicies_AssetAllocationPct_PartnershipJoint;
            }
        }
        
        public wPolicies_AssetAllocationPct_RealEstate wPolicies_AssetAllocationPct_RealEstate
        {
            get
            {
                if ((this.mwPolicies_AssetAllocationPct_RealEstate == null))
                {
                    this.mwPolicies_AssetAllocationPct_RealEstate = new wPolicies_AssetAllocationPct_RealEstate(this);
                }
                return this.mwPolicies_AssetAllocationPct_RealEstate;
            }
        }
        
        public wPolices_AssetAllocationPct_EmployerSecurities wPolices_AssetAllocationPct_EmployerSecurities
        {
            get
            {
                if ((this.mwPolices_AssetAllocationPct_EmployerSecurities == null))
                {
                    this.mwPolices_AssetAllocationPct_EmployerSecurities = new wPolices_AssetAllocationPct_EmployerSecurities(this);
                }
                return this.mwPolices_AssetAllocationPct_EmployerSecurities;
            }
        }
        
        public wEndofNoticeYr_YearOfFundingSer wEndofNoticeYr_YearOfFundingSer
        {
            get
            {
                if ((this.mwEndofNoticeYr_YearOfFundingSer == null))
                {
                    this.mwEndofNoticeYr_YearOfFundingSer = new wEndofNoticeYr_YearOfFundingSer(this);
                }
                return this.mwEndofNoticeYr_YearOfFundingSer;
            }
        }
        #endregion
        
        #region Fields
        private tvNaviTree mtvNaviTree;
        
        private wEndofNoticeYr_Yearbeforefundingser mwEndofNoticeYr_Yearbeforefundingser;
        
        private wPolicies_FundingPolicy mwPolicies_FundingPolicy;
        
        private wPolicies_InvestmentPolicy mwPolicies_InvestmentPolicy;
        
        private wPolicies_AssetAllocationPct_Cash mwPolicies_AssetAllocationPct_Cash;
        
        private wPolicies_AssetAllocationPct_USGov mwPolicies_AssetAllocationPct_USGov;
        
        private wPolicies_AssetAllocationPct_PreferredCorpDebt mwPolicies_AssetAllocationPct_PreferredCorpDebt;
        
        private wPolicies_AssetAllocationPct_AllOtherCorp mwPolicies_AssetAllocationPct_AllOtherCorp;
        
        private wPolicies_AssetAllocationPct_PreferredCorpStocks mwPolicies_AssetAllocationPct_PreferredCorpStocks;
        
        private wPolicies_AssetAllocationPct_CommonCorpStocks mwPolicies_AssetAllocationPct_CommonCorpStocks;
        
        private wPolicies_AssetAllocationPct_PartnershipJoint mwPolicies_AssetAllocationPct_PartnershipJoint;
        
        private wPolicies_AssetAllocationPct_RealEstate mwPolicies_AssetAllocationPct_RealEstate;
        
        private wPolices_AssetAllocationPct_EmployerSecurities mwPolices_AssetAllocationPct_EmployerSecurities;
        
        private wEndofNoticeYr_YearOfFundingSer mwEndofNoticeYr_YearOfFundingSer;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class tvNaviTree : WinWindow
    {
        
        public tvNaviTree(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "trvLibraryExplorer";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public UIAnnualFundingNoticeTreeItem UIAnnualFundingNoticeTreeItem
        {
            get
            {
                if ((this.mUIAnnualFundingNoticeTreeItem == null))
                {
                    this.mUIAnnualFundingNoticeTreeItem = new UIAnnualFundingNoticeTreeItem(this);
                }
                return this.mUIAnnualFundingNoticeTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private UIAnnualFundingNoticeTreeItem mUIAnnualFundingNoticeTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIAnnualFundingNoticeTreeItem : WinTreeItem
    {
        
        public UIAnnualFundingNoticeTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTreeItem.PropertyNames.Name] = "Annual Funding Notice";
            this.SearchProperties["Value"] = "0";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinTreeItem UIEndofNoticeYearTreeItem
        {
            get
            {
                if ((this.mUIEndofNoticeYearTreeItem == null))
                {
                    this.mUIEndofNoticeYearTreeItem = new WinTreeItem(this);
                    #region Search Criteria
                    this.mUIEndofNoticeYearTreeItem.SearchProperties[WinTreeItem.PropertyNames.Name] = "End of Notice Year";
                    this.mUIEndofNoticeYearTreeItem.SearchProperties["Value"] = "1";
                    this.mUIEndofNoticeYearTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIEndofNoticeYearTreeItem.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mUIEndofNoticeYearTreeItem.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIEndofNoticeYearTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private WinTreeItem mUIEndofNoticeYearTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wEndofNoticeYr_Yearbeforefundingser : WinWindow
    {
        
        public wEndofNoticeYr_Yearbeforefundingser(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "rbtYearBFS";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton rdYearbeforefundingser
        {
            get
            {
                if ((this.mrdYearbeforefundingser == null))
                {
                    this.mrdYearbeforefundingser = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdYearbeforefundingser.SearchProperties[WinRadioButton.PropertyNames.Name] = "Year before funding service";
                    this.mrdYearbeforefundingser.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdYearbeforefundingser;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdYearbeforefundingser;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_FundingPolicy : WinWindow
    {
        
        public wPolicies_FundingPolicy(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "txtFundingPolicy";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_InvestmentPolicy : WinWindow
    {
        
        public wPolicies_InvestmentPolicy(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "txtInvestmentPolicy";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt.SearchProperties[WinEdit.PropertyNames.Name] = "Statement of the Plan\'s policies";
                    this.mtxt.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_Cash : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_Cash(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "20";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt : WinEdit
    {
        
        public txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_USGov : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_USGov(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "19";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt1 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt1(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt1 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt1 : WinEdit
    {
        
        public txt1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_PreferredCorpDebt : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_PreferredCorpDebt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "18";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt2 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt2(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt2 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt2 : WinEdit
    {
        
        public txt2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_AllOtherCorp : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_AllOtherCorp(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "17";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt3 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt3(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt3 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt3 : WinEdit
    {
        
        public txt3(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_PreferredCorpStocks : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_PreferredCorpStocks(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "16";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt4 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt4(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt4 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt4 : WinEdit
    {
        
        public txt4(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_CommonCorpStocks : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_CommonCorpStocks(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "15";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt5 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt5(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt5 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt5 : WinEdit
    {
        
        public txt5(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_PartnershipJoint : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_PartnershipJoint(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "14";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt6 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt6(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt6 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt6 : WinEdit
    {
        
        public txt6(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolicies_AssetAllocationPct_RealEstate : WinWindow
    {
        
        public wPolicies_AssetAllocationPct_RealEstate(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "13";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt7 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt7(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt7 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt7 : WinEdit
    {
        
        public txt7(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPolices_AssetAllocationPct_EmployerSecurities : WinWindow
    {
        
        public wPolices_AssetAllocationPct_EmployerSecurities(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "4";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txt8 txt
        {
            get
            {
                if ((this.mtxt == null))
                {
                    this.mtxt = new txt8(this);
                }
                return this.mtxt;
            }
        }
        #endregion
        
        #region Fields
        private txt8 mtxt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txt8 : WinEdit
    {
        
        public txt8(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UINumEditorEdit1
        {
            get
            {
                if ((this.mUINumEditorEdit1 == null))
                {
                    this.mUINumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wEndofNoticeYr_YearOfFundingSer : WinWindow
    {
        
        public wEndofNoticeYr_YearOfFundingSer(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "rbtYearFS";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton rdYearoffundingservice
        {
            get
            {
                if ((this.mrdYearoffundingservice == null))
                {
                    this.mrdYearoffundingservice = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdYearoffundingservice.SearchProperties[WinRadioButton.PropertyNames.Name] = "Year of funding service";
                    this.mrdYearoffundingservice.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdYearoffundingservice;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdYearoffundingservice;
        #endregion
    }
}
