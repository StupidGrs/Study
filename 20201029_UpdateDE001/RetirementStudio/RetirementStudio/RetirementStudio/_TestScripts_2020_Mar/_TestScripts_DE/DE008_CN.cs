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
using RetirementStudio._UIMaps.UserDefinedProjectionAClasses;
using RetirementStudio._UIMaps.ActuarialReportClasses;
using RetirementStudio._UIMaps.SocialSecurityContributionCeilingsClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using System.Threading;



namespace RetirementStudio._TestScripts_2020_Mar_DE
{
    /// <summary>
    /// Summary description for DE008_CN
    /// </summary>
    [CodedUITest]
    public class DE008_CN
    {
        public DE008_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 008 Create New";
            Config.sPlanName = "QA DE Benchmark 008 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory


        public string sOutputPension_Stichtag2010_Baseline = "";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions = "";
        public string sOutputPension_Stichtag2011_Baseline = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS = "";

        public string sOutputPension_Stichtag2010_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\Baseline\7.5_20191115_E\";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\PreliminaryAssumptions\7.5_20191115_E\";
        public string sOutputPension_Stichtag2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\Baseline\7.5_20191115_E\";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\InterestSensitivityMINUS\7.5_20191115_E\";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\InterestSensitivityPLUS\7.5_20191115_E\";



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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\CreateNew\Val\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Preliminary Assumptions\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity MINUS0.5%\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity PLUS0.5%\\" + sPostFix + "\\");
                }
            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Stichtag2010_Baseline = @\"" + sOutputPension_Stichtag2010_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2010_PreliminaryAssumptions = @\"" + sOutputPension_Stichtag2010_PreliminaryAssumptions + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_Baseline = @\"" + sOutputPension_Stichtag2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityMINUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityMINUS + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputPension_Stichtag2011_InterestSensitivityPLUS = @\"" + sOutputPension_Stichtag2011_InterestSensitivityPLUS + "\";" + Environment.NewLine;
            _gLib._PrintReportDirectory(sContent);

        }

        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
        public CashBalance pCashBalance = new CashBalance();
        public SocialSecurityContributionCeilings pSocialSecurityContributionCeilings = new SocialSecurityContributionCeilings();
        public ActuarialReport pActuarialReport = new ActuarialReport();
        public UserDefinedProjectionA pUserDefinedProjectionA = new UserDefinedProjectionA();
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
        public void test_DE008_CN()
        {
          
            #region MultiThreads

            Thread thrd_Stichtag2010_Baseline = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2010_Baseline(sOutputPension_Stichtag2010_Baseline));
            Thread thrd_Stichtag2010_PreliminaryAssumptions = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2010_PreliminaryAssumptions(sOutputPension_Stichtag2010_PreliminaryAssumptions));
            Thread thrd_Stichtag2011_Baseline = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2011_Baseline(sOutputPension_Stichtag2011_Baseline));
            Thread thrd_Stichtag2011_InterestSensitivityPLUS = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2011_InterestSensitivityPLUS(sOutputPension_Stichtag2011_InterestSensitivityPLUS));

            #endregion



            this.GenerateReportOuputDir();


            #region PensionValuations - Stichtag 2010 - Baseline


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
            dic.Add("Name", "Stichtag 2010");
            dic.Add("Parent", "Conversion 2009");
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
            dic.Add("ServiceToOpen", "Stichtag 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Stichtag 2010");


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
            dic.Add("Data_Name", "Data 2010");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Assumption 2010");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "Liability Method 2010");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "Provision 2010");
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
            dic.Add("SnapshotName", "Unload to Val 2010");
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

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($FAE_Planformel*$emp.ParttimeAverage/100,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($FAE_Planformel*$emp.ParttimeAverage/100,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_DurchschnittsEntgelt");
            dic.Add("Level_7", "GEL_UVAs");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "Durchschnittsentgelt");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_Baustein256");
            dic.Add("Level_7", "GEL_UVAs");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "Festbetrag");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "InternationalAndHB");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($emp.ParttimeAverage/100*($UF_Festbetragsbaustein+$FAE_UeberBBGBaustein),2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($UF_Planformel*$emp.ParttimeAverage/100,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("ContractualRetureentAge", "");
            dic.Add("OverwriteWithIndividualRetirementAge_chx", "true");
            dic.Add("OverwriteWithIndividual_Age_V", "click");
            dic.Add("OverwriteWithIndividual_Age_cbo", "AssumedRetAgeIntAcc");
            dic.Add("OverwriteWithIndividual_Age_C", "");
            dic.Add("OverwriteWithIndividual_Age_txt", "");
            pAssumedRetirementAge._PopVerify_Calculate(dic);


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
            dic.Add("txtRate", "5,17");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("AverageWorkingLifeTime", "true");
            dic.Add("AverageLifeTime", "true");
            dic.Add("AverageWorkingLifeTimeToVesting", "true");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03.21.1939\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.29.1953\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"01.25.1958\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.09.1938\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
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


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Test Cases", "Conversion", true, true);
            ////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Direct Promise", "RollForward", true, true);

            ////////_gLib._MsgBoxYesNo("", "LiabilitySetForGlobeExport are not downloaded since there is no need to download this report for DE client");

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true, dic);



            thrd_Stichtag2010_Baseline.Start();


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region PensionValuations - Stichtag 2010 - Preliminary Assumptions


            pMain._SelectTab("Stichtag 2010");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Preliminary Assumptions");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Preliminary Assumptions");
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
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


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
            dic.Add("txtRate", "4,4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Gesamtbestand");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "True");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4,7");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("Remove", "Click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
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



            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Test Cases", "Conversion", true, true);


            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);


            thrd_Stichtag2010_PreliminaryAssumptions.Start();


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion




            #region PensionValuation - Stichta2011 - Baseline


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
            dic.Add("Name", "Stichtag 2011");
            dic.Add("Parent", "Stichtag 2010");
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
            dic.Add("ServiceToOpen", "Stichtag 2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Stichtag 2011");


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
            dic.Add("Data_Name", "Baseline Data");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "Preliminary Assumptions Assumption");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "New BBG Provisions");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Stichtag 2011");

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
            dic.Add("SnapshotName", "Upload Data 2011");
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
            dic.Add("Level_2", "AssumedRetAgeIntAcc");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "SSCCAtTermination");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "ImportName");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "TerminationFlag");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "");
            pParticipantDataSet._SetFieldProperty(dic);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "AvgPay");
            dic.Add("Level_4", "AvgPayCurrentYear");
            pParticipantDataSet._Navigate(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "AvgPay");
            dic.Add("Level_4", "AvgPayCurrentYear");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "AvgPay");
            dic.Add("Level_4", "AvgPayPriorYear1");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "AvgPay");
            dic.Add("Level_4", "AvgPayPriorYear2");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);


            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("ReturnPosLevel", "2");
            Mouse.Click(pParticipantDataSet.wRetirementStudio.wFPGrid.grid, pParticipantDataSet._Navigate(dic, false));

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "PayCurrentYear");
            pParticipantDataSet._Navigate(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "PayCurrentYear");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "PayPriorYear1");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "PayPriorYear2");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);



            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "Pay");
            dic.Add("ReturnPosLevel", "2");
            Mouse.Click(pParticipantDataSet.wRetirementStudio.wFPGrid.grid, pParticipantDataSet._Navigate(dic, false));

            pParticipantDataSet._ExpandOrCollapseFirstLevel("Personal Information");



            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "SVPflichtigesEK");
            dic.Add("Level_4", "SVPflichtigesEKCurrentYear");
            pParticipantDataSet._Navigate(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "SVPflichtigesEK");
            dic.Add("Level_4", "SVPflichtigesEKCurrentYear");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "SVPflichtigesEK");
            dic.Add("Level_4", "SVPflichtigesEKPriorYear1");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "SVPflichtigesEK");
            dic.Add("Level_4", "SVPflichtigesEKPriorYear2");
            dic.Add("bIsIncludeInReport_Disabled", "False");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "");
            dic.Add("bContinueWithoutCollapse", "true");
            pParticipantDataSet._SetFieldProperty(dic);




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


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "FAE Formula");
            dic.Add("Level_6", "FAE_Planformel");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "_SocSecContribCeiling");
            dic.Add("sData3", "");
            pFAEFormula._TBL_Excess(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Assumptions");


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Ceilings");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("West", "true");
            dic.Add("East", "");
            dic.Add("WestEast_FromData", "");
            dic.Add("Knappschaft", "");
            dic.Add("RV_FromData", "");
            dic.Add("HealthInsuranceWest_cbo_T", "SocSecHealthInsWestPrelim");
            dic.Add("RVWest_cbo_T", "SocSecRVWestPrelim");
            dic.Add("IncreaseRate_P", "");
            dic.Add("IncreaseRate_txt", "");
            dic.Add("ValuationAge", "");
            dic.Add("LastTableEntry", "");
            pSocialSecurityContributionCeilings._SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");

            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,13");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");

            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Rates");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            dic.Add("AsOfDate", "");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");

            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_EE", "7,90");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"07.21.1943\" AND $emp.HireDate1=\"01.01.1973\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.29.1953\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"01.25.1958\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"07.21.1943\" AND $emp.HireDate1=\"01.02.1964\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Stichtag 2011");


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
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "true");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
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


            #region Actuarial Report

            //pMain._SelectTab("Stichtag 2011");

            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Actuarial Report");
            //dic.Add("MenuItem_2", "Edit Parameters");
            //pMain._FlowTreeRightSelect(dic);


            //pActuarialReport._SelectTab("General");


            //dic.Clear();
            //dic.Add("ShowLYLiabilitiesInLastYear", "true");
            //dic.Add("MecerLocation", "Stuttgart");
            //dic.Add("NameToBePrintedOnReportLeft", "Lars Erpenbach");
            //dic.Add("AcademicTitleOfPersonLeft", "Diplom-Wirtschaftsmathematiker");
            //dic.Add("NameToBePrintedOnReportRight", "Stefan Heinzmann");
            //dic.Add("AcademicTitleOfPersonRight", "Diplom-Wirtschaftsmathematiker");
            //dic.Add("ExtensionOfUndersigningPersonRight", "+49 711 23716 0");
            //dic.Add("LocationOfUndersigningPersonRight", "Stuttgart");
            //dic.Add("DoNotAttachTermsAndConditions", "");
            //pActuarialReport._General(dic);

            //pActuarialReport._SelectTab("Subsidiary Information");

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ClientCode", "DE008");
            //pActuarialReport._SubsidiaryInformation(dic);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("LongName", "IDEX Europe GmbH");
            //dic.Add("ShortName", "IDEX");
            //dic.Add("OK", "click");
            //pActuarialReport._SI_TreeViewAddItem(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Level_1", "IDEX Europe GmbH");
            //pActuarialReport._SI_TreeViewSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ClientCode", "IDEX");
            //dic.Add("AddressLine1", "true");
            //dic.Add("AddressLine1_txt", "Weinstraße 39");
            //dic.Add("City", "true");
            //dic.Add("City_txt", "Erlangen");
            //dic.Add("PostalCode", "true");
            //dic.Add("PostalCode_txt", "91058");
            //dic.Add("Country", "true");
            //dic.Add("Country_txt", "Deutschland");
            //pActuarialReport._SubsidiaryInformation(dic);

            //pMain._Home_ToolbarClick_Top(true);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("LongName", "Lukas Hydraulik GmbH");
            //dic.Add("ShortName", "Lukas");
            //dic.Add("OK", "click");
            //pActuarialReport._SI_TreeViewAddItem(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("Level_1", "Lukas Hydraulik GmbH");
            //pActuarialReport._SI_TreeViewSelect(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("ClientCode", "LUKAS");
            //dic.Add("AddressLine1", "true");
            //dic.Add("AddressLine1_txt", "Weinstraße 39");
            //dic.Add("City", "true");
            //dic.Add("City_txt", "Erlangen");
            //dic.Add("PostalCode", "true");
            //dic.Add("PostalCode_txt", "91058");
            //dic.Add("Country", "true");
            //dic.Add("Country_txt", "Deutschland");
            //pActuarialReport._SubsidiaryInformation(dic);

            //pMain._Home_ToolbarClick_Top(true);


            //pActuarialReport._SelectTab("Report Contents");

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("iRow", "1");
            //dic.Add("ReportSetName", "TaxTrade");
            //dic.Add("ReportType", "Direct Promise");
            //dic.Add("ReportTemplate", "2015_DEDirectPromise");
            //dic.Add("Listing1", "DirectPromise_2013");
            //pActuarialReport._ReportContents_DefineReportSets(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("VOShortName", "VKAP");
            //dic.Add("VOZusammenfassung", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\RetStu_VKAP.doc");
            //dic.Add("VOSummary", "");
            //pActuarialReport._ReportContents_VOSummaries(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("VOShortName", "FAG");
            //dic.Add("VOZusammenfassung", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\RetStu_FAG&EZ.doc");
            //dic.Add("VOSummary", "");
            //pActuarialReport._ReportContents_VOSummaries(dic);

            //pMain._Home_ToolbarClick_Top(true);



            //pActuarialReport._SelectTab("Tax and Trade");

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("DirectPromise", "true");
            //dic.Add("SupportFund", "false");
            //dic.Add("NameOfSupportFund", "");
            //dic.Add("NumberOfReports", "4");
            //pActuarialReport._TaxAndTrade(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field1 value");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "LUKAS");
            //dic.Add("sFieldType", "Txt");
            //pActuarialReport._TaxAndTrade_TBL(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field1 value");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "IDEX");
            //dic.Add("sFieldType", "Txt");
            //pActuarialReport._TaxAndTrade_TBL(dic);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field1 value");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "LUKAS");
            //dic.Add("sFieldType", "Txt");
            //pActuarialReport._TaxAndTrade_TBL(dic);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field1 value");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "IDEX");
            //dic.Add("sFieldType", "Txt");
            //pActuarialReport._TaxAndTrade_TBL(dic);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field2 value");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "FAG");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field2 value");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "FAG");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field2 value");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "VKAP");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Break field2 value");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "VKAP");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Subtitle (first page and header)");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "Kugelfischer plan");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Subtitle (first page and header)");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "Kugelfischer plan");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Subtitle (first page and header)");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "Versorgungskapital plan");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Subtitle (first page and header)");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "Versorgungskapital plan");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Subsidiary");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "Lukas");
            //dic.Add("sFieldType", "LIST");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Direct Promise Report Set 1");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "TaxTrade");
            //    dic.Add("sFieldType", "LIST");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Run Date");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "02.12.2011");
            //    dic.Add("sFieldType", "date");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Run date of last year's report");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "26.11.2010");
            //    dic.Add("sFieldType", "date");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Inventory Date");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "31.12.2011");
            //    dic.Add("sFieldType", "date");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Date when BilMoG is first applied");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "01.01.2010");
            //    dic.Add("sFieldType", "date");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    //////////////dic.Add("InformationByBreak", "Interest rate BilMoG as of previous year");
            //    dic.Add("InformationByBreak", "Interest Rate Trade as of previous Year");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "5,17%");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, false);
            //}



            //for (int i = 1; i <= 2; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Projection rate");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "2,75%");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 2; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "BBG increase rate");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "2,50%");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}



            //for (int i = 1; i <= 2; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "COLA rate");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "1,75%");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}


            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Show complete reconcilation of pension expense for Trade");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "true");
            //    dic.Add("sFieldType", "chx");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (trade)");
            //    dic.Add("iCol", i.ToString());
            //    ////////////dic.Add("sData", "RV-AAG07+ATZ");   ////old
            //    dic.Add("sData", "Flex-AAG07+ATZ");
            //    dic.Add("sFieldType", "LIST");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}


            //for (int i = 1; i <= 2; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (tax)");
            //    dic.Add("iCol", i.ToString());
            //    ////////////dic.Add("sData", "RV-AAG07+ATZ");   
            //    dic.Add("sData", "Flex-AAG07+ATZ");
            //    dic.Add("sFieldType", "LIST");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //for (int i = 3; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Option for describing chosen assumed retirement age (tax)");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "Age 65");
            //    dic.Add("sFieldType", "LIST");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            //dic.Add("InformationByBreak", "LY Liabilities applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "9403402");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            //dic.Add("InformationByBreak", "LY Liabilities applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "1249311");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            //dic.Add("InformationByBreak", "LY Liabilities applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "199395");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "Liabilities applying BilMoG as of previous year");
            //dic.Add("InformationByBreak", "LY Liabilities applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "5168");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "LY Book Reserve Trade");
            //dic.Add("InformationByBreak", "LY Book Reserve Trade applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "9403402");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "LY Book Reserve Trade");
            //dic.Add("InformationByBreak", "LY Book Reserve Trade applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "1249311");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "LY Book Reserve Trade");
            //dic.Add("InformationByBreak", "LY Book Reserve Trade applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "199395");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            ////////////dic.Add("InformationByBreak", "LY Book Reserve Trade");
            //dic.Add("InformationByBreak", "LY Book Reserve Trade applying § 253 Abs.2 HGB (BilMoG)");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "5168");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transition amount liabilities when BilMoG was first applied");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "2103678");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transition amount liabilities when BilMoG was first applied");
            //dic.Add("iCol", "2");
            //dic.Add("sData", "489714");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transition amount liabilities when BilMoG was first applied");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "2103678");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);



            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Number of years from BilMoG transition date");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "1");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}


            //for (int i = 1; i <= 3; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Amortisation amount or period for BilMoG transition");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "15");
            //    dic.Add("sFieldType", "txt");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Amortisation amount or period for BilMoG transition");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "1");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Pensions paid this year (incl. from assets)");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "541996,49");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transfers from liabilities (Tax)");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "2633");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transfers to liabilities (Tax)");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "2633");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);



            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transfers from liabilities (Trade)");
            //dic.Add("iCol", "3");
            //dic.Add("sData", "2633");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Transfers to liabilities (Trade)");
            //dic.Add("iCol", "4");
            //dic.Add("sData", "2633");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Assets applying BilMoG as of previous year");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "250838,00");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);

            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Assets applying BilMoG current year");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "243958");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //dic.Clear();
            //dic.Add("PopVerify", "Pop");
            //dic.Add("InformationByBreak", "Payments from assets in current year");
            //dic.Add("iCol", "1");
            //dic.Add("sData", "18492");
            //dic.Add("sFieldType", "txt");
            //pActuarialReport._TaxAndTrade_TBL(dic, true);


            //for (int i = 1; i <= 4; i++)
            //{
            //    dic.Clear();
            //    dic.Add("PopVerify", "Pop");
            //    dic.Add("InformationByBreak", "Do not create PSV Coverage Certificate");
            //    dic.Add("iCol", i.ToString());
            //    dic.Add("sData", "true");
            //    dic.Add("sFieldType", "chx");
            //    pActuarialReport._TaxAndTrade_TBL(dic, true);
            //}


            //pMain._Home_ToolbarClick_Top(true);
            //pMain._Home_ToolbarClick_Top(false);


            //pMain._SelectTab("Stichtag 2011");



            //dic.Clear();
            //dic.Add("iMaxRowNum", "");
            //dic.Add("iMaxColNum", "");
            //dic.Add("iSelectRowNum", "2");
            //dic.Add("iSelectColNum", "1");
            //dic.Add("MenuItem_1", "Run");
            //dic.Add("MenuItem_2", "Actuarial Report");
            //pMain._FlowTreeRightSelect(dic);

            #endregion


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true, dic);
            ////////////pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Direct Promise", "RollForward", true, true);



            thrd_Stichtag2011_Baseline.Start();


            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region PensionValuation - Stichta2011 - Interest Sensitivity PLUS0.5%

            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Sensitivity");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Interest_IncreaseBy", "0,50");
            dic.Add("Interest_DecreseBy", "0,50");
            dic.Add("AddSensitivityNodes", "");
            pMain._PopVerify_AddSensitivityValuationNode(dic);

            dic.Clear();
            dic.Add("sTableType", "Interest");
            dic.Add("AssumptionDefinition", "Interest");
            dic.Add("sIntAcc", "True");
            dic.Add("sTrade", "");
            dic.Add("sTax", "");
            pMain._TBL_Sensitivity(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddSensitivityNodes", "click");
            pMain._PopVerify_AddSensitivityValuationNode(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Valuation Node Properties");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Interest Sensitivity PLUS0.5%");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Valuation Node Properties");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "Interest Sensitivity MINUS0.5%");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("Remove", "click");
            dic.Add("TextSubstitution", "click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Remove", "click");
            pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
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
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "False");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "True");
            dic.Add("InternationalAccountingPBO", "True");
            dic.Add("SelectVOs_AllVOs", "True");
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

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true, "Val Liab");


            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);


            thrd_Stichtag2011_InterestSensitivityPLUS.Start();


            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region PensionValuation - Stichta2011 - Interest Sensitivity MINUS0.5%

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("Remove", "click");
            dic.Add("TextSubstitution", "click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Remove", "click");
            pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Stichtag 2011");


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
            dic.Add("PayoutProjection", "True");
            dic.Add("ApplyWithdrawalAdjustment", "True");
            dic.Add("IncludeIOE", "");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("SaveResultsforAuditReport", "");
            dic.Add("ApplyOverrides", "True");
            dic.Add("RunLocally", "");
            dic.Add("Pay", "PayCurrentYear");
            dic.Add("CurrentYear", "True");
            dic.Add("PriorYear", "");
            dic.Add("BreakByFundingVehicle", "True");
            dic.Add("UseReportBreaks", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Tax", "True");
            dic.Add("Trade", "True");
            dic.Add("InternationalAccountingABO", "");
            dic.Add("InternationalAccountingPBO", "");
            dic.Add("SelectVOs_AllVOs", "True");
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

            pMain._SelectTab("Stichtag 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Stichtag 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "2");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "2");
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
            dic.Add("RemoveAll", "");
            dic.Add("AddAll", "");
            dic.Add("Node", "");
            dic.Add("Add", "");
            dic.Add("ShowSubtotalBreaks", "SubDivisionCode");
            dic.Add("OK", "Click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Test Cases", "Conversion", true, true);

            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);

            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "IOE", "RollForward", false, true);
            pOutputManager._ExportReport_Others_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true);
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_DrillDown_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            dic.Clear();
            dic.Add("Group_ReportBreak", "True");
            pOutputManager._ExportReport_Custom_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true, dic);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_SubReports_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
            pOutputManager._ExportReport_Common_PDF_EXCEL(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod, sOutputPension_Stichtag2011_InterestSensitivityMINUS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_InterestSensitivityMINUS");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt2" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 4, new int[0, 0] { }, new string[1] { "Tabellenblatt3" }, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Stichtag 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "finished ! !");


            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }





        public void t_CompareRpt_Stichtag2010_Baseline(string sOutputPension_Stichtag2010_Baseline)
        {


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Stichtag2010_Baseline_Prod, sOutputPension_Stichtag2010_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2010_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsWithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2010_PreliminaryAssumptions(string sOutputPension_Stichtag2010_PreliminaryAssumptions)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Stichtag2010_PreliminaryAssumptions_Prod, sOutputPension_Stichtag2010_PreliminaryAssumptions);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2010_PreliminaryAssumptions");

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2011_Baseline(string sOutputPension_Stichtag2011_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Stichtag2011_Baseline_Prod, sOutputPension_Stichtag2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearWithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsWithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ05.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_EZ20.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_FAG.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary_VKAP.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_IDEXEuropeGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Stichtag2011_InterestSensitivityPLUS(string sOutputPension_Stichtag2011_InterestSensitivityPLUS)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Stichtag2011_InterestSensitivityPLUS_Prod, sOutputPension_Stichtag2011_InterestSensitivityPLUS);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Stichtag2011_InterestSensitivityPLUS");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaseline_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinewithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselineByPlanDef_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_Tax.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_Trade.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_IntlAccountingPBO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationToBaselinebyPlanDefwithBreaks_IntlAccountingABO.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsByPlanDef.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 11, 0, 0, 0);
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
