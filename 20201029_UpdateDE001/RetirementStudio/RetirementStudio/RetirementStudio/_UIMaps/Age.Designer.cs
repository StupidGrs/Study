﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.AgeClasses
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
    public partial class Age
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
        public wValuationmonthandday wValuationmonthandday
        {
            get
            {
                if ((this.mwValuationmonthandday == null))
                {
                    this.mwValuationmonthandday = new wValuationmonthandday(this);
                }
                return this.mwValuationmonthandday;
            }
        }
        
        public wOtherdate wOtherdate
        {
            get
            {
                if ((this.mwOtherdate == null))
                {
                    this.mwOtherdate = new wOtherdate(this);
                }
                return this.mwOtherdate;
            }
        }
        
        public wAgeRoundingRule wAgeRoundingRule
        {
            get
            {
                if ((this.mwAgeRoundingRule == null))
                {
                    this.mwAgeRoundingRule = new wAgeRoundingRule(this);
                }
                return this.mwAgeRoundingRule;
            }
        }
        #endregion
        
        #region Fields
        private wValuationmonthandday mwValuationmonthandday;
        
        private wOtherdate mwOtherdate;
        
        private wAgeRoundingRule mwAgeRoundingRule;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wValuationmonthandday : WinWindow
    {
        
        public wValuationmonthandday(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radValuationMonth";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Valuation month and day";
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
    public class wOtherdate : WinWindow
    {
        
        public wOtherdate(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radOtherMonth";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "Other date";
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
    public class wAgeRoundingRule : WinWindow
    {
        
        public wAgeRoundingRule(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboRoundingRule";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Alignment";
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