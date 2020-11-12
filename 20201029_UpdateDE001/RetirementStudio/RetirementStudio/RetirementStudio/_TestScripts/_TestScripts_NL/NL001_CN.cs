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

// CA Screens
using RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses;


// DE Screens
using RetirementStudio._UIMaps.AssumedRetirementAgeClasses;
using RetirementStudio._UIMaps.ContractualRetirementAgeClasses;
using RetirementStudio._UIMaps.JubileeBenefitClasses;
using RetirementStudio._UIMaps.PlanDefinition_DEClasses;
using RetirementStudio._UIMaps.FlatAmountAccumulationClasses;
using RetirementStudio._UIMaps.UnitFormulaClasses;
using RetirementStudio._UIMaps.AgeClasses;
using RetirementStudio._UIMaps.PayCreditClasses;
using RetirementStudio._UIMaps.CashBalanceClasses;
using RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses;
using RetirementStudio._UIMaps.InactiveBenefitPaymentClasses;
using System.Threading;




namespace RetirementStudio._TestScripts._TestScripts_NL
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NL001_CN
    {
        public NL001_CN()
        {

            Config.eEnv = _TestingEnv.QA1;
            Config.eCountry = _Country.NL;
            Config.sClientName = "QA NL Benchmark 001 Create New D";
            Config.sPlanName = "QA NL Benchmark 001 Create New Plan";
            Config.sDataCenter = "Dallas";
            Config.bDownloadReports_PDF = false;
            Config.bDownloadReports_EXCEL = true;
            Config.bCompareReports = true;

        }

        
        #region Report Output Directory

        public string sFunding_Fnd2011Cnv = "";
        public string sFunding_Fnd2012RF_Baseline = ""; 
        public string sFunding_Fnd2012RF_FndChld1 = "";
        public string sAccounting_Acct2011Cnv = "";

        public string sFunding_Fnd2011Cnv_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2011Cnv\6.9.1_20160927_B\";
        public string sFunding_Fnd2012RF_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2012RF\Baseline\6.9.1_20160927_B\";
        public string sFunding_Fnd2012RF_FndChld1_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Funding\Fnd2012RF\FndChld1\6.9.1_20160927_B\";
        public string sAccounting_Acct2011Cnv_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\Production\Accounting\Acct2011Cnv\6.9.1_20160927_B\";

        String sTable_Ontslag_Male = "";
        String sTable_Ontslag_FeMale = "";

        String sTable_AOkansen_Male = "";
        String sTable_AOkansen_FeMale = "";



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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_NL_Benchmark_001\CreateNew\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                    sFunding_Fnd2011Cnv = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2011Cnv\\" + sPostFix + "\\");
                    sFunding_Fnd2012RF_Baseline = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2012RF\\Baseline\\" + sPostFix + "\\");
                    sFunding_Fnd2012RF_FndChld1 = _gLib._CreateDirectory(sMainDir + "Funding\\Fnd2012RF\\FndChld1\\" + sPostFix + "\\");
                    sAccounting_Acct2011Cnv = _gLib._CreateDirectory(sMainDir + "Accounting\\Acct2011Cnv\\" + sPostFix + "\\");

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

                string sMainDir = sDir + "NL001_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);

                _gLib._CreateDirectory(sMainDir);
                sFunding_Fnd2011Cnv = _gLib._CreateDirectory(sMainDir + "\\sFunding_Fnd2011Cnv\\");
                sFunding_Fnd2012RF_Baseline = _gLib._CreateDirectory(sMainDir + "\\sFunding_Fnd2012RF_Baseline\\");
                sFunding_Fnd2012RF_FndChld1 = _gLib._CreateDirectory(sMainDir + "\\sFunding_Fnd2012RF_FndChld1\\");
                sAccounting_Acct2011Cnv = _gLib._CreateDirectory(sMainDir + "\\sAccounting_Acct2011Cnv\\");

            }

            string sContent = "";
            sContent = sContent + "sFunding_Fnd2011Cnv = @\"" + sFunding_Fnd2011Cnv + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding_Fnd2012RF_Baseline = @\"" + sFunding_Fnd2012RF_Baseline + "\";" + Environment.NewLine;
            sContent = sContent + "sFunding_Fnd2012RF_FndChld1 = @\"" + sFunding_Fnd2012RF_FndChld1 + "\";" + Environment.NewLine;
            sContent = sContent + "sAccounting_Acct2011Cnv = @\"" + sAccounting_Acct2011Cnv + "\";" + Environment.NewLine;

            _gLib._PrintReportDirectory(sContent);



        }


        #endregion


        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();

        public InactiveBenefitPayment pInactiveBenefitPayment = new InactiveBenefitPayment();
        public CareerAverageEarmingsFormula pCareerAverageEarmingsFormula = new CareerAverageEarmingsFormula();
        public CashBalance pCashBalance = new CashBalance();
        public PayCredit pPayCredit = new PayCredit();
        public Age pAge = new Age();
        public UnitFormula pUnitFormula = new UnitFormula();
        public FlatAmountAccumulation pFlatAmountAccumulation = new FlatAmountAccumulation();
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



        #endregion


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_NL001_CN()
        {


            #region MultiThreads
            
            Thread thrd_Acct2011Cnv = new Thread(() => new NL001_CN().t_CompareRpt_Acct2011Cnv(sAccounting_Acct2011Cnv));
            Thread thrd_Fnd2011Cnv = new Thread(() => new NL001_CN().t_CompareRpt_Fnd2011Cnv(sFunding_Fnd2011Cnv));
            Thread thrd_Fnd2012RF_Baseline = new Thread(() => new NL001_CN().t_CompareRpt_Fnd2012RF_Baseline(sFunding_Fnd2012RF_Baseline));

            #endregion


            this.GenerateReportOuputDir();


            #region Data2011

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
            dic.Add("ClientCode", "1234");
            dic.Add("FiscalYearEnd", "12/31");
            dic.Add("MeasurementDate", "09/30");
            dic.Add("Notes", "Do NOT Delete!" + Environment.NewLine + "Original client: VR NEW NL BENCHMARK");
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
            dic.Add("Country", "Netherlands");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_PMTool_CountrySelection(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PlanName", Config.sPlanName);
            dic.Add("PlanYearBegin", "");
            dic.Add("OK", "Click");
            pMain._PopVerify_PMTool_Plan(dic);


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
            dic.Add("Name", "Data2011Cnv");
            dic.Add("EffectiveDate", "01-01-2011");
            dic.Add("Parent", "");
            dic.Add("RSC", "True");
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
            dic.Add("ServiceToOpen", "Data2011Cnv");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Data2011Cnv");

            dic.Clear();
            dic.Add("Level_1", "Data2011Cnv");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\NL001\Data_NLBench2011.xls");
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
            dic.Add("FileName", @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\NL001\Data_NLBench2012.xls");
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
            dic.Add("Level_1", "Data2011Cnv");
            dic.Add("Level_2", "Current View");
            pData._TreeViewSelect(dic);

            pData._CV_ExpandPersonalInformation();

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Category", "Pay");
            dic.Add("Label", "PayHist");
            dic.Add("DisplayName", "");
            dic.Add("VariesbyVO", "");
            dic.Add("HistoryLabels", "2");
            dic.Add("Monthly", "");
            dic.Add("Yearly", "");
            dic.Add("WarehouseFieldType", "");
            dic.Add("FieldLength", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("FromDate", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._CV_AddSingleLabel(dic, false);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Data2011Cnv");
            dic.Add("Level_2", "Imports");
            dic.Add("MenuItem", "Add new file");
            pData._TreeViewRightSelect(dic);

            pData._SelectTab("Select File");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "Imp1");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data_NLBench2011.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);

            pData._SelectTab("Mapping");

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Unique_NoMatch_Num", "283");
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
            dic.Add("Message", "");
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
            dic.Add("Level_1", "Data2011Cnv");
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
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");

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
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DivisionCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DC Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Funding Results");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Accounting Results");
            pData._TreeViewSelect_Snapshots(dic, true);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "DataSnap2011");
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


            #region sAccounting_Acct2011Cnv - ParticipantData

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
            dic.Add("Level_1", Config.sClientName);
            dic.Add("Level_2", Config.sPlanName);
            dic.Add("Level_3", "AccountingValuations");
            pMain._HomeTreeViewSelect(0, dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "Click");
            dic.Add("ServiceToOpen", "");
            pMain._PopVerify_Home_RightPane(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ConversionService", "True");
            dic.Add("Name", "Acct2011Cnv");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "");
            dic.Add("FiscalYearEndingIn_Accounting", "2011");
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
            dic.Add("ServiceToOpen", "Acct2011Cnv");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Acct2011Cnv");

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
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "DataSnap2011");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);


            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Accounting Results");
            dic.Add("Level_2", "GRSAccountingNC");
            dic.Add("Data", "Benefit1DB");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Accounting Results");
            dic.Add("Level_2", "GRSAccountingAL");
            dic.Add("Data", "PayHistCurrentYear");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "Click");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("Decrement", "Retirement");
            dic.Add("FundingAL", "");
            dic.Add("FundingNC", "");
            dic.Add("AccountingAL", "2000000");
            dic.Add("AccountingNC", "200000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Withdrawal");
            dic.Add("FundingAL", "");
            dic.Add("FundingNC", "");
            dic.Add("AccountingAL", "350000");
            dic.Add("AccountingNC", "80000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Disability");
            dic.Add("FundingAL", "");
            dic.Add("FundingNC", "");
            dic.Add("AccountingAL", "300000");
            dic.Add("AccountingNC", "60000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Decrement", "Death");
            dic.Add("FundingAL", "");
            dic.Add("FundingNC", "");
            dic.Add("AccountingAL", "294410");
            dic.Add("AccountingNC", "67958");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Row", "Number");
            dic.Add("Active", "63");
            dic.Add("Deferred", "153");
            dic.Add("Retired", "67");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Age");
            dic.Add("Active", "46,00");
            dic.Add("Deferred", "48,00");
            dic.Add("Retired", "74,50");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Service from Hire");
            dic.Add("Active", "13,00");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Pay");
            dic.Add("Active", "30000");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Annual Pension");
            dic.Add("Active", "");
            dic.Add("Deferred", "250000");
            dic.Add("Retired", "400000");
            dic.Add("OK", "Click");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

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

            pMain._SelectTab("Acct2011Cnv");



            for (int iAge = 15; iAge <= 24; iAge++)
                sTable_Ontslag_Male = sTable_Ontslag_Male + "0,000000" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,053000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,051100" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,049200" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,047300" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,045400" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,043500" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,041600" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,039700" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,037800" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,035900" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,034000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,032000" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,030000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,028000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,026000" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,024000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,022000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,020000" + Environment.NewLine;

            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,018000" + Environment.NewLine;
            sTable_Ontslag_Male = sTable_Ontslag_Male + "0,016000" + Environment.NewLine;

            for (int iAge = 45; iAge <= 65; iAge++)
                sTable_Ontslag_Male = sTable_Ontslag_Male + "0,014000" + Environment.NewLine;



            for (int iAge = 15; iAge <= 24; iAge++)
                sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,000000" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,171000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,164000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,157000" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,150000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,143000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,136000" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,129000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,122000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,115000" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,108000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,101000" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,094300" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,087600" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,080900" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,074200" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,067500" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,060800" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,054100" + Environment.NewLine;

            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,047400" + Environment.NewLine;
            sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,040700" + Environment.NewLine;

            for (int iAge = 45; iAge <= 65; iAge++)
                sTable_Ontslag_FeMale = sTable_Ontslag_FeMale + "0,034000" + Environment.NewLine;

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "Ontslag");
            dic.Add("Type", "Withdrawal Decrements");
            dic.Add("Description", "Copy from Canadian Sample Client");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "Age");
            dic.Add("Index1_From", "");
            dic.Add("Index1_To", "");
            dic.Add("Extend", "");
            dic.Add("Zero", "Click");
            dic.Add("SameRatesUsed", "");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sMaleRates", sTable_Ontslag_Male);
            dic.Add("sFemaleRates", sTable_Ontslag_FeMale);
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Acct2011Cnv");

            for (int iAge = 15; iAge <= 24; iAge++)
                sTable_AOkansen_Male = sTable_AOkansen_Male + "0,000308" + Environment.NewLine;

            for (int iAge = 25; iAge <= 34; iAge++)
                sTable_AOkansen_Male = sTable_AOkansen_Male + "0,000766" + Environment.NewLine;

            for (int iAge = 35; iAge <= 44; iAge++)
                sTable_AOkansen_Male = sTable_AOkansen_Male + "0,001166" + Environment.NewLine;

            for (int iAge = 45; iAge <= 54; iAge++)
                sTable_AOkansen_Male = sTable_AOkansen_Male + "0,002103" + Environment.NewLine;

            for (int iAge = 55; iAge <= 64; iAge++)
                sTable_AOkansen_Male = sTable_AOkansen_Male + "0,003840" + Environment.NewLine;




            for (int iAge = 15; iAge <= 24; iAge++)
                sTable_AOkansen_FeMale = sTable_AOkansen_FeMale + "0,000494" + Environment.NewLine;

            for (int iAge = 25; iAge <= 34; iAge++)
                sTable_AOkansen_FeMale = sTable_AOkansen_FeMale + "0,001525" + Environment.NewLine;

            for (int iAge = 35; iAge <= 44; iAge++)
                sTable_AOkansen_FeMale = sTable_AOkansen_FeMale + "0,001719" + Environment.NewLine;

            for (int iAge = 45; iAge <= 54; iAge++)
                sTable_AOkansen_FeMale = sTable_AOkansen_FeMale + "0,003101" + Environment.NewLine;

            for (int iAge = 55; iAge <= 64; iAge++)
                sTable_AOkansen_FeMale = sTable_AOkansen_FeMale + "0,004848" + Environment.NewLine;


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Name", "AOkansen");
            dic.Add("Type", "Disability Decrements");
            dic.Add("Description", "Copy from Canadian Sample Client");
            dic.Add("Ultimate", "");
            dic.Add("Generational", "");
            dic.Add("TwoDimensional", "");
            dic.Add("Index1_Index", "Age");
            dic.Add("Index1_From", "");
            dic.Add("Index1_To", "");
            dic.Add("Extend", "");
            dic.Add("Zero", "Click");
            dic.Add("SameRatesUsed", "");
            dic.Add("Format", "");
            dic.Add("DecimalPlaces", "");
            dic.Add("OK", "Click");
            dic.Add("sMaleRates", sTable_AOkansen_Male);
            dic.Add("sFemaleRates", sTable_AOkansen_FeMale);
            pMain._ts_AddTable(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            #region sAccounting_Acct2011Cnv - Assumption

            pMain._SelectTab("Acct2011Cnv");

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
            dic.Add("PreDecrementRate", "5,55");
            dic.Add("PreCommencementRate", "5,75");
            dic.Add("PostCommencementRate", "6,05");
            pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CustomR_2Percent");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CustomR_2Percent");
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
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CustomR_Zero");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayIncrease1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3,5");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Acct2011Cnv");

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
            pAssumptions._TreeViewRightSelect(dic, "Age1_NextFullMonth");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "Age1_NextFullMonth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValuationMonthAndDay", "true");
            dic.Add("OtherDate", "");
            dic.Add("AgeRoundingRule", "Age to next full month");
            pAge._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("MenuItem", "Add Age");
            pAssumptions._TreeViewRightSelect(dic, "Age2_RetAge65");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Age");
            dic.Add("Level_3", "Age2_RetAge65");
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
            dic.Add("Level_2", "Service");
            dic.Add("MenuItem", "Add Service");
            pAssumptions._TreeViewRightSelect(dic, "Svc1_MembD");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Service");
            dic.Add("Level_3", "Svc1_MembD");
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
            dic.Add("ServiceStarts_C", "Click");
            dic.Add("ServiceStarts_cbo", "");
            dic.Add("ServiceStarts_txt", "25");
            dic.Add("MaximumService_UseServiceCap", "40");
            dic.Add("ServiceStarts_FixedDate", "");
            dic.Add("ServiceStarts_Date", "MembershipDate1");
            dic.Add("ServiceEnds_V", "");
            dic.Add("ServiceEnds_C", "Click");
            dic.Add("ServiceEnds_cbo", "");
            dic.Add("ServiceEnds_txt", "66");
            dic.Add("ServiceEnds_FixedDate", "");
            dic.Add("ServiceEnds_Date", "TerminationDate1");
            dic.Add("CalculationMethod", "");
            dic.Add("RoundingPeriod", "");
            dic.Add("RoundingMethod", "");
            dic.Add("RoundingRule", "Nearest months");
            dic.Add("ServiceIncreasement_V", "");
            dic.Add("ServiceIncreasement_C", "");
            dic.Add("ServiceIncreasement_cbo", "");
            dic.Add("ServiceIncreasement_txt", "");
            pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA1_Fixed55");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "FTA1_Fixed55");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "55");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA2_Svc25");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "FTA2_Svc25");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "25");
            dic.Add("RuleOf", "");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("MenuItem", "Add From/To Age");
            pAssumptions._TreeViewRightSelect(dic, "FTA3_Rule70");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "From/To Age");
            dic.Add("Level_3", "FTA3_Rule70");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("InsertRow", "");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("SSNRA_Exists", "False");
            dic.Add("SSNRA", "");
            dic.Add("FixedAge", "");
            dic.Add("YearOfService", "");
            dic.Add("RuleOf", "70");
            dic.Add("DateConstant", "");
            dic.Add("DateField", "");
            dic.Add("ServiceBasedOn", "");
            dic.Add("AgeBasedOn", "");
            dic.Add("Comparison", "");
            pFromToAge._StandardTable_NotUS(dic);


            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "Actives");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "Actives");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.USC=\"Act\" and $age<$Age2_RetAge65");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("MenuItem", "Add Eligibilities");
            pAssumptions._TreeViewRightSelect(dic, "NotRetired");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Eligibilities");
            dic.Add("Level_3", "NotRetired");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Formula", "$emp.PayStatus = \"DEF\"");
            dic.Add("Validate", "Click");
            pEligibilities._PopVerify_Eligibilities(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PProj1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "PayHist");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
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
            dic.Add("Deduction_txt", "15736");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "Click");
            dic.Add("DeductionAnnualIncrease_P", "");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "CustomR_2Percent");
            dic.Add("DeductionAnnualIncrease_txt", "");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PProj2");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "True");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataFieldContainingPayHistory", "PayHist");
            dic.Add("PayIncreaseAssumption", "PayIncrease1");
            dic.Add("UseOnlyDataFields", "");
            dic.Add("rdValuationYearPlus", "");
            dic.Add("txtValuationYearPlus", "");
            dic.Add("rdSpecifiedYear", "");
            dic.Add("txtSpecifiedYear", "");
            dic.Add("ApplyEGTRRALimits", "");
            pPayoutProjection._PopVerify_History(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_C", "click");
            dic.Add("Deduction_txt", "17536");
            dic.Add("DeductionAnnualIncrease_V", "click");
            dic.Add("DeductionAnnualIncrease_cbo_V", "CustomR_2Percent");
            dic.Add("PlanPayLimitAmount_C", "click");
            dic.Add("PlanPayLimitAmount_txt", "57000");
            dic.Add("PlanPayAnnualLimitIncrease_V", "click");
            dic.Add("PlanPayAnnualLimitIncrease_cbo", "CustomR_Zero");
            pPayoutProjection._ApplyPayLimitDeduction_WithDeduction(dic);


            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PProj3_Function");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj3_Function");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "True");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("Function", "$PProj1/2+$PProj2/3");
            dic.Add("Validate", "Click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "23456");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "");
            dic.Add("DeductionAnnualIncrease_P", "Click");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "");
            dic.Add("DeductionAnnualIncrease_txt", "1,0");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);

            pMain._Home_ToolbarClick_Top(true);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("MenuItem", "Add Pay Projection");
            pAssumptions._TreeViewRightSelect(dic, "PProj4_Custom");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj4_Custom");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "Click");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PProj1*$emp.PTCurrent");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PayAv1");


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAv1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PProj1");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "Nearest month");
            dic.Add("DecimalPlacesForYearOfHire", "2");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "13579");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "");
            dic.Add("DeductionAnnualIncrease_P", "Click");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "");
            dic.Add("DeductionAnnualIncrease_txt", "1,0");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PayAv2");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAv2");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "True");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PProj2");
            dic.Add("AveragingMethod", "High M out of last N years");
            dic.Add("M", "3");
            dic.Add("N", "7");
            dic.Add("RoundingForYearOfHire", "Elapsed time");
            dic.Add("DecimalPlacesForYearOfHire", "2");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "13579");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "");
            dic.Add("DeductionAnnualIncrease_P", "Click");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "");
            dic.Add("DeductionAnnualIncrease_txt", "1,0");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "click");
            dic.Add("DeductionAnnual_V", "");
            dic.Add("DeductionAnnual_P", "click");
            dic.Add("ApplyAverageLimitAmount_C", "click");
            dic.Add("ApplyAverageLimitAmount_txt", "55000");
            dic.Add("ApplyAverageAnnualLimitIncrease_V", "click");
            dic.Add("ApplyAverageAnnualLimitIncrease_cbo", "CustomR_2Percent");
            pPayAverage._PopVerify_ApplyDeductionBeforeAverageing_And_ApplyAveragePayLimit(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("MenuItem", "Add Pay Average");
            pAssumptions._TreeViewRightSelect(dic, "PayAv3");

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAv3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyAveragePayLimit", "True");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            pPayAverage._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ApplyPayLimitBeforeAveraging", "");
            dic.Add("ApplyeDeductionBeforeAveraging", "");
            dic.Add("AdjustmentPeriod", "True");
            dic.Add("ApplyLegislatedSalaryCap", "");
            dic.Add("ApplyPayAverageFreezeDefinition", "");
            dic.Add("ApplyAverageAtFutureAge", "");
            dic.Add("UseDtaItemForSolvencyAndPPF", "");
            pPayAverage._PopVerify_Main_UK(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "PProj3_Function");
            dic.Add("AveragingMethod", "M consecutive out of last N years");
            dic.Add("M", "3");
            dic.Add("N", "6");
            dic.Add("RoundingForYearOfHire", "Completed month");
            dic.Add("DecimalPlacesForYearOfHire", "2");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "Click");
            dic.Add("Deduction_T", "");
            dic.Add("Deduction_cbo_V", "");
            dic.Add("Deduction_txt", "13579");
            dic.Add("Deduction_cbo_T", "");
            dic.Add("DeductionAnnualIncrease_V", "");
            dic.Add("DeductionAnnualIncrease_P", "Click");
            dic.Add("DeductionAnnualIncrease_T", "");
            dic.Add("DeductionAnnualIncrease_cbo_V", "");
            dic.Add("DeductionAnnualIncrease_txt", "1,0");
            dic.Add("DeductionAnnualIncrease_cbo_T", "");
            pPayoutProjection._PopVerify_ApplyDeduction(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "click");
            dic.Add("DeductionAnnual_V", "");
            dic.Add("DeductionAnnual_P", "click");
            dic.Add("ApplyAverageLimitAmount_C", "click");
            dic.Add("ApplyAverageLimitAmount_txt", "55000");
            dic.Add("ApplyAverageAnnualLimitIncrease_V", "click");
            dic.Add("ApplyAverageAnnualLimitIncrease_cbo", "CustomR_2Percent");
            pPayAverage._PopVerify_ApplyDeductionBeforeAverageing_And_ApplyAveragePayLimit(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            pMain._SelectTab("Acct2011Cnv");

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
            dic.Add("ApplyPercentMarriedAt", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("ApplyPercentMarriedAt", "Secondary decrement");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "NotPensioners");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$emp.PayStatus=\"DEF\"");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "AGPrognose20102060Hoog2010");
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

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Actives");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "Ontslag");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Actives");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("MenuItem", "Add Condition");
            pAssumptions._TreeViewRightSelect(dic, "NewSubGroup1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "AOkansen");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "Click");
            dic.Add("cboPreDefinedEligibility", "Actives");
            dic.Add("LocalEligibility", "");
            dic.Add("txtLocalEligibility", "");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "");
            dic.Add("Validate", "");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sAccounting_Acct2011Cnv - Provision

            pMain._SelectTab("Acct2011Cnv");

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
            dic.Add("Level_3", "Flat Amount Accumulation");
            dic.Add("MenuItem", "Add Flat Amount Accumulation");
            pAssumptions._TreeViewRightSelect(dic, "FLAT1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Flat Amount Accumulation");
            dic.Add("Level_4", "FLAT1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ServiceBasedOn", "Svc1_MembD");
            dic.Add("LimitServiceTo", "");
            dic.Add("StartingAccruedAmount", "AccruedBenefit1");
            dic.Add("AccrualRateTiersBasedOn", "Service");
            dic.Add("NumberOfAccrualRateTiers", "2");
            pFlatAmountAccumulation._Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "1");
            dic.Add("AccrualRatePerYearOfService", "101,00");
            dic.Add("UpToAgeAndService", "9");
            pFlatAmountAccumulation._Standard_Table(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("AccrualRatePerYearOfService", "111,00");
            dic.Add("UpToAgeAndService", "99");
            pFlatAmountAccumulation._Standard_Table(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "FAE1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "FAE1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "PayAv1");
            dic.Add("Service", "$Service");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "Service");
            dic.Add("NumberOfRateTiers", "2");
            dic.Add("IntegrationType", "Excess");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "9");
            dic.Add("sData4", "99");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("btnC", "click");
            dic.Add("btnV", "");
            dic.Add("sData2", "5678");
            dic.Add("sData3", "0,07");
            dic.Add("sData4", "0,073");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0,08");
            dic.Add("sData4", "0,085");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("MenuItem", "Add FAE Formula");
            pAssumptions._TreeViewRightSelect(dic, "FAE2");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "FAE Formula");
            dic.Add("Level_4", "FAE2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "PayAv2");
            dic.Add("Service", "Svc1_MembD");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "Service");
            dic.Add("NumberOfRateTiers", "2");
            dic.Add("IntegrationType", "Offset");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "9");
            dic.Add("sData4", "99");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("btnC", "");
            dic.Add("btnV", "");
            dic.Add("sData2", "");
            dic.Add("sData3", "0,07");
            dic.Add("sData4", "0,073");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);

            dic.Clear();
            dic.Add("iRow", "3");
            dic.Add("btnC", "click");
            dic.Add("btnV", "");
            dic.Add("sData2", "543");
            dic.Add("sData3", "0,08");
            dic.Add("sData4", "0,085");
            pFAEFormula._TBL_Excess_MoreThanOneTires(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("MenuItem", "Add Pay Credit");
            pAssumptions._TreeViewRightSelect(dic, "PayCredit1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Pay Credit");
            dic.Add("Level_4", "PayCredit1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PProj3_Function");
            dic.Add("ServiceBasedOn", "");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Standard", "");
            dic.Add("CustomCode", "");
            dic.Add("ServiceProrateFormula", "");
            dic.Add("ServiceProrateReduction", "");
            dic.Add("PayAverage", "");
            dic.Add("Service", "");
            dic.Add("ServiceLimitTo", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_TXT", "");
            dic.Add("RateTiersBasedOn", "Service");
            dic.Add("NumberOfRateTiers", "2");
            dic.Add("IntegrationType", "");
            dic.Add("NumberOfBreakPoints", "");
            pFAEFormula._PopVerify_Standard(dic);


            ////////            oParam.Add "iColumn" , "1"
            ////////oParam.Add "ServiceYear" , "9"
            ////////oParam.Add "NonIntegrated_txt" , "0,065"

            ////////           oParam.Add "iColumn" , "2"
            ////////oParam.Add "ServiceYear" , "99"
            ////////oParam.Add "NonIntegrated_txt" , "0,075"

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "9");
            dic.Add("bPayCredit", "true");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "99");
            dic.Add("bPayCredit", "true");
            pUnitFormula._FormulaTable(dic);


            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "0,065");
            dic.Add("bPayCredit", "true");
            pUnitFormula._FormulaTable(dic);

            dic.Clear();
            dic.Add("iRow", "2");
            dic.Add("iCol", "2");
            dic.Add("iRowMax", "2");
            dic.Add("iColMax", "2");
            dic.Add("sData", "0,075");
            dic.Add("bPayCredit", "true");
            pUnitFormula._FormulaTable(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("MenuItem", "Add Cash Balance");
            pAssumptions._TreeViewRightSelect(dic, "CashBalance1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Cash Balance");
            dic.Add("Level_4", "CashBalance1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("StartingBalance", "AccruedBenefit1");
            dic.Add("PayCredits", "PayCredit1");
            pCashBalance._PopVerify_Standard(dic);


            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CAE1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CAE1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PProj4_Custom");
            dic.Add("ServiceBasedOn", "Svc1_MembD");
            pPayCredit._PopVerify_Standard(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CustomR_Zero");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "ComingServiceBenefitOPatValDate");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "click");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "65");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0,0175");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("MenuItem", "Add Career Average Earnings Formula");
            pAssumptions._TreeViewRightSelect(dic, "CAE2");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CAE2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ProjectedSalary", "PayAv3");
            dic.Add("ServiceBasedOn", "Svc1_MembD");
            pPayCredit._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_V_NL", "click");
            dic.Add("Revaluation_Rate_cbo_NL", "CustomR_Zero");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "click");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "ComingServiceBenefitNPatValDate");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "click");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "65");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);

            pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0,01225");


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "CustFB1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "CustFB1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CAE1+0.0175*$PProj4_Custom*Max(0,$Age1_NextFullMonth-$Age2_RetAge65)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("MenuItem", "Add Custom Formula B");
            pAssumptions._TreeViewRightSelect(dic, "CustFB2");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Custom Formula B");
            dic.Add("Level_4", "CustFB2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$CAE2+0.01225*$PProj4_Custom*Max(0,$Age1_NextFullMonth-$Age2_RetAge65)");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            pAssumptions._Collapse(dic);



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
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLA1p");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "COLA1p");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLA_End", "");
            dic.Add("COLA_DuringDeferral", "true");
            dic.Add("COLA_AfterBenefit_Rate_V", "Click");
            dic.Add("COLA_AfterBenefit_Rate_cbo_V", "CustomR_Zero");
            dic.Add("COLA_AfterBenefit_Rate_C", "");
            dic.Add("COLA_AfterBenefit_Rate_txt", "");
            dic.Add("COLA_During_Rate_V", "click");
            dic.Add("COLA_During_Rate_cbo_V", "CustomR_Zero");
            dic.Add("COLA_During_Rate_C", "");
            dic.Add("COLA_During_Rate_txt", "");
            pCostOfLivingAdjustments._COLADuringDeferral_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("MenuItem", "Add Cost of Living Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "COLA2p");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Cost of Living Adjustments");
            dic.Add("Level_3", "COLA2p");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("COLA_End", "");
            dic.Add("COLA_DuringDeferral", "true");
            dic.Add("COLA_AfterBenefit_Rate_V", "");
            dic.Add("COLA_AfterBenefit_Rate_cbo_V", "");
            dic.Add("COLA_AfterBenefit_Rate_C", "Click");
            dic.Add("COLA_AfterBenefit_Rate_txt", "3,45");
            dic.Add("COLA_During_Rate_V", "");
            dic.Add("COLA_During_Rate_cbo_V", "");
            dic.Add("COLA_During_Rate_C", "click");
            dic.Add("COLA_During_Rate_txt", "4,12");
            pCostOfLivingAdjustments._COLADuringDeferral_NL(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("MenuItem", "Add Form of Payment");
            pAssumptions._TreeViewRightSelect(dic, "FOP1_SL");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP1_SL");
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
            pAssumptions._TreeViewRightSelect(dic, "FOP2_Spouse");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP2_Spouse");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's");
            dic.Add("MortalityInReferralPeriod", "Joint life mortality");
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
            pAssumptions._TreeViewRightSelect(dic, "FOP3_SpDID");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP3_SpDID");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "Spouse's annuity for death in deferral");
            dic.Add("MortalityInReferralPeriod", "");
            dic.Add("btnGuaranteePeriod_V", "");
            dic.Add("GuaranteePeriod_cbo", "");
            dic.Add("btnGuaranteePeriod_C", "click");
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
            pAssumptions._TreeViewRightSelect(dic, "FOP4_Revers");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP4_Revers");
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
            pAssumptions._TreeViewRightSelect(dic, "FOP5_OOPB");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP5_OOPB");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "OOPB definite unmarried pension");
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
            pAssumptions._TreeViewRightSelect(dic, "FOP6_OOPO");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Form of Payment");
            dic.Add("Level_3", "FOP6_OOPO");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FormOfPaymentType", "OOPO indefinite unmarried pension");
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
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("MenuItem", "Add Adjustments");
            pAssumptions._TreeViewRightSelect(dic, "Adj1_PV");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Adjustments");
            dic.Add("Level_3", "Adj1_PV");
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
            pAssumptions._TreeViewRightSelect(dic, "PD1A_Ret");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD1A_Ret");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CustFB1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP1_SL");
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
            pAssumptions._TreeViewRightSelect(dic, "PD2_AllIn");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD2_AllIn");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "All inactives");
            dic.Add("SingleFormulaBenefit", "ComingServiceBenefitOPatValDate");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP1_SL");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD3A_Wth");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD3A_Wth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CAE1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP1_SL");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD4A_Dis");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD4A_Dis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAE2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP1_SL");
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
            pAssumptions._TreeViewRightSelect(dic, "PD5_InPay");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD5_InPay");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "In pay inactives");
            dic.Add("SingleFormulaBenefit", "ComingServiceBenefitNPatValDate");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD6_Def");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD6_Def");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "ComingServiceBenefitNPatValDate");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP3_SpDID");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD7_Def");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD7_Def");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "Deferred inactives");
            dic.Add("SingleFormulaBenefit", "ComingServiceBenefitNPatValDate");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD8A_Ret");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD8A_Ret");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CAE2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            pAssumptions._TreeViewRightSelect(dic, "PD9A_Death");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD9A_Death");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CAE2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP2_Spouse");
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
            pAssumptions._TreeViewRightSelect(dic, "PD10A_Wth");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD10A_Wth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CAE2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP3_SpDID");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD11A_Wth");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD11A_Wth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CAE2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD12A_Dis");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD12A_Dis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CustFB2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "Click");
            dic.Add("BenefitStopAge_txt", "65");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            pAssumptions._TreeViewRightSelect(dic, "PD13A_Dis");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD13A_Dis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CustFB2");
            dic.Add("Function", "");
            dic.Add("Validate", "");
            dic.Add("btnBenefitCommenceAge_V", "");
            dic.Add("BenefitCommenceAge_cbo", "");
            dic.Add("btnBenefitCommenceAge_C", "Click");
            dic.Add("BenefitCommenceAge_txt", "65");
            dic.Add("btnBenefitStopAge_V", "");
            dic.Add("BenefitStopAge_cbo", "");
            dic.Add("btnBenefitStopAge_C", "");
            dic.Add("BenefitStopAge_txt", "");
            dic.Add("VestingDefinition", "");
            dic.Add("CostOfLivingAdjustmentFactor", "COLA1p");
            dic.Add("EarlyRetirementFactor", "");
            dic.Add("LateRetirementFactor", "");
            dic.Add("AdjustmentFactor", "Adj1_PV");
            dic.Add("ConversionFactor", "");
            dic.Add("ConversionFactor_Married", "");
            dic.Add("ConversionFactor_Single", "");
            dic.Add("FormOfPayment", "FOP4_Revers");
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
            pAssumptions._TreeViewRightSelect(dic, "PD14A_Ret");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD14A_Ret");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FAE1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
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
            dic.Add("FormOfPayment", "FOP5_OOPB");
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
            pAssumptions._TreeViewRightSelect(dic, "PD15A_Wth");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD15A_Wth");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "FLAT1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
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
            dic.Add("FormOfPayment", "FOP6_OOPO");
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
            dic.Add("MenuItem", "Add Plan Definition");
            pAssumptions._TreeViewRightSelect(dic, "PD17A_Dis");

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD17A_Dis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "True");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "CashBalance1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
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
            dic.Add("FormOfPayment", "FOP1_SL");
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

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            pAssumptions._Collapse(dic);


            pMain._SelectTab("Acct2011Cnv");


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
            dic.Add("NormalCostForCYTermination", "Yes");
            pMethods._PopVerify_Methods_CA(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "Svc1_MembD");
            dic.Add("CompareToAccrue", "false");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("ProjectedpayToUse", "PProj3_Function");
            dic.Add("ProjectedpayToUse_CA", "");
            dic.Add("AccumulationToUse", "");
            dic.Add("IncludeExitYearValue", "");
            dic.Add("CalculatePresentValueOfFuture", "");
            dic.Add("CalculatePresentValueOfFuture_txt", "");
            dic.Add("VestingToUseForAgeFirstVested", "ImmediateVesting");
            dic.Add("AverageWorkingLifeTime", "True");
            dic.Add("AverageLifeTime", "True");
            dic.Add("AverageWorkingLifeTimeToVesting", "True");
            dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
            pMethods._PopVerify_Methods_Accounting(dic);

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

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sAccounting_Acct2011Cnv - Test case & Rseports


            pMain._SelectTab("Acct2011Cnv");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/25/1973\" And $emp.HireDate1=\"1/1/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/6/1960\" And $emp.HireDate1=\"3/13/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/20/1936\" And $emp.HireDate1=\"2/4/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            pMain._SelectTab("Acct2011Cnv");

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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PProj1");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
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


            pMain._SelectTab("Acct2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sAccounting_Acct2011Cnv, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Valuation Summary", "Conversion", true, false);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Acct2011Cnv, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Payout Projection", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "FAS Expected Benefit Pmts", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Acct2011Cnv, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sAccounting_Acct2011Cnv, "Payout Projection", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sAccounting_Acct2011Cnv, "FAS Expected Benefit Pmts", "Conversion", false, false);
            }


            thrd_Acct2011Cnv.Start();

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);


            #endregion



            #region sFunding_Fnd2011Cnv - ParticipantData

            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
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
            dic.Add("Name", "Fnd2011Cnv");
            dic.Add("Parent", "");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2011");
            dic.Add("FirstYearPlanUnderPPA", "");
            dic.Add("RSC", "True");
            dic.Add("LocalMarket", "");
            dic.Add("Shared", "");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pMain._PopVerify_Home_ServicePropeties(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Fnd2011Cnv");
            pMain._PopVerify_Home_RightPane(dic);

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
            dic.Add("SnapshotName", "DataSnap2011");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Funding Results");
            dic.Add("Level_2", "GRSGoingConcernAL");
            dic.Add("Data", "PayHistCurrentYear");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Results");
            dic.Add("Level_2", "GRSGoingConcernNC");
            dic.Add("Data", "AccruedBenefit1");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Results");
            dic.Add("Level_2", "GRSSolvencyAL");
            dic.Add("Data", "PayHistPriorYear1");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("Level_1", "Funding Results");
            dic.Add("Level_2", "GRSSolvencyNC");
            dic.Add("Data", "Benefit1DB");
            pParticipantDataSet._MapField(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("DataEffectiveDate", "");
            dic.Add("Snapshot", "");
            dic.Add("GRSUnload", "");
            dic.Add("GotoDataSystem", "");
            dic.Add("AddField", "");
            dic.Add("GRSInformation", "Click");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);


            dic.Clear();
            dic.Add("Decrement", "Retirement");
            dic.Add("FundingAL", "1575000");
            dic.Add("FundingNC", "130000");
            dic.Add("AccountingAL", "1000000");
            dic.Add("AccountingNC", "400000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Withdrawal");
            dic.Add("FundingAL", "1236000");
            dic.Add("FundingNC", "100000");
            dic.Add("AccountingAL", "900000");
            dic.Add("AccountingNC", "350000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);

            dic.Clear();
            dic.Add("Decrement", "Disability");
            dic.Add("FundingAL", "1230000");
            dic.Add("FundingNC", "85000");
            dic.Add("AccountingAL", "700000");
            dic.Add("AccountingNC", "120000");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Decrement", "Death");
            dic.Add("FundingAL", "40000");
            dic.Add("FundingNC", "500");
            dic.Add("AccountingAL", "344410");
            dic.Add("AccountingNC", "149895");
            dic.Add("Instance", "2");
            dic.Add("OK", "");
            pParticipantDataSet._GRSInformation_TotalsByDecrement(dic);


            dic.Clear();
            dic.Add("Row", "Number");
            dic.Add("Active", "63");
            dic.Add("Deferred", "153");
            dic.Add("Retired", "67");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Age");
            dic.Add("Active", "46,00");
            dic.Add("Deferred", "48,00");
            dic.Add("Retired", "75,00");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Service from Hire");
            dic.Add("Active", "13,00");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Average Pay");
            dic.Add("Active", "20000");
            dic.Add("Deferred", "");
            dic.Add("Retired", "");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

            dic.Clear();
            dic.Add("Row", "Annual Pension");
            dic.Add("Active", "");
            dic.Add("Deferred", "280000");
            dic.Add("Retired", "420000");
            dic.Add("OK", "Click");
            pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic);

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


            #region sFunding_Fnd2011Cnv - Assumption

            pMain._SelectTab("Fnd2011Cnv");

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
            dic.Add("YieldCurve", "true");
            dic.Add("Adjustments", "true");
            dic.Add("ForwardDuration", "true");
            dic.Add("AsOfDate", "31-12-2011");
            dic.Add("Adjustment1Operator_cbo", "+");
            dic.Add("Adjustment1_c", "0,01");
            dic.Add("Adjustment2Operator_cbo", "-");
            dic.Add("Adjustment2_p", "0,5");
            dic.Add("Adjustment3Operator_cbo", "*");
            dic.Add("Adjustment3_c", "1,05");
            dic.Add("ForwardDuration_txt", "2,25");
            pInterestRate._PopVerify_YieldCurve_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CustomR_2Percent");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CustomR_2Percent");
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
            dic.Add("Level_2", "Custom Rates");
            dic.Add("MenuItem", "Add Custom Rates");
            pAssumptions._TreeViewRightSelect(dic, "CustomR_Zero");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CustomR_Zero");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("MenuItem", "Add Pay Increase");
            pAssumptions._TreeViewRightSelect(dic, "PayIncrease1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Pay Increase");
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "3,25");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "3,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


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
            dic.Add("txtPercentMarried_M", "100,0");
            dic.Add("txtPercentMarried_F", "100,0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);



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
            dic.Add("PreDecrement", "AGPrognose20102060Hoog2010");
            dic.Add("PreCommencement", "AGPrognose20102060HoogMidden2010");
            dic.Add("PostCommencement", "AGPrognose20102060Laag2010");
            pMortalityDecrement._PrePostCommencement(dic);


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
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pAssumptions._SelectTab("Conditions");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDefinedEligibility", "");
            dic.Add("cboPreDefinedEligibility", "");
            dic.Add("LocalEligibility", "Click");
            dic.Add("txtLocalEligibility", "RetAge65");
            dic.Add("AddToEligibilities", "");
            dic.Add("EligibilityCondition", "$Age >64");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic);

            pAssumptions._SelectTab("Parameters");


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Withdrawal Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "TERM11");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Retirement Decrement");
            dic.Add("Level_3", "RetAge65");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "FIXRET");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DIS851");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("MenuItem", "Add Benefit Elections");
            pAssumptions._TreeViewRightSelect(dic, "BenElection1");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "BenElection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "75,0");
            dic.Add("ElectionTable_cbo", "");
            pBenefitElections._PopVerify_BenefitElections(dic);

            pMain._Home_ToolbarClick_Top(true);

            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "");
            dic.Add("ForwardDuration", "true");
            dic.Add("AsOfDate", "01-01-2012");
            dic.Add("ForwardDuration_txt", "2,00");
            pInterestRate._PopVerify_YieldCurve_NL(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Custom Rates");
            dic.Add("Level_3", "CustomR_2Percent");
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
            dic.Add("Level_3", "PayIncrease1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("btnV", "");
            dic.Add("btnPercent", "Click");
            dic.Add("btnT", "");
            dic.Add("txtRate", "2,75");
            dic.Add("cboRate", "");
            pPayIncrease._PopVerify_PayIncrease(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Cost of Living Increase");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("TimeBased", "");
            dic.Add("PercentIcon", "");
            dic.Add("TIcon", "");
            dic.Add("txtRate", "4,0");
            dic.Add("cboRate", "");
            pInterestRate._PopVerify_SameStructureForAllPeriods(dic);


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
            dic.Add("txtPercentMarried_M", "100,0");
            dic.Add("txtPercentMarried_F", "100,0");
            dic.Add("cboPercentMarried", "");
            dic.Add("btnDifferenceInSpouseAge_CIcon", "");
            dic.Add("btnDifferenceInSpouseAge_TIcon", "");
            dic.Add("txtDifferenceInSpouseAge_M", "");
            dic.Add("txtDifferenceInSpouseAge_F", "");
            dic.Add("cboDifferenceInSpouseAge", "");
            pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PrescribedRates", "");
            dic.Add("SameStructureForAllPeriods", "");
            dic.Add("DisabledVsHealthy", "");
            dic.Add("MemberVsSpouse", "True");
            pMortalityDecrement._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "AGPrognose20102060Hoog2010");
            dic.Add("Mortality_Setback_M", "");
            dic.Add("Mortality_Setback_F", "");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Spouse", "UP84");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "false");
            dic.Add("RetWithdrawDis", "DIS852");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sFunding_Fnd2011Cnv - Provision


            pMain._SelectTab("Fnd2011Cnv");


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
            dic.Add("ServiceInstance", "Acct2011Cnv");
            dic.Add("iTableItemIndex", "1");
            dic.Add("CopyAllParameters", "");
            dic.Add("CopyParameterChanges", "");
            dic.Add("OK", "click");
            pMain._PopVerify_CopyProvisionSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddServiceInstance", "");
            dic.Add("ServiceToOpen", "Fnd2011Cnv");
            pMain._PopVerify_Home_RightPane(dic);


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
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD13A_Dis");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "");
            dic.Add("Function", "");
            dic.Add("Validate", "");

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
            dic.Add("BenefitElectionPercentage", "BenElection1");
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
            dic.Add("Level_3", "PD17A_Dis");
            dic.Add("MenuItem", "Rename");
            pAssumptions._TreeViewRightSelect(dic, "PD16A_Dis");


            pMain._Home_ToolbarClick_Top(true);

            pMain._SelectTab("Fnd2011Cnv");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            pMethods._SelectTab("Solvency");


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("sName", "PD14A_Ret");
            dic.Add("sBenefitForCalculation", "");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "True");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "4");
            dic.Add("sName", "PD10A_Wth");
            dic.Add("sBenefitForCalculation", "");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "True");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "5");
            dic.Add("sName", "PD11A_Wth");
            dic.Add("sBenefitForCalculation", "");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "True");
            pMethods._BenefitsToValueForSolvency(dic);

            dic.Clear();
            dic.Add("iRow", "10");
            dic.Add("sName", "PD13A_Dis");
            dic.Add("sBenefitForCalculation", "");
            dic.Add("sImmediateVesting", "");
            dic.Add("sCOLA", "True");
            pMethods._BenefitsToValueForSolvency(dic);


            pMethods._SelectTab("Going Concern");

            pMethods._ResultsForStatisticsForExpected_Grid_IR(1, "CashBalance1");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "");
            dic.Add("ServiceForServiceProrate", "");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("NormalCostForCYTermination", "Midyear");
            dic.Add("ProjectedPayToUseForCoveredPay", "PProj2");
            dic.Add("AccumulationToUseForExepctedPVOfEmployee", "");
            dic.Add("IncludeChangesInPVFutureEEGainLoss", "");
            dic.Add("AccumulationToUseForExepctedPVOfEmployer", "");
            dic.Add("BeginningOfTheYearPVFuture", "");
            dic.Add("StopPVFuture_V", "");
            dic.Add("StopPVFuture_cbo", "");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);

            pMain._Home_ToolbarClick_Top(true);

            #endregion


            #region sFunding_Fnd2011Cnv - Test case & Reports

            pMain._SelectTab("Fnd2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/25/1973\" And $emp.HireDate1=\"1/1/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/6/1960\" And $emp.HireDate1=\"3/13/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/20/1936\" And $emp.HireDate1=\"2/4/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Fnd2011Cnv");


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
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PProj2");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            ///// // dic.Add("Acc_ProjectedBenefitObligation", "True");
            ///////  dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Fnd2011Cnv");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Fnd2011Cnv");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "1");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2011Cnv, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Valuation Summary", "Conversion", true, false);

            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Liability Summary", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Fnd2011Cnv, "Liability Summary", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Member Statistics", "Conversion", true, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Fnd2011Cnv, "Conversion Diagnostic", "Conversion", true, false, 0);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Conversion Diagnostic", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Test Case List", "Conversion", true, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Detailed Results", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Individual Output", "Conversion", true, false);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Payout Projection", "Conversion", true, false);
            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Liability Summary", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Fnd2011Cnv, "Liability Summary", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Member Statistics", "Conversion", false, false);
                pOutputManager._ExportReport_DrillDown(sFunding_Fnd2011Cnv, "Conversion Diagnostic", "Conversion", false, false, 0);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Conversion Diagnostic", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Test Case List", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Detailed Results", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Detailed Results by Plan Def", "Conversion", false, false);
                pOutputManager._ExportReport_Common(sFunding_Fnd2011Cnv, "Valuation Summary", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Individual Output", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "IOE", "Conversion", false, false);
                pOutputManager._ExportReport_Others(sFunding_Fnd2011Cnv, "Payout Projection", "Conversion", false, false);
            }


            thrd_Fnd2011Cnv.Start();

            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion



            #region sFunding_Fnd2012RF_Baseline

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
            dic.Add("Name", "Data2012RF");
            dic.Add("EffectiveDate", "01-01-2012");
            dic.Add("Parent", "Data2011Cnv");
            dic.Add("RSC", "True");
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
            dic.Add("ServiceToOpen", "Data2012RF");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Data2012RF");

            dic.Clear();
            dic.Add("Level_1", "Data2012RF");
            dic.Add("Level_2", "Imports");
            dic.Add("Level_3", "Imp1");
            pData._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileDefinitionName", "");
            dic.Add("FileType", "Excel file");
            dic.Add("Browse", "Click");
            dic.Add("Preview", "");
            pData._PopVerify_IP_SelectFile(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FileName", "Data_NLBench2012.xls");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pData._PopVerify_IP_SelectFile_FileSelection(dic);



            pData._SelectTab("Mapping");

            pData._CV_ExpandPersonalInformation();

            pData._IP_Mapping_Initialize("Personal Information", "Personal Information", 1, 0, 1, "EmployeeIDNumber");
            pData._IP_Mapping_Initialize("Personal Information", "Pay", 2, 17, 1, "PayHist");
            pData._IP_Mapping_Initialize("Personal Information", "PayHist", 3, 17, 1, "PayHistCurrentYear");

            pData._IP_Mapping_MapField("PayHistPriorYear3", "PayHistPriorYear2", 0, false, 0);

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("PopVerify", "Verify");
            dic.Add("Message", "Data validate & load SUCCESS.");
            dic.Add("OK", "");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
            dic.Add("OK", "Click");
            pData._PopVerify_IP_ValidateAndLoad_Popup(dic);

            pMain._Home_ToolbarClick_Top(true);


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
            dic.Add("Unique_NoMatch_Num", "3");
            dic.Add("Unique_UniqueMatch_Num", "283");
            dic.Add("Unique_MultipleMatches_Num", "0");
            dic.Add("Duplicate_NoMatch_Num", "");
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
            dic.Add("Message", "");
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
            dic.Add("PopVerify", "Pop");
            dic.Add("Message", "");
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
            dic.Add("Level_1", "Data2012RF");
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
            dic.Add("Level_3", "ParticipantStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "PayStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "HealthStatus");
            pData._TreeViewSelect_Snapshots(dic, false);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "AliveStatus");
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
            dic.Add("Level_3", "OrganizationCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Classification Codes");
            dic.Add("Level_3", "DivisionCode");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "DC Information");
            pData._TreeViewSelect_Snapshots(dic, true);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "DataSnap2012");
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


            pMain._SelectTab("Home");

            dic.Clear();
            dic.Add("Country", Config.eCountry.ToString());
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
            dic.Add("Name", "Fnd2012RF");
            dic.Add("Parent", "Fnd2011Cnv");
            dic.Add("ParentFinalValuationSet", "");
            dic.Add("PlanYearBeginningIn", "2012");
            dic.Add("FiscalYearEndingIn_Accounting", "");
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
            dic.Add("ServiceToOpen", "Fnd2012RF");
            dic.Add("CheckPopup", "False");
            pMain._PopVerify_Home_RightPane(dic);


            pMain._SelectTab("Fnd2012RF");

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
            dic.Add("Data_Name", "Baseline");
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
            dic.Add("CompareData", "");
            dic.Add("ImportDataandApplyMapping", "");
            pParticipantDataSet._PopVerify_ParticipantDataSet(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "DataSnap2012");
            dic.Add("OK", "Click");
            dic.Add("RetainThePreviousUnload", "");
            dic.Add("SpecifyANewSnapshotRetainingPrevious", "Click");
            dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
            dic.Add("SpecifyANewUnload", "");
            dic.Add("SelectSnapshotOption_OK", "Click");
            pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic);

            pParticipantDataSet._Initialzie();

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "PayHist");
            dic.Add("Level_4", "PayHistCurrentYear");
            pParticipantDataSet._Navigate(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "PayHist");
            dic.Add("Level_4", "PayHistCurrentYear");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "PayHist");
            dic.Add("Level_4", "PayHistPriorYear1");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "PayHist");
            dic.Add("Level_4", "PayHistPriorYear2");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
            pParticipantDataSet._SetFieldProperty(dic);

            dic.Clear();
            dic.Add("Level_1", "Personal Information");
            dic.Add("Level_2", "Pay");
            dic.Add("Level_3", "PayHist");
            dic.Add("Level_4", "PayHistPriorYear3");
            dic.Add("bIsIncludeInReport_Disabled", "false");
            dic.Add("bIncludeInReport", "true");
            dic.Add("sComparisonType", "");
            dic.Add("bALL", "");
            dic.Add("bACT", "");
            dic.Add("bDEF", "");
            dic.Add("bPEN", "");
            dic.Add("bServiceFirstSubItem", "False");
            dic.Add("bContinueWithoutCollapse", "True");
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


            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Test Case");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Test Case Library");

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"5/25/1973\" And $emp.HireDate1=\"1/1/2009\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"8/6/1960\" And $emp.HireDate1=\"3/13/1999\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/20/1936\" And $emp.HireDate1=\"2/4/1977\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            dic.Clear();
            dic.Add("SelectionCriteria", "$emp.BirthDate=\"12/28/1949\" And $emp.HireDate1=\"2/14/1998\"");
            dic.Add("iResultRow", "1");
            pTestCaseLibrary._AddTestCase(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Fnd2012RF");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PProj2");
            dic.Add("CurrentYear", "");
            dic.Add("PriorYear", "True");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            //////////dic.Add("Acc_ProjectedBenefitObligation", "True");
            //////////dic.Add("Acc_AccumulatedBenefitObligation", "True");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);


            pMain._SelectTab("Fnd2012RF");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
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
            dic.Add("ShowSubtotalBreaks", "DivisionCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);


            pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Parameter Print", "RollForward", true, true);


            if (Config.bDownloadReports_PDF)
            {
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation To Prior Year", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation To Prior Year With Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "DetailedResults", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "DetailedResults With Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Individual Checking Template", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Payout Projection", "RollForward", true, true);

            }


            if (Config.bDownloadReports_EXCEL)
            {
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation to Prior Year", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation to Prior Year with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation to Prior Year by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Reconciliation to Prior Year by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Status Reconciliation", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Member Statistics", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Individual Checking Template", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Age Service Matrix", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Individual Output", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_Baseline, "Payout Projection", "RollForward", false, true);
            }


            thrd_Fnd2012RF_Baseline.Start();

            pMain._Home_ToolbarClick_Top(true);

            #endregion
            

            #region sFunding_Fnd2012RF_FndChld1

            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "2");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Add Valuation Node");
            pMain._FlowTreeRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ValNodeName", "FndChld1");
            dic.Add("LiabilityValuationDate", "");
            dic.Add("Data_AddNew", "");
            dic.Add("Data_Name", "");
            dic.Add("Data_Edit", "");
            dic.Add("Assumptions_AddNew", "True");
            dic.Add("Assumptions_Name", "FndChld1 Assumptions");
            dic.Add("Assumptions_Edit", "");
            dic.Add("MethodsLiabilities_AddNew", "True");
            dic.Add("MethodsLiabilities_Name", "FndChld1 Methods");
            dic.Add("MethodsLiabilities_Edit", "");
            dic.Add("Provisions_AddNew", "True");
            dic.Add("Provisions_Name", "FndChld1 Provisions");
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
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Assumptions");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "");
            dic.Add("ForwardDuration", "");
            dic.Add("AsOfDate", "");
            dic.Add("Adjustment1Operator_cbo", "");
            dic.Add("Adjustment1_c", "");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "1,25");
            pInterestRate._PopVerify_YieldCurve_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PreDecrement", "");
            dic.Add("PreCommencement", "");
            dic.Add("PostCommencement", "");

            dic.Add("PreDecrement_SetBack_M", "1");
            dic.Add("PreDecrement_SetBack_F", "-1");
            dic.Add("PreDecrement_Weighting_M", "75");
            dic.Add("PreDecrement_Weighting_F", "");

            dic.Add("PreCommencement_SetBack_M", "2");
            dic.Add("PreCommencement_SetBack_F", "-3");
            dic.Add("PreCommencement_Weighting_M", "");
            dic.Add("PreCommencement_Weighting_F", "75");

            dic.Add("PostCommencement_SetBack_M", "-1");
            dic.Add("PostCommencement_SetBack_F", "2");
            dic.Add("PostCommencement_Weighting_M", "50");
            dic.Add("PostCommencement_Weighting_F", "50");
            pMortalityDecrement._PrePostCommencement(dic);



            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DIS852");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Benefit Elections");
            dic.Add("Level_3", "BenElection1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Button_V", "");
            dic.Add("Button_Percent", "");
            dic.Add("Button_T", "");
            dic.Add("ElectionPercentage_cbo", "");
            dic.Add("ElectionPercentage_txt", "");
            dic.Add("ElectionTable_cbo", "");
            dic.Add("Adjustment", "true");
            dic.Add("Adjustment1_cbo", "+");
            dic.Add("Adjustment_P", "click");
            dic.Add("Adjustment_P_txt", "5,0");
            pBenefitElections._PopVerify_BenefitElections(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMethods._SelectTab("Solvency");

            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Interest Rate");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("YieldCurve", "");
            dic.Add("Adjustments", "");
            dic.Add("ForwardDuration", "true");
            dic.Add("AsOfDate", "31-12-2011");
            dic.Add("Adjustment1Operator_cbo", "");
            dic.Add("Adjustment1_c", "");
            dic.Add("Adjustment2Operator_cbo", "");
            dic.Add("Adjustment2_p", "");
            dic.Add("Adjustment3Operator_cbo", "");
            dic.Add("Adjustment3_c", "");
            dic.Add("ForwardDuration_txt", "2,75");
            pInterestRate._PopVerify_YieldCurve_NL(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Mortality Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Mortality", "");
            dic.Add("Mortality_Setback_M", "1");
            dic.Add("Mortality_Setback_F", "-1");
            dic.Add("Disabled", "");
            dic.Add("Disabled_Setback_M", "");
            dic.Add("Disabled_Setback_F", "");
            dic.Add("Disabled_Setback_M_NL", "");
            dic.Add("Disabled_Setback_F_NL", "");
            dic.Add("ProjectionScale", "");
            dic.Add("ProjectToYear", "");
            dic.Add("Spouse", "UP84");
            dic.Add("Spouse_Weighting_M", "75");
            dic.Add("Spouse_Weighting_F", "80");
            pMortalityDecrement._PopVerify_SameStructureForAll(dic);


            dic.Clear();
            dic.Add("Level_1", "Assumptions");
            dic.Add("Level_2", "Disability Decrement");
            dic.Add("Level_3", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Adjustments", "");
            dic.Add("RetWithdrawDis", "DIS853");
            pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic);

            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Fnd2012RF");

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
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("ApplyPayLimitAfterDeduction", "True");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Deduction_V", "");
            dic.Add("Deduction_C", "click");
            dic.Add("Deduction_T", "");
            dic.Add("DeductionAnnualIncrease_V", "click");
            dic.Add("LimitAmount_C", "click");
            dic.Add("LimitAmount_C_txt", "57500");
            dic.Add("AnnualLimitIncrease_P", "click");
            dic.Add("AnnualLimitIncrease_P_txt", "0,25");
            pPayoutProjection._ApplyPayLimitAfterDeduction_WithDeduction(dic);



            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj3_Function");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Function", "$PProj1/2+$PProj2/3+111");
            dic.Add("Validate", "click");
            pPlanDefinition._PopVerify_PlanDefinition(dic);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Projection");
            dic.Add("Level_3", "PProj4_Custom");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("History", "");
            dic.Add("PresentYear", "");
            dic.Add("FunctionOfOtherProjections", "");
            dic.Add("CustomCode", "Click");
            dic.Add("PlanPayLimitDefinition", "");
            dic.Add("ApplyDeduction", "");
            dic.Add("LegislatedPayLimitDefinition", "");
            pPayoutProjection._PopVerify_Main(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "");
            dic.Add("Name", "");
            dic.Add("Expression", "$PProj1*$emp.PTCurrent+55");
            dic.Add("Validate", "Click");
            pAssumptions._PopVerify_Provision_CustomCode(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            dic.Add("Level_2", "Pay Average");
            dic.Add("Level_3", "PayAv3");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("PayProjectionToAverage", "");
            dic.Add("AveragingMethod", "");
            dic.Add("M", "");
            dic.Add("RoundingForYearOfHire", "");
            dic.Add("DecimalPlacesForYearOfHire", "");
            dic.Add("Include", "");
            dic.Add("DropForCalculations", "");
            dic.Add("DropForCalculationAndPeriodConsidered", "Click");
            dic.Add("AdjustmentPeriodMonths", "3");
            dic.Add("AdjustmentMethod", "Adjustment factor");
            pPayAverage._PopVerify_Standard(dic);

            dic.Clear();
            dic.Add("Level_1", "Participant Info");
            pAssumptions._Collapse(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CAE1");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_cbo", "CustomR_2Percent");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);



            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Formulae");
            dic.Add("Level_3", "Career Average Earnings Formula");
            dic.Add("Level_4", "CAE2");
            dic.Add("Level_5", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Revaluation_Rate_cbo", "");
            dic.Add("Revaluation_Rate_txt", "3,0");
            dic.Add("StartingAmountAsOfAmount", "");
            dic.Add("StrartingAccruedAmount_V", "");
            dic.Add("StrartingAccruedAmount_C", "");
            dic.Add("StrartingAccruedAmount_cbo", "");
            dic.Add("StrartingAccruedAmount_txt", "");
            dic.Add("StopAccrualAt_V", "");
            dic.Add("StopAccrualAt_C", "");
            dic.Add("StopAccrualAt_cbo", "");
            dic.Add("StopAccrualAt_txt", "");
            dic.Add("RateTiersBaseOn", "");
            pCareerAverageEarmingsFormula._Formula(dic);


            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Inactive Benefit Payment");
            dic.Add("MenuItem", "Add Inactive Benefit Payment");
            pAssumptions._TreeViewRightSelect(dic, "InBenPmt1");

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            dic.Add("Level_2", "Inactive Benefit Payment");
            dic.Add("Level_3", "InBenPmt1");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);


            dic.Clear();
            dic.Add("iRow", "1");
            dic.Add("Operation", "");
            dic.Add("BenefitAmount_cbo", "AccruedBenefit1");
            dic.Add("StartDate", "$ValAge");
            dic.Add("StopDate", "$FullMortAge");
            dic.Add("BeneficiaryAmount_txt", "4567,00");
            dic.Add("COLA", "COLA1p");
            pInactiveBenefitPayment._TBL_InactiveBenefits(dic);

            dic.Clear();
            dic.Add("Level_1", "Provisions");
            pAssumptions._Collapse(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            dic.Add("Level_2", "Plan Definition");
            dic.Add("Level_3", "PD7_Def");
            dic.Add("Level_4", "Default");
            pAssumptions._TreeViewSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SingleFormulaOrBenefit", "");
            dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
            dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
            dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
            dic.Add("ParticipantType", "");
            dic.Add("SingleFormulaBenefit", "InBenPmt1");
            dic.Add("Function", "");
            dic.Add("Validate", "");
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

            pMain._Home_ToolbarClick_Top(true);

            dic.Clear();
            dic.Add("Level_1", "Benefit Definition");
            pAssumptions._Collapse(dic);


            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "Liability Methods");
            dic.Add("MenuItem_2", "Edit Parameters");
            pMain._FlowTreeRightSelect(dic);

            pMain._SelectTab("Methods");

            pMethods._SelectTab("Going Concern");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CostMethod", "Projected Unit Credit Service Prorate");
            dic.Add("ServiceForServiceProrate", "$Service");
            dic.Add("CompareToAccrue", "");
            dic.Add("AllowNegativeNormalCost", "");
            dic.Add("NormalCostForCYTermination", "Yes");
            dic.Add("ProjectedPayToUseForCoveredPay", "");
            dic.Add("AccumulationToUseForExepctedPVOfEmployee", "");
            dic.Add("IncludeChangesInPVFutureEEGainLoss", "");
            dic.Add("AccumulationToUseForExepctedPVOfEmployer", "");
            dic.Add("BeginningOfTheYearPVFuture", "");
            dic.Add("StopPVFuture_V", "");
            dic.Add("StopPVFuture_cbo", "");
            pMethods._PopVerify_Methods_Funding_GoningConcern(dic);

            pMain._Home_ToolbarClick_Top(true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("BenefitDefinition", "PD8A_Ret");
            dic.Add("PUCOverrides", "Traditional Unit Credit");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "click");
            dic.Add("iRow", "2");
            dic.Add("BenefitDefinition", "PD11A_Wth");
            dic.Add("PUCOverrides", "Projected Unit Credit Service Prorate");
            dic.Add("TUCOverrides", "");
            dic.Add("ServiceForProrate", "Svc1_MembD");
            dic.Add("SpecialAttribute", "");
            pMethods._MethodOverrieds_BenefitDefinition_NL(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddRow", "");
            dic.Add("iRow", "1");
            dic.Add("Formula", "CashBalance1");
            dic.Add("PUCOverrides", "Traditional Unit Credit");
            dic.Add("ServiceForProrate", "");
            dic.Add("SpecialAttribute", "Cash Balance Benefit");
            dic.Add("TransitionBalance", "AccruedBenefit1");
            dic.Add("WithInterest", "CashBalance1");
            pMethods._MethodOverrieds_Formula_NL(dic);



            pMain._Home_ToolbarClick_Top(true);


            pMain._SelectTab("Fnd2012RF");

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
            dic.Add("GL_PPANAR_Min", "");
            dic.Add("GL_PPANAR_Max", "");
            dic.Add("GL_EAN", "");
            dic.Add("EstimateNextYearLiabilityForAFTAP", "");
            dic.Add("PayoutProjection", "True");
            dic.Add("IncludeIOE", "True");
            dic.Add("GenerateParameterPrint", "True");
            dic.Add("GenerateTestCaseOutput", "True");
            dic.Add("IncludeGainLossResult", "");
            dic.Add("Service", "$Service");
            dic.Add("Pay", "PProj2");
            dic.Add("CurrentYear", "Click");
            dic.Add("PriorYear", "");
            dic.Add("CashBanlance", "AccruedBenefit1");
            dic.Add("Pension", "Benefit1DB");
            dic.Add("AllLiabilityTypes", "");
            dic.Add("PayoutProjectionCustomGroup", "Gender");
            dic.Add("RunValuation", "Click");
            dic.Add("OK", "");
            pMain._PopVerify_RunOptions(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pMain._PopVerify_EnterpriseRunSubmitted(dic);

            pMain._SelectTab("Fnd2012RF");


            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Run Status");
            pMain._FlowTreeRightSelect(dic);

            pMain._EnterpriseRun("Group Job Successfully Complete", true);

            pMain._SelectTab("Fnd2012RF");

            dic.Clear();
            dic.Add("iMaxRowNum", "");
            dic.Add("iMaxColNum", "");
            dic.Add("iSelectRowNum", "3");
            dic.Add("iSelectColNum", "1");
            dic.Add("MenuItem_1", "View Output");
            pMain._FlowTreeRightSelect(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Doer", "True");
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
            dic.Add("ShowSubtotalBreaks", "DivisionCode");
            dic.Add("OK", "click");
            pOutputManager._PopVerify_OutputManagerSetup(dic);

            pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Valuation Summary", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Parameter Print", "RollForward", true, true);
            pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Test Cases", "RollForward", true, true);

            if (Config.bDownloadReports_PDF)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Individual Output", "RollForward", true, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Payout Projection", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline", "RollForward", true, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results", "RollForward", true, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
            }


            if (Config.bDownloadReports_EXCEL)
            {

                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liability Scenario by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Common(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Valuation Summary", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "IOE", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Payout Projection", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
                pOutputManager._ExportReport_SubReports(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
                pOutputManager._ExportReport_Others(Config.eCountry, sFunding_Fnd2012RF_FndChld1, "Individual Output", "RollForward", false, true);
            }


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001CN", sFunding_Fnd2012RF_FndChld1_Prod, sFunding_Fnd2012RF_FndChld1);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding_Fnd2012RF_FndChld1");

                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinewithBreaks_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDefwithBreaks_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultswithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenario_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariowithBreaks_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDef_Solvency.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0, true);
                _compareReportsLib.CompareExcel_Exact("LiabilityScenariobyPlanDefwithBreaks_Solvency.xlsx", 4, 0, 0, 0, true);
            }

            pMain._SelectTab("Fnd2012RF");
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);

            #endregion


            _gLib._MsgBox("", "Finished!");

        }



        public void t_CompareRpt_Acct2011Cnv(string sAccounting_Acct2011Cnv)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001CN", sAccounting_Acct2011Cnv_Prod, sAccounting_Acct2011Cnv);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sAccounting_Acct2011Cnv");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                /////////////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FASExpectedBenefitPmts.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }
         
        public void t_CompareRpt_Fnd2011Cnv(string sFunding_Fnd2011Cnv)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001CN", sFunding_Fnd2011Cnv_Prod, sFunding_Fnd2011Cnv);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding_Fnd2011Cnv");
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_ActiveMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_DeferredMembers.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("LiabilitySummary_Pensioners.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByNone.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByStatusCodes.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ConversionDiagnostic_GroupByCustom_Gender.xlsx", 4, 0, 0, 0);
                ////// _compareReportsLib.CompareExcel_Exact("TestCaseList.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                //////_compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                Config.bThreadFinsihed = true;
            }
        }

        public void t_CompareRpt_Fnd2012RF_Baseline(string sFunding_Fnd2012RF_Baseline)
        {
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("NL001CN", sFunding_Fnd2012RF_Baseline_Prod, sFunding_Fnd2012RF_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sFunding_Fnd2012RF_Baseline");

                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYear_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearwithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDef_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_GoingConcern.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ReconciliationtoPriorYearbyPlanDefwithBreaks_Solvency.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResults.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultswithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDef.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("DetailedResultsbyPlanDefwithBreaks.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("StatusReconciliation.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("MemberStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_CheckingGroupStatistics.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_MovementAndRollforward.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualCheckingTemplate_OutlierSummary.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("AgeServiceMatrix.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("ValuationSummary.xlsx", 11, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("IndividualOutput.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("PayoutProjection.xlsx", 4, 0, 0, 0);
                //////////    _compareReportsLib.CompareExcel_Exact("IOE.xlsx", 7, 0, 0, 0);
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
