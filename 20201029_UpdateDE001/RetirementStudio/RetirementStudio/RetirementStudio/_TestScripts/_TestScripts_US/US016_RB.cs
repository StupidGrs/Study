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
    /// Summary description for US016_RB
    /// </summary>
    [CodedUITest]
    public class US016_RB
    {
        public US016_RB()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 016 D";
            Config.sPlanName = "QA US Benchmark 016 D Plan";
            //Config.sClientName = "QA US Benchmark 016";
            //Config.sPlanName = "QA US Benchmark 016 Plan";
            Config.sProductionVerison = "7.3";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);


        }

        #region Report Output Directory



        public string sOutputFunding_Val2013 = "";
        public string sOutputFunding_Val2014_Baseline = "";
        public string sOutputFunding_Val2014_FinalResults = "";

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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_016_At_Risk\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_Dallas";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_Val2013 = _gLib._CreateDirectory(sMainDir + "Val 2013\\" + sPostFix + "\\");
                sOutputFunding_Val2014_Baseline = _gLib._CreateDirectory(sMainDir + "Val 2014\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Val2014_FinalResults = _gLib._CreateDirectory(sMainDir + "Val 2014\\Final Results\\" + sPostFix + "\\");
                

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Val2013 = @\"" + sOutputFunding_Val2013 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Val2014_Baseline = @\"" + sOutputFunding_Val2014_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Val2014_FinalResults = @\"" + sOutputFunding_Val2014_FinalResults + "\";" + Environment.NewLine;
            

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
        public void test_US016_RB()
        {



            this.GenerateReportOuputDir();


            #region sOutputFunding_Val2013


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Val 2013");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Val 2013");



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
            dic.Add("Service", "BenefitService");
            dic.Add("Pay", "PensionEarningsPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Val 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Val 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);




            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Val2013, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Val2013, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Payout Projection", "Conversion", true, true);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Val2013, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Val2013, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2013, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2013, "Payout Projection", "Conversion", false, true);

            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Val 2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Val2014_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Val 2014");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Val 2014");


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
            dic.Add("GL_PPANAR_Max", "True");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "BenefitService");
            dic.Add("Pay", "PensionEarningsPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Val 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Val 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_Baseline, "Payout Projection", "RollForward", false, true);
            }

            



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Val 2014");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region sOutputFunding_Val2014_FinalResults



            pMain._SelectTab("Val 2014");


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
            dic.Add("Service", "BenefitService");
            dic.Add("Pay", "PensionEarningsPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
            dic.Add("FAS35PresentValueOfVestedBenefits", "True");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "True");
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



            pMain._SelectTab("Val 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Val 2014");



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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "ASC 960 reconciliation run completed.");
            dic.Add("OK", "");
            pMain._PopVerify_Home_Confrim(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "");
            dic.Add("No", "");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_Home_Confrim(dic);



            pMain._SelectTab("Val 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "ASC 960 Reconciliation", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Val2014_FinalResults, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Val2014_FinalResults, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Val2014_FinalResults, "ASC 960 Reconciliation", "RollForward", false, true);
            }




            pMain._SelectTab("Val 2014");

            pMain._GenerateNewReport(sOutputFunding_Val2014_FinalResults, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Val2014_FinalResults, "ASC 960 Letter", 3);



            pMain._SelectTab("Val 2014");
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
