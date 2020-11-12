namespace RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses
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
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    public partial class EmployeeContributionsFormula
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("FormulaCalculated", "");
        ///    dic.Add("PredefinedAmount_rd", "");
        ///    dic.Add("StartingBalanceAsOfOneYear", "");
        ///    dic.Add("StartingBalance_V", "Click");
        ///    dic.Add("StartingBalance_C", "");
        ///    dic.Add("StartingBalance_cbo", "PreCWI");
        ///    dic.Add("StartingBalance_txt", "");
        ///    dic.Add("PreDefinedAmount", "");
        ///    dic.Add("StopContributionAt_V", "");
        ///    dic.Add("StopContributionAt_C", "");
        ///    dic.Add("StopContributionAt_cbo", "");
        ///    dic.Add("StopContributionAt_txt", "");
        ///    dic.Add("OffsetToAnnual_V", "");
        ///    dic.Add("OffsetToAnnual_C", "");
        ///    dic.Add("OffsetToAnnual_cbo", "");
        ///    dic.Add("OffsetToAnnual_txt", "");
        ///    dic.Add("LimitToAnnual_V", "");
        ///    dic.Add("LimitToAnnual_C", "");
        ///    dic.Add("LimitToAnnual_cbo", "");
        ///    dic.Add("LimitToAnnual_txt", "");
        ///    dic.Add("ContributionsMade", "");
        ///    dic.Add("InterestCredited", "");
        ///    dic.Add("RateForYear_V", "Click");
        ///    dic.Add("RateForYear_P", "");
        ///    dic.Add("RateForYear_T", "");
        ///    dic.Add("RateForYear_cbo", "");
        ///    dic.Add("RateForYear_txt", "");
        ///    dic.Add("SameRatesApplies", "");
        ///    dic.Add("Rate_V", "Click");
        ///    dic.Add("Rate_P", "");
        ///    dic.Add("Rate_T", "");
        ///    dic.Add("Rate_cbo", "Accum");
        ///    dic.Add("Rate_txt", "");
        ///    dic.Add("ProjectedPay", "ProjPay");
        ///    dic.Add("Service", "");
        ///    dic.Add("RatesTiersBasedOn", "");
        ///    dic.Add("IntegrationType", "");
        ///    pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_EmployeeContributionsFormula(MyDictionary dic)
        {

           
            string sFunctionName = "_PopVerify_EmployeeContributionsFormula";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int icbo = 2;
            int iStartingBalance_cbo = 0;
            int iStopContributioniAt_cbo = 0;
            int iOffsetToAnnual_cbo = 0;
            int iLimitToAnnual_cbo = 0;
            int iRateForYear_cbo = 0;
            int iRate_cbo = 0;

            if (dic["StopContributionAt_V"] != "")
                iStopContributioniAt_cbo = 1;
            if (dic["OffsetToAnnual_V"] != "")
                iOffsetToAnnual_cbo = 1;
            if (dic["LimitToAnnual_V"] != "")
                iLimitToAnnual_cbo = 1;
            if (dic["StartingBalance_V"] != "")
                iStartingBalance_cbo = 1;
            if (dic["RateForYear_V"] != "")
                iRateForYear_cbo = 1;
            if (dic["Rate_V"] != "")
                iRate_cbo = 1;

            int itxt = 1;
            int iStartingBalance_txt = 0;
            int iStopContributioniAt_txt = 0;
            int iOffsetToAnnual_txt = 0;
            int iLimitToAnnual_txt = 0;

            if (dic["StopContributionAt_C"] != "")
                iStopContributioniAt_txt = 1;
            if (dic["OffsetToAnnual_C"] != "")
                iOffsetToAnnual_txt = 1;
            if (dic["LimitToAnnual_C"] != "")
                iLimitToAnnual_txt = 1;
            if (dic["StartingBalance_C"] != "")
                iStartingBalance_txt = 1;

            int itxt_P = 1;
            int iRateForYear_txt_P = 0;
            int iRate_txt_P = 0;

            if (dic["RateForYear_P"] != "")
                iRateForYear_txt_P = 1;
            if (dic["Rate_P"] != "")
                iRate_txt_P = 1;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("FormulaCalculated", this.wRetirementStudio.wFormulaCalculated.rd, dic["FormulaCalculated"], 0);
                _gLib._SetSyncUDWin("PredefinedAmount_rd", this.wRetirementStudio.wPredefinedAmount_rd.rd, dic["PredefinedAmount_rd"], 0);
                _gLib._SetSyncUDWin("StartingBalanceAsOfOneYear", this.wRetirementStudio.wStartingBalanceAsOfOneYear.chk, dic["StartingBalanceAsOfOneYear"], 0);
                _gLib._SetSyncUDWin("StartingBalance_V", this.wRetirementStudio.wStartingBalance_V.btn, dic["StartingBalance_V"], 0);
                _gLib._SetSyncUDWin("StartingBalance_C", this.wRetirementStudio.wStartingBalance_C.btn, dic["StartingBalance_C"], 0);
                
                _gLib._SetSyncUDWin("PreDefinedAmount", this.wRetirementStudio.wPreDefinedAmount.cbo, dic["PreDefinedAmount"], 0);
                _gLib._SetSyncUDWin("StopContributionAt_V", this.wRetirementStudio.wStopContributionAt_V.btn, dic["StopContributionAt_V"], 0);
                _gLib._SetSyncUDWin("StopContributionAt_C", this.wRetirementStudio.wStopContributionAt_C.btn, dic["StopContributionAt_C"], 0);

                _gLib._SetSyncUDWin("OffsetToAnnual_V", this.wRetirementStudio.wOffsetToAnnual_V.btn, dic["OffsetToAnnual_V"], 0);
                _gLib._SetSyncUDWin("OffsetToAnnual_C", this.wRetirementStudio.wOffsetToAnnual_C.btn, dic["OffsetToAnnual_C"], 0);

                _gLib._SetSyncUDWin("LimitToAnnual_V", this.wRetirementStudio.wLimitToAnnual_V.btn, dic["LimitToAnnual_V"], 0);
                _gLib._SetSyncUDWin("LimitToAnnual_C", this.wRetirementStudio.wLimitToAnnual_C.btn, dic["LimitToAnnual_C"], 0);

                if (dic["StartingBalance_cbo"] != "")
                {
                    icbo = 2 + iStopContributioniAt_cbo + iOffsetToAnnual_cbo + iLimitToAnnual_cbo;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StartingBalance_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["StartingBalance_cbo"], 0);
                }
                if (dic["StartingBalance_txt"] != "")
                {
                    itxt = 1 + iStopContributioniAt_txt + iOffsetToAnnual_txt + iLimitToAnnual_txt;
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StartingBalance_txt", this.wRetirementStudio.wCommon_txt.txt, dic["StartingBalance_txt"], true, 0);
                }
                if (dic["StopContributionAt_cbo"] != "")
                {
                    icbo = 2;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StopContributionAt_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["StopContributionAt_cbo"], 0);
                }
                if (dic["StopContributionAt_txt"] != "")
                {
                    itxt = 1;
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StopContributionAt_txt", this.wRetirementStudio.wCommon_txt.txt, dic["StopContributionAt_txt"], true, 0);
                }
                if (dic["OffsetToAnnual_cbo"] != "")
                {
                    icbo = 2 + iStopContributioniAt_cbo;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("OffsetToAnnual_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["OffsetToAnnual_cbo"], 0);
                }
                if (dic["OffsetToAnnual_txt"] != "")
                {
                    itxt = 1 + iStopContributioniAt_txt;
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("OffsetToAnnual_txt", this.wRetirementStudio.wCommon_txt.txt, dic["OffsetToAnnual_txt"], true, 0);
                }
                if (dic["LimitToAnnual_cbo"] != "")
                {
                    icbo = 2 + iStopContributioniAt_cbo + iOffsetToAnnual_cbo;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("LimitToAnnual_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["LimitToAnnual_cbo"], 0);
                }
                if (dic["LimitToAnnual_txt"] != "")
                {
                    itxt = 1 + iStopContributioniAt_txt + iOffsetToAnnual_txt;
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("LimitToAnnual_txt", this.wRetirementStudio.wCommon_txt.txt, dic["LimitToAnnual_txt"], true, 0);
                }


                _gLib._SetSyncUDWin("InterestCredited", this.wRetirementStudio.wInterestCredited.cbo, dic["InterestCredited"], 0);
                _gLib._SetSyncUDWin("ContributionsMade", this.wRetirementStudio.wContributionsMade.cbo, dic["ContributionsMade"], 0);


                //////_gLib._SetSyncUDWin("RateForYear_V", this.wRetirementStudio.wRateForYear_V.btn, dic["RateForYear_V"], 0); // it is disabled all the time
                if (_gLib._Enabled("", this.wRetirementStudio.wRateForYear_P.btn, 1, false))
                    _gLib._SetSyncUDWin("RateForYear_P", this.wRetirementStudio.wRateForYear_P.btn, dic["RateForYear_P"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wRateForYear_T.btn, 1, false))
                    _gLib._SetSyncUDWin("RateForYear_T", this.wRetirementStudio.wRateForYear_T.btn, dic["RateForYear_T"], 0);

                _gLib._SetSyncUDWin("SameRatesApplies", this.wRetirementStudio.wSameRatesApplies.chk, dic["SameRatesApplies"], 0);
                _gLib._SetSyncUDWin("Rate_V", this.wRetirementStudio.wRate_V.btn, dic["Rate_V"], 0);
                _gLib._SetSyncUDWin("Rate_P", this.wRetirementStudio.wRate_P.btn, dic["Rate_P"], 0);
                _gLib._SetSyncUDWin("Rate_T", this.wRetirementStudio.wRate_T.btn, dic["Rate_T"], 0);
                if (dic["Rate_cbo"] != "")
                {
                    icbo = 2 + iStopContributioniAt_cbo + iOffsetToAnnual_cbo + iLimitToAnnual_cbo + iStartingBalance_cbo + iRateForYear_cbo;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["Rate_cbo"], 0);
                }
                if (dic["Rate_txt"] != "")
                {
                    itxt_P = 1 + iRateForYear_txt_P;
                    this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt_P.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("Rate_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Rate_txt"], 0);
                }


                _gLib._SetSyncUDWin("ProjectedPay", this.wRetirementStudio.wProjectedPay.cbo, dic["ProjectedPay"], 0);
                _gLib._SetSyncUDWin("Service", this.wRetirementStudio.wService.cbo, dic["Service"], 0);
                _gLib._SetSyncUDWin("RatesTiersBasedOn", this.wRetirementStudio.wRatesTiersBasedOn.cbo, dic["RatesTiersBasedOn"], 0);
                _gLib._SetSyncUDWin("IntegrationType", this.wRetirementStudio.wIntegrationType.cbo, dic["IntegrationType"], 0);

     
            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Mar-14
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("FormulaCalculated", "");
        ///    dic.Add("PredefinedAmount_rd", "");
        ///    dic.Add("StartingBalanceAsOfOneYear", "");
        ///    dic.Add("StartingBalance_V", "Click");
        ///    dic.Add("StartingBalance_C", "");
        ///    dic.Add("StartingBalance_cbo", "PreCWI");
        ///    dic.Add("StartingBalance_txt", "");
        ///    dic.Add("PreDefinedAmount", "");
        ///    dic.Add("StopContributionAt_V", "");
        ///    dic.Add("StopContributionAt_C", "");
        ///    dic.Add("StopContributionAt_cbo", "");
        ///    dic.Add("StopContributionAt_txt", "");
        ///    dic.Add("OffsetToAnnual_V", "");
        ///    dic.Add("OffsetToAnnual_C", "");
        ///    dic.Add("OffsetToAnnual_cbo", "");
        ///    dic.Add("OffsetToAnnual_txt", "");
        ///    dic.Add("LimitToAnnual_V", "");
        ///    dic.Add("LimitToAnnual_C", "");
        ///    dic.Add("LimitToAnnual_cbo", "");
        ///    dic.Add("LimitToAnnual_txt", "");
        ///    dic.Add("ApplyNumberOfContributions", "");
        ///    dic.Add("InterestCredited", "");
        ///    dic.Add("InterestCredited_txt", "");
        ///    dic.Add("ContributionsMade", "");
        ///    dic.Add("ContributionsMade_txt", "");
        ///    dic.Add("SameRatesApplies", "");
        ///    dic.Add("Rate_V", "Click");
        ///    dic.Add("Rate_P", "");
        ///    dic.Add("Rate_T", "");
        ///    dic.Add("Rate_cbo", "Accum");
        ///    dic.Add("Rate_txt", "");  
        ///    pEmployeeContributionsFormula._Standard_PreDefinedAmount(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Standard_PreDefinedAmount(MyDictionary dic)
        {


            string sFunctionName = "_Standard_PreDefinedAmount";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

          
            if (dic["PopVerify"] == "Pop")
            {
                int icbo = 1;
                int itxt = 1;

                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("FormulaCalculated", this.wRetirementStudio.wFormulaCalculated.rd, dic["FormulaCalculated"], 0);
                _gLib._SetSyncUDWin("PredefinedAmount_rd", this.wRetirementStudio.wPredefinedAmount_rd.rd, dic["PredefinedAmount_rd"], 0);
                _gLib._SetSyncUDWin("StartingBalanceAsOfOneYear", this.wRetirementStudio.wStartingBalanceAsOfOneYear.chk, dic["StartingBalanceAsOfOneYear"], 0);


                _gLib._SetSyncUDWin("StartingBalance_V", this.wRetirementStudio.wLimitToAnnual_V.btn, dic["StartingBalance_V"], 0);
                _gLib._SetSyncUDWin("StartingBalance_C", this.wRetirementStudio.wLimitToAnnual_C.btn, dic["StartingBalance_C"], 0);

                _gLib._SetSyncUDWin("PreDefinedAmount", this.wRetirementStudio.wPreDefinedAmount.cbo, dic["PreDefinedAmount"], 0);
              
                _gLib._SetSyncUDWin("StopContributionAt_V", this.wRetirementStudio.wStopContributionAt_V_BR.btn, dic["StopContributionAt_V"], 0);
                _gLib._SetSyncUDWin("StopContributionAt_C", this.wRetirementStudio.wStopContributionAt_C_BR.btn, dic["StopContributionAt_C"], 0);

                _gLib._SetSyncUDWin("OffsetToAnnual_V", this.wRetirementStudio.wStopContributionAt_V.btn, dic["OffsetToAnnual_V"], 0);
                _gLib._SetSyncUDWin("OffsetToAnnual_C", this.wRetirementStudio.wStopContributionAt_C.btn, dic["OffsetToAnnual_C"], 0);

                _gLib._SetSyncUDWin("LimitToAnnual_V", this.wRetirementStudio.wOffsetToAnnual_V.btn, dic["LimitToAnnual_V"], 0);
                _gLib._SetSyncUDWin("LimitToAnnual_C", this.wRetirementStudio.wOffsetToAnnual_C.btn, dic["LimitToAnnual_C"], 0);
                                            

                if (dic["StopContributionAt_cbo"] != "")
                {                   
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StopContributionAt_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["StopContributionAt_cbo"], 0);
                    icbo++;
                }
                if (dic["StopContributionAt_txt"] != "")
                {
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StopContributionAt_txt", this.wRetirementStudio.wCommon_txt.txt, dic["StopContributionAt_txt"], true, 0);
                    itxt++;
                }


                if (dic["OffsetToAnnual_cbo"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("OffsetToAnnual_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["OffsetToAnnual_cbo"], 0);
                    icbo++;
                }
                if (dic["OffsetToAnnual_txt"] != "")
                {
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("OffsetToAnnual_txt", this.wRetirementStudio.wCommon_txt.txt, dic["OffsetToAnnual_txt"], true, 0);
                    itxt++;
                }


                if (dic["LimitToAnnual_cbo"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("LimitToAnnual_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["LimitToAnnual_cbo"], 0);
                    icbo++;
                }
                if (dic["LimitToAnnual_txt"] != "")
                {
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("LimitToAnnual_txt", this.wRetirementStudio.wCommon_txt.txt, dic["LimitToAnnual_txt"], true, 0);
                    itxt++;
                }

                _gLib._SetSyncUDWin("ApplyNumberOfContributions", this.wRetirementStudio.wApplyNumberOfContributions.chk, dic["ApplyNumberOfContributions"], 0);


                if (dic["StartingBalance_cbo"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StartingBalance_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["StartingBalance_cbo"], 0);
                    icbo++;
                }
                if (dic["StartingBalance_txt"] != "")
                {
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StartingBalance_txt", this.wRetirementStudio.wCommon_txt.txt, dic["StartingBalance_txt"], true, 0);
                    itxt++;
                }


                _gLib._SetSyncUDWin("InterestCredited", this.wRetirementStudio.wInterestCredited.cbo, dic["InterestCredited"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestCredited_txt", this.wRetirementStudio.wInterestCredited_txt.txt, dic["InterestCredited_txt"], 0);
                _gLib._SetSyncUDWin("ContributionsMade", this.wRetirementStudio.wContributionsMade.cbo, dic["ContributionsMade"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ContributionsMade_txt", this.wRetirementStudio.wContributionsMade_txt.txt, dic["ContributionsMade_txt"], 0);


                ////////////////if (_gLib._Enabled("", this.wRetirementStudio.wRateForYear_P.btn, 1, false))
                ////////////////    _gLib._SetSyncUDWin("RateForYear_P", this.wRetirementStudio.wRateForYear_P.btn, dic["RateForYear_P"], 0);
                ////////////////if (_gLib._Enabled("", this.wRetirementStudio.wRateForYear_T.btn, 1, false))
                ////////////////    _gLib._SetSyncUDWin("RateForYear_T", this.wRetirementStudio.wRateForYear_T.btn, dic["RateForYear_T"], 0);

                
                _gLib._SetSyncUDWin("SameRatesApplies", this.wRetirementStudio.wSameRatesApplies.chk, dic["SameRatesApplies"], 0);
             
                _gLib._SetSyncUDWin("Rate_V", this.wRetirementStudio.wRate_V_BR.btn, dic["Rate_V"], 0);
                _gLib._SetSyncUDWin("Rate_P", this.wRetirementStudio.wRate_P.btn, dic["Rate_P"], 0);
                _gLib._SetSyncUDWin("Rate_T", this.wRetirementStudio.wRate_T_BR.btn, dic["Rate_T"], 0);
             
                if (dic["Rate_cbo"] != "")
                {
                    icbo = icbo + 1;
                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["Rate_cbo"], 0);
                }

                _gLib._SetSyncUDWin_ByClipboard("Rate_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Rate_txt"], 0);


            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
