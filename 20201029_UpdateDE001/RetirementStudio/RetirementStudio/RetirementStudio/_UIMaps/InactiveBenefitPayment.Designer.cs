﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.InactiveBenefitPaymentClasses
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
    public partial class InactiveBenefitPayment
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
        public wFPGrid wFPGrid
        {
            get
            {
                if ((this.mwFPGrid == null))
                {
                    this.mwFPGrid = new wFPGrid(this);
                }
                return this.mwFPGrid;
            }
        }
        
        public wCommon_V wCommon_V
        {
            get
            {
                if ((this.mwCommon_V == null))
                {
                    this.mwCommon_V = new wCommon_V(this);
                }
                return this.mwCommon_V;
            }
        }
        
        public wCommon_cbo wCommon_cbo
        {
            get
            {
                if ((this.mwCommon_cbo == null))
                {
                    this.mwCommon_cbo = new wCommon_cbo(this);
                }
                return this.mwCommon_cbo;
            }
        }
        
        public wCommon_C wCommon_C
        {
            get
            {
                if ((this.mwCommon_C == null))
                {
                    this.mwCommon_C = new wCommon_C(this);
                }
                return this.mwCommon_C;
            }
        }
        
        public wCommon_txt wCommon_txt
        {
            get
            {
                if ((this.mwCommon_txt == null))
                {
                    this.mwCommon_txt = new wCommon_txt(this);
                }
                return this.mwCommon_txt;
            }
        }
        #endregion
        
        #region Fields
        private wFPGrid mwFPGrid;
        
        private wCommon_V mwCommon_V;
        
        private wCommon_cbo mwCommon_cbo;
        
        private wCommon_C mwCommon_C;
        
        private wCommon_txt mwCommon_txt;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wFPGrid : WinWindow
    {
        
        public wFPGrid(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sprInactiveBenefit";
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
                    this.mgrid.SearchProperties[WinControl.PropertyNames.Name] = "Inactive Benefit";
                    this.mgrid.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
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
    public class wCommon_V : WinWindow
    {
        
        public wCommon_V(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnVariable";
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
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "V";
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
    public class wCommon_cbo : WinWindow
    {
        
        public wCommon_cbo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_cboVariable";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton UIOpenButton
        {
            get
            {
                if ((this.mUIOpenButton == null))
                {
                    this.mUIOpenButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIOpenButton.SearchProperties[WinButton.PropertyNames.Name] = "Open";
                    this.mUIOpenButton.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIOpenButton;
            }
        }
        
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
        private WinButton mUIOpenButton;
        
        private WinComboBox mcbo;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wCommon_C : WinWindow
    {
        
        public wCommon_C(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_btnConstant";
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
    public class wCommon_txt : WinWindow
    {
        
        public wCommon_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "_numEditConstant";
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
        public WinEdit UI_numEditConstantEdit1
        {
            get
            {
                if ((this.mUI_numEditConstantEdit1 == null))
                {
                    this.mUI_numEditConstantEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUI_numEditConstantEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUI_numEditConstantEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUI_numEditConstantEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUI_numEditConstantEdit1;
        #endregion
    }
}