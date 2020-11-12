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
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.ContributionsBasedFormulaClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using System.Threading;

namespace RetirementStudio._TestScripts._TestScripts_DE
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class _DE005_CN
    {
        public _DE005_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 005 Existing DNT";
            Config.sPlanName = "QA DE Benchmark 005 Existing DNT Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = true;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory



        // public string sOutputPension_Conversion2009 = "";
        public string sOutputPension_Stichtag2010 = "";

        //public string sOutputPension_Conversion2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_005\Production\7.2_20180319_B\Conversion2009\";
        public string sOutputPension_Stichtag2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_005\Existing\Val\Stichtag2010\000_7.4_Baseline\";
        public string sService_Pension_Stichtag2010 = "Stichtag 2010_2019Testing";


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_005\Create New\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    //sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "Conversion2009\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010 = _gLib._CreateDirectory(sMainDir + "Stichtag2010\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "DE005_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                //sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2009\\");
                sOutputPension_Stichtag2010 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010\\");

            }

            string sContent = "";
            //sContent = sContent + "sOutputPension_Conversion2009 = @\"" + sOutputPension_Conversion2009 + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010 = @\"" + sOutputPension_Stichtag2010 + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();


        public ActuarialReport pActuarialReport = new ActuarialReport();
        public ContributionsBasedFormula pContributionsBasedFormula = new ContributionsBasedFormula();
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
        public void _test_DE005_CN()
        {


            this.GenerateReportOuputDir();
            sService_Pension_Stichtag2010 = "Stichtag 2010_2019Testing";


            #region Pension RF Valuation - Stichtag 2010_2019Testing


            #region Create Service and Import Data

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "PensionValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "");
            dic.Add("Name", sService_Pension_Stichtag2010);
            dic.Add("Parent", "Conversion2009");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2010");
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
            dic.Add("ServiceToOpen", sService_Pension_Stichtag2010);
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



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
            dic.Add("SnapshotName", "Unload 2010");
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


            #endregion


            #region Assumptions

            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pMain._SelectTab("Trade");

            _gLib._Wait(1);

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
            dic.Add("txtRate", "5,15");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._SelectTab("IntAccounting");

            _gLib._Wait(1);

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
            dic.Add("txtRate", "5,1");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Provisions

            pMain._SelectTab(sService_Pension_Stichtag2010);

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
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Pensioners");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
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
            dic.Add("BenefitCommencementAge_cbo", "StartDate1");
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
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Test Cases

            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.11.1960\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.02.1969\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.25.1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region ActuarialReport

            ////// Neeed be update after FCs create

            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Actuarial Report");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pActuarialReport._SelectTab("General");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ShowLYLiabilitiesInLastYear", "");
            dic.Add("MecerLocation", "Stuttgart");
            dic.Add("NameToBePrintedOnReportLeft", "Lars Erpenbach");
            dic.Add("AcademicTitleOfPersonLeft", "Diplom-Wirtschaftsmathematiker");
            dic.Add("NameToBePrintedOnReportRight", "Stefan Heinzmann");
            dic.Add("AcademicTitleOfPersonRight", "Diplom-Wirtschaftsmathematiker");
            dic.Add("ExtensionOfUndersigningPersonRight", "+49 711 23716 0");
            dic.Add("LocationOfUndersigningPersonRight", "Stuttgart");
            dic.Add("IndividualTermsAndConditions", "");
            dic.Add("DoNotAttachTermsAndConditions", "true");
            pActuarialReport._General(dic);


            pActuarialReport._SelectTab("Subsidiary Information");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ClientLongName", "true");
            dic.Add("ClientLongName_txt", "Aegis Media Gruppe");
            dic.Add("ClientShortName", "true");
            dic.Add("ClientShortName_txt", "Aegis Media Gruppe");
            dic.Add("ClientCode", "QADE005E");
            dic.Add("AddressLine1", "true");
            dic.Add("AddressLine1_txt", "Kreuzberger Ring 19");
            dic.Add("AddressLine2", "");
            dic.Add("AddressLine2_txt", "");
            dic.Add("City", "true");
            dic.Add("City_txt", "Wiesbaden");
            dic.Add("PostalCode", "");
            dic.Add("PostalCode_txt", "");
            dic.Add("Country", "true");
            dic.Add("Country_txt", "Deutschland");
            pActuarialReport._SubsidiaryInformation(dic);


            pActuarialReport._SelectTab("Report Contents");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            dic.Add("CopyAStandLayout", "true");
            dic.Add("Template", "DirectPromise_2018");
            dic.Add("OK", "click");
            pActuarialReport._ManageIndividualListingLayouts(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Copy", "click");
            dic.Add("CopyAStandLayout", "true");
            dic.Add("Template", "Benchmark_DirProm");
            dic.Add("OK", "click");
            pActuarialReport._ManageIndividualListingLayouts(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ReportSetName", "Default");
            dic.Add("ReportType", "Direct Promise");
            dic.Add("ReportTemplate", "2018_DEDirectPromise");    //// from 2012 to 2015
            dic.Add("Listing1", "DirectPromise_2018");
            dic.Add("Listing2", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ReportSetName", "IFRS");
            dic.Add("ReportType", "IFRS");
            dic.Add("ReportTemplate", "2018_DEIFRSGerman");
            dic.Add("Listing1", "Benchmark_DirProm");
            dic.Add("Listing2", "");
            pActuarialReport._ReportContents_DefineReportSets(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VOShortName", "Flex");
            dic.Add("VOZusammenfassung", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE005\Kurzbeschreibung.doc");
            dic.Add("VOSummary", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE005\Kurzbeschreibung.doc");
            pActuarialReport._ReportContents_VOSummaries(dic);


            pActuarialReport._SelectTab("Tax and Trade");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DirectPromise", "true");
            dic.Add("SupportFund", "false");
            dic.Add("NameOfSupportFund", "");
            dic.Add("NumberOfReports", "1");
            pActuarialReport._TaxAndTrade(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Subtitle (first page and header)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Flexible Benefits");
            dic.Add("sFieldType", "TEXT");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Direct Promise Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "Default");
            dic.Add("sFieldType", "list");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run Date");
            dic.Add("iCol", "1");
            dic.Add("sData", "07.01.2011");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run date of last year's report");
            dic.Add("iCol", "1");
            dic.Add("sData", "06.01.2010");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Inventory Date");
            dic.Add("iCol", "1");
            dic.Add("sData", "31.12.2010");
            dic.Add("sFieldType", "date");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            ////////dic.Clear();
            ////////dic.Add("PopVerify", "Pop");
            ////////dic.Add("InformationByBreak", "Date when BilMoG is first applied");
            ////////dic.Add("iCol", "1");
            ////////dic.Add("sData", "01.01.2010");
            ////////dic.Add("sFieldType", "date");
            ////////pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Trade is part of report");
            dic.Add("iCol", "1");
            dic.Add("sData", "false");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (trade)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Age 65");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (tax)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Age 65");
            dic.Add("sFieldType", "LIST");
            pActuarialReport._TaxAndTrade_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Do not create PSV Coverage Certificate");
            dic.Add("iCol", "1");
            dic.Add("sData", "false");
            dic.Add("sFieldType", "chx");
            pActuarialReport._TaxAndTrade_TBL(dic, true);


            pActuarialReport._SelectTab("IntAcc");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Subtitle (first page and header)");
            dic.Add("iCol", "1");
            dic.Add("sData", "Flexible Benefits");
            dic.Add("sFieldType", "TEXT");
            pActuarialReport._IntAcc_TBL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "IFRS Report Set 1");
            dic.Add("iCol", "1");
            dic.Add("sData", "IFRS");
            dic.Add("sFieldType", "list");
            pActuarialReport._IntAcc_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Run date");
            dic.Add("iCol", "1");
            dic.Add("sData", "07.01.2011");
            dic.Add("sFieldType", "date");
            pActuarialReport._IntAcc_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "Interest Rate (100% for automatic)");
            dic.Add("iCol", "1");
            dic.Add("sData", "5,10%");
            dic.Add("sFieldType", "txt");
            pActuarialReport._IntAcc_TBL(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InformationByBreak", "COLA rate (100% for automatic)");
            dic.Add("iCol", "1");
            dic.Add("sData", "2,00%");
            dic.Add("sFieldType", "TEXT");
            pActuarialReport._IntAcc_TBL(dic, true);


            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region ER & Output Manager

            pMain._SelectTab(sService_Pension_Stichtag2010);


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
            dic.Add("SaveResultsforAuditReport", "True");
            dic.Add("ApplyOverrides", "True");
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
            dic.Add("SelectVOs_VO1", "Flex");
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

            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab(sService_Pension_Stichtag2010);

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "DirectPromise" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary for Excel Export", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Parameter Print", "RollForward", true, true);
            ////// pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010, "Direct Promise", "RollForward", true, true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Direct Promise", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "IFRS", "RollForward", true, true);



            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Reconciliation to Prior Year", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Detailed Results", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Status Reconciliation", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Individual Checking Template", "RollForward", true, true, 0, new string[1] { "Flex" });
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Individual Output", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", true, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", true, true, 0, new string[1] { "DirectPromise" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[1] { "ALL" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", true, true, dic);




            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Detailed Results by Plan Def", "RollForward", false, true);
            //pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Test Cases", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "DirectPromise" });




            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE005CN", sOutputPension_Stichtag2010_Prod, sOutputPension_Stichtag2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2010");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DirectPromise.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_Flex.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_Flex.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_Flex.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DirectPromise.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                //////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0 ,true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab(sService_Pension_Stichtag2010);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


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
