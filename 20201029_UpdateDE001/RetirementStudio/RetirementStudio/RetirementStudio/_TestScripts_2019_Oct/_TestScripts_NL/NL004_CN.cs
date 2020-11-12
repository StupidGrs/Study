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



// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.AgeClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Oct_NL
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NL004_CN
    {
        public NL004_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 004 Create New";
            Config.sPlanName = "QA NL Benchmark 004 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutputAccounting_Valuation2012_Baseline = "";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity125 = "";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity75 = "";
        public string sOutputAccounting_Valuation2012_InterestSensitivity585 = "";
        public string sOutputAccounting_Valuation2012_InterestSensitivity535 = "";
        public string sOutputAccounting_Valuation2012_PaySensitivity325 = "";
        public string sOutputAccounting_Valuation2012_PaySensitivity375 = "";

        public string sOutputAccounting_Conversion2011_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Conversion 2011\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\Baseline\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity125_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\IndexationSensitivity 1.25%\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_IndexationSensitivity75_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\IndexationSensitivity 0.75%\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_InterestSensitivity585_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\InterestSensitivity 5.85%\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_InterestSensitivity535_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\InterestSensitivity 5.35%\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_PaySensitivity325_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\PaySensitivity 3.25%\000_7.4_Baseline\";
        public string sOutputAccounting_Valuation2012_PaySensitivity375_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\Existing\Valuation 2012\PaySensitivity 3.75%\000_7.4_Baseline\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_004\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputAccounting_Valuation2012_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_IndexationSensitivity125 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\IndexationSensitivity 1.25%\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_IndexationSensitivity75 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\IndexationSensitivity 0.75%\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_InterestSensitivity585 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\InterestSensitivity 5.85%\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_InterestSensitivity535 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\InterestSensitivity 5.35%\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_PaySensitivity325 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\PaySensitivity 3.25%\\" + sPostFix + "\\");
                    sOutputAccounting_Valuation2012_PaySensitivity375 = _gLib._CreateDirectory(sMainDir + "Valuation 2012\\PaySensitivity 3.75%\\" + sPostFix + "\\");
                }

            }


            string sContent = "";
            sContent = sContent + "sOutputAccounting_Valuation2012_Baseline = @\"" + sOutputAccounting_Valuation2012_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_IndexationSensitivity125 = @\"" + sOutputAccounting_Valuation2012_IndexationSensitivity125 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_IndexationSensitivity75 = @\"" + sOutputAccounting_Valuation2012_IndexationSensitivity75 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_InterestSensitivity585 = @\"" + sOutputAccounting_Valuation2012_InterestSensitivity585 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_InterestSensitivity535 = @\"" + sOutputAccounting_Valuation2012_InterestSensitivity535 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_PaySensitivity325 = @\"" + sOutputAccounting_Valuation2012_PaySensitivity325 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_Valuation2012_PaySensitivity375 = @\"" + sOutputAccounting_Valuation2012_PaySensitivity375 + "\";" + Environment.NewLine;
            _gLib._PrintReportDirectory(sContent);
        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
        public PayCredit pPayCredit = new PayCredit();
        public Age pAge = new Age();
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



        #endregion

        
        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_NL004_CN()
        {

             
            #region MultiThreads

            Thread thrd_Valuation2012_Baseline = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_Baseline(sOutputAccounting_Valuation2012_Baseline));
            Thread thrd_Valuation2012_IndexationSensitivity125 = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_IndexationSensitivity125(sOutputAccounting_Valuation2012_IndexationSensitivity125));
            Thread thrd_Valuation2012_InterestSensitivity585 = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_InterestSensitivity585(sOutputAccounting_Valuation2012_InterestSensitivity585));
            Thread thrd_Valuation2012_InterestSensitivity535 = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_InterestSensitivity535(sOutputAccounting_Valuation2012_InterestSensitivity535));
            Thread thrd_Valuation2012_PaySensitivity325 = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_PaySensitivity325(sOutputAccounting_Valuation2012_PaySensitivity325));
            Thread thrd_Valuation2012_PaySensitivity375 = new Thread(() => new NL004_CN().t_CompareRpt_Valuation2012_PaySensitivity375(sOutputAccounting_Valuation2012_PaySensitivity375));

            #endregion


            this.GenerateReportOuputDir();


            #region Roll Forward

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete  all RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Valuation 2012");
            dic.Add("Parent", "Conversion 2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2012");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2012");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Valuation 2012");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Roll Forward");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "BaselineData");
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
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            #endregion


            #region Baseline

            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            //////check on Include in Report  for ExtraServiceYears, RetirementAge, TypeOfPlan, OPExtra,NPExtra, ProrateDate");

            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExtraServiceYears");
            pParticipantDataSet._Navigate(dic, true);



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ExtraServiceYears");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "false");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "RetirementAge");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TypeOfPlan");
            pParticipantDataSet._Navigate(dic, true, true);  //, false, false, false


            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "TypeOfPlan");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "OPExtra");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "NPExtra");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "DB Information");
            dic.Add("Level_2", "ProrateDate");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2012");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"2/28/1956\"  and $emp.HireDate1=\"9/7/1981\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"11/24/1931\"  and $emp.HireDate1=\"1/1/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"3/6/1948\"  and $emp.HireDate1=\"5/19/1969\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Status Reconciliation", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Member Statistics", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Checking Template", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Age Service Matrix", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Data Matching Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Combined Status Code Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_Baseline, "Liability Set for Globe Export", "RollForward", false, false);



            thrd_Valuation2012_Baseline.Start();

            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation2012_InterestSensitivity585

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Sensitivity");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("sTableType", "Interest");
            dic.Add("AssumptionDefinition", "Interest");
            dic.Add("sIntAcc", "");
            dic.Add("sTrade", "");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("sTableType", "Pay");
            dic.Add("AssumptionDefinition", "PayIncrease");
            dic.Add("sIntAcc", "");
            dic.Add("sTrade", "");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("sTableType", "Pension");
            dic.Add("AssumptionDefinition", "CostOfLivingIncreaseAssumption");
            dic.Add("sIntAcc", "");
            dic.Add("sTrade", "");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Interest_IncreaseBy", "0,25");
            dic.Add("Interest_DecreseBy", "0,25");
            dic.Add("Pay_IncreaseBy", "0,25");
            dic.Add("Pay_DecreseBy", "0,25");
            dic.Add("Pension_IncreaseBy", "0,25");
            dic.Add("Pension_DecreseBy", "0,25");
            dic.Add("Mortality_IncreaseFactor", "");
            dic.Add("Mortality_DecreseFactor", "");
            dic.Add("Mortality_IncreaseSetBack", "");
            dic.Add("Mortality_DecreseSetBack", "");
            dic.Add("AddSensitivityNodes", "click");
            pMain._PopVerify_AddSensitivityValuationNode(dic);



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


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Test Cases", "RollForward", true, true);


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

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Scenario by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "FAS Expected Benefit Pmts", "RollForward", false, false);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results with Breaks", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, false);

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity585, "Liability Set for Globe Export", "RollForward", false, false);


            thrd_Valuation2012_InterestSensitivity585.Start();


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


            #region Valuation2012_PaySensitivity375

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity375, "Liability Set for Globe Export", "RollForward", false, false);

            thrd_Valuation2012_PaySensitivity375.Start();


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation2012_IndexationSensitivity125

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity125, "Liability Set for Globe Export", "RollForward", false, false);


            thrd_Valuation2012_IndexationSensitivity125.Start();


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation2012_InterestSensitivity535


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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_InterestSensitivity535, "Liability Set for Globe Export", "RollForward", false, false);

            thrd_Valuation2012_InterestSensitivity535.Start();


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation2012_PaySensitivity325

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_PaySensitivity325, "Liability Set for Globe Export", "RollForward", false, false);

            thrd_Valuation2012_PaySensitivity325.Start();


            pMain._SelectTab("Valuation 2012");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation2012_IndexationSensitivity75

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Scenario", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Scenario by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Valuation Summary", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Individual Output", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "IOE", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Payout Projection", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "FAS Expected Benefit Pmts", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputAccounting_Valuation2012_IndexationSensitivity75, "Liability Set for Globe Export", "RollForward", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_IndexationSensitivity75_Prod, sOutputAccounting_Valuation2012_IndexationSensitivity75);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_IndexationSensitivity75");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            }


            #endregion


            _gLib._MsgBox("", "please manually compare parameter print for node: <Valuation2012_InterestSensitivity585>, and this client is finished");

        }




        public void t_CompareRpt_Valuation2012_Baseline(string sOutputAccounting_Valuation2012_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_Baseline_Prod, sOutputAccounting_Valuation2012_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Valuation2012_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearwithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearwithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 17, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;

            }
        }

        public void t_CompareRpt_Valuation2012_IndexationSensitivity125(string sOutputAccounting_Valuation2012_IndexationSensitivity125)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_IndexationSensitivity125_Prod, sOutputAccounting_Valuation2012_IndexationSensitivity125);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_IndexationSensitivity125");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Valuation2012_InterestSensitivity585(string sOutputAccounting_Valuation2012_InterestSensitivity585)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_InterestSensitivity585_Prod, sOutputAccounting_Valuation2012_InterestSensitivity585);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_InterestSensitivity585");
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_ABO.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBO.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_ABO.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_PBO.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Valuation2012_InterestSensitivity535(string sOutputAccounting_Valuation2012_InterestSensitivity535)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_InterestSensitivity535_Prod, sOutputAccounting_Valuation2012_InterestSensitivity535);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_InterestSensitivity535");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Valuation2012_PaySensitivity325(string sOutputAccounting_Valuation2012_PaySensitivity325)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_PaySensitivity325_Prod, sOutputAccounting_Valuation2012_PaySensitivity325);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_PaySensitivity325");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Valuation2012_PaySensitivity375(string sOutputAccounting_Valuation2012_PaySensitivity375)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL004CN", sOutputAccounting_Valuation2012_PaySensitivity375_Prod, sOutputAccounting_Valuation2012_PaySensitivity375);
                _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_Valuation2012_PaySensitivity375");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
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
