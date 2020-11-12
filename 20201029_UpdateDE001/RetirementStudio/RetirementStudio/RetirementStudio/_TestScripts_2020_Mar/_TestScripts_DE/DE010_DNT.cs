using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

using RetirementStudio._Config;
using RetirementStudio._Libraries;
using RetirementStudio._ThridParty;
using RetirementStudio._UIMaps;
using RetirementStudio._UIMaps.FarPointClasses;
using RetirementStudio._UIMaps.MainClasses;
using RetirementStudio._UIMaps.DataClasses;
using RetirementStudio._UIMaps.ParticipantDataSetClasses;
using RetirementStudio._UIMaps.AssumptionsClasses;
using RetirementStudio._UIMaps.InterestRateClasses;
using RetirementStudio._UIMaps.PayIncreaseClasses;
using RetirementStudio._UIMaps.OtherDemographicAssumptionsClasses;
using RetirementStudio._UIMaps.MortalityDecrementClasses;
using RetirementStudio._UIMaps.ServiceClasses;
using RetirementStudio._UIMaps.EligibilitiesClasses;
using RetirementStudio._UIMaps.PayoutProjectionClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.Item415LimitsClasses;
using RetirementStudio._UIMaps.PlanDefinitionClasses;
using RetirementStudio._UIMaps.MethodsClasses;
using RetirementStudio._UIMaps.TestCaseLibraryClasses;
using RetirementStudio._UIMaps.OutputManagerClasses;
using RetirementStudio._UIMaps.AssetsClasses;
using RetirementStudio._UIMaps.FundingInformationClasses;
using RetirementStudio._UIMaps.FundingInformation_PYR_PreliminaryResultsClasses;
using RetirementStudio._UIMaps.FundingInformation_FTAPsClasses;
using RetirementStudio._UIMaps.FundingInformation_ShortfallClasses;
using RetirementStudio._UIMaps.FundingInformation_ContributionSummaryClasses;
using RetirementStudio._UIMaps.OtherEconomicAssumptionClasses;
using System.Threading;
using RetirementStudio._UIMaps.Item2DCashFlowOptionsClasses;
using RetirementStudio._UIMaps.PayoutProjectionByParticipantClasses;




namespace RetirementStudio._TestScripts_2020_Mar_DE
{
    /// <summary>
    /// Summary description for DE010_DNT
    /// </summary>
    [CodedUITest]
    public class DE010_DNT
    {
        public DE010_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 010 Existing DNT Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory

        //public string sOutputPension_Valuation2011_Baseline = "";
        //public string sOutputPension_Valuation2012_Baseline = "";
        public string sOutputPension_Valuation2012_MethodScreenChange = "";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance = "";

        public string sOutputJubilee_Valuation2012_TradeEAN = "";
        public string sOutputJubilee_Valuation2012_TradePUC = "";
      

        //public string sOutputPension_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Valuation2011_Baseline\";
        //public string sOutputPension_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Valuation2012_Baseline\";
        //public string sOutputPension_Valuation2012_MethodScreenChange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Valuation2012_MethodScreenChange\";
        //public string sOutputPension_Valuation2012_SecondMethodScreenChance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Valuation2012_SecondMethodScreenChance\";
  
        //public string sOutputJubilee_Valuation2012_TradeEAN_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Jubilee_Valuation2012_TradeEAN\";
        //public string sOutputJubilee_Valuation2012_TradePUC_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\7.5_20191118_B\Jubilee_Valuation2012_TradePUC\";

        public string sOutputPension_Valuation2012_MethodScreenChange_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\MethodScreenChange\20200305_QA1\";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\SecondMethodScreenChance\20200305_QA1\";

        public string sOutputJubilee_Valuation2012_TradeEAN_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\TradeEAN\20200305_QA1\";
        public string sOutputJubilee_Valuation2012_TradePUC_Prod = @"R:\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\TradePUC\20200305_QA1\";
  
       

        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();

            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in R: drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);
                //sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\Baseline\\" + sPostFix + "\\");
                //sOutputPension_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_MethodScreenChange = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\MethodScreenChange\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_SecondMethodScreenChance = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\SecondMethodScreenChance\\" + sPostFix + "\\");
              
