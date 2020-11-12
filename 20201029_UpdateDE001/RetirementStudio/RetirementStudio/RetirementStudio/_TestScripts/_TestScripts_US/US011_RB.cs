using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Threading;


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
using RetirementStudio._UIMaps.FAEFormulaClasses;
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
using RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.LateRetirementFactorsClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
using System.IO;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.SocialSecurityPIAFormulaClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;

using RetirementStudio._UIMaps.FundingInformation_PYR_SummaryViewClasses;


namespace RetirementStudio._TestScripts._TestScripts_US
{
    /// <summary>
    /// Summary description for US011_RB_Update
    /// </summary>
    [CodedUITest]
    public class US011_RB
    {
        public US011_RB()
        {

            Config.eEnv = _TestingEnv.Prod_US;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 011";
            Config.sPlanName = "QA US Benchmark 011 Plan";
            //Config.sClientName = "QA US Benchmark 011 D";
            //Config.sPlanName = "QA US Benchmark 011 D Plan";
            Config.sProductionVerison = "7.4";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = false;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

        }
        

        #region Report Output Directory


        public string sOutputFunding_val2017 = "";
        public string sOutputFunding_val2018_Baseline = "";
        public string sOutputFunding_val2018_UpdateAssumptionsfor2018 = "";
        public string sOutputFunding_val2018_PlanAmendment = "";
        public string sOutputFunding_val2018_ForAFTAP = "";
        public string sOutputFunding_valJuly2019_Baseline = "";
        public string sOutputFunding_valJuly2019_UpdateAssumptions = "";
        public string sOutputFunding_valJuly2019_UpdateProvisions = "";
        public string sOutputFunding_valJuly2019_AFTAP = "";
        public string sOutputAccounting_July2017FASVal = "";
        public string sOutputAccounting_July2018FASVal_Baseline = "";
        public string sOutputAccounting_July2018FASVal_UpdateAssumptions = "";
        public string sOutputAccounting_July2018FASVal_UpdateCashBalance = "";

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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\";
                    string sPostFix = Config.sProductionVerison + "_" + _gLib._ReturnDateStampYYYYMMDD();


                    sPostFix = sPostFix + "_Franklin";


                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_val2017 = _gLib._CreateDirectory(sMainDir + "val 2017\\" + sPostFix + "\\");
                    sOutputFunding_val2018_Baseline = _gLib._CreateDirectory(sMainDir + "val 2018\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_val2018_UpdateAssumptionsfor2018 = _gLib._CreateDirectory(sMainDir + "val 2018\\Update assumptions for 2018\\" + sPostFix + "\\");
                    sOutputFunding_val2018_PlanAmendment = _gLib._CreateDirectory(sMainDir + "val 2018\\Plan amendment\\" + sPostFix + "\\");
                    sOutputFunding_val2018_ForAFTAP = _gLib._CreateDirectory(sMainDir + "val 2018\\For AFTAP\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_Baseline = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_UpdateAssumptions = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update assumptions for 2019\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_UpdateProvisions = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update provisions for 2019\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_AFTAP = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\AFTAP\\" + sPostFix + "\\");
                    sOutputAccounting_July2017FASVal = _gLib._CreateDirectory(sMainDir + "July 2017 FAS Val\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_Baseline = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_UpdateAssumptions = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Update Assumptions\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_UpdateCashBalance = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Update Cash Balance\\" + sPostFix + "\\");

                }

            }
          
