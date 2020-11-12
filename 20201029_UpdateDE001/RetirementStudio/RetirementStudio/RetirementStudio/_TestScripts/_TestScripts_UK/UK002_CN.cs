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
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;
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
using RetirementStudio._UIMaps.CommutationFormulaClasses;




namespace RetirementStudio._TestScripts._TestScripts_UK
{
    /// <summary>
    /// Summary description for UK002_CN
    /// </summary>
    [CodedUITest]
    public class UK002_CN
    {
        public UK002_CN()
        {
            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.UK;
            Config.sClientName = "QA UK Benchmark 002 Create New";
            Config.sPlanName = "QA UK Benchmark 002 Create New Plan";
            Config.sDataCenter = "Franklin";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;
        }

        #region Report Output Directory



        public string sOutputFunding_QAUK002Val = "";

        public string sOutputFunding_QAUK002Val_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_002\Production\VAL\7.2_20180313_B\";

        String sTable_MAERSK = "";

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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_UK_Benchmark_002\Create New\VAL\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sOutputFunding_QAUK002Val = _gLib._CreateDirectory(sMainDir + sPostFix + "\\");

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

                string sMainDir = sDir + "UK002_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_QAUK002Val = _gLib._CreateDirectory(sMainDir + "\\sOutputFunding_QAUK002Val\\");

            }

