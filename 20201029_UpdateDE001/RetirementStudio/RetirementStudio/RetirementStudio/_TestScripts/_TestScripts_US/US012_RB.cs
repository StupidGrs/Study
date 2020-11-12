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


namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for US012_RB
    /// </summary>
    [CodedUITest]
    public class US012_RB
    {
        public US012_RB()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 012";
            Config.sPlanName = "QA US Benchmark 012 Plan";
            //Config.sClientName = "QA US Benchmark 012 D";
            //Config.sPlanName = "QA US Benchmark 012 D Plan";
            Config.sProductionVerison = "7.3";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

        }

        #region Report Output Directory
        

        public string sConversion = "";
        public string s2008Valuatoin_Baseline = "";
        public string s2008Valuatoin_PPAAssumptions = "";
        public string s2008Valuatoin_BurnCOB = "";
        public string sPlanTerminationSetup_ForBaseline = "";
        public string sPlanTerminationSetup_HMLRetAge = "";
        public string sPlanTerminationSetup_HighRetAge = "";
        public string sPlanTerminationSetup_EarliestRetAge = "";
        public string sPlanTerminationSetup_PBGC_Fields = "";
        public string sPlanTerminationSetup_PBGC_4044 = "";
        public string sAccountingConversion = "";

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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_12_Knight\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_Franklin";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                sConversion = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Conversion\\" + sPostFix + "\\");
                s2008Valuatoin_Baseline = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\Baseline\\" + sPostFix + "\\");
                s2008Valuatoin_PPAAssumptions = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\PPA Assumptions\\" + sPostFix + "\\");
                s2008Valuatoin_BurnCOB = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\2008 Valuation\\Burn COB\\" + sPostFix + "\\");
                sPlanTerminationSetup_ForBaseline = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\For Baseline\\" + sPostFix + "\\");
                sPlanTerminationSetup_HMLRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\HML Ret Age\\" + sPostFix + "\\");
                sPlanTerminationSetup_HighRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\High Ret Age\\" + sPostFix + "\\");
                sPlanTerminationSetup_EarliestRetAge = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\Earliest Ret Age\\" + sPostFix + "\\");
                sPlanTerminationSetup_PBGC_Fields = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\PBGC_Fields\\" + sPostFix + "\\");
                sPlanTerminationSetup_PBGC_4044 = _gLib._CreateDirectory(sMainDir + "Funding Valuation\\Plan Termination Setup\\PBGC_4044\\" + sPostFix + "\\");
                sAccountingConversion = _gLib._CreateDirectory(sMainDir + "Accounting Valuation\\Conversion\\" + sPostFix + "\\");

            }


 

            string sContent = "";
            sContent = sContent + "sConversion = @\"" + sConversion + "\";" + Environment.NewLine;
            sContent = sContent + "s2008Valuatoin_Baseline = @\"" + s2008Valuatoin_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "s2008Valuatoin_PPAAssumptions = @\"" + s2008Valuatoin_PPAAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "s2008Valuatoin_BurnCOB = @\"" + s2008Valuatoin_BurnCOB + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_ForBaseline = @\"" + sPlanTerminationSetup_ForBaseline + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_HMLRetAge = @\"" + sPlanTerminationSetup_HMLRetAge + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_HighRetAge = @\"" + sPlanTerminationSetup_HighRetAge + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_EarliestRetAge = @\"" + sPlanTerminationSetup_EarliestRetAge + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_PBGC_Fields = @\"" + sPlanTerminationSetup_PBGC_Fields + "\";" + Environment.NewLine;
            sContent = sContent + "sPlanTerminationSetup_PBGC_4044 = @\"" + sPlanTerminationSetup_PBGC_4044 + "\";" + Environment.NewLine;
            sContent = sContent + "sAccountingConversion = @\"" + sAccountingConversion + "\";" + Environment.NewLine;

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
        public void test_US012_RB()
        {




            this.GenerateReportOuputDir();


            #region sConversion

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "SVC");
            dic.Add("Pay", "SalPrj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sConversion, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sConversion, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sConversion, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sConversion, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sConversion, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sConversion, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sConversion, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sConversion, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sConversion, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sConversion, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sConversion, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sConversion, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sConversion, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sConversion, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sConversion, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sConversion, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sConversion, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sConversion, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sConversion, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sConversion, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sConversion, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sConversion, "Payout Projection", "Conversion", false, true);

            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            #region s2008Valuatoin_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "2008 Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("2008 Valuation");


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
            dic.Add("GL_PPANAR_Min", "True");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("2008 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("2008 Valuation");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_Baseline, "Payout Projection", "RollForward", false, true);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("2008 Valuation");
            pMain._Home_ToolbarClick_Top(true);




            #endregion


            #region s2008Valuatoin_PPAAssumptions


            pMain._SelectTab("2008 Valuation");


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
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("2008 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("2008 Valuation");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(s2008Valuatoin_PPAAssumptions, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_PPAAssumptions, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_PPAAssumptions, "Reconciliation to Baseline", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(s2008Valuatoin_PPAAssumptions, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_PPAAssumptions, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_PPAAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_PPAAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_PPAAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_PPAAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("2008 Valuation");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region s2008Valuatoin_BurnCOB


            pMain._SelectTab("2008 Valuation");


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
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
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

            pMain._SelectTab("2008 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("2008 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
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



            pMain._SelectTab("2008 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                ////pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Liabilities Detailed Results", "RollForward", true, true);
                //////pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Funding Calculator", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                //////pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(s2008Valuatoin_BurnCOB, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(s2008Valuatoin_BurnCOB, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                //////pOutputManager._ExportReport_Common(s2008Valuatoin_BurnCOB, "Funding Calculator", "RollForward", false, true);

            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("2008 Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sPlanTerminationSetup_ForBaseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Plan Termination Setup");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Plan Termination Setup");


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
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PBGCPlanTermination", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_ForBaseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_ForBaseline, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_ForBaseline, "Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_ForBaseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_ForBaseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_ForBaseline, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_ForBaseline, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_ForBaseline, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_ForBaseline, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);






            #endregion


            #region sPlanTerminationSetup_HMLRetAge


            pMain._SelectTab("Plan Termination Setup");


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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PBGCPlanTermination", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HMLRetAge, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HMLRetAge, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HMLRetAge, "Reconciliation to Baseline", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HMLRetAge, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HMLRetAge, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HMLRetAge, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HMLRetAge, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HMLRetAge, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HMLRetAge, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Plan Termination Setup");
            pMain._Home_ToolbarClick_Top(true);

            #endregion




            #region sPlanTerminationSetup_HighRetAge


            pMain._SelectTab("Plan Termination Setup");


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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PBGCPlanTermination", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HighRetAge, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HighRetAge, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HighRetAge, "Reconciliation to Baseline", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HighRetAge, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_HighRetAge, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HighRetAge, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_HighRetAge, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HighRetAge, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_HighRetAge, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Plan Termination Setup");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sPlanTerminationSetup_EarliestRetAge


            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PBGCPlanTermination", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_EarliestRetAge, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_EarliestRetAge, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_EarliestRetAge, "Reconciliation to Baseline", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sPlanTerminationSetup_EarliestRetAge, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_EarliestRetAge, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_EarliestRetAge, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_EarliestRetAge, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_EarliestRetAge, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_EarliestRetAge, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Plan Termination Setup");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sPlanTerminationSetup_PBGC_Fields


            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PBGCPlanTermination", "True");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "");
            dic.Add("FAS35PresentValueOfVestedBenefits", "");
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "6");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_Fields, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_Fields, "Liabilities Detailed Results", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_Fields, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_Fields, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sPlanTerminationSetup_PBGC_Fields, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_Fields, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_Fields, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

 



            #endregion


            #region sPlanTerminationSetup_PBGC_4044


            pMain._SelectTab("Plan Termination Setup");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalPrj");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Plan Termination Setup");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "7");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sPlanTerminationSetup_PBGC_4044, "Parameter Print", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_4044, "PBGC 4044 Liabilities by Plan Def", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sPlanTerminationSetup_PBGC_4044, "PBGC 4044 Liabilities by Plan Def", "RollForward", false, true);


                pOutputManager._Navigate(Config.eCountry, "IOE", "RollForward", true);
                pOutputManager._SelectTab("Individual Output");
                _gLib._SetSyncUDWin("Group - None", pOutputManager.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                _gLib._SetSyncUDWin("Process", pOutputManager.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                if (_gLib._Exists("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                    _gLib._SetSyncUDWin("NewIOEParameters1", pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                else
                {
                    dic.Clear();
                    dic.Add("Level_1", "Individual Output");
                    _gLib._TreeViewSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree, dic);

                    dic.Clear();
                    dic.Add("Level_1", "Individual Output");
                    dic.Add("MenuItem", "Add IOE Parameters");
                    _gLib._TreeViewRightSelectWin(0, pOutputManager.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);
                }

                dic.Clear();
                dic.Add("Level_1", "PBGC_Plan_Term");
                dic.Add("Level_2", "Provision Output Fields");
                dic.Add("Level_3", "PBGC Dollar Max");
                pOutputManager._TreeViewSelect_IOE(dic, true);

                _gLib._SetSyncUDWin("Export", pOutputManager.wRetirementStudio.wExport.btnExport, "Click", 0);

                pOutputManager._SaveAs(sPlanTerminationSetup_PBGC_4044 + "IOE.xls");
                _gLib._SetSyncUDWin("OK", pOutputManager.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                _gLib._FileExists(sPlanTerminationSetup_PBGC_4044 + "IOE.xlsx", Config.iTimeout, true);

            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Plan Termination Setup");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion



            #region sAccountingConversion

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Conversion");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "SVC");
            dic.Add("Pay", "SalPrj");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
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

            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Conversion");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sAccountingConversion, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccountingConversion, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sAccountingConversion, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccountingConversion, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccountingConversion, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccountingConversion, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccountingConversion, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion");
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