            string sContent = "";
            sContent = sContent + "sOutputFunding_val2017 = @\"" + sOutputFunding_val2017 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_Baseline = @\"" + sOutputFunding_val2018_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_UpdateAssumptionsfor2018 = @\"" + sOutputFunding_val2018_UpdateAssumptionsfor2018 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_PlanAmendment = @\"" + sOutputFunding_val2018_PlanAmendment + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_ForAFTAP = @\"" + sOutputFunding_val2018_ForAFTAP + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_Baseline = @\"" + sOutputFunding_valJuly2019_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_UpdateAssumptions = @\"" + sOutputFunding_valJuly2019_UpdateAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_UpdateProvisions = @\"" + sOutputFunding_valJuly2019_UpdateProvisions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_AFTAP = @\"" + sOutputFunding_valJuly2019_AFTAP + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2017FASVal = @\"" + sOutputAccounting_July2017FASVal + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_Baseline = @\"" + sOutputAccounting_July2018FASVal_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_UpdateAssumptions = @\"" + sOutputAccounting_July2018FASVal_UpdateAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_UpdateCashBalance = @\"" + sOutputAccounting_July2018FASVal_UpdateCashBalance + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public CashBalance pCashBalance = new CashBalance();
        public SocialSecurityCoveredCompFormula pSocialSecurityCoveredCompFormula = new SocialSecurityCoveredCompFormula();
        public PayCredit pPayCredit = new PayCredit();
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
        public Eligibilities pEligibilities = new Eligibilities();
        public SpecialEligibilities pSpecialEligibilities = new SpecialEligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public FAEFormula pFAEFormula = new FAEFormula();
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
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public LateRetirementFactors pLateRetirementFactors = new LateRetirementFactors();
        public Adjustments pAdjustments = new Adjustments();
        public BenefitElections pBenefitElections = new BenefitElections();
        public SocialSecurityPIAFormula pSocialSecurityPIAFormula = new SocialSecurityPIAFormula();
        public UnitFormula pUnitFormula = new UnitFormula();
        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();

        public FundingInformation_PYR_SummaryView pFundingInformation_PYR_SummaryView = new FundingInformation_PYR_SummaryView();

        #endregion


