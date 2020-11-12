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
    /// Summary description for US008_RB
    /// </summary>
    [CodedUITest]
    public class US008_RB
    {
        public US008_RB()
        {
 
            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            //Config.sClientName = "QA US Benchmark 008";
            //Config.sPlanName = "QA US Benchmark 008 Plan";
            Config.sClientName = "QA US Benchmark 008 D";
            Config.sPlanName = "QA US Benchmark 008 D Plan";
            Config.sProductionVerison = "7.4";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);



        }

        #region Report Output Directory



        public string sOutputFunding_Conversion2011_Baseline = "";
        public string sOutputFunding_Valuation2012_Baseline = "";
        public string sOutputFunding_Valuation2012_UpdateAssumptionDates = "";
        public string sOutputFunding_Valuation2012_ForAFN2012 = "";
        public string sOutputFunding_Valuation2012_ForAFTAPRange = "";
        public string sOutputFunding_Valuation2013_Baseline = "";
        public string sOutputFunding_Valuation2013_UpdateInterestAndMortality = "";
        public string sOutputFunding_Valuation2013_ForAFN2012 = "";
        public string sOutputFunding_ForAFTAPRangeTest_Baseline = "";
        public string sOutputAccounting_Conversion2011_Baseline = "";
        public string sOutputAccounting_FASVal2012_Baseline = "";


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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_008_PAUL_SCHERER\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                ////////
                sPostFix = sPostFix + "_Dallas";
                ///////

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Valuation2012_UpdateAssumptionDates = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\UpdateAssumptionDates\\" + sPostFix + "\\");
                sOutputFunding_Valuation2012_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFN2012\\" + sPostFix + "\\");
                sOutputFunding_Valuation2012_ForAFTAPRange = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2012\\ForAFTAPRange\\" + sPostFix + "\\");
                sOutputFunding_Valuation2013_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\Baseline\\" + sPostFix + "\\");
                sOutputFunding_Valuation2013_UpdateInterestAndMortality = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\UpdateInterestAndMortality\\" + sPostFix + "\\");
                sOutputFunding_Valuation2013_ForAFN2012 = _gLib._CreateDirectory(sMainDir + "Funding\\Valuation2013\\ForAFN2012\\" + sPostFix + "\\");
                sOutputFunding_ForAFTAPRangeTest_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\ForAFTAPRangeTest\\Baseline\\" + sPostFix + "\\");
                sOutputAccounting_Conversion2011_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Conversion2011\\Baseline\\" + sPostFix + "\\");
                sOutputAccounting_FASVal2012_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\FASVal2012\\Baseline\\" + sPostFix + "\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Conversion2011_Baseline = @\"" + sOutputFunding_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_Baseline = @\"" + sOutputFunding_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_UpdateAssumptionDates = @\"" + sOutputFunding_Valuation2012_UpdateAssumptionDates + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFN2012 = @\"" + sOutputFunding_Valuation2012_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2012_ForAFTAPRange = @\"" + sOutputFunding_Valuation2012_ForAFTAPRange + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_Baseline = @\"" + sOutputFunding_Valuation2013_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_UpdateInterestAndMortality = @\"" + sOutputFunding_Valuation2013_UpdateInterestAndMortality + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2013_ForAFN2012 = @\"" + sOutputFunding_Valuation2013_ForAFN2012 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_ForAFTAPRangeTest_Baseline = @\"" + sOutputFunding_ForAFTAPRangeTest_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Conversion2011_Baseline = @\"" + sOutputAccounting_Conversion2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_FASVal2012_Baseline = @\"" + sOutputAccounting_FASVal2012_Baseline + "\";" + Environment.NewLine;

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
        public void test_US008_RB()
        {



            this.GenerateReportOuputDir();


            #region   sOutputFunding_Conversion2011_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "False");
            dic.Add("PPAAtRiskLiabilityForMaximum", "False");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


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

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", false, true);

                ////////pOutputManager._ts_DrillDown_ALL(sOutputFunding_Conversion2011_Baseline, dic);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Valuation2012_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
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
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Data Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Liability Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_Baseline, "Payout Projection", "RollForward", false, true);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region  sOutputFunding_Valuation2012_UpdateAssumptionDates

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");

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


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", false, true);
            }


            pMain._SelectTab("Valuation 2012");

            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Letter", 3);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region  sOutputFunding_Valuation2012_ForAFN2012


            pMain._SelectTab("Valuation 2012");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results", "RollForward", true, true);

            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFN2012, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region  sOutputFunding_Valuation2012_ForAFTAPRange

            pMain._SelectTab("Valuation 2012");


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
            dic.Add("EstimateNextYearLiabilityForAFTAP", "True");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "True");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("EntryAgeNormal", "False");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_ForAFTAPRange, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_ForAFTAPRange, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario by Plan Def", "RollForward", false, true);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sOutputFunding_Valuation2013_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2013");
            pMain._PopVerify_Home_RightPane(dic);



            pMain._SelectTab("Valuation 2013");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Data Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_Baseline, "Liability Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_Baseline, "Payout Projection", "RollForward", false, true);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputFunding_Valuation2013_UpdateInterestAndMortality



            pMain._SelectTab("Valuation 2013");

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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
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
            dic.Add("PPAAtRiskLiabilityForMinimum", "");
            dic.Add("PPAAtRiskLiabilityForMaximum", "");
            dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "");
            dic.Add("EntryAgeNormal", "");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Valuation 2013");

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


            pMain._SelectTab("Valuation 2013");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "Click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "Click");
            dic.Add("AddAll", "Click");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "HourlyFlag");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);




            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Reconciliation", "RollForward", false, true);

            }

            pMain._SelectTab("Valuation 2013");

            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_Valuation2013_UpdateInterestAndMortality, "ASC 960 Letter", 3);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputFunding_Valuation2013_ForAFN2012


            pMain._SelectTab("Valuation 2013");


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
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "False");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2013");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Output Manager");


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_Valuation2013_ForAFN2012, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_Valuation2013_ForAFN2012, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            pMain._SelectTab("Valuation 2013");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputFunding_ForAFTAPRangeTest_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "For AFTAP Range Test");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("For AFTAP Range Test");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
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
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(sOutputFunding_ForAFTAPRangeTest_Baseline, "Funding Calculator", "RollForward", false, true);



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("For AFTAP Range Test");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputAccounting_Conversion2011_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


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

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_Conversion2011_Baseline, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_Conversion2011_Baseline, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Conversion 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region sOutputAccounting_FASVal2012_Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "FAS Val 2012");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("FAS Val 2012");

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
            dic.Add("Acc_GL_ABO", "True");
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "VestingService");
            dic.Add("Pay", "PayProjection1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "BenefitInPayment");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("FAS Val 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Test Cases", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
            }
            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Checking Template", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Data Comparison", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Decrement Age", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_FASVal2012_Baseline, "Liability Comparison", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_FASVal2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_FASVal2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("FAS Val 2012");
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
