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


namespace RetirementStudio._TestScripts_2019_Apr
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class _UK001_CN
    {
        public _UK001_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 001 Existing DNT";
            Config.sPlanName = "QA UK Benchmark 001 Existing DNT Plan";
            Config.sProductionVerison = "6.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory


        public string sOutputFunding_UKBM001 = "";
        public string sService_Funding_QAUKBM001 = "";


        public string sOutputFunding_UKBM001_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_001\Production\Funding\QA UK BM 001\7.3.2_20181119_E\";


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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_001\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_UKBM001 = _gLib._CreateDirectory(sMainDir + "Funding\\QA UK BM 001\\" + sPostFix + "\\");

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

                /////// this is for VS2012 folder structure
                sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

                ////////////////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "UK006_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_UKBM001 = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_UKBM001\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_UKBM001 = @\"" + sOutputFunding_UKBM001 + "\";" + Environment.NewLine;

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
        public void _test_UK001_CN()
        {

            sService_Funding_QAUKBM001 = "QA UK BM 001_20190926";
            sOutputFunding_UKBM001 = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_001\Create New\Funding\QA UK BM 001\20190925_QA1\";


            this.GenerateReportOuputDir();


            #region Valuation Service - QA UK BM 001

            pMain._SelectTab("Home");


            dic.Clear();
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
            dic.Add("ConversionService", "True");
            dic.Add("Name", sService_Funding_QAUKBM001);
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearEndingIn_DE", "2008");
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
            dic.Add("ServiceToOpen", sService_Funding_QAUKBM001);
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
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
            dic.Add("SnapshotName", "UpdatedwithSpouses");
            dic.Add("OK", "Click");
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

            pMain._Home_ToolbarClick_Top(true);

            #region Global Provisions

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "RetAge");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "RetAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "True");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "60");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "PensionableService");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PensionableService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "60");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "75");
            dic.Add("FixedDate_UseServiceCap", "");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pre97Service");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pre97Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "06/04/1997");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pst97Service");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pst97Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "06/04/1997");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Pensioners");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Pensioners");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus=\"IN\" AND $emp.PayStatus=\"PAY\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Deferreds");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus=\"IN\" AND $emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "NewPayProjection1");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "NewPayProjection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "True");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "True");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
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
            dic.Add("MaximumBenefitLimitation_CA", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Participant Info

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active_Service", "PensionableService");
            dic.Add("Deferred_Service", "PensionableService");
            dic.Add("Deferred_ApplyTrancheSplits", "True");
            dic.Add("Pensioner_Service", "PensionableService");
            dic.Add("Pensioner_ApplyTrancheSplits", "");
            pTrancheDefinition._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("DataField", "AccruedSpousesDID1");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "True");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pre97");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "");
            dic.Add("EndDate", "05/04/1997");
            dic.Add("GMPApplies", "True");
            dic.Add("Active_PPFTranche", "Pre1997");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "Pre1997");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "Pre1997");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);

            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst97");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "06/04/1997");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "");
            dic.Add("Active_PPFTranche", "Pst1997Pre2009");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "Pst1997Pre2009");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");
            dic.Add("Pen_PPFTranche", "Pst1997Pre2009");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pre1990");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst1990Pre1997");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst1997Pre2005");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2005Pre2009");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2009");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pre1997");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("Level_4", "Pst2005");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("DataField", "");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "True");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("DataField", "");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "True");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");


            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Assumptions

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pMain._SelectTab("Funding");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "4.9");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "4.8");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "4.9");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.4");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Pensioners");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PenInc_Pre97");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PenInc_Pre97");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "Click");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PenInc_Pst97");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PenInc_Pst97");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "Click");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.1");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Reval_in_Defer");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Reval_in_Defer");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "Click");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4.1");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "80.0");
            dic.Add("txtPercentMarried_F", "70.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "3");
            dic.Add("txtDifferenceInSpouseAge_F", "-3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "PA92MC");
            dic.Add("Mortality_Setback_M", "-3");
            dic.Add("Mortality_Setback_F", "-3");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            _gLib._MsgBox("Manual Interaction", "In Funding Tab, according to #104942, pleasee change the field in the Mortality decrement in the assumptions to from <Projection Scale and Age> to <Age> only");




            pMain._Home_ToolbarClick_Top(true);

            #endregion Assumption

            #region Provisions

            pMain._SelectTab("Provisions");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "NewEmployeeContributions1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "NewEmployeeContributions1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            pUnitFormula._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "PensionIncrease_Pre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "PensionIncrease_Pre97");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "True");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "Reval_in_Defer");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "/  /");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "Click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "PenInc_Pre97");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "PensionIncrease_Pst97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "PensionIncrease_Pst97");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "True");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "Reval_in_Defer");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "Click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "/  /");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "Click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "PenInc_Pst97");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("MenuItem", "Add GMP Adjustment Factors");
            pAssumptions._TreeViewRightSelect(dic, "GMP_AdjustmentFactors");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMP_AdjustmentFactors");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "True");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "Click");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "Click");
            dic.Add("Increase_Post88GMP_T", "");
            dic.Add("Increase_Pre88GMPPension", "");
            dic.Add("Increase_Post88GMPPension", "");
            dic.Add("Increase_Pre88GMP_V_cbo", "");
            dic.Add("Increase_Pre88GMP_P_txt", "3.0");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "");
            dic.Add("Increase_Post88GMP_P_txt", "3.0");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpousesDID");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SpousesDID");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "PensionerMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "PensionerMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "Click");
            dic.Add("GuaranteePeriod_cbo", "GUAR");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Spouses");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "Spouses");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Reversionary");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "Reversionary");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100.0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "MembersLife");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "MembersLife");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Straight life");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "5");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "");
            dic.Add("NumberOfPaymentsPerYear_txt", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Sp_Adj");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "Sp_Adj");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "0.667");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredMember_TranchedBenefit");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredMember_TranchedBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "Pre97_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pre97_AccruedBenefit1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pre97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMP_AdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Pst97_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pst97_AccruedBenefit1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pst97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "Pensioner_Benefit");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "Pensioner_Benefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "True");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Benefit1DB_Pre97");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("GMPAdjustmentFactors", "GMP_AdjustmentFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);


            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Benefit1DB_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpouse_Benefit");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpouse_Benefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "Pre97_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pre97_AccruedSpousesDID1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pre97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMP_AdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Pst97_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pst97_AccruedSpousesDID1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pst97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "PensionerSpouse_Benefit");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionerSpouse_Benefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "True");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Ben1Ben1_Pre97");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pre97");
            dic.Add("GMPAdjustmentFactors", "GMP_AdjustmentFactors");
            dic.Add("AdjustmentFactors", "Sp_Adj");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);


            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Ben1Ben1_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "Sp_Adj");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DefSpouseDTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DefSpouseDTH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "Pre97_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pre97_AccruedSpousesDID1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pre97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMP_AdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Pst97_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pst97_AccruedSpousesDID1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "0");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "PensionIncrease_Pst97");
            dic.Add("IncreasesInPayment", "PensionIncrease_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("MenuItem", "Collapse");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredMember_TranchedBenefit");
            dic.Add("FormOfPayment", "MembersLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_SpouseDAR");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_SpouseDAR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpouse_Benefit");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_SpouseDBR");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_SpouseDBR");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DefSpouseDTH");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Pensioner_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Pensioner_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "Pensioner_Benefit");
            dic.Add("FormOfPayment", "MembersLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Pensioner_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Pensioner_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PensionerSpouse_Benefit");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Methods & Test Case

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AllowNegativeNormalCost", "false");
            dic.Add("NormalCostForCYTermination_UK", "false");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "GMP_AdjustmentFactors");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PayProjection", "NewPayProjection1");
            dic.Add("EmployeeContribution", "NewEmployeeContributions1");
            dic.Add("StopPVFuture", "$FullRetAge");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"01/02/1949\"and  $emp.HireDate1 = \"03/01/1988\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02/08/1946\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #endregion

            #region Run Liabilities and download reports

            pMain._SelectTab(sService_Funding_QAUKBM001);

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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("Pay", "NewPayProjection1");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Major", "");
            dic.Add("Intermediate", "");
            dic.Add("Minor", "");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "False");
            dic.Add("AltFunding2", "False");
            dic.Add("AltFunding3", "False");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "");
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

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab(sService_Funding_QAUKBM001);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Test Cases", "Conversion", true, true);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Liability Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Member Statistics", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_UKBM001, "Conversion Diagnostic", "Conversion", true, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Individual Output", "Conversion", true, true);




            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Detailed Results with Ben Type splits", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_UKBM001, "Payout Projection - Other Info", "Conversion", false, true);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK001CN", sOutputFunding_UKBM001_Prod, sOutputFunding_UKBM001);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_UKBM001");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBenTypesplits.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0, true);

            }

            pMain._SelectTab(sService_Funding_QAUKBM001);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            #endregion

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
