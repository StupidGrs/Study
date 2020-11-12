namespace RetirementStudio._UIMaps.Item2DCashFlowOptionsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;


    public partial class Item2DCashFlowOptions
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

      
        /// <summary>
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Liability_Tax", "true");
        ///    dic.Add("Liability_Trade", "true");
        ///    dic.Add("Liability_InternationalAccountingABO", "true");
        ///    dic.Add("Liability_InternationalAccountingPBO", "true");
        ///    
        ///    dic.Add("Result_ALAccuedLiability", "true");
        ///    dic.Add("Result_NCNormalCost", "true");
        ///    dic.Add("Result_PVPBPresentValueOfProjectedBenefits", "true");
        ///    
        ///    dic.Add("ReportBreak", "true");
        ///    dic.Add("VO", "true");
        ///    dic.Add("PlanDefinition", "true");
        ///    
        ///    dic.Add("NumberOfYears", "1");
        ///    dic.Add("MaxNumberOfYears2ndDimension", "2");
        ///    dic.Add("OK", "click");
        ///    p2DCashFlowOptions._PopVerify_Main(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            ////
            this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "Tax");
            _gLib._SetSyncUDWin("Liability_Tax", this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk, dic["Liability_Tax"], 0);

            this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "Trade");
            _gLib._SetSyncUDWin("Liability_Trade", this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk, dic["Liability_Trade"], 0);

            this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "International Accounting ABO");
            _gLib._SetSyncUDWin("Liability_InternationalAccountingABO", this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk, dic["Liability_InternationalAccountingABO"], 0);

            this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "International Accounting PBO");
            _gLib._SetSyncUDWin("Liability_InternationalAccountingPBO", this.w2DCashFlowOption.wLiabilityTypeToBeIncluded.chk, dic["Liability_InternationalAccountingPBO"], 0);
 
            ////
            this.w2DCashFlowOption.wResultTypestobeInclude.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "AL - Accrued Liability");
            _gLib._SetSyncUDWin("Result_ALAccuedLiability", this.w2DCashFlowOption.wResultTypestobeInclude.chk, dic["Result_ALAccuedLiability"], 0);

            this.w2DCashFlowOption.wResultTypestobeInclude.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "NC - Normal Cost");
            _gLib._SetSyncUDWin("Result_NCNormalCost", this.w2DCashFlowOption.wResultTypestobeInclude.chk, dic["Result_NCNormalCost"], 0);

            this.w2DCashFlowOption.wResultTypestobeInclude.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "PVPB - Present Value of Projected Benefits");
            _gLib._SetSyncUDWin("Result_PVPBPresentValueOfProjectedBenefits", this.w2DCashFlowOption.wResultTypestobeInclude.chk, dic["Result_PVPBPresentValueOfProjectedBenefits"], 0);

            ////
            _gLib._SetSyncUDWin("ReportBreak", this.w2DCashFlowOption.wReportBreak.chk, dic["ReportBreak"], 0);
            _gLib._SetSyncUDWin("VO", this.w2DCashFlowOption.wVO.chk, dic["VO"], 0);
            _gLib._SetSyncUDWin("PlanDefinition", this.w2DCashFlowOption.wPlanDefinition.chk, dic["PlanDefinition"], 0);

            ////
            //////this.w2DCashFlowOption.wNumberOfYears.txt.SearchProperties.Remove(WinEdit.PropertyNames.Instance);
            _gLib._SendKeysUDWin_byPaste("NumberOfYears", this.w2DCashFlowOption.wNumberOfYears.txt, dic["NumberOfYears"],0, true);


            if (dic["MaxNumberOfYears2ndDimension"] != "")
            {
                _gLib._MsgBox("", "please set MaxNumberOfYears2ndDimension to " + dic["MaxNumberOfYears2ndDimension"]);
            }
            //////this.w2DCashFlowOption.wNumberOfYears.txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
            //////this.w2DCashFlowOption.wNumberOfYears.txt.SearchProperties.Add(WinEdit.PropertyNames.ControlName, "nudNumberOfYears2ndDimension");
            //////this.w2DCashFlowOption.wNumberOfYears.txt.SearchProperties.Add(WinEdit.PropertyNames.FriendlyName, "nudNumberOfYears2ndDimension");
            //////_gLib._SetSyncUDWin("MaxNumberOfYears2ndDimension", this.w2DCashFlowOption.wNumberOfYears.txt, dic["MaxNumberOfYears2ndDimension"], 0);
          
            _gLib._SetSyncUDWin("OK", this.w2DCashFlowOption.wOK.btn, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
