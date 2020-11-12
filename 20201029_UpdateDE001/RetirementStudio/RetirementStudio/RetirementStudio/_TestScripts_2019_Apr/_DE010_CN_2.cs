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
    /// Summary description for _DE010_CN_2
    /// </summary>
    [CodedUITest]
    public class _DE010_CN_2
    {
        public _DE010_CN_2()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 010 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 010 Existing DNT Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        public string sService_Jubliee2012 = "JubileeVal2012_0830";

        #region Report Output Directory


        public string sOutputPension_Conversion2010 = "";

   
        public string sOutputJubilee_Valuation2012_V67Enhancements = "";
        public string sOutputJubilee_Valuation2012_V69Enhancements = "";



        public string sOutputJubilee_Valuation2012_V67Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\V67Enhancements\000_7.4_Baseline\";

        public string sOutputJubilee_Valuation2012_V69Enhancements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\Existing\Jubilee Valuation 2012\V69Enhancements\000_7.4_Baseline\";

    
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
                string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_010\CreateNew";
                string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                ////  _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);
       
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
        public void test_DE010_CN_2()
        {

            #region MultiThreads

            Thread thrd_Jubilee_Valuation2012_V67Enhancements = new Thread(() => new _DE010_CN_2().t_CompareRpt_Jubilee_Valuation2012_V67Enhancements(sOutputJubilee_Valuation2012_V67Enhancements));

            #endregion



            this.GenerateReportOuputDir();

            #region Jubilee RF 2012

            ////Need add code from baseline the same as orignal Jubilee Val2012 

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "JubileeValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "false");
            dic.Add("Name", sService_Jubliee2012);
            dic.Add("Parent", "Valuation 2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2012");
            dic.Add("RSC", "true");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", sService_Jubliee2012);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab(sService_Jubliee2012);

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
            dic.Add("LiabilityValuationDate", "31.12.2012");
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


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("DataEffectiveDate", "31.12.2012");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
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
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2012 Jubilee Snapshot");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            //////dic.Add("SpecifyANewSnapshotRetainingPrevious", "true");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            _gLib._MsgBox("", "please chcek on import and all pay fields but prior year2");

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


            pMain._SelectTab(sService_Jubliee2012);


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
            dic.Add("Level_2", "JUBI02");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("ServiceInstance", "");
            dic.Add("ValuationNode", "");
            dic.Add("VOShortName", "JUBI01");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Contractual Retirement Age");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FixedAge_V", "");
            dic.Add("FixedAge_C", "");
            dic.Add("FixedAge_cbo", "");
            dic.Add("FixedAge_txt", "");
            dic.Add("Regelaltersgrenze", "true");
            pContractualRetirementAge._PopVerify_ContractualRetirementAge(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_ServiceForProration");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_ServiceForProration");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "True");
            dic.Add("ForTrade_DE", "true");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "20");
            dic.Add("ServiceStarts_FixedDate", "01.01.2000");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OtherDate", "true");
            dic.Add("Month", "June");
            dic.Add("Day", "30");
            dic.Add("Alignment", "Following the valuation date");
            pService._PopVerify_RulesBasedService_CalculationRules(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDPA_Projection1");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDPA_Projection1");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "JubiSalaryCurrentYear");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "2,0");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "CFB_FormulaB");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_FormulaB");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$UDPA_Projection1[$ValAge+1]");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JB_FixAmount2");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JB_FixAmount2");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "click");
            dic.Add("JubileeAmount_cbo", "");
            dic.Add("JubileeAmount_txt", "135,79");
            dic.Add("NetAmtUsingTotal", "click");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JBFixAmount3");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JBFixAmount3");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "click");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "PSVBenefitsOther");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "click");
            dic.Add("YearSalary", "SVSalaryCurrentYear");
            dic.Add("TaxClass", "1");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JB_FixAmount4");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JB_FixAmount4");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "");
            dic.Add("JubileeAmount_C", "click");
            dic.Add("JubileeAmount_cbo", "");
            dic.Add("JubileeAmount_txt", "246,80");
            dic.Add("NetAmtUsingTotal", "");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "click");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Social Security");
            dic.Add("MenuItem", "Add Social Security");
            pAssumptions._TreeViewRightSelect(dic, "SS_SocialSec");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Social Security");
            dic.Add("Level_6", "SS_SocialSec");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SaveThisBenefit", "");
            dic.Add("Method_Salary", "PP_JubileeSalary");
            dic.Add("SSCC_Increase", "AsPI_PayIncreaseRate");
            dic.Add("AktuellerRentenwert_Increase", "CostOfLivingIncreaseAssumption");
            dic.Add("VorlDurchs_Increase", "CostOfLivingIncreaseAssumption");
            pSocialSecurity._SocialSecurity(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi20");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "recurring holiday");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("JubileeBenefit", "JB_Salary");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "");
            dic.Add("Jubilee", "true");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("JubileeBenefit", "JB_FixAmount");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("JubileeBenefit", "JB_FixAmount2");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("JubileeBenefit", "JBFixAmount3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("JubileeBenefit", "JB_FixAmount4");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,90000");
            pPlanDefinition_DE._Table(dic);




            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi30");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "recurring holiday");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("JubileeBenefit", "JB_Salary");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("JubileeBenefit", "JB_FixAmount");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("JubileeBenefit", "JB_FixAmount2");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("JubileeBenefit", "JBFixAmount3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("JubileeBenefit", "holiday");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "0,95000");
            pPlanDefinition_DE._Table(dic);



            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi40");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "recurring holiday");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("JubileeBenefit", "JB_Salary");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("JubileeBenefit", "JB_FixAmount");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("JubileeBenefit", "JB_FixAmount2");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("JubileeBenefit", "JBFixAmount3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("JubileeBenefit", "JB_FixAmount4");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,33300");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "10");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi30");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "LowService");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi30");
            dic.Add("Level_6", "LowService");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "30");
            dic.Add("BasedOn", "");
            dic.Add("YearlySalary", "PP_JubileeSalary");
            dic.Add("ApplyPercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JB_FixAmount");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "0");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "JB_FixAmount2");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "0");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("JubileeBenefit", "JBFixAmount3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "0");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("JubileeBenefit", "JB_FixAmount4");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "0");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$SVC_ServiceForProration<10");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("MenuItem", "Add Override Definition");
            pAssumptions._TreeViewRightSelect(dic, "JubOverride");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "IntAccounting");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Trade");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("Level_6", "IntAccounting");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_AL");
            dic.Add("Expression", "$_ABO_AL+1000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_NC");
            dic.Add("Expression", "$_ABO_NC+100");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_AL");
            dic.Add("Expression", "$_PBO_AL+2000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_NC");
            dic.Add("Expression", "$_PBO_NC+200");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("Level_6", "IntAccounting");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("Level_6", "IntAccounting");
            dic.Add("Level_7", "Females");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_AL");
            dic.Add("Expression", "$_ABO_AL+500");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_NC");
            dic.Add("Expression", "$_ABO_NC+50");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_AL");
            dic.Add("Expression", "$_PBO_AL+1500");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_NC");
            dic.Add("Expression", "$_PBO_NC+150");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("Level_6", "Trade");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Trade_AL");
            dic.Add("Expression", "$_Trade_AL+3000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Trade_NC");
            dic.Add("Expression", "$_Trade_NC+300");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("Level_6", "AllOthers");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_NC");
            dic.Add("Expression", "$_NC+400");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Teilwert_1992");
            dic.Add("Expression", "$_Teilwert_1992+4000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_NC_1992");
            dic.Add("Expression", "$_NC_1992+400");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Teilwert_ValAge");
            dic.Add("Expression", "$_Teilwert_ValAge+4000");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("MenuItem", "Add Override Definition");
            pAssumptions._TreeViewRightSelect(dic, "JubBKRESOverride");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubBKRESOverride");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "IntAccounting");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubBKRESOverride");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Trade");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubBKRESOverride");
            dic.Add("Level_6", "AllOthers");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_BookReserve");
            dic.Add("Expression", "($_Teilwert_ValAge-$_Teilwert_1992)+4000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_TeilwertNY");
            dic.Add("Expression", "Round($_BookReserve*1.6666,0)");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "");
            dic.Add("Name", "");
            dic.Add("Expression", "");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Entry Age Normal (modified)");
            dic.Add("AnnualIncreaseRate", "AsPI_PayIncreaseRate");
            pMethods_DE._Table_TradeLiability_Jubilee(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("AddRow", "click");
            dic.Add("VOShortName", "JUBI01");
            dic.Add("BenefitDefinition", "Jubi20");
            dic.Add("PSVCoverage", "True");    //////// here should be "Tax" for jubi
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "");
            pMethods_DE._Table_BenefitsToExclude(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("AddRow", "click");
            dic.Add("VOShortName", "JUBI02");
            dic.Add("BenefitDefinition", "Jubi20");
            dic.Add("PSVCoverage", "True");    //////// here should be Tax for jubi
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "");
            pMethods_DE._Table_BenefitsToExclude(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "GS_ProrationOverride");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "GS_ProrationOverride");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "25");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "25");
            dic.Add("MaximumService_UseServiceCap", "30");
            dic.Add("ServiceStarts_FixedDate", "01.01.2000");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "50");
            dic.Add("ServiceEnds_FixedDate", "31.12.2020");
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


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("VOShortName", "JUBI01");
            dic.Add("BenefitDefinition", "Jubi30");
            dic.Add("isDisableTrade", "true");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "True");
            dic.Add("PUCOverride", "Projected Unit Credit Service Prorate");
            dic.Add("TUCOverride", "Service Prorate");
            dic.Add("ServiceForProrate", "GS_ProrationOverride");
            pMethods_DE._MethodOverrieds_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("VOShortName", "JUBI02");
            dic.Add("BenefitDefinition", "Jubi30");
            dic.Add("isDisableTrade", "true");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "True");
            dic.Add("PUCOverride", "Projected Unit Credit Service Prorate");
            dic.Add("TUCOverride", "Service Prorate");
            pMethods_DE._MethodOverrieds_Table(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Description", "JubileeSalaryPRoj");
            dic.Add("VOShortName", "JUBI02");
            dic.Add("Variable", "UDPA_Projection1");
            dic.Add("Age_cbo", "$SSNRA");
            pMethods_DE._AdditionalValuesToOutput(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("ProjectedpayToUse_CA", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "");
            dic.Add("AverageWorkingLifeTime", "true");
            dic.Add("AverageLifeTime", "true");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Calculate", "True");
            dic.Add("FromData", "");
            dic.Add("CustomCode", "");
            pAssumedRetirementAge._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Fruhestmogliches", "");
            dic.Add("Regelaltersgrenze", "");
            dic.Add("ContractualRetureentAge", "true");
            dic.Add("OverwriteWithIndividual_V", "");
            dic.Add("OverwriteWithIndividual_cbo", "");
            dic.Add("OverwriteWithIndividual_C", "");
            dic.Add("OverwriteWithIndividual_txt", "");
            pAssumedRetirementAge._PopVerify_Calculate(dic);



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
            dic.Add("Rate", "");
            dic.Add("AsOfDate", "31.12.2012");
            pInterestRate._PopVerify_PrescribedRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "1,88");
            dic.Add("TaxTariff", "2014");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "One Year Projection");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Actives_txt", "2,222");
            dic.Add("Pensions_txt", "3,333");
            dic.Add("Deferred_txt", "4,444");
            pOneYearProjection._OneYearProjection(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "SubsidiaryCode");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFields", "Gender");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"09.01.1975\" and $emp.VOShortName=\"JUBI01\" and $emp.EmployeeIDNumber=1");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab(sService_Jubliee2012);

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
            dic.Add("SelectVOs_AllVOs", "");
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


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);


            pMain._Home_ToolbarClick_Top(true);



            #endregion

            #region Jubilee RF 2012 -  V6.7 Enhancements

            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "V6.7 Enhancements");
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
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2015");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);



            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2016");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2016");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
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


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
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


            pMain._SelectTab(sService_Jubliee2012);
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region  Jubilee RF - Valuation 2012 - V6.9 Enhancements


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "V6.9 Enhancements");
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
            dic.Add("FundingInformation_AddNew", "false");
            dic.Add("OK", "");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Need_ActuarialReport", "true");
            dic.Add("FundingInformation_AddNew", "true");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab(sService_Jubliee2012);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Calculate", "True");
            dic.Add("FromData", "");
            dic.Add("CustomCode", "");
            pAssumedRetirementAge._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Fruhestmogliches", "");
            dic.Add("Regelaltersgrenze", "true");
            dic.Add("ContractualRetureentAge", "");
            dic.Add("OverwriteWithIndividualRetirementAge_chx", "");
            dic.Add("OverwriteWithIndividual_Age_V", "");
            dic.Add("OverwriteWithIndividual_Age_cbo", "");
            dic.Add("OverwriteWithIndividual_Age_C", "");
            dic.Add("OverwriteWithIndividual_Age_txt", "");
            pAssumedRetirementAge._PopVerify_Calculate(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Ceilings");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("West", "");
            dic.Add("East", "");
            dic.Add("WestEast_FromData", "true");
            pSocialSecurityContributionCeilings._SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("HealthInsuranceWest_T", "click");
            dic.Add("HealthInsuranceWest_T_cbox", "SocSecHealthInsWestFinal");
            dic.Add("RVWest_T", "click");
            dic.Add("RVWest_T_cbo", "SocSecRVWestFinal");
            dic.Add("HealthEnsuranceEast_T", "click");
            dic.Add("HealthEnsuranceEast_T_cbo", "SocSecHealthInsEastFinal");
            dic.Add("RVEast_T", "click");
            dic.Add("RVEast_T_cbo", "SocSecRVEastFinal");
            pSocialSecurityContributionCeilings._FromData_ContributionCeilings(dic);

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
            dic.Add("PriscribedRates_AccidentInsuranceContributionRate", "1,23");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "252,00");
            dic.Add("AdjustFactorrFromNextToGross", "1,35");
            dic.Add("TaxTariff", "2016");
            dic.Add("SoliTaxRate", "5,500");
            dic.Add("ChurchTaxRate", "8,000");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "One Year Projection");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Actives_txt", "1,23");
            dic.Add("Pensions_txt", "1,34");
            dic.Add("Deferred_txt", "1,45");
            pOneYearProjection._OneYearProjection(dic);

            pAssumptions._TreeView_SelectTab("Trade");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "click");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "GermanyTradeInterestRate10yrs");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            pAssumptions._TreeView_SelectTab("IntAccounting");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("VIcon", "");
            dic.Add("PercentIcon", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            for (int i = 0; i < 4; i++)
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("AsOfDate", "");
                dic.Add("ForActuarialEquivalence", "");
                dic.Add("ForwardRate", "");
                dic.Add("SpotRate", "true");
                dic.Add("AddRow", "click");
                pInterestRate._PopVerify_TimeBased(dic);
            }

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "4,44000000");
            pInterestRate._TimeBased_Table_DE(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "20");
            dic.Add("Rate", "3,33000000");
            pInterestRate._TimeBased_Table_DE(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("NumberOfYears", "30");
            dic.Add("Rate", "2,22000000");
            pInterestRate._TimeBased_Table_DE(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "1,11000000");
            pInterestRate._TimeBased_Table_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G Unisex");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);




            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
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
            dic.Add("CostMethod", "Entry Age Normal (modified)");
            dic.Add("AnnualIncreaseRate", "AsPI_PayIncreaseRate");
            pMethods_DE._Table_TradeLiability_Jubilee(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("CostMethod", "Entry Age Normal");
            dic.Add("AnnualIncreaseRate", "Null");
            pMethods_DE._Table_TradeLiability_Jubilee(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "Projected Unit Credit Service Prorate");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("CostMethod", "Projected Unit Credit No Prorate");
            dic.Add("CompareToAccrued", "");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("AddRow", "");
            dic.Add("DeleteRow", "click");
            dic.Add("VOShortName", "JUBI01");
            dic.Add("BenefitDefinition", "Jubi20");
            dic.Add("Tax", "True");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "");
            pMethods_DE._Table_BenefitsToExclude_Jubilee(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("DeleteRow", "click");
            dic.Add("iRow", "1");
            dic.Add("isDisableTrade", "true");
            dic.Add("VOShortName", "JUBI02");
            dic.Add("BenefitDefinition", "Jubi20");
            dic.Add("Trade", "");
            dic.Add("IntAcctng", "True");
            dic.Add("PUCOverride", "Projected Unit Credit Service Prorate");
            dic.Add("TUCOverride", "No Override");
            dic.Add("ServiceForProrate", "GS_ProrationOverride");
            pMethods_DE._MethodOverrieds_Table(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDPA_FixAmount1");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDPA_FixAmount1");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "ContribsWOInterest1");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "click");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "3,0");
            dic.Add("ProjectValuesForPastAges", "true");
            pUserDefinedProjectionA._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDPA_FixAmount2");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDPA_FixAmount2");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            pUserDefinedProjectionA._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($UDPA_FixAmount1,1000*(1+$AsPI_PayIncreaseRate)^($Age-$ValAge))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("MenuItem", "Add Jubilee Benefit");
            pAssumptions._TreeViewRightSelect(dic, "JB_FixAmount3");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Jubilee Benefit");
            dic.Add("Level_6", "JB_FixAmount3");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FixedAmount", "true");
            dic.Add("SalaryBased", "");
            dic.Add("JubileeAmount_V", "click");
            dic.Add("JubileeAmount_C", "");
            dic.Add("JubileeAmount_cbo", "UDPA_FixAmount2");
            dic.Add("JubileeAmount_txt", "");
            dic.Add("NetAmtUsingTotal", "true");
            dic.Add("NetAmtUsingSystem", "");
            dic.Add("YearSalary", "");
            dic.Add("TaxClass", "");
            dic.Add("GrossAmount", "");
            dic.Add("FinalAmount", "");
            pJubileeBenefit._PopVerify_FixedAmount(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi25");


            for (int i = 0; i < 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Jubilee");
                dic.Add("Level_2", "JUBI01");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "Jubi25");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi25");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "25");
            dic.Add("BasedOn", "HireDate1");
            dic.Add("YearlySalary", "PP_JubileeSalary");
            dic.Add("ApplyPercentMarried", "false");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JB_FixAmount3");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "2,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "True");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "5");
            dic.Add("GraceFactor", "0,50000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("MenuItem", "Add Override Definition");
            pAssumptions._TreeViewRightSelect(dic, "CrossLiabOverride");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverride");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_AL");
            dic.Add("Expression", "$_PBO_AL+1000");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_NC");
            dic.Add("Expression", "$_PBO_NC+100");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_AL");
            dic.Add("Expression", "$_ABO_AL+$_PBO_AL");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_ABO_NC");
            dic.Add("Expression", "$_ABO_NC+$_PBO_NC");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Trade_AL");
            dic.Add("Expression", "$_Trade_AL+$_ABO_AL");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Trade_NC");
            dic.Add("Expression", "$_Trade_NC+$_ABO_NC");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_BookReserve");
            dic.Add("Expression", "$_BookReserve+$_Trade_AL");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_NC");
            dic.Add("Expression", "$_NC+$_Trade_NC");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI01");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Jubi10");

            for (int i = 0; i < 3; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Jubilee");
                dic.Add("Level_2", "JUBI02");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "Jubi10");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Jubi10");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YearsOfServiceForJubi", "10");
            dic.Add("BasedOn", "HireDate1");
            dic.Add("YearlySalary", "PP_JubileeSalary");
            dic.Add("ApplyPercentMarried", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("JubileeBenefit", "JB_Salary");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("JubileeBenefit", "holiday");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "True");
            dic.Add("Retirement", "");
            dic.Add("Disability", "");
            dic.Add("Death", "");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("JubileeBenefit", "JB_FixAmount");
            dic.Add("Eligibility", "");
            dic.Add("Factor", "1,00000");
            dic.Add("Jubilee", "");
            dic.Add("Retirement", "");
            dic.Add("Disability", "True");
            dic.Add("Death", "True");
            dic.Add("GraceYears", "");
            dic.Add("GraceFactor", "1,00000");
            pPlanDefinition_DE._Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubOverride");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "JubBKRESOverride");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("MenuItem", "Add Override Definition");
            pAssumptions._TreeViewRightSelect(dic, "CrossLiabOverrideLiabTypeFolder");


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Trade");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "Tax");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("Level_6", "Trade");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_Trade_AL");
            dic.Add("Expression", "$_Trade_AL+$_Trade_OneYearProjectedAccruedLiability");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("Level_6", "Tax");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Female");

            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("Level_6", "Tax");
            dic.Add("Level_7", "Female");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            pAssumptions._SelectTab("Parameters");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_BookReserve");
            dic.Add("Expression", "Max($_Teilwert_ValAge-$_Teilwert_1992,$_Trade_AL)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("Level_6", "Tax");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_BookReserve");
            dic.Add("Expression", "Min($_Teilwert_ValAge-$_Teilwert_1992,$_Trade_AL)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Jubilee");
            dic.Add("Level_2", "JUBI02");
            dic.Add("Level_3", "Post Benefit Override Definition");
            dic.Add("Level_4", "Override Definition");
            dic.Add("Level_5", "CrossLiabOverrideLiabTypeFolder");
            dic.Add("Level_6", "AllOthers");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("isInputName", "true");
            dic.Add("Name", "_PBO_AL");
            dic.Add("Expression", "$_ABO_AL");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "click");
            dic.Add("Remove", "");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Reomve", "");
            pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFieldValue", "Sub1");
            dic.Add("SubstitutionText", "Sub1Text");
            dic.Add("Remove", "");
            dic.Add("OK", "");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFieldValue", "Sub2");
            dic.Add("SubstitutionText", "Sub2Text");
            dic.Add("Remove", "");
            dic.Add("OK", "click");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BreakFields", "");
            dic.Add("Remove", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab(sService_Jubliee2012);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("iPosX", "");
            dic.Add("iPosY", "");
            dic.Add("MenuItem_1", "Sensitivity");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Interest_IncreaseBy", "0,50");
            dic.Add("Interest_DecreseBy", "0,50");
            dic.Add("Pay_IncreaseBy", "0,50");
            dic.Add("Pay_DecreseBy", "0,50");
            dic.Add("Pension_IncreaseBy", "");
            dic.Add("Pension_DecreseBy", "");
            dic.Add("Mortality_IncreaseFactor", "1,135");
            dic.Add("Mortality_DecreseFactor", "0,885");
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
            dic.Add("AssumptionDefinition", "AsPI_PayIncreaseRate");
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

            dic.Clear();
            dic.Add("OK", "click");
            pMain._SensitivityWaringHandle(dic);


            pMain._SelectTab(sService_Jubliee2012);

            pMain._Home_ToolbarClick_Top(true);


            //V69 Enhancements node run Batch Liab
            dic.Clear();
            dic.Add("iPosX", "575");
            dic.Add("iPosY", "148");
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

            //Multiple Select Nodes window - node +0.5%
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "82");
            dic.Add("iY", "205");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //Multiple Select Nodes window - node 3.5%
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "175");
            dic.Add("iY", "205");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //Multiple Select Nodes window - node -0.5%
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "335");
            dic.Add("iY", "205");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //Multiple Select Nodes window - node 2.5%
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "459");
            dic.Add("iY", "205");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //Multiple Select Nodes window - node *1.135
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "600");
            dic.Add("iY", "205");
            dic.Add("OK", "");
            pMain._PopVerify_MultipleNodeSelection(dic);

            //Multiple Select Nodes window - node *0.885%
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iX", "750");
            dic.Add("iY", "205");
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


            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node +0.5%
            dic.Clear();
            dic.Add("iPosX", "82");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node 3.5%
            dic.Clear();
            dic.Add("iPosX", "175");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node-0.5%
            dic.Clear();
            dic.Add("iPosX", "335");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node 2.5%
            dic.Clear();
            dic.Add("iPosX", "459");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node *1.135
            dic.Clear();
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node *0.885
            dic.Clear();
            dic.Add("iPosX", "750");
            dic.Add("iPosY", "205");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Completed With Errors", true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            #region AR  --- No tmeplate update , comment this section

            //////dic.Clear();
            //////dic.Add("iPosX", "687");
            //////dic.Add("iPosY", "151");
            //////dic.Add("MenuItem_1", "Actuarial Report");
            //////dic.Add("MenuItem_2", "Edit Parameters");
            //////pMain._FlowTreeRightSelect(dic);


            //////pActuarialReport._SelectTab("Report Contents");

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "1");
            ////////////////////dic.Add("ReportSetName", "JubiTaxTrade");
            ////////////////////dic.Add("ReportType", "Jubilee");
            //////dic.Add("ReportTemplate", "2016_DEJubilee");
            //////////////////dic.Add("Listing1", "JubiNew");
            ////////////////////dic.Add("Listing2", "Jubilee default");
            //////pActuarialReport._ReportContents_DefineReportSets(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "2");
            ////////////////////dic.Add("ReportSetName", "IFRS");
            ////////////////////dic.Add("ReportType", "Jubilee IFRS");
            //////dic.Add("ReportTemplate", "2016_DEJubileeIFRS");
            ////////////////////dic.Add("Listing1", "IFRS default");
            //////pActuarialReport._ReportContents_DefineReportSets(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "3");
            ////////////////////dic.Add("ReportSetName", "IFRSEng");
            ////////////////////dic.Add("ReportType", "Jubilee IFRS");
            //////dic.Add("ReportTemplate", "2016_DEJubileeIFRSEnglish");
            //////dic.Add("Listing1", "");
            //////pActuarialReport._ReportContents_DefineReportSets(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "4");
            ////////////////////dic.Add("ReportSetName", "Accounting");
            ////////////////////dic.Add("ReportType", "Jubilee");
            //////dic.Add("ReportTemplate", "2016_DEJubileeAccountingBasis");
            //////dic.Add("Listing1", "");
            //////pActuarialReport._ReportContents_DefineReportSets(dic);



            //////pActuarialReport._SelectTab("Tax and Trade");


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field 1 value");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "Sub1");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field 1 value");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "Sub2");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field 2 value");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "#BLANK");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field 2 value");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "#BLANK");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Trade Interest rate determination method");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "x");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "LY Book Reserve Tax");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "123456");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "LY Book Reserve Tax");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "98765");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Trade liability method");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "MODTW");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Trade liability method");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "ALTTW");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);



            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Tax Method");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "Pausch");
            //////dic.Add("sFieldType", "list");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Tax Method");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "Dummy (cf manual)");
            //////dic.Add("sFieldType", "list");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Biometric assumptions Tax");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "x");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Biometric assumptions Tax");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "2015");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Biometric assumptions Trade");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "2010");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Biometric assumptions IntAcc");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "x");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);


            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Effect of change in salary increase");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "5432");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Effect of change in withdrawal");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "4321");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._TaxAndTrade_TBL(dic, true);



            //////pActuarialReport._SelectTab("IntAcc");

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field1 value");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "Sub1");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._IntAcc_TBL(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field1 value");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "Sub2");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._IntAcc_TBL(dic, true);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field2 value");
            //////dic.Add("iCol", "1");
            //////dic.Add("sData", "#BLANK");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._IntAcc_TBL(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("InformationByBreak", "Break field2 value");
            //////dic.Add("iCol", "2");
            //////dic.Add("sData", "#BLANK");
            //////dic.Add("sFieldType", "txt");
            //////pActuarialReport._IntAcc_TBL(dic, true);



            //////pActuarialReport._SelectTab("Sensitivity Results");

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "1");
            //////dic.Add("ValuationNode", "InterestSensitivity Null +0.5%");
            //////dic.Add("Rate", "");
            //////pActuarialReport._SensitivityResults(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "2");
            //////dic.Add("ValuationNode", "InterestSensitivity Null -0.5%");
            //////pActuarialReport._SensitivityResults(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "3");
            //////dic.Add("ValuationNode", "Using IntAcc Tab Value");
            //////pActuarialReport._SensitivityResults(dic);

            //////dic.Clear();
            //////dic.Add("PopVerify", "Pop");
            //////dic.Add("iRow", "4");
            //////dic.Add("ValuationNode", "Using IntAcc Tab Value");
            //////pActuarialReport._SensitivityResults(dic);


            //////pMain._Home_ToolbarClick_Top(true);
            //////pMain._Home_ToolbarClick_Top(false);


            //////pMain._SelectTab(sService_Jubliee2012);

            //////dic.Clear();
            //////dic.Add("iPosX", "687");
            //////dic.Add("iPosY", "140");
            //////dic.Add("MenuItem_1", "Run");
            //////dic.Add("MenuItem_2", "Actuarial Report");
            //////pMain._FlowTreeRightSelect(dic);

            //////_gLib._Wait(10);

            #endregion

            pMain._SelectTab(sService_Jubliee2012);

            //Tree view select node - V69
            dic.Clear();
            dic.Add("iPosX", "575");
            dic.Add("iPosY", "148");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Output Manager");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #region collaspe all setup setting about all sub node


            pMain._SelectTab(sService_Jubliee2012);

            //tree view node +0.5%
            dic.Clear();
            dic.Add("iPosX", "82");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //tree view node 3.5%
            dic.Clear();
            dic.Add("iPosX", "175");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //tree view node -0.5%
            dic.Clear();
            dic.Add("iPosX", "335");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab(sService_Jubliee2012);

            //tree view node 2.5%
            dic.Clear();
            dic.Add("iPosX", "459");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            //tree view node *1.135
            dic.Clear();
            dic.Add("iPosX", "600");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab(sService_Jubliee2012);

            //tree view node *0.885
            dic.Clear();
            dic.Add("iPosX", "750");
            dic.Add("iPosY", "150");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "");
            dic.Add("Checker", "");
            dic.Add("Reviewer", "");
            dic.Add("Setup", "click");
            pOutputManager._PopVerify_OutputManager(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "click");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "V6.9 Enhancements");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null +0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "InterestSensitivity Null -0.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 3.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "");
            dic.Add("OK", "");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "PaySensitivity 2.5%");
            dic.Add("Add", "click");
            dic.Add("ShowSubtotalBreaks", "SubsidiaryCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            pMain._SelectTab(sService_Jubliee2012);

            //tree view node V69
            dic.Clear();
            dic.Add("iPosX", "575");
            dic.Add("iPosY", "148");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "Jubilee", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, "IFRS", "RollForward", false, true);


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
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010CN_2", sOutputJubilee_Valuation2012_V69Enhancements_Prod, sOutputJubilee_Valuation2012_V69Enhancements);
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


            pMain._SelectTab(sService_Jubliee2012);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


        }


        #region compare report function


        void t_CompareRpt_Jubilee_Valuation2012_V67Enhancements(string sOutputJubilee_Valuation2012_V67Enhancements)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE010CN_2", sOutputJubilee_Valuation2012_V67Enhancements_Prod, sOutputJubilee_Valuation2012_V67Enhancements);
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

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
