﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.ValuationProcessControlClasses
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
    public partial class ValuationProcessControl
    {
        
        /// <summary>
        /// RecordedMethod1
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinClient grid = this.wRetirementStudio.wVPCServicesManage.grid;
            #endregion

            // Click 'sprVPCServicesManager' client
            Mouse.Click(grid, new Point(61, 27));
        }
        
        #region Properties
        public wValuationProcessCont wValuationProcessCont
        {
            get
            {
                if ((this.mwValuationProcessCont == null))
                {
                    this.mwValuationProcessCont = new wValuationProcessCont();
                }
                return this.mwValuationProcessCont;
            }
        }
        
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
        
        public wSaveAs wSaveAs
        {
            get
            {
                if ((this.mwSaveAs == null))
                {
                    this.mwSaveAs = new wSaveAs();
                }
                return this.mwSaveAs;
            }
        }
        #endregion
        
        #region Fields
        private wValuationProcessCont mwValuationProcessCont;
        
        private wRetirementStudio mwRetirementStudio;
        
        private wSaveAs mwSaveAs;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wValuationProcessCont : WinWindow
    {
        
        public wValuationProcessCont()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Valuation Process Control Properties";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public wName wName
        {
            get
            {
                if ((this.mwName == null))
                {
                    this.mwName = new wName(this);
                }
                return this.mwName;
            }
        }
        
        public wPlanYearBegins wPlanYearBegins
        {
            get
            {
                if ((this.mwPlanYearBegins == null))
                {
                    this.mwPlanYearBegins = new wPlanYearBegins(this);
                }
                return this.mwPlanYearBegins;
            }
        }
        
        public wPlanYearEnds wPlanYearEnds
        {
            get
            {
                if ((this.mwPlanYearEnds == null))
                {
                    this.mwPlanYearEnds = new wPlanYearEnds(this);
                }
                return this.mwPlanYearEnds;
            }
        }
        
        public wValuationDate wValuationDate
        {
            get
            {
                if ((this.mwValuationDate == null))
                {
                    this.mwValuationDate = new wValuationDate(this);
                }
                return this.mwValuationDate;
            }
        }
        
        public wOutsidestudio wOutsidestudio
        {
            get
            {
                if ((this.mwOutsidestudio == null))
                {
                    this.mwOutsidestudio = new wOutsidestudio(this);
                }
                return this.mwOutsidestudio;
            }
        }
        
        public wOK wOK
        {
            get
            {
                if ((this.mwOK == null))
                {
                    this.mwOK = new wOK(this);
                }
                return this.mwOK;
            }
        }
        
        public wFundingService wFundingService
        {
            get
            {
                if ((this.mwFundingService == null))
                {
                    this.mwFundingService = new wFundingService(this);
                }
                return this.mwFundingService;
            }
        }
        #endregion
        
        #region Fields
        private wName mwName;
        
        private wPlanYearBegins mwPlanYearBegins;
        
        private wPlanYearEnds mwPlanYearEnds;
        
        private wValuationDate mwValuationDate;
        
        private wOutsidestudio mwOutsidestudio;
        
        private wOK mwOK;
        
        private wFundingService mwFundingService;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wName : WinWindow
    {
        
        public wName(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "tbName";
            this.WindowTitles.Add("Valuation Process Control Properties");
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
                    this.mtxt.SearchProperties[WinEdit.PropertyNames.Name] = "Name";
                    this.mtxt.WindowTitles.Add("Valuation Process Control Properties");
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
    public class wPlanYearBegins : WinWindow
    {
        
        public wPlanYearBegins(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "dtPlanYearBegins";
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public cbo cbo
        {
            get
            {
                if ((this.mcbo == null))
                {
                    this.mcbo = new cbo(this);
                }
                return this.mcbo;
            }
        }
        #endregion
        
        #region Fields
        private cbo mcbo;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class cbo : WinComboBox
    {
        
        public cbo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinEdit UIDtPlanYearBeginsEdit
        {
            get
            {
                if ((this.mUIDtPlanYearBeginsEdit == null))
                {
                    this.mUIDtPlanYearBeginsEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIDtPlanYearBeginsEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUIDtPlanYearBeginsEdit.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mUIDtPlanYearBeginsEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIDtPlanYearBeginsEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPlanYearEnds : WinWindow
    {
        
        public wPlanYearEnds(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "dtPlanYearEnds";
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public cbo1 cbo
        {
            get
            {
                if ((this.mcbo == null))
                {
                    this.mcbo = new cbo1(this);
                }
                return this.mcbo;
            }
        }
        #endregion
        
        #region Fields
        private cbo1 mcbo;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class cbo1 : WinComboBox
    {
        
        public cbo1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinEdit UIDtPlanYearEndsEdit
        {
            get
            {
                if ((this.mUIDtPlanYearEndsEdit == null))
                {
                    this.mUIDtPlanYearEndsEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIDtPlanYearEndsEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUIDtPlanYearEndsEdit.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mUIDtPlanYearEndsEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIDtPlanYearEndsEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wValuationDate : WinWindow
    {
        
        public wValuationDate(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "dtValuationDate";
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public cbo2 cbo
        {
            get
            {
                if ((this.mcbo == null))
                {
                    this.mcbo = new cbo2(this);
                }
                return this.mcbo;
            }
        }
        #endregion
        
        #region Fields
        private cbo2 mcbo;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class cbo2 : WinComboBox
    {
        
        public cbo2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinEdit UIDtValuationDateEdit
        {
            get
            {
                if ((this.mUIDtValuationDateEdit == null))
                {
                    this.mUIDtValuationDateEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIDtValuationDateEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUIDtValuationDateEdit.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mUIDtValuationDateEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIDtValuationDateEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wOutsidestudio : WinWindow
    {
        
        public wOutsidestudio(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "rbOutsideStudio";
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinRadioButton rd
        {
            get
            {
                if ((this.mrd == null))
                {
                    this.mrd = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Outside studio";
                    this.mrd.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mrd;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrd;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wOK : WinWindow
    {
        
        public wOK(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnOK";
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinButton btn
        {
            get
            {
                if ((this.mbtn == null))
                {
                    this.mbtn = new WinButton(this);
                    #region Search Criteria
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mbtn.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mbtn;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtn;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFundingService : WinWindow
    {
        
        public wFundingService(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbFundingService";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Valuation Process Control Properties");
            #endregion
        }
        
        #region Properties
        public WinComboBox cbo
        {
            get
            {
                if ((this.mcbo == null))
                {
                    this.mcbo = new WinComboBox(this);
                    #region Search Criteria
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Current measurement";
                    this.mcbo.WindowTitles.Add("Valuation Process Control Properties");
                    #endregion
                }
                return this.mcbo;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mcbo;
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
        public TvExplorer TvExplorer
        {
            get
            {
                if ((this.mTvExplorer == null))
                {
                    this.mTvExplorer = new TvExplorer(this);
                }
                return this.mTvExplorer;
            }
        }
        
        public wCheckListstoEeport wCheckListstoEeport
        {
            get
            {
                if ((this.mwCheckListstoEeport == null))
                {
                    this.mwCheckListstoEeport = new wCheckListstoEeport(this);
                }
                return this.mwCheckListstoEeport;
            }
        }
        
        public wVPCServicesManage wVPCServicesManage
        {
            get
            {
                if ((this.mwVPCServicesManage == null))
                {
                    this.mwVPCServicesManage = new wVPCServicesManage(this);
                }
                return this.mwVPCServicesManage;
            }
        }
        
        public wTab wTab
        {
            get
            {
                if ((this.mwTab == null))
                {
                    this.mwTab = new wTab(this);
                }
                return this.mwTab;
            }
        }
        #endregion
        
        #region Fields
        private TvExplorer mTvExplorer;
        
        private wCheckListstoEeport mwCheckListstoEeport;
        
        private wVPCServicesManage mwVPCServicesManage;
        
        private wTab mwTab;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class TvExplorer : WinWindow
    {
        
        public TvExplorer(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "tvExplorer";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public UIPhaseTreeItem UIPhaseTreeItem
        {
            get
            {
                if ((this.mUIPhaseTreeItem == null))
                {
                    this.mUIPhaseTreeItem = new UIPhaseTreeItem(this);
                }
                return this.mUIPhaseTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private UIPhaseTreeItem mUIPhaseTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIPhaseTreeItem : WinTreeItem
    {
        
        public UIPhaseTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTreeItem.PropertyNames.Name] = "Phase";
            this.SearchProperties["Value"] = "0";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public UIPlanningTreeItem UIPlanningTreeItem
        {
            get
            {
                if ((this.mUIPlanningTreeItem == null))
                {
                    this.mUIPlanningTreeItem = new UIPlanningTreeItem(this);
                }
                return this.mUIPlanningTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private UIPlanningTreeItem mUIPlanningTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIPlanningTreeItem : WinTreeItem
    {
        
        public UIPlanningTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTreeItem.PropertyNames.Name] = "Planning";
            this.SearchProperties["Value"] = "1";
            this.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            this.SearchConfigurations.Add(SearchConfiguration.NextSibling);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinTreeItem UIBasisTreeItem
        {
            get
            {
                if ((this.mUIBasisTreeItem == null))
                {
                    this.mUIBasisTreeItem = new WinTreeItem(this);
                    #region Search Criteria
                    this.mUIBasisTreeItem.SearchProperties[WinTreeItem.PropertyNames.Name] = "Basis";
                    this.mUIBasisTreeItem.SearchProperties["Value"] = "2";
                    this.mUIBasisTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIBasisTreeItem.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mUIBasisTreeItem.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIBasisTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private WinTreeItem mUIBasisTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wCheckListstoEeport : WinWindow
    {
        
        public wCheckListstoEeport(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnExport";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btn
        {
            get
            {
                if ((this.mbtn == null))
                {
                    this.mbtn = new WinButton(this);
                    #region Search Criteria
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "Export CheckLists to Excel";
                    this.mbtn.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtn;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtn;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wVPCServicesManage : WinWindow
    {
        
        public wVPCServicesManage(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sprVPCServicesManager";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinClient grid
        {
            get
            {
                if ((this.mgrid == null))
                {
                    this.mgrid = new WinClient(this);
                    #region Search Criteria
                    this.mgrid.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mgrid;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mgrid;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wTab : WinWindow
    {
        
        public wTab(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "MainWorkspace";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinTabPage wHome
        {
            get
            {
                if ((this.mwHome == null))
                {
                    this.mwHome = new WinTabPage(this);
                    #region Search Criteria
                    this.mwHome.SearchProperties[WinTabPage.PropertyNames.Name] = "Home";
                    this.mwHome.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mwHome;
            }
        }
        #endregion
        
        #region Fields
        private WinTabPage mwHome;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wSaveAs : WinWindow
    {
        
        public wSaveAs()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Save As";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Save As");
            #endregion
        }
        
        #region Properties
        public wFileName wFileName
        {
            get
            {
                if ((this.mwFileName == null))
                {
                    this.mwFileName = new wFileName(this);
                }
                return this.mwFileName;
            }
        }
        
        public wSave wSave
        {
            get
            {
                if ((this.mwSave == null))
                {
                    this.mwSave = new wSave(this);
                }
                return this.mwSave;
            }
        }
        #endregion
        
        #region Fields
        private wFileName mwFileName;
        
        private wSave mwSave;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFileName : WinWindow
    {
        
        public wFileName(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "1001";
            this.WindowTitles.Add("Save As");
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
                    this.mtxt.SearchProperties[WinEdit.PropertyNames.Name] = "File name:";
                    this.mtxt.WindowTitles.Add("Save As");
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
    public class wSave : WinWindow
    {
        
        public wSave(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "1";
            this.WindowTitles.Add("Save As");
            #endregion
        }
        
        #region Properties
        public WinButton btn
        {
            get
            {
                if ((this.mbtn == null))
                {
                    this.mbtn = new WinButton(this);
                    #region Search Criteria
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "Save";
                    this.mbtn.WindowTitles.Add("Save As");
                    #endregion
                }
                return this.mbtn;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtn;
        #endregion
    }
}
