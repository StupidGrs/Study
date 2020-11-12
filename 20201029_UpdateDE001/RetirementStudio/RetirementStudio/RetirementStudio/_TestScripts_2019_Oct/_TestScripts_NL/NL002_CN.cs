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
using RetirementStudio._UIMaps.InactiveBenefitPaymentClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;

// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.AgeClasses;



namespace RetirementStudio._TestScripts_2019_Oct_NL
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NL002_CN
    {
        public NL002_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 002 Create New D";
            Config.sPlanName = "QA NL Benchmark 002 Create New Plan";
            Config.sDataCenter = "Dallas";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory

        public string sAccounting_Valuation2010 = "";

        public string sAccounting_Valuation2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_002\Production\6.9.1_20160927_B\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_002\Create New\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sAccounting_Valuation2010 = _gLib._CreateDirectory(sMainDir + sPostFix + "\\");

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

                //////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "NL002_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sAccounting_Valuation2010 = _gLib._CreateDirectory(sMainDir + "\\sAccounting_Valuation2010\\");

            }

            string sContent = "";
            sContent = sContent + "sAccounting_Valuation2010 = @\"" + sAccounting_Valuation2010 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

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
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();


        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_NL002_CN()
        {

            this.GenerateReportOuputDir();


            #region Valuation 2010 - ParticipantData & Tables


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            _gLib._MsgBox("", "please delete Conversion service");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Valuation 2010");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2010");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2010");

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
            dic.Add("DataEffectiveDate", "31-12-2009");
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
            dic.Add("SnapshotName", "Import");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
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


            #endregion


            #region Valuation 2010 - Assumptions

            pMain._SelectTab("Valuation 2010");

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
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "DeductionIncrease");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "DeductionIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "Salarisverhogen");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "Salarisverhogen");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "Click");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "SL1MODUS");
            pPayIncrease._PopVerify_PayIncrease(dic);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation 2010 - Provisions




            pMain._SelectTab("Valuation 2010");

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
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "AGEAT65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "AGEAT65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "AGEATVAL");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "AGEATVAL");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationMonthAndDay", "true");
            dic.Add("OtherDate", "");
            dic.Add("AgeRoundingRule", "Age to completed months");
            pAge._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "CSDJ");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "CSDJ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($AGEAT65-$AGEATVAL,0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "PenServ");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PenServ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "25");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
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
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "TOTAALDJ");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "TOTAALDJ");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "Click");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CSDJ+$PenServ");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Deferreds");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Actieves");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Actieves");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "ActievesUnder65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "ActievesUnder65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"AC\" and $Age<65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Deferreds65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus=\"DEF\" and $emp.ICLA=0");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Deferreds60");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Deferreds60");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus = \"IN\" and $emp.PayStatus=\"DEF\" and $emp.ICLA=2");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PayProjection");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PayProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "False");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "MLSalaris");
            dic.Add("PayIncreaseAssumption", "Salarisverhogen");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PGOP1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PGOP1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "MLSalaris");
            dic.Add("PayIncreaseAssumption", "Salarisverhogen");
            dic.Add("UseOnlyDataFields", "");
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
            dic.Add("Deduction_txt", "17457");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "Click");
            dic.Add("DeductionAnnualIncrease_P", "");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "DeductionIncrease");
            dic.Add("DeductionAnnualIncrease_txt", "");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "PenServAT65");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "PenServAT65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "Click");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "PenServ");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "Click");
            dic.Add("SelectServiceAtAge_txt", "65");
            pServiceSelection._PopVerify_ServiceSelection(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            pMain._SelectTab("Valuation 2010");

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
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Primary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "100,0");
            dic.Add("txtPercentMarried_F", "100,0");
            dic.Add("cboPercentMarried", "");
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
            dic.Add("ApplyPercentMarriedAt", "Secondary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "Click");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "M8085P1");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("ApplyPercentMarriedAt", "Secondary decrement");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Actieves");
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
            dic.Add("ApplyPercentMarriedAt", "Secondary decrement");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "Click");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "M8085P1");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("ApplyPercentMarriedAt", "Secondary decrement");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            ///////////////////////////////////

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
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "AG5050");
            dic.Add("Mortality_Setback_M_NL", "-1");
            dic.Add("Mortality_Setback_F_NL", "-1");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "ActievesUnder65");
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
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "ActivesUnder65");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WURDAM");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus=\"AC\" and $Age<65");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WIA608");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M_NL", "");
            dic.Add("Mortality_Setback_F_NL", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Disabled_Setback_M_NL", "-1");
            dic.Add("Disabled_Setback_F_NL", "-1");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "");
            dic.Add("ProportionMale", "");
            dic.Add("ProportionFeMale", "");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "ActievesUnder65");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2010");

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
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "User Defined Projection");
            dic.Add("MenuItem", "Add User Defined Projection");
            pAssumptions._TreeViewRightSelect(dic, "Franchise");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "User Defined Projection");
            dic.Add("Level_4", "Franchise");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "");
            dic.Add("Amount_C", "Click");
            dic.Add("Amount_cbo", "");
            dic.Add("Amount_txt", "17457,0");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "DeductionIncrease");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "");
            dic.Add("Amount_C", "Click");
            dic.Add("Amount_cbo", "");
            dic.Add("Amount_txt", "17457,0");
            dic.Add("Rate_V", "Click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "DeductionIncrease");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "ImmediateVesting");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "ImmediateVesting");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "$Service");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "0");
            dic.Add("VestingPercentage", "100");
            pVesting._ServiceTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SingleLife");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SingleLife");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_txt", "99");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Spouses");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Spouses");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100,0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_txt", "99");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "Reversionary");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "Reversionary");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100,0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_txt", "99");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "SpousesDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "SpousesDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100,0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_txt", "1");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "AnnualReversionary");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "AnnualReversionary");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "Click");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            dic.Add("btnSurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("btnSurvivorPercentOrAmount_Percent", "Click");
            dic.Add("SurvivorPercentOrAmount_txt", "100,0");
            dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
            dic.Add("btnPopupAmount_V", "");
            dic.Add("PopupAmount_cbo", "");
            dic.Add("btnPopupAmount_C", "");
            dic.Add("PopupAmount_txt", "");
            dic.Add("btnNumberOfPaymentsPerYear_V", "");
            dic.Add("NumberOfPaymentsPerYear_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_C", "Click");
            dic.Add("NumberOfPaymentsPerYear_txt", "1");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "WZP3Perc");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "WZP3Perc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "1,03");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AccruedPension");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "AccruedPension");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0.0175*$PenServ*$PGOP1*$emp.PTFactorH");
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
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "AccruedPension");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "FullPension");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "FullPension");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "0.0175*$TOTAALDJ*$PGOP1*$emp.PTFactorH");
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
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "FullPension");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_RET_Member");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_Member");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_Member");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ACTIVES_RET_ELDOP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ACTIVES_RET_ELDOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDOP");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "ACTIVES_RET_ELDOP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "RET01");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RET01");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$Actives_RET_Member+$ACTIVES_RET_ELDOP");
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
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "RET01");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_RET_Spouses");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_Spouses");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension*0.70");
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
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_Spouses");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_RET_SPOU_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_SPOU_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
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
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_RET_SPOU_ELDNP");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_Dis_Member");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_Member");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_Member");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_Dis_MEM_ELDOP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_MEM_ELDOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDOP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_MEM_ELDOP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_Dis_SpousesPRE65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_SpousesPRE65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension*0.70");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_SpousesPRE65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_DIS_SPOU_PRE65_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DIS_SPOU_PRE65_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DIS_SPOU_PRE65_ELDNP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_Dis_SpousesPost65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_SpousesPost65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension*0.70");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_Dis_SpousesPost65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_DIS_SPOU_POST65_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DIS_SPOU_POST65_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DIS_SPOU_POST65_ELDNP");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_Member");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_Member");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$AccruedPension");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_Member");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_ELDOP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_ELDOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDOP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
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
            dic.Add("FormOfPayment", "SingleLife");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_ELDOP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_SpousesPRE65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SpousesPRE65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$AccruedPension*0.70");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SpousesPRE65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_SPOU_RET65_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SPOU_RET65_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SPOU_RET65_ELDNP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_SpousesPOST65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SpousesPOST65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$AccruedPension*0.70");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_SpousesPOST65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_WTH_POU_POST65_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_POU_POST65_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_WTH_POU_POST65_ELDNP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_DTH_Spouses");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DTH_Spouses");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$FullPension*0.70");
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
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "Spouses");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DTH_Spouses");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Actives_DTH_SPOU_ELDNP");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DTH_SPOU_ELDNP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "-$emp.ELDNP");
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
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "Spouses");
            dic.Add("FormOfPayment_Married", "");
            dic.Add("FormOfPayment_Single", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("BenefitElectionPercentage_Married", "");
            dic.Add("BenefitElectionPercentage_Single", "");
            dic.Add("MaximumBenefitLimitation", "");
            dic.Add("MaximumBenefitLimitation_Married", "");
            dic.Add("MaximumBenefitLimitation_Single", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PostDecrementMortality", "");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Actives_DTH_SPOU_ELDNP");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Member");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Member");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.AccruedBenefit1-$emp.ELDOP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
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
            dic.Add("FormOfPayment", "SingleLife");
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
            dic.Add("Level_3", "Deferred_Member");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Member");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.AccruedBenefit1-$emp.ELDOP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "60");
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
            dic.Add("FormOfPayment", "SingleLife");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Deferreds60");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Member");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Spouses_Pre65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_Pre65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.Beneficiary1Benefit1-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
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
            dic.Add("Level_3", "Deferred_Spouses_Pre65");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_Pre65");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.Beneficiary1Benefit1-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "60");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "SpousesDID");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Deferreds60");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_Pre65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Spouses_post65");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_post65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.Beneficiary1Benefit1-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
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
            dic.Add("Level_3", "Deferred_Spouses_post65");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_post65");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.Beneficiary1Benefit1-$emp.ELDNP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "60");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "WZP3Perc");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualReversionary");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Deferreds60");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Deferred_Spouses_post65");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Pensioner_Member");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Pensioner_Member");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.AccruedBenefit1-$emp.ELDOP");
            dic.Add("Validate", "Click");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
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
            dic.Add("FormOfPayment", "SingleLife");
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
            dic.Add("Level_3", "Pensioner_Member");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Pensioner_Spouses");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "Pensioner_Spouses");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "Click");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "$emp.Beneficiary1Benefit1-$emp.ELDNP");
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
            dic.Add("FormOfPayment", "Reversionary");
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


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation 2010 - Methods & Test Cases

            pMain._SelectTab("Valuation 2010");

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
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("NormalCostForCYTermination", "Yes");
            dic.Add("GrowIn_Age", "");
            dic.Add("GrowIn_Service", "");
            dic.Add("MaxValue_StartAge", "");
            dic.Add("MaxValue_StopAge", "");
            pMethods._PopVerify_Methods_CA(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "PenServ");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "");
            dic.Add("ProjectedpayToUse_CA", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "True");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "ImmediateVesting");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "True");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("BenefitDefinition", "ACTIVES_RET_ELDOP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("BenefitDefinition", "Actives_RET_SPOU_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "3");
            dic.Add("BenefitDefinition", "Actives_Dis_MEM_ELDOP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "4");
            dic.Add("BenefitDefinition", "Actives_DIS_SPOU_POST65_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "5");
            dic.Add("BenefitDefinition", "Actives_DIS_SPOU_PRE65_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "6");
            dic.Add("BenefitDefinition", "Actives_WTH_ELDOP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "7");
            dic.Add("BenefitDefinition", "Actives_WTH_POU_POST65_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "8");
            dic.Add("BenefitDefinition", "Actives_WTH_SPOU_RET65_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "9");
            dic.Add("BenefitDefinition", "Actives_DTH_SPOU_ELDNP");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/2/1982\" And $emp.HireDate1=\"5/1/2007\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/4/1951\" And $emp.HireDate1=\"8/4/1976\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);
            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"2/18/1939\" And $emp.HireDate1=\"1/1/1993\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Valuation 2010 - ER & Reports

            pMain._SelectTab("Valuation 2010");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "PenServ");
            dic.Add("Pay", "MLSalarisCurrentYear");
            dic.Add("CurrentYear", "Click");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "FullPension");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
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
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Parameter Print", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Test Cases", "Conversion", true, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccounting_Valuation2010, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sAccounting_Valuation2010, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Conversion Diagnostic", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sAccounting_Valuation2010, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sAccounting_Valuation2010, "FAS Expected Benefit Pmts", "Conversion", false, false);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL002CN", sAccounting_Valuation2010_Prod, sAccounting_Valuation2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccounting_Valuation2010");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                ////////_compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Valuation 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            _gLib._MsgBox("", "Finished!");


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
