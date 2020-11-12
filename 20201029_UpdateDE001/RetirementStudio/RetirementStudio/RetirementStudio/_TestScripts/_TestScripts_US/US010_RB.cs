﻿using System;
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
    /// Summary description for US010_RB
    /// </summary>
    [CodedUITest]
    public class US010_RB
    {
        public US010_RB()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 010";
            Config.sPlanName = "QA US Benchmark 010 Plan";
            Config.sProductionVerison = "6.3";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);


        }

        #region Report Output Directory



        public string sOutputFunding_July2006Valuation = "";
        public string sOutputFunding_July2007Valuation = "";
        public string sOutputAccounting_July2006FASVal = "";
        public string sOutputAccounting_July2007FASVal = "";


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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_010_Drummond\Production\";
                string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();

                sPostFix = sPostFix + "_Franklin";

                _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputFunding_July2006Valuation = _gLib._CreateDirectory(sMainDir + "July 2006 Valuation\\" + sPostFix + "\\");
                sOutputFunding_July2007Valuation = _gLib._CreateDirectory(sMainDir + "July 2007 Valuation\\" + sPostFix + "\\");
                sOutputAccounting_July2006FASVal = _gLib._CreateDirectory(sMainDir + "July 2006 FAS Val\\" + sPostFix + "\\");
                sOutputAccounting_July2007FASVal = _gLib._CreateDirectory(sMainDir + "July 2007 FAS Val\\" + sPostFix + "\\");

            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_July2006Valuation = @\"" + sOutputFunding_July2006Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_July2007Valuation = @\"" + sOutputFunding_July2007Valuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2006FASVal = @\"" + sOutputAccounting_July2006FASVal + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2007FASVal = @\"" + sOutputAccounting_July2007FASVal + "\";" + Environment.NewLine;

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
        public void test_US010_RB()
        {

  

            this.GenerateReportOuputDir();

            #region sOutputFunding_July2006Valuation


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2006 Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("July 2006 Valuation");


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
            dic.Add("Service", "CreditedService");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Beneficiary1Percent1");
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
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("July 2006 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_July2006Valuation, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Parameter Print", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_July2006Valuation, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_July2006Valuation, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2006Valuation, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2006Valuation, "Payout Projection", "Conversion", false, true);

            }




            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2006 Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sOutputFunding_July2007Valuation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 Valuation");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("July 2007 Valuation");


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
            dic.Add("Pay", "N/A");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("July 2007 Valuation");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_July2007Valuation, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_July2007Valuation, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_July2007Valuation, "Payout Projection", "RollForward", false, true);
            }



            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2007 Valuation");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #region sOutputAccounting_July2006FASVal


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2006 FAS Val");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("July 2006 FAS Val");

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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("July 2006 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Valuation Summary", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Parameter Print", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Test Cases", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2006FASVal, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2006FASVal, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2006FASVal, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2006 FAS Val");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion


            #region sOutputAccounting_July2007FASVal


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2007 FAS Val");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("July 2007 FAS Val");

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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "N/A");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

             if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Detailed Results", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Member Statistics", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Individual Checking Template", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Data Matching Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Combined Status Code Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Gain / Loss Status Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Decrement Age", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Valuation Summary", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Individual Output", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Parameter Print", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Test Cases", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Payout Projection", "RollForward", true, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "FAS Expected Benefit Pmts", "RollForward", true, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Liability Set for Globe Export", "RollForward", true, false);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Detailed Results", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Detailed Results by Plan Def", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Member Statistics", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Individual Checking Template", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Age Service Matrix", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Data Matching Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Combined Status Code Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Decrement Age", "RollForward", false, false);
                pOutputManager._ExportReport_SubReports(sOutputAccounting_July2007FASVal, "Gain / Loss Participant Listing", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "Valuation Summary", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Individual Output", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "IOE", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Payout Projection", "RollForward", false, false);
                pOutputManager._ExportReport_Common(sOutputAccounting_July2007FASVal, "FAS Expected Benefit Pmts", "RollForward", false, false);
                pOutputManager._ExportReport_Others(sOutputAccounting_July2007FASVal, "Liability Set for Globe Export", "RollForward", false, false);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("July 2007 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputAccounting_July2007FASVal);


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