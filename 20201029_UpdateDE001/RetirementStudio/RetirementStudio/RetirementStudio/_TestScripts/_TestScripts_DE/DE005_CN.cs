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
    /// Summary description for DE005_CN
    /// </summary>
    [CodedUITest]
    public class DE005_CN
    {
        public DE005_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.DE;
            Config.sClientName = "QA DE Benchmark 005 Create New";
            Config.sPlanName = "Alle - QA DE Benchmark 005 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }


        #region Report Output Directory



        public string sOutputPension_Conversion2009 = "";
        public string sOutputPension_Stichtag2010 = "";

        public string sOutputPension_Conversion2009_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_005\Production\7.2_20180319_B\Conversion2009\";
        public string sOutputPension_Stichtag2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_DE_Benchmark_005\Production\7.2_20180319_B\Stichtag2010\";



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

                    sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "Conversion2009\\" + sPostFix + "\\");
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
                sOutputPension_Conversion2009 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Conversion2009\\");
                sOutputPension_Stichtag2010 = _gLib._CreateDirectory(sMainDir + "\\sOutputPension_Stichtag2010\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputPension_Conversion2009 = @\"" + sOutputPension_Conversion2009 + "\";" + Environment.NewLine;
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
        public void test_DE005_CN()
        {

            #region MultiThreads

            Thread thrd_Conversion2009 = new Thread(() => new DE005_CN().t_CompareRpt_Conversion2009(sOutputPension_Conversion2009));

            #endregion


            this.GenerateReportOuputDir();


            #region Create Client


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
            dic.Add("ClientCode", "DEBM005");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "12/31");
            dic.Add("Notes", "Client Owner: Stefan Heinzman. Original client: Aegis Media Central Services GmbH & Co. KG");
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
            dic.Add("DefaultValuationDate", "31.12");
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
            dic.Add("EnterVOShortName", "Flex");
            dic.Add("ConfirmVOShortName", "Flex");
            dic.Add("VOLongName", "FlexibleBenefits");
            dic.Add("VOClass", "");
            dic.Add("FundingVehicle", "");
            dic.Add("TypeOfPromise", "Defined Benefit with Contribution");
            dic.Add("Sponsor", "Employee");
            dic.Add("PSVCoverage", "True");
            dic.Add("ExculdeWidowers", "");
            dic.Add("Tax", "");
            dic.Add("Trade", "");
            dic.Add("InternationalAccounting", "");
            dic.Add("Apply30g", "True");
            dic.Add("OK", "Click");
            pMain._PopVerify_CreateNewVO(dic);


            #endregion



            #region Conversion Data service: Conversion2009


            #region Add Data Service

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
            dic.Add("Name", "Conversion2009");
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
            dic.Add("ServiceToOpen", "Conversion2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            #endregion


            #region Conversion2009 - CurrentView

            pData._ts_UpdateIncludedVOs("Flex", true);


            dic.Clear();
            dic.Add("Level_1", "Conversion2009");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Personal Information");
            dic.Add("Label", "TerminationFlag1");
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
            dic.Add("Category", "Pay");
            dic.Add("Label", "Pay1");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "LumpSumDeathBenefit3");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "LumpSumDeathBenefit4");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AssumedRetAgeIntAcc");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BenefitFromActContrib1");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BenefitFromActContrib2");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "ContribOverPSVLimitLY");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "ContribOverPSVLimitTY");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "EeAccountBalance2");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "EeAccountBalance3");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "EeAccountBalance4");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DC Information");
            dic.Add("Label", "LumpSumBenefit");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Legacy System Results");
            dic.Add("Label", "LegacyPSV");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Upload Data & Import - Import Data

            dic.Clear();
            dic.Add("Level_1", "Conversion2009");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE005\Input_RetStu2009Data.xls");
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
            dic.Add("Level_1", "Conversion2009");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);


            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Data Upload from GRS");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Input_RetStu2009Data.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "");
            dic.Add("Browse", "");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_SelectFile(dic);

            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "Legacy System Results", 1, 0, 1, "LegacyTaxAL");
            pData._IP_Mapping_Initialize("Personal Information", "Last Year", 1, 0, 1, "LYOverwriteResults");
            pData._IP_Mapping_Initialize("Personal Information", "DC Information", 1, 0, 1, "EeContribRate1");
            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "IsEligible_VOParent");

            pData._IP_Mapping_MapField("ParticipantStatus", "ETY", 0, false, 0);
            pData._IP_Mapping_MapField("PayStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("AliveStatus", "ETY", 0, true, 0);
            pData._IP_Mapping_MapField("TerminationFlag1", "TerminationFlag", 0, true, 5);
            pData._IP_Mapping_MapField("LumpSumBenefit", "EeContribRate1", 0, true, 12);
            pData._IP_Mapping_MapField("LYAliveStatus", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("LYHealthStatus", "HealthStatus", 0, true, 0);
            pData._IP_Mapping_MapField("LYParticipantStatus", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("LYPayStatus", "ELY", 0, true, 0);
            pData._IP_Mapping_MapField("LYBookReserve", "LegacyLYBookReserve", 0, true, 0);
            pData._IP_Mapping_MapField("LegacyTradeAL", "LegacyTaxAL", 0, true, 30);
            pData._IP_Mapping_MapField("LegacyTradeNC", "LegacyTaxNC", 0, true, 0);

            //Format - ParticipantStatus
            pData._IP_Mapping_ClickEdit("ParticipantStatus", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            //Format - PayStatus
            pData._IP_Mapping_ClickEdit("PayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            //Format - AliveStatus
            pData._IP_Mapping_ClickEdit("AliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYAliveStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            pData._IP_Mapping_ClickEdit("LYParticipantStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);


            pData._IP_Mapping_ClickEdit("LYPayStatus", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Lookup", "True");
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
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Mapping_Transformation(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preview", "Click");
            pData._PopVerify_IP_Mapping(dic);

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
            dic.Add("DerivedField", "LYOverwriteResults");
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
            dic.Add("DerivedField", "IsEligible_Flex");
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
            dic.Add("Unique_NoMatch_Num", "79");
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
            dic.Add("PopVerify", "Verify");
            dic.Add("Matched_Num", "0");
            dic.Add("New_Num", "79");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("RefreshResults", "");
            dic.Add("UnacceptAllRecords", "");
            dic.Add("UnacceptSelectedRecords", "");
            dic.Add("SaveToWarehouse", "Click");
            dic.Add("MergeDuplicates", "");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Once the matching results have been processed, all the Import parameters for this file will become read-only. Do you wish to proceed?");
            dic.Add("Yes", "");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Yes", "Click");
            dic.Add("No", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic);


            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "The matching results have now been processed. All the Import parameters for this file are now read-only.");
            dic.Add("OK", "");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic);


            #endregion


            #region Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "Conversion2009");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "Letzte Anpassumgen");
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

            //Derivation - YearsCertain1
            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "YearsCertain1");
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
            dic.Add("Formula", "=60");
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

            dic.Clear();
            dic.Add("Level_1", "Conversion2009");
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

            //Derivation - USC
            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "USC");
            dic.Add("DerivedField_SearchFromIndex", "3");
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
            dic.Add("SelectFieldsForPreview", "");
            dic.Add("CalculateAndPreview", "Click");
            dic.Add("SaveToWarehouse", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic);

            #endregion


            #region Snapshot

            dic.Clear();
            dic.Add("Level_1", "Conversion2009");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Data Unload to Conversion");
            dic.Add("UseLatestDate", "True");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

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

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            #endregion


            pMain._Home_ToolbarClick_Top(true);



            #endregion



            #region Pension Valuation - Conversion2009


            #region Add Val Service

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
            dic.Add("Name", "Conversion2009");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("PlanYearEndingIn_DE", "2009");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("SelectAllVO", "Click");
            dic.Add("DeselectAll", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Conversion2009");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            #endregion


            #region ParticipantDataSet

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
            dic.Add("SnapshotName", "Data Unload to Conversion");
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

            pMain._SelectTab("Participant DataSet");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Assumptions

            pMain._SelectTab("Conversion2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pAssumptions._TreeView_SelectTab("Tax");

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
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,50");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pAssumptions._TreeView_SelectTab("Trade");

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
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,50");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

            pAssumptions._TreeView_SelectTab("IntAccounting");

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
            dic.Add("UnemploymentInsuranceContributionRate_EE", "1,50");
            dic.Add("CareInsuranceContributionRate_EE", "1,225");
            pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic);

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
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "AsPI_Gehaltstrend");

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
            dic.Add("txtRate", "1,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

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
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("PreDecrementPostCommencement", "True");
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



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "true");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._TreeView_SelectTab("Trade");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FromData", "True");
            dic.Add("CustomCode", "");
            dic.Add("AssumedRetirementAge_V", "Click");
            dic.Add("AssumedRetirementAge_C", "");
            dic.Add("AssumedRetirementAge_cbo", "AssumedRetAgeIntAcc");
            dic.Add("AssumedRetirementAge_txt", "");
            pAssumedRetirementAge._PopVerify_FromData(dic);

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
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,25");
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
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

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
            dic.Add("Level_3", "Default");
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



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "true");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "true");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            pAssumptions._TreeView_SelectTab("IntAccounting");

            _gLib._Wait(1);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Assumed Retirement Age");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Add("PopVerify", "Pop");
            dic.Add("Calculate", "True");
            dic.Add("FromData", "");
            dic.Add("CustomCode", "");
            pAssumedRetirementAge._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Fruhestmogliches", "");
            dic.Add("Regelaltersgrenze", "");
            dic.Add("OverwriteWithIndividualRetirementAge_chx", "true");
            dic.Add("OverwriteWithIndividual_Age_V", "click");
            dic.Add("OverwriteWithIndividual_Age_cbo", "AssumedRetAgeIntAcc");
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
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "5,75");
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
            dic.Add("txtRate", "2,0");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

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
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "True");
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



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "true");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZEROWTH");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Other", "true");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERODIS");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

           
            pMain._Home_ToolbarClick_Top(true);


            #endregion


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


            #region Provisions

            pMain._SelectTab("Conversion2009");

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
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_PensionableService");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_PensionableService");
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
            dic.Add("ServiceStarts_Date", "PensionableServiceDate");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            pService._PopVerify_RulesBasedService_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "SVC_ForProration");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Service");
            dic.Add("Level_5", "SVC_ForProration");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("ServiceAsAFunction", "");
            dic.Add("RulesBasedService", "True");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "True");
            dic.Add("ForInternationalAccounting_DE", "True");
            dic.Add("ForTrade_DE", "True");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01.01.2010");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "");
            dic.Add("ServiceEnds_FixedDate", "31.12.2010");
            dic.Add("ServiceEnds_Date", "");
            dic.Add("CalculationMethod", "Valuation date");
            dic.Add("RoundingPeriod", "Years");
            dic.Add("RoundingMethod", "Commenced");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA_EndOfWaitingPeriod");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "From/To Age");
            dic.Add("Level_5", "FTA_EndOfWaitingPeriod");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "15");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "#1#");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);

            _gLib._MsgBox("From/To Age","Make sure the \"Service based on value\" is blank");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "EL_WaitingPeriodOver");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("Level_5", "EL_WaitingPeriodOver");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age>= $FTA_EndOfWaitingPeriod");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "EL_NextYear");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Eligibilities");
            dic.Add("Level_5", "EL_NextYear");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age= ($ValAge+1)");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PP_PayProjection");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
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
            dic.Add("UseCurrentYearPayRateFrom", "Pay1CurrentYear");
            dic.Add("PayIncreaseAssumption", "AsPI_Gehaltstrend");
            pPayoutProjection._PopVerify_PresentYear(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PP_OldAgeBenNY");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_OldAgeBenNY");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "True");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.BenefitFromActContrib2");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PP_LumpSumBenNY");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Projection");
            dic.Add("Level_5", "PP_LumpSumBenNY");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "True");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.LumpSumBenefit");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PA_PayAverage");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("Level_5", "PA_PayAverage");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PP_PayProjection");
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
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            dic.Add("Level_4", "Pay Average");
            dic.Add("Level_5", "PA_PayAverage");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "DeferredVesteds");

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
            dic.Add("txtLocalEligibility", "DeferredVesteds");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$_DefVested");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Participant Info");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CFA_BBG");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_BBG");
            dic.Add("Level_7", "Default");
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
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CFA_OldAgePension");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_OldAgePension");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "ProjectedValue");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_OldAgePension");
            dic.Add("Level_7", "ProjectedValue");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.EeAccountBalance2");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_OldAgePension");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.EeAccountBalance4");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CFA_OldAgePensionNoPSVSave");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_OldAgePensionNoPSVSave");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max(0, $emp.EeAccountBalance1-$emp.EeAccountBalance4)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CFA_LumpSumDeathBen");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_LumpSumDeathBen");
            dic.Add("MenuItem", "Add New Liability Type Folder");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FolderName", "ProjectedValue");
            dic.Add("IntlAccountingABO", "True");
            dic.Add("IntlAccountingPBO", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("OK", "Click");
            pAssumptions._PopVerify_NewLiabilityTypeFolder(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_LumpSumDeathBen");
            dic.Add("Level_7", "ProjectedValue");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.LumpSumDeathBenefit1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_LumpSumDeathBen");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.LumpSumDeathBenefit4");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("MenuItem", "Add Custom Formula A");
            pAssumptions._TreeViewRightSelect(dic, "CFA_LumpSumDeathBenNoPSVSave");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            dic.Add("Level_6", "CFA_LumpSumDeathBenNoPSVSave");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "Max(0, $emp.LumpSumDeathBenefit1-$emp.LumpSumDeathBenefit4)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula A");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "PC_OldAgeBenContribNY");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_OldAgeBenContribNY");
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
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_OldAgeBenContribNY");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "Click");
            p415Limits._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_OldAgeBenContribNY");
            dic.Add("Level_7", "International");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "Click");
            dic.Add("CustomCode", "");
            p415Limits._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PP_OldAgeBenNY");
            dic.Add("ServiceBasedOn", "SVC_PensionableService");
            pPayCredit._PopVerify_Standard(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "1,0");



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "EL_NextYear");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_OldAgeBenContribNY");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "Click");
            p415Limits._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "PC_LumpSumDeathBenContribNY");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_LumpSumDeathBenContribNY");
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
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_LumpSumDeathBenContribNY");
            dic.Add("Level_7", "International");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "Click");
            p415Limits._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_LumpSumDeathBenContribNY");
            dic.Add("Level_7", "International");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "Click");
            dic.Add("CustomCode", "");
            p415Limits._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PP_LumpSumBenNY");
            dic.Add("ServiceBasedOn", "SVC_PensionableService");
            pPayCredit._PopVerify_Standard(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "1,0");

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "True");
            dic.Add("cboPreDefinedEligibility", "EL_NextYear");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            dic.Add("Level_6", "PC_LumpSumDeathBenContribNY");
            dic.Add("Level_7", "AllOthers");
            dic.Add("Level_8", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "Click");
            p415Limits._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Pay Credit");
            pAssumptions._Collapse(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("MenuItem", "Add Contributions Based Formula");
            pAssumptions._TreeViewRightSelect(dic, "CBF_OldAgePension");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_OldAgePension");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "True");
            dic.Add("FormulaCalculated", "");
            dic.Add("PreDefinedAmount", "True");
            dic.Add("AccountBalance", "CFA_OldAgePension");
            dic.Add("StartAge", "");
            dic.Add("PreDefinedAmount_cbo", "PC_OldAgeBenContribNY");
            dic.Add("TransformationRate_Percent", "click");
            dic.Add("TransformationRate_Rate", "100,0");
            pContributionsBasedFormula._ContributionsBasedFormula(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("MenuItem", "Add Contributions Based Formula");
            pAssumptions._TreeViewRightSelect(dic, "CBF_LumpSumDeathBen");



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Contributions Based Formula");
            dic.Add("Level_6", "CBF_LumpSumDeathBen");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SimpleLinearization", "True");
            dic.Add("FormulaCalculated", "");
            dic.Add("PreDefinedAmount", "True");
            dic.Add("AccountBalance", "CFA_LumpSumDeathBen");
            dic.Add("StartAge", "");
            dic.Add("PreDefinedAmount_cbo", "PC_LumpSumDeathBenContribNY");
            dic.Add("TransformationRate_Percent", "");
            dic.Add("TransformationRate_Rate", "100,0");
            pContributionsBasedFormula._ContributionsBasedFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "CFB_FinalBenefit");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_FinalBenefit");
            dic.Add("Level_7", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            dic.Add("Level_5", "Custom Formula B");
            dic.Add("Level_6", "CFB_FinalBenefit");
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
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "DefVested_Endanspruch");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$_DefVestedFixed");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Formulae");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Vesting");
            dic.Add("MenuItem", "Add Vesting");
            pAssumptions._TreeViewRightSelect(dic, "VST_LegalVesting");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLA_Rentenanpassungen");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Cost of Living Adjustments");
            dic.Add("Level_5", "COLA_Rentenanpassungen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLABegin_Active_PaymentsFrom", "");
            dic.Add("COLABegin_Active_PaymentsFrom_txt", "0");
            dic.Add("COLABegin_Active_Age", "");
            dic.Add("COLABegin_Active_Date", "");
            dic.Add("COLADuring_V", "");
            dic.Add("COLADuring_P", "");
            dic.Add("COLADuring_T", "");
            dic.Add("COLADuring_Rate_cbo", "");
            dic.Add("COLADuring_Rate_txt", "");
            dic.Add("COLAAfter_V", "");
            dic.Add("COLAAfter_P", "");
            dic.Add("COLAAfter_T", "");
            dic.Add("COLAAfter_Rate_cbo", "");
            dic.Add("COLAAfter_Rate_txt", "");
            pCostOfLivingAdjustments._PopVerify_CostOfLivingAdjustments_DE(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLABegin_Active_PaymentsFrom", "");
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
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("MenuItem", "Add Early Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "ERF_EarlyRetirement");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Early Retirement Factors");
            dic.Add("Level_5", "ERF_EarlyRetirement");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            pEarlyRetirementFactor._TBL_ReductionDefinition(1, "30", "");


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_StraightLife");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_StraightLife");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "click");
            dic.Add("SurvivorPercentOrAmount_V", "");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            dic.Add("btnGuaranteePeriod_V", "click");
            dic.Add("GuaranteePeriod_cbo", "YearsCertain1");
            dic.Add("btnGuaranteePeriod_C", "");
            dic.Add("GuaranteePeriod_txt", "");
            dic.Add("cboGuaranteePeriod_YearMonth", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);



            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Spouse");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Spouse");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Reversionary");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Reversionary");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Reversionary");
            dic.Add("SurvivorPercentOrAmount_V", "Click");
            dic.Add("SurvivorPercentOrAmount_P", "");
            dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
            dic.Add("SurvivorPercentOrAmount_txt", "");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Orphans");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Orphans");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Immediate orphan annuity");
            dic.Add("NumOfPayPerYear_V", "");
            dic.Add("NumOfPayPerYear_C", "");
            dic.Add("NumOfPayPerYear_cbo", "");
            dic.Add("NumOfPayPerYear_txt", "");
            dic.Add("LastPaymentAge_V", "");
            dic.Add("LastPaymentAge_C", "Click");
            dic.Add("MaximumPaymentAge_V", "");
            dic.Add("MaximumPaymentAge_C", "Click");
            dic.Add("LastPaymentAge_txt", "18");
            dic.Add("MaximumPaymentAge_txt", "25");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_LumpSum");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_LumpSum");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("IgnorePercentMarried_DE", "true");
            pFormOfPayment._PopVerify_FormOfPayment(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP_Insurance");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            dic.Add("Level_4", "Form of Payment");
            dic.Add("Level_5", "FOP_Insurance");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Insurance");
            pFormOfPayment_DE._PopVerify_FormOfPayment(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Provisions");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "OldAgePension");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "OldAgePension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CBF_OldAgePension");
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
            dic.Add("Eligibility", "EL_WaitingPeriodOver");
            dic.Add("VestedRatio", "$_mntelvector");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "ERF_EarlyRetirement");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);


            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "OldAgePensionOverPSVSave");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "OldAgePensionOverPSVSave");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CFA_OldAgePensionNoPSVSave");
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
            dic.Add("Eligibility", "EL_WaitingPeriodOver");
            dic.Add("VestedRatio", "$_mntelvector");
            dic.Add("CostOfLivingAdjustment", "COLA_Rentenanpassungen");
            dic.Add("EarlyRetirement", "ERF_EarlyRetirement");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_StraightLife");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Retirement");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "SpouseLumpSum");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "SpouseLumpSum");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CBF_LumpSumDeathBen");
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
            dic.Add("Eligibility", "EL_WaitingPeriodOver");
            dic.Add("VestedRatio", "$_mntelvector");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_LumpSum");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "SpouseLumpSumOverPSVSave");

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "SpouseLumpSumOverPSVSave");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
            dic.Add("ApplyVersorgungsausgleich", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives and deferreds");
            dic.Add("SingleFormulaOrBenefit_cbo", "CFA_LumpSumDeathBenNoPSVSave");
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
            dic.Add("Eligibility", "EL_WaitingPeriodOver");
            dic.Add("VestedRatio", "$_mntelvector");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("Conversion", "");
            dic.Add("FormOfPayment", "FOP_LumpSum");
            dic.Add("BenefitElectionPercentage", "");
            dic.Add("Decrement", "Death");
            dic.Add("ExcludePercentMarried", "");
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Pensioners");

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
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "True");
            dic.Add("UseAsWithdrawalBenefit", "");
            dic.Add("UseAsFutureValPension", "True");
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
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            dic.Clear();
            dic.Add("Level_1", "Pension");
            dic.Add("Level_2", "Flex");
            dic.Add("Level_3", "Benefit Definition");
            dic.Add("Level_4", "Plan Definition");
            dic.Add("Level_5", "Pensioners");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "True");
            dic.Add("FunctionOfOtherFormular", "");
            dic.Add("IncludeThisBenefitInPresentValueCalc", "");
            dic.Add("UseAsWithdrawalBenefit", "");
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
            pPlanDefinition_DE._PopVerify_PlanDefinition_DE_Pension(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "True");
            dic.Add("txtLocalEligibility", "Waisen");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.AliveStatus = \"NO\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region Methods

            pMain._SelectTab("Conversion2009");

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
            dic.Add("CostMethod", "Traditional Unit Credit");
            dic.Add("MembershipDate", "");
            dic.Add("AnnualIncreaseRate", "");
            dic.Add("EarliestEntryAgeMethod", "");
            pMethods_DE._Table_TradeLiability(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("CostMethod", "");
            dic.Add("MembershipDate", "");
            dic.Add("AnnualIncreaseRate", "");
            dic.Add("EarliestEntryAgeMethod", "");
            dic.Add("EarliestEntryAge_txt", "");
            dic.Add("AllowNegativeNormal", "true");
            pMethods_DE._Table_TradeLiability(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Traditional Unit Credit");
            dic.Add("CompareToAccrued", "True");
            dic.Add("AllowNegativeNormal", "True");
            pMethods_DE._Table_InternationalAccounting(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("VOShortName", "Flex");
            dic.Add("BenefitDefinition", "OldAgePensionOverPSVSave");
            dic.Add("PSVCoverage", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("IntAcctng", "True");
            pMethods_DE._Table_BenefitsToExclude(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("VOShortName", "Flex");
            dic.Add("BenefitDefinition", "SpouseLumpSumOverPSVSave");
            dic.Add("PSVCoverage", "True");
            dic.Add("Tax", "");
            dic.Add("Trade", "True");
            dic.Add("IntAcctng", "True");
            pMethods_DE._Table_BenefitsToExclude(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CheckDeferredVested", "");
            dic.Add("UseDeprecatedCOLAMethod", "True");
            pMethods_DE._PopVerify_Methods_DE(dic);


            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region  Test Cases

            pMain._SelectTab("Conversion2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12.25.1961\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05.02.1969\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"07.18.1967\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region ER & Output Manager

            pMain._SelectTab("Conversion2009");

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
            dic.Add("SaveResultsforAuditReport", "");
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

            pMain._SelectTab("Conversion2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Conversion2009");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Valuation Summary for Excel Export", "Conversion", true, true);
            pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Print", "Conversion", true, true);



            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Conversion Diagnostic", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Test Case List", "Conversion", true, true);
                pOutputManager._ExportReport_Common(sOutputPension_Conversion2009, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Individual Output", "Conversion", true, true);
                pOutputManager._ExportReport_Others(sOutputPension_Conversion2009, "Parameter Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Test Cases", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", true, false, 0, new string[1] { "DriectPromise" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", true, false, 0, new string[1] { "DriectPromise" });
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

                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Member Statistics", "Conversion", false, true, 0, new string[1] { "DriectPromise" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Conversion2009, "Valuation Summary", "Conversion", false, true, 0, new string[1] { "DriectPromise" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2009, "Payout Projection", "Conversion", false, true, dic);

            }

            thrd_Conversion2009.Start();


            pMain._SelectTab("Conversion2009");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            #endregion


            #endregion



            #region RF Data Service - Stichtag 2010


            #region Add Val Service

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
            dic.Add("Name", "Stichtag 2010");
            dic.Add("EffectiveDate", "31.12.2010");
            dic.Add("Parent", "Conversion2009");
            dic.Add("RSC", "");
            dic.Add("Shared", "True");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            #endregion


            #region Import Data

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Stichtag 2010");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "Stichtag 2010");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\DE005\AegisData2010.xls");
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
            dic.Add("Level_1", "Stichtag 2010");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Data Upload from GRS");
            pData._TreeViewSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "New Data 2010");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "AegisData2010.xls");
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

            pData._SelectTab("Pre Matching Derivations");


            dic.Clear();
            dic.Add("iRow", "1");
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
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

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
            dic.Add("PopVerify", "Pop");
            dic.Add("MatchManually", "");
            dic.Add("FindMatches", "Click");
            pData._PopVerify_IP_Matching(dic);

            dic.Clear();
            dic.Add("PopVerify", "Verify");
            dic.Add("Unique_NoMatch_Num", "1");
            dic.Add("Unique_UniqueMatch_Num", "79");
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
            dic.Add("Matched_Num", "79");
            dic.Add("New_Num", "1");
            dic.Add("Ignored_Num", "0");
            dic.Add("Gone_Num", "0");
            dic.Add("Leaver_Num", "0");
            dic.Add("Unmatched_Num", "0");
            dic.Add("Unmerged_Num", "0");
            pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic);

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

            #endregion


            #region Derivation Groups

            dic.Clear();
            dic.Add("Level_1", "Stichtag 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "Letzte Anpassumgen");
            pData._TreeViewSelect(dic);


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
            dic.Add("CalculateAndPreview", "");
            dic.Add("SaveToWarehouse", "");
            pData._PopVerify_DerivationGroups(dic);

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

            //Derivation - Benefit2DB
            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit2DB");
            dic.Add("DerivedField_SearchFromIndex", "10");
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
            dic.Add("Level_2", "DC Information");
            dic.Add("Level_3", "EeAccountBalance2");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=EeAccountBalance2_C");
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

            //Derivation - Benefit3DB
            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "Benefit3DB");
            dic.Add("DerivedField_SearchFromIndex", "10");
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
            dic.Add("Level_3", "LumpSumDeathBenefit1");
            pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("SelectInputFields", "");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("Formula", "=LumpSumDeathBenefit1_C");
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

            dic.Clear();
            dic.Add("Level_1", "Stichtag 2010");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("Level_3", "DeriveUSC");
            pData._TreeViewSelect(dic);

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

            #endregion


            #region Snapshots

            dic.Clear();
            dic.Add("Level_1", "Stichtag 2010");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "Data Unload to Conversion");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Unload 2010");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
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


            #endregion



            #region Pension RF Valuation - Stichtag 2010


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
            dic.Add("Name", "Stichtag 2010");
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
            dic.Add("ServiceToOpen", "Stichtag 2010");
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

            pMain._SelectTab("Stichtag 2010");

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

            //////// Neeed be update after FCs create

            pMain._SelectTab("Stichtag 2010");

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
            dic.Add("Template", "DirectPromise_2013");
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
            dic.Add("Listing1", "DirectPromise_2013");
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
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Actuarial Report");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Stichtag 2010");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);



            pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", true, true, 0, new string[1] { "DirectPromise" });
            pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary for Excel Export", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Parameter Print", "RollForward", true, true);
            ////////////pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010, "Direct Promise", "RollForward", true, true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Direct Promise", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "IFRS", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Parameter Summary", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Individual Checking Template", "RollForward", true, true, 0, new string[1] { "Flex" });
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", true, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", true, true, 0, new string[1] { "DirectPromise" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", true, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Liability Set for Globe Export", "RollForward", true, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", true, true, dic);

            }




            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputPension_Stichtag2010, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Individual Checking Template", "RollForward", false, true, 0, new string[1] { "Flex" });
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary for Excel Export", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", false, true);
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Member Statistics", "RollForward", false, true, 0, new string[1] { "DirectPromise" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Valuation Summary", "RollForward", false, true, 0, new string[1] { "DirectPromise" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "FAS Expected Benefit Pmts", "RollForward", false, true, 0, new string[1] { "ALL" });
                pOutputManager._ExportReport_DrillDown(Config.eCountry, sOutputPension_Stichtag2010, "Liability Set for Globe Export", "RollForward", false, true, 0, new string[1] { "ALL" });
                dic.Clear();
                dic.Add("Group_ReportBreak", "True");
                pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Stichtag2010, "Payout Projection", "RollForward", false, true, dic);

            }


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
                ////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0 ,true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts_ALL.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitySetforGlobeExport_ALL.xlsx", 4, 0, 0, 0, true);

            }


            pMain._SelectTab("Stichtag 2010");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

        }


        public void t_CompareRpt_Conversion2009(string sOutputPension_Conversion2009)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("DE005CN", sOutputPension_Conversion2009_Prod, sOutputPension_Conversion2009);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputPension_Conversion2009");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics_DriectPromise.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt2" });
                _compareReportsLib.CompareExcel_Exact("ValuationSummaryforExcelExport.xlsx", 0, new int[0, 0] { }, new string[1] { "Tabellenblatt3" });

                _compareReportsLib.CompareExcel_Exact("ValuationSummary_DriectPromise.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection_ReportBreak.xlsx", 4, 0, 0, 0);
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