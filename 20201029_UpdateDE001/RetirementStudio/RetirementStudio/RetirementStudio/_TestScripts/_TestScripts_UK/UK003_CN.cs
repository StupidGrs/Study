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
using RetirementStudio._UIMaps.DataSummaryFieldsClasses;
using RetirementStudio._UIMaps.FundingInformation_UKClasses;
using RetirementStudio._UIMaps.FutureValuationOptionClasses;
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ValuationProcessControlClasses;
using System.Threading;



namespace RetirementStudio._TestScripts._TestScripts_UK
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class UK003_CN
    {
        public UK003_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 003 Create New";
            Config.sPlanName = "QA UK Benchmark 003 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }


        #region Report Output Directory


        public string sOutputFunding_Valuation2011_Baseline = "";
        public string sOutputFunding_Valuation2014_Baseline = "";
        public string sOutputFunding_Valuation2014_FVGrowthPCT = "";

        public string sOutputFunding_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2011\6.9.1_20160928_E\";
        public string sOutputFunding_Valuation2014_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\Baseline\6.9.1_20160928_E\";
        public string sOutputFunding_Valuation2014_FVGrowthPCT_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Production\Funding\Valuation 2014\FV GrowthPCT\6.9.1_20160928_E\";



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

                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_003\Create New\Funding\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2011\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2014_Baseline = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\Baseline\\" + sPostFix + "\\");
                    sOutputFunding_Valuation2014_FVGrowthPCT = _gLib._CreateDirectory(sMainDir + "Valuation 2014\\FV GrowthPCT\\" + sPostFix + "\\");


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

                string sMainDir = sDir + "UK003_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2011_Baseline\\");
                sOutputFunding_Valuation2014_Baseline = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2014_Baseline\\");
                sOutputFunding_Valuation2014_FVGrowthPCT = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_Valuation2014_FVGrowthPCT\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_Valuation2011_Baseline = @\"" + sOutputFunding_Valuation2011_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2014_Baseline = @\"" + sOutputFunding_Valuation2014_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sOutputFunding_Valuation2014_FVGrowthPCT = @\"" + sOutputFunding_Valuation2014_FVGrowthPCT + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);

        }


        #endregion



        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public ValuationProcessControl pValuationProcessControl = new ValuationProcessControl();
        public AssumedRetirementAge pAssumedRetirementAge = new AssumedRetirementAge();
        public FutureValuationOption pFutureValuationOption = new FutureValuationOption();
        public FundingInformation_UK pFundingInformation_UK = new FundingInformation_UK();
        public DataSummaryFields pDataSummaryFields = new DataSummaryFields();
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
        public void test_UK003_CN()
        {

 

            #region MultiThreads

            Thread thrd_Valuation2011_Baseline = new Thread(() => new UK003_CN().t_CompareRpt_Valuation2011_Baseline(sOutputFunding_Valuation2011_Baseline));
            Thread thrd_Valuation2014_Baseline = new Thread(() => new UK003_CN().t_CompareRpt_Valuation2014_Baseline(sOutputFunding_Valuation2014_Baseline));
            Thread thrd_Valuation2014_FVGrowthPCT = new Thread(() => new UK003_CN().t_CompareRpt_Valuation2014_FVGrowthPCT(sOutputFunding_Valuation2014_FVGrowthPCT));
          
            #endregion


            this.GenerateReportOuputDir();


            #region Create client

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
            dic.Add("ClientCode", "TESTUK");
            dic.Add("FiscalYearEnd", "03/31");
            dic.Add("MeasurementDate", "04/01");
            dic.Add("Notes", "UK_Test_Wigan"
                + Environment.NewLine + "UK Test - West Ham"
                + Environment.NewLine + "Date Created:" + _gLib._ReturnDateStampYYYYMMDD()
                + Environment.NewLine + Environment.NewLine + "BENCHMARK DO NOT TOUCH ");
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
            dic.Add("Country", "United Kingdom");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanName", Config.sPlanName);
            dic.Add("PlanYearBegin", "04/01");
            dic.Add("PSOReferenceNumber", "");
            dic.Add("SCON", "");
            dic.Add("TaxRegistrationStatus", "");
            dic.Add("FRS17", "");
            dic.Add("FAS87", "");
            dic.Add("IAS19", "");
            dic.Add("Works", "");
            dic.Add("Staff", "");
            dic.Add("Execs", "");
            dic.Add("PublicSectorProjection", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan_UK(dic);


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Mannual Steps", "click Plan name " + Config.sClientName + "==>>" + Config.sPlanName + " in left Tree View");

            dic.Clear();
            dic.Add("EnterShortName", "AllMembers");
            dic.Add("ConfirmShortName", "AllMembers");
            dic.Add("LongName", "AllMembers");
            pMain._ts_CreateNewBenefitSet(dic);


            dic.Clear();
            dic.Add("EnterShortName", "GroupA");
            dic.Add("ConfirmShortName", "GroupA");
            dic.Add("LongName", "GroupA");
            pMain._ts_CreateNewBenefitSet(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Data2011

            pMain._SelectTab("Home");

            dic.Clear();
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
            dic.Add("Name", "2011 Data");
            dic.Add("EffectiveDate", "01/04/2011");
            dic.Add("Parent", "");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "True");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "2011 Data");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("2011 Data");


            dic.Clear();
            dic.Add("Level_1", "2011 Data");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK003\UK Benchmark 003 - split into 2 benefit sets.xls");
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
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "BasicPay");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "3");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_Pre90XS");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_9094XS");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_9497XS");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_Pre90GMP");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_9094GMP");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AccBen1_9497GMP");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "BARBFRAC");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "8");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "GMPFRAC");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "9");
            dic.Add("DecimalPlaces", "8");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "AddPen");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "2");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "DateJoinedStaff");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "DateTime");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "DB Information");
            dic.Add("Label", "GREVRATE");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "13");
            dic.Add("DecimalPlaces", "4");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, true);



            dic.Clear();
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "2011Data file");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "UKBenchmark003splitinto2benefitsets.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Validate && Load");

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
            dic.Add("Unique_NoMatch_Num", "71");
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
            dic.Add("Level_1", "2011 Data");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "BasicPay");
            dic.Add("Level_5", "BasicPayPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            pData._TreeViewSelect_Snapshots(dic, true);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2011 in 2 benefit sets");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Valuation2011 - ParticipantData


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
            dic.Add("Name", "Valuation 2011");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearEndingIn_DE", "2011");
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
            dic.Add("ServiceToOpen", "Valuation 2011");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2011");


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
            dic.Add("SnapshotName", "2011 in 2 benefit sets");
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


            #endregion


            #region Funding - Valuation2011 - Assumptions & Provisions

            pMain._SelectTab("Valuation 2011");

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
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Funding");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.1");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.1");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.2");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.2");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.3");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.3");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            pAssumptions._Collapse(dic);


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
            dic.Add("txtRate", "3.4");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayIncrease");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "Funding");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.4");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "AltFund1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "1.1");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "AltFund2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2.2");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "AltFund3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3.3");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            pAssumptions._Collapse(dic);


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
            dic.Add("RPIRate_txt", "3.4");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "3.4");
            dic.Add("S148Inc_txt", "4.4");
            dic.Add("LimmGMPRate_txt", "4.4");
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


            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2011");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "4.4");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "4.7");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3.9");
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
            dic.Add("CPIRate_txt", "3.9");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "");
            dic.Add("RPIRate_P", "Click");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "");
            dic.Add("RPIRate_txt", "3.9");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);

            //// redo 
            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CPIRate_V", "");
            dic.Add("CPIRate_P", "Click");
            dic.Add("CPIRate_T", "");
            dic.Add("CPIRate_cbo_V", "");
            dic.Add("CPIRate_txt", "3.9");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "");
            dic.Add("RPIRate_P", "Click");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "");
            dic.Add("RPIRate_txt", "3.9");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


            ////////////////////_gLib._MsgBox("", "please check the value of <CPI> and <RPI> is <3.9>");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("SalCapInc_P", "Click");
            dic.Add("S148Inc_P", "Click");
            dic.Add("LimmGMPRate_P", "Click");
            dic.Add("SalCapInc_txt", "3.9");
            dic.Add("S148Inc_txt", "3.9");
            dic.Add("LimmGMPRate_txt", "3.6");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMethods._SelectTab("PPF S179");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2011");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2011");


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
            pAssumptions._TreeViewRightSelect(dic, "PensionableService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PensionableService");
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
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "24");
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
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "24");
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
            dic.Add("RoundingRule", "");
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
            dic.Add("MaximumService_UseServiceCap", "75");
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
            dic.Add("Level_3", "PensionableService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "Staffmembers");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PensionableService");
            dic.Add("Level_4", "Staffmembers");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "24");
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
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "24");
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
            dic.Add("RoundingRule", "");
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
            dic.Add("MaximumService_UseServiceCap", "75");
            dic.Add("FixedDate_UseServiceCap", "");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.DivisionCode=\"1\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PensionableService");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "RobsonService");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "PensionableService");
            dic.Add("Level_4", "RobsonService");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceAtValuationDate", "");
            dic.Add("RulesBasedService", "");
            dic.Add("CustomCode", "");
            dic.Add("UseServiceCa", "true");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "24");
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
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_V", "");
            dic.Add("ServiceStarts_C", "click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "24");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "HireDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "65");
            dic.Add("ServiceEnds_FixedDate", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("ProvidedInDataField", "");
            dic.Add("ServiceEndsAt_V", "");
            dic.Add("ServiceEndsAt_C", "");
            dic.Add("ServiceEndsAt_cbo", "");
            dic.Add("ServiceEndsAt_txt", "");
            dic.Add("MaximumService_UseServiceCap", "75");
            dic.Add("FixedDate_UseServiceCap", "");
            dic.Add("Date_UseServiceCap", "");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncrement_V", "");
            dic.Add("ServiceIncrement_C", "");
            dic.Add("ServiceIncrement_cbo", "");
            dic.Add("ServiceIncrement_txt", "");
            pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.DivisionCode=\"4\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post06Service");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post06Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "24");
            dic.Add("ServiceStarts_FixedDate", "06/04/2006");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "click");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "1.0");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post97Service");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post97Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IRUK", "True");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "06/04/1997");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post94Service");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post94Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "01/07/1994");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Post90Service");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Post90Service");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "click");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "17/05/1990");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Service9706");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Service9706");
            dic.Add("Level_4", "Default");
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
            dic.Add("Function", "$Post97Service - $Post06Service");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Service9497");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Service9497");
            dic.Add("Level_4", "Default");
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
            dic.Add("Function", "$Post94Service - $Post97Service");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Service9094");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Service9094");
            dic.Add("Level_4", "Default");
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
            dic.Add("Function", "$Post90Service - $Post94Service");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Pre90Service");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Pre90Service");
            dic.Add("Level_4", "Default");
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
            dic.Add("Function", "$PensionableService - $Post90Service");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Service");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Under65");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Under65");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$Age < 65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Staff");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Staff");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.DivisionCode = \"1\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Works");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Works");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.DivisionCode = \"2\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Robson");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Robson");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.DivisionCode = \"4\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Females");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Females");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.Gender = \"F\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "BasicPayProjected");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "BasicPayProjected");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "true");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "true");
            dic.Add("LegislatedPayLimitDefinition", "true");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "BasicPay");
            dic.Add("PayIncreaseAssumption", "PayIncrease");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);


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
            dic.Add("ApplyeDeductionBeforeAveraging", "False");
            dic.Add("AdjustmentPeriod", "");
            dic.Add("ApplyLegislatedSalaryCap", "false");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "false");
            pPayAverage._PopVerify_Main_UK(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "BasicPayProjected");
            dic.Add("AveragingMethod", "M consecutive out of last N years");
            dic.Add("M", "3");
            dic.Add("N", "13");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "6");
            dic.Add("AdjustmentMethod", "");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Assumptions");

            pMethods._SelectTab("Funding");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "PA92MC");
            dic.Add("Mortality_Setback_M", "1");
            dic.Add("Mortality_Setback_F", "1");
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
            dic.Add("cboPreDefinedEligibility", "Under65");
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
            dic.Add("MenuItem", "Use Alternative Basis Folders");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "WithDrawal Decrement");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM01");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "WithDrawal Decrement");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM02");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "WithDrawal Decrement");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM03");
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
            dic.Add("Active_Service", "PensionableService");
            dic.Add("Deferred_Service", "PensionableService");
            dic.Add("Deferred_ApplyTrancheSplits", "");
            dic.Add("Pensioner_Service", "PensionableService");
            dic.Add("Pensioner_ApplyTrancheSplits", "");
            pTrancheDefinition._PopVerify_Main(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pre90");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "");
            dic.Add("EndDate", "16/05/1990");
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
            dic.Add("Active_FemalePPF_txt", "60");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "65");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

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
            dic.Add("Def_FemalePPF_txt", "60");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "65");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst90Pre94");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "17/05/1990");
            dic.Add("EndDate", "30/06/1994");
            dic.Add("GMPApplies", "true");

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
            dic.Add("Active_MalePPF_txt", "60");
            dic.Add("Active_FemalePPF_cbo", "");
            dic.Add("Active_FemalePPF_txt", "60");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "60");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

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
            dic.Add("Def_MalePPF_txt", "60");
            dic.Add("Def_FemalePPF_cbo", "");
            dic.Add("Def_FemalePPF_txt", "60");
            dic.Add("Def_MaleSolvency_cbo", "");
            dic.Add("Def_MaleSolvency_txt", "60");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst94Pre97");
            dic.Add("Actives", "True");
            dic.Add("Deferred", "True");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "01/07/1994");
            dic.Add("EndDate", "05/04/1997");
            dic.Add("GMPApplies", "true");

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
            dic.Add("Active_MaleSolvency_txt", "60");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

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
            dic.Add("Def_MaleSolvency_txt", "60");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");
            dic.Add("OK", "Click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pre97");
            dic.Add("Actives", "false");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "True");
            dic.Add("StartDate", "");
            dic.Add("EndDate", "05/04/1997");
            dic.Add("GMPApplies", "true");

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
            dic.Add("Pen_MaleSolvency_txt", "60");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst97Pre06");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "06/04/1997");
            dic.Add("EndDate", "05/04/2006");
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
            dic.Add("Active_MaleSolvency_txt", "60");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

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
            dic.Add("Def_MaleSolvency_txt", "60");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");

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
            dic.Add("Pen_MaleSolvency_txt", "60");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst06Pre09");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "06/04/2006");
            dic.Add("EndDate", "05/04/2009");
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
            dic.Add("Active_MaleSolvency_txt", "60");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

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
            dic.Add("Def_MaleSolvency_txt", "60");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst09");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "06/04/2009");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "");

            dic.Add("Active_PPFTranche", "Pst2009");
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
            dic.Add("Active_MaleSolvency_txt", "60");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "60");

            dic.Add("Def_PPFTranche", "Pst2009");
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
            dic.Add("Def_MaleSolvency_txt", "60");
            dic.Add("Def_FemaleSolvency_cbo", "");
            dic.Add("Def_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst06");
            dic.Add("Actives", "false");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "06/04/2006");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "");

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
            dic.Add("Pen_MaleSolvency_txt", "60");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "LRF");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "(1.741) / (((1-$emp.GMPFRAC)* (1+$Inflation_RPI)+$emp.GMPFRAC *$emp.GREVRATE)^5)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pre90Pension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pre90Pension");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pre90_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pre90Pension");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pre90Pension");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pre90_Service");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
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
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pension9094");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9094");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst90Pre94_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9094");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9094");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst90Pre94_Service");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
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
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pension9497");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9497");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst94Pre97_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9497");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9497");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst94Pre97_Service");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
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
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pension9706");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9706");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst97Pre06_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9706");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9706");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst97Pre06_Service");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
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
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Pension0609");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension0609");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst06Pre09_Service");
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
            dic.Add("Level_5", "Pension0609");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension0609");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst06Pre09_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Works");
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
            dic.Add("Level_4", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "PensionPost09");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "PensionPost09");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst09_Service");
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
            dic.Add("Level_5", "PensionPost09");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "PensionPost09");
            dic.Add("Level_6", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst09_Service");
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

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.0125");


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Works");
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
            dic.Add("Level_4", "FAE Formula");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "PastEEconts");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "PastEEconts");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "click");
            dic.Add("StartingBalance_C", "");
            dic.Add("StartingBalance_cbo", "ContribsWInterest1");
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
            dic.Add("ProjectedPay", "BasicPayProjected");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "FutureEEConts");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "FutureEEConts");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "");
            dic.Add("StartingBalance_C", "click");
            dic.Add("StartingBalance_cbo", "");
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
            dic.Add("ProjectedPay", "BasicPayProjected");
            dic.Add("Service", "");
            dic.Add("RatesTiersBasedOn", "");
            dic.Add("IntegrationType", "");
            pEmployeeContributionsFormula._PopVerify_EmployeeContributionsFormula(dic);


            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.05");



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DeferredPre90");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DeferredPre90");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_Pre90XS * 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Deferred9094");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Deferred9094");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_9094XS * 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Deferred9497");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Deferred9497");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_9497XS * 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Deferred9706");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Deferred9706");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_Post97PreA * 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Deferred0609");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Deferred0609");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccBen1_PostAPre09 * 1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Pension9497ADDPEN");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Pension9497ADDPEN");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AddPen + $Pension9497");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "PensionPre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "PensionPre97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Pre90Pension +$Pension9094*1.403771037 +$Pension9497ADDPEN");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DeferredPre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DeferredPre97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "($emp.GMPPre88 +$emp.GMPPost88 +$emp.AccBen1_XSNonRev +$emp.AccBen1_XSRev) *(($emp.BARBFRAC * $LRF) +(1 -$emp.BARBFRAC))");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpousesDeferredPre97");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesDeferredPre97");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$DeferredPre97 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpousesDef9706");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesDef9706");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Deferred9706 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpousesDefPost06");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesDefPost06");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Deferred0609 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "SpousesPre90");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "SpousesPre90");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$DeferredPre90 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Spouses9094");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Spouses9094");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Deferred9094 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Spouses9497");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Spouses9497");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Deferred9497 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


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
            pAssumptions._TreeViewRightSelect(dic, "Pre97Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pre97Increase");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "31/03/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pre97Increase");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pre97Increase");
            dic.Add("Level_5", "NewSubGroup1");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "31/03/2008");
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


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Pst97Pre06Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pst97Pre06Increase");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "31/03/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "click");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "InflationAssump");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Post06Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Post06Increase");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "31/03/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "click");
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
            dic.Add("Level_4", "Post06Increase");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Post06Increase");
            dic.Add("Level_5", "NewSubGroup1");
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
            dic.Add("Revaluation_Rate_V_cbo", "InflationAssump");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Increase_Starts_YearsFrom", "");
            dic.Add("Increase_Starts_Date_V", "");
            dic.Add("Increase_Starts_Date_D", "click");
            dic.Add("Increase_Starts_Date_V_cbo", "");
            dic.Add("Increase_Starts_Date_D_txt", "31/03/2008");
            dic.Add("Increase_Ends_YearsFrom", "");
            dic.Add("Increase_Ends_Date_V", "");
            dic.Add("Increase_Ends_Date_D", "click");
            dic.Add("Increase_Ends_Date_V_cbo", "");
            dic.Add("Increase_Ends_Date_D_txt", "");
            dic.Add("Increase_Amount_Rate_V", "click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "InflationAssump");
            dic.Add("Increase_Amount_Rate_P_txt", "");
            dic.Add("Increase_Amount_Rate_T_cbo", "");
            dic.Add("Increase_Pension", "");
            pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Works");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pre90LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pre90LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pre90LRF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pre90LRF");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.741/(1 + $PayIncrease)^5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Females");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pst90Pre94LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pst90Pre94LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.741/(1+$PayIncrease)^5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "DefPre90");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "DefPre90");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "DefPre90");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "DefPre90");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.741/(1+$Inflation_RPI)^5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Females");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Def9094");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Def9094");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.741/(1+$Inflation_RPI)^5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("MenuItem", "Add GMP Adjustment Factors");
            pAssumptions._TreeViewRightSelect(dic, "GMPAdjustmentFactor");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactor");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Act_FromValuation_S148Increases", "");
            dic.Add("Act_FromValuation_FixedRateAt", "click");
            dic.Add("Act_FromValuation_FixedRateAt_V", "");
            dic.Add("Act_FromValuation_FixedRateAt_D", "click");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "31/03/2008");
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "click");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "31/03/2008");
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
            dic.Add("Increase_Pre88GMP_P", "click");
            dic.Add("Increase_Pre88GMP_T", "");
            dic.Add("Increase_Post88GMP_V", "");
            dic.Add("Increase_Post88GMP_P", "click");
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
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactor");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactor");
            dic.Add("Level_5", "NewSubGroup1");
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
            dic.Add("Act_FromDate_FixedRateAt", "click");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "31/03/2008");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "click");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Staff");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactor");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "GMP Adjustment Factors");
            dic.Add("Level_4", "GMPAdjustmentFactor");
            dic.Add("Level_5", "NewSubGroup1");
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
            dic.Add("Act_FromDate_FixedRateAt", "click");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            dic.Add("Act_FromDate_FixedRateAt_D", "click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromDate_FixedRateAt_D_txt", "31/03/2008");
            dic.Add("Inact_S148Increases", "");
            dic.Add("Inact_FixedRateAtDateOfLeaving", "");
            dic.Add("Inact_FixedRateAt", "");
            dic.Add("Inact_FixedDateAt_V", "");
            dic.Add("Inact_FixedDateAt_D", "click");
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
            dic.Add("Increase_Pre88GMP_P_txt", "");
            dic.Add("Increase_Pre88GMP_T_cbo", "");
            dic.Add("Increase_Post88GMP_V_cbo", "");
            dic.Add("Increase_Post88GMP_P_txt", "3.0");
            dic.Add("Increase_Post88GMP_T_cbo", "");
            pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Works");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "MembersPension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "MembersPension");
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
            pAssumptions._TreeViewRightSelect(dic, "LumpSum");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "LumpSum");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Lump sum");
            dic.Add("MortalityInReferralPeriod", "");
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
            dic.Add("MortalityInReferralPeriod", "Interest only");
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

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "SpousesProportion");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "SpousesProportion");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "");
            dic.Add("LoadingFactor_C", "Click");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "");
            dic.Add("LoadingFactor_txt", "0.5");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "DefPre90LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "DefPre90LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "DefPre90");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Def9094LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "Def9094LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "Def9094");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActivesMembers");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActivesMembers");
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
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pre90Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9094");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre94LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9497ADDPEN");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9706");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97Pre06Increase");
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension0609");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "6");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            pMain._Home_ToolbarClick_Top(true);




            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActivesSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActivesSpouse");
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
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pre90Pension");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9094");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre94LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9497");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension9706");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97Pre06Increase");
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "Pension0609");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "6");
            dic.Add("iCol_Total", "6");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "SpousesProportion");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            pMain._Home_ToolbarClick_Top(true);



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
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "AccBen1_Pre90XS");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "DefPre90LRF");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "AccBen1_9094XS");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "Def9094LRF");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "AccBen1_9497XS");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post97PreA");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97Pre06Increase");
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("BaseAmountRevaluing", "AccBen1_PostAPre09");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "6");
            dic.Add("BaseAmountRevaluing", "AccBen1_Post09");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "66.6667%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpousePst");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpousePst");
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
            dic.Add("BaseAmountRevaluing", "SpousesPre90");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "DefPre90LRF");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Spouses9094");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "Def9094LRF");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "Pension9497");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "SpousesDef9706");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97Pre06Increase");
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("BaseAmountRevaluing", "SpousesDefPost06");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "6");
            dic.Add("BaseAmountRevaluing", "#1#");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "66.6667%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "PensionerMembers");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionerMembers");
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
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
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
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
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
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            pMain._Home_ToolbarClick_Top(true);



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
            dic.Add("BaseAmount", "Ben1Ben1_Pre97");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
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
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "Ben1Ben1_PostAPre09");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpousePre");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpousePre");
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
            dic.Add("BaseAmountRevaluing", "SpousesPre90");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Spouses9094");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "Pension9497");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre97Increase");
            dic.Add("IncreasesInPayment", "Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "SpousesDef9706");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pst97Pre06Increase");
            dic.Add("IncreasesInPayment", "Pst97Pre06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("BaseAmountRevaluing", "SpousesDefPost06");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post06Increase");
            dic.Add("IncreasesInPayment", "Post06Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "6");
            dic.Add("BaseAmountRevaluing", "#1#");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "");
            dic.Add("IncreasesInPayment", "");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "66.6667%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            pAssumptions._Collapse(dic);



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
            dic.Add("TranchedBenefit", "ActivesMembers");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
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
            dic.Add("TranchedBenefit", "ActivesSpouse");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Retirement");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Ret_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_Ret_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredMembers");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "DefMbrPen");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_Ret_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_Ret_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpousePst");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "DefSdarPen");
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
            dic.Add("TranchedBenefit", "PensionerMembers");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "PenMbrPen");
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
            dic.Add("TranchedBenefit", "PensionerSpouse");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "PenSdarPen");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Deferred_DID_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Deferred_DID_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpousePre");
            dic.Add("FormOfPayment", "SpousesDID");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "DefSpsDID");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_Wth_Member");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_Wth_Member");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActivesMembers");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "ActWthMbrPen");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_Wth_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_Wth_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActivesSpouse");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "ActWthSdarPen");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ROCPast");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ROCPast");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "PastEEconts");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "65");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Death");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "LumpSum");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "ROCFuture");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "ROCFuture");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "");
            dic.Add("ParticipantType", "");
            dic.Add("NonTranchedBenefit", "FutureEEConts");
            dic.Add("DefineAccruedBenefitAsZero", "true");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "click");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "click");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "65");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "LumpSum");
            dic.Add("Decrement", "Death");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "LumpSum");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("MenuItem", "Copy Benefit Set From");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Client", Config.sClientName);
            dic.Add("Plan", Config.sPlanName);
            dic.Add("ServiceType", "");
            dic.Add("ServiceInstance", "");
            dic.Add("ValuationNode", "");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("OK", "Click");
            pMain._PopVerify_CopyProvisionSet_UK(dic);

            #endregion


            #region Funding - Valuation2011 - Methods

            pMain._SelectTab("Valuation 2011");

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
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "false");
            dic.Add("btnStartAge_V", "");
            dic.Add("StartAge_cbo", "");
            dic.Add("btnStartAge_C", "");
            dic.Add("StartAge_txt", "");
            dic.Add("UsePresentValueOfFutureSalary", "");
            dic.Add("UsePresentValueOfFutureService", "");
            dic.Add("ProjectedPayToUseForCoveredPay", "");
            dic.Add("AccumulationToUseForExpected", "");
            dic.Add("IncludePVFutureSalaryService", "");
            dic.Add("btnStopPVFuture_V", "");
            dic.Add("StopPVFuture_cbo", "");
            dic.Add("btnStopPVFuture_C", "");
            dic.Add("StopPVFuture_txt", "");
            dic.Add("BeginningOfTheYearPVFuture", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            pMethods._PopVerify_Methods(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "GMPAdjustmentFactor");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GMPAdjustmentsToUse_AddRow", "Click");
            dic.Add("GMPAdjustmentsToUse_DeleteRow", "");
            dic.Add("AdditionalCalcRequest_AddRow", "");
            dic.Add("AdditionalCalcRequest_DeleteRow", "");
            pMethods_UK._PopVerify_Methods(dic);



            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("GMPAdjustment", "GMPAdjustmentFactor");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PayProjection", "BasicPayProjected");
            dic.Add("EmployeeContribution", "FutureEEConts");
            dic.Add("StopPVFuture", "$FullRetAge");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("GMPAdjustmentsToUse_AddRow", "");
            dic.Add("GMPAdjustmentsToUse_DeleteRow", "");
            dic.Add("AdditionalCalcRequest_AddRow", "Click");
            dic.Add("AdditionalCalcRequest_DeleteRow", "");
            pMethods_UK._PopVerify_Methods(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("PayProjection", "BasicPayProjected");
            dic.Add("EmployeeContribution", "FutureEEConts");
            dic.Add("StopPVFuture", "$FullRetAge");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Fudning - Valuation2011 - Test Case & Reports

            pMain._SelectTab("Valuation 2011");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"02/15/1943\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate = \"04/22/1951\" and $emp.HireDate1 = \"7/18/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);



            pMain._SelectTab("Valuation 2011");

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
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
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

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Valuation 2011");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2011_Baseline, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Detailed Results", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Individual Output", "Conversion", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_Valuation2011_Baseline, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Detailed Results", "Conversion", false, true);

                ////////////  XLS report <Detailed Results with Ben Type splits> only works in Win7 machine.   NT 6.1 means win7
                ////if (Environment.OSVersion.ToString().Contains("NT 6.1"))
                ////    pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Detailed Results with Ben Type splits", "Conversion", false, true);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2011_Baseline, "Payout Projection - Other Info", "Conversion", false, true);

            }

            thrd_Valuation2011_Baseline.Start();

            pMain._SelectTab("Valuation 2011");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region  Data2014


            pMain._SelectTab("Home");

            dic.Clear();
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
            dic.Add("Name", "2014 Data");
            dic.Add("EffectiveDate", "01/04/2014");
            dic.Add("Parent", "2011 Data");
            dic.Add("RSC", "");
            dic.Add("Shared", "");
            dic.Add("GeneralUse", "");
            dic.Add("Conversion", "");
            dic.Add("CopyDataService", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_DataServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "2014 Data");
            pMain._PopVerify_Home_RightPane(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("2014 Data");


            dic.Clear();
            dic.Add("Level_1", "2014 Data");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK003\UK Benchmark 003 - split into 2 benefit sets ROLL Forward 3 Years.xls");
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
            dic.Add("Level_1", "2014 Data");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);


            ////////pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Work Fields");
            dic.Add("Label", "tempHolder");
            dic.Add("DisplayName", "");
            dic.Add("HistoryLabels", "");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "Decimal");
            dic.Add("FieldLength", "15");
            dic.Add("DecimalPlaces", "6");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);



            dic.Clear();
            dic.Add("Level_1", "2014 Data");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "2011data file");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "2014 data file");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "UKBenchmark003splitinto2benefitsetsROLLForward3Years.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);



            pData._SelectTab("Validate && Load");

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
            dic.Add("Unique_NoMatch", "4");
            dic.Add("Unique_UniqueMatch", "69");
            dic.Add("Unique_MultipleMatches", "");
            dic.Add("Duplicate_NoMatch", "");
            dic.Add("Duplicate_UniqueMatch", "");
            dic.Add("Duplicate_MultipleMatches", "");
            dic.Add("Warehouse_NoMatch", "2");
            dic.Add("AcceptAllRecordsAs_What", "");
            dic.Add("AcceptSelectedRecordsAs_What", "");
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

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "2014 Data");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "fix pay");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("SingleTabPerRecordFile_cbo", "");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "UKBenchmark003splitinto2benefitsetsROLLForward3Years.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);


            pData._SelectTab("Mapping");


            pData._IP_Mapping_Initialize("Personal Information", "Work Fields", 1, 0, 1, "tempHolder");

            pData._IP_Mapping_MapField("tempHolder", "BasicPayCurrentYear", 0, true);


            pData._SelectTab("Validate && Load");

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
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            ////////////////////////////////// oParam.Add "LoadStatus" , "STAGED"


            pData._SelectTab("Pre Matching Derivations");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Add", "Click");
            pData._PopVerify_DerivationGroups(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Apply", "");
            dic.Add("DerivedField", "BasicPayCurrentYear");
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
            dic.Add("Level_2", "Work Fields");
            dic.Add("Level_3", "tempHolder");
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
            dic.Add("Formula", "=E2");
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
            dic.Add("Unique_NoMatch_Num", "");
            dic.Add("Unique_UniqueMatch_Num", "73");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "0");
            dic.Add("Duplicate_UniqueMatch_Num", "0");
            dic.Add("Duplicate_MultipleMatches_Num", "0");
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
            dic.Add("Level_1", "2014 Data");
            dic.Add("Level_2", "Snapshots");
            dic.Add("Level_3", "2011 in 2 benefit sets");
            pData._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "BasicPay");
            dic.Add("Level_5", "BasicPayPriorYear3");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2014 in 2 benefit sets");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            ////////////_gLib._MsgBox("", "Please verify the preview records is 75 then click OK to go on testing, otherwise you should stop to check the snapshot");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "2014 Data");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "BasicPay");
            dic.Add("Level_5", "BasicPayPriorYear4");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "BasicPay");
            dic.Add("Level_5", "BasicPayPriorYear5");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "Pay");
            dic.Add("Level_4", "BasicPay");
            dic.Add("Level_5", "BasicPayPriorYear6");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Beneficiary Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DB Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            pData._TreeViewSelect_Snapshots(dic, true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2014 in 2 benefit sets_fix pay");
            dic.Add("Filter", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "Click");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Assets2011

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("WorkspaceName", "2011Assets");
            pMain._Assets_AddWorkSpace(dic);


            pMain._SelectTab("2011Assets");


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/04/2010");
            dic.Add("TrustPeriodEndDate", "31/03/2011");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "");
            dic.Add("Unaudited", "True");
            dic.Add("Piror2YearsOfNHCE", "");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Fixed Interest - UK Public Sector");
            dic.Add("Value", "889,600.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Public Sector");
            dic.Add("Value", "823,500.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Fixed Interest - UK Other");
            dic.Add("Value", "372,500.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Other");
            dic.Add("Value", "256,500.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "5");
            dic.Add("sAssetCategory", "Equities - UK");
            dic.Add("Value", "895,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "6");
            dic.Add("sAssetCategory", "Equities - Overseas");
            dic.Add("Value", "960,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "7");
            dic.Add("sAssetCategory", "Index Linked - UK");
            dic.Add("Value", "654,890.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "8");
            dic.Add("sAssetCategory", "Index Linked - Overseas");
            dic.Add("Value", "243,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "9");
            dic.Add("sAssetCategory", "Cash Deposits");
            dic.Add("Value", "600,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "10");
            dic.Add("sAssetCategory", "AVC Investments");
            dic.Add("Value", "325,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "11");
            dic.Add("sAssetCategory", "Taxable Recoverable");
            dic.Add("Value", "736,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "12");
            dic.Add("sAssetCategory", "Property");
            dic.Add("Value", "626,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "13");
            dic.Add("sAssetCategory", "Net Current Assets");
            dic.Add("Value", "525,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Reconciliation of Market Value");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "7,600,000.00");
            dic.Add("Contributions_Employer_Itemize", "Click");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Normal - regular");
            dic.Add("Amount", "123,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Special");
            dic.Add("Amount", "235,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Category", "Augmentations");
            dic.Add("Amount", "860,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Category", "Group Life");
            dic.Add("Amount", "250,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Category", "Normal - deficit");
            dic.Add("Amount", "230,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Augmentations");
            dic.Add("Amount", "0.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "AVCs");
            dic.Add("Amount", "325,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "click");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Group");
            dic.Add("Amount", "5,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "Individual Participant");
            dic.Add("Amount", "10,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "Click");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Lump sums on death in retirement");
            dic.Add("Amount", "200,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "Commutation and lump sums on retirement");
            dic.Add("Amount", "100,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Category", "Purchase of annuities");
            dic.Add("Amount", "300,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Category", "Pensions");
            dic.Add("Amount", "500,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Category", "Lump sums on death in service");
            dic.Add("Amount", "13,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "Click");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");

            dic.Add("MV_Adjustment", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");

            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Payments to State Scheme");
            dic.Add("Amount", "60,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "click");

            dic.Add("MV_Adjustment", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");

            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Administration");
            dic.Add("Amount", "20,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "Actuarial");
            dic.Add("Amount", "400,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "click");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Investment Management Expenses");
            dic.Add("Amount", "50,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "Change in market value of investments");
            dic.Add("Amount", "70,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Category", "Investment Income");
            dic.Add("Amount", "30,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "-288,010.00");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region Assets2012

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("WorkspaceName", "2012Assets");
            pMain._Assets_AddWorkSpace(dic);


            pMain._SelectTab("2012Assets");

            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/04/2011");
            dic.Add("TrustPeriodEndDate", "31/03/2012");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "");
            dic.Add("Unaudited", "True");
            dic.Add("Piror2YearsOfNHCE", "");
            dic.Add("iSelectAssetSnapshot", "1");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Fixed Interest - UK Public Sector");
            dic.Add("Value", "850,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Public Sector");
            dic.Add("Value", "790,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Fixed Interest - UK Other");
            dic.Add("Value", "390,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Other");
            dic.Add("Value", "285,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "5");
            dic.Add("sAssetCategory", "Equities - UK");
            dic.Add("Value", "890,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "6");
            dic.Add("sAssetCategory", "Equities - Overseas");
            dic.Add("Value", "950,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "7");
            dic.Add("sAssetCategory", "Index Linked - UK");
            dic.Add("Value", "655,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "8");
            dic.Add("sAssetCategory", "Index Linked - Overseas");
            dic.Add("Value", "245,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "9");
            dic.Add("sAssetCategory", "Cash Deposits");
            dic.Add("Value", "700,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "10");
            dic.Add("sAssetCategory", "AVC Investments");
            dic.Add("Value", "515,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "11");
            dic.Add("sAssetCategory", "Taxable Recoverable");
            dic.Add("Value", "725,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "12");
            dic.Add("sAssetCategory", "Property");
            dic.Add("Value", "628,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "13");
            dic.Add("sAssetCategory", "Net Current Assets");
            dic.Add("Value", "550,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Reconciliation of Market Value");
            pAssets._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "Click");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "Group Life");
            dic.Add("Amount", "450,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Category", "Augmentations");
            dic.Add("Amount", "780,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Category", "Normal - regular");
            dic.Add("Amount", "500,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "click");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Category", "AVCs");
            dic.Add("Amount", "190,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "click");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);



            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Group");
            dic.Add("Amount", "20,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "Click");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Claims on term assurance policies");
            dic.Add("Amount", "314,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "Click");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in retirement");
            dic.Add("Amount", "277,329.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Commutation and lump sums on retirement");
            dic.Add("Amount", "453,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Pensions");
            dic.Add("Amount", "600,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in service");
            dic.Add("Amount", "40,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "click");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Refunds");
            dic.Add("Amount", "21,500.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Administration");
            dic.Add("Amount", "125,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Actuarial");
            dic.Add("Amount", "385,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Audit fees");
            dic.Add("Amount", "40,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "Click");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Payment on term insurance policies");
            dic.Add("Amount", "500,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "click");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Change in market value of investments");
            dic.Add("Amount", "453,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "839.00");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region Assets2013

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("WorkspaceName", "2013Assets");
            pMain._Assets_AddWorkSpace(dic);


            pMain._SelectTab("2013Assets");

            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/04/2012");
            dic.Add("TrustPeriodEndDate", "31/03/2013");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "");
            dic.Add("Unaudited", "True");
            dic.Add("Piror2YearsOfNHCE", "");
            dic.Add("iSelectAssetSnapshot", "1");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Fixed Interest - UK Public Sector");
            dic.Add("Value", "900,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Public Sector");
            dic.Add("Value", "800,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Fixed Interest - UK Other");
            dic.Add("Value", "400,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Other");
            dic.Add("Value", "250,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "5");
            dic.Add("sAssetCategory", "Equities - UK");
            dic.Add("Value", "850,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "6");
            dic.Add("sAssetCategory", "Equities - Overseas");
            dic.Add("Value", "980,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "7");
            dic.Add("sAssetCategory", "Index Linked - UK");
            dic.Add("Value", "660,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "8");
            dic.Add("sAssetCategory", "Index Linked - Overseas");
            dic.Add("Value", "260,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "9");
            dic.Add("sAssetCategory", "Cash Deposits");
            dic.Add("Value", "750,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "10");
            dic.Add("sAssetCategory", "AVC Investments");
            dic.Add("Value", "800,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "11");
            dic.Add("sAssetCategory", "Taxable Recoverable");
            dic.Add("Value", "730,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "12");
            dic.Add("sAssetCategory", "Property");
            dic.Add("Value", "650,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "13");
            dic.Add("sAssetCategory", "Net Current Assets");
            dic.Add("Value", "590,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Reconciliation of Market Value");
            pAssets._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "Click");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Normal - regular");
            dic.Add("Amount", "700,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Augmentations");
            dic.Add("Amount", "600,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Group Life");
            dic.Add("Amount", "350,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "Normal - deficit");
            dic.Add("Amount", "250,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "click");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "AVCs");
            dic.Add("Amount", "285,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "click");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Individual Participant");
            dic.Add("Amount", "500,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "Click");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Commutation and lump sums on retirement");
            dic.Add("Amount", "750,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in retirement");
            dic.Add("Amount", "450,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Pensions");
            dic.Add("Amount", "500,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in service");
            dic.Add("Amount", "220,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "click");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Refunds");
            dic.Add("Amount", "15,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "click");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Audit fees");
            dic.Add("Amount", "65,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Administration");
            dic.Add("Amount", "250,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Actuarial");
            dic.Add("Amount", "680,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "click");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Investment Income");
            dic.Add("Amount", "690,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "2,000.00");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion

            #region  Assets2014

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AssetData");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("WorkspaceName", "2014Assets");
            pMain._Assets_AddWorkSpace(dic);


            pMain._SelectTab("2014Assets");

            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "General Information");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TrustPeriodStartDate", "01/04/2013");
            dic.Add("TrustPeriodEndDate", "31/03/2014");
            dic.Add("Restated", "");
            dic.Add("NotRestated", "True");
            dic.Add("Audited", "");
            dic.Add("Unaudited", "True");
            dic.Add("Piror2YearsOfNHCE", "");
            dic.Add("iSelectAssetSnapshot", "1");
            pAssets._PopVerify_GerneralInformation(dic);


            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Summary of Market Value");
            pAssets._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "1");
            dic.Add("sAssetCategory", "Fixed Interest - UK Public Sector");
            dic.Add("Value", "925,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "2");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Public Sector");
            dic.Add("Value", "780,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "3");
            dic.Add("sAssetCategory", "Fixed Interest - UK Other");
            dic.Add("Value", "425,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "4");
            dic.Add("sAssetCategory", "Fixed Interest - Overseas Other");
            dic.Add("Value", "280,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "5");
            dic.Add("sAssetCategory", "Equities - UK");
            dic.Add("Value", "890,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "6");
            dic.Add("sAssetCategory", "Equities - Overseas");
            dic.Add("Value", "990,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "7");
            dic.Add("sAssetCategory", "Index Linked - UK");
            dic.Add("Value", "670,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "8");
            dic.Add("sAssetCategory", "Index Linked - Overseas");
            dic.Add("Value", "280,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "9");
            dic.Add("sAssetCategory", "Cash Deposits");
            dic.Add("Value", "760,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "10");
            dic.Add("sAssetCategory", "AVC Investments");
            dic.Add("Value", "900,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "11");
            dic.Add("sAssetCategory", "Taxable Recoverable");
            dic.Add("Value", "750,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "12");
            dic.Add("sAssetCategory", "Property");
            dic.Add("Value", "660,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);

            dic.Clear();
            dic.Add("iAssetCategory", "13");
            dic.Add("sAssetCategory", "Net Current Assets");
            dic.Add("Value", "710,000.00");
            pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic);



            dic.Clear();
            dic.Add("Level_1", "Data Entry");
            dic.Add("Level_2", "Reconciliation of Market Value");
            pAssets._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "Click");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Normal - regular");
            dic.Add("Amount", "824,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Augmentations");
            dic.Add("Amount", "625,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Normal - deficit");
            dic.Add("Amount", "225,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "Group Life");
            dic.Add("Amount", "345,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "click");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "AVCs");
            dic.Add("Amount", "100,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "click");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Individual Participant");
            dic.Add("Amount", "450,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "click");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Claims on term assurance policies");
            dic.Add("Amount", "577,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "Click");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in retirement");
            dic.Add("Amount", "325,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Purchase of annuities");
            dic.Add("Amount", "265,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("Date", "");
            dic.Add("Category", "Lump sums on death in service");
            dic.Add("Amount", "250,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("Date", "");
            dic.Add("Category", "Commutation and lump sums on retirement");
            dic.Add("Amount", "452,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("Date", "");
            dic.Add("Category", "Pensions");
            dic.Add("Amount", "725,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "click");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Refunds");
            dic.Add("Amount", "25,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "click");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Actuarial");
            dic.Add("Amount", "790,000.00");
            dic.Add("OK", "");
            pAssets._RMV_EmployerContributions_UK(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("Date", "");
            dic.Add("Category", "Administration");
            dic.Add("Amount", "260,000.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "click");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Date", "");
            dic.Add("Category", "Investment Income");
            dic.Add("Amount", "345,750.00");
            dic.Add("OK", "click");
            pAssets._RMV_EmployerContributions_UK(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("Contributions_Other_Itemize", "");
            dic.Add("Transfers_TransfersToPlan_Itemize", "");
            dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
            dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
            dic.Add("Withdrawals_OtherPayments_Itemize", "");
            dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_Expenses_Itemize", "");
            dic.Add("MV_Adjustment", "250.00");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("MVPeriodBegin", "");
            dic.Add("Contributions_Employer_Itemize", "");
            dic.Add("Contributions_Participant_Itemize", "");
            dic.Add("InvestEarnings_Interest", "");
            dic.Add("InvestEarnings_Dividends", "");
            dic.Add("InvestEarnings_Realized", "");
            dic.Add("InvestEarnings_Unrealized", "");
            dic.Add("InvestEarnings_OtherGainLoss", "");
            dic.Add("Disburse_BenefitPayments_Itemize", "");
            dic.Add("Disburse_BenefitPayments", "");
            dic.Add("Disburse_Expenses", "");
            dic.Add("CreateAssetSnapshot", "Click");
            pAssets._PopVerify_ReconciliationOfMarketValue(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("OK", "Click");
            pAssets._PopVerify_AssetSnapshotProperties(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region Funding - Valuation2014_Baseline

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
            dic.Add("ConversionService", "");
            dic.Add("Name", "Valuation 2014");
            dic.Add("Parent", "Valuation 2011");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearEndingIn_DE", "2014");
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
            dic.Add("ServiceToOpen", "Valuation 2014");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("LiabilityValuationDate", "01/04/2014");
            dic.Add("Data_AddNew", "true");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "");
            dic.Add("Assumptions_Name", "");
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
            dic.Add("OK", "click");
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
            dic.Add("SnapshotName", "2014 in 2 benefit sets_fix pay");
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
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "BasicPay");
            dic.Add("Level_4", "BasicPayPriorYear3");
            pParticipantDataSet._Navigate(dic, true, false);


            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "BasicPay");
            dic.Add("Level_4", "BasicPayPriorYear3");
            dic.Add("Data", "[None]");
            dic.Add("bContinueWithoutCollapse", "true");
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


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"10/09/1951\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);


            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"04/01/1946\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data Summary Fields");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Data Summary Fields");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PensionablePay", "BasicPayProjected");
            dic.Add("PensionableService", "PensionableService");
            dic.Add("TransferredinPension", "AddPen");
            dic.Add("AlternatePay1", "BasicPayCurrentYear");
            dic.Add("AlternatePay2", "BasicPayProjected");
            pDataSummaryFields._MemberSummaries_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("PensionablePay", "BasicPayProjected");
            dic.Add("PensionableService", "PensionableService");
            dic.Add("TransferredinPension", "ContribsWInterest1");
            dic.Add("AlternatePay1", "BasicPayCurrentYear");
            dic.Add("AlternatePay2", "BasicPayProjected");
            pDataSummaryFields._MemberSummaries_Actives(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("DeferredPension", "Deferred_Ret_Member");
            dic.Add("PensionableService", "");
            dic.Add("TransferredinPension", "AccruedBenefit1");
            pDataSummaryFields._MemberSummaries_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("DeferredPension", "Deferred_Ret_Member");
            dic.Add("PensionableService", "");
            dic.Add("TransferredinPension", "AccruedBenefit1");
            pDataSummaryFields._MemberSummaries_Deferreds(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("InsuredPen", "Pensioner_Member");
            dic.Add("InsuredSpousePen", "Pensioner_Spouse");
            dic.Add("FundedPen", "Pensioner_Member");
            dic.Add("FundedSpousePen", "Pensioner_Spouse");
            pDataSummaryFields._MemberSummaries_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("InsuredPen", "Pensioner_Member");
            dic.Add("InsuredSpousePen", "Pensioner_Spouse");
            dic.Add("FundedPen", "Pensioner_Member");
            dic.Add("FundedSpousePen", "Pensioner_Spouse");
            pDataSummaryFields._MemberSummaries_Pensions(dic);


            pDataSummaryFields._SelectTab("Benefit Splits");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("AccruedPension", "Active_Ret_Member");
            dic.Add("OtherPension1", "ROCFuture");
            dic.Add("OtherPension2", "ROCPast");
            dic.Add("OtherPension3", "");
            pDataSummaryFields._BenefitSplits_ActivesPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("AccruedPension", "Active_Ret_Member");
            dic.Add("OtherPension1", "ROCFuture");
            dic.Add("OtherPension2", "ROCPast");
            dic.Add("OtherPension3", "ROCPast");
            pDataSummaryFields._BenefitSplits_ActivesPensionSplits(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("GL_FundingLiabilities", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "DivisionCode");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
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

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Test Cases", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Status Reconciliation", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Member Statistics", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Age Service Matrix", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Output", "RollForward", true, true);
            }



            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Detailed Results", "RollForward", false, true);

                ////////  XLS report <Detailed Results with Ben Type splits> only works in Win7 machine.   NT 6.1 means win7
                ////if (Environment.OSVersion.ToString().Contains("NT 6.1"))
                ////    pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Detailed Results with Ben Type splits", "RollForward", false, true);

                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Payout Projection - Benefit Cashflows", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_Baseline, "Payout Projection - Other Info", "RollForward", false, true);

            }

            thrd_Valuation2014_Baseline.Start();


            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);


            #endregion


            #region  Funding - Valuation2014_FV GrowthPCT

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "FV GrowthPCT");
            dic.Add("LiabilityValuationDate", "01/04/2014");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "FV GrowthPCT Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "");
            dic.Add("MethodsLiabilities_Name", "");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "true");
            dic.Add("Provisions_Name", "New nontranche plan defs");
            dic.Add("Provisions_Edit", "");
            dic.Add("FundingInformation_AddNew", "");
            dic.Add("FundingInformation_Name", "");
            dic.Add("FundingInformation_Edit", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_ValuationNodeProperties(dic);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "5.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "4.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "7.5");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "6.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "AltFund3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "6.75");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.25");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2014");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);


            pMethods._SelectTab("PPF S179");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Month", "end March");
            dic.Add("Year", "2014");
            dic.Add("SolvencyBasis", "");
            pAssumptions._PopVerify_Assmp_Solvency_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "true");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Precommencement_Pre2009_txt", "0.47");
            dic.Add("Precommencement_Post2009_txt", "1.89");
            dic.Add("Postcommencementrate_txt", "4.96");
            pInterestRate._PopVerify_NonPrescribedRates(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("NonPrescribedRates", "true");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Postcommencementrate_txt", "2.44");   //// for common object  Post1997increases_txt
            pInterestRate._PopVerify_NonPrescribedRates(dic);


            pMethods._SelectTab("Projection");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AsOfDate", "");
            dic.Add("ForActuarialEquivalence", "");
            dic.Add("ForwardRate", "");
            dic.Add("SpotRate", "");
            dic.Add("AddRow", "click");
            pInterestRate._PopVerify_TimeBased(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "3.0");
            pPayIncrease._TimeBased_Table(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.0");
            pPayIncrease._TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Inflation");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "0.5");
            pInflation._CPI_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "1.0");
            pInflation._CPI_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "3.0");
            pInflation._RPI_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.0");
            pInflation._RPI_TimeBased_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Economic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "true");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "3.0");
            pOtherEconomicAssumption._SalCapInc_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "4.0");
            pOtherEconomicAssumption._SalCapInc_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "1");
            dic.Add("Rate", "4.0");
            pOtherEconomicAssumption._S148Inc_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "5.0");
            pOtherEconomicAssumption._S148Inc_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "1");
            dic.Add("NumberOfYears", "10");
            dic.Add("Rate", "4.0");
            pOtherEconomicAssumption._LimGMPRate_TimeBased_Table(dic);

            dic.Clear();
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("NumberOfYears", "99");
            dic.Add("Rate", "5.0");
            pOtherEconomicAssumption._LimGMPRate_TimeBased_Table(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Projection same as Funding");
            pAssumptions._TreeViewRightSelect(dic, "");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM01");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Provisions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Provisions");


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "ContribsWInterest1");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac2");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPre88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac3");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "true");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPost88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            pAssumptions._Collapse(dic);




            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac1");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "ContribsWInterest1");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac2");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPre88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac3");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac3");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "false");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("NonTranchedBenefit", "GMPPost88");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Non-Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "NonTrInac4");

            dic.Clear();
            dic.Add("Level_1", "GroupA");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Non-Tranched Benefit Plan Definition");
            dic.Add("Level_4", "NonTrInac4");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPayment", "MembersPension");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "true");
            pPlanDefinition._PopVerify_PlanDefinition(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IncludeThisBenefitInPV", "true");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("NonTranchedBenefit", "Benefit1DB");
            dic.Add("DefineAccruedBenefitAsZero", "");
            dic.Add("FullySalaryRelateBenefit", "");
            dic.Add("BenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_V_cbo", "");
            dic.Add("BenefitCommenceAge_C_txt", "");
            dic.Add("BenefitStopAge_V", "");
            dic.Add("BenefitStopAge_C", "");
            dic.Add("BenefitStopAge_V_cbo", "");
            dic.Add("BenefitStopAge_C_txt", "");
            dic.Add("CostOfLivingAdjustment", "");
            dic.Add("EarlyRetirement", "");
            dic.Add("LateRetirement", "");
            dic.Add("Adjustment", "");
            dic.Add("TransferValue_V", "");
            dic.Add("TransferValue_T", "");
            dic.Add("TransferValue_V_cbo", "");
            dic.Add("TransferValue_T_cbo", "");
            dic.Add("FormOfPayment", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("StartAgeForPost_V", "");
            dic.Add("StartAgeForPost_C", "");
            dic.Add("StartAgeForPost_V_cbo", "");
            dic.Add("StartAgeForPost_C_txt", "");
            dic.Add("MaleSolvencyPaymentAge_V", "");
            dic.Add("MaleSolvencyPaymentAge_C", "");
            dic.Add("MaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("MaleSolvencyPaymentAge_C_txt", "");
            dic.Add("FemaleSolvencyPaymentAge_V", "");
            dic.Add("FemaleSolvencyPaymentAge_C", "");
            dic.Add("FemaleSolvencyPaymentAge_V_cbo", "");
            dic.Add("FemaleSolvencyPaymentAge_C_txt", "");
            pNonTranchedBenefitPlanDefinition._PopVerify_NonTranchedBenefitPlanDefinition(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            pAssumptions._Collapse(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            pAssumptions._Collapse(dic);


            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Data Summary Fields");
            pMain._FlowTreeRightSelect(dic);


            pMain._SelectTab("Data Summary Fields");

            pDataSummaryFields._SelectTab("Benefit Splits");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_DeferredsPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_DeferredsPensionSplits(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("OtherPension1", "NonTrInac1");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_PensionersPensionSplits(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("BenefitSet", "GroupA");
            dic.Add("OtherPension1", "NonTrInac4");
            dic.Add("OtherPension2", "NonTrInac2");
            dic.Add("OtherPension3", "NonTrInac3");
            pDataSummaryFields._BenefitSplits_PensionersPensionSplits(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");



            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Future Valuation Options");
            pMain._FlowTreeRightSelect(dic);


            pFutureValuationOption._SelectTab("Population size");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "Growth rate %");
            dic.Add("iColName", (2014 - 2014 + 2).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRowNum", "1");
            dic.Add("ParticipantGroup", "");
            dic.Add("PopulationSizeOption", "");
            dic.Add("iColName", (2015 - 2014 + 2).ToString());
            dic.Add("iColValue", "10.00");
            pFutureValuationOption._PropulationSize(dic);


            pFutureValuationOption._SelectTab("New entrants");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"03/13/1982\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"05/01/1950\"");
            dic.Add("iResultRow", "1");
            pFutureValuationOption._AddTestCase(dic);


            pFutureValuationOption._SelectTab("Projection years");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EveryYearForTheFirst", "");
            dic.Add("AndEvery", "");
            dic.Add("UpToincludingProjectionYear", "");
            dic.Add("FundingUpdateDate_UK", "01/08/2015");
            pFutureValuationOption._ProjectionYears(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "");
            pFutureValuationOption._PopVerify_OK(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("MenuItem_1", "Asset Snapshots");
            pMain._MenuSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pParticipantDataSet._PopVerify_AssetSnapshot(dic);


            pMain._SelectTab("Valuation 2014");


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
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("PayoutProjectionCustomGroup", "#1#");
            dic.Add("Major", "BenefitSetShortName");
            dic.Add("Intermediate", "Gender");
            dic.Add("Minor", "DivisionCode");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
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

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Population Projection");
            pMain._FlowTreeRightSelect(dic);



            pMain._SelectTab("Valuation 2014");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Proj");



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Future Valuation Liabilities");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayoutProjection", "");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "");
            dic.Add("Pay", "BasicPayPriorYear1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("Funding", "True");
            dic.Add("AltFunding1", "True");
            dic.Add("AltFunding2", "True");
            dic.Add("AltFunding3", "True");
            dic.Add("Solvency", "True");
            dic.Add("PPFS179", "True");
            dic.Add("SelectVOs_AllVOs", "");
            dic.Add("SelectVOs_VO1", "AllMembers");
            dic.Add("SelectVOs_VO2", "GroupA");
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

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);


            pMain._EnterpriseRun("Group Job Successfully Complete", true, "FV Liab");

            pMain._SelectTab("Run Status");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region ValuationProcessControl - VPC 2014

            pMain._SelectTab("Home");


            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "ValuationProcessControl");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "VPC 2014");
            dic.Add("Planyearbegins", "01/04/2014");
            dic.Add("Planyearends", "31/03/2015");
            dic.Add("Valuationdate", "01/04/2014");
            dic.Add("Outsidestudio", "true");
            dic.Add("Fundingservice", "Valuation 2014");
            dic.Add("OK", "click");
            pValuationProcessControl._AddNewService(dic);



            pValuationProcessControl._OpenVPC("VPC 2014");


            pMain._SelectTab("VPC 2014");

            dic.Clear();
            dic.Add("Level_1", "Phase");
            dic.Add("Level_2", "Planning");
            dic.Add("Level_3", "Basis");
            pValuationProcessControl._TreeViewSelect(dic, true);


            _gLib._KillProcessByName("EXCEL");
            MyExcel _excel = new MyExcel(@"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK003\MSVPCheckLists_Planning_0429\Basis_Planning.xlsx", true);
            _excel.OpenExcelFile(1);

            _gLib._MsgBox("", "Please accurately paste values into current system, then close excel");

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ExportCheckListstoExcel", "Click");
            dic.Add("FileName", sOutputFunding_Valuation2014_FVGrowthPCT + "BasicPlanning.zip");
            dic.Add("Save", "click");
            pValuationProcessControl._ExportCheckListstoExcel(dic);

            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - Valuation2014_FV - FundingInformation

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "FundingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Valuation 2014");
            pMain._PopVerify_Home_RightPane(dic);


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Funding Information");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Funding Information");


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "General Parameters");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("VPCServiceContainingBasis", "VPC 2014");
            pFundingInformation_UK._RegularValuation_GeneralParameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Data Movements");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "15");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "2");
            dic.Add("Col2", "1");
            dic.Add("Col3", "3");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "4");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "-4");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-2");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "");
            dic.Add("Col2", "-2");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Col1", "-2");
            dic.Add("Col2", "");
            dic.Add("Col3", "-2");
            pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);


            pFundingInformation_UK._SelectTab("Deferreds");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "16");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "2");
            dic.Add("Col2", "3");
            dic.Add("Col3", "1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "4");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "-2");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-4");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "");
            dic.Add("Col2", "");
            dic.Add("Col3", "-1");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Col1", "-1");
            dic.Add("Col2", "-3");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);


            pFundingInformation_UK._SelectTab("Pensioners");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "45");
            dic.Add("Col2", "");
            dic.Add("Col3", "");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "");
            dic.Add("Col2", "2");
            dic.Add("Col3", "5");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "5");
            dic.Add("Col2", "3");
            dic.Add("Col3", "6");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "3");
            dic.Add("Col2", "2");
            dic.Add("Col3", "3");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Col1", "2");
            dic.Add("Col2", "3");
            dic.Add("Col3", "2");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "-5");
            dic.Add("Col2", "-4");
            dic.Add("Col3", "-5");
            pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Data Summaries");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ThisValuation", "FV GrowthPCT");
            dic.Add("LastValuation", "Baseline");
            pFundingInformation_UK._RegularValuation_DataSummaries(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Assets");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "2014Assets");
            pFundingInformation_UK._RegularValuation_Assets_Snapshot_TableSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("IntervaluationPeriodContribution_Employer", "3.20");
            dic.Add("IntervaluationPeriodContribution_Employee", "");
            dic.Add("IntervaluationPeriodPension_DataAwarded", "02/01/2013");
            pFundingInformation_UK._RegularValuation_Assets(dic);



            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "2.4 %");
            dic.Add("Col2", "3.0 %");
            dic.Add("Col3", "1.3 %");
            pFundingInformation_UK._RegularValuation_Assets_RateofPensionIncrease_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "3.0 %");
            dic.Add("Col2", "2.0 %");
            dic.Add("Col3", "2.5 %");
            pFundingInformation_UK._RegularValuation_Assets_EnvestermentReport(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "5.0 %");
            dic.Add("Col2", "4.0 %");
            dic.Add("Col3", "3.0 %");
            pFundingInformation_UK._RegularValuation_Assets_EnvestermentReport(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Liabilities");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ValuationNode", "Copy of PFVS");
            dic.Add("LiabilityType", "Funding");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund1");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund2");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "AltFund3");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "Funding");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "Solvency");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("LiabilityType", "PPF_S179");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund1");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund2");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("LiabilityType", "AltFund3");
            pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(dic);



            pFundingInformation_UK._SelectTab("FSM Sensitivities");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ImportFSMSensitivities", "click");
            pFundingInformation_UK._RegularValuation_Liabilities_FSMSensitivities(dic);


            pFundingInformation_UK._SelectTab("Miscellaneous Adjustments");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "ActAdj");
            dic.Add("Value_P", "12.00");
            dic.Add("Value_C", "");
            dic.Add("ApplytoPast", "true");
            dic.Add("ApplytoFuture", "true");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "DefAdj");
            dic.Add("Value_C", "2,000");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "PenAdj");
            dic.Add("Value_P", "5.00");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Benefit Splits");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ThisValuation", "FV GrowthPCT");
            dic.Add("LastValuation", "Baseline");
            pFundingInformation_UK._RegularValuation_DataSummaries(dic);



            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Results Summary");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingInsurance_Fixed_rd", "true");
            dic.Add("FundingInsurance_Fixed_txt", "7.00");
            pFundingInformation_UK._RegularValuation_ResultsSummary(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Regular Valuation");
            dic.Add("Level_2", "Reports");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SFOResults", "This Time Val");
            dic.Add("LastTimesResults", "Last Time Val");
            dic.Add("SolvencyResults", "Solvency");
            dic.Add("PPFResults", "PPF");
            dic.Add("Actives", "456,700");
            dic.Add("Deferreds", "233,444");
            dic.Add("Pensioners", "899,900");
            dic.Add("Expenses", "250,000");
            dic.Add("SalaryIncreaseforStayers", "3.0");
            pFundingInformation_UK._RegularValuation_Reports_Liabilities(dic);


            pFundingInformation_UK._SelectTab("Recovery plan");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/04/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/07/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Amount", "245,000");
            dic.Add("Date", "01/10/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Amount", "260,000");
            dic.Add("Date", "01/12/2014");
            pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);



            pFundingInformation_UK._SelectTab("Sensitivities");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Preretiremrnt", "789,000");
            dic.Add("Pstretirement", "765,000");
            dic.Add("Inflation", "24,300");
            dic.Add("SalaryGrowth", "45,000");
            dic.Add("Mortality", "78,699");
            dic.Add("EquityMarkets", "12,500");
            dic.Add("GiltYields", "25,600");
            pFundingInformation_UK._RegularValuation_Reports_Sensitivities(dic);


            pFundingInformation_UK._SelectTab("AOS");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Description", "Expected interest");
            dic.Add("Value", "789,999.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Description", "Excess employer conts");
            dic.Add("Value", "240,000.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Description", "Excess investment return");
            dic.Add("Value", "12,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Description", "Excess salary increases");
            dic.Add("Value", "150,000.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Description", "Excess pension increases");
            dic.Add("Value", "7,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Description", "Benefit changes");
            dic.Add("Value", "2,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Description", "Impact of merger");
            dic.Add("Value", "9,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Description", "Miscellaneous");
            dic.Add("Value", "34,500.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("Description", "Financial conditions");
            dic.Add("Value", "9,800.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("Description", "Change in approach to setting financial assumptions");
            dic.Add("Value", "78,888.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "11");
            dic.Add("Description", "Improved life expectancy");
            dic.Add("Value", "23,333.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "12");
            dic.Add("Description", "Commutation assumptions");
            dic.Add("Value", "89,999.0");
            pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);

            pMain._Home_ToolbarClick_Top(true);


            pFundingInformation_UK._SelectTab("Projections");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingSurplus", "896,000");
            dic.Add("FundingLevel", "4");
            dic.Add("SolvencyShortfall", "33,333");
            dic.Add("Solvencylevel", "3");
            pFundingInformation_UK._RegularValuation_Reports_Projection(dic);


            pFundingInformation_UK._SelectTab("Inv strategy");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Value", "24.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Value", "11.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Value", "15.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Value", "9.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Value", "10.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Value", "12.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Value", "5.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Value", "4.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("AssetCategory", "Taxable Recoverable");
            dic.Add("Value", "6.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_OtherAsset_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("AssetCategory", "Property");
            dic.Add("Value", "4.0");
            pFundingInformation_UK._RegularValuation_Reports_InvStrategy_OtherAsset_Table(dic);


            pFundingInformation_UK._SelectTab("PPF S179 cert");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("NameofSection", "ABC");
            dic.Add("SchemeRegistrationNumber", "111-222-333");
            dic.Add("SchemeAddressLine1", "544 Scheme Address");
            dic.Add("Line2", "Suite 300A");
            dic.Add("Line3", "Scheme Address, IL 60061");
            dic.Add("Line4", "");
            dic.Add("GuidanceUsed", "Gui");
            dic.Add("AssumptionUsed", "GAM");
            dic.Add("ExternalLiabilities", "7,860,000");
            dic.Add("ActivesInsured", "26");
            dic.Add("DeferredsInsured", "46");
            pFundingInformation_UK._RegularValuation_Reports_PPFS179Cert(dic);


            pFundingInformation_UK._SelectTab("General info");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SchemeActuary", "Jane Smiyh");
            dic.Add("ConsultingOfficeAddressLine1", "Mercer");
            dic.Add("Line2", "544 Lakeview Parkway");
            dic.Add("Line3", "Suite 300");
            dic.Add("Line4", "Vernon Hills, IL 60061");
            dic.Add("EmployerName", "ABC company");
            dic.Add("CurrencyUnit", "£ 000's");
            pFundingInformation_UK._RegularValuation_Reports_GeneralInfo(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Liabilities and Assets");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Scenario", "Last Time Val");
            dic.Add("ValuationNode", "Copy of PFVS");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "7,338,990");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Scenario", "Regular Val Funding");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Scenario", "Regular Val PPF (BL)");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "PPF_S179");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Scenario", "Regular Val Solv (BL)");
            dic.Add("ValuationNode", "Baseline");
            dic.Add("ValuationType", "Regular Valuation");
            dic.Add("LiabilityType", "Solvency");
            dic.Add("AssetValue", "7,816,500");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Scenario", "FU Funding");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "Funding");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Scenario", "FU Solv");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "Solvency");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "7");
            dic.Add("Scenario", "FU PPF");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "PPF_S179");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "8");
            dic.Add("Scenario", "FU AltFd1");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund1");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "9");
            dic.Add("Scenario", "FU AltFd2");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund2");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "10");
            dic.Add("Scenario", "FU AltFd3");
            dic.Add("ValuationNode", "FV GrowthPCT");
            dic.Add("ValuationType", "Funding Update");
            dic.Add("LiabilityType", "AltFund3");
            dic.Add("AssetValue", "8,500,000");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);


            pFundingInformation_UK._SelectTab("Adjustment for liability related cashflows");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Col1", "20,000");
            dic.Add("Col2", "11,111");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Col1", "1,000");
            dic.Add("Col2", "1,111");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Col1", "100");
            dic.Add("Col2", "200");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Col1", "450,000");
            dic.Add("Col2", "200,100");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "6");
            dic.Add("Col1", "4.25");
            dic.Add("Col2", "");
            pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);


            pFundingInformation_UK._SelectTab("Miscellaneous Adjustments");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "A1");
            dic.Add("Value_P", "1.0");
            dic.Add("Value_C", "");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "A2");
            dic.Add("Value_C", "10,000");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "A3");
            dic.Add("Value_P", "2.00");
            dic.Add("ApplytoFuture", "false");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "A4");
            dic.Add("Value_P", "3.00");
            dic.Add("Value_ClickC", "");
            dic.Add("ApplytoPast", "false");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "A5");
            dic.Add("Value_C", "-1,000");
            dic.Add("ApplytoPast", "false");
            dic.Add("ApplytoFuture", "false");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "D1");
            dic.Add("Value_P", "1.10");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "D2");
            dic.Add("Value_C", "11,000");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "D3");
            dic.Add("Value_P", "-2.20");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "D4");
            dic.Add("Value_P", "3.30");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "D5");
            dic.Add("Value_C", "-22,000");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("Name", "P1");
            dic.Add("Value_C", "11,100");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("Name", "P2");
            dic.Add("Value_P", "1.11");
            dic.Add("ApplytoPPF", "");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "3");
            dic.Add("Name", "P3");
            dic.Add("Value_P", "-2.22");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "4");
            dic.Add("Name", "P4");
            dic.Add("Value_C", "-22,200");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "5");
            dic.Add("Name", "P5");
            dic.Add("Value_P", "3.33");
            dic.Add("ApplytoPPF", "true");
            pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);


            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Results Summary");
            pFundingInformation._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FundingExpenses_Fixed_rd", "");
            dic.Add("FundingInsurance_Fixed_rd", "");
            dic.Add("Solvency_Fixed_rd", "");
            dic.Add("FundingExpenses_Fixed_txt", "2.50");
            dic.Add("FundingInsurance_Fixed_txt", "");
            dic.Add("Solvency_Fixed_txt", "");
            dic.Add("Actives", "18");
            dic.Add("Deferreds", "13");
            dic.Add("PensionersUnder60", "10");
            dic.Add("Pensioners6069", "26");
            dic.Add("Pensioners7079", "14");
            dic.Add("PensionersOver80", "9");
            pFundingInformation_UK._RegularValuation_ResultsSummary(dic);



            dic.Clear();
            dic.Add("Level_1", "Funding Update");
            dic.Add("Level_2", "Reports");
            pFundingInformation._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CurrentUpdateFunding", " FU Funding");
            dic.Add("CurrentUpdateSolvency", " FU Solv");
            dic.Add("CurrentUpdatePPF", " FU PPF");
            dic.Add("LastFullValuation", " Regular Val Funding");
            dic.Add("SolvencyFundingLevel", "77");
            pFundingInformation_UK._FundingUpdate_Reports(dic);


            pFundingInformation_UK._SelectTab("Experience");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("EmployeeContributionRate", "3.2");
            dic.Add("EmployerContributionRate", "5.0");
            dic.Add("FTSEAllShareTRI_PreviousUpdate", "3.56");
            dic.Add("FTSEAllShareTRI_CurrentUpdate", "2.45");
            dic.Add("FTGovtFixed_PreviousUpdate", "2.10");
            dic.Add("FTGovtFixed_CurrentUpdate", "0.55");
            dic.Add("FTGovIL_PreviousUpdate", "1.23");
            dic.Add("FTGovIL_CurrentUpdate", "1.20");
            dic.Add("IBoxxCorpBondAA_PreviousUpdate", "2.1234");
            dic.Add("IBoxxCorpBondAA_CurrentUpdate", "0.3451");
            dic.Add("DurationForGiltYields_PreviousUpdate", "12.1");
            dic.Add("FixedGiltYield_PreviousUpdate", "1.00");
            dic.Add("FixedGiltYield_CurrentUpdate", "3.45");
            dic.Add("IndexLinkedGilt_PreviousUpdate", "3.10");
            dic.Add("IndexLinkedGilt_CurrentUpdate", "0.45");
            dic.Add("ImpliedInflation_PreviousUpdate", "1.23");
            dic.Add("ImpliedInflation_CurrentUpdate", "3.10");
            dic.Add("AssetReturn", "-2.11");
            pFundingInformation_UK._FundingUpdate_Reports_Experience(dic);



            pFundingInformation_UK._SelectTab("Basis");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("InvestmentReturnPre_PreviousUpdate", "1.45");
            dic.Add("InvestmentReturnPre_CurrentUpdate", "4.00");
            dic.Add("InvestmentReturnPost_PreviousUpdate", "2.45");
            dic.Add("InvestmentReturnPost_CurrentUpdate", "2.30");
            dic.Add("InflationRPI_PreviousUpdate", "0.56");
            dic.Add("InflationRPI_CurrentUpdate", "1.30");
            dic.Add("InflationCPI_PreviousUpdate", "1.40");
            dic.Add("InflationCPI_CurrentUpdate", "2.34");
            dic.Add("SalaryGrowth_PreviousUpdate", "3.00");
            dic.Add("SalaryGrowth_CurrentUpdate", "4.00");
            dic.Add("DeferredRevaluation_PreviousUpdate", "2.34");
            dic.Add("DeferredRevaluation_CurrentUpdate", "1.20");
            dic.Add("PensionIncrease5_0_PreviousUpdate", "1.34");
            dic.Add("PensionIncrease5_0_CurrentUpdate", "5.00");
            dic.Add("PensionIncrease2_5_PreviousUpdate", "2.34");
            dic.Add("PensionIncrease2_5_CurrentUpdate", "2.50");
            dic.Add("MortalityBaseTable_PreviousUpdate", "Mort1");
            dic.Add("MortalityBaseTable_CurrentUpdate", "Mort2");
            dic.Add("MortalityFutureImprovements_PreviousUpdate", "AA projection scale");
            dic.Add("MortalityFutureImprovements_CurrentUpdate", "XX projection scale");
            pFundingInformation_UK._FundingUpdate_Reports_Basis(dic);


            pFundingInformation_UK._SelectTab("General Info");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AssetMethod", "Roll forward using index returns");
            dic.Add("AOSMethod", "Last full valuation");
            dic.Add("VARChartMethod", "Surplus/Shortfall");
            dic.Add("ConsultingOfficeAddressLine1", "Mercer");
            dic.Add("Line2", "1 University Square Drive");
            dic.Add("Line3", "Suite 100");
            dic.Add("Line4", "Princeton, NJ 08540 USA");
            dic.Add("TelephoneNumber", "+1 609 520 2500");
            dic.Add("SFPDate", "01/04/2014");
            dic.Add("NextFullValuationDate", "01/04/2017");
            dic.Add("CurrencyUnit", "£ 000's");
            pFundingInformation_UK._FundingUpdate_Reports_GeneralInfo(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region Funding - Valuation2014_FV - Reports

            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Calculations");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_FundingCalculationRunCompleted_UK(dic);



            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Run");
            dic.Add("MenuItem_2", "Funding Update Calculations");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_RunOptions(dic);

            _gLib._Wait(10);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Valuation 2014");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Parameter Print", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Benefit Cashflows", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Other Info", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Population Projection", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Liabilities Detailed Results", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Test Cases", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Benefit Cashflows", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Payout Projection - Other Info", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results", "RollForward", false, true);

                ////////////  XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine.   NT 6.1 means win7
                ////if (Environment.OSVersion.ToString().Contains("NT 6.1"))
                ////    pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Liabilities Detailed Results with Ben Type splits", "RollForward", false, true);

                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Checking Spreadsheet", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Calculator - Consulting Spreadsheet", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Population Projection", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_FVPayouts(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Future Valuation Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Results Summary", "RollForward", false, true);
            }

            thrd_Valuation2014_FVGrowthPCT.Start();

            _gLib._MsgBox("", "XLS report <Liabilities Detailed Results with Ben Type splits> only works in Win7 machine," + Environment.NewLine + Environment.NewLine
                + "please mannually click and download <Liabilities Detailed Results with Ben Type splits>, if process not complete please ship because bug not fixed.");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Valuation Report", 3);

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, false, "Silver");

            pMain._SelectTab("Valuation 2014");
            pMain._GenerateNewReport(sOutputFunding_Valuation2014_FVGrowthPCT, "Funding Update Report", 3, true, "Silver");


            pMain._SelectTab("Valuation 2014");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            _gLib._MsgBox("!", "Finished!");
          
        }

        

        void t_CompareRpt_Valuation2011_Baseline(string sOutputFunding_Valuation2011_Baseline)
        {

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003CN", sOutputFunding_Valuation2011_Baseline_Prod, sOutputFunding_Valuation2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBenTypesplits.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }
        
        void t_CompareRpt_Valuation2014_Baseline(string sOutputFunding_Valuation2014_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003CN", sOutputFunding_Valuation2014_Baseline_Prod, sOutputFunding_Valuation2014_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2014_Baseline");
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_PPFS179.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBenTypesplits.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        void t_CompareRpt_Valuation2014_FVGrowthPCT(string sOutputFunding_Valuation2014_FVGrowthPCT)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK003CN", sOutputFunding_Valuation2014_FVGrowthPCT_Prod, sOutputFunding_Valuation2014_FVGrowthPCT);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2014_FVGrowthPCT");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-BenefitCashflows.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection-OtherInfo.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_PPFS179.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0);

                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Funding.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_PPF.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund1.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund2.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_AltFund3.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2014-liabilityvaluationdate.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2015-liabilityvaluationdate+1year.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_Valuationyear2016-liabilityvaluationdate+2year.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true );

                _compareReportsLib.CompareExcel_Exact("FundingUpdateResultsSummary.xlsx", 4, 0, 0, 0, true);
                ////////////////_compareReportsLib.CompareExcel_Exact("FundingCalculator-CheckingSpreadsheet.xlsm", 4, 0, 0, 0, true);
                ////////////////_compareReportsLib.CompareExcel_Exact("FundingCalculator-ConsultingSpreadsheet.xlsm", 4, 0, 0, 0, true);
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
