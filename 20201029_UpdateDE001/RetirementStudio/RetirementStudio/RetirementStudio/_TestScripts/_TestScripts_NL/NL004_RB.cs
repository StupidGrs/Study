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


namespace RetirementStudio._TestScripts._TestScripts_NL
{
    /// <summary>
    /// Summary description for NL004_RB
    /// </summary>
    [CodedUITest]
    public class NL004_RB
    {

        public NL004_RB()
        {
            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 004 B";
            Config.sPlanName = "QA NL Benchmark 004 B Plan";
            Config.sProductionVerison = "6.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;
        }


        #region Report Output Directory


        public string sOutputAccounting_Conversion2011 = "";
        public string sOutputAccounting_Valuation2012_Baseline = "";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity125 = "";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity75 = "";
        public string sOutputAccounting_Valuation2012_InterestSensitivity585 = "";
        public string sOutputAccounting_Valuation2012_InterestSensitivity535 = "";
        public string sOutputAccounting_Valuation2012_PaySensitivity325 = "";
        public string sOutputAccounting_Valuation2012_PaySensitivity375 = "";

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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();
                
                sPostFix = sPostFix + "_E";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputAccounting_Conversion2011 = _gLib._CreateDirectory(sMainDir + "Conversion 2011\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\Baseline\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_IndexationSensitivity75 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\IndexationSensitivity 0.75%\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_IndexationSensitivity125 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\IndexationSensitivity 1.25%\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_InterestSensitivity535 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\InterestSensitivity 5.35%\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_InterestSensitivity585 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\InterestSensitivity 5.85%\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_PaySensitivity325 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\PaySensitivity 3.25%\\" + sPostFix + "\\");
                sOutputAccounting_Valuation2012_PaySensitivity375 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\PaySensitivity 3.75%\\" + sPostFix + "\\");

            }


            string sContent = "";
            sContent = sContent + "sOutputAccounting_Conversion2011 = @\"" + sOutputAccounting_Conversion2011 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_Baseline = @\"" + sOutputAccounting_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_IndexationSensitivity75 = @\"" + sOutputAccounting_Valuation2012_IndexationSensitivity75 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_IndexationSensitivity125 = @\"" + sOutputAccounting_Valuation2012_IndexationSensitivity125 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_InterestSensitivity535 = @\"" + sOutputAccounting_Valuation2012_InterestSensitivity535 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_InterestSensitivity585 = @\"" + sOutputAccounting_Valuation2012_InterestSensitivity585 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_PaySensitivity325 = @\"" + sOutputAccounting_Valuation2012_PaySensitivity325 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_PaySensitivity375 = @\"" + sOutputAccounting_Valuation2012_PaySensitivity375 + "\";" + Environment.NewLine;

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
        public void test_NL004_RB()
        {


            this.GenerateReportOuputDir();


            #region sOutputAccounting_Conversion2011


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
            dic.Add("ServiceToOpen", "Conversion 2011");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion 2011");


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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "#1#");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "OrganizationCode");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Test Cases", "Conversion", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            pMain._SelectTab("Conversion 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputAccounting_Valuation2012_Baseline


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
            dic.Add("ServiceToOpen", "Valuation 2012");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "405");
            dic.Add("iPosY", "95");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "OrganizationCode");
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
            dic.Add("iPosX", "405");
            dic.Add("iPosY", "95");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "405");
            dic.Add("iPosY", "95");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "");
            dic.Add("Node", "Baseline");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "OrganizationCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results with Breaks", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Checking Template", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputAccounting_Valuation2012_InterestSensitivity585



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "72");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "72");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "72");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "");
            dic.Add("Node", "Baseline");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity 5.85%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "OrganizationCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);



            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario with Breaks", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "FAS Expected Benefit Pmts", "Conversion", true, false);

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline with Breaks", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results with Breaks", "RollForward", true, false);

                pMain._SelectTab("Output Manager");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Doer", "True");
                dic.Add("Checker", "");
                dic.Add("Reviewer", "");
                dic.Add("Setup", "click");
                pOutputManager._PopVerify_OutputManager(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RemoveAll", "");
                dic.Add("AddAll", "");
                dic.Add("Node", "");
                dic.Add("Add", "");
                dic.Add("ShowSubtotalBreaks", "N/A");
                dic.Add("OK", "Click");
                pOutputManager._PopVerify_OutputManagerSetup(dic);

                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Set for Globe Export", "RollForward", true, false);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pMain._SelectTab("Output Manager");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Doer", "True");
                dic.Add("Checker", "");
                dic.Add("Reviewer", "");
                dic.Add("Setup", "click");
                pOutputManager._PopVerify_OutputManager(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RemoveAll", "");
                dic.Add("AddAll", "");
                dic.Add("Node", "");
                dic.Add("Add", "");
                dic.Add("ShowSubtotalBreaks", "OrganizationCode");
                dic.Add("OK", "Click");
                pOutputManager._PopVerify_OutputManagerSetup(dic);

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "FAS Expected Benefit Pmts", "Conversion", false, false);

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results with Breaks", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, false);

                pMain._SelectTab("Output Manager");

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Doer", "True");
                dic.Add("Checker", "");
                dic.Add("Reviewer", "");
                dic.Add("Setup", "click");
                pOutputManager._PopVerify_OutputManager(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RemoveAll", "");
                dic.Add("AddAll", "");
                dic.Add("Node", "");
                dic.Add("Add", "");
                dic.Add("ShowSubtotalBreaks", "N/A");
                dic.Add("OK", "Click");
                pOutputManager._PopVerify_OutputManagerSetup(dic);

                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Set for Globe Export", "RollForward", false, false);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "72");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputAccounting_Valuation2012_InterestSensitivity585);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region sOutputAccounting_Valuation2012_PaySensitivity375



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "205");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "205");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "205");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liability Set for Globe Export", "RollForward", true, false);

            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "FAS Expected Benefit Pmts", "Conversion", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputAccounting_Valuation2012_IndexationSensitivity125



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "340");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "340");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "340");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liability Set for Globe Export", "RollForward", true, false);

            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "FAS Expected Benefit Pmts", "Conversion", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputAccounting_Valuation2012_InterestSensitivity535



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "470");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liability Set for Globe Export", "RollForward", true, false);

            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "FAS Expected Benefit Pmts", "Conversion", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputAccounting_Valuation2012_PaySensitivity325



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liability Set for Globe Export", "RollForward", true, false);

            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "FAS Expected Benefit Pmts", "Conversion", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region sOutputAccounting_Valuation2012_IndexationSensitivity75



            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "736");
            dic.Add("iPosY", "150");
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
            dic.Add("Service", "ServiceProrate");
            dic.Add("Pay", "PayNormalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "PastServiceBenefitOPatValDate");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "");
            dic.Add("SolvencyLiability", "");
            dic.Add("WindUpLiability", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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
            dic.Add("iPosX", "736");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "736");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "");
            dic.Add("Node", "Baseline");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity 5.85%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.75%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "IndexationSensitivity1.25%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity 5.35%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.25%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "IndexationSensitivity0.75%");
            dic.Add("Add", "Click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Test Cases", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Scenario", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "FAS Expected Benefit Pmts", "Conversion", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Reconciliation to Baseline", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liabilities Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Set for Globe Export", "RollForward", true, false);

            }




            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Scenario", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Scenario by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "FAS Expected Benefit Pmts", "Conversion", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Reconciliation to Baseline", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liabilities Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Valuation 2012");
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
