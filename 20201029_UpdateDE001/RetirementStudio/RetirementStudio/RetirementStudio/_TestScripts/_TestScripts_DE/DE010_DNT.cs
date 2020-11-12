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



namespace RetirementStudio._TestScripts._TestScripts_DE
{
    /// <summary>
    /// Summary description for DE010_CN
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

        
        //////public string sOutputPension_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Conversion2010\";
        //////public string sOutputPension_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_Baseline\";
        //////public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_ConstantNumberOfPlanMembers\";
        //////public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_IndividualBeneficiaryMethod\";
        //////public string sOutputPension_Valuation2011_MultiplePasses_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_MultiplePasses\";
        //////public string sOutputPension_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_Baseline\";
        //////public string sOutputPension_Valuation2012_MethodScreenChange_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_MethodScreenChange\";
        //////public string sOutputPension_Valuation2012_SecondMethodScreenChance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_SecondMethodScreenChance\";
        //////public string sOutputPension_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_V67Enhancements\";
        //////public string sOutputJubilee_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Conversion2010\";
        //////public string sOutputJubilee_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2011_Baseline\";
        //////public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2011_ConstantNumberOfPlanMembers\";
        //////public string sOutputJubilee_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_Baseline\";
        //////public string sOutputJubilee_Valuation2012_TradeEAN_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_TradeEAN\";
        //////public string sOutputJubilee_Valuation2012_TradePUC_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_TradePUC\";
        //////public string sOutputJubilee_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_V67Enhancements\";
        //////public string sOutputJubilee_Valuation2012_V69Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_V69Enhancements\";
        //////public string sOutput_Data2013_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Data2013\";


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

                sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Conversion 2010\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_IndividualBeneficiaryMethod = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\IndividualBeneficiaryMethod\\" + sPostFix + "\\");
                sOutputPension_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\MultiplePasses\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_MethodScreenChange = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\MethodScreenChange\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_SecondMethodScreenChance = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\SecondMethodScreenChance\\" + sPostFix + "\\");
                sOutputPension_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");

                sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Jubilee Conversion 2010\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\Baseline\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\ConstantNumberOfPlanMembers\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradeEAN = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradeEAN\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_TradePUC = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\TradePUC\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V69Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V69Enhancements\\" + sPostFix + "\\");
            }
            ////////}
            ////////else
            ////////{
            ////////    // get the main reports directory
            ////////    string sDir = Directory.GetCurrentDirectory();
            ////////    for (int i = 0; i < 3; i++)
            ////////    {
            ////////        DirectoryInfo info = Directory.GetParent(sDir);
            ////////        sDir = info.FullName;
            ////////    }

            ////////    /// this is for VS2012 folder structure
            ////////    sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

            ////////    ////sDir = sDir + "\\_TestLog\\";

            ////////    string sMainDir = sDir + "DE008_" + _gLib._ReturnDateStampYYYYMMDD();

            ////////    _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

            ////////    _gLib._CreateDirectory(sMainDir);

            ////////    sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + sOutputPension_Conversion2010 + "\\Conversion 2010\\");
            ////////    sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\Baseline\\");
            ////////    sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\ConstantNumberOfPlanMembers\\");
            ////////    sOutputPension_Valuation2011_IndividualBeneficiaryMethod = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\IndividualBeneficiaryMethod\\");
            ////////    sOutputPension_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + "\\Valuation 2011\\MultiplePasses\\");
            ////////    sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Jubilee Conversion 2010\\");
            ////////    sOutputJubilee_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\Baseline\\");
            ////////    sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\ConstantNumberOfPlanMembers\\");
            ////////    sOutputJubilee_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2011\\MultiplePasses\\");

            ////////}

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2010 = @\"" + sOutputPension_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_Baseline = @\"" + sOutputPension_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputPension_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_IndividualBeneficiaryMethod = @\"" + sOutputPension_Valuation2011_IndividualBeneficiaryMethod + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_MultiplePasses = @\"" + sOutputPension_Valuation2011_MultiplePasses + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_Baseline = @\"" + sOutputPension_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_MethodScreenChange = @\"" + sOutputPension_Valuation2012_MethodScreenChange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_SecondMethodScreenChance = @\"" + sOutputPension_Valuation2012_SecondMethodScreenChance + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_V67Enhancements = @\"" + sOutputPension_Valuation2012_V67Enhancements + "\";" + Environment.NewLine + Environment.NewLine;


            sContent = sContent + "sOutputJubilee_Conversion2010 = @\"" + sOutputJubilee_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_Baseline = @\"" + sOutputJubilee_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_Baseline = @\"" + sOutputJubilee_Valuation2012_Baseline + "\";" + Environment.NewLine;
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
        public void test_DE010_DNT()
        {




            #region MultiThreads


            Thread thrd_Pension_Conversion2010 = new Thread(() => new DE010_DNT().t_CompateRpt_Pension_Conversion2010(sOutputPension_Conversion2010));
            Thread thrd_Pension_Valuation2011_MultiplePasses = new Thread(() => new DE010_DNT().t_CompateRpt_Pension_Valuation2011_MultiplePasses(sOutputPension_Valuation2011_MultiplePasses) );
            Thread thrd_Pension_Valuation2012_SecondMethodScreenChance = new Thread(() => new DE010_DNT().t_CompateRpt_Pension_Valuation2012_SecondMethodScreenChance(sOutputPension_Valuation2012_SecondMethodScreenChance));
            Thread thrd_Jubilee_Conversion2010 = new Thread(() => new DE010_DNT().t_CompateRpt_Jubilee_Conversion2010(sOutputJubilee_Conversion2010)) ;
            Thread thrd_Jubilee_Valuation2011_ConstantNumberOfPlanMembers = new Thread(() => new DE010_DNT().t_CompateRpt_Jubilee_Valuation2011_ConstantNumberOfPlanMembers(sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers));

            #endregion




            this.GenerateReportOuputDir();


            #region Pension - Conversion2010

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion 2010");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Conversion 2010");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("Pay", "Pay1CurrentYear");
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


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "ALL" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", true, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", true, true, dic);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true, dic);
            }


            thrd_Pension_Conversion2010.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Pension RF - Valuation2011 - Multiple Passes

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("Pay", "Pay1CurrentYear");
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


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "RollForward", false, true);
            }


            thrd_Pension_Valuation2011_MultiplePasses.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region Jubilee - Conversion2010


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee Conversion 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Jubilee Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
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


            pMain._SelectTab("Jubilee Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubilee Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, true, 0, new string[1] { "ALL" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Conversion2010, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", false, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", false, true, dic);
            }

            thrd_Jubilee_Conversion2010.Start();


            pMain._SelectTab("Jubilee Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Jubilee RF - Valuation2011 - Constant Number of Plan Members


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("ApplyOverrides", "True");
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



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("Pay", "Pay1CurrentYear");
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
            dic.Add("SelectVOs_VO1", "JUBI01");
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


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, false, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Population Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Population Projection", "RollForward", false, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Summary", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Group", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Year", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", false, false);

            }


            thrd_Jubilee_Valuation2011_ConstantNumberOfPlanMembers.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region  Pension RF - Valuation 2012 - SecondMethodScreenChance

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


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
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
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

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
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
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
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
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "210");
            dic.Add("iPosY", "160");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub3_DECO01", "Sub3_PENS01", "Sub1_SF01", "Sub2_SF01" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", true, true);

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", true, true, dic);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Test Cases", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Valuation2012_SecondMethodScreenChance, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true, dic);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", false, true);

            }


            thrd_Pension_Valuation2012_SecondMethodScreenChance.Start();

            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "IFRS", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Direct Promise", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Support Fund", "RollForward", false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region  Jubilee RF - Valuation 2012 - Trade PUC


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            //////////// run baseline node
            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
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
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "140");
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
            dic.Add("IAgreeToUnlock", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CascadingUnlock(dic);


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
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
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
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
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
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "300");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "IFRS", "RollForward", true, false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Jubilee", "RollForward", true, false, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "All"});
            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputJubilee_Valuation2012_TradePUC, sOutputJubilee_Valuation2012_TradePUC_Prod);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Valuation2012_TradePUC");
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0,true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0,true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_All.xlsx", 4, 0, 0, 0, true);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            _gLib._MsgBox("", "Finished");

          
        }

          
        void t_CompateRpt_Pension_Conversion2010( string sOutputPension_Conversion2010)
          {  
                if (Config.bCompareReports)
                {
                    CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputPension_Conversion2010_Prod, sOutputPension_Conversion2010);
                    _compareReportsLib._Report(_PassFailStep.Description, "", "sConversion2010");
                    _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                    Config.bThreadFinsihed = true;
                }
          }

        void t_CompateRpt_Pension_Valuation2011_MultiplePasses( string sOutputPension_Valuation2011_MultiplePasses)
           {
               if (Config.bCompareReports)
                {
                    CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputPension_Valuation2011_MultiplePasses_Prod, sOutputPension_Valuation2011_MultiplePasses);
                    _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Valuation2011_MultiplePasses");
                    _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_ALL.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_ALL.xlsx", 4, 0, 0, 0);
                    Config.bThreadFinsihed = true;
                }
           }

        void t_CompateRpt_Pension_Valuation2012_SecondMethodScreenChance( string sOutputPension_Valuation2012_SecondMethodScreenChance) 
            {
                if (Config.bCompareReports)
                {
                    CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputPension_Valuation2012_SecondMethodScreenChance, sOutputPension_Valuation2012_SecondMethodScreenChance_Prod);
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

                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_Sub1_SF01.xlsx", 4, 0, 0, 0);

                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_Sub1_CashBal01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_Sub1_DECO01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_Sub1_PENS01.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_Sub1_PENS02.xlsx", 4, 0, 0, 0);
                    _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_Sub1_SF01.xlsx", 4, 0, 0, 0);
                    Config.bThreadFinsihed = true;
                }                            
            }
        
        void t_CompateRpt_Jubilee_Conversion2010( string sOutputJubilee_Conversion2010)
         {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputJubilee_Conversion2010_Prod, sOutputJubilee_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sJubilee_Conversion2010");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
}
          
        void t_CompateRpt_Jubilee_Valuation2011_ConstantNumberOfPlanMembers( string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers)
          {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT", sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers_Prod, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
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
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear_ALL.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
          }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
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

