﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.VestingClasses
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
    public partial class Vesting
    {
        
        /// <summary>
        /// RecordedMethod1
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WinClient clientBlankArea = this.wRetirementStudio.wStandard_BlankArea.clientBlankArea;
            #endregion

            // Click 'pnlPercentageChoices' client
            Mouse.Click(clientBlankArea, new Point(534, 120));
        }
        
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
        
        public wTable wTable
        {
            get
            {
                if ((this.mwTable == null))
                {
                    this.mwTable = new wTable(this);
                }
                return this.mwTable;
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
        
        public wStandard_VestingServiceDefinition wStandard_VestingServiceDefinition
        {
            get
            {
                if ((this.mwStandard_VestingServiceDefinition == null))
                {
                    this.mwStandard_VestingServiceDefinition = new wStandard_VestingServiceDefinition(this);
                }
                return this.mwStandard_VestingServiceDefinition;
            }
        }
        
        public wStandard_AddRow wStandard_AddRow
        {
            get
            {
                if ((this.mwStandard_AddRow == null))
                {
                    this.mwStandard_AddRow = new wStandard_AddRow(this);
                }
                return this.mwStandard_AddRow;
            }
        }
        
        public wStandard_FPGrid wStandard_FPGrid
        {
            get
            {
                if ((this.mwStandard_FPGrid == null))
                {
                    this.mwStandard_FPGrid = new wStandard_FPGrid(this);
                }
                return this.mwStandard_FPGrid;
            }
        }
        
        public wStandard_TBL_YearsOfService wStandard_TBL_YearsOfService
        {
            get
            {
                if ((this.mwStandard_TBL_YearsOfService == null))
                {
                    this.mwStandard_TBL_YearsOfService = new wStandard_TBL_YearsOfService(this);
                }
                return this.mwStandard_TBL_YearsOfService;
            }
        }
        
        public wStandard_TBL_VestingPercentage wStandard_TBL_VestingPercentage
        {
            get
            {
                if ((this.mwStandard_TBL_VestingPercentage == null))
                {
                    this.mwStandard_TBL_VestingPercentage = new wStandard_TBL_VestingPercentage(this);
                }
                return this.mwStandard_TBL_VestingPercentage;
            }
        }
        
        public wStandard_BlankArea wStandard_BlankArea
        {
            get
            {
                if ((this.mwStandard_BlankArea == null))
                {
                    this.mwStandard_BlankArea = new wStandard_BlankArea(this);
                }
                return this.mwStandard_BlankArea;
            }
        }
        
        public UIVestingViewWindow UIVestingViewWindow
        {
            get
            {
                if ((this.mUIVestingViewWindow == null))
                {
                    this.mUIVestingViewWindow = new UIVestingViewWindow(this);
                }
                return this.mUIVestingViewWindow;
            }
        }
        
        public wVestingRule wVestingRule
        {
            get
            {
                if ((this.mwVestingRule == null))
                {
                    this.mwVestingRule = new wVestingRule(this);
                }
                return this.mwVestingRule;
            }
        }
        
        public wVestingRadio wVestingRadio
        {
            get
            {
                if ((this.mwVestingRadio == null))
                {
                    this.mwVestingRadio = new wVestingRadio(this);
                }
                return this.mwVestingRadio;
            }
        }
        
        public wTable_Table wTable_Table
        {
            get
            {
                if ((this.mwTable_Table == null))
                {
                    this.mwTable_Table = new wTable_Table(this);
                }
                return this.mwTable_Table;
            }
        }
        
        public wTable_Index1 wTable_Index1
        {
            get
            {
                if ((this.mwTable_Index1 == null))
                {
                    this.mwTable_Index1 = new wTable_Index1(this);
                }
                return this.mwTable_Index1;
            }
        }
        
        public wTable_Setback wTable_Setback
        {
            get
            {
                if ((this.mwTable_Setback == null))
                {
                    this.mwTable_Setback = new wTable_Setback(this);
                }
                return this.mwTable_Setback;
            }
        }
        
        public wTable_Index2 wTable_Index2
        {
            get
            {
                if ((this.mwTable_Index2 == null))
                {
                    this.mwTable_Index2 = new wTable_Index2(this);
                }
                return this.mwTable_Index2;
            }
        }
        #endregion
        
        #region Fields
        private wStandard mwStandard;
        
        private wTable mwTable;
        
        private wCustomCode mwCustomCode;
        
        private wStandard_VestingServiceDefinition mwStandard_VestingServiceDefinition;
        
        private wStandard_AddRow mwStandard_AddRow;
        
        private wStandard_FPGrid mwStandard_FPGrid;
        
        private wStandard_TBL_YearsOfService mwStandard_TBL_YearsOfService;
        
        private wStandard_TBL_VestingPercentage mwStandard_TBL_VestingPercentage;
        
        private wStandard_BlankArea mwStandard_BlankArea;
        
        private UIVestingViewWindow mUIVestingViewWindow;
        
        private wVestingRule mwVestingRule;
        
        private wVestingRadio mwVestingRadio;
        
        private wTable_Table mwTable_Table;
        
        private wTable_Index1 mwTable_Index1;
        
        private wTable_Setback mwTable_Setback;
        
        private wTable_Index2 mwTable_Index2;
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
        public WinRadioButton rdStandard
        {
            get
            {
                if ((this.mrdStandard == null))
                {
                    this.mrdStandard = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdStandard.SearchProperties[WinRadioButton.PropertyNames.Name] = "Standard";
                    this.mrdStandard.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdStandard;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdStandard;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wTable : WinWindow
    {
        
        public wTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "radTable";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinRadioButton rdTable
        {
            get
            {
                if ((this.mrdTable == null))
                {
                    this.mrdTable = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdTable.SearchProperties[WinRadioButton.PropertyNames.Name] = "Table";
                    this.mrdTable.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdTable;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdTable;
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
        public WinRadioButton rdCustomCode
        {
            get
            {
                if ((this.mrdCustomCode == null))
                {
                    this.mrdCustomCode = new WinRadioButton(this);
                    #region Search Criteria
                    this.mrdCustomCode.SearchProperties[WinRadioButton.PropertyNames.Name] = "Custom code";
                    this.mrdCustomCode.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mrdCustomCode;
            }
        }
        #endregion
        
        #region Fields
        private WinRadioButton mrdCustomCode;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard_VestingServiceDefinition : WinWindow
    {
        
        public wStandard_VestingServiceDefinition(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboVestingServiceDefinition";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinComboBox cboVestingServiceDefinition
        {
            get
            {
                if ((this.mcboVestingServiceDefinition == null))
                {
                    this.mcboVestingServiceDefinition = new WinComboBox(this);
                    #region Search Criteria
                    this.mcboVestingServiceDefinition.SearchProperties[WinComboBox.PropertyNames.Name] = "Vesting service definition";
                    this.mcboVestingServiceDefinition.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mcboVestingServiceDefinition;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mcboVestingServiceDefinition;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard_AddRow : WinWindow
    {
        
        public wStandard_AddRow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cmdAddYears";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinButton btnAddRow
        {
            get
            {
                if ((this.mbtnAddRow == null))
                {
                    this.mbtnAddRow = new WinButton(this);
                    #region Search Criteria
                    this.mbtnAddRow.SearchProperties[WinButton.PropertyNames.Name] = "Add Row";
                    this.mbtnAddRow.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mbtnAddRow;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mbtnAddRow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard_FPGrid : WinWindow
    {
        
        public wStandard_FPGrid(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sprYears";
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
    public class wStandard_TBL_YearsOfService : WinWindow
    {
        
        public wStandard_TBL_YearsOfService(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "ctlNumEditor";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit txtYearsOfService
        {
            get
            {
                if ((this.mtxtYearsOfService == null))
                {
                    this.mtxtYearsOfService = new WinEdit(this);
                    #region Search Criteria
                    this.mtxtYearsOfService.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mtxtYearsOfService.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxtYearsOfService;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxtYearsOfService;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard_TBL_VestingPercentage : WinWindow
    {
        
        public wStandard_TBL_VestingPercentage(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "ctlNumEditor";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit txtVestingPercentage
        {
            get
            {
                if ((this.mtxtVestingPercentage == null))
                {
                    this.mtxtVestingPercentage = new WinEdit(this);
                    #region Search Criteria
                    this.mtxtVestingPercentage.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mtxtVestingPercentage.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mtxtVestingPercentage;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mtxtVestingPercentage;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard_BlankArea : WinWindow
    {
        
        public wStandard_BlankArea(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "pnlPercentageChoices";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinClient clientBlankArea
        {
            get
            {
                if ((this.mclientBlankArea == null))
                {
                    this.mclientBlankArea = new WinClient(this);
                    #region Search Criteria
                    this.mclientBlankArea.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mclientBlankArea;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mclientBlankArea;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIVestingViewWindow : WinWindow
    {
        
        public UIVestingViewWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "VestingView";
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinClient UIVestingViewClient
        {
            get
            {
                if ((this.mUIVestingViewClient == null))
                {
                    this.mUIVestingViewClient = new WinClient(this);
                    #region Search Criteria
                    this.mUIVestingViewClient.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUIVestingViewClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIVestingViewClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wVestingRule : WinWindow
    {
        
        public wVestingRule(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cmbVestingRule";
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
    public class wVestingRadio : WinWindow
    {
        
        public wVestingRadio(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cmbVestingRatio";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Vesting Ratio";
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
    public class wTable_Table : WinWindow
    {
        
        public wTable_Table(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboTable";
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
                    this.mcbo.SearchProperties[WinComboBox.PropertyNames.Name] = "Standard";
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
    public class wTable_Index1 : WinWindow
    {
        
        public wTable_Index1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboIndex1";
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
    public class wTable_Setback : WinWindow
    {
        
        public wTable_Setback(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudSetback";
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
        public WinEdit UINudSetbackEdit1
        {
            get
            {
                if ((this.mUINudSetbackEdit1 == null))
                {
                    this.mUINudSetbackEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUINudSetbackEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUINudSetbackEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUINudSetbackEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINudSetbackEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wTable_Index2 : WinWindow
    {
        
        public wTable_Index2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboIndex2";
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