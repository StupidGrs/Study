﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace RetirementStudio._UIMaps.UnitFormulaClasses
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
    public partial class UnitFormula
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
        
        public wService wService
        {
            get
            {
                if ((this.mwService == null))
                {
                    this.mwService = new wService(this);
                }
                return this.mwService;
            }
        }
        
        public wStopAccrualAt_V wStopAccrualAt_V
        {
            get
            {
                if ((this.mwStopAccrualAt_V == null))
                {
                    this.mwStopAccrualAt_V = new wStopAccrualAt_V(this);
                }
                return this.mwStopAccrualAt_V;
            }
        }
        
        public wStopAccuralAt_C wStopAccuralAt_C
        {
            get
            {
                if ((this.mwStopAccuralAt_C == null))
                {
                    this.mwStopAccuralAt_C = new wStopAccuralAt_C(this);
                }
                return this.mwStopAccuralAt_C;
            }
        }
        
        public wStopAccuralAt_cbo wStopAccuralAt_cbo
        {
            get
            {
                if ((this.mwStopAccuralAt_cbo == null))
                {
                    this.mwStopAccuralAt_cbo = new wStopAccuralAt_cbo(this);
                }
                return this.mwStopAccuralAt_cbo;
            }
        }
        
        public wStopAccuralAt_txt wStopAccuralAt_txt
        {
            get
            {
                if ((this.mwStopAccuralAt_txt == null))
                {
                    this.mwStopAccuralAt_txt = new wStopAccuralAt_txt(this);
                }
                return this.mwStopAccuralAt_txt;
            }
        }
        
        public wRateTiersBasedOn wRateTiersBasedOn
        {
            get
            {
                if ((this.mwRateTiersBasedOn == null))
                {
                    this.mwRateTiersBasedOn = new wRateTiersBasedOn(this);
                }
                return this.mwRateTiersBasedOn;
            }
        }
        
        public wNumberOfRateTiers wNumberOfRateTiers
        {
            get
            {
                if ((this.mwNumberOfRateTiers == null))
                {
                    this.mwNumberOfRateTiers = new wNumberOfRateTiers(this);
                }
                return this.mwNumberOfRateTiers;
            }
        }
        
        public FPGrid FPGrid
        {
            get
            {
                if ((this.mFPGrid == null))
                {
                    this.mFPGrid = new FPGrid(this);
                }
                return this.mFPGrid;
            }
        }
        
        public wLimitServiceTo wLimitServiceTo
        {
            get
            {
                if ((this.mwLimitServiceTo == null))
                {
                    this.mwLimitServiceTo = new wLimitServiceTo(this);
                }
                return this.mwLimitServiceTo;
            }
        }
        
        public wFormulaTable_txt wFormulaTable_txt
        {
            get
            {
                if ((this.mwFormulaTable_txt == null))
                {
                    this.mwFormulaTable_txt = new wFormulaTable_txt(this);
                }
                return this.mwFormulaTable_txt;
            }
        }
        
        public wToServiceInSameTier wToServiceInSameTier
        {
            get
            {
                if ((this.mwToServiceInSameTier == null))
                {
                    this.mwToServiceInSameTier = new wToServiceInSameTier(this);
                }
                return this.mwToServiceInSameTier;
            }
        }
        
        public wAtexitagetoallservic wAtexitagetoallservic
        {
            get
            {
                if ((this.mwAtexitagetoallservic == null))
                {
                    this.mwAtexitagetoallservic = new wAtexitagetoallservic(this);
                }
                return this.mwAtexitagetoallservic;
            }
        }
        #endregion
        
        #region Fields
        private wStandard mwStandard;
        
        private wCustomCode mwCustomCode;
        
        private wService mwService;
        
        private wStopAccrualAt_V mwStopAccrualAt_V;
        
        private wStopAccuralAt_C mwStopAccuralAt_C;
        
        private wStopAccuralAt_cbo mwStopAccuralAt_cbo;
        
        private wStopAccuralAt_txt mwStopAccuralAt_txt;
        
        private wRateTiersBasedOn mwRateTiersBasedOn;
        
        private wNumberOfRateTiers mwNumberOfRateTiers;
        
        private FPGrid mFPGrid;
        
        private wLimitServiceTo mwLimitServiceTo;
        
        private wFormulaTable_txt mwFormulaTable_txt;
        
        private wToServiceInSameTier mwToServiceInSameTier;
        
        private wAtexitagetoallservic mwAtexitagetoallservic;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStandard : WinWindow
    {
        
        public wStandard(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnStandardDefinition";
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
    public class wService : WinWindow
    {
        
        public wService(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboService";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinComboBox cboService
        {
            get
            {
                if ((this.mcboService == null))
                {
                    this.mcboService = new WinComboBox(this);
                    #region Search Criteria
                    this.mcboService.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mcboService;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mcboService;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStopAccrualAt_V : WinWindow
    {
        
        public wStopAccrualAt_V(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStopAccuralAt_C : WinWindow
    {
        
        public wStopAccuralAt_C(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStopAccuralAt_cbo : WinWindow
    {
        
        public wStopAccuralAt_cbo(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wStopAccuralAt_txt : WinWindow
    {
        
        public wStopAccuralAt_txt(UITestControl searchLimitContainer) : 
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
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
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wRateTiersBasedOn : WinWindow
    {
        
        public wRateTiersBasedOn(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cboRateTiersBasis";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinComboBox cboRateTiersBasedOn
        {
            get
            {
                if ((this.mcboRateTiersBasedOn == null))
                {
                    this.mcboRateTiersBasedOn = new WinComboBox(this);
                    #region Search Criteria
                    this.mcboRateTiersBasedOn.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mcboRateTiersBasedOn.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mcboRateTiersBasedOn;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mcboRateTiersBasedOn;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wNumberOfRateTiers : WinWindow
    {
        
        public wNumberOfRateTiers(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudNumberOfRateTiers";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txtEdit1 txtEdit
        {
            get
            {
                if ((this.mtxtEdit == null))
                {
                    this.mtxtEdit = new txtEdit1(this);
                }
                return this.mtxtEdit;
            }
        }
        #endregion
        
        #region Fields
        private txtEdit1 mtxtEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txtEdit1 : WinEdit
    {
        
        public txtEdit1(UITestControl searchLimitContainer) : 
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
    public class FPGrid : WinWindow
    {
        
        public FPGrid(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ControlName, "spr", PropertyExpressionOperator.Contains));
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
    public class wLimitServiceTo : WinWindow
    {
        
        public wLimitServiceTo(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "nudServiceLimit";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txtEdit2 txtEdit
        {
            get
            {
                if ((this.mtxtEdit == null))
                {
                    this.mtxtEdit = new txtEdit2(this);
                }
                return this.mtxtEdit;
            }
        }
        #endregion
        
        #region Fields
        private txtEdit2 mtxtEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txtEdit2 : WinEdit
    {
        
        public txtEdit2(UITestControl searchLimitContainer) : 
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
    public class wFormulaTable_txt : WinWindow
    {
        
        public wFormulaTable_txt(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "ctlNumEditor";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public txtEdit3 txtEdit
        {
            get
            {
                if ((this.mtxtEdit == null))
                {
                    this.mtxtEdit = new txtEdit3(this);
                }
                return this.mtxtEdit;
            }
        }
        #endregion
        
        #region Fields
        private txtEdit3 mtxtEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class txtEdit3 : WinEdit
    {
        
        public txtEdit3(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Retirement Studio");
            #endregion
        }
        
        #region Properties
        public WinEdit UICtlNumEditorEdit1
        {
            get
            {
                if ((this.mUICtlNumEditorEdit1 == null))
                {
                    this.mUICtlNumEditorEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUICtlNumEditorEdit1.SearchProperties[WinEdit.PropertyNames.Name] = "Text area";
                    this.mUICtlNumEditorEdit1.WindowTitles.Add("Retirement Studio");
                    #endregion
                }
                return this.mUICtlNumEditorEdit1;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUICtlNumEditorEdit1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class wToServiceInSameTier : WinWindow
    {
        
        public wToServiceInSameTier(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnToServiceSameTier";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "to service in same tier";
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
    public class wAtexitagetoallservic : WinWindow
    {
        
        public wAtexitagetoallservic(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnExitAgeToAllService";
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
                    this.mrd.SearchProperties[WinRadioButton.PropertyNames.Name] = "at exit age to all service";
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
}