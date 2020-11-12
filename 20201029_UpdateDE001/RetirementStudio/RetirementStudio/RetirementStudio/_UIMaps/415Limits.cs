namespace RetirementStudio._UIMaps.Item415LimitsClasses
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


    public partial class Item415Limits
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "Click");
        ///    dic.Add("CustomCode", "");
        ///    p415Limits._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("DeterminLimitBasedOn", "");
        ///    dic.Add("DeterminLimitBasedOn_Year", "");
        ///    dic.Add("IncreaseAppliesUntil", "");
        ///    dic.Add("BenefitCommenceAge_cbo", "");
        ///    dic.Add("btnBenefitCommenceAge_C", "");
        ///    dic.Add("BenefitCommenceAge_txt", "");
        ///    dic.Add("EarlyRetirementFator", "");
        ///    dic.Add("LateRetirementFactor", "");
        ///    dic.Add("PlanNormalFormOfPayment", "");
        ///    dic.Add("ConversionFactorNormalFromToStraightLife", "");
        ///    dic.Add("btnPlanNormalFromStopAge_V", "");
        ///    dic.Add("PlanNormalFromStopAge_cbo", "");
        ///    dic.Add("btnPlanNormalFromStopAge_C", "");
        ///    dic.Add("PlanNormalFromStopAge_txt", "");
        ///    dic.Add("PlanActuarialEquivalence", "");
        ///    dic.Add("415LimitFormOfPayement", "");
        ///    dic.Add("ConversionFactorNormalFromTo415Limit", "");
        ///    dic.Add("btn415LimitFormStopAge_V", "");
        ///    dic.Add("415LimitFormStopAge_cbo", "");
        ///    dic.Add("btn415LimitFormStopAge_C", "");
        ///    dic.Add("415LimitFormStopAge_txt", "");
        ///    dic.Add("ParticipationService", "");
        ///    dic.Add("MandatoryEmployeeContribution", "");
        ///    dic.Add("ProjectedPayForAlternative", "");
        ///    dic.Add("EmploymentService", "");
        ///    p415Limits._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iBenefitCommenceAge_txt = 0;
            int iPlanNormalFromStopAge_txt = 0;
            int i415LimitFormStopAge_txt = 0;

            int iBenefitCommenceAge_cbo = 0;
            int iPlanNormalFromStopAge_cbo = 0;
            int i415LimitFormStopAge_cbo = 0;

            int iIncrease_cbo = 0;
            int iTxtIncrease_txt = 0;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("DeterminLimitBasedOn", this.wRetirementStudio.wDeterminLimitBasedOn.cboDeterminLimitBasedOn, dic["DeterminLimitBasedOn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeterminLimitBasedOn_Year", this.wRetirementStudio.wDeterminLimitBasedOn_Year.txtDeterminLimitBasedOn_Year, dic["DeterminLimitBasedOn_Year"], 0);
                _gLib._SetSyncUDWin("IncreaseAppliesUntil", this.wRetirementStudio.wIncreaseAppliesUntil.cboIncreaseAppliesUntil, dic["IncreaseAppliesUntil"], 0);


                //  BenefitCommenceAge
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_V", this.wRetirementStudio.wBenefitCommenceAge_VIcon.btnBenefitCommenceAge_V, dic["btnBenefitCommenceAge_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_C", this.wRetirementStudio.wBenefitCommenceAge_CIcon.btnBenefitCommenceAge_C, dic["btnBenefitCommenceAge_C"], 0);
                if (dic["btnBenefitCommenceAge_V"] != "")
                {
                    iBenefitCommenceAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitCommenceAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitCommenceAge_cbo"], 0);
                }
                if (dic["btnBenefitCommenceAge_C"] != "")
                {
                    iBenefitCommenceAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitCommenceAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitCommenceAge_txt"], true, 0);
                }



                _gLib._SetSyncUDWin("EarlyRetirementFator", this.wRetirementStudio.wEarlyRetirementFator.cboEarlyRetirementFator, dic["EarlyRetirementFator"], 0);
                _gLib._SetSyncUDWin("LateRetirementFactor", this.wRetirementStudio.wLateRetirementFactor.cboLateRetirementFactor, dic["LateRetirementFactor"], 0);
                _gLib._SetSyncUDWin("PlanNormalFormOfPayment", this.wRetirementStudio.wPlanNormalFormOfPayment.cboPlanNormalFormOfPayment, dic["PlanNormalFormOfPayment"], 0);
                _gLib._SetSyncUDWin("ConversionFactorNormalFromToStraightLife", this.wRetirementStudio.wConversionFactorNormalFromToStraightLife.cboConversionFactorNormalFromToStraightLife, dic["ConversionFactorNormalFromToStraightLife"], 0);


                //  PlanNormalFromStopAge
                _gLib._SetSyncUDWin("btnPlanNormalFromStopAge_V", this.wRetirementStudio.wPlanNormalFromStopAge_VIcon.btnPlanNormalFromStopAge_V, dic["btnPlanNormalFromStopAge_V"], 0);
                _gLib._SetSyncUDWin("btnPlanNormalFromStopAge_C", this.wRetirementStudio.wPlanNormalFromStopAge_CIcon.btnPlanNormalFromStopAge_C, dic["btnPlanNormalFromStopAge_C"], 0);
                if (dic["btnPlanNormalFromStopAge_V"] != "")
                {
                    iPlanNormalFromStopAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPlanNormalFromStopAge_cbo.ToString());
                    _gLib._SetSyncUDWin("PlanNormalFromStopAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["PlanNormalFromStopAge_cbo"], 0);
                }
                if (dic["btnPlanNormalFromStopAge_C"] != "")
                {
                    iPlanNormalFromStopAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPlanNormalFromStopAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PlanNormalFromStopAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["PlanNormalFromStopAge_txt"], true, 0);
                }


                _gLib._SetSyncUDWin("PlanActuarialEquivalence", this.wRetirementStudio.wPlanActuarialEquivalence.cboPlanActuarialEquivalence, dic["PlanActuarialEquivalence"], 0);
                _gLib._SetSyncUDWin("415LimitFormOfPayement", this.wRetirementStudio.w415LimitFormOfPayement.cbo415LimitFormOfPayement, dic["415LimitFormOfPayement"], 0);
                _gLib._SetSyncUDWin("ConversionFactorNormalFromTo415Limit", this.wRetirementStudio.wConversionFactorNormalFromTo415Limit.cboConversionFactorNormalFromTo415Limit, dic["ConversionFactorNormalFromTo415Limit"], 0);


                //  415LimitFormStopAge
                _gLib._SetSyncUDWin("btn415LimitFormStopAge_V", this.wRetirementStudio.w415LimitFormStopAge_VIcon.btn415LimitFormStopAge_V, dic["btn415LimitFormStopAge_V"], 0);
                _gLib._SetSyncUDWin("btn415LimitFormStopAge_C", this.wRetirementStudio.w415LimitFormStopAge_CIcon.btn415LimitFormStopAge_C, dic["btn415LimitFormStopAge_C"], 0);
                if (dic["btn415LimitFormStopAge_V"] != "")
                {
                    i415LimitFormStopAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, i415LimitFormStopAge_cbo.ToString());
                    _gLib._SetSyncUDWin("415LimitFormStopAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["415LimitFormStopAge_cbo"], 0);
                }
                if (dic["btn415LimitFormStopAge_C"] != "")
                {
                    i415LimitFormStopAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, i415LimitFormStopAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("415LimitFormStopAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["415LimitFormStopAge_txt"], true, 0);
                }


                _gLib._SetSyncUDWin("ParticipationService", this.wRetirementStudio.wParticipationService.cboParticipationService, dic["ParticipationService"], 0);
                _gLib._SetSyncUDWin("MandatoryEmployeeContribution", this.wRetirementStudio.wMandatoryEmployeeContribution.cboMandatoryEmployeeContribution, dic["MandatoryEmployeeContribution"], 0);
                _gLib._SetSyncUDWin("ProjectedPayForAlternative", this.wRetirementStudio.wProjectedPayForAlternative.cboProjectedPayForAlternative, dic["ProjectedPayForAlternative"], 0);
                _gLib._SetSyncUDWin("EmploymentService", this.wRetirementStudio.wEmploymentService.cboEmploymentService, dic["EmploymentService"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}