        [TestMethod]
        public void test_US011_RB()
        {

           

 
            this.GenerateReportOuputDir();

            #region Update for 2017

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Update for 2017");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Update for 2017");

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
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "CBal");
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

            pMain._SelectTab("Update for 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);


            pMain._SelectTab("Update for 2017");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Valuation Summary", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_val2017, "Liability Summary", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_val2017, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Payout Projection", "Conversion", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_val2017, "Liability Summary", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_val2017, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2017, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2017, "Payout Projection", "Conversion", false, true);

            }
  
            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Update for 2017");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region val 2018 Baseline node

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "val 2018");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("val 2018");

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
            dic.Add("IncludeGainLossResult", "False");
            dic.Add("IncludeGainLossAgeGroupReportFields", "True");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "Cbal");
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


            pMain._EnterpriseRun("Group Job Successfully Complete with 2 NP", true);


            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Payout Projection", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_Baseline, "Payout Projection", "RollForward", false, true);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region val 2018 - update assumptions for 2018

            pMain._SelectTab("val 2018");

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
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "Cbal");
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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 2018");

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
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region val 2018 - plan amendment

            pMain._SelectTab("val 2018");

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
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "Cbal");
            dic.Add("Pension", "Benefit1DB");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 2018");

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

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
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
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Funding Calculator Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_PlanAmendment, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Funding Calculator Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_PlanAmendment, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_PlanAmendment, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_PlanAmendment, "Funding Calculator", "RollForward", false, true);

            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region val 2018 - for AFTAP

            pMain._SelectTab("val 2018");

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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "CBal");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "False");
            dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
            dic.Add("PPANotAtRiskLiabilityForMaximum", "False");
            dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "False");
            dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "False");
            dic.Add("FAS35PresentValueOfAccumulatedBenefits", "False");
            dic.Add("FAS35PresentValueOfVestedBenefits", "False");
            dic.Add("PPAAtRiskLiabilityForMinimum", "True");
            dic.Add("PPAAtRiskLiabilityForMaximum", "False");
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

            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Valuation Summary", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Liability Scenario", "RollForward", true, true);

                ////////////////pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Individual Output", "RollForward", true, true);
                ////////////////pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Reconciliation to Baseline", "RollForward", true, true);
            }

            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_val2018_ForAFTAP, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_val2018_ForAFTAP, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_val2018_ForAFTAP, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);

            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region val 7.1.2019 - Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "val 7.1.2019");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("GL_PPANAR_Min", "true");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "CBal");
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

            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Valuation Summary", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Data Matching Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Combined Status Code Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Decrement Age", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Payout Projection", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Data Comparison", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Data Matching Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Combined Status Code Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Decrement Age", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_Baseline, "Payout Projection", "RollForward", false, true);
            }

            pMain._SelectTab("val 7.1.2019");

            pMain._GenerateNewReport(sOutputFunding_valJuly2019_Baseline, "Report Appendices", 2);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region val 7.1.2019 - update assumptions for 2019

            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("Pay", "SalProj");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "Cbal");
            dic.Add("Pension", "Benefit1DB");
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
            dic.Add("PayoutProjectionCustomGroup", "DivisionCode");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 7.1.2019");

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

            pMain._SelectTab("val 7.1.2019");

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

            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "ASC 960 Reconciliation", "RollForward", true, true);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Funding Calculator Scenario", "RollForward", false, true);

                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateAssumptions, "Funding Calculator", "RollForward", false, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateAssumptions, "ASC 960 Reconciliation", "RollForward", false, true);

            }


            pMain._SelectTab("val 7.1.2019");
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateAssumptions, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateAssumptions, "ASC 960 Letter", 3);

            pMain._SelectTab("val 7.1.2019");
            pMain._Home_ToolbarClick_Top(true);
 
            #endregion

            #region val 7.1.2019 - update provisions for 2019

              pMain._SelectTab("val 7.1.2019");

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
                dic.Add("Pay", "SalProj");
                dic.Add("CurrentYear", "True");
                dic.Add("PriorYear", "");
                dic.Add("CashBanlance", "CBal");
                dic.Add("Pension", "Benefit1DB");
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

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "4");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);

                pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

                pMain._SelectTab("val 7.1.2019");

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

                pMain._SelectTab("val 7.1.2019");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "4");
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

                pMain._SelectTab("val 7.1.2019");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "4");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);


                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Parameter Print", "RollForward", true, true);
                pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", true, true);


                if (Config.bDownloadReports_PDF)
                {
               
                 pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario", "RollForward", true, true);
                    ////////////////pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", true, true);
                    pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Individual Output", "RollForward", true, true);
                    ////////////////pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Parameter Print", "RollForward", true, true);
                    pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Payout Projection", "RollForward", true, true);
                    pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results", "RollForward", true, true);
                    pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline", "RollForward", true, true);
                }

                if (Config.bDownloadReports_EXCEL)
                {
                    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario by Plan Def", "RollForward", false, true);
                    pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", false, true);
                    pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Individual Output", "RollForward", false, true);
                    pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "IOE", "RollForward", false, true);
                    pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_UpdateProvisions, "Payout Projection", "RollForward", false, true);
                    pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results", "RollForward", false, true);
                    pOutputManager._ExportReport_Common(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline", "RollForward", false, true);
                    pOutputManager._ExportReport_SubReports(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                    pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "ASC 960 Reconciliation", "RollForward", false, true);

                    pMain._SelectTab("val 7.1.2019");

                    pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "PPA Funding Valuation Report", 4);
                    pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "AFTAP Certification", 4);
                    pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "Annual Funding Notice", 4);
                    pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "ASC 960 Letter", 4);
                    pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "Schedule SB Attachments", 4);

                    pMain._SelectTab("Output Manager");
                    pMain._Home_ToolbarClick_Top(true);
                    pMain._Home_ToolbarClick_Top(false);

                    pMain._SelectTab("val 7.1.2019");
                    pMain._Home_ToolbarClick_Top(true);
                    pMain._Home_ToolbarClick_Top(false);

                }

            #endregion

            #region val 7.1.2019 - AFTAP


                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "2");
                dic.Add("iSelectRowNum", "3");
                dic.Add("iSelectColNum", "2");
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

                pMain._SelectTab("val 7.1.2019");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "2");
                dic.Add("iSelectRowNum", "3");
                dic.Add("iSelectColNum", "2");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                pOutputManager._ExportReport_Others(sOutputFunding_valJuly2019_AFTAP, "Funding Calculator", "RollForward", false, true);


                pMain._SelectTab("Output Manager");
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);

                pMain._SelectTab("AFTAP");
                pMain._GenerateNewReport(sOutputFunding_valJuly2019_AFTAP, "AFTAP Range Certification", 3);

                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Acconting - July 2017 FAS Val


                pMain._SelectTab("Home");

                dic.Clear();
                dic.Add("Level_1", Config.sClientName);
                dic.Add("Level_2", Config.sPlanName);
                dic.Add("Level_3", "AccontingValuations");
                pMain._HomeTreeViewSelect_Favorites(0, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", "July 2017 FAS Val");
                pMain._PopVerify_Home_RightPane(dic);

                pMain._SelectTab("July 2017 FAS Val");

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
                dic.Add("Pay", "SalProj");
                dic.Add("CurrentYear", "True");
                dic.Add("PriorYear", "");
                dic.Add("CashBanlance", "Cbal");
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

                pMain._SelectTab("July 2017 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "1");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete with 7 NP", true);

                pMain._SelectTab("July 2017 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "1");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                if (Config.bDownloadReports_PDF)
                {
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Liability Summary", "Conversion", true, false);
                    pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2017FASVal, "Liability Summary", "Conversion", true, false, 0);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Member Statistics", "Conversion", true, false);
                    pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2017FASVal, "Conversion Diagnostic", "Conversion", true, false, 0);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Conversion Diagnostic", "Conversion", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Test Case List", "Conversion", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Detailed Results", "Conversion", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Valuation Summary", "Conversion", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Individual Output", "Conversion", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Parameter Print", "Conversion", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Test Cases", "Conversion", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Payout Projection", "Conversion", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "FAS Expected Benefit Pmts", "Conversion", true, false);
                }

                if (Config.bDownloadReports_EXCEL)
                {
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Liability Summary", "Conversion", false, false);
                    pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2017FASVal, "Liability Summary", "Conversion", false, false, 0);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Member Statistics", "Conversion", false, false);
                    pOutputManager._ExportReport_DrillDown(sOutputAccounting_July2017FASVal, "Conversion Diagnostic", "Conversion", false, false, 0);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Conversion Diagnostic", "Conversion", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Test Case List", "Conversion", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Detailed Results", "Conversion", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Detailed Results by Plan Def", "Conversion", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "Valuation Summary", "Conversion", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Individual Output", "Conversion", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "IOE", "Conversion", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2017FASVal, "Payout Projection", "Conversion", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2017FASVal, "FAS Expected Benefit Pmts", "Conversion", false, false);
                }

                pMain._SelectTab("July 2017 FAS Val");
                pMain._Home_ToolbarClick_Top(true);
                pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region Accounting - July 2018 FAS Val -Baseline node

                pMain._SelectTab("Home");

                dic.Clear();
                dic.Add("Level_1", Config.sClientName);
                dic.Add("Level_2", Config.sPlanName);
                dic.Add("Level_3", "AccountingValuations");
                pMain._HomeTreeViewSelect(0, dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AddServiceInstance", "");
                dic.Add("ServiceToOpen", "July 2018 FAS Val");
                pMain._PopVerify_Home_RightPane(dic);

                pMain._SelectTab("July 2018 FAS Val");

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
                dic.Add("Acc_GL_ABO", "True");
                dic.Add("GL_PPANAR_Min", "");
                dic.Add("GL_PPANAR_Max", "");
                dic.Add("GL_EAN", "");
                dic.Add("EstimateNextYearLiabilityForAFTAP", "");
                dic.Add("PayoutProjection", "True");
                dic.Add("IncludeIOE", "True");
                dic.Add("GenerateParameterPrint", "True");
                dic.Add("GenerateTestCaseOutput", "True");
                dic.Add("IncludeGainLossResult", "True");
                dic.Add("Service", "CreditedService");
                dic.Add("Pay", "SalProj");
                dic.Add("CurrentYear", "True");
                dic.Add("PriorYear", "");
                dic.Add("CashBanlance", "Cbal");
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

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete with 2 NP", true);

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "2");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RemoveAll", "");
                dic.Add("AddAll", "Click");
                dic.Add("Node", "");
                dic.Add("Add", "");
                dic.Add("ShowSubtotalBreaks", "");
                dic.Add("OK", "Click");
                pOutputManager._PopVerify_OutputManagerSetup(dic);

                if (Config.bDownloadReports_PDF)
                {
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Reconciliation to Prior Year", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Detailed Results", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Status Reconciliation", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Member Statistics", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Individual Checking Template", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Age Service Matrix", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Data Matching Summary", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Combined Status Code Summary", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Status Reconciliation", "RollForward", true, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", true, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Decrement Age", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Valuation Summary", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Individual Output", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Parameter Print", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Test Cases", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Payout Projection", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Liability Set for Globe Export", "RollForward", true, false);
                }

                if (Config.bDownloadReports_EXCEL)
                {
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Detailed Results", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Status Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Member Statistics", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Individual Checking Template", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Age Service Matrix", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Data Matching Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Combined Status Code Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Decrement Age", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "Valuation Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Individual Output", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "IOE", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Payout Projection", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_Baseline, "Liability Set for Globe Export", "RollForward", false, false);
                }

                pMain._SelectTab("July 2018 FAS Val");
                pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Accounting - July 2018 FAS Val - update assumptions

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "3");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "3");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                if (Config.bDownloadReports_PDF)
                {
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Valuation Summary", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Individual Output", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Parameter Print", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Test Cases", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Payout Projection", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "FAS Expected Benefit Pmts", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", true, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", true, false);
                }

                if (Config.bDownloadReports_EXCEL)
                {
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Valuation Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Individual Output", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "IOE", "Conversion", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Payout Projection", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "FAS Expected Benefit Pmts", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);

                }

                pMain._SelectTab("July 2018 FAS Val");
                pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Acconting - July 2018 FAS Val - update cash balance

                pMain._SelectTab("July 2018 FAS Val");

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
                dic.Add("Service", "CreditedService");
                dic.Add("Pay", "SalProj");
                dic.Add("CurrentYear", "True");
                dic.Add("PriorYear", "");
                dic.Add("CashBanlance", "Cbal");
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

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "4");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Run Status");
                pMain._FlowTreeRightSelect(dic);


                pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

                pMain._SelectTab("July 2018 FAS Val");

                dic.Clear();
                dic.Add("iMaxRowNum", "");
                dic.Add("iMaxColNum", "");
                dic.Add("iSelectRowNum", "4");
                dic.Add("iSelectColNum", "1");
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("RemoveAll", "");
                dic.Add("AddAll", "");
                dic.Add("Node", "");
                dic.Add("Add", "");
                dic.Add("ShowSubtotalBreaks", "");
                dic.Add("OK", "");
                pOutputManager._PopVerify_OutputManagerSetup(dic);

                pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Parameter Print", "RollForward", true, false);

                if (Config.bDownloadReports_PDF)
                {
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Valuation Summary", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Individual Output", "RollForward", true, false);
                    //pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Parameter Print", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Test Cases", "RollForward", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Payout Projection", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "FAS Expected Benefit Pmts", "RollForward", true, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results", "Conversion", true, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Set for Globe Export", "RollForward", true, false);

                }

                if (Config.bDownloadReports_EXCEL)
                {
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario by Plan Def", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Valuation Summary", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Individual Output", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "IOE", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Payout Projection", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "FAS Expected Benefit Pmts", "RollForward", false, false);
                    pOutputManager._ExportReport_Others(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Set for Globe Export", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results", "RollForward", false, false);
                    pOutputManager._ExportReport_Common(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline", "RollForward", false, false);
                    pOutputManager._ExportReport_SubReports(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);

                }

                pMain._SelectTab("Output Manager");
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
