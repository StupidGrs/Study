namespace RetirementStudio._UIMaps.TranchedBenefitClasses
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


    public partial class TranchedBenefit
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Active", "");
        ///    dic.Add("Deferred", "");
        ///    dic.Add("Pensioner", "");
        ///    dic.Add("BaseAmountRevaluing", "");
        ///    dic.Add("BaseAmountNonRevaluing", "");
        ///    dic.Add("RevalueNonRevaluing", "");
        ///    dic.Add("CommutationAmtByTranche", "");
        ///    pTranchedBenefit._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Active", this.wRetirementStudio.wActive.rd, dic["Active"], 0);
                _gLib._SetSyncUDWin("Deferred", this.wRetirementStudio.wDeferred.rd, dic["Deferred"], 0);
                _gLib._SetSyncUDWin("Pensioner", this.wRetirementStudio.wPensioner.rd, dic["Pensioner"], 0);
                _gLib._SetSyncUDWin("BaseAmountRevaluing", this.wRetirementStudio.wBaseAmountRevaluing.chk, dic["BaseAmountRevaluing"], 0);
                _gLib._SetSyncUDWin("BaseAmountNonRevaluing", this.wRetirementStudio.wBaseAmountNonRevaluing.chk, dic["BaseAmountNonRevaluing"], 0);
                _gLib._SetSyncUDWin("RevalueNonRevaluing", this.wRetirementStudio.wRevalueNonRevaluing.chk, dic["RevalueNonRevaluing"], 0);
                _gLib._SetSyncUDWin("CommutationAmtByTranche", this.wRetirementStudio.wCommutationAmtByTranche.chk, dic["CommutationAmtByTranche"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Active", this.wRetirementStudio.wActive.rd, dic["Active"], 0);
                _gLib._VerifySyncUDWin("Deferred", this.wRetirementStudio.wDeferred.rd, dic["Deferred"], 0);
                _gLib._VerifySyncUDWin("Pensioner", this.wRetirementStudio.wPensioner.rd, dic["Pensioner"], 0);
                _gLib._VerifySyncUDWin("BaseAmountRevaluing", this.wRetirementStudio.wBaseAmountRevaluing.chk, dic["BaseAmountRevaluing"], 0);
                _gLib._VerifySyncUDWin("BaseAmountNonRevaluing", this.wRetirementStudio.wBaseAmountNonRevaluing.chk, dic["BaseAmountNonRevaluing"], 0);
                _gLib._VerifySyncUDWin("RevalueNonRevaluing", this.wRetirementStudio.wRevalueNonRevaluing.chk, dic["RevalueNonRevaluing"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iCol", "");
        ///    dic.Add("iCol_Total", "");
        ///    dic.Add("BaseAmount", "");
        ///    dic.Add("DefineAccruedBenefitSeparately", "");
        ///    dic.Add("AccruedBaseAmount", "");
        ///    dic.Add("BenefitCommencementAge_current", "");
        ///    dic.Add("BenefitCommencementAge_txt", "");
        ///    dic.Add("BenefitCommencementAge_cbo", "");
        ///    dic.Add("BenefitStopAge_current", "");
        ///    dic.Add("BenefitStopAge_txt", "");
        ///    dic.Add("BenefitStopAge_cbo", "");
        ///    dic.Add("RevaluationInDeferment", "");
        ///    dic.Add("IncreasesInPayment", "");
        ///    dic.Add("EarlyRetirementFactors", "");
        ///    dic.Add("LateRetirementFactors", "");
        ///    dic.Add("GMPAdjustmentFactors", "");
        ///    dic.Add("CommutationFactors", "");
        ///    dic.Add("AdjustmentFactors", "");
        ///    dic.Add("SpousePercent_txt", "");
        ///    dic.Add("SpousePercent_cbo", "");
        ///    dic.Add("CommutationAmount", "");
        ///    pTranchedBenefit._TBL_Active(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Active(MyDictionary dic)
        {
            string sFunctionName = "_TBL_Active";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts: Set values in column # " + dic["iCol"]);

            if (dic["iCol_Total"] == null || dic["iCol_Total"] == "")
                _gLib._MsgBox("", "Please update iCol_Total value in iCol_Total field, then send testcase fiel to webber or lin");

            int iCol = Convert.ToInt32(dic["iCol"]);
            int iCol_Total = Convert.ToInt32(dic["iCol_Total"]);
            string sBackKeys = "";

            for (int i = 1; i < 50; i++)
                sBackKeys = sBackKeys + "{Tab}{Tab}{Tab}";


            if (dic["BaseAmount"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("BaseAmount", this.wRetirementStudio.wCommon_cbo.cbo, dic["BaseAmount"], 0);
            }

            if (dic["DefineAccruedBenefitSeparately"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < iCol_Total + iCol; i++)
                    sKeys = sKeys + "{Tab}";

                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);
                _gLib._SendKeysUDWin("checkbox", this.wRetirementStudio, "{Space}");

                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wTrancheBenefit_FPGrid.grid);

                if (!sAct.ToUpper().Contains(dic["DefineAccruedBenefitSeparately"].ToUpper()))
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio, "{Space}");

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wTrancheBenefit_FPGrid.grid);

                if (!sAct.ToUpper().Contains(dic["DefineAccruedBenefitSeparately"].ToUpper()))
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set  <" + dic["DefineAccruedBenefitSeparately"] + ">  to <DefineAccruedBenefitSeparately> at coloumn <" + dic["iCol"] + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Function <" + sFunctionName + "> fail to set  <" + dic["DefineAccruedBenefitSeparately"] + ">  to <DefineAccruedBenefitSeparately> at coloumn <" + dic["iCol"] + ">");
                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> Successfully  set  <" + dic["DefineAccruedBenefitSeparately"] + ">  to <DefineAccruedBenefitSeparately> at coloumn <" + dic["iCol"] + ">");

            }

            if (dic["AccruedBaseAmount"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 2) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("AccruedBaseAmount", this.wRetirementStudio.wCommon_cbo.cbo, dic["AccruedBaseAmount"], 0);
            }

            if (dic["BenefitCommencementAge_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 3) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitCommencementAge_cbo"], 0);
            }

            if (dic["BenefitCommencementAge_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 3) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitCommencementAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitCommencementAge_txt"], 0);
            }

            if (dic["BenefitStopAge_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 6) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);


                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitStopAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitStopAge_cbo"], 0);
            }

            if (dic["BenefitStopAge_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 6) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitStopAge_txt"], 0);
            }


            if (dic["RevaluationInDeferment"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 9) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("RevaluationInDeferment", this.wRetirementStudio.wCommon_cbo.cbo, dic["RevaluationInDeferment"], 0);
            }

            if (dic["IncreasesInPayment"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 10) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("IncreasesInPayment", this.wRetirementStudio.wCommon_cbo.cbo, dic["IncreasesInPayment"], 0);
            }
            if (dic["EarlyRetirementFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 11) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("EarlyRetirementFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["EarlyRetirementFactors"], 0);
            }

            if (dic["LateRetirementFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 12) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("LateRetirementFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["LateRetirementFactors"], 0);
            }
            if (dic["GMPAdjustmentFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 13) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("GMPAdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["GMPAdjustmentFactors"], 0);
            }

            if (dic["CommutationFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 14) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("CommutationFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["CommutationFactors"], 0);
            }

            if (dic["AdjustmentFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 15) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("AdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["AdjustmentFactors"], 0);
            }

            if (dic["SpousePercent_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 16) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("SpousePercent_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["SpousePercent_cbo"], 0);
            }

            if (dic["SpousePercent_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 16) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("P", this.wRetirementStudio.wCommon_P.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("SpousePercent_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["SpousePercent_txt"], 0);
            }

            if (dic["CommutationAmount"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 100);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 16) + 2 * iCol_Total * 3 + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("CommutationAmount", this.wRetirementStudio.wCommon_cbo.cbo, dic["CommutationAmount"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends: Set values in column # " + dic["iCol"]);
        }


        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iCol", "1");
        ///    dic.Add("iCol_Total", "3");
        ///    dic.Add("BaseAmount", "Benefit1DB_Pre97");
        ///    dic.Add("BenefitCommencementAge_current", "");
        ///    dic.Add("BenefitCommencementAge_txt", "");
        ///    dic.Add("BenefitCommencementAge_cbo", "");
        ///    dic.Add("BenefitStopAge_current", "");
        ///    dic.Add("BenefitStopAge_txt", "");
        ///    dic.Add("BenefitStopAge_cbo", "");
        ///    dic.Add("IncreasesInPayment", "");
        ///    dic.Add("GMPAdjustmentFactors", "");
        ///    dic.Add("AdjustmentFactors", "");
        ///    dic.Add("SpousePercent_txt", "");
        ///    dic.Add("SpousePercent_cbo", "");
        ///    pTranchedBenefit._TBL_Pensioner(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Pensioner(MyDictionary dic)
        {
            string sFunctionName = "_TBL_Pensioner";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts: Set values in column # " + dic["iCol"]);


            if (dic["iCol_Total"] == null || dic["iCol_Total"] == "")
                _gLib._MsgBox("", "Please update iCol_Total value in iCol_Total field, then send testcase fiel to webber or lin");

            int iCol = Convert.ToInt32(dic["iCol"]);
            int iCol_Total = Convert.ToInt32(dic["iCol_Total"]);

            _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 30);

            string sBackKeys = "";
            for (int i = 1; i < 50; i++)
                sBackKeys = sBackKeys + "{Tab}{Tab}{Tab}";

            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);




            if (dic["BaseAmount"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
 

                string sKeys = "";
                for (int i = 1; i < iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("BaseAmount", this.wRetirementStudio.wCommon_cbo.cbo, dic["BaseAmount"], 0);
            }
            if (dic["BenefitCommencementAge_cbo"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 90);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 90);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

            
                string sKeys = "";
                for (int i = 1; i < iCol_Total + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitCommencementAge_cbo"], 0);
            }
            if (dic["BenefitCommencementAge_txt"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 90);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 90);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

           
                string sKeys = "";
                for (int i = 1; i < iCol_Total + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitCommencementAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitCommencementAge_txt"], 0);
            }
            if (dic["BenefitStopAge_cbo"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 120);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 120);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);


                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 4) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitStopAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitStopAge_cbo"], 0);
                ////////////////_gLib._SendKeysUDWin("BenefitStopAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, "{Tab}", 0, ModifierKeys.None, false);
            }
            if (dic["BenefitStopAge_txt"] != "")
            {
            //    _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 120);
            //    _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 120);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

             
                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 4) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitStopAge_txt"], 0);
            }

            if (dic["IncreasesInPayment"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 150);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 150);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 7) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("IncreasesInPayment", this.wRetirementStudio.wCommon_cbo.cbo, dic["IncreasesInPayment"], 0);
            }

            if (dic["GMPAdjustmentFactors"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 170);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 170);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 8) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("GMPAdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["GMPAdjustmentFactors"], 0);
            }


            if (dic["AdjustmentFactors"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 190);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 190);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

              
                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 9) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("AdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["AdjustmentFactors"], 0);
            }


            if (dic["SpousePercent_cbo"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 210);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 210);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 10) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("SpousePercent_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["SpousePercent_cbo"], 0);
            }
            if (dic["SpousePercent_txt"] != "")
            {
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 210);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 210);
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                           
                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 10) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("P", this.wRetirementStudio.wCommon_P.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("SpousePercent_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["SpousePercent_txt"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends: Set values in column # " + dic["iCol"]);
        }


        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iCol", "");
        ///    dic.Add("iCol_Total", "5");
        ///    dic.Add("BaseAmountRevaluing", "");
        ///    dic.Add("BaseAmountNonRevaluing", "");
        ///    dic.Add("AccruedBaseAmount", "");
        ///    dic.Add("BenefitCommencementAge_current", "");
        ///    dic.Add("BenefitCommencementAge_txt", "");
        ///    dic.Add("BenefitCommencementAge_cbo", "");
        ///    dic.Add("BenefitStopAge_current", "");
        ///    dic.Add("BenefitStopAge_txt", "");
        ///    dic.Add("BenefitStopAge_cbo", "");
        ///    dic.Add("RevaluationInDeferment", "");
        ///    dic.Add("IncreasesInPayment", "");
        ///    dic.Add("EarlyRetirementFactors", "");
        ///    dic.Add("LateRetirementFactors", "");
        ///    dic.Add("GMPAdjustmentFactors", "");
        ///    dic.Add("CommutationFactors", "");
        ///    dic.Add("AdjustmentFactors", "");
        ///    dic.Add("SpousePercent_txt", "");
        ///    dic.Add("SpousePercent_cbo", "");
        ///    dic.Add("CommutationAmount", "");
        ///    pTranchedBenefit._TBL_Deferred(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Deferred(MyDictionary dic)
        {
            string sFunctionName = "_TBL_Deferred";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["iCol_Total"] == null || dic["iCol_Total"] == "")
                _gLib._MsgBox("", "Please update iCol_Total value in iCol_Total field, then send testcase fiel to webber or lin");


            int iCol = Convert.ToInt32(dic["iCol"]);
            int iCol_Total = Convert.ToInt32(dic["iCol_Total"]);


            string sBackKeys = "";
            for (int i = 1; i < 50; i++)
                sBackKeys = sBackKeys + "{Tab}{Tab}{Tab}";

            if (dic["BaseAmountRevaluing"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                string sKeys = "";
                for (int i = 1; i < iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys, 0);

                _gLib._SetSyncUDWin("BaseAmountRevaluing", this.wRetirementStudio.wCommon_cbo.cbo, dic["BaseAmountRevaluing"], 0);
            }


            if (dic["BaseAmountNonRevaluing"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 66);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 66);

                string sKeys = "";
                for (int i = 1; i < iCol_Total + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("BaseAmountNonRevaluing", this.wRetirementStudio.wCommon_cbo.cbo, dic["BaseAmountNonRevaluing"], 0);
            }


            if (dic["BenefitCommencementAge_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 88);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 88);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 2) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitCommencementAge_cbo"], 0);
            }


            if (dic["BenefitCommencementAge_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 88);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 88);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 2) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitCommencementAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitCommencementAge_txt"], 0);
            }


            if (dic["BenefitStopAge_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 110);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 110);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 5) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitStopAge_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitStopAge_cbo"], 0);
            }


            if (dic["BenefitStopAge_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 110);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 110);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 5) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommon_C.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["BenefitStopAge_txt"], 0);
            }


            if (dic["RevaluationInDeferment"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 140);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 140);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 8) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("RevaluationInDeferment", this.wRetirementStudio.wCommon_cbo.cbo, dic["RevaluationInDeferment"], 0);
            }


            if (dic["IncreasesInPayment"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 166);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 166);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 9) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("IncreasesInPayment", this.wRetirementStudio.wCommon_cbo.cbo, dic["IncreasesInPayment"], 0);
            }


            if (dic["EarlyRetirementFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 193);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 193);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 10) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("EarlyRetirementFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["EarlyRetirementFactors"], 0);
            }


            if (dic["LateRetirementFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 221);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 221);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 11) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("LateRetirementFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["LateRetirementFactors"], 0);
            }


            if (dic["GMPAdjustmentFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 248);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 248);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 12) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("GMPAdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["GMPAdjustmentFactors"], 0);
            }


            if (dic["CommutationFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 278);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 278);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 13) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("CommutationFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["CommutationFactors"], 0);
            }


            if (dic["AdjustmentFactors"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 303);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 303);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 14) + iCol; i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("AdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["AdjustmentFactors"], 0);
            }


            if (dic["SpousePercent_cbo"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 328);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 328);


                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 15) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("SpousePercent_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["SpousePercent_cbo"], 0);
            }


            if (dic["SpousePercent_txt"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 328);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 328);


                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 15) + (iCol * 3); i++)
                    sKeys = sKeys + "{Tab}";
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("P", this.wRetirementStudio.wCommon_P.btn, "Click", 0);
                _gLib._SetSyncUDWin_ByClipboard("SpousePercent_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["SpousePercent_txt"], 0);
            }

            if (dic["CommutationAmount"] != "")
            {
                _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 150, 30);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                //_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sFirstBackKeys, 0, ModifierKeys.Shift, false);

                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 160, 303);
                //_gLib._SetSyncUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, "Click", 0, false, 50, 303);

                string sKeys = "";
                for (int i = 1; i < (iCol_Total * 7) + iCol; i++)
                    sKeys = sKeys + "{Tab}";

                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wTrancheBenefit_FPGrid.grid, sKeys);

                _gLib._SetSyncUDWin("AdjustmentFactors", this.wRetirementStudio.wCommon_cbo.cbo, dic["CommutationAmount"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends: Set values in column # " + dic["iCol"]);
        }

    }



}
