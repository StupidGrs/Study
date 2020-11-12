﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.MaxPensionDefinitionClasses
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
    public partial class MaxPensionDefinition
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
        public wStandard wStandard
        {
            get
            {
                if ((this.mwStandard == null))
                {
                    this.mwStandard = new wStandard(this);
                }
                return this.mwStandard;
            }
        }
        
        public wCustomCode wCustomCode
        {
            get
            {
                if ((this.mwCustomCode == null))
                {
                    this.mwCustomCode = new wCustomCode(this);
                }
                return this.mwCustomCode;
            }
        }
        
        public wMaximumPensionFormula wMaximumPensionFormula
        {
            get
            {
                if ((this.mwMaximumPensionFormula == null))
                {
                    this.mwMaximumPensionFormula = new wMaximumPensionFormula(this);
                }
                return this.mwMaximumPensionFormula;
            }
        }
        
        public wEarlyRetirementFactors wEarlyRetirementFactors
        {
            get
            {
                if ((this.mwEarlyRetirementFactors == null))
                {
                    this.mwEarlyRetirementFactors = new wEarlyRetirementFactors(this);
                }
                return this.mwEarlyRetirementFactors;
            }
        }
        
        public wLifeConversionFactors wLifeConversionFactors
        {
            get
            {
                if ((this.mwLifeConversionFactors == null))
                {
                    this.mwLifeConversionFactors = new wLifeConversionFactors(this);
                }
                return this.mwLifeConversionFactors;
            }
        }
        
        public wLateRetirementFactors wLateRetirementFactors
        {
            get
            {
                if ((this.mwLateRetirementFactors == null))
                {
                    this.mwLateRetirementFactors = new wLateRetirementFactors(this);
                }
                return this.mwLateRetirementFactors;
            }
        }
        
        public wERFForAgeReduction wERFForAgeReduction
        {
            get
            {
                if ((this.mwERFForAgeReduction == null))
                {
                    this.mwERFForAgeReduction = new wERFForAgeReduction(this);
                }
                return this.mwERFForAgeReduction;
            }
        }
        
        public wBridgeConversionFactors wBridgeConversionFactors
        {
            get
            {
                if ((this.mwBridgeConversionFactors == null))
                {
                    this.mwBridgeConversionFactors = new wBridgeConversionFactors(this);
                }
                return this.mwBridgeConversionFactors;
            }
        }
        
        public wAppliesToAllBenefits wAppliesToAllBenefits
        {
            get
            {
                if ((this.mwAppliesToAllBenefits == null))
                {
                    this.mwAppliesToAllBenefits = new wAppliesToAllBenefits(this);
                }
                return this.mwAppliesToAllBenefits;
            }
        }
        #endregion
        
        #region Fields
        private wStandard mwStandard;
        
        private wCustomCode mwCustomCode;
        
        private wMaximumPensionFormula mwMaximumPensionFormula;
        
        private wEarlyRetirementFactors mwEarlyRetirementFactors;
        
        private wLifeConversionFactors mwLifeConversionFactors;
        
        private wLateRetirementFactors mwLateRetirementFactors;
        
        private wERFForAgeReduction mwERFForAgeReduction;
        
        private wBridgeConversionFactors mwBridgeConversionFactors;
        
        private wAppliesToAllBenefits mwAppliesToAllBenefits;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard : WinWindow
    {
        
        public wStandard(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radStandard";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Standard";
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
    public class wCustomCode : WinWindow
    {
        
        public wCustomCode(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnCustomCode";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Custom code";
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
    public class wMaximumPensionFormula : WinWindow
    {
        
        public wMaximumPensionFormula(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboMaximumPensionFormula";
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
    public class wEarlyRetirementFactors : WinWindow
    {
        
        public wEarlyRetirementFactors(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboLifetimeEarlyRetirementFactors";
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
    public class wLifeConversionFactors : WinWindow
    {
        
        public wLifeConversionFactors(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboLifetimeConversionFactors";
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
    public class wLateRetirementFactors : WinWindow
    {
        
        public wLateRetirementFactors(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboLifetimeLateRetirementFactors";
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
    public class wERFForAgeReduction : WinWindow
    {
        
        public wERFForAgeReduction(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboERFForAgeReduction";
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
    public class wBridgeConversionFactors : WinWindow
    {
        
        public wBridgeConversionFactors(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboBridgeConversionFactors";
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
    public class wAppliesToAllBenefits : WinWindow
    {
        
        public wAppliesToAllBenefits(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboCostOfLiving";
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
}