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


namespace RetirementStudio._TestScripts._TestScripts_CA
{
    /// <summary>
    /// Summary description for CA004_RB
    /// </summary>
    [CodedUITest]
    public class CA004_RB
    {
        public CA004_RB()
        {

            Config.eEnv = _TestingEnv.Prod_CA;
            Config.eCountry = _Country.CA;
            Config.sClientName = "QA CA Benchmark 004 6.1";
            Config.sPlanName = "QA CA Benchmark 004";
            Config.sProductionVerison = "6.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);
        }



        #region Report Output Directory

        public string sOutputFunding_Conversion2005 = "";
        public string sOutputFunding_Funding2008_Baseline = "";
        public string sOutputFunding_Funding2008_UpdateSolvency = "";
        public string sOutputAccounting_Test2005 = "";
        public string sOutputAccounting_Accounting2008 = "";
        public string sOutputFunding_Funding2008_MortalityProj = "";
        


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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_CA_Benchmark_4\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_Conversion2005 = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion2005\\" + sPostFix + "\\");
                sOutputFunding_Funding2008_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2008\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Funding2008_UpdateSolvency = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2008\\UpdateSolvency\\" + sPostFix + "\\");
                sOutputAccounting_Test2005 = _gLib._CreateDirectory(sMainDir + "Accounting\\Test2005\\" + sPostFix + "\\");
                sOutputAccounting_Accounting2008 = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting2008\\" + sPostFix + "\\");
                sOutputFunding_Funding2008_MortalityProj = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2008\\MortalityProj\\" + sPostFix + "\\");

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Conversion2005 = @\"" + sOutputFunding_Conversion2005 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2008_Baseline = @\"" + sOutputFunding_Funding2008_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2008_UpdateSolvency = @\"" + sOutputFunding_Funding2008_UpdateSolvency + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Test2005 = @\"" + sOutputAccounting_Test2005 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Accounting2008 = @\"" + sOutputAccounting_Accounting2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Funding2008_MortalityProj = @\"" + sOutputFunding_Funding2008_MortalityProj + "\";" + Environment.NewLine;

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
        public void test_CA004_RB()
        {


            this.GenerateReportOuputDir();


            #region sOutputFunding_Conversion2005

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion2005");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion2005");


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
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "ContribsWInterest1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion2005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion2005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2005, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2005, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Conversion2005, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2005, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2005, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2005, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2005, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Conversion2005, "Payout Projection", "Conversion", false, true);

                pOutputManager._ts_DrillDown_ALL(sOutputFunding_Conversion2005, dic);
            }

            
            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion2005");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Funding2008_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Funding2008");


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
            dic.Add("GL_GoingConcern", "True");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "ErAccountBalance1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "False");
            dic.Add("WindUpLiability", "False");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Parameter Print", "RollForward", true, true);
                ////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_Baseline, "Payout Projection", "RollForward", false, true);
            }

            


            pMain._SelectTab("Funding2008");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region sOutputAccounting_Test2005

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Test2005");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Test2005");


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
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "PSContributions");
            dic.Add("Pension", "AccruedBenefit1");
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

            pMain._SelectTab("Test2005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Test2005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Test2005, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Test2005, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Test2005, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Test2005, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Test2005, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Test2005, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }



            pMain._SelectTab("Test2005");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputAccounting_Accounting2008


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "2008 Accounting");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("2008 Accounting");

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
            dic.Add("Acc_GL_PBO", "True");
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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "ErAccountBalance1");
            dic.Add("Pension", "AccruedBenefit1");
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

            pMain._SelectTab("2008 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("2008 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Gain / Loss Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Decrement Age", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Parameter Print", "RollForward", true, false);
                ////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Test Cases", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Liability Set for Globe Export", "RollForward", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Decrement Age", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputAccounting_Accounting2008, "Gain / Loss Participant Listing", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputAccounting_Accounting2008, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputAccounting_Accounting2008, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("2008 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputAccounting_Accounting2008);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region sOutputFunding_Funding2008_UpdateSolvency

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Funding2008");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Funding2008");


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
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "ErAccountBalance1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("GoingConcernLiability", "True");
            dic.Add("SolvencyLiability", "True");
            dic.Add("WindUpLiability", "True");
            dic.Add("PayoutProjectionCustomGroup", "");
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

            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding2008");

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
            dic.Add("FC_IncludeSPC", "false");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pMain._PopVerify_RunSpecialPaymentTool_CA(dic);


            //////////string sContent = "Please follow the below steps: " + Environment.NewLine + Environment.NewLine;
            //////////sContent = sContent + "Step1: Main Menu - Keep the default selection for Ontario, click [Next]" + Environment.NewLine;
            //////////sContent = sContent + "Step2: Main Input - click [Next]" + Environment.NewLine;
            //////////sContent = sContent + "Step3: Input 1 (where shortfall and discount rates are entered) - keep default values and click [Next]" + Environment.NewLine;
            //////////sContent = sContent + "Step4: Input 2 (existing GC special payment) - no need to enter anything, click [Next] " + Environment.NewLine;
            //////////sContent = sContent + "Step5: Input 3 (existing Solvency special payment) - enter the following into row 1 , click [Run]" + Environment.NewLine;
            //////////sContent = sContent + "       Enter values for Input 3: Date Established= 1/1/2003, Montly payment =$60,216, Last payment = 31/12/2008" + Environment.NewLine;
            //////////sContent = sContent + "Step6: Close the current SPT Excel file" + Environment.NewLine;
            //////////sContent = sContent + "Step7: Click Yes to save SPT " + Environment.NewLine + Environment.NewLine;
            //////////sContent = sContent + "Click OK in this messagebox to keet testing!" + Environment.NewLine;

            //////////_gLib._MsgBox("Need Manual Interaction!", sContent);




            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Parameter Print", "RollForward", true, true);
                ////////pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liabilities Detailed Results", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Funding Calculatior Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Funding2008_UpdateSolvency, "Special Payment Calculation", "RollForward", false, true);
            }

            

            pMain._SelectTab("Funding2008");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Funding_Funding2008_MortalityProj


            pMain._SelectTab("Funding2008");


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
            dic.Add("GL_GoingConcern", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "Credited");
            dic.Add("Pay", "ProjPay");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "ErAccountBalance1");
            dic.Add("Pension", "AccruedBenefit1");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("CalcIncreCostSolvencyWindup", "False");
            dic.Add("RunValuation", "Click");
            ////// EE Contributions = ErAccouintBalance1
            ////// Persion = AccruedBenefit1
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Funding2008");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Funding2008_MortalityProj, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);


            pMain._SelectTab("Funding2008");
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
