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




namespace RetirementStudio._TestScripts_2019_Oct_US
{
    /// <summary>
    /// Summary description for US011_CN
    /// </summary>
    [CodedUITest]
    public class US011_CN
    {
        public US011_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.US;
            Config.sClientName = "QA US Benchmark 011 Create New";
            Config.sPlanName = "QA US Benchmark 011 Create New Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputFunding_val2018_Baseline = "";
        public string sOutputFunding_val2018_UpdateAssumptionsfor2018 = "";
        public string sOutputFunding_val2018_PlanAmendment = "";
        public string sOutputFunding_val2018_ForAFTAP = "";
        public string sOutputFunding_valJuly2019_Baseline = "";
        public string sOutputFunding_valJuly2019_UpdateAssumptions = "";
        public string sOutputFunding_valJuly2019_UpdateProvisions = "";
        public string sOutputFunding_valJuly2019_AFTAP = "";
        public string sOutputFunding_valJuly2019_updateFIForASOP51 = "";
        public string sOutputAccounting_July2018FASVal_Baseline = "";
        public string sOutputAccounting_July2018FASVal_UpdateAssumptions = "";
        public string sOutputAccounting_July2018FASVal_UpdateCashBalance = "";


        public string sOutputFunding_val2018_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 2018\Baseline\7.5_20191201_Franklin\";
        public string sOutputFunding_val2018_UpdateAssumptionsfor2018_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 2018\update assumptions for 2018\7.5_20191201_Franklin\";
        public string sOutputFunding_val2018_PlanAmendment_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 2018\plan amendment\7.5_20191201_Franklin\";
        public string sOutputFunding_val2018_ForAFTAP_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 2018\for AFTAP\7.5_20191201_Franklin\";
        public string sOutputFunding_valJuly2019_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\Baseline\7.5_20191201_Franklin\";
        public string sOutputFunding_valJuly2019_UpdateAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\update assumptions for 2019\7.5_20191201_Franklin\";
        public string sOutputFunding_valJuly2019_UpdateProvisions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\update provisions for 2019\7.5_20191201_Franklin\";
        public string sOutputAccounting_July2017FASVal_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\July 2017 FAS Val\7.5_20191201_Franklin\";
        public string sOutputAccounting_July2018FASVal_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\July 2018 FAS Val\Baseline\7.5_20191201_Franklin\";
        public string sOutputAccounting_July2018FASVal_UpdateAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\July 2018 FAS Val\Update Assumptions\7.5_20191201_Franklin\";
        public string sOutputAccounting_July2018FASVal_UpdateCashBalance_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\July 2018 FAS Val\Update Cash Balance\7.5_20191201_Franklin\";
        public string sOutputFunding_valJuly2019_updateFIForASOP51_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_11_Nebraska\Production\val 7.1.2019\update FI for ASOP 51\7.5_20191201_Franklin\";


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

