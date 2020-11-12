namespace RetirementStudio._UIMaps.PlanDefinition_DEClasses
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
    
    
    
    public partial class PlanDefinition_DE
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("YearsOfServiceForJubi", "5");
        ///    dic.Add("BasedOn", "JubiEligDate");
        ///    dic.Add("YearlySalary", "PayProjection1");
        ///    dic.Add("ApplyPercentMarried", "");
        ///    pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDefinition_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDefinition_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("YearsOfServiceForJubi", this.wRetirementStudio.wYearsOfServiceForJubi.txt, dic["YearsOfServiceForJubi"], 0);
                _gLib._SetSyncUDWin("BasedOn", this.wRetirementStudio.wBasedOn.cbo, dic["BasedOn"], 0);
                _gLib._SetSyncUDWin("YearlySalary", this.wRetirementStudio.wYearlySalary.cbo, dic["YearlySalary"], 0);
                _gLib._SetSyncUDWin("ApplyPercentMarried", this.wRetirementStudio.wApplyPercentMarried.chk, dic["ApplyPercentMarried"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("YearsOfServiceForJubi", this.wRetirementStudio.wYearsOfServiceForJubi.txt, dic["YearsOfServiceForJubi"], 0);
                _gLib._VerifySyncUDWin("BasedOn", this.wRetirementStudio.wBasedOn.cbo, dic["BasedOn"], 0);
                _gLib._VerifySyncUDWin("YearlySalary", this.wRetirementStudio.wYearlySalary.cbo, dic["YearlySalary"], 0);
                _gLib._VerifySyncUDWin("ApplyPercentMarried", this.wRetirementStudio.wApplyPercentMarried.chk, dic["ApplyPercentMarried"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("JubileeBenefit", "JubileeBenefit1");
        ///    dic.Add("Eligibility", "");
        ///    dic.Add("Factor", "");
        ///    dic.Add("Jubilee", "True");
        ///    dic.Add("Retirement", "");
        ///    dic.Add("Disability", "");
        ///    dic.Add("Death", "");
        ///    dic.Add("GraceYears", "");
        ///    dic.Add("GraceFactor", "1,00000");
        ///    pPlanDefinition_DE._Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table(MyDictionary dic)
        {

            string sFunctionName = "_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            int iPosX = 40;
            int iPosY = 20 * iRow + 10;

            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            //if (iRow >= 6)
            //{
            //    _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 3, false, 670, 50);
            //    _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}", 0);
            //}

            ////////_gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);

            if (dic["JubileeBenefit"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                _gLib._SendKeysUDWin("sData", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                _gLib._SetSyncUDWin("JubileeBenefit", this.wRetirementStudio.wCommon_cbo.cbo, dic["JubileeBenefit"], 0);
            }

            if (dic["Eligibility"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                _gLib._SetSyncUDWin("Eligibility", this.wRetirementStudio.wCommon_cbo.cbo, dic["Eligibility"], 0);
            }
            if (dic["Factor"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}");
                _gLib._SetSyncUDWin_ByClipboard("Factor", this.wRetirementStudio.wCommon_txt.txt, dic["Factor"], 0);
            }

            if (dic["Jubilee"] != "")
            {
                Clipboard.Clear();

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}{Space}");

                string sAct = "";
                sAct = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sAct.ToUpper().Contains(dic["Jubilee"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");

                sAct = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sAct.ToUpper().Contains(dic["Jubilee"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}");

                sAct = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sAct.ToUpper().Contains(dic["Jubilee"].ToUpper()))
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["Jubilee"] + "> at Row  <" + iRow + ">");
            }

            if (dic["Retirement"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                Clipboard.Clear();

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}{Space}");


                string sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Retirement"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");

                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Retirement"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}");
                
                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Retirement"].ToUpper()))
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["Retirement"] + "> at Row  <" + iRow + ">");
            }
            if (dic["Disability"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");
                
                string sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Disability"].ToUpper()))
                    _gLib._SendKeysUDWin("Disability", this.wRetirementStudio.wFPGrid.grid, "{Space}");

                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Disability"].ToUpper()))
                    _gLib._SendKeysUDWin("Disability", this.wRetirementStudio.wFPGrid.grid, "{Space}");
               
                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Disability"].ToUpper()))
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["Disability"] + "> at Row  <" + iRow + ">");
            }

            if (dic["Death"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                Clipboard.Clear();

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");
                string sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);

                if (!sData.ToUpper().Contains(dic["Death"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}");

                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Death"].ToUpper()))
                    _gLib._SendKeysUDWin("Jubilee", this.wRetirementStudio.wFPGrid.grid, "{Space}");
               
                sData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);
                if (!sData.ToUpper().Contains(dic["Death"].ToUpper()))
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["Death"] + "> at Row  <" + iRow + ">");
            }
            if (dic["GraceYears"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SetSyncUDWin_ByClipboard("GraceYears", this.wRetirementStudio.wCommon_txt.txt, dic["GraceYears"], 0);
            }
            if (dic["GraceFactor"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 1, false, iPosX, iPosY);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SetSyncUDWin_ByClipboard("GraceFactor", this.wRetirementStudio.wCommon_txt.txt, dic["GraceFactor"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2015-May-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SingleFormulaOrBenefit", "True");
        ///    dic.Add("FunctionOfOtherFormular", "");
        ///    dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
        ///    dic.Add("UseAsWithdrawalBenefit", "");
        ///    dic.Add("UseAsFutureValPension", "True");
        ///    dic.Add("ApplyVersorgungsausgleich", "");
        ///    dic.Add("IncludeIn2DCasgFlows", "");
        ///    pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDefinition_DE_Pension_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDefinition_DE_Pension_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("SingleFormulaOrBenefit", this.wRetirementStudio.wSingleFormulaOrBenefit.rd, dic["SingleFormulaOrBenefit"], 0);
                _gLib._SetSyncUDWin("FunctionOfOtherFormular", this.wRetirementStudio.wFunctionOfOtherFormular.rd, dic["FunctionOfOtherFormular"], 0);
                _gLib._SetSyncUDWin("IncludeThisBenefitInPresentValueCalc", this.wRetirementStudio.wIncludeThisBenefitInPresentValueCalc.chk, dic["IncludeThisBenefitInPresentValueCalc"], 0);
                _gLib._SetSyncUDWin("UseAsWithdrawalBenefit", this.wRetirementStudio.wUseAsWithdrawalBenefit.chk, dic["UseAsWithdrawalBenefit"], 0);
                _gLib._SetSyncUDWin("UseAsFutureValPension", this.wRetirementStudio.wUseAsFutureValPension.chk, dic["UseAsFutureValPension"], 0);
                _gLib._SetSyncUDWin("ApplyVersorgungsausgleich", this.wRetirementStudio.wApplyVersorgungsausgleich.chk, dic["ApplyVersorgungsausgleich"], 0);

                _gLib._SetSyncUDWin("IncludeIn2DCasgFlows", this.wRetirementStudio.wIncludein2DCashflows.chk, dic["IncludeIn2DCasgFlows"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SingleFormulaOrBenefit", this.wRetirementStudio.wSingleFormulaOrBenefit.rd, dic["SingleFormulaOrBenefit"], 0);
                _gLib._VerifySyncUDWin("FunctionOfOtherFormular", this.wRetirementStudio.wFunctionOfOtherFormular.rd, dic["FunctionOfOtherFormular"], 0);
                _gLib._VerifySyncUDWin("IncludeThisBenefitInPresentValueCalc", this.wRetirementStudio.wIncludeThisBenefitInPresentValueCalc.chk, dic["IncludeThisBenefitInPresentValueCalc"], 0);
                _gLib._VerifySyncUDWin("UseAsWithdrawalBenefit", this.wRetirementStudio.wUseAsWithdrawalBenefit.chk, dic["UseAsWithdrawalBenefit"], 0);
                _gLib._VerifySyncUDWin("UseAsFutureValPension", this.wRetirementStudio.wUseAsFutureValPension.chk, dic["UseAsFutureValPension"], 0);
                _gLib._VerifySyncUDWin("ApplyVersorgungsausgleich", this.wRetirementStudio.wApplyVersorgungsausgleich.chk, dic["ApplyVersorgungsausgleich"], 0);

            }


            _gLib._SetSyncUDWin_ByClipboard("YearsOfServiceForJubi", this.wRetirementStudio.wYearsOfServiceForJubi.txt, dic["YearsOfServiceForJubi"], 0);
            _gLib._SetSyncUDWin("BasedOn", this.wRetirementStudio.wBasedOn.cbo, dic["BasedOn"], 0);




            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ParticipantType", "Actives and deferreds");
        ///    dic.Add("SingleFormulaOrBenefit_cbo", "AccruedBenefit");
        ///    dic.Add("Function", "");
        ///    dic.Add("Validate", "");
        ///    dic.Add("VersorgungsausgleichAdjustment_cbo", "");
        ///    dic.Add("BenefitCommencementAge_V", "");
        ///    dic.Add("BenefitCommencementAge_C", "");
        ///    dic.Add("BenefitStopAge_V", "");
        ///    dic.Add("BenefitStopAge_C", "");
        ///    dic.Add("FirstStartAge_V", "");
        ///    dic.Add("FirstStartAge_C", "");
        ///    dic.Add("LastStartAge_V", "");
        ///    dic.Add("LastStartAge_C", "");
        ///    dic.Add("NumberOfPayments_V", "");
        ///    dic.Add("NumberOfPayments_C", "");
        ///    dic.Add("MaximumNumberOfPayments_V", "");
        ///    dic.Add("MaximumNumberOfPayments_C", "");
        ///    dic.Add("2DCaseFlow_V", "");
        ///    dic.Add("2DCaseFlow_C", "");
        ///    dic.Add("BenefitCommencementAge_cbo", "");
        ///    dic.Add("BenefitCommencementAge_txt", "");
        ///    dic.Add("BenefitStopAge_cbo", "");
        ///    dic.Add("BenefitStopAge_txt", "");
        ///    dic.Add("FirstStartAge_cbo", "");
        ///    dic.Add("FirstStartAge_txt", "");
        ///    dic.Add("LastStartAge_cbo", "");
        ///    dic.Add("LastStartAge_txt", "");
        ///    dic.Add("NumberOfPayments_cbo", "");
        ///    dic.Add("NumberOfPayments_txt", "");
        ///    dic.Add("MaximumNumberOfPayments_cbo", "");
        ///    dic.Add("MaximumNumberOfPayments_txt", "");
        ///    dic.Add("2DCaseFlow_cbo", "");
        ///    dic.Add("2DCaseFlow_txt", "");
        ///    dic.Add("Eligibility", "");
        ///    dic.Add("VestedRatio", "");
        ///    dic.Add("VestingDefinition", "");
        ///    dic.Add("CostOfLivingAdjustment", "BenCOLA");
        ///    dic.Add("EarlyRetirement", "");
        ///    dic.Add("LateRetirement", "");
        ///    dic.Add("Adjustment", "");
        ///    dic.Add("Conversion", "");
        ///    dic.Add("FormOfPayment", "Life");
        ///    dic.Add("BenefitElectionPercentage", "");
        ///    dic.Add("Decrement", "Retirement");
        ///    dic.Add("ExcludePercentMarried", "");
        ///    dic.Add("Other", "true");
        ///    pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDefinition_DE_Pension(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDefinition_DE_Pension";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int icbo = 0;
            int itxt = 0;

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ParticipantType", this.wRetirementStudio.wParticipantType.cbo, dic["ParticipantType"], 0);
                _gLib._SetSyncUDWin("SingleFormulaOrBenefit_cbo", this.wRetirementStudio.wSingleFormulaOrBenefit_cbo.cbo, dic["SingleFormulaOrBenefit_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Function", this.wRetirementStudio.wFunction.txt, dic["Function"], 0);
                _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btn, dic["Validate"], 0);
                _gLib._SetSyncUDWin("VersorgungsausgleichAdjustment_cbo", this.wRetirementStudio.wVersorgungsausgleich.cbo, dic["VersorgungsausgleichAdjustment_cbo"], 0);


                _gLib._SetSyncUDWin("BenefitCommencementAge_V", this.wRetirementStudio.wBenefitCommencementAge_V.btn, dic["BenefitCommencementAge_V"], 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_C", this.wRetirementStudio.wBenefitCommencementAge_C.btn, dic["BenefitCommencementAge_C"], 0);
                _gLib._SetSyncUDWin("BenefitStopAge_V", this.wRetirementStudio.wBenefitStopAge_V.btn, dic["BenefitStopAge_V"], 0);
                _gLib._SetSyncUDWin("BenefitStopAge_C", this.wRetirementStudio.wBenefitStopAge_C.btn, dic["BenefitStopAge_C"], 0);
                _gLib._SetSyncUDWin("FirstStartAge_V", this.wRetirementStudio.wFirstStartAge_V.btn, dic["FirstStartAge_V"], 0);
                _gLib._SetSyncUDWin("FirstStartAge_C", this.wRetirementStudio.wFirstStartAge_C.btn, dic["FirstStartAge_C"], 0);
                _gLib._SetSyncUDWin("LastStartAge_V", this.wRetirementStudio.wLastStartAge_V.btn, dic["LastStartAge_V"], 0);
                _gLib._SetSyncUDWin("LastStartAge_C", this.wRetirementStudio.wLastStartAge_C.btn, dic["LastStartAge_C"], 0);
                _gLib._SetSyncUDWin("NumberOfPayments_V", this.wRetirementStudio.wNumberOfPayments_V.btn, dic["NumberOfPayments_V"], 0);
                _gLib._SetSyncUDWin("NumberOfPayments_C", this.wRetirementStudio.wNumberOfPayments_C.btn, dic["NumberOfPayments_C"], 0);
                _gLib._SetSyncUDWin("MaximumNumberOfPayments_V", this.wRetirementStudio.wMaximumNumberOfPayments_V.btn, dic["MaximumNumberOfPayments_V"], 0);
                _gLib._SetSyncUDWin("MaximumNumberOfPayments_C", this.wRetirementStudio.wMaximumNumberOfPayments_C.btn, dic["MaximumNumberOfPayments_C"], 0);
                _gLib._SetSyncUDWin("2DCaseFlow_V", this.wRetirementStudio.w2DCaseFlow_V.btn, dic["2DCaseFlow_V"], 0);
                _gLib._SetSyncUDWin("2DCaseFlow_C", this.wRetirementStudio.w2DCaseFlow_C.btn, dic["2DCaseFlow_C"], 0);



                if (dic["BenefitCommencementAge_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("BenefitCommencementAge_cbo", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["BenefitCommencementAge_cbo"], 0);
                }
                if (dic["BenefitCommencementAge_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("BenefitCommencementAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0,false, 3,3);
                    _gLib._SetSyncUDWin_ByClipboard("BenefitCommencementAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["BenefitCommencementAge_txt"], 0);
                }


                if (dic["BenefitStopAge_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("BenefitStopAge_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["BenefitStopAge_cbo"], 0);
                }
                if (dic["BenefitStopAge_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("BenefitStopAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["BenefitStopAge_txt"], 0);
                }


                if (dic["FirstStartAge_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("FirstStartAge_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["FirstStartAge_cbo"], 0);
                }
                if (dic["FirstStartAge_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("FirstStartAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SetSyncUDWin_ByClipboard("FirstStartAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["FirstStartAge_txt"], 0);
                }


                if (dic["LastStartAge_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("LastStartAge_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["LastStartAge_cbo"], 0);
                }
                if (dic["LastStartAge_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("LastStartAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SetSyncUDWin_ByClipboard("LastStartAge_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["LastStartAge_txt"], 0); 
                }


                if (dic["NumberOfPayments_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("NumberOfPayments_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["NumberOfPayments_cbo"], 0);
                }
                if (dic["NumberOfPayments_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("NumberOfPayments_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SetSyncUDWin_ByClipboard("NumberOfPayments_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["NumberOfPayments_txt"], 0); 
                }


                if (dic["MaximumNumberOfPayments_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("MaximumNumberOfPayments_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["MaximumNumberOfPayments_cbo"], 0);
                }
                if (dic["MaximumNumberOfPayments_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("MaximumNumberOfPayments_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SetSyncUDWin_ByClipboard("MaximumNumberOfPayments_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["MaximumNumberOfPayments_txt"], 0); 
                }


                if (dic["2DCaseFlow_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("2DCaseFlow_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["2DCaseFlow_cbo"], 0);
                }
                if (dic["2DCaseFlow_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SendKeysUDWin("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "{Delete}{Delete}{Delete}{Delete}",0);
                    _gLib._SetSyncUDWin_ByClipboard("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["2DCaseFlow_txt"], 0);
                }



                _gLib._SetSyncUDWin("Eligibility", this.wRetirementStudio.wEligibility.cbo, dic["Eligibility"], 0);
                _gLib._SetSyncUDWin("VestedRatio", this.wRetirementStudio.wVestedRatio.cbo, dic["VestedRatio"], 0);
                _gLib._SetSyncUDWin("VestingDefinition", this.wRetirementStudio.wVestingDefinitionforWithdrawal.cbo, dic["VestingDefinition"], 0);
                _gLib._SetSyncUDWin("CostOfLivingAdjustment", this.wRetirementStudio.wCostOfLivingAdjustment.cbo, dic["CostOfLivingAdjustment"], 0);
                _gLib._SetSyncUDWin("EarlyRetirement", this.wRetirementStudio.wEarlyRetirement.cbo, dic["EarlyRetirement"], 0);
                _gLib._SetSyncUDWin("LateRetirement", this.wRetirementStudio.wLateRetirement.cbo, dic["LateRetirement"], 0);
                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustment.cbo, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("Conversion", this.wRetirementStudio.wConversion.cbo, dic["Conversion"], 0);
                _gLib._SetSyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cbo, dic["FormOfPayment"], 0);
                _gLib._SetSyncUDWin("BenefitElectionPercentage", this.wRetirementStudio.wBenefitElectionPercentage.cbo, dic["BenefitElectionPercentage"], 0);
                _gLib._SetSyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cbo, dic["Decrement"], 0);
                _gLib._SetSyncUDWin("ExcludePercentMarried", this.wRetirementStudio.wExcludePercentMarried.chk, dic["ExcludePercentMarried"], 0);
                _gLib._SetSyncUDWin("Other", this.wRetirementStudio.wOther.rd, dic["Other"], 0);

            }
 

            _gLib._SetSyncUDWin_ByClipboard("YearsOfServiceForJubi", this.wRetirementStudio.wYearsOfServiceForJubi.txt, dic["YearsOfServiceForJubi"], 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }







        /// <summary>
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("2DCaseFlow_V", "");
        ///    dic.Add("2DCaseFlow_C", "");
        ///    dic.Add("2DCaseFlow_cbo", "");
        ///    dic.Add("2DCaseFlow_txt", "");
        ///    pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Jubilee(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDefinition_DE_Jubilee(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDefinition_DE_Jubilee";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int icbo = 0;
            int itxt = 0;

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("2DCaseFlow_V", this.wRetirementStudio.w2DCaseFlow_V.btn, dic["2DCaseFlow_V"], 0);
                _gLib._SetSyncUDWin("2DCaseFlow_C", this.wRetirementStudio.w2DCaseFlow_C.btn, dic["2DCaseFlow_C"], 0);

                if (dic["2DCaseFlow_V"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_Pen_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("2DCaseFlow_V", this.wRetirementStudio.wCommon_Pen_cbo.cbo, dic["2DCaseFlow_cbo"], 0);
                }
                if (dic["2DCaseFlow_C"] != "")
                {
                    itxt = itxt + 1;
                    this.wRetirementStudio.wCommon_Pen_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "click", 0, false, 3, 3);
                    _gLib._SendKeysUDWin("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, "{Delete}{Delete}{Delete}{Delete}", 0);
                    _gLib._SetSyncUDWin_ByClipboard("2DCaseFlow_C", this.wRetirementStudio.wCommon_Pen_txt.Edit.txt, dic["2DCaseFlow_txt"], 0);
                }



                _gLib._SetSyncUDWin("Eligibility", this.wRetirementStudio.wEligibility.cbo, dic["Eligibility"], 0);
                _gLib._SetSyncUDWin("VestedRatio", this.wRetirementStudio.wVestedRatio.cbo, dic["VestedRatio"], 0);
                _gLib._SetSyncUDWin("VestingDefinition", this.wRetirementStudio.wVestingDefinitionforWithdrawal.cbo, dic["VestingDefinition"], 0);
                _gLib._SetSyncUDWin("CostOfLivingAdjustment", this.wRetirementStudio.wCostOfLivingAdjustment.cbo, dic["CostOfLivingAdjustment"], 0);
                _gLib._SetSyncUDWin("EarlyRetirement", this.wRetirementStudio.wEarlyRetirement.cbo, dic["EarlyRetirement"], 0);
                _gLib._SetSyncUDWin("LateRetirement", this.wRetirementStudio.wLateRetirement.cbo, dic["LateRetirement"], 0);
                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustment.cbo, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("Conversion", this.wRetirementStudio.wConversion.cbo, dic["Conversion"], 0);
                _gLib._SetSyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cbo, dic["FormOfPayment"], 0);
                _gLib._SetSyncUDWin("BenefitElectionPercentage", this.wRetirementStudio.wBenefitElectionPercentage.cbo, dic["BenefitElectionPercentage"], 0);
                _gLib._SetSyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cbo, dic["Decrement"], 0);
                _gLib._SetSyncUDWin("ExcludePercentMarried", this.wRetirementStudio.wExcludePercentMarried.chk, dic["ExcludePercentMarried"], 0);
                _gLib._SetSyncUDWin("Other", this.wRetirementStudio.wOther.rd, dic["Other"], 0);

            }


            _gLib._SetSyncUDWin_ByClipboard("YearsOfServiceForJubi", this.wRetirementStudio.wYearsOfServiceForJubi.txt, dic["YearsOfServiceForJubi"], 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
