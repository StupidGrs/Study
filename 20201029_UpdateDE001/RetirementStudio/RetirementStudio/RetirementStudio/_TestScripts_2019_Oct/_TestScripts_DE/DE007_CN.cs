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
using RetirementStudio._UIMaps.ContributionsBasedFormulaClasses;


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
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using System.Threading;
using System.Threading;

namespace RetirementStudio._TestScripts_2019_Oct_DE
{
    /// <summary>
    /// Summary description for DE007_CN
    /// </summary>
    [CodedUITest]
    public class DE007_CN
    {
        public DE007_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 007 Create New";
            Config.sPlanName = "QA DE Benchmark 007 Create New Plan";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory


        public string sOutputPension_Stichtag2011_Teriferhoehung = "";
        public string sOutputPension_Stichtag2011_IFRSneueAnnahmen = "";

        public string sOutputPension_Stichtag2011_Teriferhoehung_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_007\Existing\Stichtag 2011 Final\Tariferhoehung\000_7.4_Baseline\";
        public string sOutputPension_Stichtag2011_IFRSneueAnnahmen_Prod = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_007\Existing\Stichtag 2011 Final\IFRS neue Annahmen\000_7.4_Baseline\";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_007\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();


                    sOutputPension_Stichtag2011_Teriferhoehung = _gLib._CreateDirectory(sMainDir + "Stichtag 2011 Final\\Tariferhoehung\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_IFRSneueAnnahmen = _gLib._CreateDirectory(sMainDir + "Stichtag 2011 Final\\IFRS neue Annahmen\\" + sPostFix + "\\");
                }
            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Stichtag2011_Teriferhoehung = @\"" + sOutputPension_Stichtag2011_Teriferhoehung + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_IFRSneueAnnahmen = @\"" + sOutputPension_Stichtag2011_IFRSneueAnnahmen + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);
        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public MyDictionary dic = new MyDictionary();
        public ContributionsBasedFormula pContributionsBasedFormula = new ContributionsBasedFormula();
        public ActuarialReport pActuarialReport = new ActuarialReport();
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

        public PayCredit pPayCredit = new PayCredit();


        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_DE007_CN()
        {


            #region MultiThreads

            Thread thrd_Stichtag2011_Teriferhoehung = new Thread(() => new DE007_CN().t_CompareRpt_Stichtag2011_Teriferhoehung(sOutputPension_Stichtag2011_Teriferhoehung));

            #endregion


            this.GenerateReportOuputDir();


            #region Pension - Stichtag2011Final - Tariferhoehung

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
            dic.Add("Name", "Stichtag 2011 Final");
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
            dic.Add("ServiceToOpen", "Stichtag 2011 Final");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Tariferhoehung");
            dic.Add("LiabilityValuationDate", "31.03.2011");
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


            pMain._SelectTab("Stichtag 2011 Final");

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
            dic.Add("SnapshotName", "Val2011");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "True");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Last Year");
            dic.Add("Level_2", "LYUSC");
            dic.Add("Level_3", "");
            dic.Add("Level_4", "");
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



            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");

