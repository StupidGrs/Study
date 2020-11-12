namespace RetirementStudio._UIMaps.NonTranchedBenefitPlanDefinitionClasses
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
    
    
    public partial class NonTranchedBenefitPlanDefinition
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-June-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IncludeThisBenefitInPV", "");
        ///    dic.Add("ParticipantType", "");
        ///    dic.Add("NonTranchedBenefit", "");
        ///    dic.Add("DefineAccruedBenefitAsZero", "");
        ///    dic.Add("FullySalaryRelateBenefit", "");
        ///    dic.Add("BenefitCommenceAge_V", "");
        ///    dic.Add("BenefitCommenceAge_C", "");
        ///    dic.Add("BenefitCommenceAge_V_cbo", "");
        ///    dic.Add("BenefitCommenceAge_C_txt", "");
        ///    dic.Add("BenefitStopAge_V", "");
        ///    dic.Add("BenefitStopAge_C", "");
        ///    dic.Add("BenefitStopAge_V_cbo", "");
        ///    dic.Add("BenefitStopAge_C_txt", "");
        ///    dic.Add("CostOfLivingAdjustment", "");
        ///    dic.Add("EarlyRetirement", "");
        ///    dic.Add("LateRetirement", "");
        ///    dic.Add("Adjustment", "");
        ///    dic.Add("TransferValue_V", "");
        ///    dic.Add("TransferValue_T", "");
        ///    dic.Add("TransferValue_V_cbo", "");
        ///    dic.Add("TransferValue_T_cbo", "");
        ///    dic.Add("FormOfPayment", "");
        ///    dic.Add("Decrement", "");
        ///    dic.Add("ApplyDifferentStartAge", "");
        ///    dic.Add("StartAgeForPost_V", "");
        ///    dic.Add("StartAgeForPost_C", "");
        ///    dic.Add("StartAgeForPost_V_cbo", "");
        ///    dic.Add("StartAgeForPost_C_txt", "");
        ///    dic.Add("MaleSolvencyPaymentAge_V", "");
        ///    dic.Add("MaleSolvencyPaymentAge_C", "");
        ///    dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
        ///    dic.Add("MaleSolvencyPaymentAge_C_txt", "");
        ///    dic.Add("FemaleSolvencyPaymentAge_V", "");
        ///    dic.Add("FemaleSolvencyPaymentAge_C", "");
        ///    dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
        ///    dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
        ///    pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_NonTranchedBenefitPlanDefinition(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_NonTranchedBenefitPlanDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
            
            int iCbo_V = 0;
            int iTxt_C = 0;
            int iCbo_T = 0;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("IncludeThisBenefitInPV", this.wRetirementStudio.wIncludeThisBenefitInPV.chk, dic["IncludeThisBenefitInPV"], 0);
                _gLib._SetSyncUDWin("ParticipantType", this.wRetirementStudio.wParticipantType.cbo, dic["ParticipantType"], 0);
                _gLib._SetSyncUDWin("NonTranchedBenefit", this.wRetirementStudio.wNonTranchedBenefit.cbo, dic["NonTranchedBenefit"], 0);
                _gLib._SetSyncUDWin("DefineAccruedBenefitAsZero", this.wRetirementStudio.wDefineAccruedBenefitAsZero.chk, dic["DefineAccruedBenefitAsZero"], 0);
                _gLib._SetSyncUDWin("FullySalaryRelateBenefit", this.wRetirementStudio.wFullySalaryRelateBenefit.chk, dic["FullySalaryRelateBenefit"], 0);
                _gLib._SetSyncUDWin("BenefitCommenceAge_V", this.wRetirementStudio.wBenefitCommenceAge_V.btn, dic["BenefitCommenceAge_V"], 0);
                _gLib._SetSyncUDWin("BenefitCommenceAge_C", this.wRetirementStudio.wBenefitCommenceAge_C.btn, dic["BenefitCommenceAge_C"], 0);
                
                if (dic["BenefitCommenceAge_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("BenefitCommenceAge_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["BenefitCommenceAge_V_cbo"], 0);

                if (dic["BenefitCommenceAge_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("BenefitCommenceAge_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitCommenceAge_C_txt"], 0);

                _gLib._SetSyncUDWin("BenefitStopAge_V", this.wRetirementStudio.wBenefitStopAge_V.btn, dic["BenefitStopAge_V"], 0);
                _gLib._SetSyncUDWin("BenefitStopAge_C", this.wRetirementStudio.wBenefitStopAge_C.btn, dic["BenefitStopAge_C"], 0);

                if (dic["BenefitStopAge_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("BenefitStopAge_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["BenefitStopAge_V_cbo"], 0);

                if (dic["BenefitStopAge_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitStopAge_C_txt"], 0);

                
                _gLib._SetSyncUDWin("CostOfLivingAdjustment", this.wRetirementStudio.wCostOfLivingAdjustment.cbo, dic["CostOfLivingAdjustment"], 0);
                _gLib._SetSyncUDWin("EarlyRetirement", this.wRetirementStudio.wEarlyRetirement.cbo, dic["EarlyRetirement"], 0);
                _gLib._SetSyncUDWin("LateRetirement", this.wRetirementStudio.wLateRetirement.cbo, dic["LateRetirement"], 0);
                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustment.cbo, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("TransferValue_V", this.wRetirementStudio.wTransferValue_V.btn, dic["TransferValue_V"], 0);
                _gLib._SetSyncUDWin("TransferValue_T", this.wRetirementStudio.wTransferValue_T.btn, dic["TransferValue_T"], 0);

                if (dic["TransferValue_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("TransferValue_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["TransferValue_V_cbo"], 0);

                if (dic["TransferValue_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("TransferValue_T_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["TransferValue_T_cbo"], 0);

                
                _gLib._SetSyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cbo, dic["FormOfPayment"], 0);
                _gLib._SetSyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cbo, dic["Decrement"], 0);
                _gLib._SetSyncUDWin("ApplyDifferentStartAge", this.wRetirementStudio.wApplyDifferentStartAge.chk, dic["ApplyDifferentStartAge"], 0);

                if (_gLib._Enabled("StartAgeForPost_V", this.wRetirementStudio.wStartAgeForPost_V.btn, 1, false))
                    _gLib._SetSyncUDWin("StartAgeForPost_V", this.wRetirementStudio.wStartAgeForPost_V.btn, dic["StartAgeForPost_V"], 0);
                if (dic["StartAgeForPost_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("StartAgeForPost_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["StartAgeForPost_V_cbo"], 0);


                if (_gLib._Enabled("StartAgeForPost_C", this.wRetirementStudio.wStartAgeForPost_C.btn, 1, false))
                    _gLib._SetSyncUDWin("StartAgeForPost_C", this.wRetirementStudio.wStartAgeForPost_C.btn, dic["StartAgeForPost_C"], 0);
                if (dic["StartAgeForPost_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("StartAgeForPost_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["StartAgeForPost_C_txt"], 0);


                _gLib._SetSyncUDWin("MaleSolvencyPaymentAge_V", this.wRetirementStudio.wMaleSolvencyPaymentAge_V.btn, dic["MaleSolvencyPaymentAge_V"], 0);
                _gLib._SetSyncUDWin("MaleSolvencyPaymentAge_C", this.wRetirementStudio.wMaleSolvencyPaymentAge_C.btn, dic["MaleSolvencyPaymentAge_C"], 0);
                if (dic["MaleSolvencyPaymentAge_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("MaleSolvencyPaymentAge_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["MaleSolvencyPaymentAge_V_cbo"], 0);

                if (dic["MaleSolvencyPaymentAge_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("MaleSolvencyPaymentAge_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["MaleSolvencyPaymentAge_C_txt"], 0);

                
                _gLib._SetSyncUDWin("FemaleSolvencyPaymentAge_V", this.wRetirementStudio.wFemaleSolvencyPaymentAge_V.btn, dic["FemaleSolvencyPaymentAge_V"], 0);
                _gLib._SetSyncUDWin("FemaleSolvencyPaymentAge_C", this.wRetirementStudio.wFemaleSolvencyPaymentAge_C.btn, dic["FemaleSolvencyPaymentAge_C"], 0);
                if (dic["FemaleSolvencyPaymentAge_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("FemaleSolvencyPaymentAge_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["FemaleSolvencyPaymentAge_V_cbo"], 0);

                if (dic["FemaleSolvencyPaymentAge_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("FemaleSolvencyPaymentAge_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["FemaleSolvencyPaymentAge_C_txt"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("", "No Verify functin here!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
