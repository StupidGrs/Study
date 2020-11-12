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
using RetirementStudio._UIMaps;
using RetirementStudio._UIMaps.FarPointClasses;
using RetirementStudio._UIMaps.MainClasses;
using RetirementStudio._UIMaps.OutputManagerClasses;
using System.Threading;


namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _DE010_DNT
    {
        public _DE010_DNT()
        {
            Config.eEnv = _TestingEnv.QA2;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 010 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = false;
            Config.bCompareReports = false;
        }

        #region Report Output Directory



        public string sOutputPension_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Conversion 2010\20171114_QA1\";
        public string sOutputPension_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2011\Baseline\20171114_QA1\";
        public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2011\ConstantNumberOfPlanMembers\20171114_QA1\";
        public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2011\IndividualBeneficiaryMethod\20171114_QA1\";
        public string sOutputPension_Valuation2011_MultiplePasses_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2011\MultiplePasses\20171114_QA1\";
        public string sOutputPension_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\Baseline\20171114_QA1\";
        public string sOutputPension_Valuation2012_MethodScreenChange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\MethodScreenChange\20171114_QA1\";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\SecondMethodScreenChance\20171114_QA1\";
        public string sOutputPension_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Valuation 2012\V67Enhancements\20171114_QA1\";

        public string sOutputJubilee_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Conversion 2010\20171114_QA1\";
        public string sOutputJubilee_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2011\Baseline\20171114_QA1\";
        public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2011\ConstantNumberOfPlanMembers\20171114_QA1\";
        public string sOutputJubilee_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\Baseline\20171114_QA1\";
        public string sOutputJubilee_Valuation2012_TradeEAN_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\TradeEAN\20171114_QA1\";
        public string sOutputJubilee_Valuation2012_TradePUC_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\TradePUC\20171114_QA1\";
        public string sOutputJubilee_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\V67Enhancements\20171114_QA1\";

        

        public string sOutputPension_Conversion2010 = "";
        public string sOutputPension_Valuation2011_Baseline = "";
        public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = "";
        public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod = "";
        public string sOutputPension_Valuation2011_MultiplePasses = "";
        public string sOutputPension_Valuation2012_Baseline = "";
        public string sOutputPension_Valuation2012_MethodScreenChange = "";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance = "";
        public string sOutputPension_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Conversion2010 = "";
        public string sOutputJubilee_Valuation2011_Baseline = "";
        public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = "";
        public string sOutputJubilee_Valuation2012_Baseline = "";
        public string sOutputJubilee_Valuation2012_TradeEAN = "";
        public string sOutputJubilee_Valuation2012_TradePUC = "";
        public string sOutputJubilee_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Valuation2012_V69Enhancements = "";


        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();

            if (sCurrentUser.ToString() == "Others_PDF_EXCEL")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in R: drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                //////sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Conversion 2010\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\Baseline\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2011_IndividualBeneficiaryMethod = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\IndividualBeneficiaryMethod\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\MultiplePasses\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_MethodScreenChange = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\MethodScreenChange\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_SecondMethodScreenChance = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\SecondMethodScreenChance\\" + sPostFix + "\\");
                //////sOutputPension_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");

                //////sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Jubilee Conversion 2010\\" + sPostFix + "\\");
                //////sOutputJubilee_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\Baseline\\" + sPostFix + "\\");
                //////sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                //////sOutputJubilee_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradeEAN = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradeEAN\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradePUC = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradePUC\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V69Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V69Enhancements\\" + sPostFix + "\\");
            }
           

            string sContent = "";
            //////sContent = sContent + "sOutputPension_Conversion2010 = @\"" + sOutputPension_Conversion2010 + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2011_Baseline = @\"" + sOutputPension_Valuation2011_Baseline + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputPension_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2011_IndividualBeneficiaryMethod = @\"" + sOutputPension_Valuation2011_IndividualBeneficiaryMethod + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2011_MultiplePasses = @\"" + sOutputPension_Valuation2011_MultiplePasses + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2012_Baseline = @\"" + sOutputPension_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_MethodScreenChange = @\"" + sOutputPension_Valuation2012_MethodScreenChange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_SecondMethodScreenChance = @\"" + sOutputPension_Valuation2012_SecondMethodScreenChance + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputPension_Valuation2012_V67Enhancements = @\"" + sOutputPension_Valuation2012_V67Enhancements + "\";" + Environment.NewLine + Environment.NewLine;


            //////sContent = sContent + "sOutputJubilee_Conversion2010 = @\"" + sOutputJubilee_Conversion2010 + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputJubilee_Valuation2011_Baseline = @\"" + sOutputJubilee_Valuation2011_Baseline + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            //////sContent = sContent + "sOutputJubilee_Valuation2012_Baseline = @\"" + sOutputJubilee_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradeEAN = @\"" + sOutputJubilee_Valuation2012_TradeEAN + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradePUC = @\"" + sOutputJubilee_Valuation2012_TradePUC + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V67Enhancements = @\"" + sOutputJubilee_Valuation2012_V67Enhancements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V69Enhancements = @\"" + sOutputJubilee_Valuation2012_V69Enhancements + "\";" + Environment.NewLine;


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
        public void _test_DE010_DNT()
        {




            string sPosX_Valuation2012_MethodScreenChange = "95";           ////// no.1 node of 3 in row 3
            string sPosY_Valuation2012_MethodScreenChange = "150";          ////// no.1 node of 3 in row 3
            string sPosX_Valuation2012_SecondMethodScreenChance = "245";    ////// no.2 node of 3 in row 3
            string sPosY_Valuation2012_SecondMethodScreenChance = "150";    ////// no.2 node of 3 in row 3


            string sPosX_sOutputJubilee_Valuation2012_TradeEAN = "130";     ////// no.1 node of 4 in row 3
            string sPosY_sOutputJubilee_Valuation2012_TradeEAN = "150";     ////// no.1 node of 4 in row 3
            string sPosX_sOutputJubilee_Valuation2012_TradePUC = "310";     ////// no.2 node of 4 in row 3
            string sPosY_sOutputJubilee_Valuation2012_TradePUC = "150";     ////// no.2 node of 4 in row 3



            _gLib._MsgBoxYesNo("Please provide the position of X / Y of each node", "Continue?");


            _gLib._MsgBoxYesNo("Manual", "Please open Pension Valuation 2012");


            #region sOutputPension_Valuation2012_MethodScreenChange



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

            ////////////////////dic.Clear();
            ////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////dic.Add("IAgreeToUnlock", "True");
            ////////////////////dic.Add("OK", "Click");
            ////////////////////pMain._PopVerify_CascadingUnlock(dic);


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



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



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


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
            dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Individual Population Projection", "RollForward", true, true);

            //////////////////////////_gLib._MsgBoxYesNo("sOutputPension_Valuation2012_MethodScreenChange", "Finished");


            #endregion


            #region sOutputPension_Valuation2012_SecondMethodScreenChance


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

            ////////////////////dic.Clear();
            ////////////////////dic.Add("PopVerify", "Pop");
            ////////////////////dic.Add("IAgreeToUnlock", "True");
            ////////////////////dic.Add("OK", "Click");
            ////////////////////pMain._PopVerify_CascadingUnlock(dic);


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


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



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



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



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


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iPosX", sPosX_Valuation2012_SecondMethodScreenChance);
            dic.Add("iPosY", sPosY_Valuation2012_SecondMethodScreenChance);
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);




            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Individual Population Projection", "RollForward", true, true);

            ////////////////_gLib._MsgBoxYesNo("sOutputPension_Valuation2012_SecondMethodScreenChance", "Finished");

            #endregion


            _gLib._MsgBoxYesNo("Manual", "Please open Jubilee Valuation 2012");

            #region sOutputJubilee_Valuation2012_TradeEAN

            ////////////////////// complete with errors - Val & FV

            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PayoutProjection", "True");
            //dic.Add("ApplyWithdrawalAdjustment", "");
            //dic.Add("IncludeIOE", "");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "True");
            //dic.Add("SaveResultsforAuditReport", "");
            //dic.Add("ApplyOverrides", "");
            //dic.Add("RunLocally", "");
            //dic.Add("Pay", "JubiSalaryCurrentYear");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("BreakByFundingVehicle", "");
            //dic.Add("UseReportBreaks", "True");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Tax", "True");
            //dic.Add("Trade", "True");
            //dic.Add("InternationalAccountingABO", "True");
            //dic.Add("InternationalAccountingPBO", "True");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "");
            //dic.Add("SelectVOs_VO2", "");
            //dic.Add("SelectVOs_VO3", "");
            //dic.Add("SelectVOs_VO4", "");
            //dic.Add("SelectVOs_VO5", "");
            //dic.Add("SelectVOs_VO6", "");
            //dic.Add("RunValuation", "Click");
            //pMain._PopVerify_RunOptions(dic);

            //////////////////////dic.Clear();
            //////////////////////dic.Add("PopVerify", "Pop");
            //////////////////////dic.Add("IAgreeToUnlock", "True");
            //////////////////////dic.Add("OK", "Click");
            //////////////////////pMain._PopVerify_CascadingUnlock(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);



            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Future Valuation Population Projection");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("IAgreeToUnlock", "True");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_CascadingUnlock(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Future Valuation Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PayoutProjection", "");
            //dic.Add("ApplyWithdrawalAdjustment", "");
            //dic.Add("IncludeIOE", "True");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "");
            //dic.Add("SaveResultsforAuditReport", "");
            //dic.Add("ApplyOverrides", "");
            //dic.Add("RunLocally", "");
            //dic.Add("Pay", "PP_JubileeSalary");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("BreaksBasedOnData", "Original");
            //dic.Add("UseReportBreaks", "True");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Tax", "True");
            //dic.Add("Trade", "True");
            //dic.Add("InternationalAccountingABO", "True");
            //dic.Add("InternationalAccountingPBO", "True");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "");
            //dic.Add("SelectVOs_VO2", "");
            //dic.Add("SelectVOs_VO3", "");
            //dic.Add("SelectVOs_VO4", "");
            //dic.Add("SelectVOs_VO5", "");
            //dic.Add("SelectVOs_VO6", "");
            //dic.Add("RunValuation", "click");
            //pMain._PopVerify_RunOptions(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true, "FV Liab");


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradeEAN);
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);





            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Liabilities Detailed Results", "RollForward", true, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Population Projection", "RollForward", true, false);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            //pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Individual Population Projection", "RollForward", true, false);

            ////////////////////////_gLib._MsgBoxYesNo("sOutputJubilee_Valuation2012_TradeEAN", "Finished");

            #endregion

            

            #region sOutputJubilee_Valuation2012_TradePUC    

            ////////////////////// complete with errors - Val & FV

            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PayoutProjection", "True");
            //dic.Add("ApplyWithdrawalAdjustment", "");
            //dic.Add("IncludeIOE", "");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "True");
            //dic.Add("SaveResultsforAuditReport", "");
            //dic.Add("ApplyOverrides", "");
            //dic.Add("RunLocally", "");
            //dic.Add("Pay", "JubiSalaryCurrentYear");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("BreakByFundingVehicle", "");
            //dic.Add("UseReportBreaks", "True");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Tax", "True");
            //dic.Add("Trade", "True");
            //dic.Add("InternationalAccountingABO", "True");
            //dic.Add("InternationalAccountingPBO", "True");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "");
            //dic.Add("SelectVOs_VO2", "");
            //dic.Add("SelectVOs_VO3", "");
            //dic.Add("SelectVOs_VO4", "");
            //dic.Add("SelectVOs_VO5", "");
            //dic.Add("SelectVOs_VO6", "");
            //dic.Add("RunValuation", "Click");
            //pMain._PopVerify_RunOptions(dic);


            //////////////////////dic.Clear();
            //////////////////////dic.Add("PopVerify", "Pop");
            //////////////////////dic.Add("IAgreeToUnlock", "True");
            //////////////////////dic.Add("OK", "Click");
            //////////////////////pMain._PopVerify_CascadingUnlock(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);


            //pMain._EnterpriseRun("Group Job Completed With Errors", true);




            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Future Valuation Population Projection");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("IAgreeToUnlock", "True");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_CascadingUnlock(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");





            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Future Valuation Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PayoutProjection", "");
            //dic.Add("ApplyWithdrawalAdjustment", "");
            //dic.Add("IncludeIOE", "True");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "");
            //dic.Add("SaveResultsforAuditReport", "");
            //dic.Add("ApplyOverrides", "");
            //dic.Add("RunLocally", "");
            //dic.Add("Pay", "PP_JubileeSalary");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("BreaksBasedOnData", "Original");
            //dic.Add("UseReportBreaks", "True");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Tax", "True");
            //dic.Add("Trade", "True");
            //dic.Add("InternationalAccountingABO", "True");
            //dic.Add("InternationalAccountingPBO", "True");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "");
            //dic.Add("SelectVOs_VO2", "");
            //dic.Add("SelectVOs_VO3", "");
            //dic.Add("SelectVOs_VO4", "");
            //dic.Add("SelectVOs_VO5", "");
            //dic.Add("SelectVOs_VO6", "");
            //dic.Add("RunValuation", "click");
            //pMain._PopVerify_RunOptions(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true, "FV Liab");




            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "");
            //dic.Add("iSelectColNum", "");
            //dic.Add("iPosX", sPosX_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("iPosY", sPosY_sOutputJubilee_Valuation2012_TradePUC);
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liabilities Detailed Results", "RollForward", true, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Population Projection", "RollForward", true, false);
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "All" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "All" });
            //pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "All" });
            //pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Individual Population Projection", "RollForward", true, false);

            //_gLib._MsgBoxYesNo("sOutputJubilee_Valuation2012_TradePUC", "Finished");

            #endregion

            

            _gLib._MsgBoxYesNo("", "Finished");



        
        }

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
    }
}
