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


namespace RetirementStudio._TestScripts._TestScripts_IR
{
    /// <summary>
    /// Summary description for IR001_RB
    /// </summary>
    [CodedUITest]
    public class IR001_RB
    {
        public IR001_RB()
        {
            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.IR;
            Config.sClientName = "QA IR Benchmark 001";
            Config.sPlanName = "QA IR Benchmark 001 Plan";
            Config.sProductionVerison = "6.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;
        }


        #region Report Output Directory


        public string sOutputFunding_Valuation2009_Baseline = "";
        public string sOutputFunding_Valuation2009_AttainedAge = "";
        public string sOutputFunding_2010Valuation_Baseline = "";
        public string sOutputFunding_2010Valuation_AddDecrements = "";
        public string sOutputAccounting_FASValuation2009 = "";
        public string sOutputAccounting_FASValuation2010_Baseline = "";
        public string sOutputAccounting_FASValuation2010_AddDecrements = "";


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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_IR_Benchmark_001\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_E";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_Valuation2009_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2009\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Valuation2009_AttainedAge = _gLib._CreateDirectory(sMainDir + "Valuation 2009\\Attained Age\\" + sPostFix + "\\");
                sOutputFunding_2010Valuation_Baseline = _gLib._CreateDirectory(sMainDir + "2010 Valuation\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_2010Valuation_AddDecrements = _gLib._CreateDirectory(sMainDir + "2010 Valuation\\Add Decrements\\" + sPostFix + "\\");
                sOutputAccounting_FASValuation2009 = _gLib._CreateDirectory(sMainDir + "FAS Valuation 2009\\" + sPostFix + "\\");
                sOutputAccounting_FASValuation2010_Baseline = _gLib._CreateDirectory(sMainDir + "FAS Valuation 2010\\Baseline\\" + sPostFix + "\\");
                sOutputAccounting_FASValuation2010_AddDecrements = _gLib._CreateDirectory(sMainDir + "FAS Valuation 2010\\Add Decrements\\" + sPostFix + "\\");

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2009_Baseline = @\"" + sOutputFunding_Valuation2009_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2009_AttainedAge = @\"" + sOutputFunding_Valuation2009_AttainedAge + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_2010Valuation_Baseline = @\"" + sOutputFunding_2010Valuation_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_2010Valuation_AddDecrements = @\"" + sOutputFunding_2010Valuation_AddDecrements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASValuation2009 = @\"" + sOutputAccounting_FASValuation2009 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASValuation2010_Baseline = @\"" + sOutputAccounting_FASValuation2010_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASValuation2010_AddDecrements = @\"" + sOutputAccounting_FASValuation2010_AddDecrements + "\";" + Environment.NewLine;

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
        public void test_IR001_RB()
        {


            this.GenerateReportOuputDir();


            #region sOutputFunding_Valuation2009_Baseline

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
            dic.Add("ServiceToOpen", "Valuation 2009");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2009");

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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2009_Baseline, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2009_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Payout Projection", "Conversion", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2009_Baseline, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2009_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_Baseline, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_Baseline, "Payout Projection", "Conversion", false, true);

            }


            pMain._SelectTab("Valuation 2009");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputFunding_Valuation2009_AttainedAge


            pMain._SelectTab("Valuation 2009");

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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_AttainedAge, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2009_AttainedAge, "Reconciliation to Baseline", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_AttainedAge, "Liabilities Detailed Results", "Conversion", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_AttainedAge, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2009_AttainedAge, "Payout Projection", "Conversion", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2009_AttainedAge, "Reconciliation to Baseline", "Conversion", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2009_AttainedAge, "Reconciliation to Baseline by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_AttainedAge, "Liabilities Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2009_AttainedAge, "Liabilities Detailed Results by Plan Def", "Conversion", false, true);
            }


            pMain._SelectTab("Valuation 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_2010Valuation_Baseline

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
            dic.Add("ServiceToOpen", "2010 Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("2010 Valuation");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("2010 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("2010 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Test Cases", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Payout Projection", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_Baseline, "Payout Projection", "RollForward", false, true);
            }




            pMain._SelectTab("2010 Valuation");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputFunding_2010Valuation_AddDecrements


            pMain._SelectTab("2010 Valuation");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("2010 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("2010 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Test Cases", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_2010Valuation_AddDecrements, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }



            pMain._SelectTab("2010 Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputAccounting_FASValuation2009

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Valuation 2009");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("FAS Valuation 2009");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("FAS Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("FAS Valuation 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Test Cases", "Conversion", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_FASValuation2009, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_FASValuation2009, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_FASValuation2009, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_FASValuation2009, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASValuation2009, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASValuation2009, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            pMain._SelectTab("FAS Valuation 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputAccounting_FASValuation2010_Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Valuation 2010");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("FAS Valuation 2010");

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
            dic.Add("Acc_GL_PBO", "");
            dic.Add("Acc_GL_ABO", "");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("FAS Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Test Cases", "RollForward", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
            }



            pMain._SelectTab("FAS Valuation 2010");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region sOutputAccounting_FASValuation2010_AddDecrements


            pMain._SelectTab("FAS Valuation 2010");

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
            dic.Add("Acc_GL_PBO", "");
            dic.Add("Acc_GL_ABO", "");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "TotalService");
            dic.Add("Pay", "PensionableSalary");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AdjustedInPayPension");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("FAS Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Test Cases", "RollForward", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liability Scenario", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liability Set for Globe Export", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liabilities Detailed Results", "RollForward", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liability Scenario", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liability Scenario by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liability Set for Globe Export", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_FASValuation2010_AddDecrements, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("FAS Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputAccounting_FASValuation2010_AddDecrements);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


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