                sOutputJubilee_Valuation2012_TradeEAN = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradeEAN\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradePUC = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradePUC\\" + sPostFix + "\\");
          }
           

            string sContent = "";
            //sContent = sContent + "sOutputPension_Valuation2011_Baseline = @\"" + sOutputPension_Valuation2011_Baseline + "\";" + Environment.NewLine;
            //sContent = sContent + "sOutputPension_Valuation2012_Baseline = @\"" + sOutputPension_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_MethodScreenChange = @\"" + sOutputPension_Valuation2012_MethodScreenChange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_SecondMethodScreenChance = @\"" + sOutputPension_Valuation2012_SecondMethodScreenChance + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradeEAN = @\"" + sOutputJubilee_Valuation2012_TradeEAN + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradePUC = @\"" + sOutputJubilee_Valuation2012_TradePUC + "\";" + Environment.NewLine;


            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public MyDictionary dic = new MyDictionary();
        public FarPoint _fp = new FarPoint();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public Main pMain = new Main();
        public OutputManager pOutputManager = new OutputManager();


        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_DE010_DNT()
        {

            #region MultiThreads

            //Thread thrd_Pension_Valuation2011_Baseline = new Thread(() => new DE010_DNT().t_CompareRpt_Pension_Valuation2012_Baseline(sOutputPension_Valuation2012_Baseline));
            //Thread thrd_Pension_Valuation2012_Baseline = new Thread(() => new DE010_DNT().t_CompareRpt_Pension_Valuation2012_Baseline(sOutputPension_Valuation2012_Baseline));
            Thread thrd_Pension_Valuation2012_MethodScreenChange = new Thread(() => new DE010_DNT().t_CompareRpt_Pension_Valuation2012_MethodScreenChange(sOutputPension_Valuation2012_MethodScreenChange));
            Thread thrd_Pension_Valuation2012_SecondMethodScreenChance = new Thread(() => new DE010_DNT().t_CompareRpt_Pension_Valuation2012_SecondMethodScreenChance(sOutputPension_Valuation2012_SecondMethodScreenChance));
            Thread thrd_Jubilee_Valuation2012_TradeEAN = new Thread(() => new DE010_DNT().t_CompareRpt_Jubilee_Valuation2012_TradeEAN(sOutputJubilee_Valuation2012_TradeEAN));
            Thread thrd_Jubilee_Valuation2012_TradePUC = new Thread(() => new DE010_DNT().t_CompareRpt_Jubilee_Valuation2012_TradePUC(sOutputJubilee_Valuation2012_TradePUC));

            #endregion

            string sPosX_Valuation2012_MethodScreenChange = "95";           ////// no.1 node of 3 in row 3
            string sPosY_Valuation2012_MethodScreenChange = "150";          ////// no.1 node of 3 in row 3
            string sPosX_Valuation2012_SecondMethodScreenChance = "245";    ////// no.2 node of 3 in row 3
            string sPosY_Valuation2012_SecondMethodScreenChance = "150";    ////// no.2 node of 3 in row 3


            string sPosX_sOutputJubilee_Valuation2012_TradeEAN = "130";     ////// no.1 node of 4 in row 3
            string sPosY_sOutputJubilee_Valuation2012_TradeEAN = "150";     ////// no.1 node of 4 in row 3
            string sPosX_sOutputJubilee_Valuation2012_TradePUC = "310";     ////// no.2 node of 4 in row 3
            string sPosY_sOutputJubilee_Valuation2012_TradePUC = "150";     ////// no.2 node of 4 in row 3

        

            //_gLib._MsgBoxYesNo("Please provide the position of X / Y of each node", "Continue?");


            this.GenerateReportOuputDir();

            #region Pension RF - Valuation 2012 - MethodScreenChange

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "false");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            dic.Add("FVPopulationProjectionRunOption_Pop", "true");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Valuation2012_MethodScreenChange, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "All" });
            ////////////////pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Parameter Print", "RollForward", true, true);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_Pension_Valuation2012_MethodScreenChange.Start();

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Pension RF - Valuation 2012 - SecondMethodScreenChance

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "true");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            dic.Add("FVPopulationProjectionRunOption_Pop", "true");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "true");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputPension_Valuation2012_SecondMethodScreenChance, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Test Cases", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });

            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Print", "RollForward", true, true);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_Pension_Valuation2012_SecondMethodScreenChance.Start();

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Jubilee RF - Valuation 2012 - Trade EAN

         
            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiSalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            //////////////////////dic.Clear();
            //////////////////////dic.Add("PopVerify", "Pop");
            //////////////////////dic.Add("IAgreeToUnlock", "True");
            //////////////////////dic.Add("OK", "Click");
            //////////////////////pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_JubileeSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreaksBasedOnData", "Original");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Liabilities Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Individual Population Projection", "RollForward", true, false);



            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_Jubilee_Valuation2012_TradeEAN.Start();


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region  Jubilee RF - Valuation 2012 - Trade PUC

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiSalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_JubileeSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreaksBasedOnData", "Original");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("RunValuation", "click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liabilities Detailed Results", "RollForward", true, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Population Projection", "RollForward", true, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Individual Population Projection", "RollForward", true, false);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            thrd_Jubilee_Valuation2012_TradePUC.Start();

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            _gLib._MsgBox("", "please manually compare the FV related reports, and this client is finished!");

        }




        #region Compare report function

        void t_CompareRpt_Pension_Valuation2012_MethodScreenChange(string sOutputPension_Valuation2012_MethodScreenChange)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputPension_Valuation2012_MethodScreenChange_Prod, sOutputPension_Valuation2012_MethodScreenChange);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Valuation2012_MethodScreenChange");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_ALL.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Pension_Valuation2012_SecondMethodScreenChance(string sOutputPension_Valuation2012_SecondMethodScreenChance)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputPension_Valuation2012_SecondMethodScreenChance_Prod, sOutputPension_Valuation2012_SecondMethodScreenChance);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Valuation2012_SecondMethodScreenChance");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub3_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub3_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub1_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub2_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub2_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub2_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub2_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub3_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_Sub3_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDef.xlsx", 11, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_SF01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_CashBal01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_DECO01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_PENS01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_SF01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_DECO01.xlsx", 4, 0, 0, 0);
                ////////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_CashBal01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_SF01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub3_DECO01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub3_PENS01.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

    
        void t_CompareRpt_Jubilee_Valuation2012_TradeEAN(string sOutputJubilee_Valuation2012_TradeEAN)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputJubilee_Valuation2012_TradeEAN_Prod, sOutputJubilee_Valuation2012_TradeEAN);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Valuation2012_TradeEAN");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_F.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_M.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_F.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_M.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_F.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_M.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub1_M.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub2_M.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub3_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_Sub3_M.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Jubilee_Valuation2012_TradePUC(string sOutputJubilee_Valuation2012_TradePUC)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputJubilee_Valuation2012_TradePUC_Prod, sOutputJubilee_Valuation2012_TradePUC);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Valuation2012_TradePUC");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                ////////////////////_compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

    
        #endregion


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
