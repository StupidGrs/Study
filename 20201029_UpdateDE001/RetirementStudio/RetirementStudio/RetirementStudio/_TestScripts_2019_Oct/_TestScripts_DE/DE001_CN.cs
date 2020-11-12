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
using System.Threading;
using RetirementStudio._UIMaps.Item2DCashFlowOptionsClasses;
using RetirementStudio._UIMaps.PayoutProjectionByParticipantClasses;


namespace RetirementStudio._TestScripts_2019_Oct_DE
{
    /// <summary>
    /// Summary description for DE001_CN
    /// </summary>
    [CodedUITest]
    public class DE001_CN
    {
        public DE001_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 001 Create New";
            Config.sPlanName = "Alle - QA DE Benchmark 001 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false ;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory


        public string sOutputPension_Pension2009 = "";
        public string sOutputJubilee_Jubilee2009_Baseline = "";
        public string sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = "";

        public string sOutputPension_Pension2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Production\VAL\Pension 2009\7.5_20191128_E\";
        public string sOutputJubilee_Jubilee2009_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Production\VAL\Jubilee 2009\Baseline\7.5_20191128_E\";
        public string sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Production\VAL\Jubilee 2009\Change Trade and IA Interest\7.5_20191128_E\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_001\Create New\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Pension2009 = _gLib._CreateDirectory(sMainDir + "Pension 2009\\" + sPostFix + "\\");
                    ////sOutputJubilee_JubileeConversion2008 = _gLib._CreateDirectory(sMainDir + "Jubilee Conversion 2008\\" + sPostFix + "\\");
                    sOutputJubilee_Jubilee2009_Baseline = _gLib._CreateDirectory(sMainDir + "Jubilee 2009\\Baseline\\" + sPostFix + "\\");
                    sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = _gLib._CreateDirectory(sMainDir + "Jubilee 2009\\Change Trade and IA Interest\\" + sPostFix + "\\");

                }
            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Pension2009 = @\"" + sOutputPension_Pension2009 + "\";" + Environment.NewLine;
            ////sContent = sContent + "sOutputJubilee_JubileeConversion2008 = @\"" + sOutputJubilee_JubileeConversion2008 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubilee2009_Baseline = @\"" + sOutputJubilee_Jubilee2009_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest = @\"" + sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);
        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        private PayoutProjectionByParticipant pPayoutProjectionByParticipant = new PayoutProjectionByParticipant();
        private Item2DCashFlowOptions p2DCashFlowOptions = new Item2DCashFlowOptions();
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
        public void test_DE001_CN()
        {


            #region MultiThreads

            Thread thrd_Pension2009 = new Thread(() => new DE001_CN().t_CompareRpt_Pension2009(sOutputPension_Pension2009));
            Thread thrd_Jubilee2009_Baseline = new Thread(() => new DE001_CN().t_CompareRpt_Jubilee2009_Baseline(sOutputJubilee_Jubilee2009_Baseline));

            #endregion


            this.GenerateReportOuputDir();


            #region Pension RF Valuation - Pension 2009


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete all RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Pension 2009");
            dic.Add("Parent", "Conversion 2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "True");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Pension 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



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
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "ValuationData2009");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #region Test Case


            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.15.1927\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1937\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.15.1926\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.15.1955\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            pMain._SelectTab("Pension 2009");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "NetPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Pen1");
            dic.Add("SelectVOs_VO2", "Pen2");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectVOs_VO5", "");
            dic.Add("SelectVOs_VO6", "");
            dic.Add("GL_Liabilities_Pension", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pension 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Parameter Summary", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Individual Checking Template", "RollForward", false, true, 0, new string[2] { "Pen1", "Pen2" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Member Statistics", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Valuation Summary", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[10] { "DeckPlan", "DeferredPlan", "GesamPlan", "MahoPlan", "PlanNamedVorst", "PlanOne", "PlanRen", "TheSecondPlanRen", "UVA2", "UVA3" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pension2009, "Payout Projection", "RollForward", false, true, dic);

           
            thrd_Pension2009.Start();


            pMain._SelectTab("Pension 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Jubilee 2009 - Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "please delete all RollForward services");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Jubilee 2009");
            dic.Add("Parent", "Jubilee Conversion 2008");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Jubilee 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

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
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "JubileeData2009");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #region Test Case

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.29.1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06.26.1947\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.28.1989\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            pMain._SelectTab("Jubilee 2009");

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
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


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Parameter Summary", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "Jub1" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_Baseline, "Payout Projection", "RollForward", false, true, dic);


            thrd_Jubilee2009_Baseline.Start();


            pMain._SelectTab("Jubilee 2009");
            pMain._Home_ToolbarClick_Top(true);



            #endregion


            #region Jubilee RF service: Jubilee 2009 - Change Trade and IA Interest


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Change Trade and IA Interest");
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
            dic.Add("Provisions_AddNew", "");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "31.12.2009");
            pInterestRate._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,9");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);




            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #region Test Cases


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.29.1986\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06.26.1947\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.28.1989\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion

            pMain._SelectTab("Jubilee 2009");




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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "JubiPayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jub1");
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

            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Parameter Summary", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "LargerGroup", "SmallerGroup" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[2] { "LargerGroup", "SmallerGroup" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest_Prod, sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest");
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LargerGroup.xlsx", 16, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_SmallerGroup.xlsx", 16, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_LargerGroup.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_SmallerGroup.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Jubilee 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Parameter Print");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ParameterPrint_Standalone(sOutputJubilee_Jubilee2009_ChangeTradeAndIAInterest);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("", "please manually compare parameter print for the last node, and this client is finished");

        }


        public void t_CompareRpt_Pension2009(string sOutputPension_Pension2009)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputPension_Pension2009_Prod, sOutputPension_Pension2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pension2009");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_UVA3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Pen1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Pen2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeckPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DeferredPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_GesamPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_MahoPlan.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanNamedVorst.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanOne.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_PlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_TheSecondPlanRen.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_UVA2.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_UVA3.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_UVA3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_DeckPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_DeferredPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_GesamPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_MahoPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanNamedVorst.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanOne.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_PlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_TheSecondPlanRen.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_UVA2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_UVA3.xlsx", 4, 0, 0, 0);

                
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Jubilee2009_Baseline(string sOutputJubilee_Jubilee2009_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE001CN", sOutputJubilee_Jubilee2009_Baseline_Prod, sOutputJubilee_Jubilee2009_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubilee2009_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LargerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_SmallerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Jub1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LargerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_SmallerGroup.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LargerGroup.xlsx", 4, 0, 0, 0);
                //////////////_compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_SmallerGroup.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_LargerGroup.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_SmallerGroup.xlsx", 4, 0, 0, 0);
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

