namespace RetirementStudio._UIMaps.TranchedBenefitPlanDefinitionClasses
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
    
    
    public partial class TranchedBenefitPlanDefinition
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-June-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ParticipantType", "");
        ///    dic.Add("TranchedBenefit", "");
        ///    dic.Add("FormOfPayment", "");
        ///    dic.Add("CommutationAmount", "");
        ///    dic.Add("SalaryIncreaseForGMP", "");
        ///    dic.Add("Decrement", "");
        ///    dic.Add("ApplyDifferentStartAge", "");
        ///    dic.Add("PPFCalculationType", "");
        ///    pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TranchedBenefitPlanDefinition(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_TranchedBenefitPlanDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("ParticipantType", this.wRetirementStudio.wParticipantType.cbo, dic["ParticipantType"], 0);
                _gLib._SetSyncUDWin("TranchedBenefit", this.wRetirementStudio.wTranchedBenefit.cbo, dic["TranchedBenefit"], 0);
                _gLib._SetSyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cbo, dic["FormOfPayment"], 0);
                _gLib._SetSyncUDWin("CommutationAmount", this.wRetirementStudio.wCommutationAmount.cbo, dic["CommutationAmount"], 0);
                _gLib._SetSyncUDWin("SalaryIncreaseForGMP", this.wRetirementStudio.wSalaryIncreaseForGMP.cbo, dic["SalaryIncreaseForGMP"], 0);
                _gLib._SetSyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cbo, dic["Decrement"], 0);
                _gLib._SetSyncUDWin("ApplyDifferentStartAge", this.wRetirementStudio.wApplyDifferentStartAge.chk, dic["ApplyDifferentStartAge"], 0);
                _gLib._SetSyncUDWin("PPFCalculationType", this.wRetirementStudio.wPPFCalculationType.cbo, dic["PPFCalculationType"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ParticipantType", this.wRetirementStudio.wParticipantType.cbo, dic["ParticipantType"], 0);
                _gLib._VerifySyncUDWin("TranchedBenefit", this.wRetirementStudio.wTranchedBenefit.cbo, dic["TranchedBenefit"], 0);
                _gLib._VerifySyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cbo, dic["FormOfPayment"], 0);
                _gLib._VerifySyncUDWin("CommutationAmount", this.wRetirementStudio.wCommutationAmount.cbo, dic["CommutationAmount"], 0);
                _gLib._VerifySyncUDWin("SalaryIncreaseForGMP", this.wRetirementStudio.wSalaryIncreaseForGMP.cbo, dic["SalaryIncreaseForGMP"], 0);
                _gLib._VerifySyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cbo, dic["Decrement"], 0);
                _gLib._VerifySyncUDWin("ApplyDifferentStartAge", this.wRetirementStudio.wApplyDifferentStartAge.chk, dic["ApplyDifferentStartAge"], 0);
                _gLib._VerifySyncUDWin("PPFCalculationType", this.wRetirementStudio.wPPFCalculationType.cbo, dic["PPFCalculationType"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
