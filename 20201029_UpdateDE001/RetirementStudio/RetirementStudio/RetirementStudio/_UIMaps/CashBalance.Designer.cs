﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.CashBalanceClasses
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
    public partial class CashBalance
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
        public wStartingBalance wStartingBalance
        {
            get
            {
                if ((this.mwStartingBalance == null))
                {
                    this.mwStartingBalance = new wStartingBalance(this);
                }
                return this.mwStartingBalance;
            }
        }
        
        public wPayCredits wPayCredits
        {
            get
            {
                if ((this.mwPayCredits == null))
                {
                    this.mwPayCredits = new wPayCredits(this);
                }
                return this.mwPayCredits;
            }
        }
        
        public wLinearizationwithbre wLinearizationwithbre
        {
            get
            {
                if ((this.mwLinearizationwithbre == null))
                {
                    this.mwLinearizationwithbre = new wLinearizationwithbre(this);
                }
                return this.mwLinearizationwithbre;
            }
        }
        
        public wAccountBalance wAccountBalance
        {
            get
            {
                if ((this.mwAccountBalance == null))
                {
                    this.mwAccountBalance = new wAccountBalance(this);
                }
                return this.mwAccountBalance;
            }
        }
        
        public wPriorYear wPriorYear
        {
            get
            {
                if ((this.mwPriorYear == null))
                {
                    this.mwPriorYear = new wPriorYear(this);
                }
                return this.mwPriorYear;
            }
        }
        
        public wStartAge wStartAge
        {
            get
            {
                if ((this.mwStartAge == null))
                {
                    this.mwStartAge = new wStartAge(this);
                }
                return this.mwStartAge;
            }
        }
        
        public wButton_C wButton_C
        {
            get
            {
                if ((this.mwButton_C == null))
                {
                    this.mwButton_C = new wButton_C(this);
                }
                return this.mwButton_C;
            }
        }
        
        public wBreakPoint_txt wBreakPoint_txt
        {
            get
            {
                if ((this.mwBreakPoint_txt == null))
                {
                    this.mwBreakPoint_txt = new wBreakPoint_txt(this);
                }
                return this.mwBreakPoint_txt;
            }
        }
        
        public wBreakpointAge wBreakpointAge
        {
            get
            {
                if ((this.mwBreakpointAge == null))
                {
                    this.mwBreakpointAge = new wBreakpointAge(this);
                }
                return this.mwBreakpointAge;
            }
        }
        
        public wPayCreditsLabelCoWindow wPayCreditsLabelCoWindow
        {
            get
            {
                if ((this.mwPayCreditsLabelCoWindow == null))
                {
                    this.mwPayCreditsLabelCoWindow = new wPayCreditsLabelCoWindow(this);
                }
                return this.mwPayCreditsLabelCoWindow;
            }
        }
        
        public wTheSame wTheSame
        {
            get
            {
                if ((this.mwTheSame == null))
                {
                    this.mwTheSame = new wTheSame(this);
                }
                return this.mwTheSame;
            }
        }
        
        public wDifference wDifference
        {
            get
            {
                if ((this.mwDifference == null))
                {
                    this.mwDifference = new wDifference(this);
                }
                return this.mwDifference;
            }
        }
        
        public wCashBalanceRate wCashBalanceRate
        {
            get
            {
                if ((this.mwCashBalanceRate == null))
                {
                    this.mwCashBalanceRate = new wCashBalanceRate(this);
                }
                return this.mwCashBalanceRate;
            }
        }
        
        public wSimplelinearizationWindow wSimplelinearizationWindow
        {
            get
            {
                if ((this.mwSimplelinearizationWindow == null))
                {
                    this.mwSimplelinearizationWindow = new wSimplelinearizationWindow(this);
                }
                return this.mwSimplelinearizationWindow;
            }
        }
        
        public wLinearizationwithbreWindow wLinearizationwithbreWindow
        {
            get
            {
                if ((this.mwLinearizationwithbreWindow == null))
                {
                    this.mwLinearizationwithbreWindow = new wLinearizationwithbreWindow(this);
                }
                return this.mwLinearizationwithbreWindow;
            }
        }
        
        public wHistoricalvaluesWindow wHistoricalvaluesWindow
        {
            get
            {
                if ((this.mwHistoricalvaluesWindow == null))
                {
                    this.mwHistoricalvaluesWindow = new wHistoricalvaluesWindow(this);
                }
                return this.mwHistoricalvaluesWindow;
            }
        }
        
        public wCustomcodeWindow wCustomcodeWindow
        {
            get
            {
                if ((this.mwCustomcodeWindow == null))
                {
                    this.mwCustomcodeWindow = new wCustomcodeWindow(this);
                }
                return this.mwCustomcodeWindow;
            }
        }
        
        public wCom_cbo wCom_cbo
        {
            get
            {
                if ((this.mwCom_cbo == null))
                {
                    this.mwCom_cbo = new wCom_cbo(this);
                }
                return this.mwCom_cbo;
            }
        }
        
        public wFreezePayCreditsAtAge_TXT wFreezePayCreditsAtAge_TXT
        {
            get
            {
                if ((this.mwFreezePayCreditsAtAge_TXT == null))
                {
                    this.mwFreezePayCreditsAtAge_TXT = new wFreezePayCreditsAtAge_TXT(this);
                }
                return this.mwFreezePayCreditsAtAge_TXT;
            }
        }
        
        public wRateOnBalancesIsDiffer wRateOnBalancesIsDiffer
        {
            get
            {
                if ((this.mwRateOnBalancesIsDiffer == null))
                {
                    this.mwRateOnBalancesIsDiffer = new wRateOnBalancesIsDiffer(this);
                }
                return this.mwRateOnBalancesIsDiffer;
            }
        }
        #endregion
        
        #region Fields
        private wStartingBalance mwStartingBalance;
        
        private wPayCredits mwPayCredits;
        
        private wLinearizationwithbre mwLinearizationwithbre;
        
        private wAccountBalance mwAccountBalance;
        
        private wPriorYear mwPriorYear;
        
        private wStartAge mwStartAge;
        
        private wButton_C mwButton_C;
        
        private wBreakPoint_txt mwBreakPoint_txt;
        
        private wBreakpointAge mwBreakpointAge;
        
        private wPayCreditsLabelCoWindow mwPayCreditsLabelCoWindow;
        
        private wTheSame mwTheSame;
        
        private wDifference mwDifference;
        
        private wCashBalanceRate mwCashBalanceRate;
        
        private wSimplelinearizationWindow mwSimplelinearizationWindow;
        
        private wLinearizationwithbreWindow mwLinearizationwithbreWindow;
        
        private wHistoricalvaluesWindow mwHistoricalvaluesWindow;
        
        private wCustomcodeWindow mwCustomcodeWindow;
        
        private wCom_cbo mwCom_cbo;
        
        private wFreezePayCreditsAtAge_TXT mwFreezePayCreditsAtAge_TXT;
        
        private wRateOnBalancesIsDiffer mwRateOnBalancesIsDiffer;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStartingBalance : WinWindow
    {
        
        public wStartingBalance(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbocurrentYearBalanceLabelComboBox";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Freeze pay credits at age";
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
    public class wPayCredits : WinWindow
    {
        
        public wPayCredits(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbopayCreditsLabelComboBox";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Proportion of interest earned by pay credits";
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
    public class wLinearizationwithbre : WinWindow
    {
        
        public wLinearizationwithbre(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radLinearizationWithBreakpoint";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Linearization with breakpoint";
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
    public class wAccountBalance : WinWindow
    {
        
        public wAccountBalance(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboAccountBalance";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Account balance";
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
    public class wPriorYear : WinWindow
    {
        
        public wPriorYear(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radPriorYear";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Prior year";
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
    public class wStartAge : WinWindow
    {
        
        public wStartAge(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboStartAge";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Start age for linearization";
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
    public class wButton_C : WinWindow
    {
        
        public wButton_C(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnConstant";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "2";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "C";
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
    public class wBreakPoint_txt : WinWindow
    {
        
        public wBreakPoint_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditConstant";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "2";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public Edit Edit
        {
            get
            {
                if ((this.mEdit == null))
                {
                    this.mEdit = new Edit(this);
                }
                return this.mEdit;
            }
        }
        #endregion
        
        #region Fields
        private Edit mEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class Edit : WinEdit
    {
        
        public Edit(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
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
                    this.mtxt.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
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
    public class wBreakpointAge : WinWindow
    {
        
        public wBreakpointAge(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboBreakpointAge";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Breakpoint age";
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
    public class wPayCreditsLabelCoWindow : WinWindow
    {
        
        public wPayCreditsLabelCoWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbopayCreditsLabelComboBox";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Proportion of interest earned by pay credits";
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
    public class wTheSame : WinWindow
    {
        
        public wTheSame(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btninterestCreditSameOptionRadioButton";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Rate on balances is the same before and after decrementing";
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
    public class wDifference : WinWindow
    {
        
        public wDifference(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btninterestCreditsDifferentOptionRadioButton";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Rate on balances is different after decrementing";
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
    public class wCashBalanceRate : WinWindow
    {
        
        public wCashBalanceRate(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sprCashBalanceRates";
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
    public class wSimplelinearizationWindow : WinWindow
    {
        
        public wSimplelinearizationWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radSimpleLinearization";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton UISimplelinearizationRadioButton
        {
            get
            {
                if ((this.mUISimplelinearizationRadioButton == null))
                {
                    this.mUISimplelinearizationRadioButton = new WinRadioButton(this);
                    #region Search Criteria
                    this.mUISimplelinearizationRadioButton.SearchProperties[WinRadioButton.PropertyNames.Name] = "Simple linearization";
                    this.mUISimplelinearizationRadioButton.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUISimplelinearizationRadioButton;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mUISimplelinearizationRadioButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wLinearizationwithbreWindow : WinWindow
    {
        
        public wLinearizationwithbreWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radLinearizationWithBreakpoint";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton UILinearizationwithbreRadioButton
        {
            get
            {
                if ((this.mUILinearizationwithbreRadioButton == null))
                {
                    this.mUILinearizationwithbreRadioButton = new WinRadioButton(this);
                    #region Search Criteria
                    this.mUILinearizationwithbreRadioButton.SearchProperties[WinRadioButton.PropertyNames.Name] = "Linearization with breakpoint";
                    this.mUILinearizationwithbreRadioButton.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUILinearizationwithbreRadioButton;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mUILinearizationwithbreRadioButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wHistoricalvaluesWindow : WinWindow
    {
        
        public wHistoricalvaluesWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radHistoricalValues";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton UIHistoricalvaluesRadioButton
        {
            get
            {
                if ((this.mUIHistoricalvaluesRadioButton == null))
                {
                    this.mUIHistoricalvaluesRadioButton = new WinRadioButton(this);
                    #region Search Criteria
                    this.mUIHistoricalvaluesRadioButton.SearchProperties[WinRadioButton.PropertyNames.Name] = "Historical values";
                    this.mUIHistoricalvaluesRadioButton.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIHistoricalvaluesRadioButton;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mUIHistoricalvaluesRadioButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wCustomcodeWindow : WinWindow
    {
        
        public wCustomcodeWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnCustomCode";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton UICustomcodeRadioButton
        {
            get
            {
                if ((this.mUICustomcodeRadioButton == null))
                {
                    this.mUICustomcodeRadioButton = new WinRadioButton(this);
                    #region Search Criteria
                    this.mUICustomcodeRadioButton.SearchProperties[WinRadioButton.PropertyNames.Name] = "Custom code";
                    this.mUICustomcodeRadioButton.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUICustomcodeRadioButton;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mUICustomcodeRadioButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wCom_cbo : WinWindow
    {
        
        public wCom_cbo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains));
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
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
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "Open";
                    this.mbtn.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
    public class wFreezePayCreditsAtAge_TXT : WinWindow
    {
        
        public wFreezePayCreditsAtAge_TXT(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditConstant";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txtFreezePayCreditsAtAge txtFreezePayCreditsAtAge
        {
            get
            {
                if ((this.mtxtFreezePayCreditsAtAge == null))
                {
                    this.mtxtFreezePayCreditsAtAge = new txtFreezePayCreditsAtAge(this);
                }
                return this.mtxtFreezePayCreditsAtAge;
            }
        }
        #endregion
        
        #region Fields
        private txtFreezePayCreditsAtAge mtxtFreezePayCreditsAtAge;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txtFreezePayCreditsAtAge : WinEdit
    {
        
        public txtFreezePayCreditsAtAge(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
                    this.mtxt.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
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
    public class wRateOnBalancesIsDiffer : WinWindow
    {
        
        public wRateOnBalancesIsDiffer(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btninterestCreditsDifferentOptionRadioButton";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton rdRateOnBalancesIsDiffer
        {
            get
            {
                if ((this.mrdRateOnBalancesIsDiffer == null))
                {
                    this.mrdRateOnBalancesIsDiffer = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdRateOnBalancesIsDiffer.SearchProperties[WinRadioButton.PropertyNames.Name] = "Rate on balances is different after decrementing";
                    this.mrdRateOnBalancesIsDiffer.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mrdRateOnBalancesIsDiffer.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdRateOnBalancesIsDiffer;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdRateOnBalancesIsDiffer;
        #endregion
    }
}
