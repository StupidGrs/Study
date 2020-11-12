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



namespace RetirementStudio._TestScripts._TestScripts_UK
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _UK004_CN
    {
        public _UK004_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 004 Existing DNT";
            Config.sPlanName = "QA UK Benchmark 004 Existing DNT Plan";
            Config.sProductionVerison = "6.2";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory


        public string sOutputFunding_ValuationJune2008 = "";
        public string sServicename_Funding__ValuationJune2008 = "";


        public string sOutputFunding_ValuationJune2008_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_004\Existing\Funding\Valuation June 2008\000_7.4_Baseline\";


        public void GenerateReportOuputDir()
        {

            pMain._SetLanguageAndRegional(); pMain._SetLanguageAndRegional();
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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_004\Create New\Funding\Valuation June 2008\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_ValuationJune2008 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\");

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

                string sMainDir = sDir + "UK004_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_ValuationJune2008 = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_ValuationJune2008\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_ValuationJune2008 = @\"" + sOutputFunding_ValuationJune2008 + "\";" + Environment.NewLine;

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
        public void _test_UK004_CN()
        {



            sServicename_Funding__ValuationJune2008 = "Valuation June 2008_20190927";

            this.GenerateReportOuputDir();


            #region Valuation June 2008 - ParticipantData

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
            dic.Add("Name", sServicename_Funding__ValuationJune2008);
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
            dic.Add("ServiceToOpen", sServicename_Funding__ValuationJune2008);
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
            dic.Add("SnapshotName", "All Data");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "USC");
            dic.Add("Data", "[None]");
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


            pMain._SelectTab(sServicename_Funding__ValuationJune2008);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/15/1939\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"10/27/1955\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"06/21/1959\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/28/1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Valuation June 2008_2019testing - Assumptions

            pMain._SelectTab(sServicename_Funding__ValuationJune2008);

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
            dic.Add("PreCommencementRate_C", "7.2");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "6.2");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "InflationAssump");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "InflationAssump");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.8");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Pre97XSPenInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pre97XSPenInc");
            dic.Add("Level_4", "Default");
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


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Pst97PenInc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst97PenInc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.8");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryAssump");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryAssump");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "5.3");
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
            dic.Add("RPIRate_txt", "3.8");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            //////////oParam.Add "SalCapInc_txt" , "3.8"
            //////////oParam.Add "S148Inc_txt" , "5.3"
            //////////oParam.Add "LimGMPRate_txt" , "5.3"

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "3.8");
            dic.Add("S148Inc_txt", "5.3");
            dic.Add("LimmGMPRate_txt", "5.3");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation June 2008_2019testing - Provisions

            pMain._SelectTab(sServicename_Funding__ValuationJune2008);


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
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "PenServ");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PenServ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("MaximumService_UseServiceCap", "120");
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
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pre97Serv");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pre97Serv");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "true");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
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
            pAssumptions._TreeViewRightSelect(dic, "Pst97Serv");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pst97Serv");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "true");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PenServ - $Pre97Serv");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Actives");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Actives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\"");
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
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" AND $emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActiveUnder65");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActiveUnder65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age <65 AND $emp.ParticipantStatus = \"AC\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "ProjectedPay");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "ProjectedPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("LegislatedPayLimitDefinition", "False");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "PayVector");
            dic.Add("PayIncreaseAssumption", "SalaryAssump");
            dic.Add("UseOnlyDataFields", "true");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "4680");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "Click");
            dic.Add("DeductionAnnualIncrease_P", "");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "InflationAssump");
            dic.Add("DeductionAnnualIncrease_txt", "");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "FinalPensionableSalary");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "FinalPensionableSalary");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "False");
            dic.Add("ApplyeDeductionBeforeAveraging", "false");
            dic.Add("AdjustmentPeriod", "");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "");
            pPayAverage._PopVerify_Main_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "ProjectedPay");
            dic.Add("AveragingMethod", "M consecutive out of last N years");
            dic.Add("M", "3");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "6");
            dic.Add("AdjustmentMethod", "Adjustment factor");
            dic.Add("FinalSalaryFromData", "PayVectorCurrentYear");
            dic.Add("ProjectFPS", "true");
            dic.Add("PayIncreaseAssumptionForProjection", "SalaryAssump");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "NewServiceSelection1");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "NewServiceSelection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "$Service");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "65");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Assumptions");

            pMethods._SelectTab("Funding");


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
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "NewSubGroup1");
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




            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Deferreds");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "NewSubGroup1");
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




            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Actives");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


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
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "ActiveUnder65");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LG5960WIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LG5960QIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active_Service", "PenServ");
            dic.Add("Deferred_Service", "PenServ");
            dic.Add("Deferred_ApplyTrancheSplits", "");
            dic.Add("Pensioner_Service", "PenServ");
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

            dic.Add("Active_PPFTranche", "Pre1997");
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

            dic.Add("Def_PPFTranche", "Pre1997");
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

            dic.Add("Pen_PPFTranche", "Pre1997");
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
            dic.Add("Name", "Pst97");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "06/04/1997");
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
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pre97Pension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pre97Pension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pre97_Service");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01666667");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pst97Pension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pst97Pension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst97_Service");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.01666667");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "EmployeeContributions1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "EmployeeContributions1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "true");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "ContribsWOInterest1");
            dic.Add("StartingBalance_txt", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("StopContributionAt_V", "");
            dic.Add("StopContributionAt_C", "");
            dic.Add("StopContributionAt_cbo", "");
            dic.Add("StopContributionAt_txt", "");
            dic.Add("OffsetToAnnual_V", "");
            dic.Add("OffsetToAnnual_C", "");
            dic.Add("OffsetToAnnual_cbo", "");
            dic.Add("OffsetToAnnual_txt", "");
            dic.Add("LimitToAnnual_V", "");
            dic.Add("LimitToAnnual_C", "");
            dic.Add("LimitToAnnual_cbo", "");
            dic.Add("LimitToAnnual_txt", "");
            dic.Add("RateForYear_V", "click");
            dic.Add("RateForYear_P", "click");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_T", "");
            dic.Add("Rate_cbo", "InflationAssump");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectedPay", "ProjectedPay");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.085");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Pre97PenFinal");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Pre97PenFinal");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Pre97Pension+$emp.Additional_Pension");
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


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Pre97COLA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pre97COLA");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "30/06/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "Click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "Pre97XSPenInc");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Pst97COLA");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pst97COLA");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "30/06/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "Click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "Pst97PenInc");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "TestEarlyRetirementFactors");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            dic.Add("Level_4", "TestEarlyRetirementFactors");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_C", "click");
            dic.Add("AgeAtWhichReductionEnds_cbo", "");
            dic.Add("AgeAtWhichReductionEnds_txt", "65");
            pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            pVesting._PopVerify_Standard(dic);


            pEarlyRetirementFactor._TBL_ReductionDefinition(2, "64", "3.0", false, true);

            pEarlyRetirementFactor._TBL_ReductionDefinition(3, "63", "3.0", false, true);

            pEarlyRetirementFactor._TBL_ReductionDefinition(4, "62", "3.0", false, true);

            pEarlyRetirementFactor._TBL_ReductionDefinition(5, "61", "3.0", false, true);

            pEarlyRetirementFactor._TBL_ReductionDefinition(6, "60", "3.0", false, true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Early Retirement Factors");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("MenuItem", "Add GMP Adjustment Factors");
            pAssumptions._TreeViewRightSelect(dic, "NewGMPAdjustmentFactors");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "NewGMPAdjustmentFactors");
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
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "Click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "30/06/2008");
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
            dic.Add("Increase_Pre88GMP_P_txt", "");
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
            dic.Add("btnGuaranteePeriod_C", "click");
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
            dic.Add("btnNumberOfPaymentsPerYear_C", "click");
            dic.Add("NumberOfPaymentsPerYear_txt", "1");
            pFormOfPayment._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveMembers");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveMembers");
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
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "Pst97Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "Pst97Pension");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "TestEarlyRetirementFactors");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpouses");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpouses");
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
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "Pst97Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "Pst97Pension");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredMembers");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredMembers");
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
            dic.Add("BaseAmountNonRevaluing", "AccBen1_XSNonRev");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post97PreA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpouses");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpouses");
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
            dic.Add("BaseAmountNonRevaluing", "AccBen1_XSNonRev");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post97PreA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "PensionersMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionersMember");
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
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
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
            dic.Add("IncreasesInPayment", "Pst97COLA");
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
            pAssumptions._TreeViewRightSelect(dic, "PensionersSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionersSpouse");
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
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Ben1Ben1_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Pst97COLA");
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
            pAssumptions._TreeViewRightSelect(dic, "ActiveMembersWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveMembersWTH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "true");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "Pst97Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "Pst97Pension");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveMemberILL");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveMemberILL");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "true");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "2");
            dic.Add("BaseAmount", "Pst97Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "Pst97Pension");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpDID");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpDID");
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
            dic.Add("BaseAmountNonRevaluing", "AccBen1_XSNonRev");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97COLA");
            dic.Add("IncreasesInPayment", "Pre97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "NewGMPAdjustmentFactors");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post97PreA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97COLA");
            dic.Add("IncreasesInPayment", "Pst97COLA");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);


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
            pAssumptions._TreeViewRightSelect(dic, "Active_Ret_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_Ret_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveMembers");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryAssump");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_Ret_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_Ret_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveSpouses");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryAssump");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



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
            dic.Add("TranchedBenefit", "DeferredMembers");
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
            pAssumptions._TreeViewRightSelect(dic, "Deferred_SpousePre65");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_SpousePre65");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpDID");
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
            pAssumptions._TreeViewRightSelect(dic, "Deferred_SpousePost65");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_SpousePost65");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpouses");
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
            dic.Add("TranchedBenefit", "PensionersMember");
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
            dic.Add("TranchedBenefit", "PensionersSpouse");
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
            pAssumptions._TreeViewRightSelect(dic, "Active_ILL_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_ILL_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveMemberILL");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryAssump");
            dic.Add("Decrement", "Disability");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_WTH_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_WTH_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("TranchedBenefit", "ActiveMembersWTH");
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "SalaryAssump");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation June 2008_2019testing - Methods & Reports

            pMain._SelectTab(sServicename_Funding__ValuationJune2008);


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
            dic.Add("AllowNegativeNormalCost", "false");
            pMethods._PopVerify_Methods(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "NewGMPAdjustmentFactors");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sServicename_Funding__ValuationJune2008);

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Pay", "PayVectorCurrentYear");
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

            pMain._SelectTab(sServicename_Funding__ValuationJune2008);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab(sServicename_Funding__ValuationJune2008);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Test Cases", "Conversion", true, true);



            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Liability Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Member Statistics", "Conversion", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutputFunding_ValuationJune2008, "Conversion Diagnostic", "Conversion", true, true, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Individual Output", "Conversion", true, true);


            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Detailed Results with Ben Type splits", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputFunding_ValuationJune2008, "Payout Projection - Other Info", "Conversion", false, true);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK004CN", sOutputFunding_ValuationJune2008_Prod, sOutputFunding_ValuationJune2008);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_ValuationJune2008");
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

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sServicename_Funding__ValuationJune2008);
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
