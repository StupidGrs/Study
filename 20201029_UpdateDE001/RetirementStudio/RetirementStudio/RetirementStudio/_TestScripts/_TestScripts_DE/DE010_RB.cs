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


namespace RetirementStudio._TestScripts._TestScripts_DE
{
    /// <summary>
    /// Summary description for DE010_RB
    /// </summary>
    [CodedUITest]
    public class DE010_RB
    {
        public DE010_RB()
        {
            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010";
            Config.sPlanName = "Alle - QA DE Benchmark 010 Plan";
            ////Config.sClientName = "QA DE Benchmark 010 E";
            ////Config.sPlanName = "Alle - QA DE Benchmark 010 E Plan";
            Config.sProductionVerison = "6.9.1";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;
        }


        #region Report Output Directory

        /// Pension
        public string sOutputPension_Conversion2010 = "";

        public string sOutputPension_Valuation2011_Baseline = "";
        public string sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = "";
        public string sOutputPension_Valuation2011_IndividualBeneficiaryMethod = "";
        public string sOutputPension_Valuation2011_MultiplePasses = "";

        public string sOutputPension_Valuation2012_Baseline = "";
        public string sOutputPension_Valuation2012_MethodScreenChange = "";
        public string sOutputPension_Valuation2012_SecondMethodScreenChance = "";
        public string sOutputPension_Valuation2012_V67Enhancements = "";



        ///  Jubilee
        public string sOutputJubilee_Conversion2010 = "";

        public string sOutputJubilee_Valuation2011_Baseline = "";
        public string sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = "";

        public string sOutputJubilee_Valuation2012_Baseline = "";
        public string sOutputJubilee_Valuation2012_TradeEAN = "";
        public string sOutputJubilee_Valuation2012_TradePUC = "";
        public string sOutputJubilee_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Valuation2012_V69Enhancements = "";

        public string sOutput_Data2013 = "";

        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_B";

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputPension_Conversion2010 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Conversion2010\\");
                sOutputPension_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2011_Baseline\\");
                sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2011_ConstantNumberOfPlanMembers\\");
                sOutputPension_Valuation2011_IndividualBeneficiaryMethod = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2011_IndividualBeneficiaryMethod\\");
                sOutputPension_Valuation2011_MultiplePasses = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2011_MultiplePasses\\");
                sOutputPension_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2012_Baseline\\");
                sOutputPension_Valuation2012_MethodScreenChange = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2012_MethodScreenChange\\");
                sOutputPension_Valuation2012_SecondMethodScreenChance = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2012_SecondMethodScreenChance\\");
                sOutputPension_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Valuation2012_V67Enhancements\\");

                sOutputJubilee_Conversion2010 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Conversion2010\\");
                sOutputJubilee_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2011_Baseline\\");
                sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2011_ConstantNumberOfPlanMembers\\");
                sOutputJubilee_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2012_Baseline\\");
                sOutputJubilee_Valuation2012_TradeEAN = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2012_TradeEAN\\");
                sOutputJubilee_Valuation2012_TradePUC = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2012_TradePUC\\");
                sOutputJubilee_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2012_V67Enhancements\\");
                sOutputJubilee_Valuation2012_V69Enhancements = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Jubilee_Valuation2012_V69Enhancements\\");
                sOutput_Data2013 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\Data2013\\");

            }


            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2010 = @\"" + sOutputPension_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_Baseline = @\"" + sOutputPension_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputPension_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_IndividualBeneficiaryMethod = @\"" + sOutputPension_Valuation2011_IndividualBeneficiaryMethod + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2011_MultiplePasses = @\"" + sOutputPension_Valuation2011_MultiplePasses + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_Baseline = @\"" + sOutputPension_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_MethodScreenChange = @\"" + sOutputPension_Valuation2012_MethodScreenChange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_SecondMethodScreenChance = @\"" + sOutputPension_Valuation2012_SecondMethodScreenChance + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Valuation2012_V67Enhancements = @\"" + sOutputPension_Valuation2012_V67Enhancements + "\";" + Environment.NewLine;

