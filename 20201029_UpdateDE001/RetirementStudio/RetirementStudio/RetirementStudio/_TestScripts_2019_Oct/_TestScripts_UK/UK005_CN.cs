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
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using RetirementStudio._UIMaps.AgeClasses;




namespace RetirementStudio._TestScripts_2019_Oct_UK
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class UK005_CN
    {
        public UK005_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 005 Create New";
            Config.sPlanName = "QA UK Benchmark 005 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory


        public string sOutputFunding_QAUKBenchmark005 = "";

        public string sOutputFunding_QAUKBenchmark005_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_005\Production\Funding\7.5_20191208_E\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_005\Create New\Funding\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_QAUKBenchmark005 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\");

                }
            } 

            string sContent = "";
            sContent = sContent + "sOutputFunding_QAUKBenchmark005 = @\"" + sOutputFunding_QAUKBenchmark005 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public Age pAge = new Age();
        public PayCredit pPayCredit = new PayCredit();
        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();
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
        public void test_UK005_CN()
        {

         
            this.GenerateReportOuputDir();


            #region QA UK Benchmark 005 - ParticipantData


            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "delete Conversion service fist");



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "QA UK Benchmark 005");
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
            dic.Add("ServiceToOpen", "QA UK Benchmark 005");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("QA UK Benchmark 005");


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
            dic.Add("SnapshotName", "QA_UK_BM_005");
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
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region QA UK Benchmark 005 - Provisions


            pMain._SelectTab("QA UK Benchmark 005");


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
            pAssumptions._TreeViewRightSelect(dic, "NewAge1");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "NewAge1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationMonthAndDay", "true");
            dic.Add("OtherDate", "");
            dic.Add("AgeRoundingRule", "Age nearest birthday");
            pAge._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "NewService1");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "NewService1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "1");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
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
            dic.Add("MaximumService_UseServiceCap", "65");
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
            pAssumptions._TreeViewRightSelect(dic, "ValServ");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ValServ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "");
            dic.Add("Date_UseServiceCap", "$ValDate");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pre97Val");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pre97Val");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
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
            dic.Add("ServiceEnds_FixedDate", "05/04/1997");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pst97Val");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pst97Val");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "05/04/1997");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "05/04/2006");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "PstAVal");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PstAVal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "$ValServ-$Pre97Val-$Pst97Val");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("FixedDate_UseServiceCap", "");
            dic.Add("Date_UseServiceCap", "$ValDate");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActStaff60ths");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActStaff60ths");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $emp.DivisionCode = \"AAAA\" and $emp.YearsCertain1 = 60");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActStaff80ths");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActStaff80ths");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus= \"AC\" and $emp.DivisionCode = \"AAAA\" and $emp.YearsCertain1 = 80");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActClow");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActClow");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $emp.DivisionCode = \"BBBB\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActDir");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActDir");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $emp.DivisionCode = \"CCCC\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Def60");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Def60");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\" and $emp.RETAGE = 60");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Def65");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Def65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"DEF\" and $emp.RETAGE = 65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "PenRPI");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "PenRPI");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus = \"PAY\" and $emp.PRE97IND = 0");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Pen5");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Pen5");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus= \"IN\" and $emp.PayStatus = \"PAY\" and $emp.PRE97IND = 1");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Act_LT65");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Act_LT65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$age<65 and $emp.ParticipantStatus = \"AC\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            pAssumptions._Collapse(dic);


            #endregion


            #region QA UK Benchmark 005 - Assumptions

            pMain._SelectTab("QA UK Benchmark 005");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "True");
            dic.Add("PreDecrementPostCommencement", "");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "4.75");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CARE_Inflation");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CARE_Inflation");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.6");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayInc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "5.6");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CPIRate_V", "");
            dic.Add("CPIRate_P", "Click");
            dic.Add("CPIRate_T", "");
            dic.Add("CPIRate_cbo_V", "");
            dic.Add("CPIRate_txt", "");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "");
            dic.Add("RPIRate_P", "Click");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "");
            dic.Add("RPIRate_txt", "3.6");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "");
            dic.Add("S148Inc_txt", "5.6");
            dic.Add("LimmGMPRate_txt", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("txtPercentMarried_M", "90.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
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
            dic.Add("Mortality_Setback_M", "2");
            dic.Add("Mortality_Setback_F", "2");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ER60TO65");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "click");
            dic.Add("cboPreDefinedEligibility", "Act_LT65");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayProj_Capped");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayProj_Capped");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "click");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "false");
            dic.Add("LegislatedPayLimitDefinition", "true");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "Pay1");
            dic.Add("PayIncreaseAssumption", "PayInc");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ZeroPay");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ZeroPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "true");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "true");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "true");
            dic.Add("LegislatedPayLimitDefinition", "true");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FPS_Final1_LEL_HalfYr_Cap");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FPS_Final1_LEL_HalfYr_Cap");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "False");
            dic.Add("ApplyeDeductionBeforeAveraging", "true");
            dic.Add("AdjustmentPeriod", "false");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PayProj_Capped");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "1");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "4524");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "Click");
            dic.Add("DeductionAnnualIncrease_P", "");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "CARE_Inflation");
            dic.Add("DeductionAnnualIncrease_txt", "");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FPS_Final1_HalfYr_Cap");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FPS_Final1_HalfYr_Cap");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "False");
            dic.Add("ApplyeDeductionBeforeAveraging", "false");
            dic.Add("AdjustmentPeriod", "false");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PayProj_Capped");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "1");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region QA UK Benchmark 005 - Provisions


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active_Service", "NewService1");
            dic.Add("Deferred_Service", "NewService1");
            dic.Add("Deferred_ApplyTrancheSplits", "");
            dic.Add("Pensioner_Service", "NewService1");
            dic.Add("Pensioner_ApplyTrancheSplits", "");
            pTrancheDefinition._PopVerify_Main(dic);


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
            dic.Add("Name", "PstA");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "06/04/2006");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "");

            dic.Add("Active_PPFTranche", "Pst1997Pre2009");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "click");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "click");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "click");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "click");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "65");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "65");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");

            dic.Add("Def_PPFTranche", "Pst1997Pre2009");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "click");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "click");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "click");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "click");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "65");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "65");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");

            dic.Add("Pen_PPFTranche", "Pst1997Pre2009");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "click");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "click");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "click");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "click");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "65");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "65");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst97PreA");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "06/04/1997");
            dic.Add("EndDate", "05/04/2006");
            dic.Add("GMPApplies", "false");

            dic.Add("Active_PPFTranche", "Pst1997Pre2009");
            dic.Add("Active_MalePPF_V", "");
            dic.Add("Active_MalePPF_C", "click");
            dic.Add("Active_FemalePPF_V", "");
            dic.Add("Active_FemalePPF_C", "click");
            dic.Add("Active_MaleSolvency_V", "");
            dic.Add("Active_MaleSolvency_C", "click");
            dic.Add("Active_FemaleSolvency_V", "");
            dic.Add("Active_FemaleSolvency_C", "click");
            dic.Add("Active_FullySalaryRelated", "");
            dic.Add("Active_MalePPF_cbo", "");
            dic.Add("Active_MalePPF_txt", "65");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "65");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");

            dic.Add("Def_PPFTranche", "Pst1997Pre2009");
            dic.Add("Def_MalePPF_V", "");
            dic.Add("Def_MalePPF_C", "click");
            dic.Add("Def_FemalePPF_V", "");
            dic.Add("Def_FemalePPF_C", "click");
            dic.Add("Def_MaleSolvency_V", "");
            dic.Add("Def_MaleSolvency_C", "click");
            dic.Add("Def_FemaleSolvency_V", "");
            dic.Add("Def_FemaleSolvency_C", "click");
            dic.Add("Def_MalePPF_cbo", "");
            dic.Add("Def_MalePPF_txt", "65");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "65");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "");

            dic.Add("Pen_PPFTranche", "Pst1997Pre2009");
            dic.Add("Pen_MalePPF_V", "");
            dic.Add("Pen_MalePPF_C", "click");
            dic.Add("Pen_FemalePPF_V", "");
            dic.Add("Pen_FemalePPF_C", "click");
            dic.Add("Pen_MaleSolvency_V", "");
            dic.Add("Pen_MaleSolvency_C", "click");
            dic.Add("Pen_FemaleSolvency_V", "");
            dic.Add("Pen_FemaleSolvency_C", "click");
            dic.Add("Pen_MalePPF_cbo", "");
            dic.Add("Pen_MalePPF_txt", "65");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "65");
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
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CarePre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "CarePre97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($Pre97Val/$ValServ) * $emp.AccruedBenefit1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CarePst97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "CarePst97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($Pst97Val/$ValServ) * $emp.AccruedBenefit1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CarePstA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "CarePstA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($PstAVal/$ValServ) * $emp.AccruedBenefit1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "BARBPEN");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "BARBPEN");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.EQPEN * 0.35");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "SpouseXSrev");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "SpouseXSrev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "2/3 * $emp.AccBen1_XSRev");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            pAssumptions._Collapse(dic);


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
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "Click");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "ContribsWInterest1");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "click");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "RETAGE");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "click");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "Pay1CurrentYear");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CARE_Pre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CARE_Pre97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "");
            dic.Add("Service", "");
            dic.Add("ServiceLimitTo", "40");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CARE_Inflation");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CarePre97");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);



            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "1.0");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CARE_Pst97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CARE_Pst97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            //////////oParam.Add "ProjectedPay" , "ZeroPay"
            //////////oParam.Add "Rate_V" , "Rate_V"
            //////////oParam.Add "Rate_cbo" , "CARE_Inflation"
            //////////oParam.Add "LimitServiceTo" , "40"
            //////////oParam.Add "StartingAccruedAmount_cbo" , "CarePst97"


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "ZeroPay");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "");
            dic.Add("Service", "");
            dic.Add("ServiceLimitTo", "40");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CARE_Inflation");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CarePst97");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "1.0");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CARE_PstA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CARE_PstA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "FPS_Final1_LEL_HalfYr_Cap");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "");
            dic.Add("Service", "");
            dic.Add("ServiceLimitTo", "40");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CARE_Inflation");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CarePstA");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01667");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CARE_PstA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Career Average Earnings Formula");
            dic.Add("Level_5", "CARE_PstA");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "FPS_Final1_LEL_HalfYr_Cap");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "");
            dic.Add("Service", "");
            dic.Add("ServiceLimitTo", "40");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CARE_Inflation");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "CarePstA");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "click");
            dic.Add("cboPreDefinedEligibility", "ActStaff80ths");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpXSrev");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpXSrev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_XSRev * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpXSnrev");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpXSnrev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_XSNonRev * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpPst97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpPst97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_Post97PreA * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpPstA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpPstA");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_PostAPre09 * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpBarb");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpBarb");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$BARBPEN * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpADD");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpADD");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.EADDPEN * 2/3");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Inc_Pre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Inc_Pre97");
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
            dic.Add("Revaluation_Rate_V", "click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "CARE_Inflation");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "click");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "click");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "3.0");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Inc_Pst97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Inc_Pst97");
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
            dic.Add("Revaluation_Rate_V", "click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "CARE_Inflation");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "click");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "3.6");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Inc_PstA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Inc_PstA");
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
            dic.Add("Revaluation_Rate_V", "click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "CARE_Inflation");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "click");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "2.5");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "ForEQPEN");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "ForEQPEN");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "True");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "true");
            dic.Add("Revaluation_Rate_V", "click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "CARE_Inflation");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "click");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "3.0");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "ForEADDPEN");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "ForEADDPEN");
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
            dic.Add("Revaluation_Rate_V", "");
            dic.Add("Revaluation_Rate_P", "click");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_CumulativeMax", "");
            dic.Add("Revaluation_PensionIncrease", "");
            dic.Add("Revaluation_Rate_V_cbo", "");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "click");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "3.0");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "ERF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "ERF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "59", "2.0");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "NewLateRetirementFactors1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "NewLateRetirementFactors1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.35");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("MenuItem", "Add GMP Adjustment Factors");
            pAssumptions._TreeViewRightSelect(dic, "GMPAdj");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdj");
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
            dic.Add("Act_FromDate_S148Increases", "click");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "click");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "");
            dic.Add("Inact_LimitedRate", "");
            dic.Add("Inact_PensionIncrease", "");
            dic.Add("Inact_FixedDateAt_V_cbo", "");
            dic.Add("Inact_FixedDateAt_D_txt", "");
            dic.Add("Increase_Pre88GMP_V", "");
            dic.Add("Increase_Pre88GMP_P", "click");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "SingleLife");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SingleLife");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "AnnualReversionary");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "AnnualReversionary");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "Lump");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "Lump");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
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
            pAssumptions._TreeViewRightSelect(dic, "SpouseDID");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SpouseDID");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
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
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "SpousesProp");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "SpousesProp");
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
            pAssumptions._TreeViewRightSelect(dic, "ActiveMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CARE_Pre97");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pre97");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("EarlyRetirementFactors", "ERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CARE_Pst97");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pst97");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("EarlyRetirementFactors", "ERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CarePstA");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_PstA");
            dic.Add("IncreasesInPayment", "Inc_PstA");
            dic.Add("EarlyRetirementFactors", "ERF");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "True");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CARE_Pre97");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pre97");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CARE_Pst97");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pst97");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "3");
            dic.Add("BaseAmount", "CarePstA");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_PstA");
            dic.Add("IncreasesInPayment", "Inc_PstA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "100.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "false");
            dic.Add("BaseAmountNonRevaluing", "false");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "AccBen1_XSRev");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pre97");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post97PreA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pst97");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "AccBen1_PostAPre09");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_PstA");
            dic.Add("IncreasesInPayment", "Inc_PstA");
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
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpousePreRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpousePreRet");
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
            dic.Add("BaseAmountRevaluing", "SpXSrev");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "RETAGE");
            dic.Add("RevaluationInDeferment", "Inc_Pre97");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "SpPst97");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "RETAGE");
            dic.Add("RevaluationInDeferment", "Inc_Pst97");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "SpPstA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "RETAGE");
            dic.Add("RevaluationInDeferment", "Inc_PstA");
            dic.Add("IncreasesInPayment", "Inc_PstA");
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
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpousePstRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpousePstRet");
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
            dic.Add("BaseAmountRevaluing", "SpXSrev");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pre97");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "SpPst97");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_Pst97");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "SpPstA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "RETAGE");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Inc_PstA");
            dic.Add("IncreasesInPayment", "Inc_PstA");
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
            pAssumptions._TreeViewRightSelect(dic, "PensionerMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionerMember");
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
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Benefit1DB_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "Benefit1DB_PostA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Inc_PstA");
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
            pAssumptions._TreeViewRightSelect(dic, "PensionerSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionerSpouse");
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
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Inc_Pre97");
            dic.Add("GMPAdjustmentFactors", "GMPAdj");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Benefit1DB_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Inc_Pst97");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "Benefit1DB_PostA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Inc_PstA");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProp");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Act_Ret_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Act_Ret_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveMember");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayInc");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Act_Ret_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Act_Ret_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveSpouse");
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayInc");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Act_Dth_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Act_Dth_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveSpouse");
            dic.Add("FormOfPayment", "Spouses");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayInc");
            dic.Add("Decrement", "Death");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Def_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Def_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredMember");
            dic.Add("FormOfPayment", "SingleLife");
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
            pAssumptions._TreeViewRightSelect(dic, "Def_Spouse_PreRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Def_Spouse_PreRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpousePreRet");
            dic.Add("FormOfPayment", "SpouseDID");
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
            pAssumptions._TreeViewRightSelect(dic, "Def_Spouse_PstRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Def_Spouse_PstRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpousePstRet");
            dic.Add("FormOfPayment", "AnnualReversionary");
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
            pAssumptions._TreeViewRightSelect(dic, "Pen_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Pen_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PensionerMember");
            dic.Add("FormOfPayment", "SingleLife");
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
            pAssumptions._TreeViewRightSelect(dic, "Pen_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Pen_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PensionerSpouse");
            dic.Add("FormOfPayment", "AnnualReversionary");
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
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AddPen_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "AddPen_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.EADDPEN + $emp.AccBen1_XSNonRev");
            dic.Add("Validate", "click");
            dic.Add("btnBenefitCommenceAge_V", "click");
            dic.Add("BenefitCommenceAge_cbo", "RETAGE");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "ForEADDPEN");
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
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "SingleLife");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AddPen_Spouse_PreRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "AddPen_Spouse_PreRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$SpADD + $SpXSnrev");
            dic.Add("Validate", "click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "click");
            dic.Add("BenefitStopAge_cbo", "RETAGE");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "ForEADDPEN");
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
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            dic.Add("MaximumBenefitLimitation_CA", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "SpouseDID");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AddPen_Spouse_PstRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "AddPen_Spouse_PstRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "true");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$SpADD + $SpXSnrev");
            dic.Add("Validate", "click");
            dic.Add("btnBenefitCommenceAge_V", "click");
            dic.Add("BenefitCommenceAge_cbo", "RETAGE");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "ForEADDPEN");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "AnnualReversionary");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region QA UK Benchmark 005 - Methods & Test case & Reports

            pMain._SelectTab("QA UK Benchmark 005");


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
            dic.Add("Funding", "");
            dic.Add("PBGCTermLiability", "");
            dic.Add("NondiscriminationTesting", "");
            dic.Add("BenefitExclusions_DthLiab", "");
            dic.Add("BenefitExclusions_InacLiab", "");
            dic.Add("BenefitExclusions_InactDIDLiab", "");
            dic.Add("BenefitExclusions_RetLiab", "");
            dic.Add("BenefitExclusions_WthDIDLiab", "");
            dic.Add("BenefitExclusions_WthLiab", "");
            dic.Add("CostMethod", "Attained Age");
            pMethods._PopVerify_Methods(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "GMPAdj");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PayProjection", "PayProj_Capped");
            dic.Add("EmployeeContribution", "");
            dic.Add("StopPVFuture", "$FullRetAge");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("QA UK Benchmark 005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"04/05/1971\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.birthdate=\"09/26/1953\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("QA UK Benchmark 005");


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
            dic.Add("Pay", "FinalPayCurrentYear");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
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

            pMain._SelectTab("QA UK Benchmark 005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("QA UK Benchmark 005");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_QAUKBenchmark005, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Detailed Results with Ben Type splits", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_QAUKBenchmark005, "Payout Projection - Other Info", "Conversion", false, true);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK005CN", sOutputFunding_QAUKBenchmark005_Prod, sOutputFunding_QAUKBenchmark005);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_QAUKBenchmark005");
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


            pMain._SelectTab("QA UK Benchmark 005");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("!", "Finished!");

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
