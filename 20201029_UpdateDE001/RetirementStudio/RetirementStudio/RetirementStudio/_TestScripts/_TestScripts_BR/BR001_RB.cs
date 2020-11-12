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
using RetirementStudio._UIMaps.AdjustmentsClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionRatesClasses;
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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.TableManagerClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.InactiveBenefitPaymentClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;

// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.AgeClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;

//BR
using RetirementStudio._UIMaps.CustomRateClasses;

namespace RetirementStudio._TestScripts
{
    /// <summary>
    /// Summary description for BR001_BR
    /// </summary>
    [CodedUITest]
    public class BR001_BR
    {
        public BR001_BR()
        {

            Config.eEnv = _TestingEnv.Prod_EU;
            Config.eCountry = _Country.BR;
            Config.sClientName = "QA BR Benchmark 001";
            Config.sPlanName = "QA BR Benchmark 001 Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory

        public string sFunding_Funding2015 = "";
        public string sAccounting_Accounting2015 = "";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_001\Production\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sFunding_Funding2015 = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2015\\" + sPostFix + "\\");
                    sAccounting_Accounting2015 = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting2015\\" + sPostFix + "\\");

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

                ////////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "BR001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sFunding_Funding2015 = _gLib._CreateDirectory(sMainDir + "\\sFunding_Funding2015\\");

                sAccounting_Accounting2015 = _gLib._CreateDirectory(sMainDir + "\\sAccounting_Accounting2015\\");

            }

            string sContent = "";
            sContent = sContent + "sFunding_Funding2015 = @\"" + sFunding_Funding2015 + "\";" + Environment.NewLine;

            sContent = sContent + "sAccounting_Accounting2015 = @\"" + sAccounting_Accounting2015 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);



        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public InactiveBenefitPayment pInactiveBenefitPayment = new InactiveBenefitPayment();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public CashBalance pCashBalance = new CashBalance();
        public PayCredit pPayCredit = new PayCredit();
        public Age pAge = new Age();
        public UnitFormula pUnitFormula = new UnitFormula();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
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
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public MortalityDecrement pMortalityDecrement = new MortalityDecrement();
        public Service pService = new Service();
        public Eligibilities pEligibilities = new Eligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public SocialSecurityContributionRates pSocialSecurityContributionRates = new SocialSecurityContributionRates();
        public Vesting pVesting = new Vesting();
        public ActuarialEquivalence pActuarialEquivalence = new ActuarialEquivalence();
        public Adjustments pAdjustments = new Adjustments();
        public ConversionFactors pConversionFactors = new ConversionFactors();
        public FormOfPayment pFormOfPayment = new FormOfPayment();
        public Item415Limits p415Limits = new Item415Limits();
        public PlanDefinition pPlanDefinition = new PlanDefinition();
        public Methods pMethods = new Methods();
        public TestCaseLibrary pTestCaseLibrary = new TestCaseLibrary();
        public TableManager pTableManager = new TableManager();
        public OutputManager pOutputManager = new OutputManager();
        public Assets pAssets = new Assets();
        public FundingInformation pFundingInformation = new FundingInformation();
        public FundingInformation_PYR_PreliminaryResults pFundingInformation_PYR_PreliminaryResults = new FundingInformation_PYR_PreliminaryResults();
        public FundingInformation_FTAPs pFundingInformation_FTAPs = new FundingInformation_FTAPs();
        public FundingInformation_Shortfall pFundingInformation_Shortfall = new FundingInformation_Shortfall();
        public FundingInformation_ContributionSummary pFundingInformation_ContributionSummary = new FundingInformation_ContributionSummary();
        public OtherEconomicAssumption pOtherEconomicAssumption = new OtherEconomicAssumption();
        public FromToAge pFromToAge = new FromToAge();
        public FAEFormula pFAEFormula = new FAEFormula();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public BenefitElections pBenefitElections = new BenefitElections();

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public ContractualRetirementAge pContractualRetirementAge = new ContractualRetirementAge();
        public JubileeBenefit pJubileeBenefit = new JubileeBenefit();
        public PlanDefinition_DE pPlanDefinition_DE = new PlanDefinition_DE();
        public CustomRate pCustomRate = new CustomRate();



        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_BR001_BR()
        {


            sFunding_Funding2015 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_001\Production\Funding\Funding2015\20191209_Prod_EU\";
            sAccounting_Accounting2015 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_001\Production\Accounting\Accounting2015\20191209_Prod_EU\";


            //this.GenerateReportOuputDir();

            #region Accounting - 31.12.2015 Accounting

            //pMain._SelectTab("Home");

            //dic.Clear();
            //dic.Add("Country", Config.eCountry.ToString());
            //dic.Add("Level_1", Config.sClientName);
            //dic.Add("Level_2", Config.sPlanName);
            //dic.Add("Level_3", "AccountingValuations");
            //pMain._HomeTreeViewSelect_Favorites(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "31.12.2015 Accounting");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("Service", "ServiceFromHire");
            dic.Add("Pay", "SalaryProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdditionalAccountBalance");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
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


            pMain._SelectTab("31.12.2015 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sAccounting_Accounting2015, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Valuation Summary", "Conversion", true, false);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Accounting2015, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Accounting2015, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Accounting2015, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Accounting2015, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Accounting2015, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Accounting2015, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Funding 31.12.2015

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
            dic.Add("ServiceToOpen", "Funding 31.12.2015");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Funding 31.12.2015");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");

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
            dic.Add("Service", "ServiceFromHire");
            dic.Add("Pay", "SalaryProjection");
            dic.Add("CurrentYear", "Click");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AdditionalAccountBalance");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Funding 31.12.2015");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Funding 31.12.2015");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Funding2015, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(sFunding_Funding2015, "Valuation Summary", "Conversion", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Funding2015, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Funding2015, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Payout Projection", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Funding2015, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Funding2015, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Funding2015, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Funding2015, "Payout Projection", "Conversion", false, false);
            }
   
            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Funding 31.12.2015");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sFunding_Funding2015);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            _gLib._MsgBox("", "finished !!");
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
