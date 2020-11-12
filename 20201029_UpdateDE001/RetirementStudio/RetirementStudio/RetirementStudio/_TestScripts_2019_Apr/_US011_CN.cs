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
using RetirementStudio._UIMaps.ASC960ReconciliationClasses;
using RetirementStudio._UIMaps.AnnualFundingNoticeClasses;
using RetirementStudio._UIMaps.FundingInformation_ASOP51Classes;



namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for _US011_CN
    /// </summary>
    [CodedUITest]
    public class _US011_CN
    {
        public _US011_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 011 Existing DNT";
            Config.sPlanName = "QA US Benchmark 011 Existing DNT Plan";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

            //_gLib._Report(_PassFailStep.Header, "Testing Starts at: " + DateTime.Now + "\t" + Environment.UserName);

            //////_gLib._MsgBox("Warning!", "If you are running Existing or Re-opened Studio after crash, Please manually select the Client in Studio-> Home -> All Services -> "
            //////    + Config.sClientName + Environment.NewLine + Environment.NewLine + "If you are running CreateNew without any crash, Please ignore this msg!"
            //////    + Environment.NewLine + Environment.NewLine + "Click OK to keep testing!");

        }



        #region Report Output Directory



        public string sOutputFunding_valJuly2019_UpdateProvisions = "";
        public string sOutputFunding_valJuly2019_updateFIForASOP51 = "";
        public string sOutputAccounting_July2018FASVal_UpdateCashBalance = "";

        public string sOutputFunding_valJuly2019_UpdateProvisions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\update provisions for 2019\7.4_20190411_Franklin\";
        public string sOutputFunding_valJuly2019_updateFIForASOP51_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\update FI for ASOP 51\7.4_20190611_Franklin\";
        public string sOutputAccounting_July2018FASVal_UpdateCashBalance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\July 2018 FAS Val\Update Cash Balance\7.4_20190411_Franklin\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_valJuly2019_UpdateProvisions = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update provisions for 2019\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_updateFIForASOP51 = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update FI for ASOP 51\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_UpdateCashBalance = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Update Cash Balance\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "US011_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_valJuly2019_UpdateProvisions = _gLib._CreateDirectory(sMainDir + "\\val 7.1.2019\\update provisions for 2019\\");
                sOutputFunding_valJuly2019_updateFIForASOP51 = _gLib._CreateDirectory(sMainDir + "\\val 7.1.2019\\update FI for ASOP 51\\");
                sOutputAccounting_July2018FASVal_UpdateCashBalance = _gLib._CreateDirectory(sMainDir + "\\Accounting_July2018FASVal\\Update Cash Balance\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_valJuly2019_UpdateProvisions = @\"" + sOutputFunding_valJuly2019_UpdateProvisions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_updateFIForASOP51 = @\"" + sOutputFunding_valJuly2019_updateFIForASOP51 + "\";" + Environment.NewLine;
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
        public AnnualFundingNotice pAnnualFundingNotice = new AnnualFundingNotice();
        public ASC960Reconciliation pASC960Reconciliation = new ASC960Reconciliation();
        public FundingInformation_ASOP51 pFundingInformation_ASOP51 = new FundingInformation_ASOP51();

        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _Test_US011_CN()
        {

            #region MultiThreads


            Thread thrd_Funding_valJuly2019_UpdateProvisions = new Thread(() => new _US011_CN().t_CompareRpt_Funding_valJuly2019_UpdateProvisions(sOutputFunding_valJuly2019_UpdateProvisions));
   

            #endregion

            string sVal2019Node_UpdateProvisionsFor2019 = "updateprovisionsFor2019-" + _gLib._ReturnDateStampYYYYMMDD();
            string sVal2019Node_UpdateFIForASOP51 = "updateFIForASOP51-" + _gLib._ReturnDateStampYYYYMMDD();
            string sAcc2018Node_UpdateCashBalance = "updatecashbalance-" + _gLib._ReturnDateStampYYYYMMDD();
     
            this.GenerateReportOuputDir();

            #region val 7.1.2019 - update provisions for 2019

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

            _gLib._MsgBoxYesNo("Manual", "Right click \"update assumptions for 2019\" Node and select <Add Valuation Node>");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sVal2019Node_UpdateProvisionsFor2019);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._ValuationNodeProperties_ChangeReasons_Initialize();

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in plan provisions");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Provisions> - <Edit Parameters>");


            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "LumpSumActEq");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "05/01/2018");
            pInterestRate._PopVerify_PrescribedRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "PPA2019CMF");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Run - Liabilities>");


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

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <View Run Status>");


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Funding Information> - <Edit Parameters>");


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Annual Funding Notice> - <Edit Parameters>");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Annual Funding Notice");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Annual Funding Notice");
            dic.Add("Level_2", "End of Notice Year");
            pAnnualFundingNotice._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("YearOfFundingService", "");
            dic.Add("YearBeforeFundingService", "true");
            pAnnualFundingNotice._PopVerify_EndOfNoticeYear(dic);

            dic.Clear();
            dic.Add("Level_1", "Annual Funding Notice");
            dic.Add("Level_2", "Policies");
            pAnnualFundingNotice._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TheFundingPolicyOfThePlanIs", "to contribute at least the minimum but no more than the unfunded ABO.");
            dic.Add("TheInvestmentPolicyOfThePlanIs", "create a diversified portfolio bond favorable.");
            dic.Add("Cash", "5.00");
            dic.Add("USGovSecurities", "15.00");
            dic.Add("PreferredCorpDebtInstruments", "5.00");
            dic.Add("AllOtherCorpDebtInstruments", "45.00");
            dic.Add("PreferredCorpStocks", "5.00");
            dic.Add("CommonCorpStocks", "5.00");
            dic.Add("PartnershipJointVentureInterests", "15.00");
            dic.Add("RealEstate", "5.00");
            dic.Add("EmployerSecurities", "5.00");
            pAnnualFundingNotice._PopVerify_Policies(dic);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Run - Funding Calculations>");


            ////dic.Clear();
            ////dic.Add("iMaxRowNum", "");
            ////dic.Add("iMaxColNum", "");
            ////dic.Add("iSelectRowNum", "2");
            ////dic.Add("iSelectColNum", "1");
            ////dic.Add("MenuItem_1", "Run");
            ////dic.Add("MenuItem_2", "Funding Calculations");
            ////pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted(dic);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Run - ASC 960 Reconciliation>");


            ////dic.Clear();
            ////dic.Add("iMaxRowNum", "");
            ////dic.Add("iMaxColNum", "");
            ////dic.Add("iSelectRowNum", "2");
            ////dic.Add("iSelectColNum", "1");
            ////dic.Add("MenuItem_1", "Run");
            ////dic.Add("MenuItem_2", "ASC 960 Reconciliation");
            ////pMain._FlowTreeRightSelect(dic);

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


            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <View Output>");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", true, true);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Funding Calculator", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "ASC 960 Reconciliation", "RollForward", false, true);

            pMain._SelectTab("val 7.1.2019");

            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "PPA Funding Valuation Report", 4);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "AFTAP Certification", 4);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "Annual Funding Notice", 4);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "ASC 960 Letter", 4);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateProvisions, "Schedule SB Attachments", 4);


            thrd_Funding_valJuly2019_UpdateProvisions.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
            pMain._SelectTab("val 7.1.2019");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Val 7.1.2019 - update FI for ASOP 51

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click  Node <" + sVal2019Node_UpdateProvisionsFor2019 + "> and select <Add Valuation Node>");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sVal2019Node_UpdateFIForASOP51);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "True");
            dic.Add("FundingInformation_AddNew", "True");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateFIForASOP51 + "> and select <Run - Liabilities>");

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

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateFIForASOP51 + "> and select <View Run Status>");

            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateFIForASOP51 + "> and select <Funding Information> - <Edit Parameters>");


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "ASOP 51 History");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfYears", "15");
            dic.Add("LoadHistory", "click");
            pFundingInformation_ASOP51._ASOP51_History(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\US011\ASOP51HistoryLoad_QAUS11.xlsx");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "ASOP 51 Current Year");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("USGovernmentSecurities_label", "Govt Bonds");
            dic.Add("USGovernmentSecurities_txt", "6.15");
            dic.Add("CorporateDebt_label", "Bonds");
            dic.Add("CorporateDebt_txt", "47.24");
            dic.Add("CorporateStocks_label", "Stocks");
            dic.Add("CorporateStocks_txt", "12.96");
            dic.Add("HedgeFunds_label", "Munis");
            dic.Add("HedgeFunds_txt", "7.98");
            dic.Add("RealEstate_label", "Hedge funds");
            dic.Add("RealEstate_txt", "15.66");
            dic.Add("Cash_label", "");
            dic.Add("Cash_txt", "10.57");
            dic.Add("Other_label", "All Other");
            dic.Add("Other_txt", "");
            dic.Add("UserDefined1_label", "DefinedB");
            dic.Add("UserDefined1_txt", "1,500.0000");
            dic.Add("UserDefined2_label", "averages");
            dic.Add("UserDefined2_txt", "1,222,000.0000");
            dic.Add("UserDefined3_label", "values");
            dic.Add("UserDefined3_txt", "15.1200");
            dic.Add("UserDefined4_label", "notice");
            dic.Add("UserDefined4_txt", "0.1350");
            dic.Add("UserDefined5_label", "itemA");
            dic.Add("UserDefined5_txt", "11,882,234.0000");
            dic.Add("AnnuityBenefitPayments_label", "Annuities");
            dic.Add("AnnuityBenefitPayments_txt", "250,000");
            dic.Add("LumpSumBenefitPayments_label", "Active CashOuts");
            dic.Add("LumpSumBenefitPayments_txt", "150,000");
            dic.Add("AnnuityBuyouts_label", "TV CashOuts");
            dic.Add("AnnuityBuyouts_txt", "12,000");
            pFundingInformation_ASOP51._ASOP51_currentYear(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "ASOP 51 Risk Assessments");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RiskAccessments", "Just type something about risk assessment here. Whatever is typed should remain in the roll forward for next year.");
            dic.Add("InvestmentRisk", "First economic risk is not so bad.");
            dic.Add("InterestRateRisk", "Second economic risk should be reviewed in more detail.");
            dic.Add("AssetLiabilityMismatchRisk", "This one should be included year after year ");
            dic.Add("LumpSumRisk", "You just need to type the same info from each of these boxes into the QA sites to ensure the data entered is saved year after year.");
            dic.Add("OtherEconomicRisk_label", "New label");
            dic.Add("OtherEconomicRisk", "You can type whatever you feel like in this one – just checking that is stays as is");
            dic.Add("LongevityRisk", "Demo risk number one");
            dic.Add("RetirementRisk", "Demo risk number two");
            dic.Add("OtherDemographicRisk_label", "Old label");
            dic.Add("OtherDemographicRisk", "Just keep typing something");
            dic.Add("MaturityMeasures_1_label", "Measure 1");
            dic.Add("MaturityMeasures_1", "This is measure one");
            dic.Add("MaturityMeasures_2_label", "Label B");
            dic.Add("MaturityMeasures_2", "This is measure two");
            dic.Add("MaturityMeasures_3_label", "Mat label 3");
            dic.Add("MaturityMeasures_3", "This is measure three – last one");
            pFundingInformation_ASOP51._ASOP51_riskAssessments(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateFIForASOP51 + "> and select <Run - Funding Calculations>");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted(dic);

            pMain._SelectTab("val 7.1.2019");

            _gLib._MsgBoxYesNo("Manual", "Right click Node <" + sVal2019Node_UpdateFIForASOP51 + "> and select <View Output>");


            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_updateFIForASOP51, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_updateFIForASOP51, "Funding Calculator", "RollForward", false, true);


            _gLib._MsgBox("", "please manually compare the FC excel file");

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region Acconting - July 2018 FAS Val - update cash balance

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect_Favorites(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "July 2018 FAS Val");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("July 2018 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", sAcc2018Node_UpdateCashBalance);
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._ValuationNodeProperties_ChangeReasons_Initialize();

            dic.Clear();
            dic.Add("LiabilityType", "All Accounting Liability Types");
            dic.Add("ReasonforChange", "Plan change");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            pMain._SelectTab("July 2018 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "pretransrate2");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "pretransrate2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "posttransrate2");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "posttransrate2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("July 2018 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Unit Formula");
            dic.Add("Level_4", "UFBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "4");
            dic.Add("sData", "400.00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "4");
            dic.Add("sData", "700.00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "3");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "4");
            dic.Add("sData", "850.00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "4");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "4");
            dic.Add("sData", "1000.00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "FAEBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.025");
            dic.Add("sData4", "0.03");
            dic.Add("sData5", "0.07");
            pFAEFormula._TBL_Excess_With3Tires_DE010(dic);

            _gLib._MsgBox("FAEBenefit", "Please double check the row2 values -0.025,0.03,0.07 are input correctly!");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "CBAccrual");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.05");
            dic.Add("sData4", "0.08");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.1");
            dic.Add("sData4", "0.16");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "TransBalance");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "");
            dic.Add("PayCredits", "");
            dic.Add("FreezePayCreditsAtAge_txt", "");
            dic.Add("RateOnBalanceIsDiffer", "true");
            pCashBalance._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ForAges", "");
            dic.Add("Rates", "pretransrate2");
            dic.Add("CreditingPeriod", "");
            dic.Add("CreditingFrequency", "");
            pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ForAges", "");
            dic.Add("Rates", "posttransrate2");
            dic.Add("CreditingPeriod", "");
            dic.Add("CreditingFrequency", "");
            pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CABenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.08");
            dic.Add("sData4", "0.1");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.12");
            dic.Add("sData4", "0.1");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("July 2018 FAS Val");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("July 2018 FAS Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "2");
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

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Test Cases", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Set for Globe Export", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("_US011CN", sOutputAccounting_July2018FASVal_UpdateCashBalance_Prod, sOutputAccounting_July2018FASVal_UpdateCashBalance);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2018FASVal_UpdateCashBalance");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_ABO.xlsx", 4, 0, 0, 0);
            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion

            _gLib._MsgBox("Congratulations!", "Finished!");

        
        }

        void t_CompareRpt_Funding_valJuly2019_UpdateProvisions(string sOutputFunding_valJuly2019_UpdateProvisions)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("_US011CN", sOutputFunding_valJuly2019_UpdateProvisions_Prod, sOutputFunding_valJuly2019_UpdateProvisions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_valJuly2019_UpdateProvisions");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0);


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