                    sOutputFunding_val2018_Baseline = _gLib._CreateDirectory(sMainDir + "val 2018\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_val2018_UpdateAssumptionsfor2018 = _gLib._CreateDirectory(sMainDir + "val 2018\\Update assumptions for 2018\\" + sPostFix + "\\");
                    sOutputFunding_val2018_PlanAmendment = _gLib._CreateDirectory(sMainDir + "val 2018\\Plan amendment\\" + sPostFix + "\\");
                    sOutputFunding_val2018_ForAFTAP = _gLib._CreateDirectory(sMainDir + "val 2018\\For AFTAP\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_Baseline = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_UpdateAssumptions = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update assumptions for 2019\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_UpdateProvisions = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update provisions for 2019\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_AFTAP = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\AFTAP\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_Baseline = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Baseline\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_UpdateAssumptions = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Update Assumptions\\" + sPostFix + "\\");
                    sOutputAccounting_July2018FASVal_UpdateCashBalance = _gLib._CreateDirectory(sMainDir + "July 2018 FAS Val\\Update Cash Balance\\" + sPostFix + "\\");
                    sOutputFunding_valJuly2019_updateFIForASOP51 = _gLib._CreateDirectory(sMainDir + "val 7.1.2019\\update FI for ASOP 51\\" + sPostFix + "\\");

                }

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_val2018_Baseline = @\"" + sOutputFunding_val2018_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_UpdateAssumptionsfor2018 = @\"" + sOutputFunding_val2018_UpdateAssumptionsfor2018 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_PlanAmendment = @\"" + sOutputFunding_val2018_PlanAmendment + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_val2018_ForAFTAP = @\"" + sOutputFunding_val2018_ForAFTAP + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_Baseline = @\"" + sOutputFunding_valJuly2019_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_UpdateAssumptions = @\"" + sOutputFunding_valJuly2019_UpdateAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_UpdateProvisions = @\"" + sOutputFunding_valJuly2019_UpdateProvisions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_AFTAP = @\"" + sOutputFunding_valJuly2019_AFTAP + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_Baseline = @\"" + sOutputAccounting_July2018FASVal_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_UpdateAssumptions = @\"" + sOutputAccounting_July2018FASVal_UpdateAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputAccounting_July2018FASVal_UpdateCashBalance = @\"" + sOutputAccounting_July2018FASVal_UpdateCashBalance + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_valJuly2019_updateFIForASOP51 = @\"" + sOutputFunding_valJuly2019_updateFIForASOP51 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);
        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public FundingInformation_ASOP51 pFundingInformation_ASOP51 = new FundingInformation_ASOP51();
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
        public ASC960Reconciliation pASC960Reconciliation = new ASC960Reconciliation();
        public AnnualFundingNotice pAnnualFundingNotice = new AnnualFundingNotice();


        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void _test_US011_CN()
        {

             
            #region MultiThreads


            Thread thrd_Funding_val2018_Baseline = new Thread(() => new US011_CN().t_CompareRpt_Funding_val2018_Baseline(sOutputFunding_val2018_Baseline));
            Thread thrd_Funding_val2018_UpdateAssumptionsfor2018 = new Thread(() => new US011_CN().t_CompareRpt_Funding_val2018_UpdateAssumptionsfor2018(sOutputFunding_val2018_UpdateAssumptionsfor2018));
            Thread thrd_Funding_val2018_PlanAmendment = new Thread(() => new US011_CN().t_CompareRpt_Funding_val2018_PlanAmendment(sOutputFunding_val2018_PlanAmendment));
            Thread thrd_Funding_val2018_ForAFTAP = new Thread(() => new US011_CN().t_CompareRpt_Funding_val2018_ForAFTAP(sOutputFunding_val2018_ForAFTAP));
            Thread thrd_Funding_valJuly2019_Baseline = new Thread(() => new US011_CN().t_CompareRpt_Funding_valJuly2019_Baseline(sOutputFunding_valJuly2019_Baseline));
            Thread thrd_Funding_valJuly2019_UpdateAssumptions = new Thread(() => new US011_CN().t_CompareRpt_Funding_valJuly2019_UpdateAssumptions(sOutputFunding_valJuly2019_UpdateAssumptions));
            Thread thrd_Funding_valJuly2019_UpdateProvisions = new Thread(() => new US011_CN().t_CompareRpt_Funding_valJuly2019_UpdateProvisions(sOutputFunding_valJuly2019_UpdateProvisions));
            Thread thrd_Accounting_July2018FASVal_Baseline = new Thread(() => new US011_CN().t_CompareRpt_Accounting_July2018FASVal_Baseline(sOutputAccounting_July2018FASVal_Baseline));
            Thread thrd_Accounting_July2018FASVal_UpdateAssumptions = new Thread(() => new US011_CN().t_CompareRpt_Accounting_July2018FASVal_UpdateAssumptions(sOutputAccounting_July2018FASVal_UpdateAssumptions));


            #endregion


            this.GenerateReportOuputDir();


            #region val 2018 - Baseline node


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete RollForward service");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "val 2018");
            dic.Add("Parent", "val 2017");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2018");
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
            dic.Add("ServiceToOpen", "val 2018");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("val 2018");

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
            dic.Add("MethodsLiabilities_AddNew", "");
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

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("val 2018");

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
            dic.Add("DataEffectiveDate", "01/01/2018");
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "data2018");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "01/01/2018");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "False");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._SelectTab("Participant DataSet");


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


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

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_Baseline, "Payout Projection", "RollForward", false, true);


            thrd_Funding_val2018_Baseline.Start();

            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region val 2018 - update assumptions for 2018

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update assumptions for 2018");
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
            dic.Add("LiabilityType", "PPA");
            dic.Add("ReasonforChange", "Change in assumed mortality");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "PBGC");
            dic.Add("ReasonforChange", "Change in interest rate");
            dic.Add("OK", "");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            pMain._SelectTab("val 2018");

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
            dic.Add("Level_3", "PBGCint");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "04/01/2018");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "04/01/2018");
            pInterestRate._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "pretransrate");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "pretransrate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "posrtransrate");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "posrtransrate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.25");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "FAS35mort");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "PPABASE06CMFMP16G");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "AllOthers");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "07/01/2018");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");

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
            dic.Add("Rates", "pretransrate");
            dic.Add("CreditingPeriod", "");
            dic.Add("CreditingFrequency", "");
            pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ForAges", "");
            dic.Add("Rates", "posrtransrate");
            dic.Add("CreditingPeriod", "");
            dic.Add("CreditingFrequency", "");
            pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

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

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_UpdateAssumptionsfor2018, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);


            thrd_Funding_val2018_UpdateAssumptionsfor2018.Start();


            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);

            #endregion



            #region val 2018 - plan amendment

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "plan amendment");
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
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in plan provisions");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "atriskflag");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "atriskflag");
            dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "atriskliab");
            dic.Add("EAN", "");
            dic.Add("FAS35PVAB", "");
            dic.Add("FAS35PVVB", "");
            dic.Add("Nondiscrimination", "");
            dic.Add("PBGCARPVVB", "True");
            dic.Add("PBGCNARPVVB", "");
            dic.Add("PBGCPlanTerm", "");
            dic.Add("PPAARMax", "True");
            dic.Add("PPAARMin", "True");
            dic.Add("PPAARPVVB", "True");
            dic.Add("PPANARMax", "");
            dic.Add("PPANARMin", "");
            dic.Add("PPANARPVVB", "");
            dic.Add("Projection", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "atriskflag");
            dic.Add("Level_4", "atriskliab");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "Click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "100.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "VestElig");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "VestElig");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Service>=5");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Special Eligibilities");
            dic.Add("Level_3", "_ARRet");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Simple", "True");
            dic.Add("Advanced", "");
            dic.Add("Simple_PreDefinedEligibility", "ERD");
            dic.Add("Advance_txtBox", "");
            dic.Add("Advance_Validate", "");
            pSpecialEligibilities._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Special Eligibilities");
            dic.Add("Level_3", "_ARImmWth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Simple", "True");
            dic.Add("Advanced", "");
            dic.Add("Simple_PreDefinedEligibility", "VestElig");
            dic.Add("Advance_txtBox", "");
            dic.Add("Advance_Validate", "");
            pSpecialEligibilities._PopVerify_Main(dic);

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
            pFAEFormula._TBL_Offset_updateToAge_US011(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0.005");
            dic.Add("sData4", "0.0075");
            dic.Add("sData5", "0.015");
            pFAEFormula._TBL_Offset_updateToAge_US011(dic);

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

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "AtRiskAdj");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "AtRiskAdj");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1.0");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit after 415 application");
            pAdjustments._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "AtRiskAdj");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1.575");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit after 415 application");
            pAdjustments._PopVerify_Main(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "_AREligInPeriod");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetire");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CBAccount");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "RetireeCOLA");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetire");
            dic.Add("Level_4", "ERD");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "RetireeCOLA");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVWith");
            dic.Add("Level_4", "notERD");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB1");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB2");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB3");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB4");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB5");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB6");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB1F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB2F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB3F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB4F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB5F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetCB6F");
            dic.Add("Level_4", "reteligandSal");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AtRiskAdj");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

 

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);


            ////Please take care of this screen, the values selected may be changed as blank after FC run, need double check!!!
            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2017");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2017");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2017");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            dic.Add("LateQuarterlyContribution", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2017");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "2017");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            _gLib._MsgBox("", "make sure MinimumRequiredContribution,ContributedByPBGC and IncludeInPrefundingCreditBalance were selected Yes in all rows, and LateQuarterlyContribution was set to Yes in row 3");



            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MarketValue", "");
            dic.Add("Average", "");
            dic.Add("Custom", "true");
            pFundingInformation._PopVerify_ActuarialValueOfAssets_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ActuarialValueOfAssets", "133,535,987");
            dic.Add("ApplyMarketValueCorridor", "");
            pFundingInformation._PopVerify_ActuarialValueOfAssets_Custom(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "07/01/2018");
            dic.Add("PlanYearEndDate", "06/30/2019");
            dic.Add("CurrentYareNumOfParcipants", "502");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "07/01/1955");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CompanyName", "");
            dic.Add("Telephone", "");
            dic.Add("AddressLine1", "One University Square Drive");
            dic.Add("AddressLine2", "Suite 100");
            dic.Add("AddressLine3", "Princeton NJ 08540");
            dic.Add("Signer1Name", "JoAnn");
            dic.Add("Signer1Credential", "ASA MAAA");
            dic.Add("Signer2Name", "");
            dic.Add("Signer2Credential", "");
            dic.Add("PeerReviewName", "Derek");
            dic.Add("PeerReviewCredentials", "FSA MAAA");
            dic.Add("RoundingScalingOptions_Thousands69470000", "");
            pFundingInformation._PopVerify_GI_ActuarialReport(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Prior Year Results");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "");
            dic.Add("ShortfallAmortizationCharge", "820,296");
            dic.Add("FullFundingLimit", "6,775,746");
            dic.Add("MinimumBeforeUseOfCreditBalance", "820,296");
            dic.Add("EffectiveInterestRateLastYear", "5.99");
            pFundingInformation_PYR_SummaryView._PopVerify_MinimumContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AtRiskProng1", "80.57");
            dic.Add("AtRiskProng2", "65.00");
            dic.Add("AdjustedFTAP", "55.55");
            dic.Add("ConsecutiveYearsAtRisk", "2");
            dic.Add("AtRiskPercentageReflectedInMinimumFunidng", "56.88");
            dic.Add("AtRiskIn2OfPrior4Years", "Yes");
            pFundingInformation_PYR_SummaryView._PopVerify_FTAP(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MarketValue", "32,058,195");
            dic.Add("ActuarialValue", "33,535,987");
            pFundingInformation_PYR_SummaryView._PopVerify_Assets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COBAfterWaiver", "");
            dic.Add("PFBAfterWaiver", "-5,432,906");
            dic.Add("NetAssetsForFundingShortfall", "28,103,081");
            dic.Add("FundingShortfallAmount", "6,775,746");
            dic.Add("TransitionPercentage", "100.00");
            dic.Add("TransitionFundingTargetLiability", "34,878,827");
            dic.Add("TransitionFundingShortfall", "6,775,746");
            pFundingInformation_PYR_SummaryView._PopVerify_NetAssets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BeginningOfTheYearBalance", "107,992");
            pFundingInformation_PYR_SummaryView._PopVerify_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingTarget", "34,878,827");
            dic.Add("CushionAmount", "17,439,414");
            dic.Add("PreliminaryDeductibleAmount", "25,516,102");
            dic.Add("MaximumDeductibleAmount", "25,516,102");
            pFundingInformation_PYR_SummaryView._PopVerify_MaximumDeductibleContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGCParticipantCount", "440");
            dic.Add("PBGCFlatRatePremiumPerParticipant", "64");
            dic.Add("PBGCFlatRatePremium", "28,160");
            dic.Add("PBGCTargetLiability", "41,229,829");
            dic.Add("UnfundedPBGCTargetLiability", "9,172,000");
            dic.Add("VariableRatePremium", "220,000");
            dic.Add("CombinedPBGCPremium", "248,160");
            pFundingInformation_PYR_SummaryView._PopVerify_PBGCPremiumsAndFillingRequirements(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InactivesInPayStatus", "154");
            dic.Add("InactivesInDefStatus", "228");
            dic.Add("VestedActives", "58");
            dic.Add("Total", "440");
            dic.Add("OfParticipantsInAllControlledGroupPlans", "440");
            pFundingInformation_PYR_SummaryView._PopVerify_ParticipantData(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "True");
            ////////////dic.Add("TabName", "Preliminary Results and PBGC Premiums");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);


            ////Pls take care of the dates section, some objects could not identify

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OriginalPlanEffectDate", "07/01/1955");
            dic.Add("BeginningOfPlanYear", "07/01/2017");
            dic.Add("EndOfPlanYear", "06/30/2018");
            dic.Add("ValuationDate", "07/01/2017");
            dic.Add("ValuationYear", "2017");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InactivesInPayStatus", "");
            dic.Add("InactivesDeferredStatus", "");
            dic.Add("VestedStatus", "");
            dic.Add("NonVestedStatus", "0");
            dic.Add("Total", "");
            dic.Add("TotalPlanParticipants", "");
            dic.Add("NumOfParticipants", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_Data(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PirorYearNum", "440");
            dic.Add("Prong1Determination", "85.00");
            dic.Add("Prong1Threshold", "80.00");
            dic.Add("Prong2Determination", "");
            dic.Add("Prong2Threshold", "70.00");
            dic.Add("PlanIsAtRisk", "");
            dic.Add("IncludesExpenseLoad", "");
            dic.Add("ConsecutiveYears", "");
            dic.Add("FTReflects", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_AtRiskDetermination(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "19,929,762");
            dic.Add("DeferredStatus", "8,766,655");
            dic.Add("VestedActives", "6,133,134");
            dic.Add("NonVestedActives", "49,276");
            dic.Add("Total", "34,878,827");
            dic.Add("NormalCost", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_NotAtRisk(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InPayStatus", "19,929,762");
            dic.Add("DeferredStatus", "8,766,655");
            dic.Add("VestedActives", "6,133,134");
            dic.Add("NonVestedActives", "49,276");
            dic.Add("Total", "");
            dic.Add("Discounted", "");
            dic.Add("Expected", "");
            dic.Add("DiscountedExpected", "");
            dic.Add("NormalCost", "");
            dic.Add("TotalNormalCost", "");
            dic.Add("EffectiveInterestRate", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_FundingTarget(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NotAtRiskLiability", "41,612,675");
            dic.Add("ExpenseLoad", "");
            dic.Add("AtRiskLiabilityNoExpense", "");
            dic.Add("AtRiskLiabilityWithExpense", "");
            dic.Add("FinalAtRisk", "");
            dic.Add("FundingTarget", "41,612,675");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_MDC(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PBGCFlatRate_ParticipantCount", "");
            dic.Add("PBGCFlatRate_PerParticipant", "");
            dic.Add("PBGCFlatRate_FlatRatePremium", "");
            dic.Add("NotAtRisk_InPayStatus", "22,885,286");
            dic.Add("NotAtRisk_DeferredStatus", "10,906,734");
            dic.Add("NotAtRisk_VestedActives", "7,437,809");
            dic.Add("NotAtRisk_Total", "41,229,829");
            dic.Add("ExpenseLoad_InPayStatus", "");
            dic.Add("ExpenseLoad_DeferredStatus", "");
            dic.Add("ExpenseLoad_VestedActives", "");
            dic.Add("ExpenseLoad_Total", "");
            dic.Add("AtRiskNoExpense_InPayStatus", "");
            dic.Add("AtRiskNoExpense_DeferredStatus", "");
            dic.Add("AtRiskNoExpense_VestedActives", "");
            dic.Add("AtRiskNoExpense_Total", "");
            dic.Add("AtRiskWithExpense_InPayStatus", "");
            dic.Add("AtRiskWithExpense_DeferredStatus", "");
            dic.Add("AtRiskWithExpense_VestedActives", "");
            dic.Add("AtRiskWithExpense_Total", "");
            dic.Add("FinalAtRisk_InPayStatus", "");
            dic.Add("FinalAtRisk_DeferredStatus", "");
            dic.Add("FinalAtRisk_VestedActives", "");
            dic.Add("FinalAtRisk_Total", "");
            dic.Add("PBGCTarget_InpayStatus", "22,885,286");
            dic.Add("PBGCTarget_DeferredStatus", "10,906,734");
            dic.Add("PBGCTarget_VestedActives", "7,437,809");
            dic.Add("PBGCTarget_Total", "");
            dic.Add("PBGCTarget_MVofAssets", "32,058,195");
            dic.Add("PBGCVariable_Unfunded", "");
            dic.Add("PBGCVariable_9Per1000", "220,000");
            dic.Add("PBGCVariable_NumOfEE", "");
            dic.Add("PBGCVariable_ParticipantCount", "");
            dic.Add("PBGCVariable_PerParticipant", "");
            dic.Add("PBGCVariable_PBGCVariable", "");
            dic.Add("PBGCVariable_CombinedPBGC", "");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PGBCPremiums(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BalanceAtBegining", "");
            dic.Add("PortionUsed", "");
            dic.Add("InterestUsingPriorYrsActualReturn", "-1,361");
            dic.Add("AmountRemaining", "106,631");
            dic.Add("PriorYrsExcess", "5,015,325");
            dic.Add("InterestOnAmount", "310,950");
            dic.Add("InterestUsingPriorYrsEffectiveRate", "310,950");
            dic.Add("TotalAvailableAtBegin", "5,326,275");
            dic.Add("PortionToBeAdded", "5,326,275");
            dic.Add("BalanceAtBOY", "5,432,906");
            dic.Add("VoluntaryReduction", "");
            dic.Add("DeemedWaivers", "");
            dic.Add("BOYBalance", "5,432,906");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Liability_Actuarial", "33,425,655");
            dic.Add("Liability_NormalCost", "");
            dic.Add("Liability_Interest", "2,072,391");
            dic.Add("Benefits_BenefitPayments", "2,112,696");
            dic.Add("Benefits_Administrative", "");
            dic.Add("Benefits_EmployeeContrib", "");
            dic.Add("Benefits_Total", "2,112,696");
            dic.Add("Benefits_ExpectedActuarial", "33,385,350");
            dic.Add("Benefits_LiabilityGL", "-1,493,477");
            dic.Add("Asset_ActuarialAsset", "28,481,975");
            dic.Add("Asset_InterestOnActuarial", "1,765,827");
            dic.Add("Asset_ContributionsMade", "5,846,834");
            dic.Add("Asset_InterestOnContrib", "44,970");
            dic.Add("Asset_ExpectedActuarial", "34,026,010");
            dic.Add("Asset_ActuarialAssetGL", "-490,023");
            dic.Add("Asset_ActuarialGL", "-1,983,500");
            pFundingInformation_PYR_PreliminaryResults._PopVerify_DevelopmentOfExperienceGL(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "FTAPs, Benefit Restrictions, and At-Risk Determination");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVOfAssets", "");
            dic.Add("90ofMarketValue", "33,535,987");
            dic.Add("110ofMarketValue", "28,852,987");
            dic.Add("PreliminaryActuarial", "35,264,014");
            dic.Add("ActuarialValue", "");
            dic.Add("AVAPFB", "28,103,081");
            dic.Add("AVACOBPFB", "28,103,081");
            dic.Add("Prior2YearsNHC", "");
            dic.Add("AVANHCPurchase", "33,535,987");
            dic.Add("AVACOBPFBNHCPurchase", "28,103,081");
            dic.Add("NARFundLiabNHCPurchase", "34,878,827");
            pFundingInformation_FTAPs._PopVerify_AssetNumbers(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FTAP", "");
            dic.Add("FTAP_PFB", "80.57");
            dic.Add("FTAP_Exempt", "96.14");
            dic.Add("FTAP_AtRisk", "");
            dic.Add("FTAP_SB_PFB", "80.57");
            dic.Add("FTAP_SB_NoPFB", "96.14");
            pFundingInformation_FTAPs._PopVerify_FTAPs(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ElectionToUse", "Yes");
            dic.Add("ShortfallFunded", "");
            dic.Add("EligibleForTransition", "");
            dic.Add("ExemptFrom2007AFC", "");
            dic.Add("2008", "80.57");
            dic.Add("2009", "79.16");
            dic.Add("2010", "60.98");
            dic.Add("IsPlanExempt", "");
            pFundingInformation_FTAPs._PopVerify_ShortfallBaseExemption(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentYearTop25", "91.91");
            dic.Add("CurrentYear401", "76.33");
            dic.Add("CanUseCOB", "80.57");
            dic.Add("QuarterlyContrib", "80.57");
            dic.Add("PBGC4010", "80.57");
            pFundingInformation_FTAPs._PopVerify_OtherFTAPChecks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Prong1", "80.00");
            dic.Add("Prong2", "70.00");
            dic.Add("PlanIsAtRiskNextYear", "Yes");
            dic.Add("PlanAtRiskPriorYear1", "Yes");
            dic.Add("PlanAtRiskPriorYear2", "Yes");
            dic.Add("NumOfYears", "2");
            dic.Add("ExpenseLoad", "");
            dic.Add("NextYearConsecutive", "");
            dic.Add("FTNextYear", "");
            pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AFTAPBefore", "");
            dic.Add("IncreaseTo60", "");
            dic.Add("IncreaseTo80", "");
            dic.Add("RequiredCredit", "");
            dic.Add("FinalAFTAP_TotalWaiver", "");
            dic.Add("FinalAFTAP_FinalAFTAP", "80.57");
            pFundingInformation_FTAPs._PopVerify_PreliminaryAFTAPCalcuations(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FullyFundedPriorYear2009FTAP", "80.43%");
            dic.Add("FullyFundedPriorYear2010FTAP", "75.78%");
            dic.Add("FullyFundedCYExemption", "100.00");
            dic.Add("FullyFundedFTAPCYFTAP_Exempt", "96.14");
            dic.Add("FinalAFTAPCalculationFinalAFTAP", "80.57");
            dic.Add("ShutDownAmountNeededTo60Percent", "");
            dic.Add("PlanAmendmentNeededTo80Percent", "");
            dic.Add("AcceleratedBenefitDistriAllowed", "None");
            dic.Add("LimitationFundingCharge", "");
            dic.Add("AddtitionalFundingToAvoid", "");
            dic.Add("PresumedCurrentYrsTreatPlan", "");
            dic.Add("PresumedCurrentYrsIn3Months", "84.88");
            dic.Add("PresumedCurrentYrsIn6Months", "74.88");
            dic.Add("PresumedCurrentYrsAfter9Months", "");
            dic.Add("PresumedNextYrsIn3Months", "80.57");
            dic.Add("PresumedNextYrsIn6Months", "70.57");
            dic.Add("PresumedNextYrsAfter9Months", "");
            pFundingInformation_FTAPs._PopVerify_BenefitRestributionsDeterminations(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Shortfall");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PY5Base", "2,324,917");
            dic.Add("PY4Base", "2,970,027");
            dic.Add("PY3Base", "-1,254,303");
            dic.Add("PY2Base", "1,302,595");
            dic.Add("PY1Base", "-189,451");
            dic.Add("PYBase", "-319,733");
            dic.Add("Total", "4,834,052");
            pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsShortfallBases(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NewBaseAmount", "1,941,694");
            dic.Add("YearsForShortfall", "7");
            dic.Add("AmortizationFactor", "6.05241");
            dic.Add("ShortfallAmortizationInstallment", "320,813");
            dic.Add("TotalSAI", "499,483");
            dic.Add("ShortfallAmortizationCharge", "820,296");
            pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsFundingWaiverBases(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "4.43");
            dic.Add("CY1", "4.43");
            dic.Add("CY2", "4.43");
            dic.Add("CY3", "4.43");
            dic.Add("CY4", "4.43");
            dic.Add("CY5", "5.91");
            dic.Add("CY6", "5.91");
            dic.Add("CY7", "5.91");
            dic.Add("CY8", "5.91");
            dic.Add("CY9", "5.91");
            pFundingInformation_Shortfall._PopVerify_InterestRatesByYear(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CY", "1.00000");
            dic.Add("CY1", "0.95758");
            dic.Add("CY2", "0.91696");
            dic.Add("CY3", "0.87806");
            dic.Add("CY4", "0.84081");
            dic.Add("CY5", "0.75044");
            dic.Add("CY6", "0.70856");
            dic.Add("CY7", "0.66902");
            dic.Add("CY8", "0.63169");
            dic.Add("CY9", "0.59644");
            pFundingInformation_Shortfall._PopVerify_DiscountFactors(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PY5_Amount", "316,181");
            dic.Add("PY4_Amount", "373,609");
            dic.Add("PY3_Amount", "-436,349");
            dic.Add("PY2_Amount", "347,118");
            dic.Add("PY1_Amount", "-41,244");
            dic.Add("PY_Amount", "-59,832");
            dic.Add("PY5_RemainingYrs", "9");
            dic.Add("PY4_RemainingYrs", "10");
            dic.Add("PY3_RemainingYrs", "3");
            dic.Add("PY2_RemainingYrs", "4");
            dic.Add("PY1_RemainingYrs", "5");
            dic.Add("PY_RemainingYrs", "6");
            pFundingInformation_Shortfall._PopVerify_PriorYrsShortfallAmortizationInstallments(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Year1", "1.00000");
            dic.Add("Year2", "1.95758");
            dic.Add("Year3", "2.87454");
            dic.Add("Year4", "3.75260");
            dic.Add("Year5", "4.59341");
            dic.Add("Year6", "5.34385");
            dic.Add("Year7", "6.05241");
            dic.Add("Year8", "6.72143");
            dic.Add("Year9", "7.35312");
            dic.Add("Year10", "7.94956");
            pFundingInformation_Shortfall._PopVerify_AmortizationFactors(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "");
            dic.Add("TabName", "Contribution Summary");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "820,296");
            dic.Add("FullFundingLimit", "6,775,746");
            dic.Add("MininumBefore", "820,296");
            pFundingInformation_ContributionSummary._PopVerify_MinimumRequiredContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Cushion_50ofFunding", "17,439,414");
            dic.Add("Cushion_FTIncrease", "6,733,848");
            dic.Add("Cushion_DeductionLimit", "");
            dic.Add("Alternate_DeductionLimit", "");
            dic.Add("Alternate_MaximumDeductible", "");
            dic.Add("Interest_EarlierOf", "12/31/2016");
            dic.Add("Interest_Fractional", "1.000000");
            dic.Add("Interest_InterestTo", "1,528,415");
            dic.Add("Interest_MaximumDeductible", "27,044,517");
            pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingShortfall", "5,052,572");
            dic.Add("AmountPriorMRC", "532,412");
            dic.Add("AmountCurrentMRC", "738,266");
            dic.Add("QuaterlyAmount", "133,103");
            dic.Add("ShortfallCurrentYear", "Yes");
            dic.Add("QuaterlyAmountNextYear", "205,074");
            dic.Add("ContribtionDates_FirstQuarterly", "04/15/2016");
            dic.Add("ContribtionDates_SecondQuarterly", "07/15/2016");
            dic.Add("ContribtionDates_ThirdQuarterly", "10/15/2016");
            dic.Add("ContribtionDates_FourthQuarterly", "01/15/2015");
            dic.Add("ContribtionDates_FinalPayment", "09/15/2017");
            dic.Add("YearAndDaysFourthQuterly_Years", "1");
            dic.Add("YearAndDaysFinalPayment_Years", "1");
            dic.Add("YearAndDaysFirstQuaterly_Days", "105");
            dic.Add("YearAndDaysSecondQuaterly_Days", "196");
            dic.Add("YearAndDaysThirdQuaterly_Days", "288");
            dic.Add("YearAndDaysFourthQuaterly_Days", "14");
            dic.Add("YearAndDaysFinalPayment_Days", "257");
            dic.Add("YearAndDaysRemainingAmount", "340,019");
            dic.Add("DiscountedContributionFirstQuaterly", "130,900");
            dic.Add("DiscountedContributionSecondQuaterly", "129,020");
            dic.Add("DiscountedContributionThirdQuaterly", "127,147");
            dic.Add("DiscountedContributionFourthQuaterly", "125,301");
            dic.Add("DiscountedContributionFinalPayment", "307,928");
            dic.Add("DiscountedContributionAvailableCredits", "820,296");
            dic.Add("CYContributionsFirstQuaterly", "");
            dic.Add("CYContributionsSecondQuaterly", "");
            dic.Add("CYContributionsThirdQuaterly", "");
            dic.Add("CYContributionsFourthQuaterly", "");
            dic.Add("CYContributionsFinalPayment", "");
            dic.Add("BeginningOf_FirstQuarterly", "130,900");
            dic.Add("BeginningOf_SecondQuarterly", "129,020");
            dic.Add("BeginningOf_ThirdQuarterly", "127,147");
            dic.Add("BeginningOf_FourthQuarterly", "125,301");
            dic.Add("BeginningOf_FinalPayment", "307,928");
            pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



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

            _gLib._MsgBox("go back to Funding Information ->Contribution screen", "make sure MinimumRequiredContribution,ContributedByPBGC and IncludeInPrefundingCreditBalance were selected Yes in all rows, and LateQuarterlyContribution was set to Yes in row 3");


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Funding Calculator Scenario", "RollForward", false, true);
            //////////////pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Liability Scenario", "RollForward", false, true);
            //////////////pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_PlanAmendment, "Funding Calculator", "RollForward", false, true);


            thrd_Funding_val2018_PlanAmendment.Start();

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 2018");
            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Mark as Final Node");
            pMain._FlowTreeRightSelect(dic);

            #endregion

            #region val 2018 - for AFTAP

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "for AFTAP");
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
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "AllOthers");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "07/01/2019");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            pMain._SelectTab("val 2018");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalProj");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "");
            dic.Add("PayIncreaseAssumption", "");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "true");
            dic.Add("txtSpecifiedYear", "2018");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_val2018_ForAFTAP, "Liability Scenario by Plan Def", "RollForward", false, true);


            thrd_Funding_val2018_ForAFTAP.Start();


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
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", "val 7.1.2019");
            dic.Add("Parent", "val 2018");
            dic.Add("ParentFinalValuationSet", "plan amendment");
            dic.Add("PlanYearBeginningIn", "2019");
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
            dic.Add("ServiceToOpen", "val 7.1.2019");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Roll Forward");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "set 415 limit");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("Snapshot", "True");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("CompareData", "false");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


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
            dic.Add("SnapshotName", "data2019");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
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
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "Click");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalProj");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "");
            dic.Add("PayIncreaseAssumption", "");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "true");
            dic.Add("txtSpecifiedYear", "2018");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Individual Checking Template", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Age Service Matrix", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Data Comparison", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Data Matching Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Combined Status Code Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Decrement Age", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Gain / Loss Participant Listing", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_Baseline, "Payout Projection", "RollForward", false, true);


            pMain._SelectTab("val 7.1.2019");

            pMain._GenerateNewReport(sOutputFunding_valJuly2019_Baseline, "Report Appendices", 2);

            thrd_Funding_valJuly2019_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region  val 7.1.2019 - update assumptions for 2019


            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update assumptions for 2019");
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
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._ValuationNodeProperties_ChangeReasons_Initialize();


            dic.Clear();
            dic.Add("LiabilityType", "FAS 35");
            dic.Add("ReasonforChange", "Change in actuarial assumptions");
            dic.Add("OK", "Click");
            pMain._ValuationNodeProperties_ChangeReasons(dic);


            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("Level_3", "FAS35int");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5.75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "PBGCint");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AllOthers");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "AllOthers");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "07/01/2019");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("val 7.1.2019");

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




            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


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

            pMain._Home_ToolbarClick_Top(true);


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

            pMain._Home_ToolbarClick_Top(true);


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

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("iRow", "5");
            dic.Add("Date", "08/15/2019");
            dic.Add("Category", "Cash");
            dic.Add("Amount", "5,200,000");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "#1#");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Date", "03/02/2020");
            dic.Add("Category", "Cash");
            dic.Add("Amount", "22,000,000");
            dic.Add("PlanYear", "2018");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "Yes");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "#1#");
            dic.Add("ContributedByPBGC", "Yes");
            dic.Add("IncludeInPrefundingCreditBalance", "Yes");
            pFundingInformation._Contributions_Employer(dic);

            pMain._Home_ToolbarClick_Top(true);

            _gLib._MsgBox("", "make sure all MinimumRequiredContribution and IncludeInPrefundingCreditBalance were selected Yes");


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Actuarial Value of Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MarketValue", "");
            dic.Add("Average", "true");
            dic.Add("Custom", "");
            pFundingInformation._PopVerify_ActuarialValueOfAssets_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanYearBeginDate", "07/01/2019");
            dic.Add("PlanYearEndDate", "06/30/2020");
            dic.Add("CurrentYareNumOfParcipants", "502");
            dic.Add("YearsForShortfallAmortization", "");
            pFundingInformation._PopVerify_GI_GeneralInformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_CarryoverBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VoluntaryCOB", "0");
            dic.Add("ApplyCalculated_Yes", "True");
            dic.Add("ApplyCalculated_No", "");
            dic.Add("ClientDecision_Yes", "");
            dic.Add("ClientDecision_No", "True");
            dic.Add("ClientDecision_Unknown", "");
            dic.Add("PBGCAgreement_Yes", "");
            dic.Add("PBGCAgreement_No", "True");
            dic.Add("PBGCAgreement_Unknown", "");
            pFundingInformation._PopVerify_GI_PrefundingBalance(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanSponsor_Yes", "");
            dic.Add("PlanSponsor_No", "True");
            dic.Add("PlanSponsor_Unknown", "");
            dic.Add("IncreaseDueToPlanAmendment", "0");
            dic.Add("ExemptFrom_Yes", "");
            dic.Add("ExemptFrom_No", "True");
            dic.Add("ExemptFrom_Unknown", "");
            dic.Add("IncreaseDueToShutdown", "0");
            dic.Add("OriginalPlanEffectiveDate", "");
            dic.Add("PlanWasFrozen_Yes", "");
            dic.Add("PlanWasFrozen_No", "True");
            dic.Add("PlanWasFrozen_Unknown", "");
            pFundingInformation._PopVerify_GI_BenefitRestriction(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Prior Year Results");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TargetNormalCost", "");
            dic.Add("ShortfallAmortizationCharge", "");
            dic.Add("FullFundingLimit", "");
            dic.Add("MinimumBeforeUseOfCreditBalance", "");
            dic.Add("EffectiveInterestRateLastYear", "");
            dic.Add("EffectiveInterestRate2YearsAgo", "");
            dic.Add("EffectiveInterestRate3YearsAgo", "5.23");
            pFundingInformation_PYR_SummaryView._PopVerify_MinimumContribution(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SummaryView", "");
            dic.Add("DetailView", "true");
            dic.Add("TabName", "FTAPs, Benefit Restrictions, and At-Risk Determination");
            pFundingInformation._PopVerify_PriorYearResults_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Prong1", "");
            dic.Add("Prong2", "");
            dic.Add("PlanIsAtRiskNextYear", "Yes");
            dic.Add("PlanAtRiskPriorYear1", "Yes");
            dic.Add("PlanAtRiskPriorYear2", "Yes");
            dic.Add("NumOfYears", "");
            dic.Add("ExpenseLoad", "");
            dic.Add("NextYearConsecutive", "");
            dic.Add("FTNextYear", "");
            pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "ASC 960 Reconciliation");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "ASC 960 Reconciliation Inputs");
            dic.Add("Level_2", "Prior Year");
            pASC960Reconciliation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MarketValueOfAssets_chk", "true");
            dic.Add("MarketValueOfAssets", "132,058,195");
            pASC960Reconciliation._PopVerify_PY_AssetData(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




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

            _gLib._MsgBox("go back to Funding Information ->Contribution screen", "make sure Plan Year=2018 for all 6 rows,and all MinimumRequiredContribution and IncludeInPrefundingCreditBalance were selected Yes; the Contributed by PBGC.. for row 5 and row 6 values are Yes ");


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

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "Funding Calculator", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateAssumptions, "ASC 960 Reconciliation", "RollForward", false, true);



            pMain._SelectTab("val 7.1.2019");

            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateAssumptions, "PPA Funding Valuation Report", 3);
            pMain._GenerateNewReport(sOutputFunding_valJuly2019_UpdateAssumptions, "ASC 960 Letter", 3);

            thrd_Funding_valJuly2019_UpdateAssumptions.Start();

            pMain._SelectTab("val 7.1.2019");
            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region val 7.1.2019 - update provisions for 2019

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update provisions for 2019");
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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

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
            dic.Add("MenuItem_1", "Annual Funding Notice");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

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


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputFunding_valJuly2019_UpdateProvisions, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_UpdateProvisions, "Funding Calculator Scenario", "RollForward", false, true);
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

            #region val 7.1.2019 - AFTAP


            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "AFTAP");
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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            //////////dic.Clear();
            //////////dic.Add("PopVerify", "Pop");
            //////////dic.Add("IAgreeToUnlock", "True");
            //////////dic.Add("OK", "Click");
            //////////pMain._PopVerify_CascadingUnlock(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Contributions");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "#1#");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "#1#");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "#1#");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "#1#");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "#1#");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "#1#");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "");
            pFundingInformation._Contributions_Employer(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "");
            dic.Add("Amount", "");
            dic.Add("PlanYear", "#1#");
            dic.Add("TaxYear", "");
            dic.Add("MinimumRequiredContribution", "#1#");
            dic.Add("DeductedButNotIncluded", "");
            dic.Add("IncludedButNotDeducted", "");
            dic.Add("ContributedByPBGC", "");
            dic.Add("IncludeInPrefundingCreditBalance", "");
            pFundingInformation._Contributions_Employer(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Calculations");
            dic.Add("Level_2", "Estimated Liabilities");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseEstimatedLiabilities", "true");
            dic.Add("FundingService", "val 2018");
            dic.Add("ValuationNode", "for AFTAP");
            dic.Add("EstimatedGL", "-1.07");
            dic.Add("KnownWorkforceChanges", "2.00");
            dic.Add("Other", "0.45");
            pFundingInformation._PopVerify_EstimatedLiabilities(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("val 7.1.2019");

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
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);


            pMain._SelectTab("val 7.1.2019");

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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            ////////dic.Clear();
            ////////dic.Add("PopVerify", "Pop");
            ////////dic.Add("RemoveAll", "");
            ////////dic.Add("AddAll", "Click");
            ////////dic.Add("Node", "");
            ////////dic.Add("Add", "");
            ////////dic.Add("ShowSubtotalBreaks", "");
            ////////dic.Add("OK", "Click");
            ////////pOutputManager._PopVerify_OutputManagerSetup(dic);



            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_AFTAP, "Funding Calculator", "RollForward", false, true);


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("val 7.1.2019");

            pMain._GenerateNewReport(sOutputFunding_valJuly2019_AFTAP, "AFTAP Range Certification", 3);

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Val 7.1.2019 - update FI for ASOP 51

            pMain._SelectTab("val 7.1.2019");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "4");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "update FI For ASOP51");
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
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            pMain._SelectTab("val 7.1.2019");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);



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

            pMain._Home_ToolbarClick_Top(true);



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

            pMain._Home_ToolbarClick_Top(true);



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
            pMain._Home_ToolbarClick_Top(true);


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

            _gLib._MsgBox("", "please make sure all MinimumRequiredContribution and IncludeInPrefundingCreditBalance were select Yes");


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

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "5");
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
            dic.Add("iSelectRowNum", "5");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputFunding_valJuly2019_updateFIForASOP51, "Funding Calculator Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputFunding_valJuly2019_updateFIForASOP51, "Funding Calculator", "RollForward", false, true);


            _gLib._MsgBox("", "please manually compare the FC excel file");

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Accounting - July 2018 FAS Val - Baseline node


            //pMain._SelectTab("Home");


            //dic.Clear();
            //dic.Add("Level_1", Config.sClientName);
            //dic.Add("Level_2", Config.sPlanName);
            //dic.Add("Level_3", "AccountingValuations");
            //pMain._HomeTreeViewSelect(0, dic);


            //_gLib._MsgBox("", "please delete RollForward service");


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("AddServiceInstance", "Click");
            //dic.Add("ServiceToOpen", "");
            //pMain._PopVerify_Home_RightPane(dic);




            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ConversionService", "");
            //dic.Add("Name", "July 2018 FAS Val");
            //dic.Add("Parent", "July 2017 FAS Val");
            //dic.Add("ParentFinalValuationSet", "");
            //dic.Add("PlanYearBeginningIn", "");
            //dic.Add("FiscalYearEndingIn_Accounting", "2018");
            //dic.Add("FirstYearPlanUnderPPA", "");
            //dic.Add("RSC", "");
            //dic.Add("LocalMarket", "");
            //dic.Add("Shared", "");
            //dic.Add("OK", "Click");
            //dic.Add("Cancel", "");
            //pMain._PopVerify_Home_ServicePropeties(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("AddServiceInstance", "");
            //dic.Add("ServiceToOpen", "July 2018 FAS Val");
            //pMain._PopVerify_Home_RightPane(dic);

            //pMain._SelectTab("July 2018 FAS Val");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "1");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Roll Forward");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ValNodeName", "");
            //dic.Add("LiabilityValuationDate", "");
            //dic.Add("Data_AddNew", "True");
            //dic.Add("Data_Name", "Baseline Data");
            //dic.Add("Data_Edit", "");
            //dic.Add("Assumptions_AddNew", "");
            //dic.Add("Assumptions_Name", "");
            //dic.Add("Assumptions_Edit", "");
            //dic.Add("MethodsLiabilities_AddNew", "");
            //dic.Add("MethodsLiabilities_Name", "");
            //dic.Add("MethodsLiabilities_Edit", "");
            //dic.Add("Provisions_AddNew", "");
            //dic.Add("Provisions_Name", "");
            //dic.Add("Provisions_Edit", "");
            //dic.Add("FundingInformation_AddNew", "");
            //dic.Add("FundingInformation_Name", "");
            //dic.Add("FundingInformation_Edit", "");
            //dic.Add("OK", "Click");
            //dic.Add("Cancel", "");
            //pMain._PopVerify_ValuationNodeProperties(dic);


            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Data");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._SelectTab("Participant DataSet");

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("DataEffectiveDate", "01/01/2018");
            //dic.Add("Snapshot", "True");
            //dic.Add("GRSUnload", "");
            //dic.Add("GotoDataSystem", "Click");
            //dic.Add("AddField", "");
            //dic.Add("GRSInformation", "");
            //dic.Add("ImportDataandApplyMapping", "");
            //pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("SnapshotName", "data2018");
            //dic.Add("OK", "Click");
            //dic.Add("RetainThePreviousUnload", "");
            //dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            //dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            //dic.Add("SpecifyANewUnload", "");
            //dic.Add("SelectSnapshotOption_OK", "Click");
            //pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("DataEffectiveDate", "");
            //dic.Add("Snapshot", "");
            //dic.Add("GRSUnload", "");
            //dic.Add("GotoDataSystem", "");
            //dic.Add("AddField", "");
            //dic.Add("GRSInformation", "");
            //dic.Add("CompareData", "false");
            //dic.Add("ImportDataandApplyMapping", "");
            //dic.Add("CheckVOImportPopup", "");
            //pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("DataEffectiveDate", "");
            //dic.Add("Snapshot", "");
            //dic.Add("GRSUnload", "");
            //dic.Add("GotoDataSystem", "");
            //dic.Add("AddField", "");
            //dic.Add("GRSInformation", "");
            //dic.Add("CompareData", "");
            //dic.Add("ImportDataandApplyMapping", "Click");
            //pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            //pMain._SelectTab("Participant DataSet");

            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Acc_GL_PBO", "");
            //dic.Add("Acc_GL_ABO", "True");
            //dic.Add("GL_PPANAR_Min", "");
            //dic.Add("GL_PPANAR_Max", "");
            //dic.Add("GL_EAN", "");
            //dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //dic.Add("PayoutProjection", "True");
            //dic.Add("IncludeIOE", "True");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "True");
            //dic.Add("IncludeGainLossResult", "True");
            //dic.Add("Service", "CreditedService");
            //dic.Add("Pay", "SalProj");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("CashBanlance", "Cbal");
            //dic.Add("Pension", "Benefit1DB");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Acc_ProjectedBenefitObligation", "True");
            //dic.Add("Acc_AccumulatedBenefitObligation", "True");
            //dic.Add("PayoutProjectionCustomGroup", "");
            //dic.Add("RunValuation", "Click");
            //dic.Add("OK", "");
            //pMain._PopVerify_RunOptions(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);


            //pMain._EnterpriseRun("Group Job Successfully Complete with 2 NP", true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            ////////////dic.Clear();
            ////////////dic.Add("PopVerify", "Pop");
            ////////////dic.Add("RemoveAll", "");
            ////////////dic.Add("AddAll", "Click");
            ////////////dic.Add("Node", "");
            ////////////dic.Add("Add", "");
            ////////////dic.Add("ShowSubtotalBreaks", "");
            ////////////dic.Add("OK", "Click");
            ////////////pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Test Cases", "RollForward", true, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Reconciliation to Prior Year", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Detailed Results", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Detailed Results by Plan Def", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Status Reconciliation", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Member Statistics", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Individual Checking Template", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Age Service Matrix", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Data Matching Summary", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Combined Status Code Summary", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Status Reconciliation", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Summary of Liability Reconciliation", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Active Decrement Gain / Loss Detail", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Decrement Age", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Gain / Loss Participant Listing", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Valuation Summary", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Individual Output", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "IOE", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Payout Projection", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_Baseline, "Liability Set for Globe Export", "RollForward", false, false);


            //thrd_Accounting_July2018FASVal_Baseline.Start();

            //pMain._SelectTab("July 2018 FAS Val");
            //pMain._Home_ToolbarClick_Top(true);

            //#endregion

            //#region Accounting - July 2018 FAS Val - update assumptions

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Add Valuation Node");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ValNodeName", "update assumptions");
            //dic.Add("LiabilityValuationDate", "");
            //dic.Add("Data_AddNew", "");
            //dic.Add("Data_Name", "");
            //dic.Add("Data_Edit", "");
            //dic.Add("Assumptions_AddNew", "True");
            //dic.Add("Assumptions_Name", "");
            //dic.Add("Assumptions_Edit", "");
            //dic.Add("MethodsLiabilities_AddNew", "");
            //dic.Add("MethodsLiabilities_Name", "");
            //dic.Add("MethodsLiabilities_Edit", "");
            //dic.Add("Provisions_AddNew", "True");
            //dic.Add("Provisions_Name", "");
            //dic.Add("Provisions_Edit", "");
            //dic.Add("FundingInformation_AddNew", "");
            //dic.Add("FundingInformation_Name", "");
            //dic.Add("FundingInformation_Edit", "");
            //dic.Add("OK", "Click");
            //dic.Add("Cancel", "");
            //pMain._PopVerify_ValuationNodeProperties(dic);

            //pMain._SelectTab("July 2018 FAS Val");


            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Assumptions");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._SelectTab("Assumptions");

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Interest Rate");
            //dic.Add("Level_3", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PrescribedRates", "");
            //dic.Add("SameStructureForAllPeriods", "");
            //dic.Add("TimeBased", "");
            //dic.Add("PercentIcon", "");
            //dic.Add("TIcon", "");
            //dic.Add("txtRate", "5.25");
            //dic.Add("cboRate", "");
            //pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Custom Rates");
            //dic.Add("Level_3", "cbrate");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PrescribedRates", "");
            //dic.Add("SameStructureForAllPeriods", "");
            //dic.Add("TimeBased", "");
            //dic.Add("PercentIcon", "");
            //dic.Add("TIcon", "");
            //dic.Add("txtRate", "3.75");
            //dic.Add("cboRate", "");
            //pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Pay Increase");
            //dic.Add("Level_3", "salscale");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("btnV", "");
            //dic.Add("btnPercent", "");
            //dic.Add("btnT", "Click");
            //dic.Add("txtRate", "");
            //dic.Add("cboRate", "");
            //dic.Add("cboRate_T", "testsalscale");
            //pPayIncrease._PopVerify_PayIncrease(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Mortality Decrement");
            //dic.Add("Level_3", "_Death");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Mortality", "PPABASE06CMFMP16G");
            //dic.Add("Mortality_Setback_M", "");
            //dic.Add("Mortality_Setback_F", "");
            //dic.Add("Disabled", "");
            //dic.Add("Disabled_Setback_M", "");
            //dic.Add("Disabled_Setback_F", "");
            //pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            //pMain._Home_ToolbarClick_Top(true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Provisions");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._SelectTab("Provisions");

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Actuarial Equivalence");
            //dic.Add("Level_3", "LumpSumActEq");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("txtInterestRate", "");
            //dic.Add("cboInterestRate", "");
            //dic.Add("AsOfDate", "05/01/2018");
            //dic.Add("Mortality", "PPA2018CMF");
            //pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);

            //pMain._Home_ToolbarClick_Top(true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("GL_PPANAR_Min", "");
            //dic.Add("GL_PPANAR_Max", "");
            //dic.Add("GL_EAN", "");
            //dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //dic.Add("PayoutProjection", "True");
            //dic.Add("IncludeIOE", "True");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "True");
            //dic.Add("IncludeGainLossResult", "");
            //dic.Add("Service", "CreditedService");
            //dic.Add("Pay", "SalProj");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("CashBanlance", "Cbal");
            //dic.Add("Pension", "Benefit1DB");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Acc_ProjectedBenefitObligation", "True");
            //dic.Add("Acc_AccumulatedBenefitObligation", "True");
            //dic.Add("PayoutProjectionCustomGroup", "");
            //dic.Add("RunValuation", "Click");
            //dic.Add("OK", "");
            //pMain._PopVerify_RunOptions(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);


            //pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Test Cases", "RollForward", true, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Valuation Summary", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Individual Output", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "IOE", "Conversion", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Payout Projection", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "FAS Expected Benefit Pmts", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Liabilities Detailed Results", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Reconciliation to Baseline", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);


            //thrd_Accounting_July2018FASVal_UpdateAssumptions.Start();

            //pMain._SelectTab("July 2018 FAS Val");
            //pMain._Home_ToolbarClick_Top(true);

            //#endregion

            //#region Accounting - July 2018 FAS Val - update cash balance

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "3");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Add Valuation Node");
            //pMain._FlowTreeRightSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ValNodeName", "update cash balance");
            //dic.Add("LiabilityValuationDate", "");
            //dic.Add("Data_AddNew", "");
            //dic.Add("Data_Name", "");
            //dic.Add("Data_Edit", "");
            //dic.Add("Assumptions_AddNew", "True");
            //dic.Add("Assumptions_Name", "");
            //dic.Add("Assumptions_Edit", "");
            //dic.Add("MethodsLiabilities_AddNew", "");
            //dic.Add("MethodsLiabilities_Name", "");
            //dic.Add("MethodsLiabilities_Edit", "");
            //dic.Add("Provisions_AddNew", "True");
            //dic.Add("Provisions_Name", "");
            //dic.Add("Provisions_Edit", "");
            //dic.Add("FundingInformation_AddNew", "");
            //dic.Add("FundingInformation_Name", "");
            //dic.Add("FundingInformation_Edit", "");
            //dic.Add("OK", "");
            //dic.Add("Cancel", "");
            //pMain._PopVerify_ValuationNodeProperties(dic);

            //pMain._ValuationNodeProperties_ChangeReasons_Initialize();

            //dic.Clear();
            //dic.Add("LiabilityType", "All Accounting Liability Types");
            //dic.Add("ReasonforChange", "Plan change");
            //dic.Add("OK", "Click");
            //pMain._ValuationNodeProperties_ChangeReasons(dic);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "4");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Assumptions");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Custom Rates");
            //dic.Add("MenuItem", "Add Custom Rates");
            //pAssumptions._TreeViewRightSelect(dic, "pretransrate");

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Custom Rates");
            //dic.Add("Level_3", "pretransrate");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PrescribedRates", "");
            //dic.Add("SameStructureForAllPeriods", "");
            //dic.Add("TimeBased", "");
            //dic.Add("PercentIcon", "click");
            //dic.Add("TIcon", "");
            //dic.Add("txtRate", "3.0");
            //dic.Add("cboRate", "");
            //pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Custom Rates");
            //dic.Add("MenuItem", "Add Custom Rates");
            //pAssumptions._TreeViewRightSelect(dic, "posttransrate");

            //dic.Clear();
            //dic.Add("Level_1", "Assumptions");
            //dic.Add("Level_2", "Custom Rates");
            //dic.Add("Level_3", "posttransrate");
            //dic.Add("Level_4", "Default");
            //pAssumptions._TreeViewSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("PrescribedRates", "");
            //dic.Add("SameStructureForAllPeriods", "");
            //dic.Add("TimeBased", "");
            //dic.Add("PercentIcon", "click");
            //dic.Add("TIcon", "");
            //dic.Add("txtRate", "2.0");
            //dic.Add("cboRate", "");
            //pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            //pMain._Home_ToolbarClick_Top(true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "4");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Provisions");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);

            //pMain._SelectTab("Provisions");

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //dic.Add("Level_3", "Unit Formula");
            //dic.Add("Level_4", "UFBenefit");
            //dic.Add("Level_5", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("iCol", "1");
            //dic.Add("iRowMax", "2");
            //dic.Add("iColMax", "4");
            //dic.Add("sData", "400.00");
            //dic.Add("bPayCredit", "");
            //pUnitFormula._FormulaTable(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("iCol", "2");
            //dic.Add("iRowMax", "2");
            //dic.Add("iColMax", "4");
            //dic.Add("sData", "700.00");
            //dic.Add("bPayCredit", "");
            //pUnitFormula._FormulaTable(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("iCol", "3");
            //dic.Add("iRowMax", "2");
            //dic.Add("iColMax", "4");
            //dic.Add("sData", "850.00");
            //dic.Add("bPayCredit", "");
            //pUnitFormula._FormulaTable(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("iCol", "4");
            //dic.Add("iRowMax", "2");
            //dic.Add("iColMax", "4");
            //dic.Add("sData", "1000.00");
            //dic.Add("bPayCredit", "");
            //pUnitFormula._FormulaTable(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //dic.Add("Level_3", "FAE Formula");
            //dic.Add("Level_4", "FAEBenefit");
            //dic.Add("Level_5", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("btnC", "");
            //dic.Add("btnV", "");
            //dic.Add("sData2", "");
            //dic.Add("sData3", "0.025");
            //dic.Add("sData4", "0.03");
            //dic.Add("sData5", "0.07");
            //pFAEFormula._TBL_Offset_updateToAge_US(dic);


            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //dic.Add("Level_3", "Pay Credit");
            //dic.Add("Level_4", "CBAccrual");
            //dic.Add("Level_5", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("btnC", "");
            //dic.Add("btnV", "");
            //dic.Add("sData2", "");
            //dic.Add("sData3", "0.05");
            //dic.Add("sData4", "0.08");
            //pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            //dic.Clear();
            //dic.Add("iRow", "3");
            //dic.Add("btnC", "");
            //dic.Add("btnV", "");
            //dic.Add("sData2", "");
            //dic.Add("sData3", "0.1");
            //dic.Add("sData4", "0.16");
            //pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //dic.Add("Level_3", "Cash Balance");
            //dic.Add("Level_4", "TransBalance");
            //dic.Add("Level_5", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("StartingBalance", "");
            //dic.Add("PayCredits", "");
            //dic.Add("FreezePayCreditsAtAge_txt", "");
            //dic.Add("RateOnBalanceIsDiffer", "true");
            //pCashBalance._PopVerify_Standard(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iRow", "1");
            //dic.Add("ForAges", "");
            //dic.Add("Rates", "pretransrate");
            //dic.Add("CreditingPeriod", "");
            //dic.Add("CreditingFrequency", "");
            //pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iRow", "2");
            //dic.Add("ForAges", "");
            //dic.Add("Rates", "posttransrate");
            //dic.Add("CreditingPeriod", "");
            //dic.Add("CreditingFrequency", "");
            //pCashBalance._LinearizationWithBreakpoint_tbl(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //dic.Add("Level_3", "Career Average Earnings Formula");
            //dic.Add("Level_4", "CABenefit");
            //dic.Add("Level_5", "Default");
            //pAssumptions._TreeViewSelect(dic);

            //_gLib._MsgBox("", "please make sure first line is 35 and 40");


            //dic.Clear();
            //dic.Add("iRow", "2");
            //dic.Add("btnC", "");
            //dic.Add("btnV", "");
            //dic.Add("sData2", "");
            //dic.Add("sData3", "0.08");
            //dic.Add("sData4", "0.1");
            //pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            //dic.Clear();
            //dic.Add("iRow", "3");
            //dic.Add("btnC", "");
            //dic.Add("btnV", "");
            //dic.Add("sData2", "");
            //dic.Add("sData3", "0.12");
            //dic.Add("sData4", "0.1");
            //pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            //dic.Clear();
            //dic.Add("Level_1", "Provisions");
            //dic.Add("Level_2", "Formulae");
            //pAssumptions._Collapse(dic);

            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "4");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Liabilities");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Acc_GL_PBO", "");
            //dic.Add("Acc_GL_ABO", "");
            //dic.Add("GL_PPANAR_Min", "");
            //dic.Add("GL_PPANAR_Max", "");
            //dic.Add("GL_EAN", "");
            //dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            //dic.Add("PayoutProjection", "True");
            //dic.Add("IncludeIOE", "True");
            //dic.Add("GenerateParameterPrint", "True");
            //dic.Add("GenerateTestCaseOutput", "True");
            //dic.Add("IncludeGainLossResult", "");
            //dic.Add("Service", "CreditedService");
            //dic.Add("Pay", "SalProj");
            //dic.Add("CurrentYear", "True");
            //dic.Add("PriorYear", "");
            //dic.Add("CashBanlance", "Cbal");
            //dic.Add("Pension", "Benefit1DB");
            //dic.Add("AllLiabilityTypes", "");
            //dic.Add("Acc_ProjectedBenefitObligation", "True");
            //dic.Add("Acc_AccumulatedBenefitObligation", "True");
            //dic.Add("PayoutProjectionCustomGroup", "");
            //dic.Add("RunValuation", "Click");
            //dic.Add("OK", "");
            //pMain._PopVerify_RunOptions(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("OK", "Click");
            //pMain._PopVerify_EnterpriseRunSubmitted(dic);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "4");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Run Status");
            //pMain._FlowTreeRightSelect(dic);


            //pMain._EnterpriseRun("Group Job Successfully Complete with 10 NP", true);

            //pMain._SelectTab("July 2018 FAS Val");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "4");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "View Output");
            //pMain._FlowTreeRightSelect(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("RemoveAll", "");
            //dic.Add("AddAll", "");
            //dic.Add("Node", "");
            //dic.Add("Add", "");
            //dic.Add("ShowSubtotalBreaks", "");
            //dic.Add("OK", "");
            //pOutputManager._PopVerify_OutputManagerSetup(dic);

            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Parameter Print", "RollForward", true, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Test Cases", "RollForward", true, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Scenario by Plan Def", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Valuation Summary", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Individual Output", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "IOE", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Payout Projection", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "FAS Expected Benefit Pmts", "RollForward", false, false);
            //pOutputManager._ExportReport_Others_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liability Set for Globe Export", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results", "RollForward", false, false);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Liabilities Detailed Results by Plan Def", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline", "RollForward", false, false);
            //pOutputManager._ExportReport_SubReports_PDF_EXCEL(sOutputAccounting_July2018FASVal_UpdateCashBalance, "Reconciliation to Baseline by Plan Def", "RollForward", false, false);



            //if (Config.bCompareReports)
            //{
            //    CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputAccounting_July2018FASVal_UpdateCashBalance_Prod, sOutputAccounting_July2018FASVal_UpdateCashBalance);
            //    _compareReportsLib._Report(_PassFailStep.Description, "", "Accounting_July2018FASVal_UpdateCashBalance");

            //    _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0, true);
            //    _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0, true);
            //}


            //pMain._SelectTab("Output Manager");
            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);




            #endregion

            _gLib._MsgBox("", "please manually compare parameter print for the last node, and this client is finished");

        }




        void t_CompareRpt_Funding_val2018_Baseline(string sOutputFunding_val2018_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_val2018_Baseline_Prod, sOutputFunding_val2018_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_val2018_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsByPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;

            }



        }

        void t_CompareRpt_Funding_val2018_UpdateAssumptionsfor2018(string sOutputFunding_val2018_UpdateAssumptionsfor2018)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_val2018_UpdateAssumptionsfor2018_Prod, sOutputFunding_val2018_UpdateAssumptionsfor2018);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_val2018_UpdateAssumptionsfor2018");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_val2018_PlanAmendment(string sOutputFunding_val2018_PlanAmendment)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_val2018_PlanAmendment_Prod, sOutputFunding_val2018_PlanAmendment);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_val2018_PlanAmendment");
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

                //////////////_compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_val2018_ForAFTAP(string sOutputFunding_val2018_ForAFTAP)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_val2018_ForAFTAP_Prod, sOutputFunding_val2018_ForAFTAP);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_val2018_ForAFTAP");
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PBGCARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPAARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPANARPVVB.xlsx", 4, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_valJuly2019_Baseline(string sOutputFunding_valJuly2019_Baseline)
        {

            if (Config.bCompareReports)
            {

                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_valJuly2019_Baseline_Prod, sOutputFunding_valJuly2019_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_valJuly2019_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVAB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_FAS35PVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PBGCNARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToPriorYearByPlanDef_PPANARPVVB.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataComparison.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_PPANARMin.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMin.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityComparison_PPANARMax.xlsx", 0, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }



        }

        void t_CompareRpt_Funding_valJuly2019_UpdateAssumptions(string sOutputFunding_valJuly2019_UpdateAssumptions)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_valJuly2019_UpdateAssumptions_Prod, sOutputFunding_valJuly2019_UpdateAssumptions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_valJuly2019_UpdateAssumptions");
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
                _compareReportsLib.CompareExcel_Exact("ASC960Reconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FundingCalculatorScenario.xlsx", 4, 0, 0, 0);

                Config.bThreadFinsihed = true;
            }

        }

        void t_CompareRpt_Funding_valJuly2019_UpdateProvisions(string sOutputFunding_valJuly2019_UpdateProvisions)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputFunding_valJuly2019_UpdateProvisions_Prod, sOutputFunding_valJuly2019_UpdateProvisions);
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



        void t_CompareRpt_Accounting_July2018FASVal_Baseline(string sOutputAccounting_July2018FASVal_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputAccounting_July2018FASVal_Baseline_Prod, sOutputAccounting_July2018FASVal_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_July2018FASVal_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DataMatchingSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("CombinedStatusCodeSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossStatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossSummaryofLiabilityReconciliation_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ActiveDecrementGainLossDetail_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DecrementAge.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("GainLossParticipantListing_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }


        }

        void t_CompareRpt_Accounting_July2018FASVal_UpdateAssumptions(string sOutputAccounting_July2018FASVal_UpdateAssumptions)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US011CN", sOutputAccounting_July2018FASVal_UpdateAssumptions_Prod, sOutputAccounting_July2018FASVal_UpdateAssumptions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_July2018FASVal_UpdateAssumptions");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_ABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_PBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_ABO.xlsx", 4, 0, 0, 0);
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
