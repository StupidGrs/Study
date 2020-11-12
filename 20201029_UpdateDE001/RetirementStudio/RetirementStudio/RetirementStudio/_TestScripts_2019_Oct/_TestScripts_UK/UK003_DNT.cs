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




namespace RetirementStudio._TestScripts_2019_Oct_UK
{
    /// <summary>
    /// Summary description for UK003_DNT
    /// </summary>
    [CodedUITest]
    public class UK003_DNT
    {
        public UK003_DNT()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 003 Existing DNT";
            Config.sPlanName = "QA UK Benchmark 003 Existing DNT Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory



        public string sOutputFunding_Valuation2011_Baseline = "";
        public string sOutputFunding_Valuation2014_Baseline = "";
        public string sOutputFunding_Valuation2014_FVGrowthPCT = "";


        public string sOutputFunding_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2011\6.8_20160322_B\";
        public string sOutputFunding_Valuation2014_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\Baseline\6.8_20160322_B\";
        public string sOutputFunding_Valuation2014_FVGrowthPCT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\FV GrowthPCT\6.8_20160322_B\";



        public void GenerateReportOuputDir()
        {
            pMain._SetLanguageAndRegional();

            if (!Config.bReportsStoreLocal)
            {
                _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();
                if (sCurrentUser.ToString() == "Others")
                {
                    _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in \\mercer.com\\US_Data\\Shared\\Dfl\\Data1\\RSS\\SQA drive, Please contact Cindy or Webber if you have to!");
                    Environment.Exit(0);
                }
                else
                {

                    //public string  = "";
                    //public string  = "";
                    //public string  = "";

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Existing\Funding\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2011\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2014_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2014_FVGrowthPCT = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\FV GrowthPCT\\" + sPostFix + "\\");


                }

            }
            else
            {
                // get the main reports directory
                string sDir = Directory.GetCurrentDirectory();
                for (int i = 0; i < 3; i++)
                {
                    DirectoryInfo info = Directory.GetParent(sDir);
                    sDir = info.FullName;
                }

                /// this is for VS2012 folder structure
                sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

                //////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "UK003_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2011_Baseline\\");
                sOutputFunding_Valuation2014_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2014_Baseline\\");
                sOutputFunding_Valuation2014_FVGrowthPCT = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2014_FVGrowthPCT\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2011_Baseline = @\"" + sOutputFunding_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2014_Baseline = @\"" + sOutputFunding_Valuation2014_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2014_FVGrowthPCT = @\"" + sOutputFunding_Valuation2014_FVGrowthPCT + "\";" + Environment.NewLine;

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
        public void test_UK003_DNT()
        {

            #region MultiThreads

            Thread thrd_Valuation2011_Baseline = new Thread(() => new UK003_DNT().t_CompareRpt_Valuation2011_Baseline(sOutputFunding_Valuation2011_Baseline));

            #endregion



            this.GenerateReportOuputDir();


            #region sOutputFunding_Valuation2011_Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
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
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
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
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Test Cases", "Conversion", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_Valuation2011_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Detailed Results", "Conversion", false, true);
            _gLib._MsgBox("Warning!", "XLS report <Detailed Results with Ben Type splits> only works in Win7 machine, skip here.");
            //////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Detailed Results with Ben Type splits", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Payout Projection - Other Info", "Conversion", false, true);


            thrd_Valuation2011_Baseline.Start();


            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region sOutputFunding_Valuation2014_FVGrowthPCT

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2014");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2014");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Valuation 2014");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");

            pMain._SelectTab("Valuation 2014");

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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Calculations");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Update Calculations");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Parameter Print", "RollForward", true, true);


            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Benefit Cashflows", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Other Info", "RollForward", false, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results", "RollForward", false, true);
            //////_gLib._MsgBox("Warning!", "XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine, skip here.");
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results with Ben Type splits", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Checking Spreadsheet", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Consulting Spreadsheet", "RollForward", false, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Results Summary", "RollForward", false, true);



            _gLib._MsgBox("", "XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine," + Environment.NewLine + Environment.NewLine
                + "please mannually click and download <Liabilities Detailed Results with Ben Type splits>, if process not complete please ship because bug not fixed.");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Valuation Report", 3);

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, false, "Silver");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, true, "Silver");


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003DNT", sOutputFunding_Valuation2014_FVGrowthPCT_Prod, sOutputFunding_Valuation2014_FVGrowthPCT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2014_FVGrowthPCT");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Funding.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund1.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund2.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund3.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPFS179.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Funding.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPF.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund1.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund2.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund3.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2014-liabilityvaluationdate.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2015-liabilityvaluationdate+1year.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2016-liabilityvaluationdate+2year.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);

                _compareReportsLib.CompareExcel_Exact("FundingUpdateResultsSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FundingCalculator-CheckingSpreadsheet.xlsm", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FundingCalculator-ConsultingSpreadsheet.xlsm", 4, 0, 0, 0, true);

            }

            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");
        }


        public void t_CompareRpt_Valuation2011_Baseline(string sOutputFunding_Valuation2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003DNT", sOutputFunding_Valuation2011_Baseline_Prod, sOutputFunding_Valuation2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBenTypesplits.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
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
