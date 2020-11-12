namespace RetirementStudio._UIMaps.PayoutProjectionByParticipantClasses
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


    public partial class PayoutProjectionByParticipant
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

      
        /// <summary>
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("NumberOfYears", "1");
        ///    dic.Add("Liability_Tax", "true");
        ///    dic.Add("Liability_Trade", "true");
        ///    dic.Add("Liability_InternationalAccountingABO", "true");
        ///    dic.Add("Liability_InternationalAccountingPBO", "true");
        ///    dic.Add("Result_ALAccuedLiability", "true");
        ///    dic.Add("Result_NCNormalCost", "true");
        ///    dic.Add("Result_PVPBPresentValueOfProjectedBenefits", "true");
        ///    dic.Add("OK", "click");
        ///    pPayoutProjectionByParticipant._PopVerify_Main(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SendKeysUDWin_byPaste("NumberOfYears", this.wPayoutProjectionbyPa.wNumberofYears.txt, dic["NumberOfYears"], 0, true);

            ////
            this.wPayoutProjectionbyPa.wLiabilityTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "Tax");
            _gLib._SetSyncUDWin("Liability_Tax", this.wPayoutProjectionbyPa.wLiabilityTypesList.chk, dic["Liability_Tax"], 0);

            this.wPayoutProjectionbyPa.wLiabilityTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "Trade");
            _gLib._SetSyncUDWin("Liability_Trade", this.wPayoutProjectionbyPa.wLiabilityTypesList.chk, dic["Liability_Trade"], 0);

            this.wPayoutProjectionbyPa.wLiabilityTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "International Accounting ABO");
            _gLib._SetSyncUDWin("Liability_InternationalAccountingABO", this.wPayoutProjectionbyPa.wLiabilityTypesList.chk, dic["Liability_InternationalAccountingABO"], 0);

            this.wPayoutProjectionbyPa.wLiabilityTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "International Accounting PBO");
            _gLib._SetSyncUDWin("Liability_InternationalAccountingPBO", this.wPayoutProjectionbyPa.wLiabilityTypesList.chk, dic["Liability_InternationalAccountingPBO"], 0);

            ////
            this.wPayoutProjectionbyPa.wResultTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "AL - Accrued Liability");
            _gLib._SetSyncUDWin("Result_ALAccuedLiability", this.wPayoutProjectionbyPa.wResultTypesList.chk, dic["Result_ALAccuedLiability"], 0);

            this.wPayoutProjectionbyPa.wResultTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "NC - Normal Cost");
            _gLib._SetSyncUDWin("Result_NCNormalCost", this.wPayoutProjectionbyPa.wResultTypesList.chk, dic["Result_NCNormalCost"], 0);

            this.wPayoutProjectionbyPa.wResultTypesList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, "PVPB - Present Value of Projected Benefits");
            _gLib._SetSyncUDWin("Result_PVPBPresentValueOfProjectedBenefits", this.wPayoutProjectionbyPa.wResultTypesList.chk, dic["Result_PVPBPresentValueOfProjectedBenefits"], 0);
            
            _gLib._SetSyncUDWin("OK", this.wPayoutProjectionbyPa.wOK.btn, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
