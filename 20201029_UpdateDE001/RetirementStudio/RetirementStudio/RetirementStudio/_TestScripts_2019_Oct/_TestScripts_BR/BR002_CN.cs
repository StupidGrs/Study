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
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.AverageYMPEClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EmployeeContributionsFormulaClasses;
using RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.AdjustmentsClasses;
using RetirementStudio._UIMaps.MaxPensionDefinitionClasses;
using RetirementStudio._UIMaps.ExcessContributionDefinitionClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using RetirementStudio._UIMaps.ITAMaximumPensionsClasses;
using RetirementStudio._UIMaps.TableManagerClasses;
using RetirementStudio._UIMaps.ServiceSelectionClasses;
using RetirementStudio._UIMaps.SocialSecurityClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2019_Oct_BR
{
    /// <summary>
    /// Summary description for CR002_CN
    /// </summary>
    [CodedUITest]
    public class BR002_CN
    {
        public BR002_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.BR;
            Config.sClientName = "QA BR Benchmark 002 Create New";
            Config.sPlanName = "QA BR Benchmark 002 Create New Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory

        public string sOutput_Accounting2015_Baseline = "";
        public string sOutput_Funding2015_Baseline = "";

        public string sOutput_Funding2015_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_002\Production\Funding\Funding2015_Baseline\7.4_20190410_Franklin\";
        public string sOutput_Accounting2015_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_002\Production\Accounting\Accounting2015_Baseline\7.4_20190410_Franklin\";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BR_Benchmark_002\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    ////// _gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutput_Funding2015_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2015_Baseline\\" + sPostFix + "\\");
                    sOutput_Accounting2015_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting2015_Baseline\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "BR002_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutput_Funding2015_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Funding2015_Baseline\\");
                sOutput_Accounting2015_Baseline = _gLib._CreateDirectory(sMainDir + "Accounting\\Accounting2015_Baseline\\");

            }

            string sContent = "";

            sContent = sContent + "sOutput_Funding2015_Baseline = @\"" + sOutput_Funding2015_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutput_Accounting2015_Baseline = @\"" + sOutput_Accounting2015_Baseline + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion




        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public SocialSecurity pSocialSecurity = new SocialSecurity();
        public ServiceSelection pServiceSelection = new ServiceSelection();
        public TableManager pTableManager = new TableManager();
        public ITAMaximumPensions pITAMaximumPensions = new ITAMaximumPensions();
        public BenefitElections pBenefitElections = new BenefitElections();
        public ExcessContributionDefinition pExcessContributionDefinition = new ExcessContributionDefinition();
        public MaxPensionDefinition pMaxPensionDefinition = new MaxPensionDefinition();
        public Adjustments pAdjustments = new Adjustments();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public CostOfLivingAdjustments pCostOfLivingAdjustments = new CostOfLivingAdjustments();
        public EmployeeContributionsFormula pEmployeeContributionsFormula = new EmployeeContributionsFormula();
        public FAEFormula pFAEFormula = new FAEFormula();
        public AverageYMPE pAverageYMPE = new AverageYMPE();
        public FromToAge pFromToAge = new FromToAge();
        public DefinedBenefitLimitIncrease pDefinedBenefitLimitIncrease = new DefinedBenefitLimitIncrease();
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

        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_BR002_CN()
        {


            #region MultiThreads

            Thread thrd_Accounting2015_Baseline = new Thread(() => new BR002_CN().t_CompareRpt_Accounting2015_Baseline(sOutput_Accounting2015_Baseline));

            #endregion


            this.GenerateReportOuputDir();


            #region Accounting - Accounting2015_Baseling - ParticipantData

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
            dic.Add("Name", "31.12.2015 Accounting");
            dic.Add("Parent", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2015");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "31.12.2015 Accounting");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data Snapshot");
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

            #region Accounting - Accounting2015_Baseline - Assumptions & Provisions


            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ContinuousService");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ContinuousService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "HireDate1");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceFromDec1978");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceFromDec1978");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "31/12/1978");
            dic.Add("Date", "");
            dic.Add("RoundingRule", "Completed years");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "DTINSSService");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "DTINSSService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "DTINSS");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceLaterofJan1994AndDTINSS");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceLaterofJan1994AndDTINSS");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01/07/1994");
            dic.Add("Date", "DTINSS");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ServiceMembDateCappedAug2003");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceMembDateCappedAug2003");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
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
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("ServiceEnds_FixedDate", "31/08/2003");
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
            pAssumptions._TreeViewRightSelect(dic, "ServiceLaterOfAug2003AndMembDate");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ServiceLaterOfAug2003AndMembDate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "31/08/2003");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "MonthlyFutureService");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MonthlyFutureService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "($Age-$ValAge)*12+1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ModifiedDTINSSService");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ModifiedDTINSSService");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$DTINSSService");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ModifiedDTINSSService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ModifiedDTINSSService");
            dic.Add("Level_4", "Females");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$DTINSSService+5");
            dic.Add("Validate", "Click");
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
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ContinuousServiceCompletedYears");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ContinuousServiceCompletedYears");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "");
            dic.Add("RoundingRule", "Completed years");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SalaryHistory");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "SalaryHistory");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($ServiceLaterofJan1994AndDTINSS*0.8,0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "MonthlySalaryHistory");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MonthlySalaryHistory");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($SalaryHistory*12,0)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "LeftFutureServiceLess40Years");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "LeftFutureServiceLess40Years");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "True");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "SERVIN");
            dic.Add("RoundingRule", "");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("T", "");
            dic.Add("txtServiceIncrement", "");
            dic.Add("cboServiceIncrement", "");
            pService._PopVerify_ServiceAtValuationDate(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "ContinuousServiceNearestYears");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ContinuousServiceNearestYears");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "");
            dic.Add("RoundingRule", "Nearest years");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "MembershipAgeCompletedYears");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "MembershipAgeCompletedYears");
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
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "BirthDate");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("MaximumService_UseServiceCap", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "MembershipDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "Completed years");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "AgeAsOn12Jan1999");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "AgeAsOn12Jan1999");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "01/12/1999");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "NormalRetirementAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "NormalRetirementAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            //////////dic.Add("ServiceBasedOn", "ContinuousServiceCompletedYears");
            dic.Add("AgeBasedOn", "");
            ////////////dic.Add("Comparison", "Later of");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "ContinuousServiceCompletedYears");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "Later of");
            pFromToAge._StandardTable_DE(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "NormalRetirementAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "AgeAsOnMembDateGE45");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "NormalRetirementAge");
            dic.Add("Level_4", "AgeAsOnMembDateGE45");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "15");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "ContinuousServiceCompletedYears");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "ContinuousServiceCompletedYears");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$MembershipAgeCompletedYears>=45");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "MaximumAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "MaximumAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "75");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);

            dic.Clear();
            dic.Add("Comparison", "Earlier of");
            dic.Add("FromToAge", "NormalRetirementAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "MaximumAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "DTINSSLEDec1998");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "MaximumAge");
            dic.Add("Level_4", "DTINSSLEDec1998");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "40");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "LeftFutureServiceLess40Years");
            ////////////dic.Add("AgeBasedOn", "#1#");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "LeftFutureServiceLess40Years");
            dic.Add("AgeBasedOn", "#1#");
            pFromToAge._StandardTable_DE(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.DTINSS<= ToDate(1998,12,31)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "OldAge");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "OldAge");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "65");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "#1#");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            pFromToAge._StandardTable_DE(dic);


            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "35");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "DTINSSService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "2");
            dic.Add("ServiceBasedOn", "DTINSSService");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);

            dic.Clear();
            dic.Add("Comparison", "Earlier of");
            dic.Add("FromToAge", "MaximumAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "OldAge");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "OldAge");
            dic.Add("Level_4", "Females");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "60");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////dic.Add("ServiceBasedOn", "#1#");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);


            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "30");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            ////////////dic.Add("ServiceBasedOn", "DTINSSService");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "2");
            dic.Add("ServiceBasedOn", "DTINSSService");
            dic.Add("AgeBasedOn", "");
            pFromToAge._StandardTable_DE(dic);

            dic.Clear();
            dic.Add("Comparison", "Earlier of");
            dic.Add("FromToAge", "MaximumAge");
            pFromToAge._Standard_CompareAboveResultsTable(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender=\"F\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "YearOfDTINSSLT1990");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "YearOfDTINSSLT1990");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$emp.DTINSS<ToDate(1999,1,1)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "MembershipAgeGE45Years");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "MembershipAgeGE45Years");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$MembAge>=45");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "NormalRetirementEligibility");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "NormalRetirementEligibility");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$Age>=$NormalRetirementAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "TransferOut");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "TransferOut");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$emp.ParticipantStatus=\"ATO\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "OldAgeLEAgeAsOnJan1999");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "OldAgeLEAgeAsOnJan1999");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$OldAge<=$AgeAsOn12Jan1999");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "CODENQ1800And1501");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "CODENQ1800And1501");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$emp.CODENQ=1800 OR $emp.CODENQ=1501");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "CODENQ1600And1700");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "CODENQ1600And1700");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FreezeAtValuationAge", "");
            dic.Add("Formula", "$emp.CODENQ=1600 OR $emp.CODENQ=1700");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);




            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "6,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PICOToEconomicAssumption");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PICOToEconomicAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "9,6837");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PICOToCapOnSalary");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PICOToCapOnSalary");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "1,3343");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryIncrease");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "TransferOut");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,3");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "2,48");
            dic.Add("BenefitPICO", "");
            dic.Add("MinimumSalaryPICO", "");
            dic.Add("SSContributionCeilingPICO", "");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetireeAndMembDateGTJan1980");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "RetireeAndMembDateGTJan1980");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "0,92");
            dic.Add("BenefitPICO", "1,23");
            dic.Add("MinimumSalaryPICO", "2,34");
            dic.Add("SSContributionCeilingPICO", "3,45");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.MembershipDate1> ToDate(1980,01,10)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetireeAndMembDateLTJuly1974");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "RetireeAndMembDateLTJuly1974");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "2,70");
            dic.Add("BenefitPICO", "1,23");
            dic.Add("MinimumSalaryPICO", "2,34");
            dic.Add("SSContributionCeilingPICO", "3,45");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.MembershipDate1<ToDate(1974,07,01)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Actives");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Actives");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "1,85");
            dic.Add("BenefitPICO", "1,23");
            dic.Add("MinimumSalaryPICO", "2,34");
            dic.Add("SSContributionCeilingPICO", "3,45");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "847,02");
            dic.Add("SocialSecurityContributionCeiling", "5013,07");
            dic.Add("SocialSecurityMaximumBenefit", "4582,55");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus<>\"IN\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "AT2000_S10");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "NormalRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "ActivesOnly");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "ActivesOnly");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ITAU10");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus=\"AC\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "NormalRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LIGHTFRA");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "SalaryProjection");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "SalaryProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "True");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "false");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("UseCurrentYearPayRateFrom", "BasicPayCurrentYear");
            dic.Add("PayIncreaseAssumption", "SalaryIncrease");
            pPayoutProjection._PopVerify_PresentYear(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PICOAdjustedProjectedPay");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PICOAdjustedProjectedPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$SalaryProjection*(1+$_PICO)*$_BCF");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "AnnualizedPayProjection");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "AnnualizedPayProjection");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "True");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "true");
            dic.Add("ApplyPayLimitAfterDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "$PICOAdjustedProjectedPay*$_NumSalary");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "ContinuousServiceNYatNRA");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service Selection");
            dic.Add("Level_3", "ContinuousServiceNYatNRA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "ContinuousServiceNearestYears");
            dic.Add("V", "click");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "NormalRetirementAge");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "AnnualizedPICOAdjustedBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AnnualizedPICOAdjustedBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Benefit1DB*$_NumBenefit*$_BCF*(1+$_PICO)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "HC_SalaryCap");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "HC_SalaryCap");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "5413.05*$_BCF");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "HC_PICOAdjustedMinimumBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "HC_PICOAdjustedMinimumBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "367.39*(1+$PICOToCapOnSalary)*$_BCF");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CappedBenefitSalary");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "CappedBenefitSalary");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($PICOAdjustedProjectedPay,10*$HC_PICOAdjustedMinimumBenefit)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "AnnualizedFactor");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "AnnualizedFactor");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$_NumBenefit*$_BCF");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "HC_IndexFATINV");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "HC_IndexFATINV");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1+(0.623/11.813)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security");
            dic.Add("MenuItem", "Add Social Security");
            pAssumptions._TreeViewRightSelect(dic, "SocialSecurity_FinalPensionPay");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security");
            dic.Add("Level_4", "SocialSecurity_FinalPensionPay");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SalaryIncreaseAssumption", "SalaryIncrease");
            dic.Add("PayProjection", "PICOAdjustedProjectedPay");
            dic.Add("LifeExpectancyTable", "IBGE2013");
            pSocialSecurity._SocialSecurity_BR(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Calculation", "SocialSecurity_FinalPensionPay_FutureService");
            dic.Add("Override_V", "MonthlyFutureService");
            pSocialSecurity._CalculationOverrides(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Calculation", "SocialSecurity_FinalPensionPay_NSalary");
            dic.Add("Override_V", "SalaryHistory");
            pSocialSecurity._CalculationOverrides(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security");
            dic.Add("Level_4", "SocialSecurity_FinalPensionPay");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Social Security");
            dic.Add("Level_4", "SocialSecurity_FinalPensionPay");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SalaryIncreaseAssumption", "SalaryIncrease");
            dic.Add("PayProjection", "PICOAdjustedProjectedPay");
            dic.Add("LifeExpectancyTable", "IBGE2013");
            pSocialSecurity._SocialSecurity_BR(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Calculation", "SocialSecurity_FinalPensionPay_FutureService");
            dic.Add("Override_V", "MonthlyFutureService");
            pSocialSecurity._CalculationOverrides(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Calculation", "SocialSecurity_FinalPensionPay_NSalary");
            dic.Add("Override_V", "SalaryHistory");
            pSocialSecurity._CalculationOverrides(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Calculation", "SocialSecurity_FinalPensionPay_FactorINSS");
            dic.Add("Override_C", "1,00000000");
            pSocialSecurity._CalculationOverrides(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "TransferOut");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "INSSPay");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "INSSPay");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($PICOAdjustedProjectedPay*$SocialSecurity_FinalPensionPay_FactorINSS,$_SSContribCeilingPICOCap)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SocialSecurityRetirementBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityRetirementBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min($INSSPay*$SocialSecurity_FinalPensionPay_NewFactorSS_LTS_Prop,$SocialSecurity_FinalPensionPay_UpdatedCeilingSS)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityRetirementBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityRetirementBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($_MinSalary,Min($INSSPay*Max($SocialSecurity_FinalPensionPay_NewFactorSS_OldAge,1),$SocialSecurity_FinalPensionPay_UpdatedCeilingSS))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "OldAgeLEAgeAsOnJan1999");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SocialSecurityDisabilityBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityDisabilityBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max(Min($INSSPay,$SocialSecurity_FinalPensionPay_UpdatedCeilingSS),$_MinSalaryPICOCap)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityDisabilityBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "SocialSecurityDisabilityBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($_MinSalaryPICOCap,Min($INSSPay*Max($SocialSecurity_FinalPensionPay_NewFactorSS_LTS_Prop,1),$SocialSecurity_FinalPensionPay_UpdatedCeilingSS))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "OldAgeLEAgeAsOnJan1999");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "RetirementBenefitOffset");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "RetirementBenefitOffset");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(($ServiceMembDateCappedAug2003*$SocialSecurityRetirementBenefit)+($ServiceLaterofAug2003AndMembDate*$CappedBenefitSalary))/($ServiceMembDateCappedAug2003+$ServiceLaterofAug2003AndMembDate)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DisabilityBenefitOffset");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "DisabilityBenefitOffset");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(($ServiceMembDateCappedAug2003*$SocialSecurityDisabilityBenefit)+($ServiceLaterofAug2003AndMembDate*$CappedBenefitSalary))/($ServiceMembDateCappedAug2003+$ServiceLaterofAug2003AndMembDate)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "FinalDisabilityBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalDisabilityBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit, Max($PICOAdjustedProjectedPay-$DisabilityBenefitOffset,0))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalDisabilityBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalDisabilityBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit,Min(~FractionOnSalaryExceedINSS($ContinuousServiceNearestYears)*($PICOAdjustedProjectedPay-$DisabilityBenefitOffset),(30*$HC_PICOAdjustedMinimumBenefit-$RetirementBenefitOffset)))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "CODENQ1800And1501");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalDisabilityBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalDisabilityBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit, Max(Min($PICOAdjustedProjectedPay,14.31*$HC_SalaryCap)- $DisabilityBenefitOffset,0))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "CODENQ1600And1700");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "FinalRetirementBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalRetirementBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit, Max($PICOAdjustedProjectedPay-$RetirementBenefitOffset,0))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalRetirementBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalRetirementBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit,Min(~FractionOnSalaryExceedINSS($ContinuousServiceNearestYears)*($PICOAdjustedProjectedPay-$RetirementBenefitOffset),((30*$HC_PICOAdjustedMinimumBenefit)-$RetirementBenefitOffset)))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "CODENQ1800And1501");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalRetirementBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalRetirementBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max($HC_PICOAdjustedMinimumBenefit, Max(Min($PICOAdjustedProjectedPay,14.31*$HC_SalaryCap)-$RetirementBenefitOffset,0))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "CODENQ1600And1700");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalBenefitOffset");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "WithdrawalBenefitOffset");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(($ServiceMembDateCappedAug2003*$SocialSecurityRetirementBenefit[$NormalRetirementAge])+($ServiceLaterofAug2003AndMembDate[$NormalRetirementAge]*$CappedBenefitSalary))/($ServiceMembDateCappedAug2003+$ServiceLaterofAug2003AndMembDate[$NormalRetirementAge])");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "FinalWithdrawalBenefit");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalWithdrawalBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalWithdrawalBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "FinalWithdrawalBenefit");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(~FractionOnSalaryExceedINSS($ContinuousServiceNYatNRA)*($PICOAdjustedProjectedPay-$WithdrawalBenefitOffset),(30*$HC_PICOAdjustedMinimumBenefit)-$WithdrawalBenefitOffset)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "CODENQ1800And1501");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "VestingForDisability");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "VestingForDisability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "ContinuousServiceCompletedYears");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "10");
            dic.Add("VestingPercentage", "100");
            pVesting._ServiceTable(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "VestingForWithdrawal");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "VestingForWithdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingServiceDefinition", "ContinuousServiceCompletedYears");
            dic.Add("AddRow", "");
            pVesting._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("YearsOfService", "3");
            dic.Add("VestingPercentage", "100");
            pVesting._ServiceTable(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "Vesting");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Vesting");
            dic.Add("Level_3", "Vesting");
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
            dic.Add("Level_2", "Vesting");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLARate");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "COLARate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "COLARate");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "BenefitGrowthClass");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "COLARate");
            dic.Add("Level_4", "BenefitGrowthClass");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLA_End", "");
            dic.Add("COLA_DuringDeferral", "true");
            dic.Add("COLA_End_Age", "");
            dic.Add("COLA_AfterBenefit_Rate_V", "click");
            dic.Add("COLA_AfterBenefit_Rate_cbo_V", "CostOfLivingIncreaseAssumption");
            dic.Add("COLA_AfterBenefit_Rate_C", "");
            dic.Add("COLA_AfterBenefit_Rate_txt", "");
            dic.Add("COLA_During_Rate_V", "click");
            dic.Add("COLA_During_Rate_cbo_V", "CostOfLivingIncreaseAssumption");
            dic.Add("COLA_During_Rate_C", "");
            dic.Add("COLA_During_Rate_txt", "");
            pCostOfLivingAdjustments._COLADuringDeferral_NL(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "($emp.CODENQ=300 Or $emp.CODENQ=1400 Or $emp.CODENQ=1401 Or $emp.CODENQ=1402 Or $emp.CODENQ=1403)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "AEValuationAssumption");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "AEValuationAssumption");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "True");
            dic.Add("ValuationMortality", "True");
            dic.Add("ValuationCOLA", "");
            dic.Add("ValuationSpouseAgeDiff", "True");
            dic.Add("ValuationPercentMarried", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboInterestRate", "COLARate");
            dic.Add("txtInterestRate", "");
            dic.Add("Mortality", "");
            pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("MenuItem", "Add Actuarial Equivalence");
            pAssumptions._TreeViewRightSelect(dic, "AEPreCommencementIntRate");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            dic.Add("Level_3", "AEPreCommencementIntRate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationInterest", "");
            dic.Add("ValuationMortality", "True");
            dic.Add("ValuationCOLA", "");
            dic.Add("ValuationSpouseAgeDiff", "True");
            dic.Add("ValuationPercentMarried", "");
            pActuarialEquivalence._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencement_V", "");
            dic.Add("PreCommencement_P", "0,0");
            dic.Add("PostCommencement_V", "InterestPostCommencement");
            dic.Add("PostCommencement_P", "");
            dic.Add("CostOfLivingIncrease_V", "COLARate");
            dic.Add("CostOfLivingIncrease_P", "");
            pActuarialEquivalence._PrePostCommencement_ValuationMortality_SpouseAgeDif(dic);


            _gLib._MsgBox("check::!!", "PreCommencement_P  ->  0,0" + Environment.NewLine + "PostCommencement_V  ->  InterestPostCommencement");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Actuarial Equivalence");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "PVToExitAgeFromNRA");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "PVToExitAgeFromNRA");
            dic.Add("Level_4", "Default");
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
            dic.Add("FormOfPaymentType_From", "Lump sum");
            dic.Add("FormOfPaymentType_To", "");
            dic.Add("MortalityInDeferralPeriod_From", "");
            dic.Add("MortalityInDeferralPeriod_To", "");
            dic.Add("ActuarialEquivalence_From", "AEValuationAssumption");
            dic.Add("ActuarialEquivalence_To", "");
            dic.Add("ApplySpouseAgeDifference_From", "");
            dic.Add("ApplySpouseAgeDifference_To", "");


            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "click");
            dic.Add("GuaranteePeriod_From_txt", "");

            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "click");
            dic.Add("SurvivorPercentage_From_txt", "");

            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "click");
            dic.Add("PopupAmount_From_txt", "");

            dic.Add("btnBenefitCommenceAge_From_V", "click");
            dic.Add("BenefitCommenceAge_From_cbo", "NormalRetirementAge");
            dic.Add("btnBenefitCommenceAge_From_C", "");
            dic.Add("BenefitCommenceAge_From_txt", "");

            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "");
            dic.Add("BenefitStopAge_From_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");

            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "");
            dic.Add("GuaranteePeriod_To_txt", "");

            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "");
            dic.Add("SurvivorPercentage_To_txt", "");

            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "");
            dic.Add("PopupAmount_To_txt", "");

            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "");
            dic.Add("BenefitCommenceAge_To_txt", "");

            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "");
            dic.Add("BenefitStopAge_To_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "");
            pConversionFactors._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("MenuItem", "Add Conversion Factors");
            pAssumptions._TreeViewRightSelect(dic, "CFLAToLADefToAge55");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Conversion Factors");
            dic.Add("Level_3", "CFLAToLADefToAge55");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType_From", "");
            dic.Add("FormOfPaymentType_To", "");
            dic.Add("MortalityInDeferralPeriod_From", "");
            dic.Add("MortalityInDeferralPeriod_To", "Member only mortality");
            dic.Add("ActuarialEquivalence_From", "AEPreCommencementIntRate");
            dic.Add("ActuarialEquivalence_To", "AEValuationAssumption");
            dic.Add("ApplySpouseAgeDifference_From", "");
            dic.Add("ApplySpouseAgeDifference_To", "");


            dic.Add("btnGuaranteePeriod_From_V", "");
            dic.Add("GuaranteePeriod_From_cbo", "");
            dic.Add("btnGuaranteePeriod_From_C", "click");
            dic.Add("GuaranteePeriod_From_txt", "");

            dic.Add("btnSurvivorPercentage_From_V", "");
            dic.Add("SurvivorPercentage_From_cbo", "");
            dic.Add("btnSurvivorPercentage_From_Percent", "click");
            dic.Add("SurvivorPercentage_From_txt", "");

            dic.Add("btnPopupAmount_From_V", "");
            dic.Add("PopupAmount_From_cbo", "");
            dic.Add("btnPopupAmount_From_C", "click");
            dic.Add("PopupAmount_From_txt", "");

            dic.Add("btnBenefitCommenceAge_From_V", "click");
            dic.Add("BenefitCommenceAge_From_cbo", "NormalRetirementAge");
            dic.Add("btnBenefitCommenceAge_From_C", "");
            dic.Add("BenefitCommenceAge_From_txt", "");

            dic.Add("btnBenefitStopAge_From_V", "");
            dic.Add("BenefitStopAge_From_cbo", "");
            dic.Add("btnBenefitStopAge_From_C", "click");
            dic.Add("BenefitStopAge_From_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
            dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_From_C", "click");
            dic.Add("NumberOfPaymentsPerYear_From_txt", "");

            dic.Add("btnGuaranteePeriod_To_V", "");
            dic.Add("GuaranteePeriod_To_cbo", "");
            dic.Add("btnGuaranteePeriod_To_C", "click");
            dic.Add("GuaranteePeriod_To_txt", "");

            dic.Add("btnSurvivorPercentage_To_V", "");
            dic.Add("SurvivorPercentage_To_cbo", "");
            dic.Add("btnSurvivorPercentage_To_Percent", "click");
            dic.Add("SurvivorPercentage_To_txt", "");

            dic.Add("btnPopupAmount_To_V", "");
            dic.Add("PopupAmount_To_cbo", "");
            dic.Add("btnPopupAmount_To_C", "click");
            dic.Add("PopupAmount_To_txt", "");

            dic.Add("btnBenefitCommenceAge_To_V", "");
            dic.Add("BenefitCommenceAge_To_cbo", "");
            dic.Add("btnBenefitCommenceAge_To_C", "click");
            dic.Add("BenefitCommenceAge_To_txt", "55");

            dic.Add("btnBenefitStopAge_To_V", "");
            dic.Add("BenefitStopAge_To_cbo", "");
            dic.Add("btnBenefitStopAge_To_C", "click");
            dic.Add("BenefitStopAge_To_txt", "");

            dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
            dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
            dic.Add("btnNumberOfPaymentsPerYear_To_C", "click");
            dic.Add("NumberOfPaymentsPerYear_To_txt", "1");
            pConversionFactors._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "MonthlyLifeAnnuityFOP");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "MonthlyLifeAnnuityFOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "AnnualLifeAnnuityFOP");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "AnnualLifeAnnuityFOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Straight life");
            dic.Add("MortalityInReferralPeriod", "Member only mortality");

            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
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
            dic.Add("btnNumberOfPaymentsPerYear_C", "click");
            dic.Add("NumberOfPaymentsPerYear_txt", "1");
            pFormOfPayment._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "LumpSumFOP");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "LumpSumFOP");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MortalityInReferralPeriod", "");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "AnnualizedAdjustment");

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "AnnualizedAdjustment");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "AnnualizedFactor");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "Benefit");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("MenuItem", "Add Custom Provision");
            pAssumptions._TreeViewRightSelect(dic, "WithdrawalBenefitForPV");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Custom Provision");
            dic.Add("Level_3", "WithdrawalBenefitForPV");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$FinalWithdrawalBenefit*($_ActTPX[$NormalRetirementAge]/$_ActTPX)*$PVToExitAgeFromNRA*$CFLAToLADefToAge55*$HC_IndexFATINV");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVInactive");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVInactive");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "AnnualizedPICOAdjustedBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "0");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLARate");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "MonthlyLifeAnnuityFOP");
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
            pPlanDefinition._PopVerify_PlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVRetirement");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVRetirement");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "FinalRetirementBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLARate");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AnnualizedAdjustment");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "MonthlyLifeAnnuityFOP");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVDisability");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDisability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "FinalDisabilityBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "0");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "VestingForDisability");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AnnualizedAdjustment");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "MonthlyLifeAnnuityFOP");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVWithdrawal");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVWithdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "WithdrawalBenefitForPV");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "55");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "VestingForWithdrawal");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AnnualizedAdjustment");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualLifeAnnuityFOP");
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
            dic.Add("PostDecrementMortality", "AEValuationAssumption");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVDeath");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVDeath");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "CappedBenefitSalary");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "0");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "LumpSumFOP");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PVSpecialWithdrawal");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PVSpecialWithdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "true");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaBenefit", "WithdrawalBenefitForPV");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_txt", "55");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_txt", "120");
            dic.Add("VestingDefinition", "VestingForWithdrawal");
            dic.Add("CostOfLivingAdjustmentFactor", "");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "AnnualizedAdjustment");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "AnnualLifeAnnuityFOP");
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
            dic.Add("PostDecrementMortality", "AEValuationAssumption");
            dic.Add("SpecialWithdrawalBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Accounting - Accounting2015_Baseline - Methods & TestCase

            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("CostMethod", "Projected Unit Credit Service Prorate");
            dic.Add("ServiceForServiceProrate", "ContinuousService");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "true");
            dic.Add("ProjectedpayToUse", "AnnualizedPayProjection");
            dic.Add("ProjectedpayToUse_CA", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "Vesting");
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "true");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("BenefitDefinition", "PVDeath");
            dic.Add("PUCOverrides", "Projected Unit Credit No Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("31.12.2015 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=100004358");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Accounting - Accounting2015_Baseline - Run ER & Report

            pMain._SelectTab("31.12.2015 Accounting");

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
            dic.Add("AllLiabilityTypes", "true");
            dic.Add("Acc_ProjectedBenefitObligation", "True");
            dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("PayoutProjection", "true");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "AnnualizedPayProjection");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "N/A");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("31.12.2015 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("31.12.2015 Accounting");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Parameter Print", "Conversion", true, false);

            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Liability Summary", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Liability Summary", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Member Statistics", "Conversion", false, false);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Conversion Diagnostic", "Conversion", false, false, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Test Case List", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Detailed Results", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Detailed Results by Plan Def", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Valuation Summary", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Individual Output", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Accounting2015_Baseline, "IOE", "Conversion", false, false);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Accounting2015_Baseline, "Payout Projection", "Conversion", false, false);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Accounting2015_Baseline, "FAS Expected Benefit Pmts", "Conversion", false, false);


            thrd_Accounting2015_Baseline.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("31.12.2015 Accounting");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Funding - Funding2015_Baseline - ParticipantData


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
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
            dic.Add("Name", "31.12.2015 Funding");
            dic.Add("Parent", "");
            dic.Add("PlanYearBeginningIn", "2015");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "31.12.2015 Funding");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("31.12.2015 Funding");

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
            dic.Add("Snapshot", "true");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "Click");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Valuation Data Snapshot");
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

            #region Funding - Funding2015_Baseline - Assumptions & Provisions


            pMain._SelectTab("31.12.2015 Funding");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Copy Provisions...");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceType", "AccountingValuations");
            dic.Add("ServiceInstance", "");
            dic.Add("iTableItemIndex", "1");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "31.12.2015 Funding");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("31.12.2015 Funding");

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
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PICOToEconomicAssumptions");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PICOToEconomicAssumptions");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,5737");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "PICOToCapOnSalary");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "PICOToCapOnSalary");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "1,3343");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "SalaryIncrease");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "SalaryIncrease");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "TransferOut");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,3");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "2,48");
            dic.Add("BenefitPICO", "");
            dic.Add("MinimumSalaryPICO", "");
            dic.Add("SSContributionCeilingPICO", "");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetireeAndMembDateGTJan1980");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "RetireeAndMembDateGTJan1980");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "0,92");
            dic.Add("BenefitPICO", "");
            dic.Add("MinimumSalaryPICO", "");
            dic.Add("SSContributionCeilingPICO", "");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.MembershipDate1> ToDate(1980,01,10)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RetireeAndMembDateLTJuly1974");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "RetireeAndMembDateLTJuly1974");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "2,70");
            dic.Add("BenefitPICO", "");
            dic.Add("MinimumSalaryPICO", "");
            dic.Add("SSContributionCeilingPICO", "");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "");
            dic.Add("SocialSecurityContributionCeiling", "");
            dic.Add("SocialSecurityMaximumBenefit", "");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.MembershipDate1<ToDate(1974,07,01)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Actives");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumption");
            dic.Add("Level_3", "Actives");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BenefitCapacityFactor", "0,980");
            dic.Add("PICO", "1,85");
            dic.Add("BenefitPICO", "1,23");
            dic.Add("MinimumSalaryPICO", "9,68");
            dic.Add("SSContributionCeilingPICO", "9,68");
            dic.Add("NumberOfBenefitPayments", "13");
            dic.Add("NumberofSalaryPeriod", "");
            dic.Add("NumberofContributions", "");
            dic.Add("MinmumSalary", "788,00");
            dic.Add("SocialSecurityContributionCeiling", "4663,75");
            dic.Add("SocialSecurityMaximumBenefit", "4676,07");
            pOtherEconomicAssumption._PopVerify_Main_BR(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus<>\"IN\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "AT2000_S10");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "_Retirement");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "NormalRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Actives");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "Actives");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ITAU10");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus=\"AC\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "_Withdrawal");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "NormalRetirementEligibility");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "_Disability");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "LIGHTFRA");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("31.12.2015 Funding");

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
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Ratio");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Ratio");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            for (int i = 1; i <= 14; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Participant Info");
                dic.Add("Level_2", "Service");
                dic.Add("Level_3", "Ratio");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "ContinuousService");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula A");
            dic.Add("Level_4", "HC_PICOAdjustedMinimumBenefit");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "367.09*(1+$PICOToCapOnSalary)*$_BCF");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Funding - Funding2015_Baseline - Methods

            pMain._SelectTab("31.12.2015 Funding");

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
            dic.Add("ServiceForServiceProrate", "Ratio");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "true");
            dic.Add("NormalCostForCYTermination", "No");
            dic.Add("NormalCostForCYTermination_UK", "");
            dic.Add("ProjectedPayToUseForCoveredPay", "AnnualizedPayProjection");
            dic.Add("AccumulationToUseForExepctedPVOfEmployee", "");
            dic.Add("IncludeChangesInPVFutureEEGainLoss", "");
            dic.Add("AccumulationToUseForExepctedPVOfEmployer", "");
            dic.Add("BeginningOfTheYearPVFuture", "");
            dic.Add("StopPVFuture_V", "click");
            dic.Add("StopPVFuture_cbo", "NormalRetirementAge");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);


            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("sName", "PVDeath");
            dic.Add("sStatus", "false");
            pMethods._BenefitsToInclude_GoingConcern(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            #region Funding - Funding2015_Baseline - TestCase



            pMain._SelectTab("31.12.2015 Funding");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.EmployeeIDNumber=100000005");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Funding - Funding2015_Baseline - Run ER & Report

            pMain._SelectTab("31.12.2015 Funding");

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
            dic.Add("GoingConcernLiability", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjection", "true");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "true");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "AnnualizedPayProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AnnualizedFactor");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("31.12.2015 Funding");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("31.12.2015 Funding");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Funding2015_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Funding2015_Baseline, "Liability Summary", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutput_Funding2015_Baseline, "Liability Summary", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Funding2015_Baseline, "Member Statistics", "Conversion", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(sOutput_Funding2015_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Funding2015_Baseline, "Test Case List", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Funding2015_Baseline, "Detailed Results", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Funding2015_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(sOutput_Funding2015_Baseline, "Valuation Summary", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Funding2015_Baseline, "Individual Output", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Funding2015_Baseline, "IOE", "Conversion", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(sOutput_Funding2015_Baseline, "Payout Projection", "Conversion", false, true);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("BR002_CN", sOutput_Funding2015_Baseline_Prod, sOutput_Funding2015_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutput_Funding2015_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                Config.bThreadFinsihed = true;
            }

            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("31.12.2015 Funding");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("!", "Finished");

        }


        public void t_CompareRpt_Accounting2015_Baseline(string sOutput_Accounting2015_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("BR002_CN", sOutput_Accounting2015_Baseline_Prod, sOutput_Accounting2015_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutput_Accounting2015_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
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

