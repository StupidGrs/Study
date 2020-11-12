﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.BreakFieldTextSubstitutionClasses
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
    public partial class BreakFieldTextSubstitution
    {
        
        /// <summary>
        /// RecordedMethod1 - Use 'RecordedMethod1Params' to pass parameters into this method.
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinClient grid = this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid;
            WinEdit txt = this.wBreakfieldtextsubstitution.wCommon_txt.txt;
            WinButton btn = this.wBreakfieldtextsubstitution.wOK.btn;
            #endregion

            // Double-Click 'Break field' client
            Mouse.DoubleClick(grid, new Point(94, 28));

            // Type 'a' in text box
            txt.Text = this.RecordedMethod1Params.txtText;

            // Double-Click 'Break field' client
            Mouse.DoubleClick(grid, new Point(228, 31));

            // Type 'b' in text box
            txt.Text = this.RecordedMethod1Params.txtText1;

            // Type '{Tab}' in text box
            Keyboard.SendKeys(txt, this.RecordedMethod1Params.txtSendKeys, ModifierKeys.None);

            // Type '{PageUp}{End}{Home}' in 'Break field' client
            Keyboard.SendKeys(grid, this.RecordedMethod1Params.gridSendKeys, ModifierKeys.None);

            // Click 'OK' button
            Mouse.Click(btn, new Point(17, 3));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public wBreakfieldtextsubstitution wBreakfieldtextsubstitution
        {
            get
            {
                if ((this.mwBreakfieldtextsubstitution == null))
                {
                    this.mwBreakfieldtextsubstitution = new wBreakfieldtextsubstitution();
                }
                return this.mwBreakfieldtextsubstitution;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private wBreakfieldtextsubstitution mwBreakfieldtextsubstitution;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// Type 'a' in text box
        /// </summary>
        public string txtText = "a";
        
        /// <summary>
        /// Type 'b' in text box
        /// </summary>
        public string txtText1 = "b";
        
        /// <summary>
        /// Type '{Tab}' in text box
        /// </summary>
        public string txtSendKeys = "{Tab}";
        
        /// <summary>
        /// Type '{PageUp}{End}{Home}' in 'Break field' client
        /// </summary>
        public string gridSendKeys = "{PageUp}{End}{Home}";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wBreakfieldtextsubstitution : WinWindow
    {
        
        public wBreakfieldtextsubstitution()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Break field text substitution";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Break field text substitution");
            #endregion
        }
        
        #region Properties
        public wTextSubstitution_FPGrid wTextSubstitution_FPGrid
        {
            get
            {
                if ((this.mwTextSubstitution_FPGrid == null))
                {
                    this.mwTextSubstitution_FPGrid = new wTextSubstitution_FPGrid(this);
                }
                return this.mwTextSubstitution_FPGrid;
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
        
        public wOK wOK
        {
            get
            {
                if ((this.mwOK == null))
                {
                    this.mwOK = new wOK(this);
                }
                return this.mwOK;
            }
        }
        #endregion
        
        #region Fields
        private wTextSubstitution_FPGrid mwTextSubstitution_FPGrid;
        
        private wCommon_txt mwCommon_txt;
        
        private wOK mwOK;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wTextSubstitution_FPGrid : WinWindow
    {
        
        public wTextSubstitution_FPGrid(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sprTextSubstitution";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Break field text substitution");
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
                    this.mgrid.SearchProperties[WinControl.PropertyNames.Name] = "Break field";
                    this.mgrid.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mgrid.WindowTitles.Add("Break field text substitution");
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
    public class wCommon_txt : WinWindow
    {
        
        public wCommon_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains));
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Break field text substitution");
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
                    this.mtxt.WindowTitles.Add("Break field text substitution");
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
    public class wOK : WinWindow
    {
        
        public wOK(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnOk";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Break field text substitution");
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
                    this.mbtn.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mbtn.WindowTitles.Add("Break field text substitution");
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
}
