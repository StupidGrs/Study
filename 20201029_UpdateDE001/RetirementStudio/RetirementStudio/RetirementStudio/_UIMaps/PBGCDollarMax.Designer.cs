﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.PBGCDollarMaxClasses
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
    public partial class PBGCDollarMax
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
        
        public wUserDefinedFOPAdjustment wUserDefinedFOPAdjustment
        {
            get
            {
                if ((this.mwUserDefinedFOPAdjustment == null))
                {
                    this.mwUserDefinedFOPAdjustment = new wUserDefinedFOPAdjustment(this);
                }
                return this.mwUserDefinedFOPAdjustment;
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
        
        public wIgnoreAgeAdjustment wIgnoreAgeAdjustment
        {
            get
            {
                if ((this.mwIgnoreAgeAdjustment == null))
                {
                    this.mwIgnoreAgeAdjustment = new wIgnoreAgeAdjustment(this);
                }
                return this.mwIgnoreAgeAdjustment;
            }
        }
        
        public wLawYear_ValuationYearPlus wLawYear_ValuationYearPlus
        {
            get
            {
                if ((this.mwLawYear_ValuationYearPlus == null))
                {
                    this.mwLawYear_ValuationYearPlus = new wLawYear_ValuationYearPlus(this);
                }
                return this.mwLawYear_ValuationYearPlus;
            }
        }
        
        public wLawYear_SpecifiedYear wLawYear_SpecifiedYear
        {
            get
            {
                if ((this.mwLawYear_SpecifiedYear == null))
                {
                    this.mwLawYear_SpecifiedYear = new wLawYear_SpecifiedYear(this);
                }
                return this.mwLawYear_SpecifiedYear;
            }
        }
        
        public wLawYear_ValuationYearsPlus_txt wLawYear_ValuationYearsPlus_txt
        {
            get
            {
                if ((this.mwLawYear_ValuationYearsPlus_txt == null))
                {
                    this.mwLawYear_ValuationYearsPlus_txt = new wLawYear_ValuationYearsPlus_txt(this);
                }
                return this.mwLawYear_ValuationYearsPlus_txt;
            }
        }
        
        public wLawYear_SpecifiedYear_txt wLawYear_SpecifiedYear_txt
        {
            get
            {
                if ((this.mwLawYear_SpecifiedYear_txt == null))
                {
                    this.mwLawYear_SpecifiedYear_txt = new wLawYear_SpecifiedYear_txt(this);
                }
                return this.mwLawYear_SpecifiedYear_txt;
            }
        }
        
        public wFOP_GuaranteePeriod_txt wFOP_GuaranteePeriod_txt
        {
            get
            {
                if ((this.mwFOP_GuaranteePeriod_txt == null))
                {
                    this.mwFOP_GuaranteePeriod_txt = new wFOP_GuaranteePeriod_txt(this);
                }
                return this.mwFOP_GuaranteePeriod_txt;
            }
        }
        
        public wFOP_SurvivorPercent_txt wFOP_SurvivorPercent_txt
        {
            get
            {
                if ((this.mwFOP_SurvivorPercent_txt == null))
                {
                    this.mwFOP_SurvivorPercent_txt = new wFOP_SurvivorPercent_txt(this);
                }
                return this.mwFOP_SurvivorPercent_txt;
            }
        }
        
        public wFOP_FormOfPayment wFOP_FormOfPayment
        {
            get
            {
                if ((this.mwFOP_FormOfPayment == null))
                {
                    this.mwFOP_FormOfPayment = new wFOP_FormOfPayment(this);
                }
                return this.mwFOP_FormOfPayment;
            }
        }
        #endregion
        
        #region Fields
        private wStandard mwStandard;
        
        private wUserDefinedFOPAdjustment mwUserDefinedFOPAdjustment;
        
        private wCustomCode mwCustomCode;
        
        private wIgnoreAgeAdjustment mwIgnoreAgeAdjustment;
        
        private wLawYear_ValuationYearPlus mwLawYear_ValuationYearPlus;
        
        private wLawYear_SpecifiedYear mwLawYear_SpecifiedYear;
        
        private wLawYear_ValuationYearsPlus_txt mwLawYear_ValuationYearsPlus_txt;
        
        private wLawYear_SpecifiedYear_txt mwLawYear_SpecifiedYear_txt;
        
        private wFOP_GuaranteePeriod_txt mwFOP_GuaranteePeriod_txt;
        
        private wFOP_SurvivorPercent_txt mwFOP_SurvivorPercent_txt;
        
        private wFOP_FormOfPayment mwFOP_FormOfPayment;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard : WinWindow
    {
        
        public wStandard(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radStandardDefinition";
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
    public class wUserDefinedFOPAdjustment : WinWindow
    {
        
        public wUserDefinedFOPAdjustment(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radUserDefined";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "User-defined form of payment adjustment";
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
    public class wIgnoreAgeAdjustment : WinWindow
    {
        
        public wIgnoreAgeAdjustment(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "ckbIgnoreAgeAdjustment";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "Ignore age adjustment";
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
    public class wLawYear_ValuationYearPlus : WinWindow
    {
        
        public wLawYear_ValuationYearPlus(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radValuationYearPlus";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Valuation year plus";
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
    public class wLawYear_SpecifiedYear : WinWindow
    {
        
        public wLawYear_SpecifiedYear(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radSpecifiedYear";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Specified year";
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
    public class wLawYear_ValuationYearsPlus_txt : WinWindow
    {
        
        public wLawYear_ValuationYearsPlus_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudValuationYearPlus";
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
        public WinEdit txt1
        {
            get
            {
                if ((this.mtxt1 == null))
                {
                    this.mtxt1 = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mtxt1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wLawYear_SpecifiedYear_txt : WinWindow
    {
        
        public wLawYear_SpecifiedYear_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudSpecifiedYear";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
        public WinEdit txt1
        {
            get
            {
                if ((this.mtxt1 == null))
                {
                    this.mtxt1 = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mtxt1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFOP_GuaranteePeriod_txt : WinWindow
    {
        
        public wFOP_GuaranteePeriod_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditConstant";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
        public WinEdit txt1
        {
            get
            {
                if ((this.mtxt1 == null))
                {
                    this.mtxt1 = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mtxt1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFOP_SurvivorPercent_txt : WinWindow
    {
        
        public wFOP_SurvivorPercent_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditRate";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
        public WinEdit txt1
        {
            get
            {
                if ((this.mtxt1 == null))
                {
                    this.mtxt1 = new WinEdit(this);
                    #region Search Criteria
                    this.mtxt1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mtxt1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxt1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxt1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFOP_FormOfPayment : WinWindow
    {
        
        public wFOP_FormOfPayment(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboFormOfPayment";
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