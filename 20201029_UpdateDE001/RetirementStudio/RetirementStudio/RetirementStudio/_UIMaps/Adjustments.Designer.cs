﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.AdjustmentsClasses
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
    
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public partial class Adjustments
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
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
        public wLoadingFactor_V wLoadingFactor_V
        {
            get
            {
                if ((this.mwLoadingFactor_V == null))
                {
                    this.mwLoadingFactor_V = new wLoadingFactor_V(this);
                }
                return this.mwLoadingFactor_V;
            }
        }
        
        public wLoadingFactor_C wLoadingFactor_C
        {
            get
            {
                if ((this.mwLoadingFactor_C == null))
                {
                    this.mwLoadingFactor_C = new wLoadingFactor_C(this);
                }
                return this.mwLoadingFactor_C;
            }
        }
        
        public wLoadingFactor_T wLoadingFactor_T
        {
            get
            {
                if ((this.mwLoadingFactor_T == null))
                {
                    this.mwLoadingFactor_T = new wLoadingFactor_T(this);
                }
                return this.mwLoadingFactor_T;
            }
        }
        
        public wLoadingFactor_cboV wLoadingFactor_cboV
        {
            get
            {
                if ((this.mwLoadingFactor_cboV == null))
                {
                    this.mwLoadingFactor_cboV = new wLoadingFactor_cboV(this);
                }
                return this.mwLoadingFactor_cboV;
            }
        }
        
        public wLoadingFactor_cboT wLoadingFactor_cboT
        {
            get
            {
                if ((this.mwLoadingFactor_cboT == null))
                {
                    this.mwLoadingFactor_cboT = new wLoadingFactor_cboT(this);
                }
                return this.mwLoadingFactor_cboT;
            }
        }
        
        public wLoadingFactor_txt wLoadingFactor_txt
        {
            get
            {
                if ((this.mwLoadingFactor_txt == null))
                {
                    this.mwLoadingFactor_txt = new wLoadingFactor_txt(this);
                }
                return this.mwLoadingFactor_txt;
            }
        }
        
        public wApplyTo wApplyTo
        {
            get
            {
                if ((this.mwApplyTo == null))
                {
                    this.mwApplyTo = new wApplyTo(this);
                }
                return this.mwApplyTo;
            }
        }
        #endregion
        
        #region Fields
        private wLoadingFactor_V mwLoadingFactor_V;
        
        private wLoadingFactor_C mwLoadingFactor_C;
        
        private wLoadingFactor_T mwLoadingFactor_T;
        
        private wLoadingFactor_cboV mwLoadingFactor_cboV;
        
        private wLoadingFactor_cboT mwLoadingFactor_cboT;
        
        private wLoadingFactor_txt mwLoadingFactor_txt;
        
        private wApplyTo mwApplyTo;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_V : WinWindow
    {
        
        public wLoadingFactor_V(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_C : WinWindow
    {
        
        public wLoadingFactor_C(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnConstant";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btnC
        {
            get
            {
                if ((this.mbtnC == null))
                {
                    this.mbtnC = new WinButton(this);
                    #region Search Criteria
                    this.mbtnC.SearchProperties[WinButton.PropertyNames.Name] = "C";
                    this.mbtnC.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtnC;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtnC;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_T : WinWindow
    {
        
        public wLoadingFactor_T(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_cboV : WinWindow
    {
        
        public wLoadingFactor_cboV(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_cboT : WinWindow
    {
        
        public wLoadingFactor_cboT(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wLoadingFactor_txt : WinWindow
    {
        
        public wLoadingFactor_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditConstant";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txtEdit txtEdit
        {
            get
            {
                if ((this.mtxtEdit == null))
                {
                    this.mtxtEdit = new txtEdit(this);
                }
                return this.mtxtEdit;
            }
        }
        #endregion
        
        #region Fields
        private txtEdit mtxtEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class txtEdit : WinEdit
    {
        
        public txtEdit(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class wApplyTo : WinWindow
    {
        
        public wApplyTo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboApplyTo";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinComboBox cboApplyTo
        {
            get
            {
                if ((this.mcboApplyTo == null))
                {
                    this.mcboApplyTo = new WinComboBox(this);
                    #region Search Criteria
                    this.mcboApplyTo.SearchProperties[WinComboBox.PropertyNames.Name] = "Apply to";
                    this.mcboApplyTo.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mcboApplyTo;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mcboApplyTo;
        #endregion
    }
}
