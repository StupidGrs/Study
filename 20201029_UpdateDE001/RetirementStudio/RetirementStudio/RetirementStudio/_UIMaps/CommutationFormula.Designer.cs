﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.CommutationFormulaClasses
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
    public partial class CommutationFormula
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
        public wPOfpension wPOfpension
        {
            get
            {
                if ((this.mwPOfpension == null))
                {
                    this.mwPOfpension = new wPOfpension(this);
                }
                return this.mwPOfpension;
            }
        }
        
        public wLumpSumIs wLumpSumIs
        {
            get
            {
                if ((this.mwLumpSumIs == null))
                {
                    this.mwLumpSumIs = new wLumpSumIs(this);
                }
                return this.mwLumpSumIs;
            }
        }
        #endregion
        
        #region Fields
        private wPOfpension mwPOfpension;
        
        private wLumpSumIs mwLumpSumIs;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wPOfpension : WinWindow
    {
        
        public wPOfpension(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "rdPercentOfPension";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "% of pension";
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
    public class wLumpSumIs : WinWindow
    {
        
        public wLumpSumIs(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudPercentAmount";
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
        public WinEdit UINudPercentAmountEdit1
        {
            get
            {
                if ((this.mUINudPercentAmountEdit1 == null))
                {
                    this.mUINudPercentAmountEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINudPercentAmountEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINudPercentAmountEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINudPercentAmountEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINudPercentAmountEdit1;
        #endregion
    }
}