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
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.TableManagerClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;


// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionRatesClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.ProjectAndProrateClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.FormOfPayment_DEClasses;
using RetirementStudio._UIMaps.IndividualOuputFieldDefinitionClasses;
using RetirementStudio._UIMaps.Methods_DEClasses;
using RetirementStudio._UIMaps.ReportBreaksClasses;
using RetirementStudio._UIMaps.BreakFieldTextSubstitutionClasses;
using RetirementStudio._UIMaps.ContributionsBasedFormulaClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionCeilingsClasses;
using RetirementStudio._UIMaps.OneYearProjectionClasses;
using RetirementStudio._UIMaps.SocialSecurityClasses;
using RetirementStudio._UIMaps.VersorgungsausgleichClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _DE010_DNT_2
    {
        public _DE010_DNT_2()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 010 Existing DNT Plan";
            //Config.sClientName = "QA DE Benchmark 010";
            //Config.sPlanName = "QA DE Benchmark 010 Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory


        public string sOutputJubilee_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\V67Enhancements\000_7.4_Baseline\";
        public string sOutputJubilee_Valuation2012_V69Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\V69Enhancements\000_7.4_Baseline\";

        public string sOutputJubilee_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Valuation2012_V69Enhancements = "";

        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional();

            _BenchmarkUser sCurrentUser = _gLib._ReturnCurrentUser();

            if (sCurrentUser.ToString() == "Others")
            {
                _gLib._MsgBox("Warning !!!", "Your are NOT allowed to create folders in R: drive, Please contact Cindy or Webber if you have to!");
                Environment.Exit(0);
            }
            else
            {
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                sOutputJubilee_Valuation2012_V67Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V67Enhancements\\" + sPostFix + "\\");
                sOutputJubilee_Valuation2012_V69Enhancements = _gLib._CreateDirectory(sMainDir + "\\Jubilee Valuation 2012\\V69Enhancements\\" + sPostFix + "\\");
            }


            string sContent = "";

            sContent = sContent + "sOutputJubilee_Valuation2012_V67Enhancements = @\"" + sOutputJubilee_Valuation2012_V67Enhancements + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Valuation2012_V69Enhancements = @\"" + sOutputJubilee_Valuation2012_V69Enhancements + "\";" + Environment.NewLine;


            _gLib._PrintReportDirectory(sContent);

        }


        #endregion



        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();
        public CashBalance pCashBalance = new CashBalance();
        public Versorgungsausgleich pVersorgungsausgleich = new Versorgungsausgleich();
        public SocialSecurity pSocialSecurity = new SocialSecurity();
        public OneYearProjection pOneYearProjection = new OneYearProjection();
        public SocialSecurityContributionCeilings pSocialSecurityContributionCeilings = new SocialSecurityContributionCeilings();
        public ActuarialReport pActuarialReport = new ActuarialReport();
        public PayCredit pPayCredit = new PayCredit();
        public MyDictionary dic = new MyDictionary();
        public ContributionsBasedFormula pContributionsBasedFormula = new ContributionsBasedFormula();
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
        public FromToAge pFromToAge = new FromToAge();
        public FAEFormula pFAEFormula = new FAEFormula();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public BenefitElections pBenefitElections = new BenefitElections();

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public ContractualRetirementAge pContractualRetirementAge = new ContractualRetirementAge();
        public JubileeBenefit pJubileeBenefit = new JubileeBenefit();
        public PlanDefinition_DE pPlanDefinition_DE = new PlanDefinition_DE();
        public TableManager pTableManager = new TableManager();
        public UnitFormula pUnitFormula = new UnitFormula();
        public SocialSecurityContributionRates pSocialSecurityContributionRates = new SocialSecurityContributionRates();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public ProjectAndProrate pProjectAndProrate = new ProjectAndProrate();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public FormOfPayment_DE pFormOfPayment_DE = new FormOfPayment_DE();
        public IndividualOuputFieldDefinition pIndividualOuputFieldDefinition = new IndividualOuputFieldDefinition();
        public Methods_DE pMethods_DE = new Methods_DE();
        public ReportBreaks pReportBreaks = new ReportBreaks();
        public BreakFieldTextSubstitution pBreakFieldTextSubstitution = new BreakFieldTextSubstitution();

        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_DE010_DNT_2()
        {


            #region MultiThreads

            Thread thrd_Jubilee_Valuation2012_V67Enhancements = new Thread(() => new _DE010_DNT_2().t_CompareRpt_Jubilee_Valuation2012_V67Enhancements(sOutputJubilee_Valuation2012_V67Enhancements));
            #endregion


            this.GenerateReportOuputDir();

            #region  Jubilee RF - Valuation 2012 - V6.7 Enhancements



            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2012");

            _gLib._MsgBox("", "pls set screen as maxinum");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiSalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "false");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
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
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "");
            dic.Add("iSelectColNum", "");
            dic.Add("iPosX", "425");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Parameter Print", "RollForward", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Test Cases", "RollForward", false, false);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Valuation Summary", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Valuation Summary for Excel Export", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V67Enhancements, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[6] { "Sub1_F", "Sub1_M", "Sub2_F", "Sub2_M", "Sub3_F", "Sub3_M" });

            thrd_Jubilee_Valuation2012_V67Enhancements.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region  Jubilee RF - Valuation 2012 - V6.9 Enhancements


            pMain._SelectTab("Valuation 2012");



            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Batch Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("OK", "click");
            pMain._HandleRemoved(dic);

            _gLib._MsgBox("", "update liability order to ABO -> PBO -> Trade -> Tax");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "true");
            dic.Add("ApplyWithdrawalAdjustment", "true");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "true");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiSalaryCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "true");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "");
            dic.Add("SelectVOs_VO2", "");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectNodes", "click");
            dic.Add("RunValuation", "");
            pMain._PopVerify_RunOptions(dic);

            /// Select all the 6 sensitivity nodes
            /// 
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "73");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "204");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "336");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "477");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "602");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "732");
            dic.Add("iY", "206");
            dic.Add("OK", "click");
            pMain._PopVerify_MultipleNodeSelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "JUBI01");
            dic.Add("SelectVOs_VO2", "JUBI02");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "204");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "342");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "475");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "607");
            dic.Add("iPosY", "209");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "729");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);

            _gLib._Wait(10);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iPosX", "687");
            dic.Add("iPosY", "140");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Jubilee", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "IFRS", "RollForward", false, true);


            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Valuation Summary", "RollForward", false, false, 0, new string[3] { "Sub1Text", "Sub2Text", "Sub3" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Valuation Summary for Excel Export", "RollForward", false, false);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Scenario by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, false);

            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[3] { "Sub1Text", "Sub2Text", "Sub3" });


            dic.Clear();
            dic.Add("Include", "true;true");
            dic.Add("DataRequestGroup", "FormerEastGermary;FormerWastGermary");
            dic.Add("Layout", "Data request layout default;Data request layout default");
            dic.Add("SelectionCriteria", "$emp.OstWestKZ=1;$emp.OstWestKZ<>1");
            dic.Add("UseReportBreak", "true");
            dic.Add("Process", "click");
            pOutputManager._Jubilee_DataRequest(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);


            dic.Clear();
            dic.Add("Description", "test" + Environment.NewLine + "6" + Environment.NewLine + "sensi" + Environment.NewLine + "Nodes");
            dic.Add("ResultToBeIncluded_ResultType", "End of Year assumptions;Custom Demographic assumptions 1 +;"
                + "Custom Demographic assumptions 1 -;Custom Financial assumptions 1 +;Custom Financial assumptions 1 -;"
                + "Salary increase rate +;Salary increase rate -;");
            dic.Add("ResultToBeIncluded_ValuationNode", "V6.9 Enhancements;Mortality *1,135 ;Mortality *0,885 ;"
                + "InterestSensitivity Null +0.5%;InterestSensitivity Null -0.5%;PaySensitivity 3.5%;PaySensitivity 2.5%");
            dic.Add("ExportToExcel", "click");
            dic.Add("ExportToGlobe", "click");
            pOutputManager._Jubilee_GlobeExportWithBreaksAndMultipleNodes(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT_2", sOutputJubilee_Valuation2012_V69Enhancements_Prod, sOutputJubilee_Valuation2012_V69Enhancements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sJubileeValuation2012_V69Enhancements");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1Text.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2Text.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub3.xlsx", 11, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenarioByPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDefwithBreaks.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1Text.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2Text.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("GlobeExportwithBreaksandMultipleNodesToExcel.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


            _gLib._MsgBox("", "wait and check");


            pMain._SelectTab("OutPut Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("!", "DE010 is done ! Please manually compare Actuarial Report");

        }


        #region compare report function


        void t_CompareRpt_Jubilee_Valuation2012_V67Enhancements(string sOutputJubilee_Valuation2012_V67Enhancements)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010DNT_2", sOutputJubilee_Valuation2012_V67Enhancements_Prod, sOutputJubilee_Valuation2012_V67Enhancements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sJubileeValuation201_V67Enhancements");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_F.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub1_M.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_F.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub2_M.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub3_F.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_Sub3_M.xlsx", 11, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub1_M.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub2_M.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_F.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_Sub3_M.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        #endregion

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