            pMethods._SelectTab("Trade");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,15");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011 Final");

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
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_pensionableService");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Completed");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_FromLastContributionDate");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_FromLastContributionDate");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01.11.2010");
            dic.Add("ServiceStarts_Date", "#1#");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Months");
            dic.Add("RoundingMethod", "Completed");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_OneYear");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_OneYear");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$age-$valage+1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_FehlendeMonate");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_FehlendeMonate");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_FehlendeMonate");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_FehlendeMonate");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("ServiceAsAFunction", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
            pService._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("Function", "Max(0,$SVC_FromLastContributionDate-($age-$ValAge))");
            dic.Add("Validate", "click");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "GEAssumedRetAge");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "($age=$_AssumedRetirementAge) OR ($ValAge>=$_AssumedRetirementAge)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "EL_GEAssumedRetAge");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("Level_5", "EL_GEAssumedRetAge");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$AGE>=$_AssumedRetirementAge");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_PayProjection");
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
            dic.Add("UseCurrentYearPayRateFrom", "SalaryCurrentYear");
            dic.Add("PayIncreaseAssumption", "AsPI_Gehaltstrend");
            pPayoutProjection._PopVerify_PresentYear(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_BBG");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$_SocSecContribCeiling");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_BBG");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$_SocSecContribCeiling");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "PC_BeitragHochrechnung");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_BeitragHochrechnung");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PP_PayProjection");
            dic.Add("ServiceBasedOn", "SVC_OneYear");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "2");
            pFAEFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "CFA_BBG");
            dic.Add("sData3", "0,005");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "CFA_Obergrenze");
            dic.Add("sData3", "0,02");
            pFAEFormula._TBL_Excess(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "PC_FinanzierungsbeitragOldAge");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_FinanzierungsbeitragOldAge");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PP_PayProjection");
            dic.Add("ServiceBasedOn", "SVC_FehlendeMonate");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "2");
            pFAEFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "CFA_BBG");
            dic.Add("sData3", "0,005");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "CFA_Obergrenze");
            dic.Add("sData3", "0,02");
            pFAEFormula._TBL_Excess(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_Bausteinkonto");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "International");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_Bausteinkonto");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PreDefinedAmount", "");
            dic.Add("AccountBalance", "");
            dic.Add("StartAge", "");
            dic.Add("PreDefinedAmount_cbo", "PC_BeitragHochrechnung");
            dic.Add("TransformationRate_Percent", "");
            pContributionsBasedFormula._ContributionsBasedFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("MenuItem", "Add Contributions Based Formula");
            pAssumptions._TreeViewRightSelect(dic, "CBF_BausteinkontoAR");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_BausteinkontoAR");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "International");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_BausteinkontoAR");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PreDefinedAmount", "true");
            dic.Add("AccountBalance", "EeAccountBalance1");
            dic.Add("StartAge", "$HireAge");
            dic.Add("PreDefinedAmount_cbo", "PC_BeitragHochrechnung");
            dic.Add("TransformationRate_Percent", "click");
            dic.Add("TransformationRate_Rate", "100,0");
            pContributionsBasedFormula._ContributionsBasedFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_BausteinkontoAR");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PreDefinedAmount", "true");
            dic.Add("AccountBalance", "EeAccountBalance1");
            dic.Add("StartAge", "$HireAge");
            dic.Add("PreDefinedAmount_cbo", "PC_BeitragFinal");
            dic.Add("TransformationRate_Percent", "click");
            dic.Add("TransformationRate_Rate", "100,0");
            pContributionsBasedFormula._ContributionsBasedFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_BausteinkontoHochgerechnet");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PC_BeitragHochrechnung*((~Bausteinzurechnung)+Max(0,$SVC_FromLastContributionDate-($age-$ValAge))*(~Bausteintabelle(65)))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_FinalBenefit");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CFB_BausteinkontoHochgerechnet+$CBF_BausteinkontoAR");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_FinalBenefitSpouse");
            dic.Add("Level_7", "IFRS");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CFB_FinalBenefit");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_Altersrente");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CBF_BausteinkontoAR[$ExitAge]+$PC_FinanzierungsbeitragOldAge");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_OldAgePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_OldAgeRev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CFA_DI_SpousePension");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "Click");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_DisabilityPension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CFA_DI_DisabilityPension");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_DisabilityPension");
            dic.Add("Level_6", "EL_DI_BUAbsicherung");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_DisabilityRev");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "COND");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "DirectIns_SpousePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_C", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("FirstStartAge_V", "");
            dic.Add("FirstStartAge_C", "");
            dic.Add("LastStartAge_V", "");
            dic.Add("LastStartAge_C", "");
            dic.Add("NumberOfPayments_V", "");
            dic.Add("NumberOfPayments_C", "");
            dic.Add("MaximumNumberOfPayments_V", "");
            dic.Add("MaximumNumberOfPayments_C", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("FirstStartAge_cbo", "");
            dic.Add("FirstStartAge_txt", "");
            dic.Add("LastStartAge_cbo", "");
            dic.Add("LastStartAge_txt", "");
            dic.Add("NumberOfPayments_cbo", "");
            dic.Add("NumberOfPayments_txt", "");
            dic.Add("MaximumNumberOfPayments_cbo", "");
            dic.Add("MaximumNumberOfPayments_txt", "");
            dic.Add("Eligibility", "");
            dic.Add("VestedRatio", "");
            dic.Add("CostOfLivingAdjustment", "COLA_InsuranceRAP");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Stichtag 2011 Final");


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
            dic.Add("AverageWorkingLifeTimeToVesting", "true");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Stichtag 2011 Final");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"07.30.1926\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Stichtag 2011 Final");


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
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_PayProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "COND");
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


            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Test Cases", "RollForward", true, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "DirectPromise" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Teriferhoehung, "Payout Projection", "RollForward", false, true, dic);


            thrd_Stichtag2011_Teriferhoehung.Start();


            pMain._SelectTab("Output Manager");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011 Final");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region  Pension - Stichtag2011Final - IFRS neue Annahmen

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "IFRS neue Annahmen");
            dic.Add("LiabilityValuationDate", "31.03.2011");
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



            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pMethods._SelectTab("IntAccounting");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,6");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011 Final");


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
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PP_PayProjection");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "COND");
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

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2011 Final");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Test Cases", "RollForward", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "DirectPromise" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_IFRSneueAnnahmen, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);



            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE007CN", sOutputPension_Stichtag2011_IFRSneueAnnahmen_Prod, sOutputPension_Stichtag2011_IFRSneueAnnahmen);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_IFRSneueAnnahmen");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DirectPromise.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                //////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0 ,true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0, true);
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
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Stichtag 2011 Final");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "Finished ! ");

        }



        public void t_CompareRpt_Stichtag2011_Teriferhoehung(string sOutputPension_Stichtag2011_Teriferhoehung)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE007CN", sOutputPension_Stichtag2011_Teriferhoehung_Prod, sOutputPension_Stichtag2011_Teriferhoehung);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_Teriferhoehung");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DirectPromise.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0);
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