            string sContent = "";
            sContent = sContent + "sOutputFunding_QAUK002Val = @\"" + sOutputFunding_QAUK002Val + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);


        }


        #endregion


        #region Fields

        public CommutationFormula pCommutationFormula = new CommutationFormula();
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
        public void test_UK002_CN()
        {


            this.GenerateReportOuputDir();


            #region Create client and Data

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
            dic.Add("ClientCode", "UK002");
            dic.Add("FiscalYearEnd", "04/06");
            dic.Add("MeasurementDate", "04/06");
            dic.Add("Notes", "UK Test - Wolves" + Environment.NewLine + "Client Owner:  Marc Knowles" + Environment.NewLine + "Date Created:" + _gLib._ReturnDateStampYYYYMMDD());
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
            dic.Add("PlanYearBegin", "04/06");
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
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            pMain._HomeTreeViewSelect(0, dic);

            _gLib._MsgBox("Mannual Interaction", "Please mannually click on plan: " + Config.sClientName + ">>" + Config.sPlanName);


            dic.Clear();
            dic.Add("EnterShortName", "AllMembers");
            dic.Add("ConfirmShortName", "AllMembers");
            dic.Add("LongName", "AllMembers");
            pMain._ts_CreateNewBenefitSet(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion

            #region Data - QA UK 002

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
            dic.Add("Name", "QA UK 002");
            dic.Add("EffectiveDate", "06/04/2008");
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
            dic.Add("ServiceToOpen", "QA UK 002");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("Level_1", "QA UK 002");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\UK002\SnapshotwithSpPen_BM_002.xls");
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
            dic.Add("Level_1", "QA UK 002");
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
            pData._CV_AddSingleLabel(dic, true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Beneficiary Information");
            dic.Add("Label", "Ben1Ben1_Pre90");
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
            dic.Add("Label", "TINGMP");
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
            dic.Add("Label", "Benefit1DBPre90");
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
            dic.Add("Label", "PPENAVC");
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
            dic.Add("Level_1", "QA UK 002");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "QA_UK_Data_002");
            dic.Add("FileType", "");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "SnapshotwithSpPen_BM_002.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);



            pData._SelectTab("Mapping");

            pData._IP_Mapping_Initialize("Personal Information", "DB Information", 1, 0, 1, "MembershipDate1");

            pData._IP_Mapping_MapField("Benefit1DBPre90", "Benefit1DB_Pre90", 14, false);

            pMain._Home_ToolbarClick_Top(true);



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
            dic.Add("PopVerify", "Verify");
            dic.Add("Status", "STAGED");
            dic.Add("LoadBlankData", "");
            dic.Add("MatchingIsCaseSensitive", "");
            dic.Add("IgnoreGoneRecordsForMatching", "");
            dic.Add("ValidateData", "");
            dic.Add("LoadData", "");
            dic.Add("ValidateAndLoadData", "");
            pData._PopVerify_IP_ValidateAndLoad(dic);



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
            dic.Add("Unique_NoMatch_Num", "86");
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
            dic.Add("New_Num", "86");
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

            dic.Clear();
            dic.Add("Level_1", "QA UK 002");
            dic.Add("Level_2", "Derivation Groups");
            dic.Add("MenuItem", "Add new derivation group");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DerivationGroupName", "NewDerivationGroup1");
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
            dic.Add("DerivedField", "BenefitSetShortName");
            dic.Add("DerivedField_SearchFromIndex", "20");
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
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "=\"AllMembers\"");
            dic.Add("Accept", "");
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
            dic.Add("Level_1", "QA UK 002");
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
            dic.Add("DerivedField_SearchFromIndex", "3");
            dic.Add("Type", "");
            dic.Add("Edit", "Click");
            pData._DG_DerivationGrid(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SelectInputFields", "Click");
            dic.Add("StandardorCustomFilter", "");
            dic.Add("Filter", "");
            dic.Add("CustomExpression", "");
            dic.Add("CustomExpression_Formula", "");
            dic.Add("CustomExpression_Accept", "");
            dic.Add("Formula", "");
            dic.Add("Accept", "");
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
            dic.Add("Level_1", "QA UK 002");
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "USC");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "QA_UK_BM_002");
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


            #region   Funding - QA UK 002 Val - ParticipantData


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
            dic.Add("Name", "QA UK 002 Val");
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
            dic.Add("ServiceToOpen", "QA UK 002 Val");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("QA UK 002 Val");

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
            dic.Add("SnapshotName", "QA_UK_BM_002");
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


            pMain._SelectTab("QA UK 002 Val");


            for (int i = 15; i <= 20; i++)
                sTable_MAERSK = sTable_MAERSK + "0.000000" + Environment.NewLine;

            for (int i = 21; i <= 30; i++)
                sTable_MAERSK = sTable_MAERSK + "0.100000" + Environment.NewLine;

            for (int i = 31; i <= 40; i++)
                sTable_MAERSK = sTable_MAERSK + "0.050000" + Environment.NewLine;

            for (int i = 41; i <= 65; i++)
                sTable_MAERSK = sTable_MAERSK + "0.020000" + Environment.NewLine;

            for (int i = 66; i <= 120; i++)
                sTable_MAERSK = sTable_MAERSK + "0.000000" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "MAERSK");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "UK Test - Wolves Benchmark Table");
            dic.Add("Ultimate", "click");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "");
            dic.Add("Index1_From", "15");
            dic.Add("Index1_To", "120");
            dic.Add("Extend", "");
            dic.Add("Zero", "Click");
            dic.Add("SameRatesUsed", "true");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sUnisexRates", sTable_MAERSK);
            dic.Add("sMaleRates", "");
            dic.Add("sFemaleRates", "");
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - QA UK 002 Val - Assumptions & Provisions

            pMain._SelectTab("QA UK 002 Val");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Assumptions");

            pMethods._SelectTab("Funding");


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreCommencementRate_C", "7.0");
            dic.Add("PreCommencementRate_T", "");
            dic.Add("PostCommencementRate_C", "5.0");
            dic.Add("PostCommencementRate_T", "");
            pInterestRate._PopVerify_PrePostCommencement(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Pre90peninc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pre90peninc");
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
            pAssumptions._TreeViewRightSelect(dic, "Post97Peninc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Post97Peninc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.25");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "Pst88GMPinc");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Pst88GMPinc");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
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
            pAssumptions._TreeViewRightSelect(dic, "Inflationrate");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "Inflationrate");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "true");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3.5");
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
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "4.75");
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
            dic.Add("CPIRate_P", "click");
            dic.Add("CPIRate_T", "");
            dic.Add("CPIRate_cbo_V", "");
            dic.Add("CPIRate_txt", "");
            dic.Add("CPIRate_cbo_T", "");
            dic.Add("RPIRate_V", "");
            dic.Add("RPIRate_P", "click");
            dic.Add("RPIRate_T", "");
            dic.Add("RPIRate_cbo_V", "");
            dic.Add("RPIRate_txt", "3.5");
            dic.Add("RPIRate_cbo_T", "");
            pInflation._PopVerify_SameStructureForAll(dic);


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
            dic.Add("SalCapInc_txt", "3.5");
            dic.Add("S148Inc_txt", "4.75");
            dic.Add("LimmGMPRate_txt", "5.0");
            pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Other Demographic Assumptions");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "");
            dic.Add("btnPercentMarried_Percent", "");
            dic.Add("btnPercentMarried_T", "");
            dic.Add("txtPercentMarried_M", "90.0");
            dic.Add("txtPercentMarried_F", "75.0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "-3");
            dic.Add("txtDifferenceInSpouseAge_F", "3");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);

            pMain._Home_ToolbarClick_Top(true);



            pMain._SelectTab("QA UK 002 Val");


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
            dic.Add("UseServiceCa", "");
            pService._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceStarts_Age_V", "");
            dic.Add("ServiceStarts_Age_C", "");
            dic.Add("ServiceStarts_Age_cbo", "");
            dic.Add("ServiceStarts_Age_txt", "");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("Date", "MembershipDate1");
            dic.Add("RoundingRule", "Completed months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "Pre90NRA");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Pre90NRA");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "false");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "60");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "$Service");
            dic.Add("AgeBasedOn", "$Age");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Pre90NRA");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "Pre90NRA");
            dic.Add("Level_4", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "65");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "$Service");
            dic.Add("AgeBasedOn", "$Age");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);



            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "Males");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.Gender = \"M\"");
            dic.Add("Validate", "click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);


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
            pAssumptions._TreeViewRightSelect(dic, "Pre90Joiner");

            dic.Clear();
            dic.Add("Level_1", "Global Provisions");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Pre90Joiner");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.MembershipDate1 < \"01/10/1990\"");
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
            dic.Add("LegislatedPayLimitDefinition", "false");
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
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "False");
            dic.Add("ApplyeDeductionBeforeAveraging", "");
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
            dic.Add("N", "10");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "click");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            dic.Add("AdjustmentPeriodMonths", "6");
            dic.Add("AdjustmentMethod", "");
            pPayAverage._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "click");
            dic.Add("Deduction_cbo", "");
            dic.Add("Deduction_txt", "4540");
            dic.Add("DeductionAnnual_V", "click");
            dic.Add("DeductionAnnual_C", "");
            dic.Add("DeductionAnnual_cbo", "Inflation_RPI");
            dic.Add("DeductionAnnual_txt", "");
            pPayAverage._PopVerify_ApplyDeductionBeforeAverageing(dic);

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
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "ZERORET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Under65");
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
            dic.Add("RetWithdrawDis", "MAERSK");
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
            dic.Add("Deferred_ApplyTrancheSplits", "true");
            dic.Add("Pensioner_Service", "PensionableService");
            dic.Add("Pensioner_ApplyTrancheSplits", "");
            pTrancheDefinition._PopVerify_Main(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Edit Tranche");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "");
            dic.Add("Actives", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "");
            dic.Add("EndDate", "");
            dic.Add("GMPApplies", "");
            dic.Add("Active_PPFTranche", "");
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
            dic.Add("Active_FemalePPF_txt", "");
            dic.Add("Active_MaleSolvency_cbo", "");
            dic.Add("Active_MaleSolvency_txt", "65");
            dic.Add("Active_FemaleSolvency_cbo", "");
            dic.Add("Active_FemaleSolvency_txt", "");
            dic.Add("Def_PPFTranche", "");
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
            dic.Add("Def_FemalePPF_txt", "");
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
            dic.Add("Pen_FemalePPF_txt", "");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "65");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);



            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst90Pre95");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "17/05/1990");
            dic.Add("EndDate", "31/12/1994");
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
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst95Pre97");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "01/01/1995");
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
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst90Pre97");
            dic.Add("Actives", "false");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "17/05/1990");
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
            dic.Add("Pen_MalePPF_txt", "60");
            dic.Add("Pen_FemalePPF_cbo", "");
            dic.Add("Pen_FemalePPF_txt", "60");
            dic.Add("Pen_MaleSolvency_cbo", "");
            dic.Add("Pen_MaleSolvency_txt", "60");
            dic.Add("Pen_FemaleSolvency_cbo", "");
            dic.Add("Pen_FemaleSolvency_txt", "60");
            dic.Add("OK", "click");
            pTrancheDefinition._PopVerify_TrancheDefinition(dic);


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst97Pre09");
            dic.Add("Actives", "true");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("StartDate", "06/04/1997");
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


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");

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


            pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1990", "Add new Tranche");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Pst97");
            dic.Add("Actives", "false");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "true");
            dic.Add("StartDate", "06/04/1997");
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
            dic.Add("iRow", "1");
            dic.Add("DataField", "");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "true");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("DataField", "AccruedSpousesDID1");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "true");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);


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
            dic.Add("Level_3", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "Prospective09Service");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service Selection");
            dic.Add("Level_4", "Prospective09Service");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "true");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "Pst09_Service");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service Selection");
            dic.Add("MenuItem", "Add Service Selection");
            pAssumptions._TreeViewRightSelect(dic, "Prospective9709Service");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Service Selection");
            dic.Add("Level_4", "Prospective9709Service");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "true");
            dic.Add("CustomCode", "");
            dic.Add("BaseServiceProjection", "Pst97Pre09_Service");
            dic.Add("V", "");
            dic.Add("C", "");
            dic.Add("SelectServiceAtAge_cbo", "");
            dic.Add("SelectServiceAtAge_txt", "");
            pServiceSelection._PopVerify_ServiceSelection(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Participant Info");
            dic.Add("Level_3", "Tranche Definition");
            pAssumptions._TreeViewSelect(dic, true);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("DataField", "");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "true");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("DataField", "AccruedSpousesDID1");
            dic.Add("Tranches", "All");
            dic.Add("TrueOrFalse", "true");
            pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic);


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
            pAssumptions._TreeViewRightSelect(dic, "TVINpenadj");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula A");
            dic.Add("Level_5", "TVINpenadj");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.addpen * (1+$Inflationrate) ^ ($Age - 65)");
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
            dic.Add("Service", "Pre1990_Service");
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
            pAssumptions._TreeViewRightSelect(dic, "Pension9095");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9095");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst90Pre95_Service");
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
            pAssumptions._TreeViewRightSelect(dic, "Pension9597");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9597");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst95Pre97_Service");
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
            pAssumptions._TreeViewRightSelect(dic, "Pension9709");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Pension9709");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Pst97Pre09_Service");
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
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "Prospectivepost09");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Prospectivepost09");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Prospective09Service");
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
            pAssumptions._TreeViewRightSelect(dic, "Prospectivepost9709");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "FAE Formula");
            dic.Add("Level_5", "Prospectivepost9709");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "FinalPensionableSalary");
            dic.Add("Service", "Prospective9709Service");
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
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("MenuItem", "Add Employee Contributions Formula");
            pAssumptions._TreeViewRightSelect(dic, "NewEmployeeContributions1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Employee Contributions Formula");
            dic.Add("Level_5", "NewEmployeeContributions1");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "True");
            dic.Add("CustomCode", "");
            dic.Add("FormulaCalculated", "");
            dic.Add("PredefinedAmount_rd", "");
            dic.Add("StartingBalanceAsOfOneYear", "");
            dic.Add("StartingBalance_V", "Click");
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
            dic.Add("ContributionsMade", "");
            dic.Add("InterestCredited", "");
            dic.Add("RateForYear_V", "");
            dic.Add("RateForYear_P", "");
            dic.Add("RateForYear_T", "");
            dic.Add("RateForYear_cbo", "");
            dic.Add("RateForYear_txt", "");
            dic.Add("SameRatesApplies", "");
            dic.Add("Rate_V", "");
            dic.Add("Rate_P", "Click");
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
            pAssumptions._TreeViewRightSelect(dic, "Spouses9709");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Spouses9709");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$pension9709 * 0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "Pre90PensionTV");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "Pre90PensionTV");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$Pre90Pension * $TVINpenadj");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpousepen");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Formulae");
            dic.Add("Level_4", "Custom Formula B");
            dic.Add("Level_5", "DeferredSpousepen");
            dic.Add("Level_6", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$emp.AccruedBenefit1 * 0.5");
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
            pAssumptions._TreeViewRightSelect(dic, "Pre90Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Pre90Increase");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "true");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_Rate_V_cbo", "Inflation_RPI");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
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
            dic.Add("Increase_Amount_Rate_V", "click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "Pre90peninc");
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
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Post90Pre97Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Post90Pre97Increase");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "true");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_Rate_V_cbo", "Inflation_RPI");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
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
            dic.Add("Increase_Amount_Rate_P", "click");
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
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Post97Increase");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Cost of Living Adjustments");
            dic.Add("Level_4", "Post97Increase");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StatutoryCPI", "");
            dic.Add("StatutoryRPI", "true");
            pCostOfLivingAdjustments_UK._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_DeferredPension", "");
            dic.Add("Revaluation_Rate_V", "Click");
            dic.Add("Revaluation_Rate_P", "");
            dic.Add("Revaluation_Rate_T", "");
            dic.Add("Revaluation_Rate_V_cbo", "Inflation_RPI");
            dic.Add("Revaluation_Rate_P_txt", "");
            dic.Add("Revaluation_Rate_T_cbo", "");
            dic.Add("Revaluation_CumulativeMax", "5.0");
            dic.Add("Revaluation_PensionIncrease", "");
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
            dic.Add("Increase_Amount_Rate_V", "click");
            dic.Add("Increase_Amount_Rate_P", "");
            dic.Add("Increase_Amount_Rate_T", "");
            dic.Add("Increase_Amount_Rate_V_cbo", "Pre90peninc");
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
            dic.Add("Expression", "1.469 / (1 + $PayIncrease) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Females");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pst90Pre95LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pst90Pre95LRF");
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
            dic.Add("Level_4", "Pst90Pre95LRF");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pst90Pre95LRF");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.469 / (1 + $PayIncrease) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Pre90Joiner");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pre90LRFWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pre90LRFWTH");
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
            dic.Add("Level_4", "Pre90LRFWTH");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pre90LRFWTH");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.469 / (1 + $inflationrate) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Females");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "Pst90Pre95LRFWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pst90Pre95LRFWTH");
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
            dic.Add("Level_4", "Pst90Pre95LRFWTH");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "Pst90Pre95LRFWTH");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "1.469 / (1 + $inflationrate) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Pre90Joiner");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "SpousePre90LRFWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePre90LRFWTH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePre90LRFWTH");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePre90LRFWTH");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5*1.469 / (1 + $inflationrate) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Females");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("MenuItem", "Add Late Retirement Factors");
            pAssumptions._TreeViewRightSelect(dic, "SpousePst90Pre90LRFWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePst90Pre90LRFWTH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePst90Pre90LRFWTH");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Late Retirement Factors");
            dic.Add("Level_4", "SpousePst90Pre90LRFWTH");
            dic.Add("Level_5", "NewSubGroup1");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "0.5*1.469 / (1 + $inflationrate) ^ 5");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "true");
            dic.Add("cboPreDefinedEligibility", "Pre90Joiner");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

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
            dic.Add("Act_FromValuation_FixedRateAt", "");
            dic.Add("Act_FromValuation_FixedRateAt_V", "");
            dic.Add("Act_FromValuation_FixedRateAt_D", "");
            dic.Add("Act_FromValuation_PensionIncrease", "");
            dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
            dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
            dic.Add("Act_FromDate_S148Increases", "");
            dic.Add("Act_FromDate_FixedRateAt", "click");
            dic.Add("Act_FromDate_FixedRateAt_V", "");
            ////////dic.Add("Act_FromDate_FixedRateAt_D", "click");
            dic.Add("Act_FromDate_PensionIncrease", "");
            dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
            //////// dic.Add("Act_FromDate_FixedRateAt_D_txt", "06/04/2008");
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
            dic.Add("Level_3", "Commutation Factors");
            dic.Add("MenuItem", "Add Commutation Factors");
            pAssumptions._TreeViewRightSelect(dic, "CommutationFactors");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Factors");
            dic.Add("Level_4", "CommutationFactors");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Male_C", "click");
            dic.Add("Male_T", "");
            dic.Add("Male_C_txt", "13.0");
            dic.Add("Male_T_cbo", "");
            dic.Add("Female_C", "click");
            dic.Add("Female_T", "");
            dic.Add("Female_C_txt", "13.0");
            dic.Add("Female_T_cbo", "");
            pCommunicationFactors._PopVerify_CommunicationFactors(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("MenuItem", "Add Commutation Formula");
            pAssumptions._TreeViewRightSelect(dic, "Commutation25pension");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Commutation Formula");
            dic.Add("Level_4", "Commutation25pension");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PercnetOfPension", "true");
            dic.Add("LumpSumIs", "25.00");
            pCommutationFormula._Main(dic);



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
            dic.Add("btnGuaranteePeriod_C", "Click");
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
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
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
            dic.Add("btnSurvivorPercentOrAmount_Percent", "click");
            dic.Add("SurvivorPercentOrAmount_txt", "50.0");
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
            pAssumptions._TreeViewRightSelect(dic, "SpousesDTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Form of Payment");
            dic.Add("Level_4", "SpousesDTH");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "WTHPre90LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "WTHPre90LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "Pre90LRFWTH");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "WTH9095LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "WTH9095LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "Pst90Pre95LRFWTH");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "SpousesAdj");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "SpousesAdj");
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
            pAssumptions._TreeViewRightSelect(dic, "SpousesWTHPre90LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "SpousesWTHPre90LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "SpousePre90LRFWTH");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "SpousesWTH9095LRF");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            dic.Add("Level_4", "SpousesWTH9095LRF");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LoadingFactor_V", "Click");
            dic.Add("LoadingFactor_C", "");
            dic.Add("LoadingFactor_T", "");
            dic.Add("LoadingFactor_cboV", "SpousePst90Pre90LRFWTH");
            dic.Add("LoadingFactor_txt", "");
            dic.Add("LoadingFactor_cboT", "");
            dic.Add("ApplyTo", "");
            pAdjustments._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Adjustments");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActivesMembersRET");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActivesMembersRET");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9709");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActivesMembersWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActivesMembersWTH");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9709");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpousesDID");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpousesDID");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9709");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpousesDTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpousesDTH");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Prospectivepost9709");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "Pension9709");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Prospectivepost09");
            dic.Add("DefineAccruedBenefitSeparately", "true");
            dic.Add("AccruedBaseAmount", "PensionPost09");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
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
            pAssumptions._TreeViewRightSelect(dic, "PensionerMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "PensionerMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "");
            dic.Add("Pensioner", "true");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Benefit1DBPre90");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Benefit1DB_Pre97");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "Benefit1DB_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Post97Increase");
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
            dic.Add("Pensioner", "true");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmount", "Ben1Ben1_Pre90");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmount", "Ben1Ben1_Pre97");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Pensioner(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmount", "Ben1Ben1_Post97PreA");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("IncreasesInPayment", "Post97Increase");
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
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpouseRET");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpouseRET");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSep3arately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRF");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSep3arately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9709");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "ActiveSpouseWTH");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "ActiveSpouseWTH");
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
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pre90PensionTV");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pre90LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9095");
            dic.Add("DefineAccruedBenefitSep3arately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "Pst90Pre95LRFWTH");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9597");
            dic.Add("DefineAccruedBenefitSep3arately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "Pension9709");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("iCol_Total", "5");
            dic.Add("BaseAmount", "PensionPost09");
            dic.Add("DefineAccruedBenefitSeparately", "");
            dic.Add("AccruedBaseAmount", "#1#");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "SpousesAdj");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Active(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
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
            dic.Add("SpousePercent_txt", "");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "Pre1990_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pre1990_AccruedBenefit1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Pre90NRA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Pst90Pre95_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "Pst95Pre97_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "Pst97Pre09_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "5");
            dic.Add("BaseAmountRevaluing", "Pst09_AccruedBenefit1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);



            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("MenuItem", "Add Tranched Benefit");
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Provisions");
            dic.Add("Level_3", "Tranched Benefit");
            dic.Add("Level_4", "DeferredSpouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Active", "");
            dic.Add("Deferred", "true");
            dic.Add("Pensioner", "");
            dic.Add("BaseAmountRevaluing", "");
            dic.Add("BaseAmountNonRevaluing", "");
            dic.Add("RevalueNonRevaluing", "");
            pTranchedBenefit._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("iCol", "1");
            dic.Add("BaseAmountRevaluing", "Pre1990_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "Pre1990_AccruedSpousesDID1_NonRevTotalBen");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "");
            dic.Add("BenefitCommencementAge_cbo", "Pre90NRA");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Pre90Increase");
            dic.Add("IncreasesInPayment", "Pre90Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "2");
            dic.Add("BaseAmountRevaluing", "Pst90Pre95_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "60");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic);

            dic.Clear();
            dic.Add("iCol", "3");
            dic.Add("BaseAmountRevaluing", "Pst95Pre97_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post90Pre97Increase");
            dic.Add("IncreasesInPayment", "Post90Pre97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "GMPAdjustmentFactor");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic); dic.Clear();

            dic.Add("iCol", "4");
            dic.Add("BaseAmountRevaluing", "Pst97Pre09_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
            dic.Add("AdjustmentFactors", "");
            dic.Add("SpousePercent_txt", "50.0000%");
            dic.Add("SpousePercent_cbo", "");
            pTranchedBenefit._TBL_Deferred(dic); dic.Clear();

            dic.Add("iCol", "5");
            dic.Add("BaseAmountRevaluing", "Pst09_AccruedSpousesDID1_RevTotalBen");
            dic.Add("BaseAmountNonRevaluing", "#1#");
            dic.Add("AccruedBaseAmount", "");
            dic.Add("BenefitCommencementAge_current", "");
            dic.Add("BenefitCommencementAge_txt", "65");
            dic.Add("BenefitCommencementAge_cbo", "");
            dic.Add("BenefitStopAge_current", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("RevaluationInDeferment", "Post97Increase");
            dic.Add("IncreasesInPayment", "Post97Increase");
            dic.Add("EarlyRetirementFactors", "");
            dic.Add("LateRetirementFactors", "");
            dic.Add("GMPAdjustmentFactors", "");
            dic.Add("CommutationFactors", "CommutationFactors");
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
            dic.Add("TranchedBenefit", "ActivesMembersRET");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "Commutation25pension");
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
            dic.Add("TranchedBenefit", "ActiveSpouseRET");
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
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActivesMembersWTH");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "Commutation25pension");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_WTH_Spouse_Pst");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_WTH_Spouse_Pst");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActiveSpouseWTH");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_WTH_Spouse_Pre");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_WTH_Spouse_Pre");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActiveSpousesDID");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Withdrawal");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "Active_DTH_Spouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "Active_DTH_Spouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Actives");
            dic.Add("TranchedBenefit", "ActiveSpousesDTH");
            dic.Add("FormOfPayment", "SpousesDTH");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "PayIncrease");
            dic.Add("Decrement", "Death");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PensMember");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "PensMember");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PensionerMember");
            dic.Add("FormOfPayment", "MembersPension");
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
            pAssumptions._TreeViewRightSelect(dic, "PensSpouse");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "PensSpouse");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Pensioners");
            dic.Add("TranchedBenefit", "PensionerSpouse");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("MenuItem", "Add Tranched Benefit Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "DeferredMemberRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DeferredMemberRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredMember");
            dic.Add("FormOfPayment", "MembersPension");
            dic.Add("CommutationAmount", "Commutation25pension");
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
            pAssumptions._TreeViewRightSelect(dic, "DeferredSpouseRet");

            dic.Clear();
            dic.Add("Level_1", "AllMembers");
            dic.Add("Level_2", "Benefit Definition");
            dic.Add("Level_3", "Tranched Benefit Plan Definition");
            dic.Add("Level_4", "DeferredSpouseRet");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ParticipantType", "Deferreds");
            dic.Add("TranchedBenefit", "DeferredSpouse");
            dic.Add("FormOfPayment", "Reversionary");
            dic.Add("CommutationAmount", "");
            dic.Add("SalaryIncreaseForGMP", "");
            dic.Add("Decrement", "Not Decrement-Based");
            dic.Add("ApplyDifferentStartAge", "");
            dic.Add("PPFCalculationType", "");
            pTranchedBenefitPlanDefinition._PopVerify_TranchedBenefitPlanDefinition(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Funding - QA UK 002 Val - Methods

            pMain._SelectTab("QA UK 002 Val");


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
            dic.Add("CostMethod", "Attained Age");
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
            dic.Add("AverageWorkingLifeTime", "");
            dic.Add("AverageLifeTime", "");
            dic.Add("AverageWorkingLifeTimeToVesting", "");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("GMPAdjustment", "GMPAdjustmentFactor");
            pMethods_UK._GMPAdjustmentsToUse_Grid(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("BenefitSet", "AllMembers");
            dic.Add("PayProjection", "BasicPayProjected");
            dic.Add("EmployeeContribution", "NewEmployeeContributions1");
            dic.Add("StopPVFuture", "$FullRetAge");
            pMethods_UK._AdditionalCalcuationRequest_Grid(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region Funding - QA UK 002 Val - Test case

            pMain._SelectTab("QA UK 002 Val");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate = \"03/05/1956\" and $emp.HireDate1 = \"06/06/1988\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate = \"05/14/1960\" and $emp.HireDate1 = \"06/17/1985\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate = \"06/24/1945\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion


            #region Funding - QA UK 002 Val - Rseports

            pMain._SelectTab("QA UK 002 Val");

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
            dic.Add("PayoutProjectionCustomGroup", "#1#");
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

            pMain._SelectTab("QA UK 002 Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);


            pMain._SelectTab("QA UK 002 Val");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Parameter Print", "Conversion", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Test Cases", "Conversion", true, true);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Liability Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_QAUK002Val, "Member Statistics", "Conversion", true, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_QAUK002Val, "Conversion Diagnostic", "Conversion", true, true, 0);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_QAUK002Val, "Valuation Summary", "Conversion", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Individual Output", "Conversion", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Liability Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_QAUK002Val, "Member Statistics", "Conversion", false, true);
                pOutputManager._ExportReport_DrillDown(sOutputFunding_QAUK002Val, "Conversion Diagnostic", "Conversion", false, true, 0);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_QAUK002Val, "Detailed Results", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Detailed Results with Ben Type splits", "Conversion", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sOutputFunding_QAUK002Val, "Valuation Summary", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Individual Output", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "IOE", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Payout Projection - Benefit Cashflows", "Conversion", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sOutputFunding_QAUK002Val, "Payout Projection - Other Info", "Conversion", false, true);

            }

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("UK002CN", sOutputFunding_QAUK002Val_Prod, sOutputFunding_QAUK002Val);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_QAUK002Val");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0 ,true);
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

            pMain._SelectTab("QA UK 002 Val");
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
