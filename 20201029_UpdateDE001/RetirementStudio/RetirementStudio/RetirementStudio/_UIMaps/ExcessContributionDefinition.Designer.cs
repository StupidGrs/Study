﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.ExcessContributionDefinitionClasses
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
    public partial class ExcessContributionDefinition
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
        public wPayAsLumpSum wPayAsLumpSum
        {
            get
            {
                if ((this.mwPayAsLumpSum == null))
                {
                    this.mwPayAsLumpSum = new wPayAsLumpSum(this);
                }
                return this.mwPayAsLumpSum;
            }
        }
        
        public wIncreaseBenefit wIncreaseBenefit
        {
            get
            {
                if ((this.mwIncreaseBenefit == null))
                {
                    this.mwIncreaseBenefit = new wIncreaseBenefit(this);
                }
                return this.mwIncreaseBenefit;
            }
        }
        
        public wActives wActives
        {
            get
            {
                if ((this.mwActives == null))
                {
                    this.mwActives = new wActives(this);
                }
                return this.mwActives;
            }
        }
        
        public wDeferredInactives wDeferredInactives
        {
            get
            {
                if ((this.mwDeferredInactives == null))
                {
                    this.mwDeferredInactives = new wDeferredInactives(this);
                }
                return this.mwDeferredInactives;
            }
        }
        
        public wPercentCovered wPercentCovered
        {
            get
            {
                if ((this.mwPercentCovered == null))
                {
                    this.mwPercentCovered = new wPercentCovered(this);
                }
                return this.mwPercentCovered;
            }
        }
        
        public wContributionDefinition wContributionDefinition
        {
            get
            {
                if ((this.mwContributionDefinition == null))
                {
                    this.mwContributionDefinition = new wContributionDefinition(this);
                }
                return this.mwContributionDefinition;
            }
        }
        
        public wRetirementList wRetirementList
        {
            get
            {
                if ((this.mwRetirementList == null))
                {
                    this.mwRetirementList = new wRetirementList(this);
                }
                return this.mwRetirementList;
            }
        }
        
        public wWithdrawalList wWithdrawalList
        {
            get
            {
                if ((this.mwWithdrawalList == null))
                {
                    this.mwWithdrawalList = new wWithdrawalList(this);
                }
                return this.mwWithdrawalList;
            }
        }
        
        public wMortalityList wMortalityList
        {
            get
            {
                if ((this.mwMortalityList == null))
                {
                    this.mwMortalityList = new wMortalityList(this);
                }
                return this.mwMortalityList;
            }
        }
        
        public wSelectBenefitToCompareList wSelectBenefitToCompareList
        {
            get
            {
                if ((this.mwSelectBenefitToCompareList == null))
                {
                    this.mwSelectBenefitToCompareList = new wSelectBenefitToCompareList(this);
                }
                return this.mwSelectBenefitToCompareList;
            }
        }
        #endregion
        
        #region Fields
        private wPayAsLumpSum mwPayAsLumpSum;
        
        private wIncreaseBenefit mwIncreaseBenefit;
        
        private wActives mwActives;
        
        private wDeferredInactives mwDeferredInactives;
        
        private wPercentCovered mwPercentCovered;
        
        private wContributionDefinition mwContributionDefinition;
        
        private wRetirementList mwRetirementList;
        
        private wWithdrawalList mwWithdrawalList;
        
        private wMortalityList mwMortalityList;
        
        private wSelectBenefitToCompareList mwSelectBenefitToCompareList;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPayAsLumpSum : WinWindow
    {
        
        public wPayAsLumpSum(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radPayAsLumpSum";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Pay as lump sum";
                    this.mrd.WindowTitles.Add("Retirement Studio");
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
    public class wIncreaseBenefit : WinWindow
    {
        
        public wIncreaseBenefit(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radIncreaseBenefit";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Increase benefit";
                    this.mrd.WindowTitles.Add("Retirement Studio");
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
    public class wActives : WinWindow
    {
        
        public wActives(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radActives";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Actives";
                    this.mrd.WindowTitles.Add("Retirement Studio");
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
    public class wDeferredInactives : WinWindow
    {
        
        public wDeferredInactives(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radDeferredInactives";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Deferred inactives";
                    this.mrd.WindowTitles.Add("Retirement Studio");
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
    public class wPercentCovered : WinWindow
    {
        
        public wPercentCovered(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "unrPercentCovered";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
        public WinEdit UIUnrPercentCoveredEdit1
        {
            get
            {
                if ((this.mUIUnrPercentCoveredEdit1 == null))
                {
                    this.mUIUnrPercentCoveredEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUIUnrPercentCoveredEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUIUnrPercentCoveredEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIUnrPercentCoveredEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIUnrPercentCoveredEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wContributionDefinition : WinWindow
    {
        
        public wContributionDefinition(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboContributionDefinition";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
                    this.mcbo.WindowTitles.Add("Retirement Studio");
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
    public class wRetirementList : WinWindow
    {
        
        public wRetirementList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "chkCompareRetirement";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public wlist wlist
        {
            get
            {
                if ((this.mwlist == null))
                {
                    this.mwlist = new wlist(this);
                }
                return this.mwlist;
            }
        }
        #endregion
        
        #region Fields
        private wlist mwlist;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wlist : WinList
    {
        
        public wlist(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinList.PropertyNames.Name] = "Select benefits to compare to contribution balance";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "PVPreCAE";
                    this.mchk.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mchk.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mchk;
            }
        }
        
        public WinCheckBox UIPVRetireCheckBox
        {
            get
            {
                if ((this.mUIPVRetireCheckBox == null))
                {
                    this.mUIPVRetireCheckBox = new WinCheckBox(this);
                    #region Search Criteria
                    this.mUIPVRetireCheckBox.SearchProperties[WinCheckBox.PropertyNames.Name] = "PVRetire";
                    this.mUIPVRetireCheckBox.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIPVRetireCheckBox;
            }
        }
        #endregion
        
        #region Fields
        private WinCheckBox mchk;
        
        private WinCheckBox mUIPVRetireCheckBox;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wWithdrawalList : WinWindow
    {
        
        public wWithdrawalList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "chkCompareWithdrawal";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "PVTerm";
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wMortalityList : WinWindow
    {
        
        public wMortalityList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "chkCompareMortality";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "PVDeath";
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wSelectBenefitToCompareList : WinWindow
    {
        
        public wSelectBenefitToCompareList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "chkCompareBenefit";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public wList1 wList
        {
            get
            {
                if ((this.mwList == null))
                {
                    this.mwList = new wList1(this);
                }
                return this.mwList;
            }
        }
        #endregion
        
        #region Fields
        private wList1 mwList;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wList1 : WinList
    {
        
        public wList1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinList.PropertyNames.Name] = "Disability";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "Pst86Defd";
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