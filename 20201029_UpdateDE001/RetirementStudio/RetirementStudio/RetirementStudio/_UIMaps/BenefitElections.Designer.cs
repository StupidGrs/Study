﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.BenefitElectionsClasses
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
    public partial class BenefitElections
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
        public wElectionPercentage_txt wElectionPercentage_txt
        {
            get
            {
                if ((this.mwElectionPercentage_txt == null))
                {
                    this.mwElectionPercentage_txt = new wElectionPercentage_txt(this);
                }
                return this.mwElectionPercentage_txt;
            }
        }
        
        public wButton_V wButton_V
        {
            get
            {
                if ((this.mwButton_V == null))
                {
                    this.mwButton_V = new wButton_V(this);
                }
                return this.mwButton_V;
            }
        }
        
        public wButton_Percent wButton_Percent
        {
            get
            {
                if ((this.mwButton_Percent == null))
                {
                    this.mwButton_Percent = new wButton_Percent(this);
                }
                return this.mwButton_Percent;
            }
        }
        
        public wButton_T wButton_T
        {
            get
            {
                if ((this.mwButton_T == null))
                {
                    this.mwButton_T = new wButton_T(this);
                }
                return this.mwButton_T;
            }
        }
        
        public wElectionPercentage_cbo wElectionPercentage_cbo
        {
            get
            {
                if ((this.mwElectionPercentage_cbo == null))
                {
                    this.mwElectionPercentage_cbo = new wElectionPercentage_cbo(this);
                }
                return this.mwElectionPercentage_cbo;
            }
        }
        
        public wElectionTable_cbo wElectionTable_cbo
        {
            get
            {
                if ((this.mwElectionTable_cbo == null))
                {
                    this.mwElectionTable_cbo = new wElectionTable_cbo(this);
                }
                return this.mwElectionTable_cbo;
            }
        }
        
        public wAdjustments wAdjustments
        {
            get
            {
                if ((this.mwAdjustments == null))
                {
                    this.mwAdjustments = new wAdjustments(this);
                }
                return this.mwAdjustments;
            }
        }
        
        public wAdjustment1_P wAdjustment1_P
        {
            get
            {
                if ((this.mwAdjustment1_P == null))
                {
                    this.mwAdjustment1_P = new wAdjustment1_P(this);
                }
                return this.mwAdjustment1_P;
            }
        }
        
        public wAdjustment1Operat wAdjustment1Operat
        {
            get
            {
                if ((this.mwAdjustment1Operat == null))
                {
                    this.mwAdjustment1Operat = new wAdjustment1Operat(this);
                }
                return this.mwAdjustment1Operat;
            }
        }
        
        public wComm_P_txt wComm_P_txt
        {
            get
            {
                if ((this.mwComm_P_txt == null))
                {
                    this.mwComm_P_txt = new wComm_P_txt(this);
                }
                return this.mwComm_P_txt;
            }
        }
        #endregion
        
        #region Fields
        private wElectionPercentage_txt mwElectionPercentage_txt;
        
        private wButton_V mwButton_V;
        
        private wButton_Percent mwButton_Percent;
        
        private wButton_T mwButton_T;
        
        private wElectionPercentage_cbo mwElectionPercentage_cbo;
        
        private wElectionTable_cbo mwElectionTable_cbo;
        
        private wAdjustments mwAdjustments;
        
        private wAdjustment1_P mwAdjustment1_P;
        
        private wAdjustment1Operat mwAdjustment1Operat;
        
        private wComm_P_txt mwComm_P_txt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wElectionPercentage_txt : WinWindow
    {
        
        public wElectionPercentage_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditRate";
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
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UI_numEditRateEdit1
        {
            get
            {
                if ((this.mUI_numEditRateEdit1 == null))
                {
                    this.mUI_numEditRateEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUI_numEditRateEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUI_numEditRateEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUI_numEditRateEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUI_numEditRateEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wButton_V : WinWindow
    {
        
        public wButton_V(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnVariable";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btnV
        {
            get
            {
                if ((this.mbtnV == null))
                {
                    this.mbtnV = new WinButton(this);
                    #region Search Criteria
                    this.mbtnV.SearchProperties[WinButton.PropertyNames.Name] = "V";
                    this.mbtnV.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mbtnV.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtnV;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtnV;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wButton_Percent : WinWindow
    {
        
        public wButton_Percent(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnRate";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btnPercent
        {
            get
            {
                if ((this.mbtnPercent == null))
                {
                    this.mbtnPercent = new WinButton(this);
                    #region Search Criteria
                    this.mbtnPercent.SearchProperties[WinButton.PropertyNames.Name] = "%";
                    this.mbtnPercent.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mbtnPercent.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtnPercent;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtnPercent;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wButton_T : WinWindow
    {
        
        public wButton_T(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnTable";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btnT
        {
            get
            {
                if ((this.mbtnT == null))
                {
                    this.mbtnT = new WinButton(this);
                    #region Search Criteria
                    this.mbtnT.SearchProperties[WinButton.PropertyNames.Name] = "T";
                    this.mbtnT.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mbtnT.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtnT;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtnT;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wElectionPercentage_cbo : WinWindow
    {
        
        public wElectionPercentage_cbo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_cboVariable";
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
                    this.mcbo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
    public class wElectionTable_cbo : WinWindow
    {
        
        public wElectionTable_cbo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_cboTableName";
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
    public class wAdjustments : WinWindow
    {
        
        public wAdjustments(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbxAdjustments";
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
                    this.mchk.SearchProperties[WinCheckBox.PropertyNames.Name] = "Adjustments";
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
    public class wAdjustment1_P : WinWindow
    {
        
        public wAdjustment1_P(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnRate";
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
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "%";
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
    public class wAdjustment1Operat : WinWindow
    {
        
        public wAdjustment1Operat(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cmbAdjustment1Operator";
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
    public class wComm_P_txt : WinWindow
    {
        
        public wComm_P_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditRate";
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "2";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
        public WinEdit UI_numEditRateEdit1
        {
            get
            {
                if ((this.mUI_numEditRateEdit1 == null))
                {
                    this.mUI_numEditRateEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUI_numEditRateEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUI_numEditRateEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUI_numEditRateEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUI_numEditRateEdit1;
        #endregion
    }
}