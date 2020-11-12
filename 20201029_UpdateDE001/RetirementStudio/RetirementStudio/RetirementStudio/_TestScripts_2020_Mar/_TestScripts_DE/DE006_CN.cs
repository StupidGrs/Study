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
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using RetirementStudio._UIMaps.SocialSecurityClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2020_Mar_DE
{
    /// <summary>
    /// Summary description for DE006_CN
    /// </summary>
    [CodedUITest]
    public class DE006_CN
    {
        public DE006_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 006 Create New D";
            Config.sPlanName = "QA DE Benchmark 006 Create New Plan";
            Config.sDataCenter = "Dallas";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutputPension_Pensionen2011_Baseline = "";
        public string sOutputPension_Pensionen2011_NewValuation = "";
        public string sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = "";
        public string sOutputJubilee_Jubi2011_Baseline = "";
        public string sOutputJubilee_Jubi2011_NewValuation = "";

        public string sOutputPension_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Conversion 2010\7.5.1_20191107_B\";
        public string sOutputPension_Pensionen2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Pension 2011\Baseline\7.5.1_20191107_B\";
        public string sOutputPension_Pensionen2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Pension\Pension 2011\New Valuation\7.5.1_20191107_B\";
        public string sOutputJubilee_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Conversion 2010\7.5.1_20191107_B\";
        public string sOutputJubilee_Jubi2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Jubi 2011\Baseline\7.5.1_20191107_B\";
        public string sOutputJubilee_Jubi2011_NewValuation_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Production\Jubilee\Jubi 2011\New Valuation\7.5.1_20191107_B\";



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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_006\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Pensionen2011_Baseline = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Pensionen2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\New Valuation\\" + sPostFix + "\\");
                    sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = _gLib._CreateDirectory(sMainDir + "Pension\\Pensionen 2011\\Check Sensitivitys in IFRS Repor\\" + sPostFix + "\\");
                    sOutputJubilee_Jubi2011_Baseline = _gLib._CreateDirectory(sMainDir + "Jubilee\\Jubi_2011\\Baseline\\" + sPostFix + "\\");
                    sOutputJubilee_Jubi2011_NewValuation = _gLib._CreateDirectory(sMainDir + "Jubilee\\Jubi_2011\\New Valuation\\" + sPostFix + "\\");
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

                ////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "DE006_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Pensionen2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pensionen2011_Baseline\\");
                sOutputPension_Pensionen2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pensionen2011_NewValuation\\");
                sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor\\");
                sOutputJubilee_Jubi2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubi2011_Baseline\\");
                sOutputJubilee_Jubi2011_NewValuation = _gLib._CreateDirectory(sMainDir + "\\sOutputJubilee_Jubi2011_NewValuation\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Pensionen2011_Baseline = @\"" + sOutputPension_Pensionen2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pensionen2011_NewValuation = @\"" + sOutputPension_Pensionen2011_NewValuation + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor = @\"" + sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubi2011_Baseline = @\"" + sOutputJubilee_Jubi2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputJubilee_Jubi2011_NewValuation = @\"" + sOutputJubilee_Jubi2011_NewValuation + "\";" + Environment.NewLine;
            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public SocialSecurity pSocialSecurity = new SocialSecurity();
        public ActuarialReport pActuarialReport = new ActuarialReport();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();
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
        public void test_DE006_CN()
        {


            #region MultiThreads

            Thread thrd_Pensionen2011_Baseline = new Thread(() => new DE006_CN().t_CompareRpt_Pensionen2011_Baseline(sOutputPension_Pensionen2011_Baseline));
            Thread thrd_Pensionen2011_NewValuation = new Thread(() => new DE006_CN().t_CompareRpt_Pensionen2011_NewValuation(sOutputPension_Pensionen2011_NewValuation));
            Thread thrd_Jubi2011_Baseline = new Thread(() => new DE006_CN().t_CompareRpt_Jubi2011_Baseline(sOutputJubilee_Jubi2011_Baseline));

            #endregion


            this.GenerateReportOuputDir();


            #region Pension Valuation RF - Pensionen 2011 - Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete all RollForward service");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Pensionen 2011");
            dic.Add("Parent", "Conversion 2010");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2011");
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
            dic.Add("ServiceToOpen", "Pensionen 2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("Pensionen 2011");

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
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
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
            dic.Add("SnapshotName", "Snap_Pens_2011");
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


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"07.17.1953\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02.05.1937\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Pensionen 2011");

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
            dic.Add("SaveResultsforAuditReport", "true");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "false");
            dic.Add("InternationalAccountingPBO", "false");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
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

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[2] { "EZ", "VO" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_Baseline, "Payout Projection", "RollForward", false, true, dic);


            thrd_Pensionen2011_Baseline.Start();

            pMain._SelectTab("Pensionen 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Pension Valuation RF - Pensionen 2011 - New Valuation

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
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
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

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
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,14");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Pensionen 2011");


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
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "FALSE");
            dic.Add("InternationalAccountingPBO", "false");
            dic.Add("SelectVOs_AllVOs", "True");
            dic.Add("SelectVOs_VO1", "");
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

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pActuarialReport._SelectTab("General");

            dic.Clear();
            dic.Add("MecerLocation", "Stuttgart");
            dic.Add("NameToBePrintedOnReportLeft", "Lars Erpenbach");
            dic.Add("AcademicTitleOfPersonLeft", "Diplom-Wirtschaftsmathematiker");
            dic.Add("NameToBePrintedOnReportRight", "Stefan Heinzmann");
            dic.Add("AcademicTitleOfPersonRight", "Diplom-Wirtschaftsmathematiker");
            dic.Add("ExtensionOfUndersigningPersonRight", "+49 711 23716 0");
            dic.Add("LocationOfUndersigningPersonRight", "Stuttgart");
            dic.Add("DoNotAttachTermsAndConditions", "true");
            pActuarialReport._General(dic);


            pActuarialReport._SelectTab("Subsidiary Information");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ClientLongName", "true");
            dic.Add("ClientLongName_txt", "A. & C KOSIK GmbH");
            dic.Add("ClientShortName", "true");
            dic.Add("ClientShortName_txt", "A. & C KOSIK GmbH");
            dic.Add("ClientCode", "");
            dic.Add("AddressLine1", "true");
            dic.Add("AddressLine1_txt", "Hirschberger Str. 1");
            dic.Add("City", "true");
            dic.Add("City_txt", "Kelheim");
            dic.Add("PostalCode", "true");
            dic.Add("PostalCode_txt", "93309");
            dic.Add("Country", "true");
            dic.Add("Country_txt", "Deutschland");
            pActuarialReport._SubsidiaryInformation(dic);

            pMain._Home_ToolbarClick_Top(true);


            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ReportSetName", "TaxTrade");
            dic.Add("ReportType", "Direct Promise");
            dic.Add("ReportTemplate", "2018_DEDirectPromise");
            dic.Add("Listing1", "DirectPromise_2013");
            pActuarialReport._ReportContents_DefineReportSets(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VOShortName", "VO");
            dic.Add("VOZusammenfassung", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE006\KB Kosik Pensionen.doc");
            dic.Add("VOSummary", "");
            pActuarialReport._ReportContents_VOSummaries(dic);

            pMain._Home_ToolbarClick_Top(true);


            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DirectPromise", "true");
            dic.Add("SupportFund", "false");
            dic.Add("NameOfSupportFund", "");
            dic.Add("NumberOfReports", "");
            pActuarialReport._TaxAndTrade(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Direct Promise Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "TaxTrade");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run Date");
            dic.Add("iCol", "1");
            dic.Add("sData", "17.12.2011");
            dic.Add("sFieldType", "Date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run date of last year's report");
            dic.Add("iCol", "1");
            dic.Add("sData", "15.11.2010");
            dic.Add("sFieldType", "Date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Inventory Date");
            dic.Add("iCol", "1");
            dic.Add("sData", "10.10.2011");
            dic.Add("sFieldType", "Date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            ////dic.Clear();
            ////dic.Add("PopVerify", "Pop");
            ////dic.Add("InformationByBreak", "Date when BilMoG is first applied");
            ////dic.Add("iCol", "1");
            ////dic.Add("sData", "01.01.2010");
            ////dic.Add("sFieldType", "Date");
            ////pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Show complete reconcilation of pension expense for Trade");
            dic.Add("InformationByBreak", "Immediate recognition of transition obligation under BilMoG");
            dic.Add("iCol", "1");
            dic.Add("sData", "true");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Transition amount liabilities when BilMoG was first applied");
            dic.Add("iCol", "1");
            dic.Add("sData", "353801");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////////dic.Add("InformationByBreak", "Interest rate BilMoG as of previous year");
            dic.Add("InformationByBreak", "Interest Rate Trade as of previous Year (100% for automatic)");
            dic.Add("iCol", "1");
            dic.Add("sData", "5,17%");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////////dic.Add("InformationByBreak", "COLA rate");
            dic.Add("InformationByBreak", "COLA rate (100% not to display)");
            dic.Add("iCol", "1");
            dic.Add("sData", "2,00%");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            dic.Add("InformationByBreak", "LY Liabilities applying § 253 Abs.2 HGB (BilMoG)");
            dic.Add("iCol", "1");
            dic.Add("sData", "1786534");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////dic.Add("InformationByBreak", "LY Book Reserve Trade");
            dic.Add("InformationByBreak", "LY Book Reserve Trade applying § 253 Abs.2 HGB (BilMoG)");
            dic.Add("iCol", "1");
            dic.Add("sData", "1786534");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            ////////dic.Add("InformationByBreak", "Pensions paid this year (incl. from assets)");
            dic.Add("InformationByBreak", "Payments paid (incl. from assets");
            dic.Add("iCol", "1");
            dic.Add("sData", "155639,94");
            dic.Add("sFieldType", "Txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            pActuarialReport._SelectTab("Sensitivity Results");

            for (int i = 1; i <= 6; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("iRow", i.ToString());
                dic.Add("ValuationNode", "Using IntAcc Tab Value");
                pActuarialReport._SensitivityResults(dic);
            }

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Test Cases", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Direct Promise", "RollForward", true, true);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);



            thrd_Pensionen2011_NewValuation.Start();

            pMain._SelectTab("Pensionen 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Pension Valuation RF - Pensionen 2011 - Check Sensitivitys in IFRS Repor

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Check Sensitivitys in IFRS Repor");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "True");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);



            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Participant DataSet");

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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TradeLiability_SameMethodforAllVOs", "false");
            dic.Add("IntAccLiability_SameMethodforAllVOs", "false");
            pMethods_DE._Methods_Pension_DE006(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "Entry Age Normal (Modified)");
            dic.Add("MembershipDate", "MembershipDate1");
            dic.Add("AnnualIncreaseRate", "NewPayIncrease1");
            dic.Add("EarliestEntryAgeMethod", "");
            dic.Add("EarliestEntryAge_txt", "20");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_TradeLiability(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("MembershipDate", "MembershipDate1");
            dic.Add("AnnualIncreaseRate", "");
            dic.Add("EarliestEntryAgeMethod", "According to Tax Law");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_TradeLiability(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "");
            pMethods_DE._Table_InternationalAccounting(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Alt Trade Proj Int");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("Other", "");
            dic.Add("AsOfDate", "31.12.2012");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
            dic.Add("Other", "");
            dic.Add("AsOfDate", "31.12.2012");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "BE_33PerCent");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "BE_33PerCent");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "33,33333333");
            dic.Add("ElectionTable_cbo", "");
            pBenefitElections._PopVerify_BenefitElections(dic);


            pMethods._SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "BE_33PerCent");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "33,33333333");
            dic.Add("ElectionTable_cbo", "");
            pBenefitElections._PopVerify_BenefitElections(dic);


            pMethods._SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "BE_33PerCent");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "33,33333333");
            dic.Add("ElectionTable_cbo", "");
            pBenefitElections._PopVerify_BenefitElections(dic);




            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            for (int i = 1; i <= 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "VO");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "OldAgePension");
                dic.Add("MenuItem", "Copy");
                pAssumptions._TreeViewRightSelect(dic, "");

                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "VO");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "OldAgePension");
                dic.Add("MenuItem", "Paste");
                pAssumptions._TreeViewRightSelect(dic, "");
            }



            for (int i = 1; i <= 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "VO");
                dic.Add("Level_3", "Provisions");
                dic.Add("Level_4", "Form of Payment");
                dic.Add("MenuItem", "Add Form of Payment");
                pAssumptions._TreeViewRightSelect(dic, "");
            }


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "NewFormofPayment1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MonthstoDeferLump_C", "click");
            dic.Add("MonthstoDeferLump_txt", "6");
            dic.Add("LumpSumInstallments_C", "click");
            dic.Add("LumpSumInstallments_txt", "1");
            dic.Add("InstallmentsAnnualRate_P", "click");
            dic.Add("InstallmentsAnnualRate_txt", "0,0");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "NewFormofPayment2");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MonthstoDeferLump_C", "click");
            dic.Add("MonthstoDeferLump_txt", "6");
            dic.Add("LumpSumInstallments_C", "click");
            dic.Add("LumpSumInstallments_txt", "10");
            dic.Add("InstallmentsAnnualRate_P", "click");
            dic.Add("InstallmentsAnnualRate_txt", "5,0");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "NewActuarialEquivalence1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Actuarial Equivalence");
            dic.Add("Level_5", "NewActuarialEquivalence1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "True");
            dic.Add("ValuationMortality", "True");
            dic.Add("ValuationCOLA", "");
            dic.Add("ValuationSpouseAgeDiff", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "1,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "NewConversionFactors1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Conversion Factors");
            dic.Add("Level_5", "NewConversionFactors1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("PresentValueFactor", "True");
            dic.Add("TabularOrConstantFactor", "");
            dic.Add("CustomCode", "");
            pConversionFactors._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCommencementAge_V", "click");
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
            pConversionFactors._PopVerify_PresentValueFactor(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("FormOfPaymentType_To", "");
            dic.Add("MortalityInDeferralPeriod_From", "");
            dic.Add("MortalityInDeferralPeriod_To", "");
            dic.Add("ActuarialEquivalence_From", "NewActuarialEquivalence1");
            dic.Add("ApplySpouseAgeDifference_From", "");
            pConversionFactors._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "NewPlanDefinition1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Conversion", "NewConversionFactors1");
            dic.Add("FormOfPayment", "NewFormofPayment1");
            dic.Add("BenefitElectionPercentage", "BE_33PerCent");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "NewPlanDefinition2");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Conversion", "NewConversionFactors1");
            dic.Add("FormOfPayment", "NewFormofPayment2");
            dic.Add("BenefitElectionPercentage", "BE_33PerCent");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "OldAgePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitElectionPercentage", "BE_33PerCent");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Social Security");
            dic.Add("MenuItem", "Add Social Security");
            pAssumptions._TreeViewRightSelect(dic, "NewSocialSecurity1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Social Security");
            dic.Add("Level_6", "NewSocialSecurity1");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SaveThisBenefit", "true");
            dic.Add("Method_Salary", "PP_PensEK");
            dic.Add("SSCC_Increase", "NewPayIncrease1");
            dic.Add("AktuellerRentenwert_Increase", "CostOfLivingIncreaseAssumption");
            dic.Add("VorlDurchs_Increase", "CostOfLivingIncreaseAssumption");
            pSocialSecurity._SocialSecurity(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VO");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$UF_Planformel*$emp.ParttimeAverage+$NewSocialSecurity1_SSDIS");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "OldAgeRev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "click");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "click");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "click");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "click");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "click");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "click");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "40");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "56");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Liabilities");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor, "Parameter Print", "RollForward", true, true);

            //////_gLib._MsgBox("", "Please manually compare the ParameterPrint,and  make sure it's matched as expected"
            //////      + Environment.NewLine + "and the CreateNew path is " + sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Sensitivity");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("AddSensitivityNodes", "");
            pMain._PopVerify_AddSensitivityValuationNode(dic);


            dic.Clear();
            dic.Add("sTableType", "Interest");
            dic.Add("AssumptionDefinition", "Interest");
            dic.Add("sIntAcc", "True");
            dic.Add("sTrade", "True");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("sTableType", "Pay");
            dic.Add("AssumptionDefinition", "CostOfLivingIncreaseAssumption");
            dic.Add("sIntAcc", "True");
            dic.Add("sTrade", "True");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("sTableType", "Pension");
            dic.Add("AssumptionDefinition", "NewPayIncrease1");
            dic.Add("sIntAcc", "True");
            dic.Add("sTrade", "True");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("sTableType", "Mortality");
            dic.Add("AssumptionDefinition", "Death");
            dic.Add("sIntAcc", "True");
            dic.Add("sTrade", "True");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Interest_IncreaseBy", "");
            dic.Add("Interest_DecreseBy", "");
            dic.Add("Pay_IncreaseBy", "");
            dic.Add("Pay_DecreseBy", "");
            dic.Add("Pension_IncreaseBy", "");
            dic.Add("Pension_DecreseBy", "");
            dic.Add("Mortality_IncreaseFactor", "");
            dic.Add("Mortality_DecreseFactor", "");
            dic.Add("Mortality_IncreaseSetBack", "");
            dic.Add("Mortality_DecreseSetBack", "");
            dic.Add("AddSensitivityNodes", "Click");
            pMain._PopVerify_AddSensitivityValuationNode(dic);


            pMain._SelectTab("Pensionen 2011");


            _gLib._MsgBox("", "Pls set the menu screen as maximum");


            dic.Clear();
            //////////////////dic.Add("iMaxRowNum", "");
            //////////////////dic.Add("iMaxColNum", "2");
            //////////////////dic.Add("iSelectRowNum", "3");
            //////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "738");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Batch Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "true");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "true");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "Pay1CurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("AltTradeProjInt", "True");
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

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "79");
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
            dic.Add("iX", "343");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "469");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "601");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "738");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "860");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "984");
            dic.Add("iY", "206");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //////_gLib._MsgBox("", "please check all the nodes under <Check Sensitivity ... > was selected");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "");
            dic.Add("iY", "");
            dic.Add("OK", "click");
            pMain._PopVerify_MultipleNodeSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            //// check all node is complered run ER, and next sample is first and last node.
            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iPosX", "80");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);



            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iPosX", "1000");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            ////////////////////dic.Add("iMaxColNum", "2");
            ////////////////////dic.Add("iSelectRowNum", "3");
            ////////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "738");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ReportSetName", "TaxTradeReport");
            dic.Add("ReportType", "Direct Promise");
            dic.Add("ReportTemplate", "2018_DEDirectPromise");
            dic.Add("Listing1", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ReportSetName", "IFRSReportEng");
            dic.Add("ReportType", "IFRS");
            dic.Add("ReportTemplate", "2018_DEIFRSEnglish");
            dic.Add("Listing1", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("ReportSetName", "USGAAPReport");
            dic.Add("ReportType", "IFRS");
            dic.Add("ReportTemplate", "2018_DEUSGAAPEnglish");
            dic.Add("Listing1", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("ReportSetName", "IFRSReportDeu");
            dic.Add("ReportType", "IFRS");
            dic.Add("ReportTemplate", "2018_DEIFRSGerman");
            dic.Add("Listing1", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VOShortName", "VO");
            dic.Add("VOZusammenfassung", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE006\KB Kosik Pensionen.doc");
            dic.Add("VOSummary", "");
            pActuarialReport._ReportContents_VOSummaries(dic);

            pMain._Home_ToolbarClick_Top(true);


            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DirectPromise", "true");
            dic.Add("SupportFund", "false");
            dic.Add("NameOfSupportFund", "");
            dic.Add("NumberOfReports", "");
            pActuarialReport._TaxAndTrade(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Direct Promise Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "TaxTradeReport");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);



            pActuarialReport._SelectTab("IntAcc");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "IFRS Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "IFRSReportEng");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "IFRS Report Set 2");
            dic.Add("iCol", "1");
            dic.Add("sData", "IFRSReportDeu");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "IFRS Report Set 3");
            dic.Add("iCol", "1");
            dic.Add("sData", "USGAAPReport");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "Interest Rate");
            dic.Add("InformationByBreak", "Interest Rate (100% for automatic)");
            dic.Add("iCol", "1");
            dic.Add("sData", "5,17%");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            pActuarialReport._SelectTab("Sensitivity Results");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ValuationNode", "InterestSensitivity 5.42%");
            ////////  dic.Add("Rate", "5,42%");
            pActuarialReport._SensitivityResults(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ValuationNode", "InterestSensitivity 4.92%");
            //////// dic.Add("Rate", "4,92%");
            pActuarialReport._SensitivityResults(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("ValuationNode", "PaySensitivity 2.25%");
            dic.Add("Rate", "2,25%");
            pActuarialReport._SensitivityResults(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("ValuationNode", "PaySensitivity 1.75%");
            dic.Add("Rate", "1,75%");
            pActuarialReport._SensitivityResults(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("ValuationNode", "PensionSensitivity0.25%");
            dic.Add("Rate", "0,50%");
            pActuarialReport._SensitivityResults(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("ValuationNode", "PensionSensitivity-0.25%");
            dic.Add("Rate", "");
            pActuarialReport._SensitivityResults(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Pensionen 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            ////////////////////dic.Add("iMaxColNum", "2");
            ////////////////////dic.Add("iSelectRowNum", "3");
            ////////////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "738");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Pensionen 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            //////////////dic.Add("iMaxColNum", "2");
            //////////////dic.Add("iSelectRowNum", "3");
            //////////////dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "738");
            dic.Add("iPosY", "151");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor, "Direct Promise", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Pensionen2011_CheckSensitivitysInIFRSRepor, "IFRS", "RollForward", true, true, true);


            pMain._SelectTab("Pensionen 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region JubileeValuation - Jubi_2011 - Baseline


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete RollForward Service first");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "false");
            dic.Add("Name", "Jubi_2011");
            dic.Add("Parent", "Conversion 2010");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2011");
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
            dic.Add("ServiceToOpen", "Jubi_2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Jubi_2011");

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
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
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
            dic.Add("SnapshotName", "Snap_Jubi_2011");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "click");
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



            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "9,80");
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_JubiGehalt");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "True");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseCurrentYearPayRateFrom", "PayJubiCurrentYear");
            dic.Add("PayIncreaseAssumption", "AsPI_PayIncreaseRate1");
            pPayoutProjection._PopVerify_PresentYear(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_SvEinkommen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseCurrentYearPayRateFrom", "JubiSvEinkommenCurrentYear");
            dic.Add("PayIncreaseAssumption", "AsPI_PayIncreaseRate1");
            pPayoutProjection._PopVerify_PresentYear(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDPA_Festbetrag");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "");
            dic.Add("Amount_C", "click");
            dic.Add("Amount_cbo", "");
            dic.Add("Amount_txt", "307,0");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JB_EineinhalbMonatsgehalt");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JB_EineinhalbMonatsgehalt");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "True");
            dic.Add("SalaryDefinition", "PP_JubiGehalt");
            dic.Add("DevideBy_V", "");
            dic.Add("DevideBy_C", "Click");
            dic.Add("DevideBy_cbo", "");
            dic.Add("DevideBy_txt", "0,66666667");
            pJubileeBenefit._PopVerify_SalaryBased(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi50");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "Jubi");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi50");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "50");
            dic.Add("BasedOn", "HireDate2");
            dic.Add("YearlySalary", "PP_SvEinkommen");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JB_Monatsgehalt");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "JB_HalbesMonatsgehalt");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "");
            pPlanDefinition_DE._Table(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/13/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Jubi_2011");

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
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayJubiCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "False");
            dic.Add("InternationalAccountingPBO", "False");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "Jubi");
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

            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Test Cases", "Conversion", true, true);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "Jubi" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_Baseline, "Payout Projection", "RollForward", false, true, dic);



            thrd_Jubi2011_Baseline.Start();


            pMain._SelectTab("Jubi_2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region JubileeValuation - Jubi_2011 - NewValuation

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "");
            dic.Add("Provisions_Edit", "");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Jubi_2011");

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
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,14");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pActuarialReport._SelectTab("General");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MecerLocation", "Stuttgart");
            dic.Add("NameToBePrintedOnReportLeft", "Lars Erpenbach");
            dic.Add("AcademicTitleOfPersonLeft", "Diplom-Wirtschaftsmathematiker");
            dic.Add("NameToBePrintedOnReportRight", "Stefan Heinzmann");
            dic.Add("AcademicTitleOfPersonRight", "Diplom-Wirtschaftsmathematiker");
            dic.Add("ExtensionOfUndersigningPersonRight", "+49 711 23716 0");
            dic.Add("LocationOfUndersigningPersonRight", "Stuttgart");
            dic.Add("DoNotAttachTermsAndConditions", "false");
            pActuarialReport._General(dic);


            pActuarialReport._SelectTab("Subsidiary Information");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ClientLongName", "true");
            dic.Add("ClientLongName_txt", "A. & C. KOSIK GmbH");
            dic.Add("ClientShortName", "true");
            dic.Add("ClientShortName_txt", "A. & C. KOSIK GmbH");
            dic.Add("ClientCode", "");
            dic.Add("AddressLine1", "true");
            dic.Add("AddressLine1_txt", "Hirschberger Str. 1");
            dic.Add("City", "true");
            dic.Add("City_txt", "Kelheim");
            dic.Add("PostalCode", "true");
            dic.Add("PostalCode_txt", "93309");
            ////////dic.Add("Country", "true");
            ////////dic.Add("Country_txt", "Deutschland");
            pActuarialReport._SubsidiaryInformation(dic);


            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ReportSetName", "TaxTrade2013");
            dic.Add("ReportType", "Jubilee");
            dic.Add("ReportTemplate", "2018_DEJubilee");
            dic.Add("Listing1", "IFRS default");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ReportSetName", "IFRSGer2013");
            dic.Add("ReportType", "Jubilee IFRS");
            dic.Add("ReportTemplate", "2018_DEJubileeIFRS");
            dic.Add("Listing1", "IFRS default");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("ReportSetName", "IFRSEng2013");
            dic.Add("ReportType", "Jubilee IFRS");
            dic.Add("ReportTemplate", "2018_DEJubileeIFRSEnglish");
            dic.Add("Listing1", "IFRS default");
            pActuarialReport._ReportContents_DefineReportSets(dic);


            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Jubilee Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "TaxTrade2013");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run date");
            dic.Add("iCol", "1");
            dic.Add("sData", "15.12.2011");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run date of last year's report");
            dic.Add("iCol", "1");
            dic.Add("sData", "15.11.2010");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Inventory date");
            dic.Add("iCol", "1");
            dic.Add("sData", "10.10.2011");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Tax is part of report");
            dic.Add("iCol", "1");
            dic.Add("sData", "true");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Trade is part of report");
            dic.Add("iCol", "1");
            dic.Add("sData", "true");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Show only basic results (Trade)");
            dic.Add("iCol", "1");
            dic.Add("sData", "true");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Show complete reconcilation of jubilee expense for Trade");
            dic.Add("iCol", "1");
            dic.Add("sData", "true");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (trade)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Pens+Regel-PA-RV-AAG07");
            dic.Add("sFieldType", "list");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Transition amount liabilities when BilMoG was first applied");
            dic.Add("iCol", "1");
            dic.Add("sData", "29075");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////////////dic.Clear();
            //////////////dic.Add("PopVerify", "Pop");
            //////////////dic.Add("InformationByBreak", "Date when BilMoG is first applied");
            //////////////dic.Add("iCol", "1");
            //////////////dic.Add("sData", "01.01.2010");
            //////////////dic.Add("sFieldType", "date");
            //////////////pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////////dic.Add("InformationByBreak", "Interest rate BilMoG as of previous year");
            dic.Add("InformationByBreak", "Interest Rate Trade as of previous Year (100% for automatic)");
            dic.Add("iCol", "1");
            dic.Add("sData", "5,17%");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "projection rate");
            dic.Add("InformationByBreak", "Projection rate (100 % not to display)");
            dic.Add("iCol", "1");
            dic.Add("sData", "3,00%");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            //////////dic.Add("InformationByBreak", "BBG increase rate");
            dic.Add("InformationByBreak", "BBG increase rate (100% not to display)");
            dic.Add("iCol", "1");
            dic.Add("sData", "3,00%");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);
         
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            dic.Add("iCol", "1");
            dic.Add("sData", "160587");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "LY Book Reserve Trade");
            dic.Add("iCol", "1");
            dic.Add("sData", "160587");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Jubilee awards (incl. contributions and holidays) paid this year");
            dic.Add("iCol", "1");
            dic.Add("sData", "9599");
            dic.Add("sFieldType", "txt");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (tax)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Pens+Regel-PA-RV-AAG07");
            dic.Add("sFieldType", "list");
            pActuarialReport._TaxAndTrade_TBL(dic, true);
               


            pActuarialReport._SelectTab("IntAcc");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Jubilee IFRS Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "IFRSGer2013");
            dic.Add("sFieldType", "list");
            pActuarialReport._TaxAndTrade_TBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Jubilee IFRS Report Set 2");
            dic.Add("iCol", "1");
            dic.Add("sData", "IFRSEng2013");
            dic.Add("sFieldType", "list");
            pActuarialReport._TaxAndTrade_TBL(dic, true);



            pActuarialReport._SelectTab("Sensitivity Results");

            for (int i = 1; i <= 4; i++)
            {

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("iRow", i.ToString());
                dic.Add("ValuationNode", "Using IntAcc Tab Value");
                dic.Add("Rate", "");
                pActuarialReport._SensitivityResults(dic);
            }

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Jubi_2011");

            pMain._Home_ToolbarClick_Top(true);

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
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayJubiCurrentYear");
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
            dic.Add("SelectVOs_VO1", "Jubi");
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


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Jubi_2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liability Set for Globe Export", "RollForward", false, false, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Reconciliation to Baseline", "RollForward", false, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liabilities Detailed Results", "RollForward", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "Jubilee", "RollForward", true, false);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Jubi2011_NewValuation, "IFRS", "RollForward", true, false, true);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputJubilee_Jubi2011_NewValuation_Prod, sOutputJubilee_Jubi2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubi2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Jubi_2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "finished ! !");

        }



        public void t_CompareRpt_Conversion2010(string sOutputPension_Conversion2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputPension_Conversion2010_Prod, sOutputPension_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2010");

                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Pensionen2011_Baseline(string sOutputPension_Pensionen2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputPension_Pensionen2011_Baseline_Prod, sOutputPension_Pensionen2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pensionen2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_All.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_VO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_VO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_VO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 16, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        public void t_CompareRpt_Pensionen2011_NewValuation(string sOutputPension_Pensionen2011_NewValuation)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputPension_Pensionen2011_NewValuation_Prod, sOutputPension_Pensionen2011_NewValuation);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Pensionen2011_NewValuation");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Jubi2010(string sOutputJubilee_Conversion2010)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputJubilee_Conversion2010_Prod, sOutputJubilee_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Conversion2010");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_ALL.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Jubi2011_Baseline(string sOutputJubilee_Jubi2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE006CN", sOutputJubilee_Jubi2011_Baseline_Prod, sOutputJubilee_Jubi2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputJubilee_Jubi2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_All.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollForward_Jubi.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Jubi.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Jubi.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_All.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
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
