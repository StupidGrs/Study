﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.ASC960ReconciliationClasses
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
    public partial class ASC960Reconciliation
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
        public wPY_MarketValueofAssetsAvailableforBenefits wPY_MarketValueofAssetsAvailableforBenefits
        {
            get
            {
                if ((this.mwPY_MarketValueofAssetsAvailableforBenefits == null))
                {
                    this.mwPY_MarketValueofAssetsAvailableforBenefits = new wPY_MarketValueofAssetsAvailableforBenefits(this);
                }
                return this.mwPY_MarketValueofAssetsAvailableforBenefits;
            }
        }
        
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
        
        public wMarketValueOfAssets wMarketValueOfAssets
        {
            get
            {
                if ((this.mwMarketValueOfAssets == null))
                {
                    this.mwMarketValueOfAssets = new wMarketValueOfAssets(this);
                }
                return this.mwMarketValueOfAssets;
            }
        }
        #endregion
        
        #region Fields
        private wPY_MarketValueofAssetsAvailableforBenefits mwPY_MarketValueofAssetsAvailableforBenefits;
        
        private tvNaviTree mtvNaviTree;
        
        private wMarketValueOfAssets mwMarketValueOfAssets;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPY_MarketValueofAssetsAvailableforBenefits : WinWindow
    {
        
        public wPY_MarketValueofAssetsAvailableforBenefits(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "numEditor";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "12";
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
        public UIASC960ReconciliationTreeItem UIASC960ReconciliationTreeItem
        {
            get
            {
                if ((this.mUIASC960ReconciliationTreeItem == null))
                {
                    this.mUIASC960ReconciliationTreeItem = new UIASC960ReconciliationTreeItem(this);
                }
                return this.mUIASC960ReconciliationTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private UIASC960ReconciliationTreeItem mUIASC960ReconciliationTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIASC960ReconciliationTreeItem : WinTreeItem
    {
        
        public UIASC960ReconciliationTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTreeItem.PropertyNames.Name] = "ASC 960 Reconciliation Inputs";
            this.SearchProperties["Value"] = "0";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinTreeItem UIPriorYearTreeItem
        {
            get
            {
                if ((this.mUIPriorYearTreeItem == null))
                {
                    this.mUIPriorYearTreeItem = new WinTreeItem(this);
                    #region Search Criteria
                    this.mUIPriorYearTreeItem.SearchProperties[WinTreeItem.PropertyNames.Name] = "Prior Year";
                    this.mUIPriorYearTreeItem.SearchProperties["Value"] = "1";
                    this.mUIPriorYearTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIPriorYearTreeItem.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mUIPriorYearTreeItem.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIPriorYearTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private WinTreeItem mUIPriorYearTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wMarketValueOfAssets : WinWindow
    {
        
        public wMarketValueOfAssets(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "checkBoxMarketValueOfAsset";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinCheckBox chk
        {
            get
            {
                if ((this.mchk == null))
                {
                    this.mchk = new WinCheckBox(this);
                    #region Search Criteria
                    this.mchk.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mchk.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mchk;
            }
        }
        #endregion
        
        #region Fields
        private WinCheckBox mchk;
        #endregion
    }
}
