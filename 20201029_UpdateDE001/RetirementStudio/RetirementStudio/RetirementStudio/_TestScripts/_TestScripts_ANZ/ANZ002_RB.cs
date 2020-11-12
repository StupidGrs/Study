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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.EligibilitiesClasses;
using RetirementStudio._UIMaps.SpecialEligibilitiesClasses;
using RetirementStudio._UIMaps.PayoutProjectionClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.Item415LimitsClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
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
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.CustomRateClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;
using RetirementStudio._UIMaps.TableManagerClasses;
using RetirementStudio._UIMaps.AgeClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;



namespace RetirementStudio._TestScripts._TestScripts_ANZ
{
    /// <summary>
    /// Summary description for ANZ001_CN
    /// </summary>
    [CodedUITest]
    public class ANZ002_RB
    {
        public ANZ002_RB()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.ANZ;
            Config.sClientName = "QA ANZ Benchmark 002";
            Config.sPlanName = "QA ANZ Benchmark 002 Plan";
            //////Config.sClientName = "QA ANZ Benchmark 002 D";
            //////Config.sPlanName = "QA ANZ Benchmark 002 D Plan";
            Config.sProductionVerison = "6.8";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

        }

        #region Report Output Directory



        public string sOutputFunding_2014BenchmarkVal_Baseline = "";
        public string sOutputFunding_2014BenchmarkVal_REVISED50YearsFV = "";

        public string sOutputFunding_2014BenchmarkVal_Baseline_Prod = "";
        public string sOutputFunding_2014BenchmarkVal_REVISED50YearsFV_Prod = "";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_ANZ_002\Production\";
                    string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                    sPostFix = sPostFix + "_Franklin";

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                    sOutputFunding_2014BenchmarkVal_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2014_Baseline\\" + sPostFix + "\\");
                    sOutputFunding_2014BenchmarkVal_REVISED50YearsFV = _gLib._CreateDirectory(sMainDir + "Funding2014_Revised50YearsFV\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "ANZ002_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);

                sOutputFunding_2014BenchmarkVal_Baseline = _gLib._CreateDirectory(sMainDir + "Funding2014\\Baseline\\");
                sOutputFunding_2014BenchmarkVal_REVISED50YearsFV = _gLib._CreateDirectory(sMainDir + "Funding2014\\REVISED50YearsFV\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_2014BenchmarkVal_Baseline = @\"" + sOutputFunding_2014BenchmarkVal_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_2014BenchmarkVal_REVISED50YearsFV = @\"" + sOutputFunding_2014BenchmarkVal_REVISED50YearsFV + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }




        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public PayCredit pPayCredit = new PayCredit();
        public Age pAge = new Age();
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
        public FromToAge pFromToAge = new FromToAge();
        public SpecialEligibilities pSpecialEligibilities = new SpecialEligibilities();
        public Eligibilities pEligibilities = new Eligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public Vesting pVesting = new Vesting();
        public UnitFormula pUnitFormula = new UnitFormula();
        public ActuarialEquivalence pActuarialEquivalence = new ActuarialEquivalence();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public ConversionFactors pConversionFactors = new ConversionFactors();
        public FormOfPayment pFormOfPayment = new FormOfPayment();
        public Item415Limits p415Limits = new Item415Limits();
        public Adjustments pAdjustments = new Adjustments();
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
        public FAEFormula pFAEFormula = new FAEFormula();

        public CustomRate pCustomRate = new CustomRate();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();
        public TableManager pTableManager = new TableManager();

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_ANZ002_RB()
        {

            this.GenerateReportOuputDir();
           

            #region 2014BMVal_Baseline - ParticipantData


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
            dic.Add("ServiceToOpen", "2014 Benchmark Val");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("2014 Benchmark Val");

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
            dic.Add("AllLiabilityTypes", "true");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("PayoutProjection", "true");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalaryCurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccrualRate");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "");
            pOutputManager._PopVerify_OutputManager(dic);

            pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Valuation Summary", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_2014BenchmarkVal_Baseline, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_2014BenchmarkVal_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_2014BenchmarkVal_Baseline, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_2014BenchmarkVal_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_2014BenchmarkVal_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_2014BenchmarkVal_Baseline, "Payout Projection", "Conversion", false, true);

            }
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("ANZ002CreateNew", sOutputFunding_2014BenchmarkVal_Baseline_Prod, sOutputFunding_2014BenchmarkVal_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_2014BenchmarkVal_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("2014 Benchmark Val");
            pMain._Home_ToolbarClick_Top(true);

            #endregion



            #region 2014BenchmarkVal_REVISED50YearsFV_Prod


            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);

            pFutureValuationOption._SelectTab("Projection years");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "1");
            dic.Add("AndEvery", "5");
            dic.Add("UpToincludingProjectionYear", "50");
            dic.Add("ProjectionYears", "");
            dic.Add("NumberOfRuns", "");
            dic.Add("RandomNumDismissed", "");
            dic.Add("FundingUpdateDate_UK", "");
            pFutureValuationOption._ProjectionYears(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pFutureValuationOption._PopVerify_OK(dic);


            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");


            _gLib._MsgBoxYesNo("", "Please confirm the next FV ER would not effect the other college, because it'll cost 2 hours  !!!");


            pMain._SelectTab("2014 Benchmark Val");

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
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");



            pMain._SelectTab("2014 Benchmark Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "");
            pOutputManager._PopVerify_OutputManager(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Population Projection", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Liabilities by Group", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Liabilities by Year", "Conversion", true, true);
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Population Projection", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Liabilities by Group", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Future Valuation Liabilities by Year", "Conversion", false, true);
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV, "Conversion", false, true);
            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("ANZ002_CN", sOutputFunding_2014BenchmarkVal_REVISED50YearsFV_Prod, sOutputFunding_2014BenchmarkVal_REVISED50YearsFV);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_2014BenchmarkVal_REVISED50YearsFV");
             
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2019.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2024.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2029.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2034.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2039.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2044.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2049.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2054.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2059.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2064.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });

            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("2014 Benchmark Val");
            pMain._Home_ToolbarClick_Top(true);


            #endregion



            _gLib._MsgBox("!", "Finished");

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