            sContent = sContent + "sOutputJubilee_Conversion2010 = @\"" + sOutputJubilee_Conversion2010 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_Baseline = @\"" + sOutputJubilee_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = @\"" + sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_Baseline = @\"" + sOutputJubilee_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradeEAN = @\"" + sOutputJubilee_Valuation2012_TradeEAN + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_TradePUC = @\"" + sOutputJubilee_Valuation2012_TradePUC + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V67Enhancements = @\"" + sOutputJubilee_Valuation2012_V67Enhancements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V69Enhancements = @\"" + sOutputJubilee_Valuation2012_V69Enhancements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutput_Data2013 = @\"" + sOutput_Data2013 + "\";" + Environment.NewLine;


            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public MyDictionary dic = new MyDictionary();
        public FarPoint _fp = new FarPoint();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public Main pMain = new Main();
        public Data pData = new Data();
        public ParticipantDataSet pParticipantDataSet = new ParticipantDataSet();
        public Assumptions pAssumptions = new Assumptions();
        public InterestRate pInterestRate = new InterestRate();
        public PayIncrease pPayIncrease = new PayIncrease();
        public OtherDemographicAssumptions pOtherDemographicAssumptions = new OtherDemographicAssumptions();
        public MortalityDecrement pMortalityDecrement = new MortalityDecrement();
        public Service pService = new Service();
        public Eligibilities pEligibilities = new Eligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public Vesting pVesting = new Vesting();
        public ActuarialEquivalence pActuarialEquivalence = new ActuarialEquivalence();
        public ConversionFactors pConversionFactors = new ConversionFactors();
        public FormOfPayment pFormOfPayment = new FormOfPayment();
        public Item415Limits p415Limits = new Item415Limits();
        public PlanDefinition pPlanDefinition = new PlanDefinition();
        public Methods pMethods = new Methods();
        public TestCaseLibrary pTestCaseLibrary = new TestCaseLibrary();
        public OutputManager pOutputManager = new OutputManager();
        public Assets pAssets = new Assets();
        public FundingInformation pFundingInformation = new FundingInformation();
        public FundingInformation_PYR_PreliminaryResults pFundingInformation_PYR_PreliminaryResults = new FundingInformation_PYR_PreliminaryResults();
        public FundingInformation_FTAPs pFundingInformation_FTAPs = new FundingInformation_FTAPs();
        public FundingInformation_Shortfall pFundingInformation_Shortfall = new FundingInformation_Shortfall();
        public FundingInformation_ContributionSummary pFundingInformation_ContributionSummary = new FundingInformation_ContributionSummary();
        public OtherEconomicAssumption pOtherEconomicAssumption = new OtherEconomicAssumption();

        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_DE010_RB()
        {


            ////////sOutputPension_Conversion2010 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Conversion2010\";
            ////////sOutputPension_Valuation2011_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_Baseline\";
            ////////sOutputPension_Valuation2011_ConstantNumberOfPlanMembers = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_ConstantNumberOfPlanMembers\";
            ////////sOutputPension_Valuation2011_IndividualBeneficiaryMethod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_IndividualBeneficiaryMethod\";
            ////////sOutputPension_Valuation2011_MultiplePasses = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2011_MultiplePasses\";
            ////////sOutputPension_Valuation2012_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_Baseline\";
            ////////sOutputPension_Valuation2012_MethodScreenChange = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_MethodScreenChange\";
            ////////sOutputPension_Valuation2012_SecondMethodScreenChance = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_SecondMethodScreenChance\";
            ////////sOutputPension_Valuation2012_V67Enhancements = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Valuation2012_V67Enhancements\";
            ////////sOutputJubilee_Conversion2010 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Conversion2010\";
            ////////sOutputJubilee_Valuation2011_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2011_Baseline\";
            ////////sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2011_ConstantNumberOfPlanMembers\";
            ////////sOutputJubilee_Valuation2011_MultiplePasses = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2011_MultiplePasses\";
            ////////sOutputJubilee_Valuation2012_Baseline = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_Baseline\";
            ////////sOutputJubilee_Valuation2012_TradeEAN = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_TradeEAN\";
            ////////sOutputJubilee_Valuation2012_TradePUC = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_TradePUC\";
            ////////sOutputJubilee_Valuation2012_V67Enhancements = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_V67Enhancements\";
            ////////sOutputJubilee_Valuation2012_V69Enhancements = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Jubilee_Valuation2012_V69Enhancements\";
            ////////sOutput_Data2013 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Production\6.9.1_20161013_B\Data2013\";



            this.GenerateReportOuputDir();


            #region Pension - Conversion2010

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
            dic.Add("SelectVOs_AllVOs", "True");
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
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2010, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
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
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2010, "Payout Projection", "Conversion", false, true, dic);
            }


            pOutputManager._ExportReport_Others(sOutputPension_Conversion2010, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2010, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "ALL" });


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region Pension RF - Valuation2011 - Baseline


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
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
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



            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[3] { "DECO01", "PENS01", "PENS02" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[1] { "ALL" });
                ////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Parameter Print", "RollForward", true, true);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[3] { "DECO01", "PENS01", "PENS02" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
                ////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "ALL" });
                ////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_Baseline, "RollForward", false, true);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_Baseline, "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "ALL" });



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Pension RF - Valuation2011 - IndividualBeneficiaryMethod


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Payout Projection", "RollForward", true, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Liabilities Detailed Results", "RollForward", true, true);
                //////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "ALL" });
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Others(sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Payout Projection", "RollForward", false, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                ////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "ALL" });
                ////////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "RollForward", false, true);
            }


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_IndividualBeneficiaryMethod, "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Pension RF - Valuation2011 - Constant Number of Plan Members

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("SelectVOs_AllVOs", "True");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("SelectVOs_AllVOs", "True");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                /////////////////// confirmed from shane, webber never need this
                //////////////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", true, true);
                //////////////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, true);
                //////////////////dic.Clear();
                //////////////////dic.Add("Group_ReportBreak", "True");
                //////////////////pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, true, dic);
                //////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
                //////////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline", "RollForward", true, true);
                //////////////////pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results", "RollForward", true, true);
                ////////////////////////////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
                //////////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", true, true);
                //////////////////pOutputManager._ExportReport_Others(sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "ALL" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                /////////////////// confirmed from shane, webber never need thispOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                //////////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", false, true);
                //////////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", false, true);
                //////////////dic.Clear();
                //////////////dic.Add("Group_ReportBreak", "True");
                //////////////pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", false, true, dic);
                //////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
                //////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline", "RollForward", false, true);
                //////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                //////////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Test Cases", "RollForward", true, true);
                //////////////pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results", "RollForward", false, true);
                //////////////pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                //////////////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
                //////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", false, true);
                //////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "ALL" });
                ////////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", false, true);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Pension RF - Valuation2011 - Multiple Passes

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "true");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "");
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

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Population Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "ALL" });
                ////////////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "RollForward", false, true);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2011_MultiplePasses, "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);

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
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee Conversion 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


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

            pMain._SelectTab("Jubilee Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Jubilee Conversion 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Valuation Summary", "Conversion", true, true, 0, new string[1] { "ALL" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Conversion2010, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", true, true, dic);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputJubilee_Conversion2010, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true);
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
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Conversion2010, "Member Statistics", "Conversion", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Conversion2010, "Payout Projection", "Conversion", false, true, dic);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Jubilee Conversion 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Jubilee RF - Valuation2011 - Baseline


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
            dic.Add("ServiceToOpen", "Valuation 2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");


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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[1] { "JUBI01" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[1] { "ALL" });
                ////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "ALL" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "JUBI01" });
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Payout Projection", "RollForward", false, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Payout Projection", "RollForward", false, true, dic);
                //////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Population Projection", "RollForward", false, false);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Liabilities by Group", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Liabilities by Year", "RollForward", false, false, 0, new string[1] { "ALL" });
                ////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "RollForward", false, false);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_Baseline, "RollForward", true, false);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Jubilee RF - Valuation2011 - Constant Number of Plan Members


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

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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
            dic.Add("IncludeIOE", "");
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
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, true);
                ////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", true, false, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Population Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Parameter Print", "RollForward", true, false);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
                //////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
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
                ////////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", false, false);

            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "RollForward", true, false);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Group", "RollForward", true, false, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2011_ConstantNumberOfPlanMembers, "Future Valuation Liabilities by Year", "RollForward", true, false, 0, new string[1] { "ALL" });


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Pension RF - Valuation 2012 - Baseline


            //pMain._SelectTab("Home");

            //dic.Clear();
            //dic.Add("Country", Config.eCountry.ToString());
            //dic.Add("Level_1", Config.sClientName);
            //dic.Add("Level_2", Config.sPlanName);
            //dic.Add("Level_3", "PensionValuations");
            //pMain._HomeTreeViewSelect(0, dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("AddServiceInstance", "");
            //dic.Add("ServiceToOpen", "Valuation 2012");
            //pMain._PopVerify_Home_RightPane(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);


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
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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
            dic.Add("SelectVOs_AllVOs", "True");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub3_DECO01", "Sub3_PENS01", "Sub1_SF01", "Sub2_SF01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[5] { "CashBal01", "DECO01", "PENS01", "PENS02", "SF01" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                ////////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub3_DECO01", "Sub3_PENS01", "Sub1_SF01", "Sub2_SF01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[5] { "CashBal01", "DECO01", "PENS01", "PENS02", "SF01" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub3_DECO01", "Sub3_PENS01", "Sub1_SF01", "Sub2_SF01" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                ////////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                //////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_Baseline, "RollForward", false, true);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub3_DECO01", "Sub3_PENS01", "Sub1_SF01", "Sub2_SF01" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others(sOutputPension_Valuation2012_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Future Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_Baseline, "RollForward", true, true);


            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "IFRS", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Direct Promise", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_Baseline, "Support Fund", "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Pension RF - Valuation 2012 - MethodScreenChange


            pMain._SelectTab("Valuation 2012");


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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[1] { "All" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results", "RollForward", true, true);
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Group", "RollForward", true, true, 0, new string[1] { "All" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Year", "RollForward", true, true, 0, new string[1] { "All" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Valuation2012_MethodScreenChange, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "All" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "All" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary", "RollForward", false, true, 0, new string[1] { "All" });
                ////////////////pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[1] { "All" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[1] { "All" });
                //////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "RollForward", false, true);
            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Future Valuation Summary", "RollForward", true, true, 0, new string[1] { "All" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "RollForward", true, true);


            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "IFRS", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Direct Promise", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_MethodScreenChange, "Support Fund", "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Pension RF - Valuation 2012 - SecondMethodScreenChance

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Summary", "RollForward", true, true);
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

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Valuation2012_SecondMethodScreenChance, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Test Cases", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                //////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });

                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                //pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Group", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Liabilities by Year", "RollForward", false, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
                ////////////////pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", false, true);

            }


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Future Valuation Summary", "RollForward", true, true, 0, new string[11] { "Sub1_CashBal01", "Sub1_DECO01", "Sub1_PENS01", "Sub1_PENS02", "Sub1_SF01", "Sub2_CashBal01", "Sub2_DECO01", "Sub2_PENS01", "Sub2_SF01", "Sub3_DECO01", "Sub3_PENS01" });
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "RollForward", true, true);


            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "IFRS", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Direct Promise", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_SecondMethodScreenChance, "Support Fund", "RollForward", false, true);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Pension RF - Valuation 2012 - V6.7 Enhancements

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
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
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "True");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._CancelRun();


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
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
            dic.Add("Pay", "PP_ProjectedPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "True");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputPension_Valuation2012_V67Enhancements, "Parameter Print", "RollForward", true, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Valuation2012_V67Enhancements, "Direct Promise", "RollForward", true, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Jubilee RF - Valuation 2012 - Baseline

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

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            ////////////dic.Add("iSelectRowNum", "2");
            ////////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "272");
            dic.Add("iPosY", "95");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            //////////////dic.Add("iSelectRowNum", "2");
            //////////////dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "272");
            dic.Add("iPosY", "95");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Individual Output", "RollForward", true, true);
                ////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                ////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Test Cases", "RollForward", false, true);
                pOutputManager._DE010_Jubilee2012_Baseline_ICT(sOutputJubilee_Valuation2012_Baseline);
                ////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            }


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "IFRS", "RollForward", true, false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_Baseline, "Jubilee", "RollForward", true, false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Jubilee RF - Valuation 2012 - Trade EAN


            pMain._SelectTab("Valuation 2012");


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


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");


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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Test Cases", "RollForward", false, false);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Summary", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "IFRS", "RollForward", true, false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Jubilee", "RollForward", true, false, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Individual Output", "RollForward", true, false);
                ////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Individual Output", "RollForward", false, false);
                ////////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradeEAN, "Future Valuation Summary", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });

            }


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region  Jubilee RF - Valuation 2012 - Trade PUC

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Test Cases", "RollForward", false, false);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", true, false, 0, new string[1] { "ALL" });
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "IFRS", "RollForward", true, false, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Jubilee", "RollForward", true, false, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Individual Output", "RollForward", true, false);
                //////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[1] { "ALL" });
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Individual Output", "RollForward", false, false);
                ////////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_TradePUC, "Future Valuation Summary", "RollForward", false, false, 0, new string[1] { "ALL" });
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Jubilee RF - Valuation 2012 - V6.7 Enhancements

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
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
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "false");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Test Cases", "RollForward", false, false);
            pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liabilities Detailed Results", "RollForward", true, false);
            ////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liability Set for Globe Export", "RollForward", true, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Individual Output", "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                ////////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });

            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Jubilee RF - Valuation 2012 - V6.9 Enhancements


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Batch Liabilities");
            pMain._FlowTreeRightSelect(dic);

            //pMain._HandleRemoved();

            _gLib._MsgBox("", "update liability order to ABO -> PBO -> Trade -> Tax");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "true");
            dic.Add("ApplyWithdrawalAdjustment", "true");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "true");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiSalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "true");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectNodes", "click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "73");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "204");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "336");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "477");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "602");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "732");
            dic.Add("iY", "206");
            dic.Add("OK", "click");
            pMain._PopVerify_MultipleNodeSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "JUBI01");
            dic.Add("SelectVOs_VO2", "JUBI02");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "204");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "342");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "475");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "607");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "729");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            _gLib._Wait(10);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "IFRS", "RollForward", true, false, true);
            //pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Jubilee", "RollForward", true, false, true);

            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iPosX", "204");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "342");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "475");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "607");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "734");
            dic.Add("iPosY", "206");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, false);

                dic.Clear();
                dic.Add("Include", "true;true");
                dic.Add("DataRequestGroup", "FormerEastGermary;FormerWastGermary");
                dic.Add("Layout", "Data request layout default;Data request layout default");
                dic.Add("SelectionCriteria", "$emp.OstWestKZ=1;$emp.OstWestKZ<>1");
                dic.Add("UseReportBreak", "true");
                dic.Add("Process", "click");
                pOutputManager._Jubilee_DataRequest(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);


                dic.Clear();
                dic.Add("Description", "test" + Environment.NewLine + "6" + Environment.NewLine + "sensi" + Environment.NewLine + "Nodes");
                dic.Add("ResultToBeIncluded_ResultType", "End of Year assumptions;Custom Demographic assumptions 1 +;"
                    + "Custom Demographic assumptions 1 -;Custom Financial assumptions 1 +;Custom Financial assumptions 1 -;"
                    + "Salary increase rate +;Salary increase rate -;");
                dic.Add("ResultToBeIncluded_ValuationNode", "V6.9 Enhancements;Mortality *1,135 ;Mortality *0,885 ;"
                    + "InterestSensitivity Null +0.5%;InterestSensitivity Null -0.5%;PaySensitivity 3.5%;PaySensitivity 2.5%");
                dic.Add("ExportToExcel", "click");
                dic.Add("ExportToGlobe", "click");
                pOutputManager._Jubilee_GlobeExportWithBreaksAndMultipleNodes(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);

            }


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Data -  Valuation2013

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation2013");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("Level_1", "Valuation2013");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "2013 Snapshot all fields");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "click");
            dic.Add("PublishSnapshot", "click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "click");
            pData._PopVerify_Snapshots(dic);

            pData._ts_SP_CreateExtract(sOutput_Data2013 + "2013 Snapshot all fields.xlsx");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion







            //#region  Jubilee RF - Valuation 2012 - V6.9 Enhancements


            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iPosX", "687");
            //dic.Add("iPosY", "140");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Batch Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._HandleRemoved();

            //_gLib._MsgBox("", "update liability order to ABO -> PBO -> Trade -> Tax");


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PayoutProjection", "true");
            //dic.Add("ApplyWithdrawalAdjustment", "true");
            //dic.Add("IncludeIOE", "");
            //dic.Add("GenerateParameterPrint", "true");
            //dic.Add("GenerateTestCaseOutput", "true");
            //dic.Add("SaveResultsforAuditReport", "");
            //dic.Add("ApplyOverrides", "");
            //dic.Add("RunLocally", "");
            //dic.Add("Pay", "JubiSalaryCurrentYear");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("BreakByFundingVehicle", "");
            //dic.Add("UseReportBreaks", "true");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Tax", "True");
            //dic.Add("Trade", "True");
            //dic.Add("AltTradeProjInt", "");
            //dic.Add("InternationalAccountingABO", "True");
            //dic.Add("InternationalAccountingPBO", "True");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "");
            //dic.Add("SelectVOs_VO2", "");
            //dic.Add("SelectVOs_VO3", "");
            //dic.Add("SelectVOs_VO4", "");
            //dic.Add("SelectVOs_VO5", "");
            //dic.Add("SelectNodes", "click");
            //dic.Add("RunValuation", "");
            //pMain._PopVerify_RunOptions(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "73");
            //dic.Add("iY", "206");
            //dic.Add("OK", "");
            //pMain._PopVerify_MultipleNodeSelection(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "204");
            //dic.Add("iY", "206");
            //dic.Add("OK", "");
            //pMain._PopVerify_MultipleNodeSelection(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "336");
            //dic.Add("iY", "206");
            //dic.Add("OK", "");
            //pMain._PopVerify_MultipleNodeSelection(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "477");
            //dic.Add("iY", "206");
            //dic.Add("OK", "");
            //pMain._PopVerify_MultipleNodeSelection(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "602");
            //dic.Add("iY", "206");
            //dic.Add("OK", "");
            //pMain._PopVerify_MultipleNodeSelection(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iX", "732");
            //dic.Add("iY", "206");
            //dic.Add("OK", "click");
            //pMain._PopVerify_MultipleNodeSelection(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("SelectVOs_AllVOs", "");
            //dic.Add("SelectVOs_VO1", "JUBI01");
            //dic.Add("SelectVOs_VO2", "JUBI02");
            //dic.Add("RunValuation", "Click");
            //pMain._PopVerify_RunOptions(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "80");
            //dic.Add("iPosY", "209");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "204");
            //dic.Add("iPosY", "209");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "342");
            //dic.Add("iPosY", "209");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "475");
            //dic.Add("iPosY", "209");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "607");
            //dic.Add("iPosY", "209");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);



            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "729");
            //dic.Add("iPosY", "205");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._EnterpriseRun("Group Job Completed With Errors", true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "687");
            //dic.Add("iPosY", "140");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Actuarial Report");
            //pMain._FlowTreeRightSelect(dic);

            //_gLib._Wait(10);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "687");
            //dic.Add("iPosY", "140");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            ////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "IFRS", "RollForward", true, false, true);
            ////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Jubilee", "RollForward", true, false, true);

            //pMain._SelectTab("Output Manager");

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);



            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "80");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");


            //dic.Clear();
            //dic.Add("iPosX", "204");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "342");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "475");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);



            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "607");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);



            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "734");
            //dic.Add("iPosY", "206");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Doer", "");
            //dic.Add("Checker", "");
            //dic.Add("Reviewer", "");
            //dic.Add("Setup", "click");
            //pOutputManager._PopVerify_OutputManager(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "click");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "V6.9 Enhancements");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null +0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "InterestSensitivity Null -0.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 3.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "PaySensitivity 2.5%");
            //dic.Add("Add", "click");
            //dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            //dic.Add("OK", "click");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);



            //pMain._SelectTab("Valuation 2012");

            //dic.Clear();
            //dic.Add("iPosX", "687");
            //dic.Add("iPosY", "140");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);


            //if (Config.bDownloadReports_EXCEL)
            //{

            //    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario with Breaks", "RollForward", false, false);
            //    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario by Plan Def with Breaks", "RollForward", false, false);
            //    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline with Breaks", "RollForward", false, false);
            //    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, false);
            //    pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results with Breaks", "RollForward", false, false);
            //    pOutputManager._ExportReport_Common(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, false);

            //    dic.Clear();
            //    dic.Add("Include", "true;true");
            //    dic.Add("DataRequestGroup", "FormerEastGermary;FormerWastGermary");
            //    dic.Add("Layout", "Data request layout default;Data request layout default");
            //    dic.Add("SelectionCriteria", "$emp.OstWestKZ=1;$emp.OstWestKZ<>1");
            //    dic.Add("UseReportBreak", "true");
            //    dic.Add("Process", "click");
            //    pOutputManager._Jubilee_DataRequest(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);


            //    dic.Clear();
            //    dic.Add("Description", "test" + Environment.NewLine + "6" + Environment.NewLine + "sensi" + Environment.NewLine + "Nodes");
            //    dic.Add("ResultToBeIncluded_ResultType", "End of Year assumptions;Custom Demographic assumptions 1 +;"
            //        + "Custom Demographic assumptions 1 -;Custom Financial assumptions 1 +;Custom Financial assumptions 1 -;"
            //        + "Salary increase rate +;Salary increase rate -;");
            //    dic.Add("ResultToBeIncluded_ValuationNode", "V6.9 Enhancements;Mortality *1,135 ;Mortality *0,885 ;"
            //        + "InterestSensitivity Null +0.5%;InterestSensitivity Null -0.5%;PaySensitivity 3.5%;PaySensitivity 2.5%");
            //    dic.Add("ExportToExcel", "click");
            //    dic.Add("ExportToGlobe", "click");
            //    pOutputManager._Jubilee_GlobeExportWithBreaksAndMultipleNodes(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);

            //}


            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Valuation 2012");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);

            //#endregion


            _gLib._MsgBox("Congratulations!", "Finished!");


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
