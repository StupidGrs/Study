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



namespace RetirementStudio._TestScripts_DE
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



        public string sOutputPension_Conversion2009 = "";
        public string sOutputPension_Stichtag2010_Baseline = "";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions = "";
        public string sOutputPension_Stichtag2011_Baseline = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS = "";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS = "";

        public string sOutputPension_Conversion2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Conversion2009\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2010_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\Baseline\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2010_PreliminaryAssumptions_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2010\PreliminaryAssumptions\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\Baseline\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2011_InterestSensitivityMINUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\InterestSensitivityMINUS\7.3.2_20181130_B\";
        public string sOutputPension_Stichtag2011_InterestSensitivityPLUS_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_008\Production\Stichtag2011\InterestSensitivityPLUS\7.3.2_20181130_B\";


        string TableManager_SelectTab_M = "";
        string TableManager_SelectTab_F = "";


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

                    sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "Conversion 2009\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "Stichtag 2010\\Preliminary Assumptions\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Baseline\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity MINUS0.5%\\" + sPostFix + "\\");
                    sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "Stichtag 2011\\Interest Sensitivity PLUS0.5%\\" + sPostFix + "\\");
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

                ////sDir = sDir + "\\_TestLog\\";

                string sMainDir = sDir + "DE008_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2009\\");
                sOutputPension_Stichtag2010_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010_Baseline\\");
                sOutputPension_Stichtag2010_PreliminaryAssumptions = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010_PreliminaryAssumptions\\");
                sOutputPension_Stichtag2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_Baseline\\");
                sOutputPension_Stichtag2011_InterestSensitivityMINUS = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_InterestSensitivityMINUS\\");
                sOutputPension_Stichtag2011_InterestSensitivityPLUS = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2011_InterestSensitivityPLUS\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2009 = @\"" + sOutputPension_Conversion2009 + "\";" + Environment.NewLine;
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
    
    
            Thread thrd_Conversion2009 = new Thread(() => new DE008_CN().t_CompareRpt_Conversion2009(sOutputPension_Conversion2009));
            Thread thrd_Stichtag2010_Baseline = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2010_Baseline(sOutputPension_Stichtag2010_Baseline));
            Thread thrd_Stichtag2010_PreliminaryAssumptions = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2010_PreliminaryAssumptions(sOutputPension_Stichtag2010_PreliminaryAssumptions));
            Thread thrd_Stichtag2011_Baseline = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2011_Baseline(sOutputPension_Stichtag2011_Baseline));
            Thread thrd_Stichtag2011_InterestSensitivityPLUS = new Thread(() => new DE008_CN().t_CompareRpt_Stichtag2011_InterestSensitivityPLUS(sOutputPension_Stichtag2011_InterestSensitivityPLUS));

            #endregion

         
            this.GenerateReportOuputDir();

            #region CreateClient

            pMain._Initialize();

            pMain._DeleteClientIfExists(Config.sClientName, Config.iTimeout / 10);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TypeClientName", "");
            dic.Add("TreeViewClientName", "");
            dic.Add("AddClient", "Click");
            dic.Add("Title", "");
            dic.Add("DeleteClient", "");
            dic.Add("AddPlan", "");
            pMain._PopVerify_PMTool(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CustomClient", "True");
            dic.Add("MetrixClient", "");
            dic.Add("ClientName", Config.sClientName);
            dic.Add("ClientCode", "LUKA01");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Do NOT Delete!");
            dic.Add("DataCenter", Config.sDataCenter);
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_Client(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TypeClientName", "");
            dic.Add("TreeViewClientName", Config.sClientName);
            dic.Add("AddClient", "");
            dic.Add("Title", "");
            dic.Add("DeleteClient", "");
            dic.Add("AddPlan", "Click");
            pMain._PopVerify_PMTool(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Country", "Germany");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TeilbereichName", Config.sPlanName);
            dic.Add("DefaultValuationDate", "");
            dic.Add("Memo", "");
            dic.Add("Confidential", "");
            dic.Add("PublicSectorProjection", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_TeilbereichAlle(dic);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);



            _gLib._MsgBox("Mannual Interaction", "Please mannually click on plan: " + Config.sClientName + ">>" + Config.sPlanName);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "EZ05");
            dic.Add("ConfirmVOShortName", "EZ05");
            dic.Add("VOLongName", "Einzelpensionszusage 5 Proz");
            dic.Add("VOClass", "");
            dic.Add("FundingVehicle", "");
            dic.Add("TypeOfPromise", "");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("InternationalAccounting", "");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "EZ20");
            dic.Add("ConfirmVOShortName", "EZ20");
            dic.Add("VOLongName", "Einzepensionszusage 20 Proz");
            dic.Add("VOClass", "");
            dic.Add("FundingVehicle", "");
            dic.Add("TypeOfPromise", "");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("InternationalAccounting", "");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "FAG");
            dic.Add("ConfirmVOShortName", "FAG");
            dic.Add("VOLongName", "FAG Kugelfischer VO");
            dic.Add("VOClass", "");
            dic.Add("FundingVehicle", "");
            dic.Add("TypeOfPromise", "");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "true");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("InternationalAccounting", "");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("AddVOtoRegistry", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EnterVOShortName", "VKAP");
            dic.Add("ConfirmVOShortName", "VKAP");
            dic.Add("VOLongName", "Versorgungskapital");
            dic.Add("VOClass", "");
            dic.Add("FundingVehicle", "");
            dic.Add("TypeOfPromise", "");
            dic.Add("Sponsor", "Employer");
            dic.Add("PSVCoverage", "true");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("InternationalAccounting", "");
            dic.Add("Apply30g", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);

            #endregion


            #region Data - Conversion Stichtag 2009

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Conversion Stichtag 2009");
            dic.Add("EffectiveDate", "31.12.2009");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
            dic.Add("Shared", "True");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "True");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion Stichtag 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pData._ts_UpdateIncludedVOs("EZ05", true);
            pData._ts_UpdateIncludedVOs("EZ20", true);
            pData._ts_UpdateIncludedVOs("FAG", true);
            pData._ts_UpdateIncludedVOs("VKAP", true);


            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "AssumedRetAgeIntAcc");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "SSCCAtTermination");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "AvgPay");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FromDate", "01.01.2009");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "Pay");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FromDate", "31.12.2009");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "SVPflichtigesEK");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("FromDate", "01.01.2009");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Festbetrag");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "Durchschnittsentgelt");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BesitzstandAktuellEURO");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BesitzstandsstartDM");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DynFaktorBesitzstand");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\EinlesedateiVKAP09.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\FAG_Ergebnisse2009.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\VKAP_Ergebnisse2009.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\BesitzstandFAG09.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\EinlesedateiFAG09.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Unload VKAP");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "EinlesedateiVKAP09.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Last Year", 1, 0, 1, "LYOverwriteResults");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_MapField("ParticipantStatus", "AliveStatus", 0, false);
            pData._IP_Mapping_MapField("PayStatus", "AliveStatus", 0, true);
            pData._IP_Mapping_MapField("LYParticipantStatus", "LYAliveStatus", 0, true);
            pData._IP_Mapping_MapField("LYPayStatus", "LYAliveStatus", 0, true);


            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);



            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYAliveStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYParticipantStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYPayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_VKAP");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=1");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "105");
            dic.Add("Unique_UniqueMatch_Num", "0");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of New");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Letzte Anderungen");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "UVACalcMethod");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "UVACalcMethod");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ISBLANK(UVACalcMethod_C),IF(ParticipantStatus_C=\"AC\",1,0),UVACalcMethod_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Letzte Anderungen");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Unload FAG");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "EinlesedateiFAG09.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Last Year", 1, 0, 1, "LYOverwriteResults");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 9, 1, "AvgPay");
            pData._IP_Mapping_Initialize("Personal Information", "SVPflichtigesEK", 3, 9, 1, "SVPflichtigesEKCurrentYear");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("SVPflichtigesEKCurrentYear", "PSOC", 0, true);
            pData._IP_Mapping_MapField("SSCCAtTermination", "SSCCAtTermination", 0, true);
            pData._IP_Mapping_MapField("LYAliveStatus", "ELY", 0, true);
            pData._IP_Mapping_MapField("LYPayStatus", "ELY", 0, true);


            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYAliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);



            pData._IP_Mapping_ClickEdit("LYParticipantStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYPayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_EZ05");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"EZ05\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Add", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_EZ20");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"EZ20\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Add", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_FAG");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("Filter_TrueFalse", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"FAG\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("NewVersion", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "181");
            dic.Add("Unique_UniqueMatch_Num", "");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "105");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "Unmatched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Unload FAG Besitzstand");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "BesitzstandFAG09.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "true");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "181");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "3");
            dic.Add("Unique_UniqueMatch_Num", "");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Ignored");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "");
            dic.Add("Unique_MultipleMatches_Num", "");
            dic.Add("Duplicate_NoMatch_Num", "");
            dic.Add("Duplicate_UniqueMatch_Num", "");
            dic.Add("Duplicate_MultipleMatches_Num", "");
            dic.Add("Warehouse_NoMatch_Num", "105");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "Unmatched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Unmatched");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Active and Deferred Members_****");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=(OR(AND(OR(ParticipantStatus_C=\"IN\",ParticipantStatus_C=\"INTR\"),PayStatus_C=\"DEF\"),"
                + "OR(ParticipantStatus_C=\"AC\",ParticipantStatus_C=\"ATI\",ParticipantStatus_C=\"ATO\")))");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Active Member_****");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(ParticipantStatus_C=\"AC\",ParticipantStatus_C=\"ATI\",ParticipantStatus_C=\"ATO\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Deferred Member_****");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(OR(ParticipantStatus_C=\"IN\",ParticipantStatus_C=\"INTR\"),PayStatus_C=\"DEF\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Inactive Member_****");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=OR(ParticipantStatus_C=\"IN\",ParticipantStatus_C=\"INTR\")");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Orphans");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AliveStatus_C=\"NO\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Letzte Anderungen");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);


            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayCurrentYear_C/ParttimeFactor_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Benefit1DB_C*12");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayAtTermination_C/PartTimeFactor_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "LYBookReserve");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Legacy System Results");
            dic.Add("Level_3", "LegacyBookReserve");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=LegacyBookReserve_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SubsidiaryCode");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"LUKAS\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SubDivisionCode");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "SubDivisionCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ISBLANK(SubDivisionCode_C),\"FAG\",SubDivisionCode_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "Click");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Import Ergebnisse 2009");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "FAG_Ergebnisse2009.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Ergebnisse 2009");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Ergebnisse VKAP");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "VKAP_Ergebnisse2009.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "true");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Ergebnisse 2009");
            pData._TreeViewSelect(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "286");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Matched");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "(4)Letzte Anderungen");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Beneficiary1StartDate1");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DeriveUSC");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "View && Update");
            dic.Add("Level_3", "Last Session");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "Click");
            dic.Add("CustomExpression_Formula", "=BirthDate_C=DATEVALUE(\"01.03.1961\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "SubsidiaryCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pAssumptions._SelectTab("Individual Record");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "Click");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "SubsidiaryCode_C");
            dic.Add("UpdatedValue", "IDEX");
            dic.Add("OK", "click");
            pData._PopVerify_VU_IR_MannualUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "true");
            dic.Add("CustomExpression_Formula", "=BirthDate_C=DATEVALUE(\"10.03.1962\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);



            pAssumptions._SelectTab("Individual Record");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "Click");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "SubsidiaryCode_C");
            dic.Add("UpdatedValue", "IDEX");
            dic.Add("OK", "click");
            pData._PopVerify_VU_IR_MannualUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "true");
            dic.Add("CustomExpression_Formula", "=BirthDate_C=DATEVALUE(\"06.03.1962\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);


            pAssumptions._SelectTab("Individual Record");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "Click");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "SubsidiaryCode_C");
            dic.Add("UpdatedValue", "IDEX");
            dic.Add("OK", "click");
            pData._PopVerify_VU_IR_MannualUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Conversion Stichtag 2009");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ImportName");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            dic.Add("Level_3", "BeneficiaryIDNumber");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CashTransferTrade");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Last Year");
            dic.Add("Level_3", "LYUSC");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "UNLOAD 2009 final");
            dic.Add("UseLatestDate", "true");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region  PensionValuations - Conversion 2009 - ParticipantData

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
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Conversion 2009");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
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
            dic.Add("ServiceToOpen", "Conversion 2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Conversion 2009");

            for (int i = 1; i <= 6; i++)
                TableManager_SelectTab_M = TableManager_SelectTab_M + "0,097500" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,095000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,092500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,090000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,087500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,085000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,080000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,075000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,065000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,055000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,045000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,040000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,035000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,030000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,027500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,025000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,022500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,020000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,017500" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,015000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,012500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,010000" + Environment.NewLine;

            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,007500" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,005000" + Environment.NewLine;
            TableManager_SelectTab_M = TableManager_SelectTab_M + "0,002500" + Environment.NewLine;


            for (int i = 1; i <= 7; i++)
                TableManager_SelectTab_F = TableManager_SelectTab_F + "0,125000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,120000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,115000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,110000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,105000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,100000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,095000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,085000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,075000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,065000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,055000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,045000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,040000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,035000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,030000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,025000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,020000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,017500" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,015000" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,012500" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,010000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,007500" + Environment.NewLine;

            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,005000" + Environment.NewLine;
            TableManager_SelectTab_F = TableManager_SelectTab_F + "0,002500" + Environment.NewLine;


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "WTHGRSLowdifferentGender");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("SelectAndUltimate", "");
            dic.Add("SelectPeriods", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "Age");
            dic.Add("Index1_From", "15");
            dic.Add("Index1_To", "120");
            dic.Add("Index2", "");
            dic.Add("From2", "");
            dic.Add("To2", "");
            dic.Add("Extend", "true");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "false");
            dic.Add("Format", "Number");
            dic.Add("DecimalPlaces", "6");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", "");
            dic.Add("sMaleRates", TableManager_SelectTab_M);
            dic.Add("sFemaleRates", TableManager_SelectTab_F);
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "EarlyRetTable");
            dic.Add("Type", "General");
            dic.Add("Description", "");
            dic.Add("Ultimate", "");
            dic.Add("SelectAndUltimate", "");
            dic.Add("SelectPeriods", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "true");
            dic.Add("Index1", "Age");
            dic.Add("From1", "15");
            dic.Add("To1", "70");
            dic.Add("Index2", "Service");
            dic.Add("From2", "0");
            dic.Add("To2", "31");
            dic.Add("Extend", "true");
            dic.Add("Zero", "");
            dic.Add("SameRatesUsed", "true");
            dic.Add("Format", "Number");
            dic.Add("DecimalPlaces", "6");
            dic.Add("Use1000Separator", "");
            pTableManager._ts_AddTable(dic);


            string EarlyRetTable = "";
            _gLib._KillProcessByName("EXCEL");
            MyExcel _excelRead = new MyExcel(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\LUKAS Hydraulik GmbH EarlyRetTable.xlsx", false);
            _excelRead.OpenExcelFile(1);

            for (int j = 2; j <= 57; j++)
            {
                for (int i = 2; i <= 33 - 1; i++)
                    EarlyRetTable = EarlyRetTable + _excelRead.getOneCellValue(j, i) + "\t";
                EarlyRetTable = EarlyRetTable + _excelRead.getOneCellValue(j, 33) + Environment.NewLine;
            }
            _excelRead.SaveExcel();
            _excelRead.CloseExcelApplication();

            pTableManager._SelectTab("Unisex Rates");
            pTableManager._ts_PasteValue(EarlyRetTable, true);

            _gLib._MsgBox("", "check pasted value in the form, you can paste it manual if it's unsuccessed." + 
                "\n the first cell should be 0.7 not 0.0");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Conversion 2009");

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
            dic.Add("SnapshotName", "UNLOAD 2009 final");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
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


            #region  PensionValuations - Conversion 2009 - Assumptions & Provisions


            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "GEL_UVAs");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "GEL_UVAs");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.ParticipantStatus=\"IN\" and $emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "GEL_UVA_Endanspruch");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "GEL_UVA_Endanspruch");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$GEL_UVAs and $emp.UVACalcMethod=0");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "GEL_UVA_Verlauf");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "GEL_UVA_Verlauf");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$GEL_UVAs and $emp.UVACalcMethod=1");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Gesamtbestand");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Gesamtbestand");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.VOShortName=\"VKAP\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
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
            dic.Add("Regelaltersgrenze", "");
            dic.Add("ContractualRetureentAge", "");
            dic.Add("OverwriteWithIndividualRetirementAge_chx", "true");
            dic.Add("OverwriteWithIndividual_Age_V", "click");
            dic.Add("OverwriteWithIndividual_Age_cbo", "AssumedRetirementAge");
            dic.Add("OverwriteWithIndividual_Age_C", "");
            dic.Add("OverwriteWithIndividual_Age_txt", "");
            pAssumedRetirementAge._PopVerify_Calculate(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CR_SameAsPayIncrease1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsPayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CR_SameAsCostOfLiving");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsCostOfLiving");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CR_SameAsBBGTrend");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsBBGTrend");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CR_Nulltrend");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_Nulltrend");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "Assumption_PI_Gehaltstrend1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "Assumption_PI_Gehaltstrend1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


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
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "true");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "GesamtRetireeDeath_HB05QRX");
            dic.Add("PreCommencement", "");
            dic.Add("PostCommencement", "");
            pMortalityDecrement._PrePostCommencement(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("MenuItem", "Add condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("ContractualRetureentAge", "");
            dic.Add("OverwriteWithIndividualRetirementAge_chx", "true");
            dic.Add("OverwriteWithIndividual_Age_V", "click");
            dic.Add("OverwriteWithIndividual_Age_cbo", "AssumedRetirementAge");
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
            dic.Add("txtRate", "5,25");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsPayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsCostOfLiving");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "1,75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsBBGTrend");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "Assumption_PI_Gehaltstrend1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2,75");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "1,75");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Ceilings");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,5");
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
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "true");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "GesamtRetireeDeath_HB05QRX");
            dic.Add("PreCommencement", "");
            dic.Add("PostCommencement", "");
            pMortalityDecrement._PrePostCommencement(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "WithDrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WTHGRSLowdifferentGender");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._TreeView_SelectTab("IntAccounting");

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
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,2");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



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
            dic.Add("txtRate", "5,1");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsPayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsCostOfLiving");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "1,75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CR_SameAsBBGTrend");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,5");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "Assumption_PI_Gehaltstrend1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "click");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,75");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "1,75");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Social Security Contribution Ceilings");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "2,5");
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
            dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
            dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
            dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
            dic.Add("HealthInsuranceContribionRate_EE", "8,20");
            dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
            dic.Add("HealthInsuranceReducedRate_EE", "7,30");
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,00");
            dic.Add("CareInsuranceContributionRate_Employer", "0,975");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("WorkingDaysPerYear", "");
            dic.Add("AdjustFactorrFromNextToGross", "");
            dic.Add("TaxTariff", "2010");
            dic.Add("SoliTaxRate", "");
            dic.Add("ChurchTaxRate", "");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PrePostCommencement", "");
            dic.Add("PreDecrementPostCommencement", "true");
            dic.Add("UnisexMortality", "");
            dic.Add("ProjectedStaticMortalit", "");
            dic.Add("GenerationalMortality", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "GesamtRetireeDeath_HB05QRX");
            dic.Add("PreCommencement", "");
            dic.Add("PostCommencement", "");
            pMortalityDecrement._PrePostCommencement(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "WithDrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "WTHGRSLowdifferentGender");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("Other", "True");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Gesamtbestand");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            #region  Common Update Code for DE - Update Assumptions

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("cboPrescribedRates", "Heubeck 2005 G");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "");
            dic.Add("txtPercentMarried_F", "");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            dic.Add("DifferenceInOrphanAge", "");
            dic.Add("NumberOfChildren", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);



            pAssumptions._TreeView_SelectTab("Tax");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);


            pAssumptions._TreeView_SelectTab("IntAccounting");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "USC40");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "True");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            dic.Add("Service", "");
            dic.Add("AdjustmentOperator", "");
            dic.Add("Adjustment_C", "");
            dic.Add("Adjustment_P", "");
            dic.Add("Adjustment_T", "");
            dic.Add("Adjustment_txt", "");
            dic.Add("Adjustment_Tcbo", "");
            dic.Add("Adjustment_Tcbo_extend", "");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Rate", "Heubeck 2005 G");
            dic.Add("AsOfDate", "");
            dic.Add("PercentEligible", "");
            pMortalityDecrement._PopVerify_PrescribedRates(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_anrechenbareDZ");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("Level_6", "Default");
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
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "20");
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
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "20");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("MaximumService_UseServiceCap", "0");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_Proration");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_Proration");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "True");
            dic.Add("ForTrade_DE", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
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
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_EarlyRetTableService");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_EarlyRetTableService");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA_AblaufWartezeit");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_AblaufWartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "EL_Wartezeit");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("Level_5", "EL_Wartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age >= $FTA_AblaufWartezeit");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PP_PensEK");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_PensEK");
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
            dic.Add("UseCurrentYearPayRateFrom", "PayCurrentYear");
            dic.Add("PayIncreaseAssumption", "Assumption_PI_Gehaltstrend1");
            pPayoutProjection._PopVerify_PresentYear(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PA_PensEKAverage");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("Level_5", "PA_PensEKAverage");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PP_PensEK");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "1");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            pPayAverage._PopVerify_Standard(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("Level_5", "PA_PensEKAverage");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "UVAs");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("Level_5", "PA_PensEKAverage");
            dic.Add("Level_6", "UVAs");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PP_PensEK");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "1");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "");
            dic.Add("AdjustmentMethod", "");
            dic.Add("FreezePayAverageAtAge_V", "");
            dic.Add("FreezePayAverageAtAge_C", "");
            dic.Add("FreezePayAverageAtAge_cbo", "");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "True");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.PayAtTermination");
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
            dic.Add("EligibilityCondition", "$GEL_UVAs");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("MenuItem", "Add Project and Prorate");
            pAssumptions._TreeViewRightSelect(dic, "MNTEL1_Endanspruch");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "true");
            dic.Add("ServiceForProration", "");
            dic.Add("ServiceSelectionForProration", "");
            pProjectAndProrate._PopVerify_ProjectAndProrate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$_mntelvector");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "UVAGesamtbestand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("Level_6", "UVAGesamtbestand");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "true");
            dic.Add("ServiceForProration", "");
            dic.Add("ServiceSelectionForProration", "");
            pProjectAndProrate._PopVerify_ProjectAndProrate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
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
            dic.Add("EligibilityCondition", "$GEL_UVAs and $emp.UVACalcMethod=0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "BBG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "InternationalAndTrade");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "True");
            dic.Add("Trade", "");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "InternationalAndTrade");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "66000*(1+$CR_SameAsBBGTrend)^($age-$age[$ValAge])");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "");
            dic.Add("Expression", "$_SocSecContribCeiling");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "FAE_Planformel");

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
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "PA_PensEKAverage");
            dic.Add("Service", "SV_anrechenbareDZ");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "BBG");
            dic.Add("sData3", "0,005");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0,015");
            pFAEFormula._TBL_Excess(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "FinalBenefit");

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
            dic.Add("Expression", "$FAE_Planformel*$emp.ParttimeAverage");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "FinalBenefit");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Benefit1DB");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLA_Rentenanpassungen");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("Level_5", "COLA_Rentenanpassungen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLABegin_Active_PaymentsFrom", "");
            dic.Add("COLABegin_Active_PaymentsFrom_txt", "0");
            dic.Add("COLABegin_Active_Age", "15");
            dic.Add("COLABegin_Active_Date", ".  .");
            dic.Add("COLADuring_V", "");
            dic.Add("COLADuring_P", "");
            dic.Add("COLADuring_T", "");
            dic.Add("COLADuring_Rate_cbo", "");
            dic.Add("COLADuring_Rate_txt", "");
            dic.Add("COLAAfter_V", "Click");
            dic.Add("COLAAfter_P", "");
            dic.Add("COLAAfter_T", "");
            dic.Add("COLAAfter_Rate_cbo", "CostOfLivingIncreaseAssumption");
            dic.Add("COLAAfter_Rate_txt", "");
            pCostOfLivingAdjustments._PopVerify_CostOfLivingAdjustments_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "ERF_KuerzungVorgezogeneAR");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("Level_5", "ERF_KuerzungVorgezogeneAR");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "True");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "~EarlyRetTable($Age,$SV_EarlyRetTableService)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_StraightLife");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Spouse");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Spouse");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Reversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Reversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Orphans");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Orphans");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Immediate orphan annuity");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "click");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("LastPaymentAge_V", "");
            dic.Add("LastPaymentAge_C", "click");
            dic.Add("MaximumPaymentAge_V", "");
            dic.Add("MaximumPaymentAge_C", "Click");
            dic.Add("LastPaymentAge_txt", "17");
            dic.Add("MaximumPaymentAge_txt", "25");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Altersrente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Altersrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "ERF_KuerzungVorgezogeneAR");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Alterswitwenrente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Alterswitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "ERF_KuerzungVorgezogeneAR");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Invalidenrente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Invalidenwitwenrente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenwitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Disability");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Aktivenwitwenrente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Aktivenwitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Spouse");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "LaufendeRente");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
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
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRente");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Waisen");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRente");
            dic.Add("Level_6", "Waisen");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
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
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Orphans");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.AliveStatus=\"NO\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "LaufendeRenteWitwenanwartschaft");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRenteWitwenanwartschaft");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaOrBenefit_cbo", "Benefit1DB");
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
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            dic.Add("Level_3", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ05");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceInstance", "");
            dic.Add("ValuationNode", "");
            dic.Add("VOShortName", "EZ05");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_Wartezeit");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_Wartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Standard");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_AblaufWartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "SV_Wartezeit");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);





            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("Level_6", "UVAGesamtbestand");
            pAssumptions._TreeViewSelect(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "UVAEndanspruch");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "InternationalAndTrade");
            dic.Add("MenuItem", "Edit");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "InternationalAndHB");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "false");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "FAE Formula");
            dic.Add("Level_6", "FAE_Planformel");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "PA_PensEKAverage");
            dic.Add("Service", "SV_anrechenbareDZ");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            dic.Add("IntegrationType", "Non-Integrated");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0,2");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("Level_5", "ERF_KuerzungVorgezogeneAR");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "true");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "30", "");



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenrente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenwitwenrente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_EarlyRetTableService");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "EZ20");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceInstance", "");
            dic.Add("ValuationNode", "");
            dic.Add("VOShortName", "EZ05");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01.01.1991");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("MaximumService_UseServiceCap", "0");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Standard");
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
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "UVAs");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("Level_6", "UVAs");
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
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "20");
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
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "20");
            dic.Add("ServiceStarts_FixedDate", "01.01.1991");
            dic.Add("ServiceStarts_Date", "");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.ParticipantStatus=\"IN\" and $emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_Wartezeit");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_Wartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Standard");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_EarlyRetAtable");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_EarlyRetAtable");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "20");
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
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "20");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "Fixed date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Completed");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_Sterbegeld");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_Sterbegeld");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
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
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_MonateSterbegeldZahlung");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_MonateSterbegeldZahlung");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5+Min(Truncate(Max($SV_Sterbegeld-6,0)),1)+Min(Truncate(Max($SV_Sterbegeld-12,0)),1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_MNTELZaehler");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_MNTELZaehler");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01.01.1991");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "Standard");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SV_MNTELNenner");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_MNTELNenner");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01.01.1991");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Standard");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_AblaufWartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "SV_Wartezeit");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA_AgePlanEinfuehrung");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_AgePlanEinfuehrung");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "01.01.1991");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "SS_MNTELNenner");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service Selection");
            dic.Add("Level_5", "SS_MNTELNenner");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "SV_MNTELNenner");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Round($SV_MNTELZaehler/$SS_MNTELNenner,6),1)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "UVAVerlauf");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "MNTEL1_Endanspruch");
            dic.Add("Level_6", "UVAVerlauf");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Min(Round($SV_MNTELZaehler/$SS_MNTELNenner,6),1)");
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
            dic.Add("EligibilityCondition", "$GEL_UVA_Verlauf");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("MenuItem", "Add Project and Prorate");
            pAssumptions._TreeViewRightSelect(dic, "NPP_VollErdient");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Project and Prorate");
            dic.Add("Level_5", "NPP_VollErdient");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "true");
            dic.Add("ServiceForProration", "");
            dic.Add("ServiceSelectionForProration", "");
            pProjectAndProrate._PopVerify_ProjectAndProrate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDP_DurchschnittsEntgelt");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_DurchschnittsEntgelt");
            dic.Add("Level_7", "Default");
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
            dic.Add("Rate_cbo", "CR_SameAsPayIncrease1");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "true");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_DurchschnittsEntgelt");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_DurchschnittsEntgelt");
            dic.Add("Level_7", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Durchschnittsentgelt");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVAs");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDP_FaktorUeberDurchGehalt");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_FaktorUeberDurchGehalt");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round(Max(1,$PA_PensEKAverage/$UDP_DurchschnittsEntgelt),6)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDP_Baustein256");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_Baustein256");
            dic.Add("Level_7", "Default");
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
            dic.Add("Rate_cbo", "CR_SameAsCostOfLiving");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "true");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_Baustein256");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_Baustein256");
            dic.Add("Level_7", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.Festbetrag");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVAs");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("MenuItem", "Add User Defined Projection A");
            pAssumptions._TreeViewRightSelect(dic, "UDP_BesitzstandStart");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection A");
            dic.Add("Level_6", "UDP_BesitzstandStart");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($emp.BesitzstandsstartDM/1.95583,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Unit Formula");
            dic.Add("MenuItem", "Add Unit Formula");
            pAssumptions._TreeViewRightSelect(dic, "UF_Festbetragsbaustein");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Unit Formula");
            dic.Add("Level_6", "UF_Festbetragsbaustein");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($SV_anrechenbareDZ*$UDP_Baustein256*$UDP_FaktorUeberDurchGehalt*12,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Flat Amount Accumulation");
            dic.Add("MenuItem", "Add Flat Amount Accumulation");
            pAssumptions._TreeViewRightSelect(dic, "FAA_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Flat Amount Accumulation");
            dic.Add("Level_6", "FAA_Besitzstand");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "");
            dic.Add("LinearizationWithBreakpoint", "true");
            dic.Add("HistoricalValuations", "");
            dic.Add("CustomCode", "");
            pCashBalance._Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AccountBalance", "BesitzstandAktuellEURO");
            dic.Add("StartAgeForLinearization", "$HireAge");
            dic.Add("BreakPoint_V", "click");
            dic.Add("BreakPoint_cbo", "UDP_BesitzstandStart");
            dic.Add("BreakPointAge", "FTA_AgePlanEinfuehrung");
            dic.Add("ServiceBasedOn", "SV_anrechenbareDZ");
            pFlatAmountAccumulation._LinearizationWithBreakpoint(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "InternationalAndTrade");
            dic.Add("MenuItem", "Edit");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "InternationalAndHB");
            dic.Add("IntlAccountingABO", "");
            dic.Add("IntlAccountingPBO", "");
            dic.Add("Tax", "false");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "FAE Formula");
            dic.Add("Level_6", "FAE_Planformel");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "FAE_UeberBBGBaustein");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "FAE Formula");
            dic.Add("Level_6", "FAE_UeberBBGBaustein");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "Click");
            dic.Add("sData2", "BBG");
            dic.Add("sData3", "0,0");
            pFAEFormula._TBL_Excess(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iNumOfBreakpoints", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0,005");
            pFAEFormula._TBL_Excess(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection B");
            dic.Add("MenuItem", "Add User Defined Projection B");
            pAssumptions._TreeViewRightSelect(dic, "UDP2_ProjezierterBesitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection B");
            dic.Add("Level_6", "UDP2_ProjezierterBesitzstand");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "FAA_Besitzstand");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "CR_SameAsBBGTrend");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "true");
            pUserDefinedProjectionA._PopVerify_Standard(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection B");
            dic.Add("Level_6", "UDP2_ProjezierterBesitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "User Defined Projection B");
            dic.Add("Level_6", "UDP2_ProjezierterBesitzstand");
            dic.Add("Level_7", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("Amount_V", "click");
            dic.Add("Amount_C", "");
            dic.Add("Amount_cbo", "FAA_Besitzstand");
            dic.Add("Amount_txt", "");
            dic.Add("Rate_V", "click");
            dic.Add("Rate_P", "");
            dic.Add("Rate_cbo", "CR_Nulltrend");
            dic.Add("Rate_txt", "");
            dic.Add("ProjectValuesForPastAges", "true");
            pUserDefinedProjectionA._PopVerify_Standard(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Verlauf");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);



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
            dic.Add("Expression", "Round($emp.ParttimeAverage*($UF_Festbetragsbaustein+$FAE_UeberBBGBaustein),2)");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Round($emp.ParttimeAverage*($UF_Festbetragsbaustein+$FAE_UeberBBGBaustein),2)");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "FluktuationsMNtel1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("Level_5", "FluktuationsMNtel1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingRule", "");
            dic.Add("VestingRatio", "MNTEL1_Endanspruch");
            pVesting._PopVerify_Standard_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "FluktuationsMNtelVollErdient");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("Level_5", "FluktuationsMNtelVollErdient");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingRule", "");
            dic.Add("VestingRatio", "NPP_VollErdient");
            pVesting._PopVerify_Standard_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("Level_5", "ERF_KuerzungVorgezogeneAR");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "True");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "~EarlyRetTable($Age,$SV_EarlyRetAtable)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_LumpSum");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_LumpSum");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IgnorePercentMarried_DE", "true");
            pFormOfPayment._PopVerify_FormOfPayment(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AR_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_Besitzstand");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$ERF_KuerzungVorgezogeneAR*($UDP2_ProjezierterBesitzstand-$UDP_BesitzstandStart)+$UDP_BesitzstandStart");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtelVollErdient");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_Besitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_Besitzstand");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AR_FAG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_FAG");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "ERF_KuerzungVorgezogeneAR");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtel1");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            for (int i = 1; i <= 7; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "AR_Besitzstand");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }


            for (int i = 1; i <= 7; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "AR_FAG");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Altersrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$AR_Besitzstand+$AR_FAG");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "#1#");
            dic.Add("VestedRatio", "#1#");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "#1#");
            dic.Add("LateRetirement", "#1#");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ARW_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_Besitzstand");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$ERF_KuerzungVorgezogeneAR*($UDP2_ProjezierterBesitzstand-$UDP_BesitzstandStart)+$UDP_BesitzstandStart");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtelVollErdient");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_Besitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_Besitzstand");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ARW_FAG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_FAG");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "ERF_KuerzungVorgezogeneAR");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtel1");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            for (int i = 1; i <= 6; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "ARW_Besitzstand");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }


            for (int i = 1; i <= 6; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "ARW_FAG");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Alterswitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$ARW_Besitzstand+$ARW_FAG");
            dic.Add("Validate", "click");
            dic.Add("BenefitCommencementAge_V", "click");
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
            dic.Add("BenefitCommencementAge_cbo", "_AssumedRetirementAge");
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
            dic.Add("Eligibility", "#1#");
            dic.Add("VestedRatio", "#1#");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "#1#");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "IR_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_Besitzstand");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$UDP2_ProjezierterBesitzstand");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtelVollErdient");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_Besitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_Besitzstand");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "IR_FAG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_FAG");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
            dic.Add("Function", "");
            dic.Add("Validate", "");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtel1");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            for (int i = 1; i <= 5; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "IR_Besitzstand");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            for (int i = 1; i <= 5; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "IR_FAG");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic);
            }

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "true");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$IR_Besitzstand+$IR_FAG");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "#1#");
            dic.Add("VestedRatio", "#1#");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Disability");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "IRW_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IRW_Besitzstand");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$UDP2_ProjezierterBesitzstand");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtelVollErdient");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IRW_Besitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IRW_Besitzstand");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "IRW_FAG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IRW_FAG");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtel1");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            for (int i = 1; i <= 4; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "IRW_Besitzstand");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }

            for (int i = 1; i <= 5; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "IRW_FAG");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenwitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "true");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$IRW_Besitzstand+$IRW_FAG");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "#1#");
            dic.Add("VestedRatio", "#1#");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Reversionary");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Disability");
            dic.Add("VestingDefinition", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AAW_Besitzstand");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_Besitzstand");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$UDP2_ProjezierterBesitzstand");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtelVollErdient");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_Besitzstand");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_Besitzstand");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "0");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "NPP_VollErdient");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "GEL_UVA_Endanspruch");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "AAW_FAG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_FAG");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "");
            dic.Add("VestingDefinition", "FluktuationsMNtel1");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            for (int i = 1; i <= 3; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "AAW_Besitzstand");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }

            for (int i = 1; i <= 3; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "AAW_FAG");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Aktivenwitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "false");
            dic.Add("UseAsFutureValPension", "true");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "$AAW_Besitzstand+$AAW_FAG");
            dic.Add("Validate", "click");
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
            dic.Add("Eligibility", "#1#");
            dic.Add("VestedRatio", "#1#");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Spouse");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Death");
            dic.Add("Other", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Stebegeld");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Stebegeld");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormular", "True");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("SingleFormulaOrBenefit_cbo", "");
            dic.Add("Function", "Round(($PA_PensEKAverage-($emp.Beneficiary1Percent1/100)*($UDP2_ProjezierterBesitzstand+$FinalBenefit))/12*$SV_MonateSterbegeldZahlung,2)");
            dic.Add("Validate", "click");
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
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_LumpSum");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Death");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_Besitzstand");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AR_FAG");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Altersrente");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_Besitzstand");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "ARW_FAG");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Alterswitwenrente");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_Besitzstand");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IR_FAG");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenrente");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "IRW_Besitzstand");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_Besitzstand");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "AAW_FAG");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Aktivenwitwenrente");
            pAssumptions._Collapse(dic);



            for (int i = 1; i <= 2; i++)
            {
                dic.Clear();
                dic.Add("Level_1", "Pension");
                dic.Add("Level_2", "FAG");
                dic.Add("Level_3", "Benefit Definition");
                dic.Add("Level_4", "Plan Definition");
                dic.Add("Level_5", "Stebegeld");
                dic.Add("MenuItem", "Move Up");
                pAssumptions._TreeViewRightSelect(dic, "");
            }


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            dic.Add("Level_3", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "FAG");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("MenuItem", "Copy VO From");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", "");
            dic.Add("Plan", "");
            dic.Add("ServiceInstance", "");
            dic.Add("ValuationNode", "");
            dic.Add("VOShortName", "EZ05");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet_DE(dic);




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_anrechenbareDZ");
            dic.Add("Level_6", "Default");
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
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "20");
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
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "20");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "PensionableServiceDate");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("MaximumService_UseServiceCap", "40");
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
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SV_EarlyRetTableService");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "ServiceForWartezeit");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "ServiceForWartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "");
            dic.Add("ForInternationalAccounting_DE", "");
            dic.Add("ForTrade_DE", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "false");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Standard");
            dic.Add("RoundingPeriod", "Days");
            dic.Add("RoundingMethod", "Commenced");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_AblaufWartezeit");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "30");
            dic.Add("YearOfService", "10");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("ServiceBasedOn", "ServiceForWartezeit");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Unit Formula");
            dic.Add("MenuItem", "Add Unit Formula");
            pAssumptions._TreeViewRightSelect(dic, "UF_Planformel");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Unit Formula");
            dic.Add("Level_6", "UF_Planformel");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Service", "SV_anrechenbareDZ");
            dic.Add("LimitServiceTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccuralAt_C", "");
            dic.Add("StopAccuralAt_cbo", "");
            dic.Add("StopAccuralAt_txt", "");
            dic.Add("RateTiersBasedOn", "");
            dic.Add("NumberOfRateTiers", "");
            pUnitFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "1");
            dic.Add("iColMax", "2");
            dic.Add("sData", "625,00");
            dic.Add("bPayCredit", "");
            pUnitFormula._FormulaTable(dic);



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
            dic.Add("Expression", "Round($UF_Planformel*$emp.ParttimeAverage,2)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "WTHVestingRatio");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("Level_5", "WTHVestingRatio");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VestingRule", "");
            dic.Add("VestingRatio", "$_mntelvector");
            pVesting._PopVerify_Standard_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("Level_5", "COLA_Rentenanpassungen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLABegin_Active_PaymentsFrom", "");
            dic.Add("COLABegin_Active_PaymentsFrom_txt", "1");
            dic.Add("COLABegin_Active_Age", "");
            dic.Add("COLABegin_Active_Date", "");
            dic.Add("COLADuring_V", "");
            dic.Add("COLADuring_P", "");
            dic.Add("COLADuring_T", "");
            dic.Add("COLADuring_Rate_cbo", "");
            dic.Add("COLADuring_Rate_txt", "");
            dic.Add("COLAAfter_V", "");
            dic.Add("COLAAfter_P", "Click");
            dic.Add("COLAAfter_T", "");
            dic.Add("COLAAfter_Rate_cbo", "");
            dic.Add("COLAAfter_Rate_txt", "");
            pCostOfLivingAdjustments._PopVerify_CostOfLivingAdjustments_DE(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("Level_5", "ERF_KuerzungVorgezogeneAR");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Add("PopVerify", "Pop");
            dic.Add("AgeInterval", "True");
            dic.Add("YearInterval", "");
            dic.Add("TabularOrActuarially", "");
            dic.Add("CustomCode", "");
            pEarlyRetirementFactor._PopVerify_Main(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "60", "");




            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Kapital");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Kapital");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("SurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IgnorePercentMarried_DE", "true");
            pFormOfPayment._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "BBG");
            dic.Add("Level_7", "InternationalAndTrade");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Altersrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "ERF_KuerzungVorgezogeneAR");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Kapital");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("VestingDefinition", "WTHVestingRatio");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Alterswitwenrente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenrente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Invalidenwitwenrente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Aktivenwitwenrente");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "True");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "FinalBenefit");
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
            dic.Add("Eligibility", "EL_Wartezeit");
            dic.Add("VestedRatio", "MNTEL1_Endanspruch");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_Kapital");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            dic.Add("VestingDefinition", "WTHVestingRatio");
            dic.Add("Other", "true");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRente");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "VKAP");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "LaufendeRenteWitwenanwartschaft");
            dic.Add("MenuItem", "Delete");
            pAssumptions._TreeViewRightSelect(dic, "");

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region  PensionValuations - Conversion 2009 - Methods

            pMain._SelectTab("Conversion 2009");

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
            dic.Add("iRow", "1");
            dic.Add("EarliestEntryAgeMethod", "");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "true");
            pMethods_DE._Table_TradeLiability(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("CompareToAccrued", "false");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AverageWorkingLifeTime", "true");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CheckDeferredVested", "");
            dic.Add("UseDeprecatedCOLAMethod", "True");
            pMethods_DE._PopVerify_Methods_DE(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region  PensionValuations - Conversion 2009 - ReportBreaks

            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Report Breaks");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "SubsidiaryCode");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFields", "SubDivisionCode");
            dic.Add("TextSubstitution", "Click");
            dic.Add("OK", "");
            pReportBreaks._PopVerify_ReportBreaks(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFieldValue", "IDEX");
            dic.Add("SubstitutionText", "IDEX Europe GmbH");
            dic.Add("OK", "");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFieldValue", "LUKAS");
            dic.Add("SubstitutionText", "Lukas Hydraulik GmbH");
            dic.Add("OK", "");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFieldValue", "FAG");
            dic.Add("SubstitutionText", "Kugelfischer Plan");
            dic.Add("OK", "");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BreakFieldValue", "VKAP");
            dic.Add("SubstitutionText", "Versorgungskapital Plan");
            dic.Add("OK", "click");
            pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BreakFields", "");
            dic.Add("TextSubstitution", "");
            dic.Add("OK", "click");
            pReportBreaks._PopVerify_ReportBreaks(dic);


            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region  PensionValuations - Conversion 2009 - TestCase & Reports

            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
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



            pMain._SelectTab("Conversion 2009");

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
            dic.Add("BreakByFundingVehicle", "True");
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

            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion 2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, false, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true, dic);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Test Case List", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results by Plan Def", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", false, true, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", false, true, 0, new string[3] { "IDEXEuropeGmbH_KugelfischerPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", false, true, dic);

            }


            thrd_Conversion2009.Start();

            pMain._SelectTab("Conversion 2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region  Data - Stichtagsbewertung 2010

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Stichtagsbewertung 2010");
            dic.Add("EffectiveDate", "31.12.2010");
            dic.Add("Parent", "Conversion Stichtag 2009");
            dic.Add("RSC", "");
            dic.Add("Shared", "True");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtagsbewertung 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\Input_RetStu_AdditionalInfo_2010.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\Input_RetStu_FAG_2010.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\Input_RetStu_VKAP_2010.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "TerminationFlag");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Integer");
            dic.Add("FieldLength", "9");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Unload VKAP");
            dic.Add("MenuItem", "Remove file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Unload FAG");
            dic.Add("MenuItem", "Remove file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Import Ergebnisse 2009");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Personaldaten 2010");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu_FAG_2010.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Last Year", 1, 0, 1, "LYOverwriteResults");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("TerminationFlag", "TerminationFlag", 0, true);


            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);



            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Personaldaten 2010");
            dic.Add("Level_4", "Ergebnisse VKAP");
            pData._TreeViewSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Versorgungskapitalplan");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu_VKAP_2010.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true);
            pData._IP_Mapping_MapField("TerminationFlag", "TerminationFlag", 0, true);



            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "AC");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "IN");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "IN");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "IN");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "IN");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "IN");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);



            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "DEF");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "DEF");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "PAY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "PAY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "PAY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "PAY");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
            dic.Add("Standard", "");
            dic.Add("OK", "");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_Transformation(1, 1, "2");
            pData._IP_Mapping_Transformation(1, 2, "XY");

            pData._IP_Mapping_Transformation(2, 1, "7");
            pData._IP_Mapping_Transformation(2, 2, "XY");

            pData._IP_Mapping_Transformation(3, 1, "13");
            pData._IP_Mapping_Transformation(3, 2, "XY");

            pData._IP_Mapping_Transformation(4, 1, "14");
            pData._IP_Mapping_Transformation(4, 2, "XY");

            pData._IP_Mapping_Transformation(5, 1, "18");
            pData._IP_Mapping_Transformation(5, 2, "NY");

            pData._IP_Mapping_Transformation(6, 1, "19");
            pData._IP_Mapping_Transformation(6, 2, "NO");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "");
            dic.Add("Standard", "");
            dic.Add("OK", "click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_VKAP");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"VKAP\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Personaldaten 2010");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_EZ05");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"EZ05\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_EZ20");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"EZ20\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "IsEligible_FAG");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode=\"FAG\",1,0)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);




            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "8");
            dic.Add("Unique_UniqueMatch_Num", "286");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of New");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Matched");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Unload FAG Besitzstand");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Additional Information 2010");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu_AdditionalInfo_2010.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);



            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "294");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "0");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Filters");
            pData._TreeViewSelect(dic);

            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Actives+Deferreds");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=PayStatus_C=\"DEF\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Aufzuloesen");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationFlag");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=TerminationFlag_C>0");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "FAG Plan");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnitCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(UnitCode_C=\"FAG\",TRUE,FALSE)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            pData._FL_Grid("Custom", 10, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddFilter", "Click");
            dic.Add("DeleteHighlightedFilter", "");
            pData._PopVerify_Filters(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pensioner Member_****");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=AND(OR(ParticipantStatus_C=\"IN\",ParticipantStatus_C=\"INTR\"),PayStatus_C=\"PAY\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Letzte Anderungen");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Jahreswerte Vollzeit");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PartTimeFactor");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PartTimeFactor_C*100,4)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ParttimeAverage");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "ParttimeAverage");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(ParttimeAverage_C*100,4)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayCurrentYear_C*12/ParttimeFactor_C*100,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AvgPayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "AvgPay");
            dic.Add("Level_5", "AvgPayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(AvgPayCurrentYear_C*12,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayAtTermination_C/PartTimeFactor_C*12*100,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Durchschnittsentgelt");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Durchschnittsentgelt");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Actives+Deferreds");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ParticipantStatus_C=\"IN\",Durchschnittsentgelt_C*12,3685.17*12)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Festbetrag");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Festbetrag");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Actives+Deferreds");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ParticipantStatus_C=\"IN\",Festbetrag_C,3.63)");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Previous", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Benefit1DB_C*12");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "9");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "StartBenefit");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StartBenefit");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=StartBenefit_C*12");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "10");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BenefitBeforeLastIncrease");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BenefitBeforeLastIncrease");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(Benefit1DB_C<>Benefit1DB_P,Benefit1DB_P,BenefitBeforeLastIncrease_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Tarifanpassung 2011");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "UnionCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(OR(UnionCode_C=1,UnionCode_C=2),ROUND(PayCurrentYear_C*1.027,2),PayCurrentYear_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "DynFaktorBesitzstand");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "DynFaktorBesitzstand");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(OR(DAYS360(TerminationDate1_C,Tarifanpassungsdatum)<0,ISBLANK(TerminationDate1_C)),ROUND(DynFaktorBesitzstand_C*1.027,6),DynFaktorBesitzstand_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "6");
            dic.Add("sData", "Tarifanpassungsdatum");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "31.03.2011");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "");
            dic.Add("sFormula", "");
            dic.Add("sRange", "Tarifanpassungsdatum");
            dic.Add("bVerify", "");
            dic.Add("bTable", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BesitzstandAktuellEURO");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "TerminationDate1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BesitzstandAktuellEURO");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(OR(DAYS360(TerminationDate1_C,Tarifanpassungsdatum)<0,ISBLANK(TerminationDate1_C)),ROUND(BesitzstandAktuellEURO_C*1.027,6),BesitzstandAktuellEURO_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("iCol", "6");
            dic.Add("sData", "Tarifanpassungsdatum");
            dic.Add("sFormula", "");
            dic.Add("sRange", "");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "31.03.2011");
            dic.Add("sFormula", "");
            dic.Add("sRange", "Tarifanpassungsdatum");
            dic.Add("bVerify", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("iCol", "6");
            dic.Add("sData", "");
            dic.Add("sFormula", "");
            dic.Add("sRange", "Tarifanpassungsdatum");
            dic.Add("bVerify", "");
            dic.Add("bTable", "");
            pData._DG_DerivationDefinition_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("NewVersion", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("SelectSampleRecords_Formula", "");
            dic.Add("SelectSampleRecords_Accept", "");
            dic.Add("SelectSampleRecords_Apply", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Auflosen bei TerminationFlag");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ParticipantStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Aufzuloesen");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"IN\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "clickk");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Aufzuloesen");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"EXP\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Fill Reportfields");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayCurrentYear_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "UVACalcMethod");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(IF(UVACalcMethod_C=1,PayAtTermination_C,Benefit1DB_C),2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Pensioner Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(Benefit1DB_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Orphans");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(Benefit1DB_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "DeriveUSC");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "View && Update");
            dic.Add("Level_3", "Last Session");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "Click");
            dic.Add("CustomExpression_Formula", "=AND(BirthDate_C=DATEVALUE(\"09.08.1961\"),SubsidiaryCode_C=\"IDEX\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "CashTransfer");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            pAssumptions._SelectTab("Individual Record");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "Click");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "CashTransfer_C");
            dic.Add("UpdatedValue", "5451");
            dic.Add("OK", "click");
            pData._PopVerify_VU_IR_MannualUpdate(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("BatchUpdateName", "");
            dic.Add("SelectFieldstoDisplay", "");
            dic.Add("StandardorCustomFilter_rd", "");
            dic.Add("StandardorCustomFilter_cbo", "");
            dic.Add("CustomExpression_rd", "true");
            dic.Add("CustomExpression_Formula", "=BirthDate_C=DATEVALUE(\"06.02.1945\")");
            dic.Add("CustomExpression_Accept", "Click");
            dic.Add("Apply", "");
            dic.Add("Plug", "");
            dic.Add("Correction", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_BatchUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "Click");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, false, true);


            pAssumptions._SelectTab("Individual Record");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ViewSetName", "");
            dic.Add("SelectLabelsToView", "");
            dic.Add("Filter", "");
            dic.Add("SimpleQuery", "");
            dic.Add("SimpleQuery_Field", "");
            dic.Add("SimpleQuery_Operator", "");
            dic.Add("Simplequery_Value", "");
            dic.Add("Apply", "Click");
            dic.Add("GenerateSummary", "");
            dic.Add("PrintAll", "");
            dic.Add("PrintToFile", "");
            dic.Add("ViewAllManualChanges", "");
            pData._PopVerify_ViewUpdate(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Label", "PayCurrentYear_C");
            dic.Add("UpdatedValue", "52464");
            dic.Add("OK", "click");
            pData._PopVerify_VU_IR_MannualUpdate(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2010");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "UNLOAD 2009 final");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Unload to Val 2010");
            dic.Add("UseLatestDate", "true");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region PensionValuations - Stichtag 2010 - Baseline


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


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Test Cases", "Conversion", true, true);
            ////pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Direct Promise", "RollForward", true, true);

            ////////_gLib._MsgBoxYesNo("", "LiabilitySetForGlobeExport are not downloaded since there is no need to download this report for DE client");

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_Baseline, "Payout Projection", "RollForward", false, true, dic);

            }


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


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Test Cases", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010_PreliminaryAssumptions, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }

            thrd_Stichtag2010_PreliminaryAssumptions.Start();


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Data - Stichtagsbewertung 2011


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ParticipantData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Stichtagsbewertung 2011");
            dic.Add("EffectiveDate", "31.12.2011");
            dic.Add("Parent", "Stichtagsbewertung 2010");
            dic.Add("RSC", "");
            dic.Add("Shared", "True");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtagsbewertung 2011");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Stichtagsbewertung 2011");

            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\Input_RetStu_FAG_2011_10.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Upload Data");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "Click");
            dic.Add("Upload", "");
            pData._PopVerify_UploadData(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE008\Input_RetStu_VKAP_2011_8.xls");
            dic.Add("Open", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_FileOpen(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LocalFile", "");
            dic.Add("GRSUnloadFile", "");
            dic.Add("SharepointFile", "");
            dic.Add("Browse", "");
            dic.Add("Upload", "Click");
            pData._PopVerify_UploadData(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Additional Information 2010");
            dic.Add("MenuItem", "Remove file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Personaldaten 2010");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Personaldaten 2011");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu_FAG_2011_10.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Personaldaten 2011");
            dic.Add("Level_4", "Versorgungskapitalplan");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Versorgungskapitalplan 2011");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu_VKAP_2011_8.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate & Load");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Status", "");
            dic.Add("LoadBlankData", "false");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "Click");
            pData._PopVerify_IP_ValidateAndLoad(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Personaldaten 2011");
            pData._TreeViewSelect(dic);


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);


            pData._SelectTab("Matching");

            dic.Clear();
            dic.Add("Field", "EmployeeIDNumber");
            dic.Add("Include", "False");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "BirthDate");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "HireDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);

            dic.Clear();
            dic.Add("Field", "MembershipDate1");
            dic.Add("Include", "True");
            dic.Add("ImportFormulaOverride", "");
            dic.Add("WarehouseFormulaOverride", "");
            pData._IP_Matching_FPSpread(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "7");
            dic.Add("Unique_UniqueMatch_Num", "289");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
            dic.Add("Warehouse_NoMatch_Num", "5");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "Click");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "Matched");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Matched");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueUniqueMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "Click");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "");
            dic.Add("AcceptAllRecordsAs_What", "New");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of New");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Unique_NoMatch", "");
            dic.Add("Unique_UniqueMatch", "");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "Click");
            dic.Add("AcceptAllRecordsAs_What", "Gone");
            dic.Add("AcceptSelectedRecordsAs_What", "");
            pData._PopVerify_IP_Matching_MatchingResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Are you sure that you want to accept all records with a status of Gone");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "All 'UnmatchedInWarehouse' records have been accepted");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_RunResults_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Fill Reportfields");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);

            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Jahreswerte Vollzeit");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Tarifanpassung 2011");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Auflosen bei TerminationFlag");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
            dic.Add("MenuItem", "Remove Derivation Group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic);



            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Jahreswerte Vollzeit");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayCurrentYear_C*12/ParttimeFactor_C*100,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "AvgPayCurrentYear");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "AvgPay");
            dic.Add("Level_5", "AvgPayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(AvgPayCurrentYear_C*12,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayAtTermination");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "PartTimeFactor");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayAtTermination_C/PartTimeFactor_C*100,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Durchschnittsentgelt");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Durchschnittsentgelt");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Actives+Deferreds");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ParticipantStatus_C=\"IN\",Durchschnittsentgelt_C,3822.89*12)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Festbetrag");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Festbetrag");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Actives+Deferreds");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(ParticipantStatus_C=\"IN\",Festbetrag_C,3.63)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "FAG Plan");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "6");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit1DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=Benefit1DB_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "7");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "StartBenefit");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "StartBenefit");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=StartBenefit_C");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);




            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "8");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BenefitBeforeLastIncrease");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "BenefitBeforeLastIncrease");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Inactive Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(Benefit1DB_C<>Benefit1DB_P,Benefit1DB_P,BenefitBeforeLastIncrease_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Fill Reportfields");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "Pay");
            dic.Add("Level_5", "PayCurrentYear");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Active Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(PayCurrentYear_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "UVACalcMethod");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayAtTermination");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Deferred Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(IF(UVACalcMethod_C=1,PayAtTermination_C,Benefit1DB_C),2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Pensioner Member_****");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(Benefit1DB_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            dic.Add("Level_3", "Benefit1DB");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Orphans");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=ROUND(Benefit1DB_C,2)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Auflosen bei TerminationFlag");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "ParticipantStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Aufzuloesen");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"IN\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "PayStatus");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "Aufzuloesen");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=\"EXP\"");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Update for VKAP");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "Click");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "SubDivisionCode");
            dic.Add("DerivedField_SearchFromIndex", "");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "");
            pData._PopVerify_DG_DerivationDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "SubDivisionCode");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=IF(SubDivisionCode_C=\"\",\"VKAP\",SubDivisionCode_C)");
            dic.Add("Previous", "");
            dic.Add("Next", "");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_DerivationDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "");
            dic.Add("Filter", "");
            dic.Add("MoveUp", "");
            dic.Add("MoveDown", "");
            dic.Add("Add", "");
            dic.Add("Insert", "");
            dic.Add("Delete", "");
            dic.Add("AddWorkFields", "");
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Stichtagsbewertung 2011");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Unload to Val 2010");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Upload Data 2011");
            dic.Add("UseLatestDate", "true");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

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


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", true, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", true, true);

                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                //////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", true, true, dic);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Checking Template", "RollForward", false, true, 0, new string[4] { "EZ05", "EZ20", "FAG", "VKAP" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Member Statistics", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Valuation Summary", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[4] { "IDEXEuropeGmbH_KugelfischerPlan", "IDEXEuropeGmbH_VersorgungskapitalPlan", "LukasHydraulikGmbH_KugelfischerPlan", "LukasHydraulikGmbH_VersorgungskapitalPlan" });
                ////////pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Payout Projection", "RollForward", false, true, dic);

            }

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_Baseline, "Direct Promise", "RollForward", true, true);

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


            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityPLUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }



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

            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Test Cases", "Conversion", true, true);


            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", true, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Valuation Summary", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[2] { "KugelfischerPlan", "VersorgungskapitalPlan" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Payout Projection", "RollForward", false, true, dic);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2011_InterestSensitivityMINUS, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);

            }

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
                       
         

        public void t_CompareRpt_Conversion2009(string sOutputPension_Conversion2009)
           {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE008CN", sOutputPension_Conversion2009_Prod, sOutputPension_Conversion2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2009");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_IDEXEuropeGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_KugelfischerPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary_LukasHydraulikGmbH_VersorgungskapitalPlan.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }

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
