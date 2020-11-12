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
using RetirementStudio._UIMaps.AdjustmentsClasses;
// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
// UK screens
using RetirementStudio._UIMaps.InflationClasses;
using RetirementStudio._UIMaps.TrancheDefinitionClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustments_UKClasses;
using RetirementStudio._UIMaps.GMPAdjustmentFactorsClasses;
using RetirementStudio._UIMaps.CommunicationFactorsClasses;
using RetirementStudio._UIMaps.TranchedBenefitClasses;
using RetirementStudio._UIMaps.TranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.NonTranchedBenefitPlanDefinitionClasses;
using RetirementStudio._UIMaps.Methods_UKClasses;
using RetirementStudio._UIMaps.DataSummaryFieldsClasses;
using RetirementStudio._UIMaps.FundingInformation_UKClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ValuationProcessControlClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Oct_UK
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class UK003_CN
    {
        public UK003_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 003 Create New";
            Config.sPlanName = "QA UK Benchmark 003 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory


        public string sOutputFunding_Valuation2014_Baseline = "";
        public string sOutputFunding_Valuation2014_FVGrowthPCT = "";

        public string sOutputFunding_Valuation2014_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\Baseline\7.5_20191208_E\";
        public string sOutputFunding_Valuation2014_FVGrowthPCT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\FV GrowthPCT\7.5_20191208_E\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Create New\Funding\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Valuation2014_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2014_FVGrowthPCT = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\FV GrowthPCT\\" + sPostFix + "\\");
                }
            }


            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2014_Baseline = @\"" + sOutputFunding_Valuation2014_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2014_FVGrowthPCT = @\"" + sOutputFunding_Valuation2014_FVGrowthPCT + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public ValuationProcessControl pValuationProcessControl = new ValuationProcessControl();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public FundingInformation_UK pFundingInformation_UK = new FundingInformation_UK();
        public DataSummaryFields pDataSummaryFields = new DataSummaryFields();
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
        public Adjustments pAdjustments = new Adjustments();

        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
        public TableManager pTableManager = new TableManager();
        public UnitFormula pUnitFormula = new UnitFormula();


        public Inflation pInflation = new Inflation();
        public TrancheDefinition pTrancheDefinition = new TrancheDefinition();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public CostOfLivingAdjustments_UK pCostOfLivingAdjustments_UK = new CostOfLivingAdjustments_UK();
        public GMPAdjustmentFactors pGMPAdjustmentFactors = new GMPAdjustmentFactors();
        public CommunicationFactors pCommunicationFactors = new CommunicationFactors();
        public TranchedBenefit pTranchedBenefit = new TranchedBenefit();
        public TranchedBenefitPlanDefinition pTranchedBenefitPlanDefinition = new TranchedBenefitPlanDefinition();
        public NonTranchedBenefitPlanDefinition pNonTranchedBenefitPlanDefinition = new NonTranchedBenefitPlanDefinition();
        public Methods_UK pMethods_UK = new Methods_UK();





        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_UK003_CN()
        {


            #region MultiThreads

            Thread thrd_Valuation2014_Baseline = new Thread(() => new UK003_CN().t_CompareRpt_Valuation2014_Baseline(sOutputFunding_Valuation2014_Baseline));
            Thread thrd_Valuation2014_FVGrowthPCT = new Thread(() => new UK003_CN().t_CompareRpt_Valuation2014_FVGrowthPCT(sOutputFunding_Valuation2014_FVGrowthPCT));

            #endregion


            this.GenerateReportOuputDir();


            #region Funding - Valuation2014_Baseline

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("", "delete RollForward services fist");




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "Valuation 2014");
            dic.Add("Parent", "Valuation 2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearEndingIn_DE", "2014");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2014");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("LiabilityValuationDate", "01/04/2014");
            dic.Add("Data_AddNew", "true");
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
            dic.Add("OK", "click");
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
            dic.Add("SnapshotName", "2014 in 2 benefit sets_fix pay");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "BasicPay");
            dic.Add("Level_4", "BasicPayPriorYear3");
            pParticipantDataSet._Navigate(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "BasicPay");
            dic.Add("Level_4", "BasicPayPriorYear3");
            dic.Add("Data", "[None]");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._MapField(dic);


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

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"10/09/1951\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"04/01/1946\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data Summary Fields");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Data Summary Fields");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PensionablePay", "BasicPayProjected");
            dic.Add("PensionableService", "PensionableService");
            dic.Add("TransferredinPension", "AddPen");
            dic.Add("AlternatePay1", "BasicPayCurrentYear");
            dic.Add("AlternatePay2", "BasicPayProjected");
            pDataSummaryFields._MemberSummaries_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("PensionablePay", "BasicPayProjected");
            dic.Add("PensionableService", "PensionableService");
            dic.Add("TransferredinPension", "ContribsWInterest1");
            dic.Add("AlternatePay1", "BasicPayCurrentYear");
            dic.Add("AlternatePay2", "BasicPayProjected");
            pDataSummaryFields._MemberSummaries_Actives(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("DeferredPension", "Deferred_Ret_Member");
            dic.Add("PensionableService", "");
            dic.Add("TransferredinPension", "AccruedBenefit1");
            pDataSummaryFields._MemberSummaries_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("DeferredPension", "Deferred_Ret_Member");
            dic.Add("PensionableService", "");
            dic.Add("TransferredinPension", "AccruedBenefit1");
            pDataSummaryFields._MemberSummaries_Deferreds(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("InsuredPen", "Pensioner_Member");
            dic.Add("InsuredSpousePen", "Pensioner_Spouse");
            dic.Add("FundedPen", "Pensioner_Member");
            dic.Add("FundedSpousePen", "Pensioner_Spouse");
            pDataSummaryFields._MemberSummaries_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("InsuredPen", "Pensioner_Member");
            dic.Add("InsuredSpousePen", "Pensioner_Spouse");
            dic.Add("FundedPen", "Pensioner_Member");
            dic.Add("FundedSpousePen", "Pensioner_Spouse");
            pDataSummaryFields._MemberSummaries_Pensions(dic);


            pDataSummaryFields._SelectTab("Benefit Splits");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("AccruedPension", "Active_Ret_Member");
            dic.Add("OtherPension1", "ROCFuture");
            dic.Add("OtherPension2", "ROCPast");
            dic.Add("OtherPension3", "");
            pDataSummaryFields._BenefitSplits_ActivesPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("AccruedPension", "Active_Ret_Member");
            dic.Add("OtherPension1", "ROCFuture");
            dic.Add("OtherPension2", "ROCPast");
            dic.Add("OtherPension3", "ROCPast");
            pDataSummaryFields._BenefitSplits_ActivesPensionSplits(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            ////////////dic.Add("GL_FundingLiabilities", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "DivisionCode");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Test Cases", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Detailed Results", "RollForward", false, true);
            ////////  XLS report <Detailed Results with Ben Type splits> only works in Win7 machine.   NT 6.1 means win7
            ////if (Environment.OSVersion.ToString().Contains("NT 6.1"))
            ////    pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Detailed Results with Ben Type splits", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Payout Projection - Benefit Cashflows", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Payout Projection - Other Info", "RollForward", false, true);


            thrd_Valuation2014_Baseline.Start();


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region  Funding - Valuation2014_FV GrowthPCT

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "FV GrowthPCT");
            dic.Add("LiabilityValuationDate", "01/04/2014");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "FV GrowthPCT Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "New nontranche plan defs");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "5.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "4.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "7.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "6.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.75");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.25");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2014");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);


            pMethods._SelectTab("PPF S179");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2014");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "true");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Precommencement_Pre2009_txt", "0.47");
            dic.Add("Precommencement_Post2009_txt", "1.89");
            dic.Add("Postcommencementrate_txt", "4.96");
            pInterestRate._PopVerify_NonPrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "true");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Postcommencementrate_txt", "2.44");   //// for common object  Post1997increases_txt
            pInterestRate._PopVerify_NonPrescribedRates(dic);


            pMethods._SelectTab("Projection");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "3.00000000");
            pPayIncrease._TimeBased_Table(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.00000000");
            pPayIncrease._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "0.50000000");
            pInflation._CPI_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "1.00000000");
            pInflation._CPI_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "3.00000000");
            pInflation._RPI_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.00000000");
            pInflation._RPI_TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "3.00000000");
            pOtherEconomicAssumption._SalCapInc_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.00000000");
            pOtherEconomicAssumption._SalCapInc_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "4.00000000");
            pOtherEconomicAssumption._S148Inc_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "5.00000000");
            pOtherEconomicAssumption._S148Inc_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "4.00000000");
            pOtherEconomicAssumption._LimGMPRate_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "5.00000000");
            pOtherEconomicAssumption._LimGMPRate_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM01");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "ContribsWInterest1");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac2");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPre88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac3");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "true");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPost88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            pAssumptions._Collapse(dic);




            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac1");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "ContribsWInterest1");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac2");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPre88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac3");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPost88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac4");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac4");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "true");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("NonTranchedBenefit", "Benefit1DB");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data Summary Fields");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Data Summary Fields");

            pDataSummaryFields._SelectTab("Benefit Splits");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_DeferredsPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_DeferredsPensionSplits(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_PensionersPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("OtherPension1", "NonTrInac4");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_PensionersPensionSplits(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", (2014 - 2014 + 2).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2015 - 2014 + 2).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03/13/1982\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/01/1950\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            pFutureValuationOption._SelectTab("Projection years");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "");
            dic.Add("AndEvery", "");
            dic.Add("UpToincludingProjectionYear", "");
            dic.Add("FundingUpdateDate_UK", "01/08/2015");
            pFutureValuationOption._ProjectionYears(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "");
            pFutureValuationOption._PopVerify_OK(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2014");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
            dic.Add("SelectVOs_VO3", "");
            dic.Add("SelectVOs_VO4", "");
            dic.Add("SelectRecords", "");
            dic.Add("Validate", "");
            dic.Add("RunValuation", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("Run Status");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);
            //////////pMain._Home_ToolbarClick_Top(false);

            //////////#endregion


            //////////#region ValuationProcessControl - VPC 2014

            //////////pMain._SelectTab("Home");


            //////////dic.Clear();
            //////////dic.Add("Country", Config.eCountry.ToString());
            //////////dic.Add("Level_1", Config.sClientName);
            //////////dic.Add("Level_2", Config.sPlanName);
            //////////dic.Add("Level_3", "ValuationProcessControl");
            //////////pMain._HomeTreeViewSelect(0, dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("AddServiceInstance", "Click");
            //////////dic.Add("ServiceToOpen", "");
            //////////pMain._PopVerify_Home_RightPane(dic);

            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("Name", "VPC 2014");
            //////////dic.Add("Planyearbegins", "01/04/2014");
            //////////dic.Add("Planyearends", "31/03/2015");
            //////////dic.Add("Valuationdate", "01/04/2014");
            //////////dic.Add("Outsidestudio", "true");
            //////////dic.Add("Fundingservice", "Valuation 2014");
            //////////dic.Add("OK", "click");
            //////////pValuationProcessControl._AddNewService(dic);



            //////////pValuationProcessControl._OpenVPC("VPC 2014");


            //////////pMain._SelectTab("VPC 2014");

            //////////dic.Clear();
            //////////dic.Add("Level_1", "Phase");
            //////////dic.Add("Level_2", "Planning");
            //////////dic.Add("Level_3", "Basis");
            //////////pValuationProcessControl._TreeViewSelect(dic, true);


            //////////_gLib._KillProcessByName("EXCEL");
            //////////MyExcel _excel = new MyExcel(@"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK003\MSVPCheckLists_Planning_0429\Basis_Planning.xlsx", true);
            //////////_excel.OpenExcelFile(1);

            //////////_gLib._MsgBox("", "Please accurately paste values into current system, then close excel");

            //////////pMain._Home_ToolbarClick_Top(true);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("ExportCheckListstoExcel", "Click");
            //////////dic.Add("FileName", sOutputFunding_Valuation2014_FVGrowthPCT + "BasicPlanning.zip");
            //////////dic.Add("Save", "click");
            //////////pValuationProcessControl._ExportCheckListstoExcel(dic);

            //////////pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2014_FV - FundingInformation

            ////pMain._SelectTab("Home");

            ////dic.Clear();
            ////dic.Add("Level_1", Config.sClientName);
            ////dic.Add("Level_2", Config.sPlanName);
            ////dic.Add("Level_3", "FundingValuations");
            ////pMain._HomeTreeViewSelect(0, dic);

            ////dic.Clear();
            ////dic.Add("PopVerify", "Pop");
            ////dic.Add("AddServiceInstance", "");
            ////dic.Add("ServiceToOpen", "Valuation 2014");
            ////pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Funding Information");


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VPCServiceContainingBasis", "VPC 2014");
            pFundingInformation_UK._RegularValuation_GeneralParameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Data Movements");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "15");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "2");
            dic.Add("Col2", "1");
            dic.Add("Col3", "3");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "4");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "-4");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-2");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "");
            dic.Add("Col2", "-2");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Col1", "-2");
            dic.Add("Col2", "");
            dic.Add("Col3", "-2");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);


            pFundingInformation_UK._SelectTab("Deferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "16");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "2");
            dic.Add("Col2", "3");
            dic.Add("Col3", "1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "4");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "-2");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-4");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "");
            dic.Add("Col2", "");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);


            pFundingInformation_UK._SelectTab("Pensioners");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "45");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "");
            dic.Add("Col2", "2");
            dic.Add("Col3", "5");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "5");
            dic.Add("Col2", "3");
            dic.Add("Col3", "6");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "3");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "2");
            dic.Add("Col2", "3");
            dic.Add("Col3", "2");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "-5");
            dic.Add("Col2", "-4");
            dic.Add("Col3", "-5");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Data Summaries");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ThisValuation", "FV GrowthPCT");
            dic.Add("LastValuation", "Baseline");
            pFundingInformation_UK._RegularValuation_DataSummaries(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Assets");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2014Assets");
            pFundingInformation_UK._RegularValuation_Assets_Snapshot_TableSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IntervaluationPeriodContribution_Employer", "3.20");
            dic.Add("IntervaluationPeriodContribution_Employee", "");
            dic.Add("IntervaluationPeriodPension_DataAwarded", "02/01/2013");
            pFundingInformation_UK._RegularValuation_Assets(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "2.4%");
            dic.Add("Col2", "3.0%");
            dic.Add("Col3", "1.3%");
            pFundingInformation_UK._RegularValuation_Assets_RateofPensionIncrease_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "3.0%");
            dic.Add("Col2", "2.0%");
            dic.Add("Col3", "2.5%");
            pFundingInformation_UK._RegularValuation_Assets_EnvestermentReport(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "5.0%");
            dic.Add("Col2", "4.0%");
            dic.Add("Col3", "3.0%");
            pFundingInformation_UK._RegularValuation_Assets_EnvestermentReport(dic);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Liabilities");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ValuationNode", "Copy of PFVS");
            dic.Add("LiabilityType", "Funding");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund1");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund2");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund3");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "Funding");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "Solvency");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "PPF_S179");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund1");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund2");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund3");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(dic);



            pFundingInformation_UK._SelectTab("FSM Sensitivities");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFSMSensitivities", "click");
            pFundingInformation_UK._RegularValuation_Liabilities_FSMSensitivities(dic);


            pFundingInformation_UK._SelectTab("Miscellaneous Adjustments");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "ActAdj");
            dic.Add("Value_P", "12.00");
            dic.Add("Value_C", "");
            dic.Add("ApplytoPast", "true");
            dic.Add("ApplytoFuture", "true");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "DefAdj");
            dic.Add("Value_C", "2,000");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "PenAdj");
            dic.Add("Value_P", "5.00");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Benefit Splits");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ThisValuation", "FV GrowthPCT");
            dic.Add("LastValuation", "Baseline");
            pFundingInformation_UK._RegularValuation_DataSummaries(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Results Summary");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingInsurance_Fixed_rd", "true");
            dic.Add("FundingInsurance_Fixed_txt", "7.00");
            pFundingInformation_UK._RegularValuation_ResultsSummary(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Reports");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SFOResults", "This Time Val");
            dic.Add("LastTimesResults", "Last Time Val");
            dic.Add("SolvencyResults", "Solvency");
            dic.Add("PPFResults", "PPF");
            dic.Add("Actives", "456,700");
            dic.Add("Deferreds", "233,444");
            dic.Add("Pensioners", "899,900");
            dic.Add("Expenses", "250,000");
            dic.Add("SalaryIncreaseforStayers", "3.0");
            pFundingInformation_UK._RegularValuation_Reports_Liabilities(dic);


            pFundingInformation_UK._SelectTab("Recovery plan");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/04/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/07/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/10/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Amount", "260,000");
            dic.Add("Date", "01/12/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);



            pFundingInformation_UK._SelectTab("Sensitivities");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preretiremrnt", "789,000");
            dic.Add("Pstretirement", "765,000");
            dic.Add("Inflation", "24,300");
            dic.Add("SalaryGrowth", "45,000");
            dic.Add("Mortality", "78,699");
            dic.Add("EquityMarkets", "12,500");
            dic.Add("GiltYields", "25,600");
            pFundingInformation_UK._RegularValuation_Reports_Sensitivities(dic);


            pFundingInformation_UK._SelectTab("AOS");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Description", "Expected interest");
            dic.Add("Value", "789,999.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Description", "Excess employer conts");
            dic.Add("Value", "240,000.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Description", "Excess investment return");
            dic.Add("Value", "12,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Description", "Excess salary increases");
            dic.Add("Value", "150,000.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Description", "Excess pension increases");
            dic.Add("Value", "7,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Description", "Benefit changes");
            dic.Add("Value", "2,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Description", "Impact of merger");
            dic.Add("Value", "9,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Description", "Miscellaneous");
            dic.Add("Value", "34,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("Description", "Financial conditions");
            dic.Add("Value", "9,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("Description", "Change in approach to setting financial assumptions");
            dic.Add("Value", "78,888.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "11");
            dic.Add("Description", "Improved life expectancy");
            dic.Add("Value", "23,333.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "12");
            dic.Add("Description", "Commutation assumptions");
            dic.Add("Value", "89,999.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            pMain._Home_ToolbarClick_Top(true);


            pFundingInformation_UK._SelectTab("Projections");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingSurplus", "896,000");
            dic.Add("FundingLevel", "4");
            dic.Add("SolvencyShortfall", "33,333");
            dic.Add("Solvencylevel", "3");
            pFundingInformation_UK._RegularValuation_Reports_Projection(dic);


            pFundingInformation_UK._SelectTab("Inv strategy");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Value", "24.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Value", "11.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Value", "15.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Value", "9.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Value", "10.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Value", "12.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Value", "5.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Value", "4.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("AssetCategory", "Taxable Recoverable");
            dic.Add("Value", "6.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_OtherAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("AssetCategory", "Property");
            dic.Add("Value", "4.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_OtherAsset_Table(dic);


            pFundingInformation_UK._SelectTab("PPF S179 cert");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NameofSection", "ABC");
            dic.Add("SchemeRegistrationNumber", "111-222-333");
            dic.Add("SchemeAddressLine1", "544 Scheme Address");
            dic.Add("Line2", "Suite 300A");
            dic.Add("Line3", "Scheme Address, IL 60061");
            dic.Add("Line4", "");
            dic.Add("GuidanceUsed", "Gui");
            dic.Add("AssumptionUsed", "GAM");
            dic.Add("ExternalLiabilities", "7,860,000");
            dic.Add("ActivesInsured", "26");
            dic.Add("DeferredsInsured", "46");
            pFundingInformation_UK._RegularValuation_Reports_PPFS179Cert(dic);


            pFundingInformation_UK._SelectTab("General info");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SchemeActuary", "Jane Smiyh");
            dic.Add("ConsultingOfficeAddressLine1", "Mercer");
            dic.Add("Line2", "544 Lakeview Parkway");
            dic.Add("Line3", "Suite 300");
            dic.Add("Line4", "Vernon Hills, IL 60061");
            dic.Add("EmployerName", "ABC company");
            dic.Add("CurrencyUnit", "£ 000's");
            pFundingInformation_UK._RegularValuation_Reports_GeneralInfo(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Liabilities and Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Scenario", "Last Time Val");
            dic.Add("ValuationNode", "Copy of PFVS");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "7,338,990");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Scenario", "Regular Val Funding");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Scenario", "Regular Val PPF (BL)");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "PPF_S179");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Scenario", "Regular Val Solv (BL)");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Solvency");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Scenario", "FU Funding");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Scenario", "FU Solv");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "Solvency");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Scenario", "FU PPF");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "PPF_S179");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Scenario", "FU AltFd1");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund1");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("Scenario", "FU AltFd2");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund2");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("Scenario", "FU AltFd3");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund3");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);


            pFundingInformation_UK._SelectTab("Adjustment for liability related cashflows");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "20,000");
            dic.Add("Col2", "11,111");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "1,000");
            dic.Add("Col2", "1,111");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "100");
            dic.Add("Col2", "200");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "450,000");
            dic.Add("Col2", "200,100");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "4.25");
            dic.Add("Col2", "");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);


            pFundingInformation_UK._SelectTab("Miscellaneous Adjustments");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "A1");
            dic.Add("Value_P", "1.0");
            dic.Add("Value_C", "");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "A2");
            dic.Add("Value_C", "10,000");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "A3");
            dic.Add("Value_P", "2.00");
            dic.Add("ApplytoFuture", "false");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "A4");
            dic.Add("Value_P", "3.00");
            dic.Add("Value_ClickC", "");
            dic.Add("ApplytoPast", "false");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "A5");
            dic.Add("Value_C", "-1,000");
            dic.Add("ApplytoPast", "false");
            dic.Add("ApplytoFuture", "false");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "D1");
            dic.Add("Value_P", "1.10");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "D2");
            dic.Add("Value_C", "11,000");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "D3");
            dic.Add("Value_P", "-2.20");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "D4");
            dic.Add("Value_P", "3.30");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "D5");
            dic.Add("Value_C", "-22,000");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "P1");
            dic.Add("Value_C", "11,100");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "P2");
            dic.Add("Value_P", "1.11");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "P3");
            dic.Add("Value_P", "-2.22");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "P4");
            dic.Add("Value_C", "-22,200");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "P5");
            dic.Add("Value_P", "3.33");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Results Summary");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingExpenses_Fixed_rd", "");
            dic.Add("FundingInsurance_Fixed_rd", "");
            dic.Add("Solvency_Fixed_rd", "");
            dic.Add("FundingExpenses_Fixed_txt", "2.50");
            dic.Add("FundingInsurance_Fixed_txt", "");
            dic.Add("Solvency_Fixed_txt", "");
            dic.Add("Actives", "18");
            dic.Add("Deferreds", "13");
            dic.Add("PensionersUnder60", "10");
            dic.Add("Pensioners6069", "26");
            dic.Add("Pensioners7079", "14");
            dic.Add("PensionersOver80", "9");
            pFundingInformation_UK._RegularValuation_ResultsSummary(dic);



            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Reports");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentUpdateFunding", " FU Funding");
            dic.Add("CurrentUpdateSolvency", " FU Solv");
            dic.Add("CurrentUpdatePPF", " FU PPF");
            dic.Add("LastFullValuation", " Regular Val Funding");
            dic.Add("SolvencyFundingLevel", "77");
            pFundingInformation_UK._FundingUpdate_Reports(dic);


            pFundingInformation_UK._SelectTab("Experience");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EmployeeContributionRate", "3.2");
            dic.Add("EmployerContributionRate", "5.0");
            dic.Add("FTSEAllShareTRI_PreviousUpdate", "3.56");
            dic.Add("FTSEAllShareTRI_CurrentUpdate", "2.45");
            dic.Add("FTGovtFixed_PreviousUpdate", "2.10");
            dic.Add("FTGovtFixed_CurrentUpdate", "0.55");
            dic.Add("FTGovIL_PreviousUpdate", "1.23");
            dic.Add("FTGovIL_CurrentUpdate", "1.20");
            dic.Add("IBoxxCorpBondAA_PreviousUpdate", "2.1234");
            dic.Add("IBoxxCorpBondAA_CurrentUpdate", "0.3451");
            dic.Add("DurationForGiltYields_PreviousUpdate", "12.1");
            dic.Add("FixedGiltYield_PreviousUpdate", "1.00");
            dic.Add("FixedGiltYield_CurrentUpdate", "3.45");
            dic.Add("IndexLinkedGilt_PreviousUpdate", "3.10");
            dic.Add("IndexLinkedGilt_CurrentUpdate", "0.45");
            dic.Add("ImpliedInflation_PreviousUpdate", "1.23");
            dic.Add("ImpliedInflation_CurrentUpdate", "3.10");
            dic.Add("AssetReturn", "-2.11");
            pFundingInformation_UK._FundingUpdate_Reports_Experience(dic);



            pFundingInformation_UK._SelectTab("Basis");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InvestmentReturnPre_PreviousUpdate", "1.45");
            dic.Add("InvestmentReturnPre_CurrentUpdate", "4.00");
            dic.Add("InvestmentReturnPost_PreviousUpdate", "2.45");
            dic.Add("InvestmentReturnPost_CurrentUpdate", "2.30");
            dic.Add("InflationRPI_PreviousUpdate", "0.56");
            dic.Add("InflationRPI_CurrentUpdate", "1.30");
            dic.Add("InflationCPI_PreviousUpdate", "1.40");
            dic.Add("InflationCPI_CurrentUpdate", "2.34");
            dic.Add("SalaryGrowth_PreviousUpdate", "3.00");
            dic.Add("SalaryGrowth_CurrentUpdate", "4.00");
            dic.Add("DeferredRevaluation_PreviousUpdate", "2.34");
            dic.Add("DeferredRevaluation_CurrentUpdate", "1.20");
            dic.Add("PensionIncrease5_0_PreviousUpdate", "1.34");
            dic.Add("PensionIncrease5_0_CurrentUpdate", "5.00");
            dic.Add("PensionIncrease2_5_PreviousUpdate", "2.34");
            dic.Add("PensionIncrease2_5_CurrentUpdate", "2.50");
            dic.Add("MortalityBaseTable_PreviousUpdate", "Mort1");
            dic.Add("MortalityBaseTable_CurrentUpdate", "Mort2");
            dic.Add("MortalityFutureImprovements_PreviousUpdate", "AA projection scale");
            dic.Add("MortalityFutureImprovements_CurrentUpdate", "XX projection scale");
            pFundingInformation_UK._FundingUpdate_Reports_Basis(dic);


            pFundingInformation_UK._SelectTab("General Info");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AssetMethod", "Roll forward using index returns");
            dic.Add("AOSMethod", "Last full valuation");
            dic.Add("VARChartMethod", "Surplus/Shortfall");
            dic.Add("ConsultingOfficeAddressLine1", "Mercer");
            dic.Add("Line2", "1 University Square Drive");
            dic.Add("Line3", "Suite 100");
            dic.Add("Line4", "Princeton, NJ 08540 USA");
            dic.Add("TelephoneNumber", "+1 609 520 2500");
            dic.Add("SFPDate", "01/04/2014");
            dic.Add("NextFullValuationDate", "01/04/2017");
            dic.Add("CurrencyUnit", "£ 000's");
            pFundingInformation_UK._FundingUpdate_Reports_GeneralInfo(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Valuation2014_FV - Reports

            pMain._SelectTab("Valuation 2014");

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
            pMain._PopVerify_FundingCalculationRunCompleted_UK(dic);



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Update Calculations");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            _gLib._Wait(10);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Benefit Cashflows", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Other Info", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results", "RollForward", false, true);

            ////////////  XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine.   NT 6.1 means win7
            ////if (Environment.OSVersion.ToString().Contains("NT 6.1"))
            ////    pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results with Ben Type splits", "RollForward", false, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Population Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_FVPayouts_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Results Summary", "RollForward", false, true);


            thrd_Valuation2014_FVGrowthPCT.Start();

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Checking Spreadsheet", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Consulting Spreadsheet", "RollForward", false, true);
          
            
            //////////////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results with Ben Type splits", "RollForward", false, true);
            _gLib._MsgBox("", "XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine," + Environment.NewLine + Environment.NewLine
                + "please mannually click and download <Liabilities Detailed Results with Ben Type splits>, if process not complete please ship because bug not fixed.");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Valuation Report", 3);

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, false, "Silver");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, true, "Silver");


            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("!", "Finished!");

        }



        void t_CompareRpt_Valuation2014_Baseline(string sOutputFunding_Valuation2014_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003CN", sOutputFunding_Valuation2014_Baseline_Prod, sOutputFunding_Valuation2014_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2014_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPFS179.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBenTypesplits.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Valuation2014_FVGrowthPCT(string sOutputFunding_Valuation2014_FVGrowthPCT)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003CN", sOutputFunding_Valuation2014_FVGrowthPCT_Prod, sOutputFunding_Valuation2014_FVGrowthPCT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2014_FVGrowthPCT");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPFS179.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPF.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2014-liabilityvaluationdate.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2015-liabilityvaluationdate+1year.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2016-liabilityvaluationdate+2year.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);

                _compareReportsLib.CompareExcel_Exact("FundingUpdateResultsSummary.xlsx", 4, 0, 0, 0, true);
                ////////////////_compareReportsLib.CompareExcel_Exact("FundingCalculator-CheckingSpreadsheet.xlsm", 4, 0, 0, 0, true);
                ////////////////_compareReportsLib.CompareExcel_Exact("FundingCalculator-ConsultingSpreadsheet.xlsm", 4, 0, 0, 0, true);
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
