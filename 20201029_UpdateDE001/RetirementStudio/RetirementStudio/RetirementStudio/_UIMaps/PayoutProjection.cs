namespace RetirementStudio._UIMaps.PayoutProjectionClasses
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

    
    public partial class PayoutProjection
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
        ///    dic.Add("History", "True");
        ///    dic.Add("PresentYear", "");
        ///    dic.Add("FunctionOfOtherProjections", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("IgnoreYearWithHoursLess", "");
        ///    dic.Add("PlanPayLimitDefinition", "");
        ///    dic.Add("ApplyDeduction", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction", "");
        ///    dic.Add("ApplySalaryMinimum", "");
        ///    dic.Add("LegislatedPayLimitDefinition", "");
        ///    pPayoutProjection._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("History", this.wRetirementStudio.wHistory.rdHistory, dic["History"], 0);
                _gLib._SetSyncUDWin("PresentYear", this.wRetirementStudio.wPresentYear.rdPresentYear, dic["PresentYear"], 0);
                _gLib._SetSyncUDWin("FunctionOfOtherProjections", this.wRetirementStudio.wFunctionOfOtherProjections.rdFunctionOfOtherProjections, dic["FunctionOfOtherProjections"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("PlanPayLimitDefinition", this.wRetirementStudio.wPlanPayLimitDefinition.chkPlanPayLimitDefinition, dic["PlanPayLimitDefinition"], 0);
                _gLib._SetSyncUDWin("IgnoreYearWithHoursLess", this.wRetirementStudio.wIgnoreYearsWithHours.chk, dic["IgnoreYearWithHoursLess"], 0);
                _gLib._SetSyncUDWin("ApplyDeduction", this.wRetirementStudio.wApplyDeduction.chk, dic["ApplyDeduction"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction", this.wRetirementStudio.wApplypaylimitafterdeduction.chk, dic["ApplyPayLimitAfterDeduction"], 0);
                _gLib._SetSyncUDWin("LegislatedPayLimitDefinition", this.wRetirementStudio.wLegislatedPayLimitDefinition.chkLegislatedPayLimitDefinition, dic["LegislatedPayLimitDefinition"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction", this.wRetirementStudio.wApplypaylimitafterdeduction.chk, dic["ApplyPayLimitAfterDeduction"], 0);
                _gLib._SetSyncUDWin("ApplySalaryMinimum", this.wRetirementStudio.wApplySalaryMinimum.chk, dic["ApplySalaryMinimum"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("History", this.wRetirementStudio.wHistory.rdHistory, dic["History"], 0);
                _gLib._VerifySyncUDWin("PresentYear", this.wRetirementStudio.wPresentYear.rdPresentYear, dic["PresentYear"], 0);
                _gLib._VerifySyncUDWin("FunctionOfOtherProjections", this.wRetirementStudio.wFunctionOfOtherProjections.rdFunctionOfOtherProjections, dic["FunctionOfOtherProjections"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("PlanPayLimitDefinition", this.wRetirementStudio.wPlanPayLimitDefinition.chkPlanPayLimitDefinition, dic["PlanPayLimitDefinition"], 0);
                _gLib._VerifySyncUDWin("ApplyDeduction", this.wRetirementStudio.wApplyDeduction.chk, dic["ApplyDeduction"], 0);
                _gLib._VerifySyncUDWin("LegislatedPayLimitDefinition", this.wRetirementStudio.wLegislatedPayLimitDefinition.chkLegislatedPayLimitDefinition, dic["LegislatedPayLimitDefinition"], 0);

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
        ///    dic.Add("DataFieldContainingPayHistory", "Salary");
        ///    dic.Add("PayIncreaseAssumption", "PayIncrease1");
        ///    dic.Add("UseOnlyDataFields", "");
        ///    dic.Add("rdValuationYearPlus", "");
        ///    dic.Add("txtValuationYearPlus", "");
        ///    dic.Add("rdSpecifiedYear", "");
        ///    dic.Add("txtSpecifiedYear", "");
        ///    dic.Add("ApplyEGTRRALimits", "False");
        ///    pPayoutProjection._PopVerify_History(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_History(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_History";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("DataFieldContainingPayHistory", this.wRetirementStudio.wHistory_DataFieldContainingPayHistory.cboDataFieldContainingPayHistory, dic["DataFieldContainingPayHistory"], 0);
                _gLib._SetSyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
                _gLib._SetSyncUDWin("UseOnlyDataFields", this.wRetirementStudio.wHistory_UseOnlyDataFields.chkUseOnlyDataFields, dic["UseOnlyDataFields"], 0);
                _gLib._SetSyncUDWin("rdValuationYearPlus", this.wRetirementStudio.wHistory_ValuationYearPlus_rd.rdValuationYearPlus, dic["rdValuationYearPlus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtValuationYearPlus", this.wRetirementStudio.wHistory_ValuationYearPlus_txt.txtValuationYearPlus, dic["txtValuationYearPlus"], true, 0);
                _gLib._SetSyncUDWin("rdSpecifiedYear", this.wRetirementStudio.wHistory_SpecifiedYear_rd.rdSpecifiedYear, dic["rdSpecifiedYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtSpecifiedYear", this.wRetirementStudio.wHistory_SpecifedYear_txt.txtSpecifiedYear, dic["txtSpecifiedYear"], true, 0);
                _gLib._SetSyncUDWin("ApplyEGTRRALimits", this.wRetirementStudio.wHistory_ApplyEGTRRALimits.chkApplyEGTRRALimits, dic["ApplyEGTRRALimits"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("DataFieldContainingPayHistory", this.wRetirementStudio.wHistory_DataFieldContainingPayHistory.cboDataFieldContainingPayHistory, dic["DataFieldContainingPayHistory"], 0);
                _gLib._VerifySyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
                _gLib._VerifySyncUDWin("UseOnlyDataFields", this.wRetirementStudio.wHistory_UseOnlyDataFields.chkUseOnlyDataFields, dic["UseOnlyDataFields"], 0);
                _gLib._VerifySyncUDWin("rdValuationYearPlus", this.wRetirementStudio.wHistory_ValuationYearPlus_rd.rdValuationYearPlus, dic["rdValuationYearPlus"], 0);
                _gLib._VerifySyncUDWin("txtValuationYearPlus", this.wRetirementStudio.wHistory_ValuationYearPlus_txt.txtValuationYearPlus, dic["txtValuationYearPlus"], 0);
                _gLib._VerifySyncUDWin("rdSpecifiedYear", this.wRetirementStudio.wHistory_SpecifiedYear_rd.rdSpecifiedYear, dic["rdSpecifiedYear"], 0);
                _gLib._VerifySyncUDWin("txtSpecifiedYear", this.wRetirementStudio.wHistory_SpecifedYear_txt.txtSpecifiedYear, dic["txtSpecifiedYear"], 0);
                _gLib._VerifySyncUDWin("ApplyEGTRRALimits", this.wRetirementStudio.wHistory_ApplyEGTRRALimits.chkApplyEGTRRALimits, dic["ApplyEGTRRALimits"], 0);
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
        ///    dic.Add("Deduction_cbo_V", "");
        ///    dic.Add("Deduction_txt", "");
        ///    dic.Add("Deduction_cbo_T", "");
        ///    dic.Add("DeductionAnnualIncrease_V", "");
        ///    dic.Add("DeductionAnnualIncrease_P", "");
        ///    dic.Add("DeductionAnnualIncrease_T", "");
        ///    dic.Add("DeductionAnnualIncrease_cbo_V", "");
        ///    dic.Add("DeductionAnnualIncrease_txt", "");
        ///    dic.Add("DeductionAnnualIncrease_cbo_T", "");
        ///    pPayoutProjection._PopVerify_ApplyDeduction(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ApplyDeduction(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ApplyDeduction";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Deduction_V", this.wRetirementStudio.wDeduction_V.btn, dic["Deduction_V"], 0);
                _gLib._SetSyncUDWin("Deduction_C", this.wRetirementStudio.wDeduction_C.btn, dic["Deduction_C"], 0);
                _gLib._SetSyncUDWin("Deduction_T", this.wRetirementStudio.wDeduction_T.btn, dic["Deduction_T"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_V", this.wRetirementStudio.wDeductionAnnualIncrease_V.btn, dic["DeductionAnnualIncrease_V"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_P", this.wRetirementStudio.wDeductionAnnualIncrease_P.btn, dic["DeductionAnnualIncrease_P"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_T", this.wRetirementStudio.wDeductionAnnualIncrease_T.btn, dic["DeductionAnnualIncrease_T"], 0);

                _gLib._SetSyncUDWin("Deduction_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Deduction_cbo_V"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Deduction_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Deduction_txt"], 0);
                _gLib._SetSyncUDWin("Deduction_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Deduction_cbo_T"], 0);

                if (dic["DeductionAnnualIncrease_cbo_V"] != "")
                {
                    string sInstance = "1";
                    if (dic["Deduction_V"] != "") sInstance = "2";
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["DeductionAnnualIncrease_cbo_V"], 0);
                }

                _gLib._SetSyncUDWin_ByClipboard("DeductionAnnualIncrease_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["DeductionAnnualIncrease_txt"], 0);

                if (dic["DeductionAnnualIncrease_cbo_T"] != "")
                {
                    string sInstance = "1";
                    if (dic["Deduction_T"] != "") sInstance = "2";
                    this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["DeductionAnnualIncrease_cbo_T"], 0);
                }


                        

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No verify fucnction!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-16
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Deduction_V", "");
        ///    dic.Add("Deduction_C", "");
        ///    dic.Add("Deduction_T", "");
        ///    dic.Add("Deduction_cbo_V", "");
        ///    dic.Add("Deduction_txt", "");
        ///    dic.Add("Deduction_cbo_T", "");
        ///    
        ///    dic.Add("DeductionAnnualIncrease_V", "");
        ///    dic.Add("DeductionAnnualIncrease_P", "");
        ///    dic.Add("DeductionAnnualIncrease_T", "");
        ///    dic.Add("DeductionAnnualIncrease_cbo_V", "");
        ///    dic.Add("DeductionAnnualIncrease_txt", "");
        ///    dic.Add("DeductionAnnualIncrease_cbo_T", ""); 
        ///    
        ///    dic.Add("LimitAmount_C", "");
        ///    dic.Add("LimitAmount_C_txt", "");
        ///    dic.Add("AnnualLimitIncrease_P", "");
        ///    dic.Add("AnnualLimitIncrease_P_txt", "");
        ///    pPayoutProjection._ApplyPayLimitAfterDeduction_WithDeduction(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ApplyPayLimitAfterDeduction_WithDeduction(MyDictionary dic)
        {
            string sFunctionName = "_ApplyPayLimitAfterDeduction_WithDeduction";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Deduction_V", this.wRetirementStudio.wDeduction_V.btn, dic["Deduction_V"], 0);
                _gLib._SetSyncUDWin("Deduction_C", this.wRetirementStudio.wDeduction_C.btn, dic["Deduction_C"], 0);
                _gLib._SetSyncUDWin("Deduction_T", this.wRetirementStudio.wDeduction_T.btn, dic["Deduction_T"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_V", this.wRetirementStudio.wDeductionAnnualIncrease_V.btn, dic["DeductionAnnualIncrease_V"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_P", this.wRetirementStudio.wDeductionAnnualIncrease_P.btn, dic["DeductionAnnualIncrease_P"], 0);
                _gLib._SetSyncUDWin("DeductionAnnualIncrease_T", this.wRetirementStudio.wDeductionAnnualIncrease_T.btn, dic["DeductionAnnualIncrease_T"], 0);
                _gLib._SetSyncUDWin("LimitAmount_C", this.wRetirementStudio.wLimitAmount_C.btn, dic["LimitAmount_C"], 0);
                _gLib._SetSyncUDWin("AnnualLimitIncrease_P", this.wRetirementStudio.wAnnualLimitIncrease_P.btn, dic["AnnualLimitIncrease_P"], 0);
                _gLib._SetSyncUDWin("AnnualLimitIncrease_V", this.wRetirementStudio.wAnnualLimitIncrease_V.btn, dic["AnnualLimitIncrease_V"], 0);


                _gLib._SetSyncUDWin("Deduction_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Deduction_cbo_V"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Deduction_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Deduction_txt"], 0);
                _gLib._SetSyncUDWin("Deduction_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Deduction_cbo_T"], 0);


                if (dic["DeductionAnnualIncrease_cbo_V"] != "")
                {
                    string sInstance = "1";
                    if (dic["Deduction_V"] != "") sInstance = "2";
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["DeductionAnnualIncrease_cbo_V"], 0);
                }

                _gLib._SetSyncUDWin_ByClipboard("DeductionAnnualIncrease_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["DeductionAnnualIncrease_txt"], 0);

                if (dic["DeductionAnnualIncrease_cbo_T"] != "")
                {
                    string sInstance = "1";
                    if (dic["Deduction_T"] != "") sInstance = "2";
                    this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["DeductionAnnualIncrease_cbo_T"], 0);
                }

                

                if (dic["LimitAmount_C"] != "")
                {
                    if (dic["Deduction_C"] != "")
                        this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin_ByClipboard("LimitAmount_C", this.wRetirementStudio.wCommon_txt_C.txt, dic["LimitAmount_C_txt"], 0);
                }
                
                if (dic["AnnualLimitIncrease_P"] != "")
                {
                    if (dic["DeductionAnnualIncrease_P"] != "")
                        this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin_ByClipboard("AnnualLimitIncrease_P", this.wRetirementStudio.wCommon_txt_P.txt, dic["AnnualLimitIncrease_P_txt"], 0);
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No verify fucnction!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-16
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Deduction_C", "");
        ///    dic.Add("Deduction_txt", "");
        ///    dic.Add("DeductionAnnualIncrease_V", "");
        ///    dic.Add("DeductionAnnualIncrease_cbo_V", "");
        ///    dic.Add("PlanPayLimitAmount_C", "");
        ///    dic.Add("PlanPayLimitAmount_txt", "");
        ///    dic.Add("PlanPayAnnualLimitIncrease_V", "");
        ///    dic.Add("PlanPayAnnualLimitIncrease_cbo", "");
        ///    pPayoutProjection._ApplyPayLimitDeduction_WithDeduction(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ApplyPayLimitDeduction_WithDeduction(MyDictionary dic)
        {
            string sFunctionName = "_ApplyPayLimitDeduction_WithDeduction";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
            
                _gLib._SetSyncUDWin("Deduction_C", this.wRetirementStudio.wLimitAmount_C.btn, dic["Deduction_C"], 0);
                if (dic["DeductionAnnualIncrease_V"] != "")
                {   this.wRetirementStudio.wDeductionAnnualIncrease_V.SearchProperties.Add(WinButton.PropertyNames.Instance, "3");
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_V", this.wRetirementStudio.wDeductionAnnualIncrease_V.btn, dic["DeductionAnnualIncrease_V"], 0);
                }
                _gLib._SetSyncUDWin("PlanPayLimitAmount_C", this.wRetirementStudio.wDeduction_C.btn, dic["PlanPayLimitAmount_C"], 0);
                _gLib._SetSyncUDWin("PlanPayAnnualLimitIncrease_V", this.wRetirementStudio.wDeduction_V.btn, dic["PlanPayAnnualLimitIncrease_V"], 0);


                ////// next function just suitable for nl001, if  you need add parameter please connect lori..
                if (dic["Deduction_C"] != ""  )
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin_ByClipboard("Deduction_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Deduction_txt"], 0);
                }

                if (dic["DeductionAnnualIncrease_cbo_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin("DeductionAnnualIncrease_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["DeductionAnnualIncrease_cbo_V"], 0);
                }


                if (dic["PlanPayLimitAmount_txt"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1");
                    _gLib._SetSyncUDWin_ByClipboard("PlanPayLimitAmount_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["PlanPayLimitAmount_txt"], 0);
                }

                if (dic["PlanPayAnnualLimitIncrease_cbo"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "1");
                    _gLib._SetSyncUDWin("PlanPayAnnualLimitIncrease_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["PlanPayAnnualLimitIncrease_cbo"], 0);
                }

            }



           
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No verify fucnction!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
        

        /// <summary>
        /// 2015-June-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("UseCurrentYearPayRateFrom", "SalaryCurrentYear");
        ///    dic.Add("PayIncreaseAssumption", "PayIncrease1");
        ///    pPayoutProjection._PopVerify_PresentYear(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PresentYear(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PresentYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("UseCurrentYearPayRateFrom", this.wRetirementStudio.wPresentYear_UseCurrentYearPayRateFrom.cbo, dic["UseCurrentYearPayRateFrom"], 0);
                _gLib._SetSyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
  

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("UseCurrentYearPayRateFrom", this.wRetirementStudio.wPresentYear_UseCurrentYearPayRateFrom.cbo, dic["UseCurrentYearPayRateFrom"], 0);
                _gLib._VerifySyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Mar-18
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("DataFieldContainingPayHistory", "");
        ///    dic.Add("PayIncreaseAssumption", "");
        ///    dic.Add("UseOnlyDataFields", ""); 

        ///    dic.Add("SalaryMinimum_SalaryMinimum_V", "");
        ///    dic.Add("SalaryMinimum_SalaryMinimum_cbo", "");
        ///    dic.Add("SalaryMinimum_SalaryMinimum_C", "");
        ///    dic.Add("SalaryMinimum_SalaryMinimum_txt", "");        
        ///    dic.Add("SalaryMinimum_Multiplier", "");
        ///    
        ///    dic.Add("PlanPayLimit_LimitAmount_V", "");
        ///    dic.Add("PlanPayLimit_LimitAmount_cbo", "");
        ///    dic.Add("PlanPayLimit_LimitAmount_C", "");
        ///    dic.Add("PlanPayLimit_LimitAmount_txt", "");
        ///    dic.Add("PlanPayLimit_Multiplier", "");
        ///    dic.Add("PlanPayLimit_AnnualLimitIncrease_V", "");
        ///    dic.Add("PlanPayLimit_AnnualLimitIncrease_cbo", "");
        ///    dic.Add("PlanPayLimit_AnnualLimitIncrease_P", "");
        ///    dic.Add("PlanPayLimit_AnnualLimitIncrease_txt", "");
        ///    
        ///    dic.Add("ApplyDeduction_Deduction_V", "");
        ///    dic.Add("ApplyDeduction_Deduction_cbo", "");
        ///    dic.Add("ApplyDeduction_Deduction_C", "");
        ///    dic.Add("ApplyDeduction_Deduction_txt", "");
        ///    dic.Add("ApplyDeduction_DeductionAnnualIncrease_V", "");
        ///    dic.Add("ApplyDeduction_DeductionAnnualIncrease_cbo", "");
        ///    dic.Add("ApplyDeduction_DeductionAnnualIncrease_P", "");
        ///    dic.Add("ApplyDeduction_DeductionAnnualIncrease_txt", "");
        ///    
        ///    dic.Add("ApplyPayLimitAfterDeduction_LimitAmount_V", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_LimitAmount_cbo", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_LimitAmount_C", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_LimitAmount_txt", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_Multiplier", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_V", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_cbo", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_P", "");
        ///    dic.Add("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_txt", "");
        ///    pPayoutProjection._PlanPayLimitDefinition_ApplyDeduction_ApplyPayLimitAfterDeduction_ApplySala(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PlanPayLimitDefinition_ApplyDeduction_ApplyPayLimitAfterDeduction_ApplySala(MyDictionary dic)
        {
            string sFunctionName = "_ApplyPayLimitDeduction_WithDeduction";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                int iV = 1, iC = 1, iP = 1;

                _gLib._SetSyncUDWin("DataFieldContainingPayHistory", this.wRetirementStudio.wHistory_DataFieldContainingPayHistory.cboDataFieldContainingPayHistory, dic["DataFieldContainingPayHistory"], 0);
                _gLib._SetSyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
                _gLib._SetSyncUDWin("UseOnlyDataFields", this.wRetirementStudio.wHistory_UseOnlyDataFields.chkUseOnlyDataFields, dic["UseOnlyDataFields"], 0);
            
                _gLib._SetSyncUDWin("SalaryMinimum_SalaryMinimum_V", this.wRetirementStudio.wDeduction_V.btn, dic["SalaryMinimum_SalaryMinimum_V"], 0);
                _gLib._SetSyncUDWin("SalaryMinimum_SalaryMinimum_C", this.wRetirementStudio.wDeduction_C.btn, dic["SalaryMinimum_SalaryMinimum_C"], 0);
                _gLib._SetSyncUDWin("PlanPayLimit_LimitAmount_V", this.wRetirementStudio.wPlan_V.btn, dic["PlanPayLimit_LimitAmount_V"], 0);
                _gLib._SetSyncUDWin("PlanPayLimit_LimitAmount_C", this.wRetirementStudio.wPlan_C.btn, dic["PlanPayLimit_LimitAmount_C"], 0);
                _gLib._SetSyncUDWin("PlanPayLimit_AnnualLimitIncrease_V", this.wRetirementStudio.wPlan_Annual_V.btn, dic["PlanPayLimit_AnnualLimitIncrease_V"], 0);
                _gLib._SetSyncUDWin("PlanPayLimit_AnnualLimitIncrease_P", this.wRetirementStudio.wPlan_Annual_P.btn, dic["PlanPayLimit_AnnualLimitIncrease_P"], 0);
                _gLib._SetSyncUDWin("ApplyDeduction_Deduction_V", this.wRetirementStudio.wApplyD_Deduction_V.btn, dic["ApplyDeduction_Deduction_V"], 0);
                _gLib._SetSyncUDWin("ApplyDeduction_Deduction_C", this.wRetirementStudio.wApplyD_Deduction_C.btn, dic["ApplyDeduction_Deduction_C"], 0);
                _gLib._SetSyncUDWin("ApplyDeduction_DeductionAnnualIncrease_V", this.wRetirementStudio.wApplyD_Annual_V.btn, dic["ApplyDeduction_DeductionAnnualIncrease_V"], 0);
                _gLib._SetSyncUDWin("ApplyDeduction_DeductionAnnualIncrease_P", this.wRetirementStudio.wApplyD_Annual_P.btn, dic["ApplyDeduction_DeductionAnnualIncrease_P"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_LimitAmount_V", this.wRetirementStudio.wApplyP_LimitA_V.btn, dic["ApplyPayLimitAfterDeduction_LimitAmount_V"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_LimitAmount_C", this.wRetirementStudio.wApplyP_LimitA_C.btn, dic["ApplyPayLimitAfterDeduction_LimitAmount_C"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_V", this.wRetirementStudio.wApplyP_Annual_V.btn, dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_V"], 0);
                _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_P", this.wRetirementStudio.wApplyP_Annual_P.btn, dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_P"], 0);


                if (dic["SalaryMinimum_SalaryMinimum_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("SalaryMinimum_SalaryMinimum_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["SalaryMinimum_SalaryMinimum_cbo"], 0);
                    iV ++;
                }
                if (dic["SalaryMinimum_SalaryMinimum_C"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("SalaryMinimum_SalaryMinimum_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["SalaryMinimum_SalaryMinimum_txt"], 0);
                    iC++;
                }

                _gLib._SetSyncUDWin_ByClipboard("SalaryMinimum_Multiplier", this.wRetirementStudio.wSalaryMiniMultipl.txt, dic["SalaryMinimum_Multiplier"], 0);

////

                if (dic["PlanPayLimit_LimitAmount_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("PlanPayLimit_LimitAmount_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["PlanPayLimit_LimitAmount_cbo"], 0);
                    iV++;
                }
                if (dic["PlanPayLimit_LimitAmount_C"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PlanPayLimit_LimitAmount_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["PlanPayLimit_LimitAmount_txt"], 0);
                    iC++;
                }

                _gLib._SetSyncUDWin_ByClipboard("PlanPayLimit_Multiplier", this.wRetirementStudio.wPlanPayLimitMulti.txt, dic["PlanPayLimit_Multiplier"], 0);

                if (dic["PlanPayLimit_AnnualLimitIncrease_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("PlanPayLimit_AnnualLimitIncrease_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["PlanPayLimit_AnnualLimitIncrease_cbo"], 0);
                    iV++;
                }
                if (dic["PlanPayLimit_AnnualLimitIncrease_P"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PlanPayLimit_AnnualLimitIncrease_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["PlanPayLimit_AnnualLimitIncrease_txt"], 0);
                    iP++;
                }

////
                if (dic["ApplyDeduction_Deduction_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("ApplyDeduction_Deduction_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["ApplyDeduction_Deduction_cbo"], 0);
                    iV++;
                }
                if (dic["ApplyDeduction_Deduction_C"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("ApplyDeduction_Deduction_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["ApplyDeduction_Deduction_txt"], 0);
                    iC++;
                }
                

                if (dic["ApplyDeduction_DeductionAnnualIncrease_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("ApplyDeduction_DeductionAnnualIncrease_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["ApplyDeduction_DeductionAnnualIncrease_cbo"], 0);
                    iV++;
                }
                if (dic["ApplyDeduction_DeductionAnnualIncrease_P"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("ApplyDeduction_DeductionAnnualIncrease_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["ApplyDeduction_DeductionAnnualIncrease_txt"], 0);
                    iP++;
                }

////

                if (dic["ApplyPayLimitAfterDeduction_LimitAmount_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_LimitAmount_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["ApplyPayLimitAfterDeduction_LimitAmount_cbo"], 0);
                    iV++;
                }
                if (dic["ApplyPayLimitAfterDeduction_LimitAmount_C"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("ApplyPayLimitAfterDeduction_LimitAmount_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["ApplyPayLimitAfterDeduction_LimitAmount_txt"], 0);
                    iC++;
                }
            
                _gLib._SetSyncUDWin_ByClipboard("ApplyPayLimitAfterDeduction_Multiplier", this.wRetirementStudio.wPayLimitAfterDedu.txt, dic["ApplyPayLimitAfterDeduction_Multiplier"], 0);


                if (dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinButton.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_cbo"], 0);
                    iV++;
                }
                if (dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_P"] != "")
                {
                    this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("ApplyPayLimitAfterDeduction_AnnualLimitIncrease_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["ApplyPayLimitAfterDeduction_AnnualLimitIncrease_txt"], 0);
                    iP++;
                }

            }




            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No verify fucnction!");
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
        ///    dic.Add("DataFieldContainingPayHistory", "Salary");
        ///    dic.Add("PayIncreaseAssumption", "PayIncrease1");
        ///    dic.Add("UseOnlyDataFields", "");
        ///    dic.Add("IgnoreYears_Hours", "");
        ///    dic.Add("IgnoreYears_DataFieldcontainingHours", "");
        ///    pPayoutProjection._PopVerify_History_IgnoreYearsWithHours(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_History_IgnoreYearsWithHours(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_History_IgnoreYearsWithHours";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("DataFieldContainingPayHistory", this.wRetirementStudio.wHistory_DataFieldContainingPayHistory.cboDataFieldContainingPayHistory, dic["DataFieldContainingPayHistory"], 0);
                _gLib._SetSyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
                _gLib._SetSyncUDWin("UseOnlyDataFields", this.wRetirementStudio.wHistory_UseOnlyDataFields.chkUseOnlyDataFields, dic["UseOnlyDataFields"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IgnoreYears_Hours", this.wRetirementStudio.wHoursThreshold.txt.UINumHoursEdit1, dic["IgnoreYears_Hours"], 0);
                _gLib._SetSyncUDWin("IgnoreYears_DataFieldcontainingHours", this.wRetirementStudio.wIgnore_DataFieldContaining.cbo, dic["IgnoreYears_DataFieldcontainingHours"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("DataFieldContainingPayHistory", this.wRetirementStudio.wHistory_DataFieldContainingPayHistory.cboDataFieldContainingPayHistory, dic["DataFieldContainingPayHistory"], 0);
                _gLib._VerifySyncUDWin("PayIncreaseAssumption", this.wRetirementStudio.wHistory_PayIncreaseAssumption.cboPayIncreaseAssumption, dic["PayIncreaseAssumption"], 0);
                _gLib._VerifySyncUDWin("UseOnlyDataFields", this.wRetirementStudio.wHistory_UseOnlyDataFields.chkUseOnlyDataFields, dic["UseOnlyDataFields"], 0);
                      }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
