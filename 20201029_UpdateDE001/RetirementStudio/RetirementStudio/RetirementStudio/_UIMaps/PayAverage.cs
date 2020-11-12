namespace RetirementStudio._UIMaps.PayAverageClasses
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

    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    public partial class PayAverage
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("ApplyAveragePayLimit", "");
        ///    dic.Add("ApplyPayAverageFreezeDefinition", "");
        ///    dic.Add("ApplyAverageAtFutureAge", "");
        ///    dic.Add("UsePayAverageFrom", "");
        ///    pPayAverage._PopVerify_Main(dic); 
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
                _gLib._SetSyncUDWin("ApplyAveragePayLimit", this.wRetirementStudio.wApplyAveragePayLimit.chkApplyAveragePayLimit, dic["ApplyAveragePayLimit"], 0);
                _gLib._SetSyncUDWin("ApplyPayAverageFreezeDefinition", this.wRetirementStudio.wApplyPayAverageFreezeDefinition.chkApplyPayAverageFreezeDefinition, dic["ApplyPayAverageFreezeDefinition"], 0);
                _gLib._SetSyncUDWin("ApplyAverageAtFutureAge", this.wRetirementStudio.wApplyAverageAtFutureAge.chkApplyAverageAtFutureAge, dic["ApplyAverageAtFutureAge"], 0);
                _gLib._SetSyncUDWin("UsePayAverageFrom", this.wRetirementStudio.wUsePayAverageFromda.chx, dic["UsePayAverageFrom"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                 _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("ApplyAveragePayLimit", this.wRetirementStudio.wApplyAveragePayLimit.chkApplyAveragePayLimit, dic["ApplyAveragePayLimit"], 0);
                _gLib._VerifySyncUDWin("ApplyPayAverageFreezeDefinition", this.wRetirementStudio.wApplyPayAverageFreezeDefinition.chkApplyPayAverageFreezeDefinition, dic["ApplyPayAverageFreezeDefinition"], 0);
                _gLib._VerifySyncUDWin("ApplyAverageAtFutureAge", this.wRetirementStudio.wApplyAverageAtFutureAge.chkApplyAverageAtFutureAge, dic["ApplyAverageAtFutureAge"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PayProjectionToAverage", "PayProjection1");
        ///    dic.Add("AveragingMethod", "");
        ///    dic.Add("M", "");
        ///    dic.Add("N", "");
        ///    dic.Add("RoundingForYearOfHire", "");
        ///    dic.Add("DecimalPlacesForYearOfHire", "");
        ///    dic.Add("Include", "");
        ///    dic.Add("DropForCalculations", "");
        ///    dic.Add("DropForCalculationAndPeriodConsidered", "");
        ///    dic.Add("AdjustmentPeriodMonths", "");
        ///    dic.Add("AdjustmentMethod", "");
        ///    dic.Add("FreezePayAverageAtAge_V", "");
        ///    dic.Add("FreezePayAverageAtAge_C", "");
        ///    dic.Add("FreezePayAverageAtAge_cbo", "");
        ///    dic.Add("LimitAmount_txt", "");
        ///    dic.Add("AnualLimitIncrease_txt", "");
        ///    dic.Add("PayAveragefromdata_cbo", "");
        ///    dic.Add("FinalSalaryFromData", "");
        ///    dic.Add("ProjectFPS", "");
        ///    dic.Add("PayIncreaseAssumptionForProjection", "");
        ///    pPayAverage._PopVerify_Standard(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PayIncrease";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PayProjectionToAverage", this.wRetirementStudio.wStandard_PayProjectionToAverage.cboPayProjectionToAverage, dic["PayProjectionToAverage"], 0);
                _gLib._SetSyncUDWin("AveragingMethod", this.wRetirementStudio.wStandard_AveragingMethod.cboAveragingMethod, dic["AveragingMethod"], 0);
                _gLib._SetSyncUDWin_ByClipboard("M", this.wRetirementStudio.wStandard_M.txtM, dic["M"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("N", this.wRetirementStudio.wStand_N.txt.UINudMethodNEdit1, dic["N"], true, 0);
                _gLib._SetSyncUDWin("RoundingForYearOfHire", this.wRetirementStudio.wStandard_RoundingForYearOfHire.cboRoundingForYearOfHire, dic["RoundingForYearOfHire"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DecimalPlacesForYearOfHire", this.wRetirementStudio.wStandard_DecimalPlacesForYearOfHire.txtDecimalPlacesForYearOfHire, dic["DecimalPlacesForYearOfHire"], true, 0);
                _gLib._SetSyncUDWin("Include", this.wRetirementStudio.wStandard_Include.rdInclude, dic["Include"], 0);
                _gLib._SetSyncUDWin("DropForCalculations", this.wRetirementStudio.wStandard_DropForCalculations.rdDropForCalculations, dic["DropForCalculations"], 0);
                _gLib._SetSyncUDWin("DropForCalculationAndPeriodConsidered", this.wRetirementStudio.wStandard_DropForCalculationAndPeriodConsidered.rdDropForCalculationAndPeriodConsidered, dic["DropForCalculationAndPeriodConsidered"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AdjustmentPeriodMonths", this.wRetirementStudio.wAdjustmentPeriodMonths.txt, dic["AdjustmentPeriodMonths"], true, 0);
                _gLib._SetSyncUDWin("AdjustmentMethod", this.wRetirementStudio.wAdjustmentMethod.cbo, dic["AdjustmentMethod"], 0);
                _gLib._SetSyncUDWin("FreezePayAverageAtAge_V", this.wRetirementStudio.wFreezePayAverageAtAge_V.btn, dic["FreezePayAverageAtAge_V"], 0);
                _gLib._SetSyncUDWin("FreezePayAverageAtAge_C", this.wRetirementStudio.wFreezePayAverageAtAge_C.btn, dic["FreezePayAverageAtAge_C"], 0);
                _gLib._SetSyncUDWin("FreezePayAverageAtAge_cbo", this.wRetirementStudio.wCommonCbo.cbo, dic["FreezePayAverageAtAge_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LimitAmount_txt", this.wRetirementStudio.wLimitAmount.Edit.txt, dic["LimitAmount_txt"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("AnualLimitIncrease_txt", this.wRetirementStudio.wAnnualLimitIncrease.Edit.txt, dic["AnualLimitIncrease_txt"], true, 0);
                _gLib._SetSyncUDWin("PayAveragefromdata_cbo", this.wRetirementStudio.wPayAverageFromData.cbo, dic["PayAveragefromdata_cbo"], 0);


                _gLib._SetSyncUDWin("FinalSalaryFromData", this.wRetirementStudio.wFinalSalaryFromData.cbo, dic["FinalSalaryFromData"], 0);
                _gLib._SetSyncUDWin("ProjectFPS", this.wRetirementStudio.wProjectFPS.rd, dic["ProjectFPS"], 0);
                _gLib._SetSyncUDWin("PayIncreaseAssumptionForProjection", this.wRetirementStudio.wPayIncreaseAssumptionForProjection.cbo, dic["PayIncreaseAssumptionForProjection"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PayProjectionToAverage", this.wRetirementStudio.wStandard_PayProjectionToAverage.cboPayProjectionToAverage, dic["PayProjectionToAverage"], 0);
                _gLib._VerifySyncUDWin("AveragingMethod", this.wRetirementStudio.wStandard_AveragingMethod.cboAveragingMethod, dic["AveragingMethod"], 0);
                _gLib._VerifySyncUDWin("M", this.wRetirementStudio.wStandard_M.txtM, dic["M"], 0);
                _gLib._VerifySyncUDWin("RoundingForYearOfHire", this.wRetirementStudio.wStandard_RoundingForYearOfHire.cboRoundingForYearOfHire, dic["RoundingForYearOfHire"], 0);
                _gLib._VerifySyncUDWin("DecimalPlacesForYearOfHire", this.wRetirementStudio.wStandard_DecimalPlacesForYearOfHire.txtDecimalPlacesForYearOfHire, dic["DecimalPlacesForYearOfHire"], 0);
                _gLib._VerifySyncUDWin("Include", this.wRetirementStudio.wStandard_Include.rdInclude, dic["Include"], 0);
                _gLib._VerifySyncUDWin("DropForCalculations", this.wRetirementStudio.wStandard_DropForCalculations.rdDropForCalculations, dic["DropForCalculations"], 0);
                _gLib._VerifySyncUDWin("DropForCalculationAndPeriodConsidered", this.wRetirementStudio.wStandard_DropForCalculationAndPeriodConsidered.rdDropForCalculationAndPeriodConsidered, dic["DropForCalculationAndPeriodConsidered"], 0);
                _gLib._VerifySyncUDWin("AdjustmentPeriodMonths", this.wRetirementStudio.wAdjustmentPeriodMonths.txt, dic["AdjustmentPeriodMonths"], 0);
                _gLib._VerifySyncUDWin("AdjustmentMethod", this.wRetirementStudio.wAdjustmentMethod.cbo, dic["AdjustmentMethod"], 0);
                _gLib._VerifySyncUDWin("FreezePayAverageAtAge_V", this.wRetirementStudio.wFreezePayAverageAtAge_V.btn, dic["FreezePayAverageAtAge_V"], 0);
                _gLib._VerifySyncUDWin("FreezePayAverageAtAge_C", this.wRetirementStudio.wFreezePayAverageAtAge_C.btn, dic["FreezePayAverageAtAge_C"], 0);
                _gLib._VerifySyncUDWin("FreezePayAverageAtAge_cbo", this.wRetirementStudio.wCommonCbo.cbo, dic["FreezePayAverageAtAge_cbo"], 0);
            
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
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("ApplyPayLimitBeforeAveraging", "");
        ///    dic.Add("ApplyeDeductionBeforeAveraging", "");
        ///    dic.Add("AdjustmentPeriod", "");
        ///    dic.Add("ApplyLegislatedSalaryCap", "");
        ///    dic.Add("ApplyPayAverageFreezeDefinition", "");
        ///    dic.Add("ApplyAverageAtFutureAge", "");
        ///    dic.Add("UseDtaItemForSolvencyAndPPF", "");
        ///    pPayAverage._PopVerify_Main_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main_UK(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitBeforeAveraging", this.wRetirementStudio.wApplyPayLimitBeforeAveraging.chk, dic["ApplyPayLimitBeforeAveraging"], 0);
                _gLib._SetSyncUDWin("ApplyeDeductionBeforeAveraging", this.wRetirementStudio.wApplyeDeductionBeforeAveraging.chk, dic["ApplyeDeductionBeforeAveraging"], 0);
                _gLib._SetSyncUDWin("AdjustmentPeriod", this.wRetirementStudio.wAdjustmentPeriod.chk, dic["AdjustmentPeriod"], 0);
                _gLib._SetSyncUDWin("ApplyLegislatedSalaryCap", this.wRetirementStudio.wApplyLegislatedSalaryCap.chk, dic["ApplyLegislatedSalaryCap"], 0);
                _gLib._SetSyncUDWin("ApplyPayAverageFreezeDefinition", this.wRetirementStudio.wApplyPayAverageFreezeDefinition.chkApplyPayAverageFreezeDefinition, dic["ApplyPayAverageFreezeDefinition"], 0);
                _gLib._SetSyncUDWin("ApplyAverageAtFutureAge", this.wRetirementStudio.wApplyAverageAtFutureAge.chkApplyAverageAtFutureAge, dic["ApplyAverageAtFutureAge"], 0);
                _gLib._SetSyncUDWin("UseDtaItemForSolvencyAndPPF", this.wRetirementStudio.wUseDtaItemForSolvencyAndPPF.chk, dic["UseDtaItemForSolvencyAndPPF"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("ApplyPayLimitBeforeAveraging", this.wRetirementStudio.wApplyPayLimitBeforeAveraging.chk, dic["ApplyPayLimitBeforeAveraging"], 0);
                _gLib._VerifySyncUDWin("ApplyeDeductionBeforeAveraging", this.wRetirementStudio.wApplyeDeductionBeforeAveraging.chk, dic["ApplyeDeductionBeforeAveraging"], 0);
                _gLib._VerifySyncUDWin("AdjustmentPeriod", this.wRetirementStudio.wAdjustmentPeriod.chk, dic["AdjustmentPeriod"], 0);
                _gLib._VerifySyncUDWin("ApplyLegislatedSalaryCap", this.wRetirementStudio.wApplyLegislatedSalaryCap.chk, dic["ApplyLegislatedSalaryCap"], 0);
                _gLib._VerifySyncUDWin("ApplyPayAverageFreezeDefinition", this.wRetirementStudio.wApplyPayAverageFreezeDefinition.chkApplyPayAverageFreezeDefinition, dic["ApplyPayAverageFreezeDefinition"], 0);
                _gLib._VerifySyncUDWin("ApplyAverageAtFutureAge", this.wRetirementStudio.wApplyAverageAtFutureAge.chkApplyAverageAtFutureAge, dic["ApplyAverageAtFutureAge"], 0);
                _gLib._VerifySyncUDWin("UseDtaItemForSolvencyAndPPF", this.wRetirementStudio.wUseDtaItemForSolvencyAndPPF.chk, dic["UseDtaItemForSolvencyAndPPF"], 0);

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
        ///    dic.Add("Deduction_V", "");
        ///    dic.Add("Deduction_C", "");
        ///    dic.Add("Deduction_T", "");
        ///    dic.Add("Deduction_cbo", "");
        ///    dic.Add("Deduction_txt", "");
        ///    dic.Add("Deduction_cbo_T", "");
        ///    dic.Add("DeductionAnnual_V", "");
        ///    dic.Add("DeductionAnnual_C", "");
        ///    dic.Add("DeductionAnnual_T", "");
        ///    dic.Add("DeductionAnnual_cbo", "");
        ///    dic.Add("DeductionAnnual_txt", "");
        ///    dic.Add("DeductionAnnual_cbo_T", "");
        ///    pPayAverage._PopVerify_ApplyDeductionBeforeAverageing(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ApplyDeductionBeforeAverageing(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ApplyDeductionBeforeAverageing";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

    
            if (dic["PopVerify"] == "Pop")
            {
                int icbo = 1;
                int icbo_T = 1;

                _gLib._SetSyncUDWin("Deduction_V", this.wRetirementStudio.wDeduction_V.btn, dic["Deduction_V"], 0);
                _gLib._SetSyncUDWin("Deduction_C", this.wRetirementStudio.wDeduction_C.btn, dic["Deduction_C"], 0);
                _gLib._SetSyncUDWin("Deduction_T", this.wRetirementStudio.wDeduction_T.btn, dic["Deduction_T"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_V", this.wRetirementStudio.wDeductionAnnualIncrease_V.btn, dic["DeductionAnnual_V"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_C", this.wRetirementStudio.wDeductionAnnualIncrease_C.btn, dic["DeductionAnnual_C"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_T", this.wRetirementStudio.wDeductionAnnual_T.btn, dic["DeductionAnnual_T"], 0);


                _gLib._SetSyncUDWin("Deduction_cbo", this.wRetirementStudio.wDeduction_cbo.cbo, dic["Deduction_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Deduction_txt", this.wRetirementStudio.wDeduction_txt.txt.UI_numEditConstantEdit1, dic["Deduction_txt"], 0);
                _gLib._SetSyncUDWin("Deduction_cbo_T", this.wRetirementStudio.wDeduction_cbo_T.cbo, dic["Deduction_cbo_T"], 0);


                if (dic["Deduction_V"] != "")
                    icbo = 2;

                if (dic["Deduction_T"] != "")
                    icbo_T = 2;

                if (dic["DeductionAnnual_V"] != "")
                    this.wRetirementStudio.wDeduction_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo.ToString() );

                if (dic["DeductionAnnual_V"] != "")
                    this.wRetirementStudio.wDeduction_cbo_T.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo_T.ToString());


                _gLib._SetSyncUDWin("DeductionAnnual_cbo", this.wRetirementStudio.wDeduction_cbo.cbo,  dic["DeductionAnnual_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeductionAnnual_txt", this.wRetirementStudio.wDeductionannualIncrease_txt.txt.UI_numEditRateEdit1, dic["DeductionAnnual_txt"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_cbo_T", this.wRetirementStudio.wDeduction_cbo_T.cbo, dic["DeductionAnnual_cbo_T"], 0);
        
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
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
        ///    dic.Add("Deduction_V", "");
        ///    dic.Add("Deduction_C", "");
        ///    dic.Add("DeductionAnnual_V", "");
        ///    dic.Add("DeductionAnnual_P", "");
        ///    dic.Add("ApplyAverageLimitAmount_C", "");
        ///    dic.Add("ApplyAverageLimitAmount_txt", "");
        ///    dic.Add("ApplyAverageAnnualLimitIncrease_V", "");
        ///    dic.Add("ApplyAverageAnnualLimitIncrease_cbo", "");
        ///    pPayAverage._PopVerify_ApplyDeductionBeforeAverageing_And_ApplyAveragePayLimit(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ApplyDeductionBeforeAverageing_And_ApplyAveragePayLimit(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ApplyDeductionBeforeAverageing_And_ApplyAveragePayLimit";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                int icbo = 1, itxt = 1;
             

                _gLib._SetSyncUDWin("Deduction_V", this.wRetirementStudio.wDeduction_V.btn, dic["Deduction_V"], 0);
                _gLib._SetSyncUDWin("Deduction_C", this.wRetirementStudio.wDeduction_C.btn, dic["Deduction_C"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_V", this.wRetirementStudio.wDeductionAnnualIncrease_V.btn, dic["DeductionAnnual_V"], 0);
                _gLib._SetSyncUDWin("DeductionAnnual_P", this.wRetirementStudio.wDeductionAnnualIncrease_C.btn, dic["DeductionAnnual_P"], 0);
                _gLib._SetSyncUDWin("ApplyAverageLimitAmount_C", this.wRetirementStudio.wApplyAveragePayLimit_LimitAmount_C.btn, dic["ApplyAverageLimitAmount_C"], 0);
                _gLib._SetSyncUDWin("ApplyAverageAnnualLimitIncrease_V", this.wRetirementStudio.wApplyAveragePayLimit_AnnualLimitIncrease_V.btn, dic["ApplyAverageAnnualLimitIncrease_V"], 0);


                if (dic["Deduction_C"] != "") itxt++;
                this.wRetirementStudio.wDeduction_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, itxt.ToString());
                   
                _gLib._SetSyncUDWin_ByClipboard("ApplyAverageLimitAmount_txt", this.wRetirementStudio.wDeduction_txt.txt.UI_numEditConstantEdit1, dic["ApplyAverageLimitAmount_txt"], 0);


                if (dic["Deduction_V"] != "") icbo ++ ;
                if (dic["DeductionAnnual_V"] != "") icbo++;
                if (dic["ApplyAverageAnnualLimitIncrease_V"] != "")
                    this.wRetirementStudio.wDeduction_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo.ToString());
                _gLib._SetSyncUDWin("ApplyAverageAnnualLimitIncrease_cbo", this.wRetirementStudio.wDeduction_cbo.cbo, dic["ApplyAverageAnnualLimitIncrease_cbo"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
